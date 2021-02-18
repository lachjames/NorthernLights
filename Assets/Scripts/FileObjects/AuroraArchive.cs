using AuroraEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public abstract class AuroraArchive
{
    public string filePath;
    public MemoryStream memoryStream;
    public AuroraArchive(string path, bool readStream = true)
    {
        filePath = path;

        if (readStream)
        {
            using (FileStream stream = File.Open(filePath, FileMode.Open))
            {
                ReadStream(stream);
            }
        }

        SetupArchive();
    }

    public AuroraArchive(Stream stream)
    {
        ReadStream(stream);

        SetupArchive();
    }

    void ReadStream (Stream stream)
    {
        memoryStream = new MemoryStream();
        stream.Seek(0, SeekOrigin.Begin);
        stream.CopyTo(memoryStream);
        memoryStream.Seek(0, SeekOrigin.Begin);
    }

    public abstract void SetupArchive();
    public abstract Stream GetResource(string resref, ResourceType rt);
}
