using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using AuroraEngine;
using System.IO;

public class TLKTest : EditorWindow
{
    TLK tlk = null;
    StringData line = null;
    string tlk_location = "/Users/lachlanoneill/Documents/Steam/swkotor/dialog.tlk";

    [MenuItem("KotOR/TLK Test")]
    public static void ShowWindow()
    {
        EditorWindow.GetWindow(typeof(TLKTest));
    }

    public void OnGUI()
    {
        if (GUILayout.Button("Load TLK"))
        {
            LoadTLK();
        }

        if (tlk != null)
        {
            ShowTLK();
        }
    }

    void LoadTLK()
    {
        tlk = new TLK();
        using (Stream stream = File.Open(tlk_location, FileMode.Open))
        {
            tlk.Load(stream, new Dictionary<string, Stream>(), skip: 0);
        }
    }

    void ShowTLK()
    {
        if (GUILayout.Button("Random line"))
        {
            line = tlk.strings[Random.Range(0, tlk.strings.Count)];
        }

        if (line != null)
        {
            GUILayout.Label("Sound ResRef: " + line.soundResRef);
            GUILayout.Label("Text: " + line.text);
        }
    }
}