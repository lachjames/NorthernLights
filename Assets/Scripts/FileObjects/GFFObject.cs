using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

namespace AuroraEngine
{
    public class GFFObject
    {
        public enum FieldType
        {
            Byte = 0,
            Char = 1,
            Word = 2,
            Short = 3,
            DWord = 4,
            Int = 5,
            DWord64 = 6,
            Int64 = 7,
            Float = 8,
            Double = 9,
            CExoString = 10,
            ResRef = 11,
            CExoLocString = 12,
            Void = 13,
            Struct = 14,
            List = 15,
            Quaternion = 16,
            Vector3 = 17
        }

        public enum Language
        {
            English = 0,
            French = 1,
            German = 2,
            Italian = 3,
            Spanish = 4,
            Polish = 5,
            Korean = 128,
            ChineseTraditional = 129,
            ChineseSimplified = 130,
            Japanese = 131
        }

        public enum Gender
        {
            Male = 0,
            Female = 1
        }

        [Serializable]
        public class CExoString
        {
            public string str = "";

            public static implicit operator string(CExoString c) => c.str;
            public static implicit operator CExoString(string s)
            {
                CExoString c = new CExoString();
                c.str = s;
                return c;
            }

            public static CExoString Parse (string s)
            {
                return new CExoString()
                {
                    str = s
                };
            }

            public string ToXML (string label)
            {
                return "<exostring label=\"" + label + "\">"+ str + "</exostring>";
            }

            public override string ToString ()
            {
                return str;
            }
        }

        [Serializable]
        public class CExoLocString
        {
            [Serializable]
            public class SubString
            {
                public int strid = 0;
                public string str = "";
            }

            public uint stringref = 0;
            public uint stringcount = 0;
            public SubString[] strings = new SubString[] { };

            public string ToXML(string label)
            {
                if (strings != null && strings.Length >= 0)
                {
                    Debug.LogWarning("Warning, CExoLocString XML conversion not yet implemented for non-strref");
                }

                return "<locstring label=\"" + label + "\" strref=\"" + stringref + "\"/>";
            }

            public static CExoLocString Parse (string s)
            {
                return new CExoLocString()
                {
                    stringref = 0,
                    stringcount = 1,
                    strings = new SubString[]
                    {
                        new SubString ()
                        {
                            strid = 0,
                            str = s
                        }
                    }
                };
            }
        }

        public string Label { get; set; }
        public FieldType Type { get; set; }
        public object Value { get; set; }
        public uint StructID { get; set; }

        public GFFObject(string label, FieldType type, object value)
        {
            Label = label;
            Type = type;
            Value = value;
        }

        public GFFObject(string label, FieldType type, object value, uint structID)
        {
            Label = label;
            Type = type;
            Value = value;
            StructID = structID;
        }

        //if this field is of the type 'struct', cast the data value as a dictionary and retrieve the requested child field by key
        public GFFObject this[string key]
        {
            get
            {
                if (Type == FieldType.Struct)
                {
                    return ((Dictionary<string, GFFObject>)Value)[key];
                }
                else
                {
                    throw new System.Exception(string.Format("Tried to retrieve a child value from a GFF field which is not a struct. Field has label {0} and type {1}.", Label, Type));
                }
            }
            set
            {
                if (Type == FieldType.Struct)
                {
                    GFFObject old;
                    if (((Dictionary<string, GFFObject>)Value).TryGetValue(key, out old))
                    {
                        ((Dictionary<string, GFFObject>)Value)[key] = value;
                    }
                    else
                    {
                        ((Dictionary<string, GFFObject>)Value).Add(key, value);
                    }
                }
                else
                {
                    throw new System.Exception(string.Format("Tried to set a child value on a GFF field which is not a struct. Field has label {0} and type {1}.", Label, Type));
                }
            }
        }

        //if this field is of the type 'list', cast the data value as an array of fields and retrieve the requested child field by index
        public GFFObject this[int index]
        {
            get
            {
                if (Type == FieldType.List)
                {
                    return ((GFFObject[])Value)[index];
                }
                else
                {
                    throw new System.Exception(string.Format("Tried to retrieve a child struct from a GFF field which is not a list. Field has label {0} and type {1}.", Label, Type));
                }
            }
            set
            {
                if (Type == FieldType.Struct)
                {
                    ((GFFObject[])Value)[index] = value;
                }
                else
                {
                    throw new System.Exception(string.Format("Tried to set a child struct on a GFF field which is not a list. Field has label {0} and type {1}.", Label, Type));
                }
            }
        }

        public T GetValue<T>()
        {
            try
            {
                return (T)Value;
            }
            catch (InvalidCastException)
            {
                Debug.LogError(string.Format("Failed to cast the specified GFF value, label was {0} and the type is {1}", Label, Value.GetType()));
                return default(T);
            }
        }

        public object Serialize<T>()
        {
            Type objectType = typeof(T);

            // Creates an instance of "T" from this GFFObject
            // Will throw an exception if a field does not match
            // the class we are serializing into
            switch (Type)
            {
                case GFFObject.FieldType.Struct:
                    T return_obj = (T)Activator.CreateInstance(objectType);

                    Dictionary<string, GFFObject> dict = (Dictionary<string, GFFObject>)Value;
                    HashSet<string> found = new HashSet<string>();

                    foreach (FieldInfo p in objectType.GetFields(BindingFlags.Public | BindingFlags.Instance))
                    {
                        // Check that the dictionary has this property
                        GFFAttribute attr = (GFFAttribute)p.GetCustomAttributes(typeof(GFFAttribute)).First();
                        string name = attr.name;

                        if (!dict.ContainsKey(name))
                        {
                            if (name == "structid")
                            {
                                p.SetValue(return_obj, StructID);
                                continue;
                            }
                            else
                            {
                                //Debug.LogWarning("Key " + name + " not found");
                                continue;
                            }
                        }

                        found.Add(name);

                        // Create a generic serializer method based on the expected type of this field
                        GFFObject obj = dict[name];
                        MethodInfo serializer = obj.GetType().GetMethod("Serialize").MakeGenericMethod(p.FieldType);

                        // Invoke this serializer on the value dict[name]
                        object serialized = serializer.Invoke(dict[name], null);

                        // Set the value in the instance
                        p.SetValue(return_obj, serialized);
                    }

                    //foreach (string k in dict.Keys)
                    //{
                    //    if (!found.Contains(k))
                    //    {
                    //        Debug.LogWarning("Did not serialize value " + k + " with type " + dict[k].Value.GetType().ToString());
                    //    }
                    //}

                    return return_obj;

                case GFFObject.FieldType.List:
                    // This is made easier because any list is guaranteed to be of type
                    // List<GFFObject> (and the objects are always structs, but that's
                    // not actually important).
                    Type listType = objectType.GetGenericArguments()[0];

                    Type newListType = typeof(List<>).MakeGenericType(new[] { listType });
                    IList return_list = (IList)Activator.CreateInstance(newListType);

                    GFFObject[] items = (GFFObject[])Value;
                    foreach (GFFObject obj in items)
                    {
                        MethodInfo serializer = obj.GetType().GetMethod("Serialize").MakeGenericMethod(listType);
                        object serialized = serializer.Invoke(obj, null);

                        return_list.Add(serialized);
                    }

                    return return_list;

                case GFFObject.FieldType.Byte:
                case GFFObject.FieldType.Char:
                case GFFObject.FieldType.Word:
                case GFFObject.FieldType.Short:
                case GFFObject.FieldType.DWord:
                case GFFObject.FieldType.Int:
                case GFFObject.FieldType.DWord64:
                case GFFObject.FieldType.Int64:
                case GFFObject.FieldType.Float:
                case GFFObject.FieldType.Double:
                case GFFObject.FieldType.CExoString:
                case GFFObject.FieldType.ResRef:
                case GFFObject.FieldType.CExoLocString:
                case GFFObject.FieldType.Void:
                case GFFObject.FieldType.Quaternion:
                case GFFObject.FieldType.Vector3:
                    return Value;
                default:
                    throw new Exception("Could not serialize type " + Type.ToString());
            }
        }

        public static GFFObject Deserialize()
        {
            // Takes an object and uses reflection to
            // create a GFFObject from it
            // Will throw an exception if there exists a public
            // field which cannot be converted to GFFObject
            throw new NotImplementedException();
        }
    }
}