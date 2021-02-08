using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using UnityEngine;

[System.Serializable]
public class LIP : BinaryStructure
{
    [BinarySkip()] public static string[] LIPCodes = new string[]
    {
        "EE",       // 0
        "EH",       // 1
        "SCHWA",    // 2
        "AH",       // 3
        "OH",       // 4
        "OOH",      // 5
        "Y",        // 6
        "S/TS",     // 7
        "F/V",      // 8
        "N/NG",     // 9
        "TH",       // 10
        "M/P/B",    // 11
        "T/D",      // 12
        "J/SH",     // 13
        "L",        // 14
        "K/G"       // 15
    };

    public int fileType;
    public int fileVersion;
    public float length;
    public int entryCount;

    [BinaryCustom("ReadFrames")] public Frame[] frames;

    public int ReadFrames(byte[] data, int start, FieldInfo f, object target, Dictionary<string, byte[]> other)
    {
        frames = new Frame[entryCount];
        int pointer = start;
        for (int i = 0; i < entryCount; i++)
        {
            frames[i] = new Frame();
            pointer = frames[i].Load(data, other, pointer);
        }
        return pointer;
    }

    public void WriteToStream (Stream stream)
    {
        foreach (byte b in BitConverter.GetBytes(fileType))
        {
            stream.WriteByte(b);
        }
        foreach (byte b in BitConverter.GetBytes(fileVersion))
        {
            stream.WriteByte(b);
        }
        foreach (byte b in BitConverter.GetBytes(length))
        {
            stream.WriteByte(b);
        }
        foreach (byte b in BitConverter.GetBytes(entryCount))
        {
            stream.WriteByte(b);
        }
        foreach (Frame f in frames)
        {
            f.WriteToStream(stream);
        }
    }
}

public class Frame : BinaryStructure
{
    public float time;
    public byte shape;

    public void WriteToStream(Stream stream)
    {
        foreach (byte b in BitConverter.GetBytes(time))
        {
            stream.WriteByte(b);
        }
        stream.WriteByte(shape);
    }
}