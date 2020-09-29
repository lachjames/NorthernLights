using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using static XNodeEditor.NodeEditor;
using XNodeEditor;

[CustomNodeEditor(typeof(EntryNode))]
public class EntryNodeEditor : NodeEditor
{
    private EntryNode node;
    public override void OnBodyGUI ()
    {
        base.OnBodyGUI();

        if (node == null) node = target as EntryNode;

        serializedObject.Update();

        // Show the text, making sure to word wrap where necessary
        bool oldWordWrap = EditorStyles.label.wordWrap;
        EditorStyles.label.wordWrap = true;
        GUILayout.Label(AuroraEngine.Resources.GetString(node.entry.Text));
        EditorStyles.label.wordWrap = oldWordWrap;
    }
}
