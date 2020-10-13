using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using XNodeEditor;
using System;
using static XNode.Node;

[CustomNodeEditor(typeof(QuestMultiplexer))]
[Serializable]
public class MultiplexerEditor : NodeEditor
{
    public string script;
    public List<int> outputs = new List<int>();
    private QuestMultiplexer node;
    public override void OnBodyGUI()
    {
        foreach (XNode.NodePort instancePort in target.Ports)
        {
            if (instancePort.fieldName == "trigger")
            {
                NodeEditorGUILayout.PortField(instancePort);
            }
        }

        using (new EditorGUILayout.HorizontalScope())
        {
            EditorGUILayout.LabelField("Script:", GUILayout.Width(100));
            script = EditorGUILayout.TextField(script);
        }

        if (GUILayout.Button("Add Output"))
        {
            outputs.Add(0);
            node.AddDynamicOutput(typeof(QuestPhase), XNode.Node.ConnectionType.Override, XNode.Node.TypeConstraint.Inherited, "output_" + outputs.Count);
        }

        int i = 0;
        foreach (XNode.NodePort dynamicPort in target.DynamicPorts)
        {
            if (i >= outputs.Count)
            {
                continue;
            }
            outputs[i] = int.Parse(EditorGUILayout.TextField(outputs[i].ToString()));
            NodeEditorGUILayout.PortField(dynamicPort);
            i++;
        }

        if (node == null) node = target as QuestMultiplexer;

        serializedObject.Update();
    }
}
