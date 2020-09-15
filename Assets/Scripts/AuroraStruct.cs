using AuroraEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

[Serializable]
public class AuroraStruct
{
    Dictionary<Type, string> TypeNames = new Dictionary<Type, string>()
    {
        { typeof(char), "char" },
        { typeof(byte), "byte" },
        { typeof(UInt16), "word"},
        { typeof(Int16), "short"},
        { typeof(UInt32), "dword"},
        { typeof(Int32), "int"},
        { typeof(UInt64), "dword64"},
        { typeof(Int64), "int64"},
        { typeof(float), "float" },
        { typeof(double), "double" },
        { typeof(string), "resref"},
        { typeof(byte[]), "void" }
    };
    public string ToXML()
    {
        // Writes this object in GFF format

        // Convert the object to XML
        string xml = "";
        bool hasStructID = false;
        int structid = 0;

        List<string> values = new List<string>();
        foreach (FieldInfo f in GetType().GetFields())
        {
            GFFAttribute attr = f.GetCustomAttribute<GFFAttribute>();
            string label = attr.name;

            object value = f.GetValue(this);
            if (value == null)
            {
                continue;
            }

            if (f.FieldType.Name == "structid")
            {
                // The struct ID should be dealt with separately
                structid = (int)f.GetValue(this);
                hasStructID = true;
            }

            if (f.FieldType.IsSubclassOf(typeof(AuroraStruct)))
            {
                AuroraStruct structVal = (AuroraStruct)value;
                // This is a nested AuroraStruct
                values.Add(structVal.ToXML());
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
                        listXML += item.ToXML();
                    }

                    listXML += "</list>";
                }

            }
            else if (f.FieldType == typeof(GFFObject.CExoLocString))
            {

            }
            else if (f.FieldType == typeof(GFFObject.CExoString))
            {

            }
            else if (f.FieldType == typeof(Quaternion))
            {

            }
            else if (f.FieldType == typeof(Vector3))
            {

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

        if (hasStructID)
        {
            xml = "<struct id=\"" + structid + "\">";

        }
        else
        {
            xml = "<struct>";
        }
        foreach (string s in values)
        {
            xml += s;
        }
        xml += "</struct>";

        return xml;
    }
}