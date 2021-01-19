using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Net.Http.Headers;
using System.Collections.Specialized;
using AuroraEngine;

public class ScriptStack: EditorWindow
{
    int selectedTrace = 0;
    Vector2 scrollPosition = Vector2.zero;
    string traceText = "";

    [MenuItem("KotOR/Script Stack")]
    public static void ShowWindow()
    {
        EditorWindow.GetWindow(typeof(ScriptStack));
    }

    public void OnGUI()
    {
        using (var scroll = new GUILayout.ScrollViewScope(scrollPosition))
        {
            scrollPosition = scroll.scrollPosition;
            LoggedEvents.DrawGUI();
        }
    }
}