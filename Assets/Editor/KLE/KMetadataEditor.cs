using AuroraEngine;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class KMetadataEditor : EditorWindow
{
    int tab;
    Vector2 scrollPos;

    AuroraStruct curData;

    [MenuItem("KotOR/Metadata Editor")]
    public static void ShowWindow()
    {
        GetWindow<KMetadataEditor>(false, "Metadata Editor", true);
    }

    public void OnGUI()
    {
        using (new EditorGUILayout.VerticalScope("box"))
        {
            tab = GUILayout.Toolbar(tab, new string[] { "GIT", "ARE", "IFO" });

            switch(tab)
            {
                case 0:
                    curData = AuroraEngine.Resources.data.module.git;
                    break;
                case 1:
                    curData = AuroraEngine.Resources.data.module.are;
                    break;
                case 2:
                    curData = AuroraEngine.Resources.data.module.ifo;
                    break;
            }

            if (curData != null)
            {
                using (var scroll = new EditorGUILayout.ScrollViewScope(scrollPos))
                {
                    scrollPos = scroll.scrollPosition;
                    GFFEditor.DrawStruct(curData);
                }
            }
        }
    }
}