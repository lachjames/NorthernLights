using AuroraEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using UnityEngine;


namespace UnityBinary
{
    // Source: https://stackoverflow.com/questions/16073091/is-there-a-way-to-create-a-delegate-to-get-and-set-values-for-a-fieldinfo
    //public static class FieldDelegates
    //{
    //    static MethodInfo getterInfo, setterInfo;

    //    static FieldDelegates()
    //    {
    //        //getterInfo = typeof(FieldDelegates).GetMethod("CreateGetterGeneric");
    //        setterInfo = typeof(FieldDelegates).GetMethod("CreateSetterGeneric");

    //        Debug.Log("Set getterInfo and setterInfo");
    //    }

    //    //public static Delegate CreateGetter(Type target, FieldInfo field)
    //    //{
    //    //    MethodInfo factory = getterInfo.MakeGenericMethod(target, field.FieldType);
    //    //    return (Delegate)getterInfo.Invoke(null, new object[] { target, field });
    //    //}

    //    public static Delegate CreateSetter(Type target, FieldInfo field)
    //    {
    //        MethodInfo factory = setterInfo.MakeGenericMethod(target, field.FieldType);
    //        return (Delegate)factory.Invoke(null, new object[] { field });
    //    }
    //    //static Delegate CreateGetterGeneric<S, T>(FieldInfo field)
    //    //{
    //    //    string methodName = field.ReflectedType.FullName + ".get_" + field.Name;
    //    //    DynamicMethod setterMethod = new DynamicMethod(methodName, typeof(T), new Type[1] { typeof(S) }, true);
    //    //    ILGenerator gen = setterMethod.GetILGenerator();
    //    //    if (field.IsStatic)
    //    //    {
    //    //        gen.Emit(OpCodes.Ldsfld, field);
    //    //    }
    //    //    else
    //    //    {
    //    //        gen.Emit(OpCodes.Ldarg_0);
    //    //        gen.Emit(OpCodes.Ldfld, field);
    //    //    }
    //    //    gen.Emit(OpCodes.Ret);
    //    //    return setterMethod.CreateDelegate(typeof(Func<S, T>));
    //    //}

    //    public static Delegate CreateSetterGeneric<S, T>(FieldInfo field)
    //    {
    //        string methodName = field.ReflectedType.FullName + ".set_" + field.Name;
    //        DynamicMethod setterMethod = new DynamicMethod(methodName, null, new Type[2] { typeof(S), typeof(T) }, true);
    //        ILGenerator gen = setterMethod.GetILGenerator();
    //        if (field.IsStatic)
    //        {
    //            gen.Emit(OpCodes.Ldarg_1);
    //            gen.Emit(OpCodes.Stsfld, field);
    //        }
    //        else
    //        {
    //            gen.Emit(OpCodes.Ldarg_0);
    //            gen.Emit(OpCodes.Ldarg_1);
    //            gen.Emit(OpCodes.Stfld, field);
    //        }
    //        gen.Emit(OpCodes.Ret);
    //        return setterMethod.CreateDelegate(typeof(Action<S, T>));
    //    }
    //}


    public class BinaryCache
    {
        public static Dictionary<Type, FieldInfo[]> fieldInfo = new Dictionary<Type, FieldInfo[]>();
        //public static Dictionary<Type, TypeCache> typeInfo = new Dictionary<Type, TypeCache>();

        public static void RegisterType(Type t)
        {
            if (fieldInfo.ContainsKey(t))
            {
                return;
            }

            fieldInfo[t] = t.GetFields();
            //typeInfo[t] = new TypeCache(t);
        }

        //public class TypeCache
        //{
        //    public Dictionary<FieldInfo, Delegate> setters = new Dictionary<FieldInfo, Delegate>();
        //    //public Dictionary<FieldInfo, Delegate> getters = new Dictionary<FieldInfo, Delegate>();
        //    public TypeCache(Type t)
        //    {
        //        foreach (FieldInfo p in fieldInfo[t])
        //        {
        //            //getters[p] = FieldDelegates.CreateGetter(t, p);
        //            setters[p] = FieldDelegates.CreateSetter(t, p);
        //        }
        //    }
        //}
    }

    public class BinaryConversion
    {
        public static Dictionary<Type, Func<byte[], int, object>> conversions;
        public static Dictionary<Type, int> sizes;

        static BinaryConversion()
        {
            //Debug.Log("Initializing binary conversion");
            // Initialize the conversion dictionary
            conversions = new Dictionary<Type, Func<byte[], int, object>>();
            sizes = new Dictionary<Type, int>();

            foreach (MethodInfo m in typeof(BinaryConversion).GetMethods())
            {
                Conversion conv = m.GetCustomAttribute<Conversion>();

                if (conv == null)
                {
                    continue;
                }

                conversions[conv.t] = (Func<byte[], int, object>)Delegate.CreateDelegate(
                    typeof(Func<byte[], int, object>),
                    m
                );
                sizes[conv.t] = conv.size;

                //Debug.Log("Added conversion for type " + conv.t + " of size " + conv.size);
            }
        }


        class Conversion : Attribute
        {
            public Type t;
            public int size;
            public Conversion(Type t, int size)
            {
                this.t = t;
                this.size = size;
            }
        }

        [Conversion(typeof(byte), 1)]
        public static object ConvertByte(byte[] data, int start)
        {
            return data[start];
        }

        [Conversion(typeof(Int16), 2)]
        public static object ConvertShort(byte[] data, int start)
        {
            return BitConverter.ToInt16(data, start);
        }

        [Conversion(typeof(UInt16), 2)]
        public static object ConvertUShort(byte[] data, int start)
        {
            return BitConverter.ToUInt16(data, start);
        }

        [Conversion(typeof(Int32), 4)]
        public static object ConvertInt(byte[] data, int start)
        {
            return BitConverter.ToInt32(data, start);
        }
        [Conversion(typeof(UInt32), 4)]
        public static object ConvertUInt(byte[] data, int start)
        {
            return BitConverter.ToUInt32(data, start);
        }

        [Conversion(typeof(Int64), 8)]
        public static object ConvertLong(byte[] data, int start)
        {
            return BitConverter.ToInt64(data, start);
        }
        [Conversion(typeof(UInt64), 8)]
        public static object ConvertULong(byte[] data, int start)
        {
            return BitConverter.ToUInt64(data, start);
        }
        [Conversion(typeof(Single), 4)]
        public static object ConvertSingle(byte[] data, int start)
        {
            return BitConverter.ToSingle(data, start);
        }
        [Conversion(typeof(Double), 8)]
        public static object ConvertDouble(byte[] data, int start)
        {
            return BitConverter.ToDouble(data, start);
        }
    }

    public class BinaryStructure
    {
        public int Load(Stream stream, Dictionary<string, Stream> other, int start = 0, int skip = 12)
        {
            byte[] data;

            // Reference : https://stackoverflow.com/questions/1080442/how-to-convert-an-stream-into-a-byte-in-c
            using (var memoryStream = new MemoryStream())
            {
                stream.Position = 0;
                stream.CopyTo(memoryStream);
                data = memoryStream.ToArray().Skip(skip).ToArray();
            }

            Dictionary<string, byte[]> otherBytes = new Dictionary<string, byte[]>();
            foreach (string otherName in other.Keys)
            {
                byte[] otherData;
                using (var memoryStream = new MemoryStream())
                {
                    other[otherName].Position = 0;
                    other[otherName].CopyTo(memoryStream);
                    otherData = memoryStream.ToArray();
                }
                otherBytes[otherName] = otherData;

                //Debug.Log("Serialized " + otherName + " to byte[" + otherData.Length + "]");
            }

            return Load(data, otherBytes, start);
        }

        public int Load(byte[] data, Dictionary<string, byte[]> other, int start)
        {
            // Add this class to BinaryCache if we haven't yet
            BinaryCache.RegisterType(GetType());

            int offset = start;
            // Serialize the data

            // Using reflection, get all the public properties of this class
            foreach (FieldInfo p in BinaryCache.fieldInfo[GetType()])
            {
                //Debug.Log("Reading " + p.Name + " at offset " + offset);
                if (BinaryConversion.conversions.ContainsKey(p.FieldType))
                {
                    offset = SetAttribute(p, data, offset);
                    //Debug.Log("Set value of " + p.Name + " to " + p.GetValue(this).ToString());
                    continue;
                }

                //Debug.Log("Type " + p.FieldType + " is not primitive");

                var attributes = p.GetCustomAttributes<BinaryAttribute>();

                if (attributes.Count() == 0)
                {
                    // We need to set the field by serializing into a custom data type
                    if (!p.FieldType.IsSubclassOf(typeof(BinaryStructure)))
                    {
                        throw new Exception("Trying to serialize something that's not inherited from BinaryStructure");
                    }

                    //Debug.Log("Reading attribute as a sub-structure");
                    BinaryStructure child = (BinaryStructure)Activator.CreateInstance(p.FieldType);
                    offset = child.Load(data, other, offset);

                    p.SetValue(this, child);
                }
                else if (attributes.Count() == 1)
                {
                    //Debug.Log("Reading attribute using BinaryAttribute");

                    BinaryAttribute b = attributes.First();
                    offset = b.ReadAttribute(data, offset, p, this, other);
                }
                else
                {
                    throw new Exception("Invalid number of attributes " + attributes.Count() + " found");
                }

                object val = p.GetValue(this);
                //Debug.Log("Set value of " + p.Name + " to " + val);
            }

            return offset;
        }

        public int SetAttribute(FieldInfo p, byte[] data, int offset)
        {
            //Delegate d = BinaryCache.typeInfo[p.FieldType].setters[p];
            // Calculate the value and store it in this object
            object value = ConvertValue(p.FieldType, data, offset);
            p.SetValue(this, value);
            // Increase the offset
            return offset + BinaryConversion.sizes[p.FieldType];
        }

        public static object ConvertValue(Type t, byte[] data, int offset)
        {
            return BinaryConversion.conversions[t](data, offset);
        }
    }

    public class PointerArray : BinaryStructure
    {
        public uint pointer;
        public uint max;
        public uint used;
    }

    public class Pointer : BinaryStructure
    {
        public uint offset;
    }

    public class BinaryAttribute : Attribute
    {
        public virtual int ReadAttribute(byte[] data, int offset, FieldInfo f, object target, Dictionary<string, byte[]> other)
        {
            throw new NotImplementedException();
        }
    }

    public class BinaryArray : BinaryAttribute
    {
        public Type t;
        public int count;
        public BinaryArray(Type t, int count)
        {
            this.t = t;
            this.count = count;
        }

        public override int ReadAttribute(byte[] data, int offset, FieldInfo f, object target, Dictionary<string, byte[]> other)
        {
            Array array = Array.CreateInstance(t, count);
            // TODO: Support non-primitive arrays
            for (int i = 0; i < count; i++)
            {
                array.SetValue(BinaryStructure.ConvertValue(t, data, offset), i);
                offset += BinaryConversion.sizes[t];
            }

            f.SetValue(target, array);
            return offset;
        }
    }

    public class BinaryText : BinaryAttribute
    {
        public int length;
        public BinaryText(int length)
        {
            this.length = length;
        }

        public override int ReadAttribute(byte[] data, int offset, FieldInfo f, object target, Dictionary<string, byte[]> other)
        {
            try
            {
                string value = Encoding.UTF8.GetString(data, offset, length).Split('\0')[0];
                f.SetValue(target, value);
            }
            catch
            {
                f.SetValue(target, "");
                //Debug.LogError("Failed to load " + f.Name);
            }


            return offset + length;
        }
    }

    public class BinaryLoadFromOffset : BinaryAttribute
    {
        public string offset, source;

        public BinaryLoadFromOffset(string offset, string source)
        {
            this.offset = offset;
            this.source = source;
        }

        public override int ReadAttribute(byte[] data, int offset, FieldInfo f, object target, Dictionary<string, byte[]> other)
        {
            //Debug.Log("Reading attribute " + f.Name + " starting at offset " + offset);
            byte[] sourceData = data;
            if (source != "")
            {
                sourceData = other[this.source];
            }

            // Get the offset value
            int sourceOffset = (int)(uint)target.GetType().GetField(this.offset).GetValue(target);

            BinaryStructure child = (BinaryStructure)Activator.CreateInstance(f.FieldType);
            int newOffset = child.Load(sourceData, other, sourceOffset);

            f.SetValue(target, child);

            return offset;
        }
    }

    public class BinaryVariableSize : BinaryAttribute
    {

    }

    public class BinaryFixedSize : BinaryAttribute
    {
        public int size;

        public BinaryFixedSize(int size)
        {
            this.size = size;
        }
    }

    public class BinaryLoadFrom : BinaryAttribute
    {
        public Type other;

        public BinaryLoadFrom(Type other)
        {
            this.other = other;
        }
    }

    public class BinaryTSL : BinaryAttribute
    {
        public override int ReadAttribute(byte[] data, int offset, FieldInfo f, object target, Dictionary<string, byte[]> other)
        {
            if (AuroraPrefs.TargetGame() == Game.KotOR)
            {
                return offset;
            }

            return offset + 4;

            //// Read the attribute if we reach this point, by calling the base function
            //return base.ReadAttribute(data, offset, f, target, other);
        }
    }

    //public class BinaryConditional : BinaryAttribute
    //{
    //    public Type t;
    //    public uint condition;

    //    public BinaryConditional (Type t, uint condition)
    //    {
    //        this.t = t;
    //        this.condition = condition;
    //    }
    //}

    public class BinaryConditional : BinaryAttribute
    {
        public string func;
        public BinaryConditional(string func)
        {
            this.func = func;
        }

        public override int ReadAttribute(byte[] data, int offset, FieldInfo f, object target, Dictionary<string, byte[]> other)
        {
            bool active = (bool)target.GetType().GetMethod(func).Invoke(target, new object[]
            {
            data, offset, f, target, other
            });

            //Debug.Log("Active = " + active);

            if (active)
            {
                BinaryStructure child = (BinaryStructure)Activator.CreateInstance(f.FieldType);
                offset = child.Load(data, other, offset);

                f.SetValue(target, child);
            }

            return offset;
        }
    }

    public class BinaryCustom : BinaryAttribute
    {
        public string func;
        public BinaryCustom(string func)
        {
            this.func = func;
        }

        public override int ReadAttribute(byte[] data, int offset, FieldInfo f, object target, Dictionary<string, byte[]> other)
        {
            MethodInfo m = target.GetType().GetMethod(func);
            //Debug.Log("Calling method (" + func + "): " + m);
            //Debug.Log(target);

            if (m == null)
            {
                throw new Exception("Failed to find method " + func);
            }

            return (int)m.Invoke(target, new object[]
            {
            data, offset, f, target, other
            });
        }
    }

    public class BinarySkip : BinaryAttribute
    {
        public override int ReadAttribute(byte[] data, int offset, FieldInfo f, object target, Dictionary<string, byte[]> other)
        {
            return offset;
        }
    }

    public class BinaryPointerArray : BinaryAttribute
    {
        string varName, offsetName, source;
        bool movePos;
        public BinaryPointerArray(string v, bool movePos = true, string offsetName = "", string source = "")
        {
            this.varName = v;
            this.offsetName = offsetName;
            this.source = source;
            this.movePos = movePos;
        }
        public override int ReadAttribute(byte[] data, int offset, FieldInfo f, object target, Dictionary<string, byte[]> other)
        {
            byte[] sourceData = data;
            if (source != "")
            {
                sourceData = other[source];
            }

            PointerArray pointer = (PointerArray)target.GetType().GetField(varName).GetValue(target);
            int pos = (int)pointer.pointer;

            if (offsetName != "")
            {
                pos += (int)(uint)target.GetType().GetField(offsetName).GetValue(target);
            }

            Type elemType = f.FieldType.GetElementType();
            BinaryStructure[] objs = (BinaryStructure[])Array.CreateInstance(elemType, pointer.used);

            for (int i = 0; i < pointer.used; i++)
            {
                BinaryStructure obj = (BinaryStructure)Activator.CreateInstance(elemType);
                pos = obj.Load(sourceData, other, pos);
                objs[i] = obj;
            }

            f.SetValue(target, objs);

            if (pointer.used == 0 || !movePos)
            {
                return offset;
            }

            return pos;
        }
    }

    public class BinaryDerefArray : BinaryAttribute
    {
        string pointerName, varName, source;

        public BinaryDerefArray(string pointerName, string v, string source = "")
        {
            this.pointerName = pointerName;
            this.varName = v;
            this.source = source;
        }
        public override int ReadAttribute(byte[] data, int offset, FieldInfo f, object target, Dictionary<string, byte[]> other)
        {
            PointerArray namesPointer = (PointerArray)target.GetType().GetField(pointerName).GetValue(target);
            Pointer[] pointers = (Pointer[])target.GetType().GetField(varName).GetValue(target);

            byte[] sourceData = data;
            if (source != "")
            {
                sourceData = other[source];
            }

            int pos = offset;

            Type elemType = f.FieldType.GetElementType();
            BinaryStructure[] objs = (BinaryStructure[])Array.CreateInstance(elemType, namesPointer.max);

            for (int i = 0; i < namesPointer.max; i++)
            {
                pos = (int)pointers[i].offset;
                //Debug.Log("Pointer points to " + pos);
                BinaryStructure obj = (BinaryStructure)Activator.CreateInstance(elemType);
                pos = obj.Load(sourceData, other, pos);
                objs[i] = obj;
            }

            f.SetValue(target, objs);

            return pos;
        }

        public class BinarySequentialArray : BinaryAttribute
        {
            // This is a sequential array, where elements of type t (which will be
            // a BinaryStructure) are stored sequentially
            public Type t;
            public string varName, offsetVar;

            public BinarySequentialArray(Type t, string varName, string offsetVar = null)
            {
                this.t = t;
                this.varName = varName;
                this.offsetVar = offsetVar;
            }

            public override int ReadAttribute(byte[] data, int offset, FieldInfo f, object target, Dictionary<string, byte[]> other)
            {
                try
                {
                    Debug.Log(target.GetType().GetField("name").GetValue(target));
                    Debug.Log(target.GetType().GetField("vertexSize").GetValue(target));
                    Debug.Log(target.GetType().GetField("numVertices").GetValue(target));
                }
                catch
                {

                }

                // If we have an offset to use, use it
                if (offset != null)
                {
                    offset = Convert.ToInt32(target.GetType().GetField(offsetVar).GetValue(target));
                }

                // If target has a variable with name "varName", use the value of that variable
                // Otherwise, call the function "varName" on target
                int count = 0;
                if (target.GetType().GetField(varName) != null)
                {
                    count = Convert.ToInt32(target.GetType().GetField(varName).GetValue(target));
                }
                else
                {
                    count = Convert.ToInt32(target.GetType().GetMethod(varName).Invoke(target, new object[]
                    {
                    data, offset, f, target, other
                    }));
                }
                BinaryStructure[] objs = (BinaryStructure[])Array.CreateInstance(t, count);

                for (int i = 0; i < count; i++)
                {
                    BinaryStructure obj = (BinaryStructure)Activator.CreateInstance(t);
                    offset = obj.Load(data, other, offset);
                    objs[i] = obj;
                }

                f.SetValue(target, objs);

                return offset;
            }
        }
    }
}