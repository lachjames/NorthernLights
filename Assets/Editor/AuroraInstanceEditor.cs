using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(AuroraInstance))]
[CanEditMultipleObjects]
public class LookAtPointEditor : Editor
{
    public override void OnInspectorGUI()
    {
        GFFEditor.DrawStruct(((AuroraInstance)target).gitData);
    }
}
