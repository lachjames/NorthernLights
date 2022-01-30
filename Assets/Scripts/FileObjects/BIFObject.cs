using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace AuroraEngine
{
    public class BIFObject : AuroraArchive
    {
        public struct Resource
        {
            public uint ID, Offset, FileSize, ResType;
        }

        private const int HEADER_SIZE = 20;

        private string fileType, fileVersion;
        private uint variableResourceCount, fixedResourceCount, variableTableOffset, variableTableRowSize, variableTableSize;

        public Resource[] resources;

        KEYObject keyObject;

        public BIFObject(string filepath, KEYObject key) : base(filepath)
        {
            keyObject = key;
            // foreach (Resource r in resources)
            // {
            //     // Get the resref and print it
            //     string resref = keyObject.GetStringFromID(r.ID);
            //     Debug.Log("Loaded resource " + resref + " of type " + r.ResType + " in " + filepath);
            // }
        }

        public BIFObject(Stream stream) : base(stream) { }

        public override void SetupArchive()
        {
            byte[] buffer;

            //Read the header
            buffer = new byte[HEADER_SIZE];
            memoryStream.Read(buffer, 0, HEADER_SIZE);

            fileType = Encoding.UTF8.GetString(buffer, 0, 4);
            fileVersion = Encoding.UTF8.GetString(buffer, 4, 4);
            variableResourceCount = BitConverter.ToUInt32(buffer, 8);
            fixedResourceCount = BitConverter.ToUInt32(buffer, 12);
            variableTableOffset = BitConverter.ToUInt32(buffer, 16);

            variableTableRowSize = 16;
            variableTableSize = variableResourceCount * variableTableRowSize;

            //Read variable tabs blocks
            buffer = new byte[variableTableSize];
            memoryStream.Read(buffer, 0, (int)variableTableSize);
            resources = new Resource[variableResourceCount];

            Debug.Log("Loading " + variableResourceCount + " resources from " + filePath);
            for (int i = 0; i < variableResourceCount; i++)
            {
                resources[i] = new Resource
                {
                    ID = BitConverter.ToUInt32(buffer, (i * (int)variableTableRowSize) + 0),
                    Offset = BitConverter.ToUInt32(buffer, (i * (int)variableTableRowSize) + 4),
                    FileSize = BitConverter.ToUInt32(buffer, (i * (int)variableTableRowSize) + 8),
                    ResType = BitConverter.ToUInt32(buffer, (i * (int)variableTableRowSize) + 12),
                };
            }
        }


        public Resource GetResourceById(uint id)
        {
            for (int i = 0; i < variableResourceCount; i++)
            {
                if (this.resources[i].ID == id)
                {
                    return this.resources[i];
                }
            }
            throw new Exception("Resource not found.");
        }

        public Stream GetResourceData(Resource resource)
        {
            using (FileStream stream = File.Open(filePath, FileMode.Open))
            {
                stream.Position = resource.Offset;
                //stream.CopyTo(resourceFile, (int)resource.FileSize);

                var buffer = new byte[(int)resource.FileSize];
                stream.Read(buffer, 0, (int)resource.FileSize);
                return new MemoryStream(buffer);
            }
        }

        public override Stream GetResource(string resref, ResourceType rt)
        {
            uint id;

            // Then try and load from BIFs
            if (keyObject.TryGetResourceID(resref, rt, out id))
            {
                uint bifIndex = id >> 20;

                // return GetResourceData(GetResourceById(bifIndex));
                try
                {
                    return GetResourceData(GetResourceById(id));
                }
                catch (Exception e)
                {
                    // Debug.LogWarning("Failed to load object " + resref + " from " + filePath + ": " + e.Message);
                    return null;
                }
            }

            return null;
        }
    }
}