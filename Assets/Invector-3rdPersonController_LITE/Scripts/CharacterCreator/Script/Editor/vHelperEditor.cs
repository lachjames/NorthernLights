using UnityEngine;
using UnityEditor;

namespace Invector
{
    class vHelperEditor : EditorWindow
    {
        [MenuItem("Invector/Help/Forum")]
        public static void Forum()
        {
            Application.OpenURL("http://invector.proboards.com/");
        }

        [MenuItem("Invector/Help/FAQ")]
        public static void FAQMenu()
        {
            Application.OpenURL("http://inv3ctor.wix.com/invector#!faq/cnni7");
        }
       
        [MenuItem("Invector/Help/Release Notes")]
        public static void ReleaseNotes()
        {
            Application.OpenURL("http://inv3ctor.wix.com/invector#!release-notes/eax8d");
        }

        [MenuItem("Invector/Help/Youtube Tutorials")]
        public static void Youtube()
        {
            Application.OpenURL("https://www.youtube.com/playlist?list=PLvgXGzhT_qehYG_Kzl5P6DuIpHynZP9Ju");
        }

        [MenuItem("Invector/Help/Online Documentation")]
        public static void Documentation()
        {
            Application.OpenURL("http://www.invector.xyz/thirdpersondocumentation");
        }       
    }
}