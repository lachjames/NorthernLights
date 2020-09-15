using UnityEditor;
using UnityEngine;

namespace Invector.vCamera
{
    [CustomEditor(typeof(vThirdPersonCamera))]
    [CanEditMultipleObjects]
    public class vThirdPersonCameraEditor : Editor
    {
        GUISkin skin;
        vThirdPersonCamera tpCamera;      
        private Texture2D m_Logo = null;

        void OnSceneGUI()
        {
            if (Application.isPlaying)
                return;
            tpCamera = (vThirdPersonCamera)target;
        }

        void OnEnable()
        {
            m_Logo = (Texture2D)Resources.Load("tp_camera", typeof(Texture2D));
            tpCamera = (vThirdPersonCamera)target;
            tpCamera.indexLookPoint = 0;
        }

        public override void OnInspectorGUI()
        {
            if (!skin) skin = Resources.Load("vSkin") as GUISkin;
            GUI.skin = skin;

            GUILayout.BeginVertical("THIRD PERSON CAMERA LITE BY Invector", "window");

            GUILayout.Space(30);

            EditorGUILayout.BeginVertical();

            base.OnInspectorGUI();

            GUILayout.Space(10);

            GUILayout.EndVertical();
            EditorGUILayout.EndVertical();

            GUILayout.Space(2);           
        }       
    }
}