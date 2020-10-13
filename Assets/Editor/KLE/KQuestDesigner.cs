using AuroraEngine;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class KQuestDesigner : EditorWindow
{
    int tab;

    AuroraQuest quest = null;

    [MenuItem("KotOR/Quest Designer")]
    public static void ShowWindow()
    {
        GetWindow<KQuestDesigner>(false, "Quest Designer", true);
    }

    public void OnGUI()
    {
        using (new EditorGUILayout.VerticalScope())
        {
            using (new EditorGUILayout.HorizontalScope())
            {
                if (GUILayout.Button("New Quest"))
                {
                    quest = new AuroraQuest();
                }

                if (GUILayout.Button("Load Quest"))
                {

                }
            }
            tab = GUILayout.Toolbar(tab, new string[] { "Structure", "Edit", "Generate" });

            if (quest != null)
            {

            }
            switch(tab)
            {
                case 0:
                    StructureWindow();
                    break;
                case 1:
                    EditWindow();
                    break;
                case 2:
                    GenerateWindow();
                    break;
            }
        }
    }

    void StructureWindow ()
    {
        using (new EditorGUILayout.HorizontalScope())
        {
            // Menu
            using (new EditorGUILayout.VerticalScope(GUILayout.Width(200)))
            {
                if (GUILayout.Button("New Phase"))
                {
                    quest.phases.Add(new AuroraQuestPhase());
                }
            }

            // Phase list
            foreach (AuroraQuestPhase phase in quest.phases)
            {
                
            }
        }
    }

    void EditWindow ()
    {

    }

    void GenerateWindow ()
    {

    }
}

public class AuroraQuest
{
    public string questName;
    public List<AuroraQuestPhase> phases;
}

public class AuroraQuestPhase
{
    public enum PhaseTask
    {
        TriggerDialog, KillNPC, GetItem, ProtectNPC, Survival, Deliver
    }

    public enum LinkType
    {
        DialogLine, KilledNPC, LootedItem
    }

    public AuroraQuest quest;

    public string journalEntry;
    public PhaseTask phaseTask;

    public Dictionary<AuroraQuestPhase, LinkType> phaseLinks;

    public string OnPhaseStartScript (string questName, int phaseNum)
    {
        // Generates a script that should trigger when the phase starts
        string script = String.Format(@"
void main () {
    SetLocalInt(GetFirstPC(), i{0}, {1});
}", questName, phaseNum);
 
        return script;
    }
}