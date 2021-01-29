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

public class KTriggerEditor : EditorWindow
{
    AuroraGIT.ATrigger selected;

    Vector2 editorScroll;
    int selectedTrigger = 0;

    List<AuroraGIT.ATrigger> triggers = null;

    GameObject editorParent;

    [MenuItem("KotOR/Trigger Editor")]
    public static void ShowWindow()
    {
        GetWindow<KTriggerEditor>(false, "Trigger Editor", true);
    }

    public void OnGUI()
    {
        UpdateTriggers();
        using (new EditorGUILayout.VerticalScope())
        {
            Menu();
            Editor();
        }
    }

    void UpdateTriggers ()
    {
        // A list of triggers can be found in the GIT file
        triggers = AuroraEngine.Resources.data.module.git.TriggerList;
        foreach (var trigger in triggers)
        {
            foreach (var geom in trigger.Geometry)
            {
                geom.structid = 3;
            }
        }

        // Create the editor parent if it doesn't exist
        if (editorParent == null)
        {
            if (editorParent = GameObject.Find("Trigger Editor"))
            {

            }
            else
            {
                editorParent = new GameObject();
                editorParent.name = "Trigger Editor";
            }
        }
    }

    void Menu()
    {
        using (new EditorGUILayout.VerticalScope())
        {
            // List triggers
            List<string> triggerNames = new List<string>();
            foreach (AuroraGIT.ATrigger trigger in triggers)
            {
                if (trigger.Tag == "")
                {
                    triggerNames.Add(trigger.TemplateResRef + " (resref)");
                } else
                {
                    triggerNames.Add(trigger.Tag);
                }
            }
            selectedTrigger = EditorGUILayout.Popup(selectedTrigger, triggerNames.ToArray());
            selected = triggers[selectedTrigger];

            // Buttons
            if (GUILayout.Button("Edit Geometry"))
            {
                BeginEditGeometry();
            }
        }
    }

    void BeginEditGeometry ()
    {
        // Delete all children of editorParent
        foreach (Transform child in editorParent.transform)
        {
            DestroyImmediate(child.gameObject);
        }

        editorParent.transform.position = new Vector3(
            selected.XPosition,
            selected.ZPosition,
            selected.YPosition
        );

        // Create new children, one for each node in the trigger's geometry
        int i = 0;
        foreach (AuroraGIT.ATrigger.AGeometry geom in selected.Geometry)
        {
            GameObject point = new GameObject();
            point.name = "TriggerPoint_" + i;
            point.transform.SetParent(editorParent.transform);

            point.transform.localPosition = new Vector3(
                geom.PointX,
                geom.PointZ,
                geom.PointY
            );

            point.AddComponent<AuroraTriggerPoint>().geometry = geom;

            i++;
        }
    }

    void Editor()
    {
        if (selected != null)
        {
            DrawEditor();
        }
    }

    void DrawEditor()
    {
        // Draw the GFF editor for the selected item
        using (new EditorGUILayout.VerticalScope())
        {
            using (var scroll = new EditorGUILayout.ScrollViewScope(editorScroll))
            {
                editorScroll = scroll.scrollPosition;
                GFFEditor.DrawStruct(selected);
            }
        }
    }
}
