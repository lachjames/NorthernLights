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

public class KTemplateEditor : EditorWindow
{
    string ext = "";

    int tab;

    KItemPicker.ItemType templateType;
    string templateName;

    Vector2 itemScroll, editorScroll;

    AuroraStruct selected;
    ResourceType selectedResourceType;
    string selectedName;

    List<(string, AuroraStruct, KItemPicker.ItemType)> newTemplates = new List<(string, AuroraStruct, KItemPicker.ItemType)>();
    List<(string, AuroraStruct, ResourceType)> editedTemplates = new List<(string, AuroraStruct, ResourceType)>();

    [MenuItem("KotOR/Template Editor")]
    public static void ShowWindow()
    {
        GetWindow<KTemplateEditor>(false, "Module Editor", true);
    }

    public void OnGUI()
    {
        using (new EditorGUILayout.VerticalScope())
        {
            Menu();
            Editor();
        }
    }

    void Menu()
    {
        using (new EditorGUILayout.VerticalScope())
        {
            // First row
            using (new EditorGUILayout.HorizontalScope())
            {
                if (GUILayout.Button("Load Template"))
                {
                    LoadTemplate();
                }
                if (GUILayout.Button("Save Template"))
                {
                    SaveTemplate();
                }
            }
        }
    }

    void LoadTemplate ()
    {
        string filename = EditorUtility.OpenFilePanel("Select a DLG file", "", "");
        ext = filename.Split('.').Last();

        using (FileStream fs = new FileStream(filename, FileMode.Open))
        {
            selected = LoadStruct(fs, ext);
        }
    }

    AuroraStruct LoadStruct (Stream stream, string ext)
    {
        AuroraStruct auroraStruct;
        GFFObject obj = new GFFLoader(stream).GetObject();
        switch (ext.ToLower())
        {
            case "utc":
                auroraStruct = (AuroraUTC)obj.Serialize<AuroraUTC>();
                break;
            case "utd":
                auroraStruct = (AuroraUTD)obj.Serialize<AuroraUTD>();
                break;
            case "utp":
                auroraStruct = (AuroraUTP)obj.Serialize<AuroraUTP>();
                break;
            case "utt":
                auroraStruct = (AuroraUTT)obj.Serialize<AuroraUTT>();
                break;
            case "ute":
                auroraStruct = (AuroraUTE)obj.Serialize<AuroraUTE>();
                break;
            case "uts":
                auroraStruct = (AuroraUTS)obj.Serialize<AuroraUTS>();
                break;
            case "utm":
                auroraStruct = (AuroraUTM)obj.Serialize<AuroraUTM>();
                break;
            case "utw":
                auroraStruct = (AuroraUTW)obj.Serialize<AuroraUTW>();
                break;
            case "dlg":
                auroraStruct = (AuroraDLG)obj.Serialize<AuroraDLG>();
                break;
            case "git":
                auroraStruct = (AuroraGIT)obj.Serialize<AuroraGIT>();
                break;
            case "are":
                auroraStruct = (AuroraARE)obj.Serialize<AuroraARE>();
                break;
            case "ifo":
                auroraStruct = (AuroraIFO)obj.Serialize<AuroraIFO>();
                break;
            case "pth":
                auroraStruct = (AuroraPTH)obj.Serialize<AuroraPTH>();
                break;
            default:
                throw new Exception("Invalid object with resource type " + ext + " selected");
        }
        return auroraStruct;
    }

    void SaveTemplate ()
    {
        string filename = EditorUtility.SaveFilePanel("Save File As...", "", "template." + ext, "");
        KModuleEditor.CreateGFFFile(AuroraPrefs.GetModuleOutLocation(), "template", selected, ext);
        File.Move(AuroraPrefs.GetModuleOutLocation() + "/template." + ext, filename);
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
    public static void CreateGFFFile(string folder, string name, AuroraStruct template, string ext)
    {
        // Create an XML file for the GFF template
        string xmlpath = folder + "tmp.xml";
        string xml = template.ToXML(ext.ToUpper());
        Debug.Log(name + ":\n" + xml);
        File.WriteAllText(xmlpath, xml);
        File.WriteAllText(Application.dataPath + "\\out.xml", xml);

        // Convert from XML to GFF using xoreos-tools
        string filename = name + "." + ext;
        string fullpath = folder + filename;

        AuroraEngine.Resources.RunXoreosTools(
            xmlpath + " " + fullpath,
            "xml2gff",
            AuroraPrefs.TargetGame() == Game.KotOR ? "--kotor" : "--kotor2"
        );

        // Delete the temporary XML file
        UnityEngine.Windows.File.Delete(folder + "tmp.xml");
    }
}
