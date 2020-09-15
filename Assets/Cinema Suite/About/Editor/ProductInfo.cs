
using UnityEditor;
using UnityEngine;
using UnityEditor.AnimatedValues;
using System;
using System.Xml;
using System.Xml.Linq;
using System.Linq;
using System.IO;

namespace CinemaSuite
{
    public class ProductInfo
    {
        public string name;
        public string version;

		public Texture2D keyImage;
		public Texture2D fiveStars;

		public Texture2D resourceImage1;
		public Texture2D resourceImage2;
		public Texture2D resourceImage3;
		public Texture2D resourceImage4;

		public string resourceImage1Link;
		public string resourceImage2Link;
		public string resourceImage3Link;
		public string resourceImage4Link;

		public string resourceImage1Label;
		public string resourceImage2Label;
		public string resourceImage3Label;
		public string resourceImage4Label;

		public string headerText;
		public string header2Text;
		public string bodyText;

		public bool installed = false;
        public string assetStorePage = "";

        public AnimBool ShowProductInfo;

        /// <summary>
        /// If used, be sure to call Initialize() after.
        /// </summary>
        public ProductInfo()
        {
            fiveStars = Resources.Load("FiveStars") as Texture2D;
        }

        public ProductInfo(UnityEngine.Events.UnityAction Repaint)
        {
            Initialize(Repaint);
        }

        public void Initialize(UnityEngine.Events.UnityAction Repaint)
        {
            ShowProductInfo = new AnimBool(true, Repaint);
        }

        internal virtual void OnGUI(Rect position)
        {
            EditorGUILayout.BeginHorizontal();

            EditorGUILayout.BeginVertical(GUILayout.Width(228));
            Rect keyImageRect = EditorGUILayout.GetControlRect(GUILayout.Height(128), GUILayout.Width(228));

            if (GUI.Button(keyImageRect, keyImage, EditorStyles.label))
            {
                Application.OpenURL(assetStorePage);
            }

            EditorGUIUtility.AddCursorRect(keyImageRect, MouseCursor.Link);

            GUI.skin.button.alignment = TextAnchor.MiddleCenter;
            GUI.skin.button.imagePosition = ImagePosition.ImageAbove;


            EditorGUILayout.BeginHorizontal();
            Rect rect = EditorGUILayout.GetControlRect(GUILayout.Height(42), GUILayout.Width(54));
            if (GUI.Button(rect, new GUIContent(resourceImage1Label, resourceImage1)))
            {
                Application.OpenURL(resourceImage1Link);
            }

            rect = EditorGUILayout.GetControlRect(GUILayout.Height(42), GUILayout.Width(54));
            if (GUI.Button(rect, new GUIContent(resourceImage2Label, resourceImage2)))
            {
                Application.OpenURL(resourceImage2Link);
            }

            rect = EditorGUILayout.GetControlRect(GUILayout.Height(42), GUILayout.Width(54));
            if (GUI.Button(rect, new GUIContent(resourceImage3Label, resourceImage3)))
            {
                Application.OpenURL(resourceImage3Link);
            }

            rect = EditorGUILayout.GetControlRect(GUILayout.Height(42), GUILayout.Width(56));
            if (GUI.Button(rect, new GUIContent(resourceImage4Label, resourceImage4)))
            {
                Application.OpenURL(resourceImage4Link);
            }
            EditorGUILayout.EndHorizontal();

            GUI.skin.label.alignment = TextAnchor.UpperLeft;

            EditorGUILayout.EndVertical();

            EditorGUILayout.BeginVertical();

            GUI.skin.label.wordWrap = true;
            Rect heading1Rect = EditorGUILayout.GetControlRect(GUILayout.Height(20));
            Rect heading2Rect = EditorGUILayout.GetControlRect(GUILayout.Height(18));
            Rect bodyRect = EditorGUILayout.GetControlRect(GUILayout.Height(128));

            GUI.Label(heading1Rect, headerText);
            GUI.Label(heading2Rect, header2Text);
            GUI.Label(bodyRect, new GUIContent(bodyText));

            EditorGUILayout.EndVertical();
            EditorGUILayout.EndHorizontal();
        }
    }
}