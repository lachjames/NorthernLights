using Invector.vCharacterController;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(vThirdPersonMotor), true)]
public class vCharacterEditor : Editor
{
    GUISkin skin;
    SerializedObject character;
    bool showWindow;

    void OnEnable()
    {
        vThirdPersonMotor motor = (vThirdPersonMotor)target;
    }

    public override void OnInspectorGUI()
    {
        if (!skin) skin = Resources.Load("vSkin") as GUISkin;
        GUI.skin = skin;

        vThirdPersonMotor motor = (vThirdPersonMotor)target;

        if (!motor) return;

        GUILayout.BeginVertical("BASIC CONTROLLER LITE BY Invector", "window");

        GUILayout.Space(30);

        if (GUILayout.Button("Purchase FULL Version"))
        {
            Application.OpenURL("https://assetstore.unity.com/publishers/13943");
        }

        EditorGUILayout.Space();

        EditorGUILayout.BeginVertical();

        base.OnInspectorGUI();

        GUILayout.EndVertical();
        EditorGUILayout.EndVertical();

        EditorGUILayout.Space();
        EditorGUILayout.Space();
    }
}