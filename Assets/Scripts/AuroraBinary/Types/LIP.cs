using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

[System.Serializable]
public class LIP : BinaryStructure
{
    public int fileType;
    public int fileVersion;
    public float length;
    public int entryCount;

    [BinaryCustom("ReadFrames")] public Frame[] frames;

    public int ReadFrames(byte[] data, int start, FieldInfo f, object target, Dictionary<string, byte[]> other)
    {
        Frame[] frames = new Frame[entryCount];
        int pointer = start;
        for (int i = 0; i < entryCount; i++)
        {
            frames[i] = new Frame();
            pointer = frames[i].Load(data, other, pointer);
        }
        return pointer;
    }
}

public class Frame : BinaryStructure
{
    public float time;
    public byte shape;
}