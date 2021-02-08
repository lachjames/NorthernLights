using AuroraEngine;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem.Android;
using UnityEngine.Networking;

public class KAIVO : EditorWindow
{
    AuroraDLG dlg;
    Vector2 editorScroll;
    string speaker;
    string loadLoc;

    [MenuItem("KotOR/KotOR AIVO")]
    public static void ShowWindow()
    {
        GetWindow<KAIVO>(false, "KotOR AIVO", true);
    }

    public void OnGUI()
    {
        using (new EditorGUILayout.VerticalScope())
        {
            Menu();
        }
    }

    void Menu()
    {
        using (new EditorGUILayout.VerticalScope())
        {
            if (GUILayout.Button("Load DLG File"))
            {
                LoadFile();
            }
            GUILayout.Label("Speaker");
            speaker = GUILayout.TextField(speaker);
            if (GUILayout.Button("Save Converted DLG"))
            {
                SaveFile();
            }
        }
    }

    void ConvertDLG ()
    {
        // The conversion works using the following process:
        //   - For every Entry node:
        //       - If the Speaker attribute is blank, set it to the Speaker string value instead
        //   - For every Reply node:
        //       - Create a new Entry node, and a new Reply node with empty text
        //       - Give the new Entry node the same text as the original Reply node
        //       - Connect the original Reply node to the new Entry node
        //       - Connect the new Entry node to the new Reply node
        //       - Remove all connections from the original Reply node to other Entry nodes,
        //         and connect the new Reply node to those Entry nodes instead

        // We must do this first, or the speaker will also speak the PC's lines
        foreach (AuroraDLG.AEntry entry in dlg.EntryList)
        {
            if (entry.Speaker == "")
            {
                if (entry.Text.stringref > 1000000 && entry.Text.stringcount == 0 && entry.Text.strings.Count == 0)
                {
                    // This line is blank
                } else
                {
                    entry.Speaker = new GFFObject.CExoString() { str = speaker };
                }
            }

            //if (
            //    (entry.Script != "" && entry.Speaker.str.ToLower() == speaker.ToLower())
            //)
            //{
            //    // This entry requires a script to be executed with the original speaker as OBJECT_SELF...
            //    entry.ActionParamStrA = entry.Script;
            //    entry.Script = "og_speak_run";
            //}

            //if (
            //    (entry.Script2 != "" && entry.Speaker.str.ToLower() == speaker.ToLower())
            //)
            //{
            //    entry.ActionParamStrB = entry.Script2;
            //    entry.Script2 = "og_speak_run";
            //}
        }

        foreach (AuroraDLG.AReply reply in new List<AuroraDLG.AReply>(dlg.ReplyList))
        {
            if (reply.Text.stringref > 1000000 && reply.Text.stringcount == 0 && reply.Text.strings.Count == 0)
            {
                continue;
            }
            if (reply.Text.strings.Count > 0 && reply.Text.strings[0].str == "")
            {
                continue;
            }

            // Add a new Entry
            AuroraDLG.AEntry newEntry = new AuroraDLG.AEntry();
            newEntry.Text = reply.Text;
            newEntry.Delay = 4294967295;
            int newEntryIdx = dlg.EntryList.Count;
            newEntry.structid = (uint)newEntryIdx;
            dlg.EntryList.Add(newEntry);

            // Copy dialog information
            if (reply.Listener == "")
            {
                newEntry.Listener = speaker;
            } else
            {
                newEntry.Listener = reply.Listener;
            }
            newEntry.Emotion = reply.Emotion;
            
            // Copy camera information
            newEntry.CameraAngle = reply.CameraAngle;
            newEntry.CameraID = reply.CameraID;
            newEntry.CameraAnimation = reply.CameraAnimation;
            newEntry.CamVidEffect = reply.CamVidEffect;
            newEntry.CamFieldOfView = reply.CamFieldOfView;
            newEntry.CamHeightOffset = reply.CamHeightOffset;

            // Add a new Reply
            AuroraDLG.AReply newReply = new AuroraDLG.AReply();
            newReply.Text = new GFFObject.CExoLocString()
            {
                stringref = 4294967295
            };
            newReply.Delay = 0;
            int newReplyIdx = dlg.ReplyList.Count;
            newReply.structid = (uint)newReplyIdx;
            dlg.ReplyList.Add(newReply);

            // We set up the chain as follows:
            // reply -> newEntry -> newReply -> reply.EntriesList

            // newEntry -> newReply
            newEntry.RepliesList = new List<AuroraDLG.AEntry.AReplies>()
            {
                new AuroraDLG.AEntry.AReplies()
                {
                    Index = (uint)newReplyIdx
                }
            };

            // newReply -> reply.EntriesList
            newReply.EntriesList = new List<AuroraDLG.AReply.AEntries>(reply.EntriesList);

            // reply -> newEntry
            reply.EntriesList = new List<AuroraDLG.AReply.AEntries>()
            {
                new AuroraDLG.AReply.AEntries()
                {
                    Index = (uint)newEntryIdx
                }
            };
        }

        GetWindow<KDialogEditor>(false, "Dialog Editor", true).dlg = dlg;
    }

    string TrimPath(int n)
    {
        string filename = Path.GetFileNameWithoutExtension(loadLoc);
        return filename.Substring(0, Math.Min(filename.Length, n));
    }

    AuroraDLG CreateTransitionDLG ()
    {
        // The transition DLG consists of a single entry, which
        // runs a script that starts the new dialog
        AuroraDLG transitionDLG = new AuroraDLG();
        transitionDLG.EntryList.Add(new AuroraDLG.AEntry()
        {
            structid = 0,
            Text = new GFFObject.CExoLocString()
            {
                stringref = 4294967295
            },
            Script = "aivo_start",
            ActionParamStrA = TrimPath(12) + "aivo"
        });
        transitionDLG.StartingList.Add(new AuroraDLG.AStarting()
        {
            structid = 0,
            Index = 0
        });

        return transitionDLG;
    }

    void LoadFile ()
    {
        loadLoc = EditorUtility.OpenFilePanel("Load LIP file", "", "");
        using (FileStream stream = new FileStream(loadLoc, FileMode.Open))
        {
            dlg = (AuroraDLG)new GFFLoader(stream).GetObject().Serialize<AuroraDLG>();
        }
    }

    void SaveFile ()
    {
        ConvertDLG();
        AuroraDLG transitionDLG = CreateTransitionDLG();
        //string transitionNSS = GenerateScript();

        string saveLoc = EditorUtility.SaveFolderPanel("Choose Output Folder", "", "");

        string filename = Path.GetFileNameWithoutExtension(loadLoc);
        string ext = Path.GetExtension(loadLoc);

        string new_filename = TrimPath(12) + "aivo";

        KModuleEditor.CreateGFFFile(saveLoc + "\\", new_filename, dlg, "dlg");
        KModuleEditor.CreateGFFFile(saveLoc + "\\", filename, transitionDLG, "dlg");
        //File.WriteAllText(saveLoc + "\\" + filename + "_s.nss", transitionNSS);
    }
}