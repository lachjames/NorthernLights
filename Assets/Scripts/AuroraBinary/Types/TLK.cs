using AuroraEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

[System.Serializable]
public class TLK : BinaryStructure
{
    [BinaryText(4)] public string fileType;
    [BinaryText(4)] public string version;

    public int languageID = 0;
    public int stringCount = 10;
    public int stringEntriesOffset = 0;

    [BinaryCustom("ReadStrings")] public Dictionary<int, StringData> strings;

    public int ReadStrings(byte[] data, int start, FieldInfo f, object target, Dictionary<string, byte[]> other)
    {
        stringCount = 49265;
        Debug.Log("TLK file reading " + stringCount + " strings");
        strings = new Dictionary<int, StringData>();

        int pos = start;

        for (int i = 0; i < stringCount; i++)
        {
            StringData stringData = new StringData();
            stringData.stringEntriesOffset = stringEntriesOffset;

            pos = stringData.Load(data, other, pos);

            strings[i] = stringData;
        }

        return pos;
    }
}

public class StringData : BinaryStructure
{
    [BinarySkip()] public int stringEntriesOffset;

    public uint flags;
    [BinaryText(16)] public string soundResRef;
    public uint volumeVariance;
    public uint pitchVariance;
    public uint offsetToString;
    public uint stringSize;
    public float soundLength;

    [BinaryCustom("ReadString")] public DialogString str;
    [BinarySkip()] public bool textPresent;
    [BinarySkip()] public bool soundPresent;
    [BinarySkip()] public bool soundLengthPresent;

    public int ReadString(byte[] data, int start, FieldInfo f, object target, Dictionary<string, byte[]> other)
    {
        // Read the flags
        textPresent = ((flags & 0x01) == 0x01);
        soundPresent = ((flags & 0x02) == 0x02);
        soundLengthPresent = ((flags & 0x04) == 0x04);

        // Load the string
        DialogString s = new DialogString();
        s.Load(data, other, (int)offsetToString);

        return start;
    }
}

public class DialogString : BinaryStructure
{
    // Hopefully 8192 is long enough - it should be, I think
    [BinaryText(8192)] public string str;

    public static implicit operator string(DialogString s) => s.str;
}