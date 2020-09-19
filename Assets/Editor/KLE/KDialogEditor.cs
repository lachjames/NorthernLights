using AuroraEngine;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEditor;
using UnityEngine;

public class KDialogEditor : EditorWindow
{
    enum DialogState
    {
        STARTING, CHOOSING_ENTRY, CHOOSING_REPLY
    }

    public AuroraDLG dlg = null;

    AuroraDLG.AEntry curEntry;
    AuroraDLG.AReply curReply;

    AuroraStruct curEditing, curEditingLink;

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

    public void LoadDLG (AuroraDLG dlg)
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

        }
    }

    void Editor ()
    {
        using (new EditorGUILayout.HorizontalScope())
        {
            LeftSidebar();
            DialogViewer();
            RightSidebar();
        }
    }

    void LeftSidebar ()
    {
        using (new EditorGUILayout.VerticalScope(GUILayout.Width(300)))
        {
            if (GUILayout.Button("Back to start"))
                Debug.Log("Back to start");
            if (GUILayout.Button("New Response"))
                Debug.Log("New Response");
            if (GUILayout.Button("Unlink response"))
                Debug.Log("Unlink response");
            if (GUILayout.Button("Copy selected"))
                Debug.Log("Copy selected");
            if (GUILayout.Button("Paste into start"))
                Debug.Log("Paste into start");
            if (GUILayout.Button("Move selected up"))
                Debug.Log("Move selected up");
            if (GUILayout.Button("Move selected down"))
                Debug.Log("Move selected down");

            // Debug information, for now
            if (curEntry != null)
                GUILayout.Label("Entry: " + curEntry.ToString());

            if (curReply != null)
                GUILayout.Label("Reply: " + curReply.ToString());

            using (var scroll = new EditorGUILayout.ScrollViewScope(leftScroll)) {
                leftScroll = scroll.scrollPosition;

                // Show the inspector for the currently selected link
                if (curEditingLink != null)
                    GFFEditor.DrawStruct(curEditingLink);
            }
        }
    }

    void DialogViewer ()
    {
        GUISkin old = GUI.skin;
        GUI.skin = new GUISkin();
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
    
    void EntryView ()
    {
        switch (mode)
        {
            case DialogState.STARTING:
                // Show the list of starting nodes
                foreach (AuroraDLG.AStarting start in dlg.StartingList)
                {
                    AuroraDLG.AEntry entry = GetEntry((int)start.Index);
                    string startLine = AuroraEngine.Resources.GetString((int)entry.Text.stringref);
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
                string line = AuroraEngine.Resources.GetString((int)curEntry.Text.stringref);
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
                    string linkLine = AuroraEngine.Resources.GetString((int)entry.Text.stringref);
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
                    string line = AuroraEngine.Resources.GetString((int)reply.Text.stringref);
                    if (GUILayout.Button(line))
                    {
                        if (Event.current.button == 1)
                        {
                            SelectedEntryReply(link);
                            SelectedReply(reply);
                        } else
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


    void NavigateFromStart (AuroraDLG.AStarting start)
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

    void SelectedStart (AuroraDLG.AStarting start)
    {
        curEditingLink = start;
    }

    void SelectedEntry (AuroraDLG.AEntry entry)
    {
        // The user selected an entry, so show all relevant replies
        curEditing = entry;
    }

    void SelectedReply (AuroraDLG.AReply reply)
    {
        // The user selected a reply, so show all relevant entries
        curEditing = reply;
    }

    void SelectedEntryReply (AuroraDLG.AEntry.AReplies entryReply)
    {
        curEditingLink = entryReply;
    }

    void SelectedReplyEntry (AuroraDLG.AReply.AEntries replyEntry)
    {
        curEditingLink = replyEntry;
    }

    void RightSidebar ()
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
