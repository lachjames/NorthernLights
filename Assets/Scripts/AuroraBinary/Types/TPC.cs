//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Reflection;
//using UnityEngine;
//using UnityBinary;

//[System.Serializable]
//public class TPC : BinaryStructure
//{
//    public uint size;
//    public float unk;
//    public ushort width;
//    public ushort height;
//    public byte encodingType;
//    public byte mipmapCount;

//    [BinaryArray(typeof(byte), 144)] public byte[] padding;

//    [BinaryCustom("ReadTexture")] public Texture2D texture;
//    [BinarySkip()] public TextureFormat format;

//    public int ReadTexture(byte[] data, int start, FieldInfo f, object target, Dictionary<string, byte[]> other)
//    {
//        int minDataSize, dataSize;
//        switch (encodingType)
//        {
//            case 0x01:
//                // Gray
//                format = TextureFormat.RGB24;
//                minDataSize = 1;
//                dataSize = width * height * minDataSize;
//                break;
//            case 0x02:
//                if (size >= 0)
//                {
//                    // Compressed
//                    format = TextureFormat.DXT1;
//                    minDataSize = 8;
//                }
//                else
//                {
//                    // Uncompressed
//                    format = TextureFormat.RGB24;
//                    minDataSize = 3;
//                    dataSize = width * height * 3;
//                }
//                // RGB
//                break;
//            case 0x04:
//                if (size >= 0)
//                {
//                    // Compressed
//                    format = TextureFormat.DXT5;
//                    minDataSize = 16;
//                } else
//                {
//                    format = TextureFormat.RGBA32;
//                    minDataSize = 4;
//                    dataSize = width * height * minDataSize;
//                }
//                // RGBA
//                break;
//            case 0x0C:
//                // BRGA
//                format = TextureFormat.BGRA32;
//                minDataSize = 4;
//                dataSize = width * height * minDataSize;
//                break;
//            default:
//                Debug.LogWarning("Unknown encoding type " + encodingType + " found");
//                break;
//        }

//        long fullSize = dataSize;
//        int w = width, h = height;
//        for (int i = 1; i < mipmapCount; i++)
//        {
//            w = Math.Max(w >> 1, 1);
//            h = Math.Max(h >> 1, 1);

//            fullSize += GetDataSize(format, w, h);
//        }

//        return start;
//    }
//}