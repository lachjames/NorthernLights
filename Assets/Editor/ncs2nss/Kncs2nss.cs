using AuroraEngine;
using NCSInstructions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class Kncs2nss : EditorWindow
{
    Vector2 scrollPos;

    string loc;
    NCSScript script;
    
    Texture2D graph_texture;

    [MenuItem("KotOR/ncs2nss")]
    public static void ShowWindow()
    {
        GetWindow<Kncs2nss>(false, "ncs2nss", true);
    }

    public void OnGUI()
    {
        using (var scroll = new EditorGUILayout.ScrollViewScope(scrollPos))
        {
            scrollPos = scroll.scrollPosition;

            if (GUILayout.Button("Load Script"))
            {
                LoadScript();
            }
            if (graph_texture != null)
            {
                GUILayout.Label(graph_texture);
            }
        }
    }

    void LoadScript()
    {
        loc = EditorUtility.OpenFilePanel("Open Script", "", "*.ncs");
        using (Stream stream = new FileStream(loc, FileMode.Open))
        {
            script = new NCSScript(stream, Path.GetFileNameWithoutExtension(loc));
        }

        DecompileScript(script);
    }

    string DecompileScript(NCSScript script)
    {
        // Preprocessing
        script = Preprocess(script);

        //// Parse subroutines
        SubroutineGraph subGraph = new SubroutineGraph(script);

        // Perform heuristic signature analysis

        // Parse globals

        // Perform data-flow analysis

        // Perform control-flow analysis

        // Convert to NSS code

        return null;
    }

    NCSScript Preprocess(NCSScript script)
    {
        return script;
    }
}
