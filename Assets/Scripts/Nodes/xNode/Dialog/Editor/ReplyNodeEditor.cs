using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using static XNodeEditor.NodeEditor;
using XNodeEditor;

[CustomNodeEditor(typeof(ReplyNode))]
public class ReplyNodeEditor : NodeEditor
{
    private ReplyNode node;
    public override void OnBodyGUI ()
    {
        base.OnBodyGUI();

        if (node == null) node = target as ReplyNode;

        serializedObject.Update();

        // Show the text, making sure to word wrap where necessary
        bool oldWordWrap = EditorStyles.label.wordWrap;
        EditorStyles.label.wordWrap = true;
        GUILayout.Label(AuroraEngine.Resources.GetString(node.reply.Text));
        EditorStyles.label.wordWrap = oldWordWrap;
    }
}
