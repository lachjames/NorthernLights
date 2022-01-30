using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using AuroraEngine;
using System.IO;

public class NCSReaderTest : EditorWindow
{
    NCSFile file;
    Vector2 scroll = new Vector2();

    [MenuItem("KotOR/NCS Reader Test")]
    public static void ShowWindow()
    {
        EditorWindow.GetWindow(typeof(NCSReaderTest));
    }

    public void OnGUI()
    {
        if (GUILayout.Button("Test"))
        {
            Test();
        }

        if (file != null)
        {
            ShowFile();
        }
    }

    void Test()
    {
        // Get NCS file from the user
        string filePath = EditorUtility.OpenFilePanel("Select NCS file", "", "NCS");
        if (filePath == "")
        {
            return;
        }

        // Load the NCS from a stream
        using (FileStream stream = File.Open(filePath, FileMode.Open))
        {
            file = new NCSFile(stream);
        }
    }

    void ShowFile()
    {
        // Show the file in a scroll view
        scroll = GUILayout.BeginScrollView(scroll);

        // Show each instruction in the file
        foreach (NCSOperation op in file.operations)
        {
            string opText = op.opType.ToString() + " (" + op.opcode + ") ";
            if (op.args != null)
            {
                opText += "{";
                foreach (string arg in op.args)
                {
                    opText += arg.ToString() + ", ";
                }
                opText += "}";
            }
            GUILayout.Label(opText);
        }

        GUILayout.EndScrollView();
    }
}