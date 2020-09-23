using AuroraEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEditor.Animations;
using UnityEngine;

[Serializable]
public class AuroraStruct
{
    Dictionary<Type, string> TypeNames = new Dictionary<Type, string>()
    {
        { typeof(char), "char" },
        { typeof(byte), "byte" },
        { typeof(UInt16), "uint16"},
        { typeof(Int16), "sint16"},
        { typeof(UInt32), "uint32"},
        { typeof(Int32), "sint32"},
        { typeof(UInt64), "uint64"},
        { typeof(Int64), "int64"},
        { typeof(float), "float" },
        { typeof(double), "double" },
        { typeof(string), "resref"},
    };
    public string ToXML(string gffType, bool isRecursive = false, string structLabel = "")
    {
        // Writes this object in GFF format

        // Convert the object to XML
        string xml = !isRecursive ? "<gff3 type=\"" + gffType + "\">" : "";
        bool hasStructID = false;
        uint structid = 0;

        List<string> values = new List<string>();
        foreach (FieldInfo f in GetType().GetFields())
        {
            GFFAttribute attr = f.GetCustomAttribute<GFFAttribute>();
            
            string label = attr.name;
            Compatibility compat = attr.compatibility;
            ExistsIn existsIn = attr.existsIn;

            //Debug.Log("Compat: " + compat + "; exists: " + existsIn);

            // Make sure we only write fields compatible with the target game
            if (compat == Compatibility.KotOR && AuroraPrefs.TargetGame() == Game.TSL)
            {
                continue;
            }
            if (compat == Compatibility.TSL && AuroraPrefs.TargetGame() == Game.KotOR)
            {
                continue;
            }

            // Don't write save-only fields when writing modules
            // TODO: Allow an override for this in case mods need it?
            if (existsIn == ExistsIn.SAVE)
            {
                continue;
            }

            object value = f.GetValue(this);
            if (value == null)
            {
                continue;
            }

            if (label == "structid")
            {
                // The struct ID should be dealt with separately
                structid = (uint)f.GetValue(this);
                Debug.Log("Struct id " + structid + " found");
                hasStructID = true;
                continue;
            }

            if (f.FieldType.IsSubclassOf(typeof(AuroraStruct)))
            {
                AuroraStruct structVal = (AuroraStruct)value;
                // This is a nested AuroraStruct
                values.Add(structVal.ToXML(gffType, true, label));
            }
            else if (f.FieldType.IsGenericType && (f.FieldType.GetGenericTypeDefinition() == typeof(List<>)))
            {
                // This is a list
                string listXML = "<list label=\"" + label + "\"";
                IList list = (IList)value;

                if (list == null)
                {
                    continue;
                }

                if (list.Count == 0)
                {
                    listXML += "/>";
                }
                else
                {
                    listXML += ">";

                    foreach (AuroraStruct item in list)
                    {
                        listXML += item.ToXML(gffType, true);
                    }

                    listXML += "</list>";
                }

                values.Add(listXML);
            }
            else if (f.FieldType == typeof(GFFObject.CExoLocString))
            {
                values.Add(((GFFObject.CExoLocString)value).ToXML(f.Name));
            }
            else if (f.FieldType == typeof(GFFObject.CExoString))
            {
                values.Add(((GFFObject.CExoString)value).ToXML(f.Name));
            }
            else if (f.FieldType == typeof(Quaternion))
            {
                Quaternion q = (Quaternion)value;
                string quatXML = "<orientation label=\"" + f.Name + "\">";

                quatXML += "<double>" + q.x + "</double>";
                quatXML += "<double>" + q.y + "</double>";
                quatXML += "<double>" + q.z + "</double>";
                quatXML += "<double>" + q.w + "</double>";

                quatXML += "</orientation>";
                values.Add(quatXML);
            }
            else if (f.FieldType == typeof(Vector3))
            {
                Vector3 v = (Vector3)value;
                string vecXML = "<vector label=\"" + f.Name + "\">";

                vecXML += "<double>" + v.x + "</double>";
                vecXML += "<double>" + v.y + "</double>";
                vecXML += "<double>" + v.z + "</double>";

                vecXML += "</vector>";
                values.Add(vecXML);
            } else if (f.FieldType == typeof(Byte[]))
            {
                // Source: https://stackoverflow.com/questions/311165/how-do-you-convert-a-byte-array-to-a-hexadecimal-string-and-vice-versa
                string b64 = Convert.ToBase64String((byte[])value, Base64FormattingOptions.InsertLineBreaks);

                values.Add("<data label=\"" + label + "\">" + b64 + "</data>");
            } else if (f.FieldType == typeof(Byte))
            {
                byte b = (byte)f.GetValue(this);
                string byteXML = "<" + TypeNames[f.FieldType];

                if (label != null)
                {
                    byteXML += " label=\"" + label + "\"";
                }
                byteXML += ">" + b.ToString() + "</" + TypeNames[f.FieldType] + ">";

                values.Add(byteXML);
            } else if (f.FieldType == typeof(Char))
            {
                char c = (char)f.GetValue(this);
                string charXML = "<" + TypeNames[f.FieldType];

                if (label != null)
                {
                    charXML += " label=\"" + label + "\"";
                }

                if ((int)c == 0)
                {
                    charXML += "/>";
                } else
                {
                    charXML += ">" + c.ToString() + "</" + TypeNames[f.FieldType] + ">";
                }

                values.Add(charXML);
            }
            else
            {
                if (!TypeNames.ContainsKey(f.FieldType))
                {
                    Debug.Log("Could not find field type" + f.FieldType);
                }

                string valXML = "<" + TypeNames[f.FieldType];

                if (label != null)
                {
                    valXML += " label=\"" + label + "\"";
                }

                valXML += ">" + value.ToString() + "</" + TypeNames[f.FieldType] + ">";

                values.Add(valXML);
            }
        }

        string structLabelXML = "";

        if (structLabel != null && structLabel != "") {
            structLabelXML = " label=\"" + structLabel + "\"";
        }

        if (!isRecursive)
        {
            xml += "<struct id=\"4294967295\"" + structLabelXML + ">";
        }
        else if (hasStructID)
        {
            xml += "<struct id=\"" + structid + "\"" + structLabelXML + ">";
        }
        else
        {
            xml += "<struct id = \"0\"" + structLabelXML + ">";
        }

        foreach (string s in values)
        {
            xml += s;
        }

        xml += "</struct>";

        if (!isRecursive)
        {
            xml += "</gff3>";
        }

        return xml;
    }
    
    public AuroraStruct DeepCopy ()
    {
        Type myType = GetType();
        AuroraStruct copy = (AuroraStruct)Activator.CreateInstance(myType);

        foreach (FieldInfo f in myType.GetFields())
        {
            if (f.FieldType.IsSubclassOf(typeof(AuroraStruct)))
            {
                AuroraStruct fCopy = ((AuroraStruct)f.GetValue(this)).DeepCopy();
                f.SetValue(copy, fCopy);
            } else if (f.FieldType == typeof(Vector3))
            {
                Vector3 v = (Vector3)f.GetValue(this);
                Vector3 vCopy = new Vector3(v.x, v.y, v.z);
                f.SetValue(copy, vCopy);
            } else if (f.FieldType == typeof(Quaternion))
            {
                Quaternion q = (Quaternion)f.GetValue(this);
                Quaternion qCopy = new Quaternion(q.x, q.y, q.z, q.w);
                f.SetValue(copy, qCopy);
            } else if (f.GetValue(this) == null)
            {
                f.SetValue(copy, null);
            } else 
            {
                // Use the DeepClone method
                object fClone = DeepClone(f.GetValue(this));
                f.SetValue(copy, fClone);
            }
        }

        return copy;
    }

    // Source: https://stackoverflow.com/questions/11074381/deep-copy-of-a-c-sharp-object
    public static T DeepClone<T>(T obj)
    {
        using (var ms = new MemoryStream())
        {
            var formatter = new BinaryFormatter();
            formatter.Serialize(ms, obj);
            ms.Position = 0;
            return (T)formatter.Deserialize(ms);
        }
    }


}