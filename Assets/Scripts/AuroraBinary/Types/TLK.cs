using AuroraEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityBinary;
using System.Text;

[System.Serializable]
public class TLK : BinaryStructure
{
    [BinaryText(4)] public string fileType;
    [BinaryText(4)] public string version;

    public uint languageID;
    public uint stringCount;
    public uint stringEntriesOffset;

    [BinaryCustom("ReadStrings")] public Dictionary<int, StringData> strings;

    public int ReadStrings(byte[] data, int start, FieldInfo f, object target, Dictionary<string, byte[]> other)
    {
        Debug.Log(fileType + " " + version);
        Debug.Log("TLK file reading " + stringCount + " strings from offset " + stringEntriesOffset);
        strings = new Dictionary<int, StringData>();

        int pos = start;

        for (int i = 0; i < stringCount; i++)
        {
            StringData stringData = new StringData();
            pos = stringData.Load(data, pos, (int)stringEntriesOffset);
            strings[i] = stringData;

            // if (i > 1000)
            // {
            //     break;
            // }
        }

        return pos;
    }
}

public class StringData
{
    public bool textPresent;
    public bool soundPresent;
    public bool soundLengthPresent;

    public string soundResRef;
    public uint volumeVariance;
    public uint pitchVariance;
    public uint offsetToString;
    public uint stringSize;
    public float soundLength;

    public string text;

    public int Load(byte[] data, int start, int stringEntryOffset)
    {
        int pos = start;

        uint flags = BitConverter.ToUInt32(data, pos);
        pos += 4;

        textPresent = (flags & 0x1) != 0;
        soundPresent = (flags & 0x2) != 0;
        soundLengthPresent = (flags & 0x4) != 0;

        if (soundPresent)
        {
            // The next 16 bytes are a resref to the sound
            soundResRef = Encoding.UTF8.GetString(data, start, 16).TrimEnd('\0');
        }
        pos += 16;

        volumeVariance = BitConverter.ToUInt32(data, pos);
        pos += 4;

        pitchVariance = BitConverter.ToUInt32(data, pos);
        pos += 4;

        if (textPresent)
        {
            offsetToString = BitConverter.ToUInt32(data, pos);
            // pos += 4;

            stringSize = BitConverter.ToUInt32(data, pos + 4);
            // pos += 4;
        }
        pos += 8;

        if (textPresent)
        {
            // Load the string from the byte array, starting at
            // index stringEntriesOffset + offsetToString
            // and ending at stringEntriesOffset + offsetToString + stringSize
            // UnityEngine.Debug.Log("Loading text of length " + stringSize + " from offset " + stringEntryOffset + " + " + offsetToString);
            text = Encoding.UTF8.GetString(data, (int)(stringEntryOffset + offsetToString), (int)stringSize);
        }

        if (soundLengthPresent)
        {
            soundLength = BitConverter.ToSingle(data, pos);
        }
        pos += 4;

        return pos;
    }
}

// public class StringData : BinaryStructure
// {
//     [BinarySkip()] public uint stringEntriesOffset;

//     public uint flags;
//     // [BinaryText(16)] public string soundResRef;
//     [BinarySkip()] public uint volumeVariance;
//     [BinarySkip()] public uint pitchVariance;
//     [BinarySkip()] public uint offsetToString;
//     [BinarySkip()] public uint stringSize;
//     [BinarySkip()] public float soundLength;

//     [BinaryCustom("ReadString")] public DialogString str;
//     [BinarySkip()] public bool textPresent;
//     [BinarySkip()] public bool soundPresent;
//     [BinarySkip()] public bool soundLengthPresent;

//     public int ReadString(byte[] data, int start, FieldInfo f, object target, Dictionary<string, byte[]> other)
//     {
//         // Read the flags
//         textPresent = ((flags & 0x01) == 0x01);
//         soundPresent = ((flags & 0x02) == 0x02);
//         soundLengthPresent = ((flags & 0x04) == 0x04);

//         // Load the string
//         DialogString s = new DialogString();
//         UnityEngine.Debug.Log("Loading string from offset " + offsetToString);
//         s.Load(data, other, (int)(stringEntriesOffset + offsetToString));
//         Debug.Log("Loaded string: " + (string)s);

//         return start;
//     }
// }

// public class DialogString : BinaryStructure
// {
//     // Hopefully 8192 is long enough - it should be, I think
//     [BinaryCustom("LoadString")] public string str;

//     public int LoadString(byte[] data, int start, FieldInfo f, object target, Dictionary<string, byte[]> other)
//     {
//         int pos = start;

//         // Read the string until we reach a null terminator
//         List<byte> strBytes = new List<byte>();
//         while (data[pos] != 0)
//         {
//             strBytes.Add(data[pos]);
//             pos++;
//         }

//         // Convert the bytes to a string
//         str = Encoding.ASCII.GetString(strBytes.ToArray());

//         return pos;
//     }

//     public static implicit operator string(DialogString s) => s.str;
// }