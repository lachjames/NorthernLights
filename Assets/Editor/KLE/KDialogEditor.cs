using AuroraEngine;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEditor;
using UnityEngine;
using XNode;
using XNodeEditor;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public class KDialogEditor : EditorWindow
{
    enum DialogState
    {
        STARTING, CHOOSING_ENTRY, CHOOSING_REPLY
    }

    public AuroraDLG dlg = null;

    AuroraDLG.AEntry curEntry;
    AuroraDLG.AReply curReply;

    AuroraStruct curEditing, curEditingLink, curCopied;

    AuroraDLG.AEntry.AReplies curEntryReplyLink;
    AuroraDLG.AReply.AEntries curReplyEntryLink;

    DialogState mode;

    Vector2 leftScroll, rightScroll, entryScroll, replyScroll;

    [MenuItem("KotOR/Dialog Editor")]
    public static void ShowWindow()
    {
        GetWindow<KDialogEditor>(false, "Dialog Editor", true);
    }

    public void OnGUI()
    {
        using (new EditorGUILayout.VerticalScope())
        {
            Menu();
            if (dlg != null)
            {
                Editor();
            }
        }
    }

    public void LoadDLGFromFile()
    {
        // Ask for a filename
        string filename = EditorUtility.OpenFilePanel("Select a DLG file", "", "");
        using (FileStream fs = new FileStream(filename, FileMode.Open))
        {
            AuroraDLG dlg = (AuroraDLG)new GFFLoader(fs).GetObject().Serialize<AuroraDLG>();
            LoadDLG(dlg);
        }
    }

    public void SaveDLGToFile()
    {
        string filename = EditorUtility.SaveFilePanel("Save File As...", "", "dialog.dlg", "");
        KModuleEditor.CreateGFFFile(AuroraPrefs.GetModuleOutLocation(), "dialog", dlg, "dlg");
        File.Move(AuroraPrefs.GetModuleOutLocation() + "/dialog.dlg", filename);
    }

    void ExportPCLines()
    {
        string outloc = EditorUtility.SaveFilePanel("Save File As...", "", "pc.json", "");

        List<object> lines = new List<object>();
        HashSet<string> seen = new HashSet<string>();
        foreach (AuroraDLG.AReply reply in dlg.ReplyList)
        {
            // Get the text for this line
            string text = AuroraEngine.Resources.GetString(reply.Text);
            string baseText = text;

            if (seen.Contains(text))
            {
                continue;
            }
            seen.Add(text);

            Debug.Log(text);
            if (text == "")
            {
                continue;
            }

            // Remove all text between '[' and ']' from the text
            while (text.Contains("["))
            {
                int start = text.IndexOf("[");
                int end = text.IndexOf("]");
                text = text.Remove(start, end - start + 1);
            }

            // Remove all text between '{ and '}'
            while (text.Contains("{"))
            {
                int start = text.IndexOf("{");
                int end = text.IndexOf("}");
                text = text.Remove(start, end - start + 1);
            }

            if (text.Trim() == "") {
                continue;
            }

            lines.Add(new
            {
                speaker = "femshep/checkpoint_21934",
                text = text.Trim(),
                audio_data = "",
                metadata = new {
                    tlk_idx = reply.Text.stringref,
                    base_text = baseText,
                    follow_on = false
                }
            });
        }

        string json = JsonConvert.SerializeObject(lines, Formatting.Indented);
        File.WriteAllText(outloc, json);
    }

    public void LoadDLG(AuroraDLG dlg)
    {
        curEntry = null;
        curReply = null;

        this.dlg = dlg;
        mode = DialogState.STARTING;
    }

    void Menu()
    {
        using (new EditorGUILayout.HorizontalScope())
        {
            if (GUILayout.Button("Load From File"))
            {
                LoadDLGFromFile();
            }
            if (GUILayout.Button("Save To File"))
            {
                SaveDLGToFile();
            }
            if (GUILayout.Button("Node View"))
            {
                DialogGraph dg = new DialogGraph();
                dg.LoadDLG(dlg);
                Debug.Log(dg);
                NodeEditorWindow.Open(dg);
            }
            if (GUILayout.Button("Export JSON"))
            {
                ExportPCLines();
            }
        }
    }

    void Editor()
    {
        using (new EditorGUILayout.HorizontalScope())
        {
            LeftSidebar();
            DialogViewer();
            RightSidebar();
        }
    }

    void LeftSidebar()
    {
        using (new EditorGUILayout.VerticalScope(GUILayout.Width(300)))
        {
            if (GUILayout.Button("Back to start"))
                BackToStart();
            if (GUILayout.Button("New Response"))
                NewResponse();
            if (GUILayout.Button("Unlink response"))
                UnlinkResponse();
            if (GUILayout.Button("Copy selected"))
                CopySelected();
            if (GUILayout.Button("Paste into selected"))
                PasteIntoSelected();
            if (GUILayout.Button("Move selected up"))
                MoveSelectedUp();
            if (GUILayout.Button("Move selected down"))
                MoveSelectedDown();

            // Debug information, for now
            if (curEntry != null)
                GUILayout.Label("Entry: " + curEntry.ToString());

            if (curReply != null)
                GUILayout.Label("Reply: " + curReply.ToString());

            using (var scroll = new EditorGUILayout.ScrollViewScope(leftScroll))
            {
                leftScroll = scroll.scrollPosition;

                // Show the inspector for the currently selected link
                if (curEditingLink != null)
                    GFFEditor.DrawStruct(curEditingLink);
            }
        }
    }

    void BackToStart()
    {
        curEntry = null;
        curReply = null;
        mode = DialogState.STARTING;
    }

    void NewResponse()
    {
        int idx;
        switch (mode)
        {
            case DialogState.STARTING:
                // Create a new starting node, and a corresponding entry
                idx = dlg.EntryList.Count;
                dlg.EntryList.Add(new AuroraDLG.AEntry()
                {
                    structid = (uint)idx
                });

                dlg.StartingList.Add(new AuroraDLG.AStarting()
                {
                    Index = (uint)idx
                });
                break;
            case DialogState.CHOOSING_ENTRY:
                idx = dlg.EntryList.Count;
                dlg.EntryList.Add(new AuroraDLG.AEntry()
                {
                    structid = (uint)idx
                });
                curReply.EntriesList.Add(new AuroraDLG.AReply.AEntries()
                {
                    Index = (uint)idx
                });
                break;
            case DialogState.CHOOSING_REPLY:
                idx = dlg.ReplyList.Count;
                dlg.ReplyList.Add(new AuroraDLG.AReply()
                {
                    structid = (uint)idx
                });
                curEntry.RepliesList.Add(new AuroraDLG.AEntry.AReplies()
                {
                    Index = (uint)idx
                });
                break;
        }
    }

    void UnlinkResponse()
    {
        switch (mode)
        {
            case DialogState.STARTING:
                // Create a new starting entry
                dlg.StartingList.Remove((AuroraDLG.AStarting)curEditingLink);
                break;
            case DialogState.CHOOSING_ENTRY:
                curReply.EntriesList.Remove((AuroraDLG.AReply.AEntries)curEditingLink);
                break;
            case DialogState.CHOOSING_REPLY:
                curEntry.RepliesList.Remove((AuroraDLG.AEntry.AReplies)curEditingLink);
                break;
        }
    }

    void CopySelected()
    {
        switch (mode)
        {
            case DialogState.STARTING:
                curCopied = (AuroraDLG.AStarting)curEditingLink;
                break;
            case DialogState.CHOOSING_ENTRY:
                curCopied = (AuroraDLG.AReply.AEntries)curEditingLink;
                break;
            case DialogState.CHOOSING_REPLY:
                curCopied = (AuroraDLG.AEntry.AReplies)curEditingLink;
                break;
        }
    }

    void PasteIntoSelected()
    {
        switch (mode)
        {
            case DialogState.STARTING:
                dlg.StartingList.Add((AuroraDLG.AStarting)curEditingLink.DeepCopy());
                break;
            case DialogState.CHOOSING_ENTRY:
                curReply.EntriesList.Add((AuroraDLG.AReply.AEntries)curEditingLink.DeepCopy());
                break;
            case DialogState.CHOOSING_REPLY:
                curEntry.RepliesList.Add((AuroraDLG.AEntry.AReplies)curEditingLink.DeepCopy());
                break;
        }
    }

    void MoveSelectedDown()
    {
        switch (mode)
        {
            case DialogState.STARTING:
                int selectedIdx = dlg.StartingList.IndexOf((AuroraDLG.AStarting)curEditingLink);
                if (selectedIdx < dlg.StartingList.Count - 1)
                {
                    dlg.StartingList.RemoveAt(selectedIdx);
                    dlg.StartingList.Insert(selectedIdx + 1, (AuroraDLG.AStarting)curEditingLink);
                }
                break;
            case DialogState.CHOOSING_ENTRY:
                int entryIdx = curReply.EntriesList.IndexOf((AuroraDLG.AReply.AEntries)curEditingLink);
                if (entryIdx < dlg.EntryList.Count - 1)
                {
                    curReply.EntriesList.RemoveAt(entryIdx);
                    curReply.EntriesList.Insert(entryIdx + 1, (AuroraDLG.AReply.AEntries)curEditingLink);
                }
                break;
            case DialogState.CHOOSING_REPLY:
                int replyIdx = curEntry.RepliesList.IndexOf((AuroraDLG.AEntry.AReplies)curEditingLink);
                if (replyIdx < dlg.ReplyList.Count - 1)
                {
                    curEntry.RepliesList.RemoveAt(replyIdx);
                    curEntry.RepliesList.Insert(replyIdx + 1, (AuroraDLG.AEntry.AReplies)curEditingLink);
                }
                break;
        }
    }

    void MoveSelectedUp()
    {
        switch (mode)
        {
            case DialogState.STARTING:
                int selectedIdx = dlg.StartingList.IndexOf((AuroraDLG.AStarting)curEditingLink);
                if (selectedIdx > 0)
                {
                    dlg.StartingList.RemoveAt(selectedIdx);
                    dlg.StartingList.Insert(selectedIdx - 1, (AuroraDLG.AStarting)curEditingLink);
                }
                break;
            case DialogState.CHOOSING_ENTRY:
                int entryIdx = curReply.EntriesList.IndexOf((AuroraDLG.AReply.AEntries)curEditingLink);
                if (entryIdx > 0)
                {
                    curReply.EntriesList.RemoveAt(entryIdx);
                    curReply.EntriesList.Insert(entryIdx - 1, (AuroraDLG.AReply.AEntries)curEditingLink);
                }
                break;
            case DialogState.CHOOSING_REPLY:
                int replyIdx = curEntry.RepliesList.IndexOf((AuroraDLG.AEntry.AReplies)curEditingLink);
                if (replyIdx > 0)
                {
                    curEntry.RepliesList.RemoveAt(replyIdx);
                    curEntry.RepliesList.Insert(replyIdx - 1, (AuroraDLG.AEntry.AReplies)curEditingLink);
                }
                break;
        }
    }

    void DialogViewer()
    {
        GUISkin old = GUI.skin;
        GUI.skin = (GUISkin)CreateInstance("GUISkin");
        GUI.skin.button.fontSize = 24;
        GUI.skin.button.normal.textColor = new Color32(0x00, 0xA4, 0xF4, 0xFF);
        GUI.skin.button.hover.textColor = new Color32(0xF4, 0xF9, 0x00, 0xFF);
        GUI.skin.button.wordWrap = true;

        GUI.skin.label.fontSize = 24;
        GUI.skin.label.normal.textColor = new Color32(0x00, 0xA4, 0xF4, 0xFF);
        GUI.skin.label.hover.textColor = new Color32(0xF4, 0xF9, 0x00, 0xFF);
        GUI.skin.label.wordWrap = true;

        GUI.skin.label.alignment = TextAnchor.MiddleCenter;

        using (new EditorGUILayout.VerticalScope())
        {
            using (var entryScope = new EditorGUILayout.ScrollViewScope(entryScroll))
            {
                entryScroll = entryScope.scrollPosition;
                EntryView();
            }
            using (var replyScope = new EditorGUILayout.ScrollViewScope(replyScroll))
            {
                replyScroll = replyScope.scrollPosition;
                ReplyView();
            }
        }

        GUI.skin = old;
    }

    void EntryView()
    {
        switch (mode)
        {
            case DialogState.STARTING:
                // Show the list of starting nodes
                foreach (AuroraDLG.AStarting start in dlg.StartingList)
                {
                    AuroraDLG.AEntry entry = GetEntry((int)start.Index);
                    string startLine = "null";
                    startLine = AuroraEngine.Resources.GetString(entry.Text);
                    if (GUILayout.Button(startLine))
                    {
                        if (Event.current.button == 1)
                        {
                            SelectedStart(start);
                        }
                        else
                        {
                            NavigateFromStart(start);
                        }
                    }
                }
                break;
            case DialogState.CHOOSING_REPLY:
                // Show the last line of dialog said by the PC
                string line = AuroraEngine.Resources.GetString(curEntry.Text);
                GUILayout.Label(line);
                break;
            case DialogState.CHOOSING_ENTRY:
                // The player is choosing their dialog option
                // Show the list of replies to the current entry
                if (curReply == null)
                    return;

                foreach (AuroraDLG.AReply.AEntries link in curReply.EntriesList)
                {
                    AuroraDLG.AEntry entry = GetEntry((int)link.Index);
                    string linkLine = AuroraEngine.Resources.GetString(entry.Text);
                    if (GUILayout.Button(linkLine))
                    {
                        if (Event.current.button == 1)
                        {
                            SelectedReplyEntry(link);
                            SelectedEntry(entry);
                        }
                        else
                        {
                            ToChooseReply(link);
                        }
                    }
                }
                break;
        }
    }

    void ReplyView()
    {
        switch (mode)
        {
            case DialogState.STARTING:
                break;
            case DialogState.CHOOSING_REPLY:
                // Show the list of entries for the current reply
                if (curEntry == null)
                    return;

                foreach (AuroraDLG.AEntry.AReplies link in curEntry.RepliesList)
                {
                    AuroraDLG.AReply reply = GetReply((int)link.Index);
                    string line = AuroraEngine.Resources.GetString(reply.Text);
                    if (GUILayout.Button(line))
                    {
                        if (Event.current.button == 1)
                        {
                            SelectedEntryReply(link);
                            SelectedReply(reply);
                        }
                        else
                        {
                            ToChooseEntry(link);
                        }
                    }
                }
                break;
            case DialogState.CHOOSING_ENTRY:
                // Show the last line of dialog spoken by the NPC
                break;
        }
    }
    AuroraDLG.AEntry GetEntry(int idx)
    {
        foreach (AuroraDLG.AEntry entry in dlg.EntryList)
        {
            if (entry.structid == idx)
            {
                return entry;
            }
        }

        return null;
    }
    AuroraDLG.AReply GetReply(int idx)
    {
        foreach (AuroraDLG.AReply reply in dlg.ReplyList)
        {
            if (reply.structid == idx)
            {
                return reply;
            }
        }

        return null;
    }


    void NavigateFromStart(AuroraDLG.AStarting start)
    {
        Debug.Log("Navigating from start");
        // Find the entry this start points to
        curEntry = GetEntry((int)start.Index);
        mode = DialogState.CHOOSING_REPLY;
    }

    void ToChooseEntry(AuroraDLG.AEntry.AReplies entryReply)
    {
        Debug.Log("Navigating from entry");
        curReply = GetReply((int)entryReply.Index);
        mode = DialogState.CHOOSING_ENTRY;
    }

    void ToChooseReply(AuroraDLG.AReply.AEntries replyEntry)
    {
        Debug.Log("Navigating from reply");
        curEntry = GetEntry((int)replyEntry.Index);
        curReply = null;
        mode = DialogState.CHOOSING_REPLY;
    }

    void SelectedStart(AuroraDLG.AStarting start)
    {
        curEditingLink = start;
        curEditing = GetEntry((int)start.Index);
    }

    void SelectedEntry(AuroraDLG.AEntry entry)
    {
        // The user selected an entry, so show all relevant replies
        curEditing = entry;
    }

    void SelectedReply(AuroraDLG.AReply reply)
    {
        // The user selected a reply, so show all relevant entries
        curEditing = reply;
    }

    void SelectedEntryReply(AuroraDLG.AEntry.AReplies entryReply)
    {
        curEditingLink = entryReply;
    }

    void SelectedReplyEntry(AuroraDLG.AReply.AEntries replyEntry)
    {
        curEditingLink = replyEntry;
    }

    void RightSidebar()
    {
        using (new EditorGUILayout.VerticalScope(GUILayout.Width(300)))
        {
            using (var scroll = new EditorGUILayout.ScrollViewScope(rightScroll))
            {
                rightScroll = scroll.scrollPosition;

                // Show the inspector for the currently selected entry/reply
                if (curEditingLink != null)
                    GFFEditor.DrawStruct(curEditing);
            }
        }
    }
}
