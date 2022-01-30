using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System;
using NCSInstructions;

public class NCSFile
{
    public List<NCSOperation> operations = new List<NCSOperation>();
    public NCSFile(Stream stream)
    {
        // Read the stream into a byte array
        byte[] bytes = new byte[stream.Length];
        stream.Read(bytes, 0, (int)stream.Length);

        // Start at offset 8
        int offset = 8;

        // Loop until we reach the end of the file
        while (offset < bytes.Length)
        {
            // Convert opcode to hex and print it
            // Debug.Log("Loading operation with opcode " + bytes[offset].ToString("X") + " from offset " + offset);
            NCSOperation op = new NCSOperation();
            offset = op.Read(bytes, offset);

            // Debug.Log("Loaded operation " + op.opcode + " of type " + op.opType);
            operations.Add(op);
        }

        Debug.Log("Loaded file with " + operations.Count + " operations");
        string summary = "";
        foreach (NCSOperation op in operations)
        {
            summary += op.ToString() + "\n";
        }
    }
}

public class NCSOperation
{
    public int opcode;

    public enum ArgType
    {
        UNKNOWN = 0x00,
        INT = 0x03,
        FLOAT = 0x04,
        STRING = 0x05,
        OBJECT = 0x06,
        EFFECT = 0x10,
        EVENT = 0x11,
        LOCATION = 0x12,
        TALENT = 0x13,
        INT_INT = 0x20,
        FLOAT_FLOAT = 0x21,
        OBJECT_OBJECT = 0x22,
        STRING_STRING = 0x23,
        STRUCTURE_STRUCTURE = 0x24,
        INT_FLOAT = 0x25,
        FLOAT_INT = 0x26,
        EFFECT_EFFECT = 0x30,
        EVENT_EVENT = 0x31,
        LOCATION_LOCATION = 0x32,
        TALENT_TALENT = 0x33,
        VECTOR_VECTOR = 0x3A,
        VECTOR_FLOAT = 0x3B,
        FLOAT_VECTOR = 0x3C
    }

    public Type opType;
    public ArgType argType;
    public string[] args;
    public int instructionStart;
    public int instructionSize;

    static byte[] ReverseEndianness(byte[] arr)
    {
        byte[] newArr = new byte[arr.Length];
        for (int i = 0; i < arr.Length; i++)
        {
            newArr[i] = arr[arr.Length - i - 1];
        }
        return newArr;
    }

    static int ToInt32(byte[] raw_arr, int offset)
    {
        byte[] snippet = new byte[4];
        Array.Copy(raw_arr, offset, snippet, 0, 4);
        snippet = ReverseEndianness(snippet);
        return BitConverter.ToInt32(snippet, 0);
    }

    static short ToInt16(byte[] raw_arr, int offset)
    {
        byte[] snippet = new byte[2];
        Array.Copy(raw_arr, offset, snippet, 0, 2);
        snippet = ReverseEndianness(snippet);
        return BitConverter.ToInt16(snippet, 0);
    }

    static ushort ToUInt16(byte[] raw_arr, int offset)
    {
        byte[] snippet = new byte[2];
        Array.Copy(raw_arr, offset, snippet, 0, 2);
        snippet = ReverseEndianness(snippet);
        return BitConverter.ToUInt16(snippet, 0);
    }

    static float ToFloat32(byte[] raw_arr, int offset)
    {
        byte[] snippet = new byte[4];
        Array.Copy(raw_arr, offset, snippet, 0, 4);
        snippet = ReverseEndianness(snippet);
        return BitConverter.ToSingle(snippet, 0);
    }
    public int Read(byte[] buffer, int start)
    {
        this.instructionStart = start;

        // Read the opcode, which is the next byte
        opcode = buffer[start];

        int offset = 1;
        Type t = null;
        ArgType at = (ArgType)0;
        string[] args = null;

        object arg1, arg2, arg3;

        switch (opcode)
        {
            case 0x00:
                // NOP: 1 byte
                t = typeof(NOP);
                at = ArgType.UNKNOWN;
                args = new string[0];
                offset = 1;
                break;
            case 0x01:
                // CPDOWNSP: 8 bytes
                // 0: Byte code
                // 1: Type
                // 2-5: Destination of the copy relative to the top of the stack
                // 6-7: Number of bytes to copy
                t = typeof(NCSInstructions.CPDOWNSP);
                at = (ArgType)buffer[start + 1];

                arg1 = ToInt32(buffer, start + 2);
                arg2 = ToInt16(buffer, start + 6);
                args = new string[2] { arg1.ToString(), arg2.ToString() };

                offset = 8;
                break;
            case 0x02:
                // RSADD: 2 bytes
                // 0: Byte code
                // 1: Type
                at = (ArgType)buffer[start + 1];
                switch (at)
                {
                    case ArgType.INT:
                        t = typeof(NCSInstructions.RSADDI);
                        break;
                    case ArgType.FLOAT:
                        t = typeof(NCSInstructions.RSADDF);
                        break;
                    case ArgType.STRING:
                        t = typeof(NCSInstructions.RSADDS);
                        break;
                    case ArgType.OBJECT:
                        t = typeof(NCSInstructions.RSADDO);
                        break;
                    case ArgType.EFFECT:
                        t = typeof(NCSInstructions.RSADDE0);
                        break;
                    case ArgType.EVENT:
                        t = typeof(NCSInstructions.RSADDE1);
                        break;
                    case ArgType.LOCATION:
                        t = typeof(NCSInstructions.RSADDE2);
                        break;
                    case ArgType.TALENT:
                        t = typeof(NCSInstructions.RSADDE3);
                        break;
                    default:
                        throw new Exception("Unknown type: " + at);
                }
                offset = 2;
                break;
            case 0x03:
                // CPTOPSP: 8 bytes
                // 0: Byte code
                // 1: Type
                // 2-5: Destination of the copy relative to the top of the stack
                // 6-7: Number of bytes to copy
                t = typeof(NCSInstructions.CPTOPSP);
                at = (ArgType)buffer[start + 1];

                arg1 = ToInt32(buffer, start + 2);
                arg2 = ToInt16(buffer, start + 6);
                args = new string[2] { arg1.ToString(), arg2.ToString() };

                offset = 8;
                break;
            case 0x04:
                // CONST: 6 bytes for int/float/object, 4+n bytes for string
                // 0: Byte code
                // 1: Type
                // 2-3: String length (for string)
                // 4-n: Text of the string (for string)
                at = (ArgType)buffer[start + 1];
                switch (at)
                {
                    case ArgType.INT:
                        t = typeof(NCSInstructions.CONSTI);
                        arg1 = ToInt32(buffer, start + 2);

                        args = new string[1] { arg1.ToString() };
                        offset = 6;
                        break;
                    case ArgType.FLOAT:
                        t = typeof(NCSInstructions.CONSTF);
                        arg1 = ToFloat32(buffer, start + 2);

                        args = new string[1] { arg1.ToString() };
                        offset = 6;
                        break;
                    case ArgType.OBJECT:
                        t = typeof(NCSInstructions.CONSTO);
                        arg1 = ToInt32(buffer, start + 2);

                        args = new string[1] { arg1.ToString() };
                        offset = 6;
                        break;
                    case ArgType.STRING:
                        t = typeof(NCSInstructions.CONSTS);
                        arg1 = ToInt16(buffer, start + 2);
                        // Debug.Log("Loading string of length " + arg1);
                        arg2 = System.Text.Encoding.UTF8.GetString(buffer, start + 4, (short)arg1);

                        args = new string[2] { arg1.ToString(), arg2.ToString() };
                        offset = 4 + (short)arg1;
                        break;
                    default:
                        throw new Exception("Unknown type: " + at);
                }
                break;
            case 0x05:
                // ACTION: 5 bytes
                // 0: Byte code
                // 1: Type (unused)
                // 2-3: Routine number
                // 4: Number of arguments
                t = typeof(NCSInstructions.ACTION);
                at = (ArgType)buffer[start + 1];

                arg1 = ToUInt16(buffer, start + 2);
                arg2 = buffer[start + 4];

                args = new string[2] { arg1.ToString(), arg2.ToString() };
                offset = 5;
                break;
            case 0x06:
                // LOGAND: 2 bytes
                // 0: Byte code
                // 1: Type (always int-int)
                t = typeof(NCSInstructions.LOGANDII);
                at = (ArgType)buffer[start + 1];

                args = new string[0];
                offset = 2;
                break;
            case 0x07:
                // LOGOR: 2 bytes
                // 0: Byte code
                // 1: Type (always int-int)
                t = typeof(NCSInstructions.LOGORII);
                at = (ArgType)buffer[start + 1];

                args = new string[0];
                offset = 2;
                break;
            case 0x08:
                // INCOR: 2 bytes
                // 0: Byte code
                // 1: Type (always int-int)
                t = typeof(NCSInstructions.INCORII);
                at = (ArgType)buffer[start + 1];

                args = new string[0];
                offset = 2;
                break;
            case 0x09:
                // EXCOR: 2 bytes
                // 0: Byte code
                // 1: Type (always int-int)
                t = typeof(NCSInstructions.EXCORII);
                at = (ArgType)buffer[start + 1];

                args = new string[0];
                offset = 2;
                break;
            case 0x0A:
                // BOOLAND: 2 bytes
                // 0: Byte code
                // 1: Type (always int-int)
                t = typeof(NCSInstructions.BOOLANDII);
                at = (ArgType)buffer[start + 1];

                args = new string[0];
                offset = 2;
                break;
            case 0x0B:
                // EQ: 2 bytes
                // 0: byte code
                // 1: Type (either int-int, float-float, string-string, object-object, or structure-structure)
                at = (ArgType)buffer[start + 1];
                offset = 2;
                args = new string[0];

                switch (at)
                {
                    case ArgType.INT_INT:
                        t = typeof(NCSInstructions.EQII);
                        break;
                    case ArgType.FLOAT_FLOAT:
                        t = typeof(NCSInstructions.EQFF);
                        break;
                    case ArgType.STRING_STRING:
                        t = typeof(NCSInstructions.EQSS);
                        break;
                    case ArgType.OBJECT_OBJECT:
                        t = typeof(NCSInstructions.EQOO);
                        break;
                    case ArgType.STRUCTURE_STRUCTURE:
                        t = typeof(NCSInstructions.EQTT);
                        arg1 = ToUInt16(buffer, start + 2);
                        args = new string[1] { arg1.ToString() };
                        offset = 4;
                        break;
                    default:
                        throw new Exception("Unknown type: " + at);
                }
                break;
            case 0x0C:
                // NEQ: 2 bytes (same as EQ)
                // 0: byte code
                // 1: Type (either int-int, float-float, string-string, object-object, or structure-structure)
                at = (ArgType)buffer[start + 1];
                offset = 2;
                args = new string[0];

                switch (at)
                {
                    case ArgType.INT_INT:
                        t = typeof(NCSInstructions.NEQII);
                        break;
                    case ArgType.FLOAT_FLOAT:
                        t = typeof(NCSInstructions.NEQFF);
                        break;
                    case ArgType.STRING_STRING:
                        t = typeof(NCSInstructions.NEQSS);
                        break;
                    case ArgType.OBJECT_OBJECT:
                        t = typeof(NCSInstructions.NEQOO);
                        break;
                    case ArgType.STRUCTURE_STRUCTURE:
                        t = typeof(NCSInstructions.NEQTT);
                        arg1 = ToUInt16(buffer, start + 2);
                        args = new string[1] { arg1.ToString() };
                        offset = 4;
                        break;
                    default:
                        throw new Exception("Unknown type: " + at);
                }
                break;
            case 0x0D:
                // GEQ: 2 bytes
                // 0: byte code
                // 1: Type (either int-int or float-float)
                at = (ArgType)buffer[start + 1];
                offset = 2;

                switch (at)
                {
                    case ArgType.INT_INT:
                        t = typeof(NCSInstructions.GEQII);
                        break;
                    case ArgType.FLOAT_FLOAT:
                        t = typeof(NCSInstructions.GEQFF);
                        break;
                    default:
                        throw new Exception("Unknown type: " + at);
                }

                args = new string[0];
                break;
            case 0x0E:
                // GT: 2 bytes
                // 0: byte code
                // 1: Type (either int-int or float-float)
                at = (ArgType)buffer[start + 1];
                offset = 2;

                switch (at)
                {
                    case ArgType.INT_INT:
                        t = typeof(NCSInstructions.GTII);
                        break;
                    case ArgType.FLOAT_FLOAT:
                        t = typeof(NCSInstructions.GTFF);
                        break;
                    default:
                        throw new Exception("Unknown type: " + at);
                }

                args = new string[0];
                break;
            case 0x0F:
                // LT: 2 bytes
                // 0: byte code
                // 1: Type (either int-int or float-float)
                at = (ArgType)buffer[start + 1];
                offset = 2;

                switch (at)
                {
                    case ArgType.INT_INT:
                        t = typeof(NCSInstructions.LTII);
                        break;
                    case ArgType.FLOAT_FLOAT:
                        t = typeof(NCSInstructions.LTFF);
                        break;
                    default:
                        throw new Exception("Unknown type: " + at);
                }

                args = new string[0];
                break;
            case 0x10:
                // LEQ: 2 bytes
                // 0: byte code
                // 1: Type (either int-int or float-float)
                at = (ArgType)buffer[start + 1];
                offset = 2;

                switch (at)
                {
                    case ArgType.INT_INT:
                        t = typeof(NCSInstructions.LEQII);
                        break;
                    case ArgType.FLOAT_FLOAT:
                        t = typeof(NCSInstructions.LEQFF);
                        break;
                    default:
                        throw new Exception("Unknown type: " + at);
                }

                args = new string[0];
                break;
            case 0x11:
                // SHLEFT: 2 bytes
                // 0: byte code
                // 1: Type (always int-int)
                t = typeof(NCSInstructions.SHLEFTII);
                at = (ArgType)buffer[start + 1];

                args = new string[0];
                offset = 2;
                break;
            case 0x12:
                // SHRIGHT: 2 bytes
                // 0: byte code
                // 1: Type (always int-int)
                t = typeof(NCSInstructions.SHRIGHTII);
                at = (ArgType)buffer[start + 1];

                args = new string[0];
                offset = 2;
                break;
            case 0x13:
                // USHRIGHT: 2 bytes
                // 0: byte code
                // 1: Type (always int-int)
                t = typeof(NCSInstructions.USHRIGHTII);
                at = (ArgType)buffer[start + 1];

                args = new string[0];
                offset = 2;
                break;
            case 0x14:
                // ADD: 2 bytes
                // 0: byte code
                // 1: Type (either int-int, int-float, float-int, float-float, string-string, or vector-vector)
                at = (ArgType)buffer[start + 1];
                offset = 2;

                switch (at)
                {
                    case ArgType.INT_INT:
                        t = typeof(NCSInstructions.ADDII);
                        break;
                    case ArgType.INT_FLOAT:
                        t = typeof(NCSInstructions.ADDIF);
                        break;
                    case ArgType.FLOAT_INT:
                        t = typeof(NCSInstructions.ADDIF);
                        break;
                    case ArgType.FLOAT_FLOAT:
                        t = typeof(NCSInstructions.ADDFF);
                        break;
                    case ArgType.STRING_STRING:
                        t = typeof(NCSInstructions.ADDSS);
                        break;
                    case ArgType.VECTOR_VECTOR:
                        t = typeof(NCSInstructions.ADDVV);
                        break;
                    default:
                        throw new Exception("Unknown type: " + at);
                }

                args = new string[0];
                break;
            case 0x15:
                // SUB: 2 bytes
                // 0: byte code
                // 1: Type (either int-int, int-float, float-int, float-float, or vector-vector)
                at = (ArgType)buffer[start + 1];
                offset = 2;

                switch (at)
                {
                    case ArgType.INT_INT:
                        t = typeof(NCSInstructions.SUBII);
                        break;
                    case ArgType.INT_FLOAT:
                        t = typeof(NCSInstructions.SUBIF);
                        break;
                    case ArgType.FLOAT_INT:
                        t = typeof(NCSInstructions.SUBIF);
                        break;
                    case ArgType.FLOAT_FLOAT:
                        t = typeof(NCSInstructions.SUBFF);
                        break;
                    case ArgType.VECTOR_VECTOR:
                        t = typeof(NCSInstructions.SUBVV);
                        break;
                    default:
                        throw new Exception("Unknown type: " + at);
                }

                args = new string[0];
                break;
            case 0x16:
                // MUL: 2 bytes
                // 0: byte code
                // 1: Type (either int-int, int-float, float-int, float-float, vector-float, or float-vector)
                at = (ArgType)buffer[start + 1];
                offset = 2;

                switch (at)
                {
                    case ArgType.INT_INT:
                        t = typeof(NCSInstructions.MULII);
                        break;
                    case ArgType.INT_FLOAT:
                        t = typeof(NCSInstructions.MULIF);
                        break;
                    case ArgType.FLOAT_INT:
                        t = typeof(NCSInstructions.MULIF);
                        break;
                    case ArgType.FLOAT_FLOAT:
                        t = typeof(NCSInstructions.MULFF);
                        break;
                    case ArgType.VECTOR_FLOAT:
                        t = typeof(NCSInstructions.MULVF);
                        break;
                    case ArgType.FLOAT_VECTOR:
                        t = typeof(NCSInstructions.MULVF);
                        break;
                    default:
                        throw new Exception("Unknown type: " + at);
                }

                args = new string[0];
                break;
            case 0x17:
                // DIV: 2 bytes
                // 0: byte code
                // 1: Type (either int-int, int-float, float-int, float-float, or vector-float)
                at = (ArgType)buffer[start + 1];
                offset = 2;

                switch (at)
                {
                    case ArgType.INT_INT:
                        t = typeof(NCSInstructions.DIVII);
                        break;
                    case ArgType.INT_FLOAT:
                        t = typeof(NCSInstructions.DIVIF);
                        break;
                    case ArgType.FLOAT_INT:
                        t = typeof(NCSInstructions.DIVIF);
                        break;
                    case ArgType.FLOAT_FLOAT:
                        t = typeof(NCSInstructions.DIVFF);
                        break;
                    case ArgType.VECTOR_FLOAT:
                        t = typeof(NCSInstructions.DIVVF);
                        break;
                    default:
                        throw new Exception("Unknown type: " + at);
                }

                args = new string[0];
                break;
            case 0x18:
                // MOD: 2 bytes
                // 0: byte code
                // 1: Type (always int-int)
                t = typeof(NCSInstructions.MODII);
                at = (ArgType)buffer[start + 1];

                args = new string[0];
                break;
            case 0x19:
                // NEG: 2 bytes
                // 0: byte code
                // 1: Type (either int or float)
                at = (ArgType)buffer[start + 1];
                offset = 2;

                switch (at)
                {
                    case ArgType.INT:
                        t = typeof(NCSInstructions.NEGI);
                        break;
                    case ArgType.FLOAT:
                        t = typeof(NCSInstructions.NEGF);
                        break;
                    default:
                        throw new Exception("Unknown type: " + at);
                }
                break;
            case 0x1A:
                // COMP: 2 bytes
                // 0: byte code
                // 1: Type (always int)
                t = typeof(NCSInstructions.COMPI);
                at = (ArgType)buffer[start + 1];

                args = new string[0];
                offset = 2;
                break;
            case 0x1B:
                // MOVSP: 6 bytes
                // 0: byte code
                // 1: Type (always int)
                // 2: Value to add to the stack pointer (int32)
                t = typeof(NCSInstructions.MOVSP);
                at = (ArgType)buffer[start + 1];

                arg1 = ToInt32(buffer, start + 2);
                args = new string[] { arg1.ToString() };
                offset = 6;
                break;
            case 0x1C:
                // Unused
                throw new Exception("Unused opcode found: " + opcode);
                break;
            case 0x1D:
                // JMP: 6 bytes
                // 0: byte code
                // 1: Type (always int)
                // 2: Offset to the new location from the start of this instruction (int32)
                t = typeof(NCSInstructions.JMP);
                at = (ArgType)buffer[start + 1];

                arg1 = ToInt32(buffer, start + 2);
                args = new string[] { arg1.ToString() };
                offset = 6;
                break;
            case 0x1E:
                // JSR: 6 bytes
                // 0: byte code
                // 1: Type (always int)
                // 2: Offset to the new location from the start of this instruction (int32)
                t = typeof(NCSInstructions.JSR);
                at = (ArgType)buffer[start + 1];

                arg1 = ToInt32(buffer, start + 2);
                args = new string[] { arg1.ToString() };
                offset = 6;
                break;
            case 0x1F:
                // JZ: 6 bytes
                // 0: byte code
                // 1: Type (always int)
                // 2: Offset to the new location from the start of this instruction (int32)
                t = typeof(NCSInstructions.JZ);
                at = (ArgType)buffer[start + 1];

                arg1 = ToInt32(buffer, start + 2);
                args = new string[] { arg1.ToString() };
                offset = 6;
                break;
            case 0x20:
                // RETN: 2 bytes
                // 0: byte code
                // 1: Type (irrelevant but required)
                t = typeof(NCSInstructions.RETN);
                at = (ArgType)buffer[start + 1];
                break;
            case 0x21:
                // DESTRUCT: 8 bytes
                // 0: byte code
                // 1: Type (always int)
                // 2-3: Total number of bytes to remove off the top of the stack (int16)
                // 4-5: Offset from the start of the bytes to remove to the element not to destroy (int16)
                // 6-7: Size of the element not to destroy (int16)
                t = typeof(NCSInstructions.DESTRUCT);
                at = (ArgType)buffer[start + 1];

                arg1 = ToInt16(buffer, start + 2);
                arg2 = ToInt16(buffer, start + 4);
                arg3 = ToInt16(buffer, start + 6);
                args = new string[] { arg1.ToString(), arg2.ToString(), arg3.ToString() };
                offset = 8;
                break;
            case 0x22:
                // NOT: 2 bytes
                // 0: byte code
                // 1: Type (always int)
                t = typeof(NCSInstructions.NOTI);
                at = (ArgType)buffer[start + 1];

                args = new string[0];
                offset = 2;
                break;
            case 0x23:
                // DECSP: 6 bytes
                // 0: byte code
                // 1: Type (always int)
                // 2: Offset of the integer relative to the stack pointer
                t = typeof(NCSInstructions.DECSPI);
                at = (ArgType)buffer[start + 1];

                arg1 = ToInt32(buffer, start + 2);
                args = new string[] { arg1.ToString() };
                offset = 6;
                break;
            case 0x24:
                // INCSP: 6 bytes
                // 0: byte code
                // 1: Type (always int)
                // 2: Offset of the integer relative to the stack pointer
                t = typeof(NCSInstructions.INCSPI);
                at = (ArgType)buffer[start + 1];

                arg1 = ToInt32(buffer, start + 2);
                args = new string[] { arg1.ToString() };
                offset = 6;
                break;
            case 0x25:
                // JNZ: 6 bytes
                // 0: byte code
                // 1: Type (always int)
                // 2: Offset to the new location from the start of this instruction (int32)
                t = typeof(NCSInstructions.JNZ);
                at = (ArgType)buffer[start + 1];

                arg1 = ToInt32(buffer, start + 2);
                args = new string[] { arg1.ToString() };
                offset = 6;
                break;
            case 0x26:
                // CPDOWNBP: 8 bytes
                // 0: byte code
                // 1: Type (always int)
                // 2-5: Destination of the copy relative to the base pointer (int32)
                // 6-7: Number of bytes to copy (int16)
                t = typeof(NCSInstructions.CPDOWNBP);
                at = (ArgType)buffer[start + 1];

                arg1 = ToInt32(buffer, start + 2);
                arg2 = ToInt16(buffer, start + 6);
                args = new string[] { arg1.ToString(), arg2.ToString() };
                offset = 8;
                break;
            case 0x27:
                // CPTOPBP: 8 bytes
                // 0: byte code
                // 1: Type (always int)
                // 2-5: Source of the copy relative to the base pointer (int32)
                // 6-7: Number of bytes to copy (int16)
                t = typeof(NCSInstructions.CPTOPBP);
                at = (ArgType)buffer[start + 1];

                arg1 = ToInt32(buffer, start + 2);
                arg2 = ToInt16(buffer, start + 6);
                args = new string[] { arg1.ToString(), arg2.ToString() };
                offset = 8;
                break;
            case 0x28:
                // DECBP: 6 bytes
                // 0: byte code
                // 1: Type (always int)
                // 2: Offset of the integer relative to the base pointer
                t = typeof(NCSInstructions.DECBP);
                at = (ArgType)buffer[start + 1];

                arg1 = ToInt32(buffer, start + 2);
                args = new string[] { arg1.ToString() };
                offset = 6;
                break;
            case 0x29:
                // INCBP: 6 bytes
                // 0: byte code
                // 1: Type (always int)
                // 2: Offset of the integer relative to the base pointer
                t = typeof(NCSInstructions.INCBP);
                at = (ArgType)buffer[start + 1];

                arg1 = ToInt32(buffer, start + 2);
                args = new string[] { arg1.ToString() };
                offset = 6;
                break;
            case 0x2A:
                // SAVEBP: 2 bytes
                // 0: byte code
                // 1: Type (always int)
                t = typeof(NCSInstructions.SAVEBP);
                at = (ArgType)buffer[start + 1];

                args = new string[0];
                offset = 2;
                break;
            case 0x2B:
                // RESTOREBP: 2 bytes
                // 0: byte code
                // 1: Type (always int)
                t = typeof(NCSInstructions.RESTOREBP);
                at = (ArgType)buffer[start + 1];

                args = new string[0];
                offset = 2;
                break;
            case 0x2C:
                // STORESTATE: 10 bytes
                // 0: byte code
                // 1: Offset to the block of code for an "action" argument
                // 2-5: Size of the variables to save relative to BP.  This would be all the global variables.
                // 6-9: Size of the local routine variables to save relative to SP.
                t = typeof(NCSInstructions.STORESTATE);
                at = ArgType.INT;

                arg1 = buffer[start + 1];
                arg2 = ToInt32(buffer, start + 2);
                arg3 = ToInt32(buffer, start + 6);
                args = new string[] { arg1.ToString(), arg2.ToString(), arg3.ToString() };
                offset = 10;
                break;
            case 0x2D:
                // NOP: 2 bytes
                // 0: byte code
                // 1: Type (always int)
                t = typeof(NCSInstructions.NOP);
                at = (ArgType)buffer[start + 1];

                args = new string[0];
                offset = 2;
                break;
            case 0x42:
                // T: 5 bytes
                // 0: byte code
                // 1-4: Size of NCS file (int32)
                t = typeof(NCSInstructions.T);
                at = ArgType.INT;

                arg1 = ToInt32(buffer, start + 1);
                args = new string[] { arg1.ToString() };
                offset = 5;
                break;
            default:
                throw new Exception("Unknown instruction: " + buffer[start]);
        }

        if (t == null)
        {
            throw new Exception("Failed to read operation with opcode " + buffer[start]);
        }

        this.opType = t;
        this.argType = at;
        this.instructionSize = offset;

        // We need to add the operation name to the start of the args array
        if (args == null)
        {
            this.args = new string[] { t.Name };
        }
        else
        {
            this.args = new string[args.Length + 1];
            this.args[0] = t.Name;
            for (int i = 0; i < args.Length; i++)
            {
                this.args[i + 1] = args[i];
            }

        }

        return start + offset;
    }
}