using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Net.Http.Headers;
using System.Collections.Specialized;
using AuroraEngine;

public class NCSTraceViewer: EditorWindow
{
    int selectedTrace = 0;
    Vector2 scrollPosition = Vector2.zero;
    string traceText = "";

    [MenuItem("KotOR/NCS Trace")]
    public static void ShowWindow()
    {
        EditorWindow.GetWindow(typeof(NCSTraceViewer));
    }

    public void OnGUI()
    {
        List<string> options = new List<string>();

        if (GUILayout.Button("Reset"))
        {
            NCSTrace.traces.Clear();
        }

        if (NCSTrace.traces.Count == 0)
        {
            return;
        }

        int i = 0;
        foreach (NCSTrace t in NCSTrace.traces)
        {
            AuroraObject obj = t.contexts[0].objectSelf;

            string tag;
            if (obj == null)
            {
                tag = "NULL";
            } else
            {
                dynamic template = obj.template;
                tag = template.Tag;
            }
            options.Add(i + ": " + tag);
            i++;
        }

        selectedTrace = EditorGUILayout.Popup(selectedTrace, options.ToArray());

        NCSTrace trace = NCSTrace.traces[selectedTrace];
        DrawTrace(trace);
    }

    void DrawTrace (NCSTrace trace)
    {
        // Write out some metadata about the trace

        // Write out the trace data
        using (new EditorGUILayout.VerticalScope())
        {
            int i = 0;
            foreach (NCSContext context in trace.contexts)
            {
                EditorGUILayout.LabelField(i + ": " + ContextStatus(context));
                i++;
            }

            using (var scroll = new EditorGUILayout.ScrollViewScope(scrollPosition))
            {
                scrollPosition = scroll.scrollPosition;
                foreach (NCSContext context in trace.contexts)
                {
                    foreach (string str in context.logs)
                    {
                        if (GUILayout.Button(str))
                        {
                            traceText = str;
                        }
                    }
                }
            }

            EditorGUILayout.TextArea(traceText);
        }
    }

    string ContextStatus(NCSContext context)
    {
        string str = "Script " + context.script.scriptName + " owned by " + context.objectSelf;

        str += "stopped @ PC = " + context.GetPC() + "; Last instruction: " + string.Join(" ", context.script.instructions[context.GetPC()].args);

        return str;
    }
}