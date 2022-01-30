﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

namespace AuroraEngine
{
    public class ERFObject : AuroraArchive
    {
        public const int HEADER_SIZE = 160, KEY_SIZE = 24, RES_SIZE = 8;

        public Dictionary<(string, ResourceType), uint> resourceKeys;
        public (uint, uint)[] resourcePointers;

        public ERFObject(string filepath) : base(filepath) { }

        public ERFObject(Stream stream) : base(stream) { }

        public override void SetupArchive()
        {
            byte[] buffer;

            //Read header
            buffer = new byte[HEADER_SIZE];
            memoryStream.Read(buffer, 0, HEADER_SIZE);

            string fileType = Encoding.UTF8.GetString(buffer, 0, 4);
            string fileVersion = Encoding.UTF8.GetString(buffer, 4, 4);

            uint languageCount = BitConverter.ToUInt32(buffer, 8);
            uint localizedStringSize = BitConverter.ToUInt32(buffer, 12);
            uint resourceCount = BitConverter.ToUInt32(buffer, 16);
            uint offsetToLocalizedStrings = BitConverter.ToUInt32(buffer, 20);
            uint offsetToKeyList = BitConverter.ToUInt32(buffer, 24);
            uint offsetToResourceList = BitConverter.ToUInt32(buffer, 28);

            byte[] buildYear = new byte[4], buildDay = new byte[4], descriptionStrRef = new byte[4], reserved = new byte[116];
            Array.Copy(buffer, 32, buildYear, 0, 4);
            Array.Copy(buffer, 36, buildDay, 0, 4);
            Array.Copy(buffer, 40, descriptionStrRef, 0, 4);
            Array.Copy(buffer, 44, reserved, 0, 116);

            //Read localized strings (these don't seem to exist in the kotor ERFs?)
            memoryStream.Position = offsetToLocalizedStrings;
            for (int i = 0; i < languageCount; i++)
            {

            }

            //Read resource keys
            resourceKeys = new Dictionary<(string, ResourceType), uint>((int)resourceCount);

            buffer = new byte[resourceCount * KEY_SIZE];
            memoryStream.Position = offsetToKeyList;
            memoryStream.Read(buffer, 0, (int)resourceCount * KEY_SIZE);

            Debug.Log("Loading " + resourceCount + " resources from " + filePath);
            for (int i = 0; i < resourceCount; i++)
            {
                string resref = Encoding.UTF8.GetString(buffer, (i * KEY_SIZE) + 0, 16).TrimEnd('\0').ToLower();    //resrefs are always case insensitive
                uint index = BitConverter.ToUInt32(buffer, (i * KEY_SIZE) + 16);
                uint type = BitConverter.ToUInt16(buffer, (i * KEY_SIZE) + 20);

                resourceKeys.Add((resref, (ResourceType)type), index);

                // Debug.Log("Loaded resource " + resref + " from " + filePath);
            }

            //Read resource list
            resourcePointers = new (uint, uint)[resourceCount];

            buffer = new byte[resourceCount * RES_SIZE];
            memoryStream.Position = offsetToResourceList;
            memoryStream.Read(buffer, 0, (int)resourceCount * RES_SIZE);

            for (int i = 0; i < resourceCount; i++)
            {
                uint offset = BitConverter.ToUInt32(buffer, (i * RES_SIZE) + 0);
                uint size = BitConverter.ToUInt32(buffer, (i * RES_SIZE) + 4);

                resourcePointers[i] = (offset, size);
            }
        }

        public override Stream GetResource(string resref, ResourceType type)
        {
            uint value;

            if (resourceKeys.TryGetValue((resref.ToLower(), type), out value))
            {
                var pointer = resourcePointers[value];

                memoryStream.Position = pointer.Item1;

                byte[] buffer = new byte[pointer.Item2];
                memoryStream.Read(buffer, 0, (int)pointer.Item2);
                return new MemoryStream(buffer);
            }

            return null;
        }
    }
}
