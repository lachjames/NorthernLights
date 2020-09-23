using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Reflection;
using System;
using AuroraEngine;

[CustomEditor(typeof(AuroraObject), true)]
[CanEditMultipleObjects]
public class GFFEditor : Editor
{
    static Dictionary<object, bool> isOpen = new Dictionary<object, bool>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void OnInspectorGUI()
    {

        AuroraObject container = (AuroraObject)target;
        //foreach (Component component in container.GetComponents<Component>())
        //{
        //    if (component.GetType() != typeof(AuroraObject) && component.GetType() != typeof(Transform))
        //    {
        //        component.hideFlags = HideFlags.HideInInspector;
        //    }
        //}
        base.OnInspectorGUI();

        if (container.template == null)
        {
            return;
        }

        EditorGUILayout.LabelField("Editing type " + container.template.GetType().Name);

        CreateInspector(container, container.template, "");
    }

    public static void CreateInspector (AuroraObject obj, AuroraStruct owner, string name)
    {
        if (owner == null)
        {
            //Debug.LogWarning("Owner for " + name + " was null");
            return;
        }
        using (new EditorGUILayout.VerticalScope("box"))
        {
            if (name != "")
            {
                EditorGUILayout.LabelField(name);
            }

            // Draw some debug information for this object
            if (obj != null)
            {
                EditorGUILayout.TextField("Actions:");
                int i = 0;
                foreach (AuroraAction action in obj.actions) {
                    EditorGUILayout.LabelField(i + ": " + action);
                    i++;
                }
                EditorGUILayout.Space();

                EditorGUILayout.TextField("Effects: ");
                i = 0;
                foreach (AuroraEffect effect in obj.effects)
                {
                    EditorGUILayout.LabelField(i + ": " + effect);
                    i++;
                }
             
                EditorGUILayout.Space();
            }

            DrawStruct(owner);
        }
    }

    public static void DrawStruct (AuroraStruct owner)
    {
        // This is an AuroraStruct object
        foreach (FieldInfo f in owner.GetType().GetFields())
        {
            if (f.FieldType.IsSubclassOf(typeof(AuroraStruct)))
            {
                CreateInspector(null, (AuroraStruct)f.GetValue(owner), f.Name);
                continue;
            }

            if (f.FieldType.IsGenericType && f.FieldType.GetGenericTypeDefinition() == typeof(List<>))
            {
                DrawList(f, owner);
                continue;
            }

            DrawField(f, owner);
        }
    }

    public static void DrawList (FieldInfo listField, AuroraStruct owner)
    {
        // Assumption: All lists used here are of type List<AuroraStruct>
        // (This is how the GFF structure is defined so it should work fine here,
        // but for other situations it might cause issus)

        Type listType = listField.FieldType.GetGenericArguments()[0];
        object listObj = listField.GetValue(owner);

        if (listObj == null)
        {

            Type genericType = typeof(List<>).MakeGenericType(new Type[] { listType });
            listObj = Activator.CreateInstance(genericType);

            listField.SetValue(owner, listObj);
        }

        if (!isOpen.ContainsKey(listObj))
        {
            isOpen[listObj] = false;
        }

        IList list = (IList)listObj;
        
        using (new EditorGUILayout.VerticalScope("box"))
        {

            using (new EditorGUILayout.HorizontalScope())
            {
                EditorGUILayout.LabelField("List " + listField.Name);

                if (GUILayout.Button("Toggle"))
                {
                    // Toggle whether list is open
                    isOpen[listObj] = !isOpen[listObj];
                }

                if (GUILayout.Button("+"))
                {
                    // Add to list
                    object newValue = Activator.CreateInstance(listType);
                    list.Add(newValue);
                }
            }

            if (!isOpen[listObj])
            {
                return;
            }

            int i = 0;
            foreach (AuroraStruct val in list)
            {
                DrawListItem(list, val, i);
                i++;
            }
        }
    }

    public static void DrawListItem (IList list, AuroraStruct obj, int idx)
    {
        using (new EditorGUILayout.HorizontalScope("box"))
        {
            // Buttons
            using (new EditorGUILayout.VerticalScope("box"))
            {
                EditorGUILayout.LabelField(idx.ToString(), GUILayout.Width(20));

                if (GUILayout.Button("-", GUILayout.Width(30)))
                {
                    list.RemoveAt(idx);
                    return;
                }

                if (GUILayout.Button("↑", GUILayout.Width(30)))
                {
                    // Move item up
                    return;
                }

                if (GUILayout.Button("↓", GUILayout.Width(30)))
                {
                    // Move item down
                    return;
                }
            }

            // List item
            using (new EditorGUILayout.VerticalScope("box"))
            {
                CreateInspector(null, obj, "");
            }
        }
    }

    public static void DrawField (FieldInfo field, AuroraStruct owner)
    {
        object value = field.GetValue(owner);
        string str = "";
        if (value != null)
        {
            str = value.ToString();
        }

        if (field.FieldType == typeof(GFFObject.CExoLocString))
        {
            // We deal with CExoLocString separately
            DrawExoLoc(field, owner);
            return;
        }

        string newValue = Draw(field.Name, str);

        // Check if str has changed
        if (newValue == str)
        {
            return;
        }

        if (field.FieldType == typeof(string))
        {
            field.SetValue(owner, newValue);
            return;
        }

        // Update the value of the field to the new given value
        MethodInfo parser = field.FieldType.GetMethod("Parse", new Type[] { typeof(string) });
        if (parser == null)
        {
            Debug.LogWarning("Could not find parser for type " + field.FieldType);
            return;
        }

        object newObj = parser.Invoke(null, new object[] { newValue });
        field.SetValue(owner, newObj);
    }

    public static void DrawExoLoc (FieldInfo f, AuroraStruct owner)
    {
        GFFObject.CExoLocString cur = (GFFObject.CExoLocString)f.GetValue(owner);

        if (cur == null)
        {
            cur = new GFFObject.CExoLocString();
            f.SetValue(owner, cur);
        }

        using (new EditorGUILayout.VerticalScope())
        {
            // Show the resref

            string newRef = Draw(f.Name + " (resref)", cur.stringref.ToString());
            cur.stringref = uint.Parse(newRef);

            if (cur.strings == null)
            {
                return;
            }

            if (GUILayout.Button("Add String"))
            {
                cur.strings.Add(new GFFObject.CExoLocString.SubString());
            }

            // Show the list of strings
            for (int i = 0; i < cur.strings.Count; i++)
            {
                GFFObject.CExoLocString.SubString sub = cur.strings[i];

                using (new EditorGUILayout.VerticalScope("box"))
                {
                    try
                    {
                        if (GUILayout.Button("Delete")) {
                            cur.strings.RemoveAt(i);
                            continue;
                        }
                        EditorGUILayout.LabelField("String " + i);
                        string newID = Draw("ID" + i, sub.strid.ToString());
                        string newValue = Draw("String", sub.str);

                        int idVal = int.Parse(newID);
                        GFFObject.CExoLocString.SubString newSub = new GFFObject.CExoLocString.SubString();
                        newSub.strid = idVal;
                        newSub.str = newValue;

                        cur.strings[i] = newSub;
                    }
                    catch { }
                }
            }
        }
    }

    public static string Draw (string label, string cur)
    {
        using (new EditorGUILayout.HorizontalScope("box"))
        {
            EditorGUILayout.LabelField(label, GUILayout.MaxWidth(120));
            return EditorGUILayout.TextField(cur);
        }
    }
}
