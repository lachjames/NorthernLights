using AuroraEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GFFExplorer : EditorWindow
{
    public GFFObject obj;

    string gffLocation;


    [MenuItem("Window/Aurora/GFF Explorer")]
    public static void ShowWindow ()
    {
        EditorWindow.GetWindow(typeof(GFFExplorer));
    }

    public void OnGUI()
    {
        using (new EditorGUILayout.VerticalScope())
        {
            gffLocation = EditorGUILayout.TextField("GFF Location", gffLocation);
            if (GUILayout.Button("Load"))
            {
                LoadGFF(gffLocation);
            }
        }
    }

    public void LoadGFF (string loc)
    {
        
    }
}
