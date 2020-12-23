﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

namespace AuroraEngine
{
    public class GFFLoader
    {
        private GFFObject TopStruct { get; set; }

        private const int DWORD_SIZE = 4, STRING_SIZE = 16, STRUCT_SIZE = 12;

        private Stream file;
        private long structoffset, fieldoffset, labeloffset, fdoffset, fioffset, lioffset;
        private int structcount, fieldcount, labelcount, fdcount, ficount, licount;

        public GFFLoader(Stream file)
        {
            this.file = file;

            //read the file type and version
            byte[] buffer = new byte[DWORD_SIZE * 14];
            file.Read(buffer, 0, DWORD_SIZE * 14);

            string filetype = Encoding.ASCII.GetString(buffer, 0, 4);
            string filever = Encoding.ASCII.GetString(buffer, 4, 4);

            //get the offset to and number of structs in the file
            structoffset = BitConverter.ToUInt32(buffer, 8);
            structcount = BitConverter.ToInt32(buffer, 12);

            //get the offset to and number of fields in the file
            fieldoffset = BitConverter.ToUInt32(buffer, 16);
            fieldcount = BitConverter.ToInt32(buffer, 20);

            //get the offset to and number of labels in the file
            labeloffset = BitConverter.ToUInt32(buffer, 24);
            labelcount = BitConverter.ToInt32(buffer, 28);

            //get the offset to and number of field data in the file
            fdoffset = BitConverter.ToUInt32(buffer, 32);
            fdcount = BitConverter.ToInt32(buffer, 36);

            //get the offset to and number of field indices in the file
            fioffset = BitConverter.ToUInt32(buffer, 40);
            ficount = BitConverter.ToInt32(buffer, 44);

            //get the offset to and number of list indices in the file
            lioffset = BitConverter.ToUInt32(buffer, 48);
            licount = BitConverter.ToInt32(buffer, 52);

            //read the top level struct, recursively reading the file
            GFFStructDef def = ReadStruct(0);
            TopStruct = new GFFObject(null, GFFObject.FieldType.Struct, def.structValue, def.structID);
        }

        public GFFObject GetObject()
        {
            return TopStruct;
        }

        public class GFFStructDef
        {
            public Dictionary<string, GFFObject> structValue;
            public uint structID;

            public GFFStructDef(Dictionary<string, GFFObject> dict, uint id)
            {
                structValue = dict;
                structID = id;
            }
        }

        /// <summary>
        /// Creates a new GFFStruct and reads all of the child fields associated with the struct at the given index in the GFF file
        /// </summary>
        private GFFStructDef ReadStruct(uint index)
        {
            long pos = file.Position;
            file.Position = structoffset + (STRUCT_SIZE * index);

            byte[] buffer = new byte[STRUCT_SIZE];
            file.Read(buffer, 0, STRUCT_SIZE);

            uint type = BitConverter.ToUInt32(buffer, 0);
            uint id = BitConverter.ToUInt32(buffer, 4);
            uint count = BitConverter.ToUInt32(buffer, 8);

            file.Position = pos;

            uint[] fieldIndices = new uint[count];

            //if count = 1, data is an index into the field array
            if (count == 1)
            {
                fieldIndices[0] = BitConverter.ToUInt32(buffer, 4);
            }
            //if count > 1, data is a byte offset into the field indices array, which itself contains an array of indices into the field array
            else
            {
                int dataOffset = BitConverter.ToInt32(buffer, 4);

                pos = file.Position;

                file.Position = fioffset + dataOffset;

                buffer = new byte[DWORD_SIZE * count];
                file.Read(buffer, 0, DWORD_SIZE * (int)count);

                file.Position = pos;

                //convert each field index from the buffer into an int
                for (int i = 0; i < count; i++)
                {
                    fieldIndices[i] = BitConverter.ToUInt32(buffer, i * DWORD_SIZE);
                }
            }

            Dictionary<string, GFFObject> fields = new Dictionary<string, GFFObject>((int)count);

            GFFObject field;
            for (int i = 0; i < count; i++)
            {
                field = ReadField(fieldIndices[i]);

                fields[field.Label] = field;
            }

            return new GFFStructDef(fields, type);
        }

        private GFFObject ReadField(uint index)
        {
            //fields are returned as a tuple (label, data) for ease of parsing
            long pos = file.Position;
            file.Position = fieldoffset + (index * DWORD_SIZE * 3);

            byte[] buffer = new byte[DWORD_SIZE * 3];
            file.Read(buffer, 0, DWORD_SIZE * 3);

            string label = ReadLabel(BitConverter.ToUInt32(buffer, 4));
            //label = label.Replace(" ", "");
            file.Position = pos;

            GFFObject.FieldType type = (GFFObject.FieldType)BitConverter.ToUInt32(buffer, 0);
            switch (type)
            {
                case GFFObject.FieldType.Byte:
                    return new GFFObject(label, type, buffer[8]);
                case GFFObject.FieldType.Char:
                    return new GFFObject(label, type, (char)buffer[8]);
                case GFFObject.FieldType.Word:
                    return new GFFObject(label, type, BitConverter.ToUInt16(buffer, 8));
                case GFFObject.FieldType.Short:
                    return new GFFObject(label, type, BitConverter.ToInt16(buffer, 8));
                case GFFObject.FieldType.DWord:
                    return new GFFObject(label, type, BitConverter.ToUInt32(buffer, 8));
                case GFFObject.FieldType.Int:
                    return new GFFObject(label, type, BitConverter.ToInt32(buffer, 8));
                case GFFObject.FieldType.DWord64:
                    return new GFFObject(label, type, ReadUInt64(BitConverter.ToUInt32(buffer, 8)));
                case GFFObject.FieldType.Int64:
                    return new GFFObject(label, type, ReadInt64(BitConverter.ToUInt32(buffer, 8)));
                case GFFObject.FieldType.Float:
                    return new GFFObject(label, type, BitConverter.ToSingle(buffer, 8));
                case GFFObject.FieldType.Double:
                    return new GFFObject(label, type, ReadDouble(BitConverter.ToUInt32(buffer, 8)));
                case GFFObject.FieldType.CExoString:
                    return new GFFObject(label, type, ReadString(BitConverter.ToUInt32(buffer, 8)));
                case GFFObject.FieldType.ResRef:
                    return new GFFObject(label, type, ReadResRef(BitConverter.ToUInt32(buffer, 8)));
                case GFFObject.FieldType.CExoLocString:
                    return new GFFObject(label, type, ReadLocalizedString(BitConverter.ToUInt32(buffer, 8)));
                case GFFObject.FieldType.Void:
                    return new GFFObject(label, type, ReadBytes(BitConverter.ToUInt32(buffer, 8)));
                case GFFObject.FieldType.Struct:
                    GFFStructDef def = ReadStruct(BitConverter.ToUInt32(buffer, 8));
                    return new GFFObject(label, type, def.structValue, def.structID);
                case GFFObject.FieldType.List:
                    return new GFFObject(label, type, ReadList(BitConverter.ToUInt32(buffer, 8)));
                case GFFObject.FieldType.Quaternion:
                    return new GFFObject(label, type, ReadQuaternion(BitConverter.ToUInt32(buffer, 8)));
                case GFFObject.FieldType.Vector3:
                    return new GFFObject(label, type, ReadVector3(BitConverter.ToUInt32(buffer, 8)));
                default:
                    Debug.LogWarningFormat("{0} has unknown GFF type ID: {1}", label, type);
                    return new GFFObject(label, type, null);
            }
        }

        private GFFObject[] ReadList(long offset)
        {
            long pos = file.Position;
            file.Position = lioffset + offset;

            //read the size of the list
            byte[] buffer = new byte[DWORD_SIZE];
            file.Read(buffer, 0, buffer.Length);
            uint count = BitConverter.ToUInt32(buffer, 0);

            //read the elements of the list (each being 1 uint index into the struct array)
            buffer = new byte[DWORD_SIZE * count];
            file.Read(buffer, 0, buffer.Length);

            file.Position = pos;

            GFFObject[] structs = new GFFObject[count];
            for (int i = 0, j = 0; i < count; i++, j += DWORD_SIZE)
            {
                GFFStructDef def = ReadStruct(BitConverter.ToUInt32(buffer, j));
                structs[i] = new GFFObject(null, GFFObject.FieldType.Struct, def.structValue, def.structID);
            }

            return structs;
        }

        private string ReadLabel(uint index)
        {
            //labels are stored in the label array and follow the same rules as resrefs i.e. 16 characters max non null terminated, but there's no need to enforce case insensitivity
            long pos = file.Position;
            file.Position = labeloffset + (STRING_SIZE * index);

            byte[] buffer = new byte[STRING_SIZE];
            file.Read(buffer, 0, STRING_SIZE);

            file.Position = pos;

            return Encoding.ASCII.GetString(buffer).TrimEnd('\0');
        }

        private ulong ReadUInt64(long offset)
        {
            long pos = file.Position;
            file.Position = fdoffset + offset;

            byte[] buffer = new byte[8];
            file.Read(buffer, 0, 8);
            file.Position = pos;

            return BitConverter.ToUInt64(buffer, 0);
        }

        private long ReadInt64(long offset)
        {
            long pos = file.Position;
            file.Position = fdoffset + offset;

            byte[] buffer = new byte[8];
            file.Read(buffer, 0, 8);
            file.Position = pos;

            return BitConverter.ToInt64(buffer, 0);
        }

        private double ReadDouble(long offset)
        {
            long pos = file.Position;
            file.Position = fdoffset + offset;

            byte[] buffer = new byte[8];
            file.Read(buffer, 0, 8);
            file.Position = pos;

            return BitConverter.ToDouble(buffer, 0);
        }

        //private GFFObject.CExoString ReadString(long offset)
        private GFFObject.CExoString ReadString(long offset)
        {
            long pos = file.Position;
            file.Position = fdoffset + offset;

            byte[] buffer = new byte[DWORD_SIZE];
            file.Read(buffer, 0, DWORD_SIZE);

            int length = (int)BitConverter.ToUInt32(buffer, 0);

            buffer = new byte[length];
            file.Read(buffer, 0, length);

            file.Position = pos;

            GFFObject.CExoString str = new GFFObject.CExoString();
            str.str = Encoding.UTF8.GetString(buffer);
            return str;
        }

        private string ReadResRef(long offset)
        {
            //resrefs in gff objects start with a single byte for the length (they still have a max size of 16), so there's no need to trim, but they still should be case agnostic
            long pos = file.Position;
            file.Position = fdoffset + offset;

            int length = file.ReadByte();
            byte[] buffer = new byte[length];
            file.Read(buffer, 0, length);

            file.Position = pos;
            return Encoding.UTF8.GetString(buffer).ToLower();
        }

        private GFFObject.CExoLocString ReadLocalizedString(long offset)
        {
            long pos = file.Position;
            file.Position = fdoffset + offset;

            //the first int is the size of the structure in bytes
            byte[] buffer = new byte[DWORD_SIZE];
            file.Read(buffer, 0, DWORD_SIZE);
            int structSize = (int)BitConverter.ToUInt32(buffer, 0);

            buffer = new byte[structSize];
            file.Read(buffer, 0, structSize);

            uint stringref = BitConverter.ToUInt32(buffer, 0);  //index into the user's tlk file or 0xFFFFFFFF if the string doesn't reference the tlk file
            uint count = BitConverter.ToUInt32(buffer, 4);      //how many substrings are there
            List<GFFObject.CExoLocString.SubString> strings = new List<GFFObject.CExoLocString.SubString>();

            int stringLength;
            for (int i = 0, j = 8; i < count; i++)
            {
                // TODO: I was debugging this at some point - why?
                strings.Add(new GFFObject.CExoLocString.SubString());

                //string id = (2 x language id) + gender
                strings[i].strid = BitConverter.ToInt32(buffer, j + 0);

                stringLength = BitConverter.ToInt32(buffer, j + 4);
                //Debug.Log("String length: " + stringLength);

                strings[i].str = Encoding.UTF8.GetString(buffer, j + 8, stringLength);
                //Debug.Log("Substring: " + strings[i].str);

                //foreach (char c in Encoding.UTF8.GetString(buffer, j + 8, stringLength))
                //{
                //    Debug.Log((int)c);
                //}
                j += 8 + stringLength;
            }

            file.Position = pos;

            return new GFFObject.CExoLocString
            {
                stringref = stringref,
                stringcount = count,
                strings = strings
            };
        }

        private Vector3 ReadVector3(long offset)
        {
            long pos = file.Position;
            file.Position = fdoffset + offset;

            byte[] buffer = new byte[12];
            file.Read(buffer, 0, 12);

            file.Position = pos;

            return new Vector3(BitConverter.ToSingle(buffer, 0), BitConverter.ToSingle(buffer, 8), BitConverter.ToSingle(buffer, 4));
        }

        private Quaternion ReadQuaternion(long offset)
        {
            long pos = file.Position;
            file.Position = fdoffset + offset;

            byte[] buffer = new byte[16];
            file.Read(buffer, 0, 16);

            file.Position = pos;

            return new Quaternion(BitConverter.ToSingle(buffer, 0), BitConverter.ToSingle(buffer, 4), BitConverter.ToSingle(buffer, 8), BitConverter.ToSingle(buffer, 12));
        }

        private byte[] ReadBytes(long offset)
        {
            long pos = file.Position;
            file.Position = fdoffset + offset;

            //the first int is the size of the structure in bytes
            byte[] buffer = new byte[DWORD_SIZE];
            file.Read(buffer, 0, DWORD_SIZE);
            int arraySize = (int)BitConverter.ToUInt32(buffer, 0);

            buffer = new byte[arraySize];
            file.Read(buffer, 0, arraySize);

            return buffer;
        }
    }
}