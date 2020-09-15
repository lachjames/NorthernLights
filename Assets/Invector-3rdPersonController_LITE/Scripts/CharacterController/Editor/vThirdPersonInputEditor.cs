using UnityEditor;
using UnityEngine;

[CanEditMultipleObjects]
[CustomEditor(typeof(Invector.vCharacterController.vThirdPersonInput), true)]
public class vThirdPersonInputEditor : Editor
{
    GUISkin skin;

    public override void OnInspectorGUI()
    {
        if (!skin) skin = Resources.Load("vSkin") as GUISkin;
        GUI.skin = skin;

        GUILayout.BeginVertical("INPUT MANAGER", "window");

        GUILayout.Space(30);

        EditorGUILayout.BeginVertical();

        base.OnInspectorGUI();

        GUILayout.Space(10);

        GUILayout.EndVertical();
        EditorGUILayout.EndVertical();

        GUILayout.Space(2);
    }
}