using AuroraEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;
using Newtonsoft.Json;

public class ScriptTool : EditorWindow
{
    bool running = false;

    string location = "";

    Vector2 stackScroll, codeScroll;

    NCSScript script;
    NCSContext context;

    [MenuItem("Window/Aurora/Script Tool")]
    public static void ShowWindow()
    {
        EditorWindow.GetWindow(typeof(ScriptTool));
    }

    public void OnGUI()
    {
        using (new EditorGUILayout.VerticalScope())
        {
            using (new EditorGUILayout.HorizontalScope())
            {
                if (GUILayout.Button("Load Script"))
                {
                    LoadScript();
                }

                if (GUILayout.Button("Reset Tool"))
                {
                    ResetTool();
                }

                // Controls
                if (GUILayout.Button(">", GUILayout.Width(50), GUILayout.Height(20)))
                {
                    script.Step(context);
                }
                if (GUILayout.Button(">10", GUILayout.Width(50), GUILayout.Height(20)))
                {
                    for (int i = 0; i < 10; i++)
                    {
                        script.Step(context);
                    }
                }
                if (GUILayout.Button(">50", GUILayout.Width(50), GUILayout.Height(20)))
                {
                    for (int i = 0; i < 50; i++)
                    {
                        script.Step(context);
                    }
                }

                if (GUILayout.Button("<<", GUILayout.Width(50), GUILayout.Height(20)))
                {
                    context = new NCSContext(script, script.file);
                    script.lastInstruction = null;
                }
            }
            if (script != null && script.lastInstruction != null)
                GUILayout.Label("Last instruction (" + context.programCounter + "): " + script.lastInstruction.ToString());

            if (script != null)
            {
                ShowEditor();
            }
        }
    }

    void LoadScript()
    {
        location = EditorUtility.OpenFilePanel(
            "Open compiled NCS file",
            "D:\\KOTOR\\KOTOR1\\KOTOR\\tools\\dencs\\dencs_py",
            "ncs"
        );

        using (FileStream fs = File.OpenRead(location))
        {
            script = new NCSScript(fs, "script");
            context = new NCSContext(script, script.file);
        }
    }

    void ResetTool()
    {
        script = null;
        context = null;
    }

    void ShowEditor()
    {
        using (new EditorGUILayout.VerticalScope())
        {
            // Main viewer
            using (new EditorGUILayout.HorizontalScope())
            {
                // Show the stack
                using (var codeScope = new GUILayout.ScrollViewScope(codeScroll, "box", GUILayout.Width(Screen.width / 3), GUILayout.Height(2 * Screen.height / 3)))
                {
                    codeScroll = codeScope.scrollPosition;
                    DrawStack();
                }

                // Show the ncs bytecode
                using (var stackScope = new GUILayout.ScrollViewScope(stackScroll, "box", GUILayout.Width(Screen.width / 3), GUILayout.Height(2 * Screen.height / 3)))
                {
                    stackScroll = stackScope.scrollPosition;
                    DrawCode();
                }
            }
        }
    }

    void DrawStack()
    {
        using (new GUILayout.VerticalScope("box"))
        {
            for (int i = 0; i < context.stack.Count; i++)
            {
                if (context.stack[i] == null)
                {
                    GUILayout.Label("NULL");
                }
                else
                {
                    GUILayout.Label(context.stack[i].ToString());
                }
            }
        }
    }

    void DrawCode()
    {
        using (new GUILayout.VerticalScope("box"))
        {
            GUIStyle style = new GUIStyle();
            for (int i = 0; i < script.instructions.Count; i++)
            {
                if (i == context.GetPC())
                {
                    style.normal.textColor = Color.green;
                }
                else
                {
                    style.normal.textColor = Color.black;
                }
                GUILayout.Label(i + ": " + script.instructions[i].ToString(), style);
            }
        }
    }
}
