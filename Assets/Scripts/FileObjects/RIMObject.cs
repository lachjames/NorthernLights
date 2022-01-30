using System;
using System.Collections.Generic;
// using System.Diagnostics;
using System.IO;
using System.Text;
using UnityEngine;

namespace AuroraEngine
{
    public class RIMObject : AuroraArchive
    {
        public struct Resource
        {
            public string ResRef;
            public uint ID;
            public long Offset, FileSize;
            public ResourceType ResType;
        }

        public const int HEADER_SIZE = 160, RES_SIZE = 32;

        public Dictionary<(string, ResourceType), Resource> resources;

        public RIMObject(string filepath) : base(filepath) { }

        public RIMObject(Stream stream) : base(stream) { }

        public override void SetupArchive()
        {
            byte[] buffer;
            //Read the header
            buffer = new byte[HEADER_SIZE];
            memoryStream.Read(buffer, 0, HEADER_SIZE);

            string fileType = Encoding.UTF8.GetString(buffer, 0, 4);
            string fileVersion = Encoding.UTF8.GetString(buffer, 4, 4);

            int resourceCount = (int)BitConverter.ToUInt32(buffer, 12);
            long resourceOffset = BitConverter.ToUInt32(buffer, 16);

            //UnityEngine.Debug.Log(fileType);
            //UnityEngine.Debug.Log(fileVersion);
            //UnityEngine.Debug.Log(resourceCount);

            memoryStream.Position = resourceOffset;

            buffer = new byte[resourceCount * RES_SIZE];
            memoryStream.Read(buffer, 0, resourceCount * RES_SIZE);

            resources = new Dictionary<(string, ResourceType), Resource>(resourceCount);

            Debug.Log("Loading " + resourceCount + " resources from " + filePath);
            for (int i = 0, idx = 0; i < resourceCount; i++, idx += RES_SIZE)
            {
                string resref = Encoding.UTF8.GetString(buffer, idx + 0, 16).TrimEnd('\0').ToLower();   //resrefs are always case insensitive
                ResourceType type = (ResourceType)BitConverter.ToUInt16(buffer, idx + 16);

                resources.Add((resref, type), new Resource
                {
                    ResRef = resref,
                    ResType = type,
                    ID = BitConverter.ToUInt32(buffer, idx + 20),
                    Offset = BitConverter.ToUInt32(buffer, idx + 24),
                    FileSize = BitConverter.ToUInt32(buffer, idx + 28)
                });

                // Debug.Log("Loaded resource " + resref);
            }
        }

        public override Stream GetResource(string resref, ResourceType type)
        {
            Resource resource;

            if (resources.TryGetValue((resref.ToLower(), type), out resource))
            {
                using (FileStream stream = File.Open(filePath, FileMode.Open))
                {
                    stream.Position = resource.Offset;

                    var buffer = new byte[(int)resource.FileSize];
                    stream.Read(buffer, 0, (int)resource.FileSize);
                    return new MemoryStream(buffer);
                }
            }
            else
            {
                return null;
            }
        }
    }
}
