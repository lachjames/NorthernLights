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

public class KModuleEditor : EditorWindow
{
    string moduleName;
    string modulePath;
    RIMObject rim, srim;
    ERFObject dlg, mod;

    object currentItem;

    int tab;

    KItemPicker.ItemType templateType;
    string templateName;

    Vector2 itemScroll, editorScroll;

    AuroraStruct selected;
    string selectedName;

    List<(string, AuroraStruct, KItemPicker.ItemType)> newTemplates = new List<(string, AuroraStruct, KItemPicker.ItemType)>();

    [MenuItem("KotOR/Module Editor")]
    public static void ShowWindow()
    {
        GetWindow<KModuleEditor>(false, "Module Editor", true);
    }

    public void OnGUI()
    {
        using (new EditorGUILayout.VerticalScope())
        {
            Menu();
            if (rim != null)
            {
                Editor();
            }
        }
    }

    void Menu()
    {
        using (new EditorGUILayout.VerticalScope())
        {
            // First row
            using (new EditorGUILayout.HorizontalScope())
            {
                if (GUILayout.Button("Reset"))
                {
                    Reset();
                }
                if (GUILayout.Button("Load Module"))
                {
                    LoadModule();
                }
                if (GUILayout.Button("Save Module"))
                {
                    SaveModule();
                }

                GUILayout.Space(5);

                if (GUILayout.Button("Import Model"))
                {
                    ImportModel();
                }

                if (GUILayout.Button("Import Script"))
                {
                    ImportScript();
                }

                if (GUILayout.Button("Import Dialogue"))
                {
                    ImportDialogue();
                }

                if (GUILayout.Button("Import Template"))
                {
                    ImportGFF();
                }
            }

            // Second row
            using (new EditorGUILayout.HorizontalScope())
            {
                templateType = (KItemPicker.ItemType)EditorGUILayout.Popup((int)templateType, Enum.GetNames(typeof(KItemPicker.ItemType)));
                templateName = EditorGUILayout.TextField(templateName);

                if (GUILayout.Button("Create Template"))
                {
                    CreateGFF();
                }

                if (GUILayout.Button("Duplicate Current Template"))
                {
                    DuplicateTemplate();
                }

                if (GUILayout.Button("Delete Current Template"))
                {
                    DeleteTemplate();
                }
            }
        }
    }

    void Editor()
    {
        EditorGUILayout.LabelField("Editing module " + moduleName);
        using (new EditorGUILayout.HorizontalScope())
        {
            using (new EditorGUILayout.VerticalScope(GUILayout.Width(200)))
            {
                ModuleItemSelection();
            }

            if (selected != null)
            {
                DrawEditor();
            }
        }
    }

    void ModuleItemSelection()
    {
        tab = GUILayout.Toolbar(tab, new string[] {
            "Templates",
            "Scripts",
            "Dialogues"
        });
        switch (tab)
        {
            case 0:
                ItemSelection(new ResourceType[]
                {
                    ResourceType.CAM, ResourceType.UTC, ResourceType.UTD,
                    ResourceType.UTP, ResourceType.UTT, ResourceType.UTE,
                    ResourceType.UTS, ResourceType.UTM, ResourceType.UTW,

                });
                break;
            case 1:
                ItemSelection(new ResourceType[]
                {
                    ResourceType.NCS
                });
                break;
            case 2:
                ItemSelection(new ResourceType[]
                {
                    ResourceType.DLG
                });
                break;
        }
    }

    void ItemSelection(ResourceType[] types)
    {
        using (var scroll = new EditorGUILayout.ScrollViewScope(itemScroll))
        {
            itemScroll = scroll.scrollPosition;

            // Get all items that we've added
            foreach ((string name, AuroraStruct str, KItemPicker.ItemType it) in newTemplates)
            {
                ResourceType rt = KItemPicker.TypeMap[it];
                if (GUILayout.Button(name + " (" + rt + ")"))
                {
                    selected = str;
                }
            }

            // Get all items in the rim
            foreach ((string name, ResourceType rt) in rim.resources.Keys)
            {
                if (!types.Contains(rt))
                {
                    continue;
                }

                if (GUILayout.Button(name + " (" + rt + ")"))
                {
                    RIMObject.Resource resource = rim.resources[(name, rt)];
                    Stream stream = rim.GetResource(resource.ResRef, resource.ResType);
                    SelectedItem(stream, resource.ResType);
                }
            }

            // Get all items in the s_rim
            foreach ((string name, ResourceType rt) in srim.resources.Keys)
            {
                if (!types.Contains(rt))
                {
                    continue;
                }

                Color col = GUI.color;

                if (name != "" && name == selectedName)
                {
                    GUI.color = Color.green;
                }

                if (GUILayout.Button(name + " (" + rt + ")"))
                {
                    if (rt == ResourceType.DLG)
                    {
                        RIMObject.Resource resource = srim.resources[(name, rt)];
                        Stream stream = srim.GetResource(resource.ResRef, resource.ResType);
                        AuroraDLG selectedDLG = (AuroraDLG)new GFFLoader(stream).GetObject().Serialize<AuroraDLG>();
                        GetWindow<KDialogEditor>(false, "Dialog Editor", true).LoadDLG(selectedDLG);
                    }
                    else if (rt == ResourceType.NCS)
                    {
                        Debug.LogWarning("Please edit NCS files using their respective editors");
                    }
                    else
                    {
                        RIMObject.Resource resource = srim.resources[(name, rt)];
                        Stream stream = srim.GetResource(resource.ResRef, resource.ResType);
                        SelectedItem(stream, resource.ResType);
                        selectedName = name;
                    }
                }

                GUI.color = col;
            }

            if (AuroraPrefs.TargetGame() == Game.KotOR)
            {
                return;
            }

            // Get all items in the MOD

            // Get all items in the erf
            foreach ((string name, ResourceType rt) in dlg.resourceKeys.Keys)
            {
                if (!types.Contains(rt))
                {
                    continue;
                }

                Color col = GUI.color;

                if (name != "" && name == selectedName)
                {
                    GUI.color = Color.green;
                }

                if (GUILayout.Button(name + " (" + rt + ")"))
                {
                    if (rt == ResourceType.DLG)
                    {
                        Stream stream = dlg.GetResource(name, rt);
                        AuroraDLG selectedDLG = (AuroraDLG)new GFFLoader(stream).GetObject().Serialize<AuroraDLG>();
                        GetWindow<KDialogEditor>(false, "Dialog Editor", true).LoadDLG(selectedDLG);
                    }
                    else if (rt == ResourceType.NCS)
                    {
                        Debug.LogWarning("Please edit NCS files using their respective editors");
                    }
                    else
                    {
                        Stream stream = dlg.GetResource(name, rt);
                        SelectedItem(stream, rt);
                        selectedName = name;
                    }
                }

                GUI.color = col;
            }
        }
    }

    void SelectedItem(Stream stream, ResourceType rt)
    {
        if (rt == ResourceType.NCS)
        {
            // This is an NCS script
            return;
        }
        else if (rt == ResourceType.CAM)
        {
            // This is a camera
            return;
        }

        // If we reach this point, we assume the object is in GFF format

        GFFObject obj = new GFFLoader(stream).GetObject();
        switch (rt)
        {
            case ResourceType.UTC:
                selected = (AuroraUTC)obj.Serialize<AuroraUTC>();
                break;
            case ResourceType.UTD:
                selected = (AuroraUTD)obj.Serialize<AuroraUTD>();
                break;
            case ResourceType.UTP:
                selected = (AuroraUTP)obj.Serialize<AuroraUTP>();
                break;
            case ResourceType.UTT:
                selected = (AuroraUTT)obj.Serialize<AuroraUTT>();
                break;
            case ResourceType.UTE:
                selected = (AuroraUTE)obj.Serialize<AuroraUTE>();
                break;
            case ResourceType.UTS:
                selected = (AuroraUTS)obj.Serialize<AuroraUTS>();
                break;
            case ResourceType.UTM:
                selected = (AuroraUTM)obj.Serialize<AuroraUTM>();
                break;
            case ResourceType.UTW:
                selected = (AuroraUTW)obj.Serialize<AuroraUTW>();
                break;
            case ResourceType.DLG:
                selected = (AuroraDLG)obj.Serialize<AuroraDLG>();
                break;
            default:
                throw new Exception("Invalid object with resource type " + rt + " selected");
        }
    }

    void DrawEditor()
    {
        // Draw the GFF editor for the selected item
        using (var scroll = new EditorGUILayout.ScrollViewScope(editorScroll))
        {
            editorScroll = scroll.scrollPosition;
            GFFEditor.DrawStruct(selected);
        }
    }

    void Reset()
    {
        moduleName = null;
        modulePath = null;
        rim = null;
        srim = null;
        dlg = null;
        mod = null;

        currentItem = null;

        tab = 0;

        templateType = 0;
        templateName = "";

        itemScroll = Vector3.zero;
        editorScroll = Vector3.zero;

        selected = null;

        newTemplates = new List<(string, AuroraStruct, KItemPicker.ItemType)>();
    }

    void LoadModule()
    {
        string loc = EditorUtility.OpenFilePanel("Select Module", "", "*");

        moduleName = Path.GetFileNameWithoutExtension(loc);
        modulePath = Path.GetDirectoryName(loc);

        // Load rim
        string rimLoc = modulePath + "\\" + moduleName + ".rim";
        rim = new RIMObject(rimLoc);

        // Load s_rim
        string srimLoc = modulePath + "\\" + moduleName + "_s.rim";
        srim = new RIMObject(srimLoc);

        // If TSL, load dlg_erf and mod 
        if (AuroraPrefs.TargetGame() == Game.TSL)
        {
            string dlgLoc = modulePath + "\\" + moduleName + "_dlg.erf";
            dlg = new ERFObject(dlgLoc);

            string modLoc = modulePath + "\\" + moduleName + ".mod";
            mod = new ERFObject(modLoc);
        }
    }

    void ImportModel()
    {

    }

    void ImportScript()
    {

    }

    void ImportDialogue()
    {

    }

    void ImportGFF()
    {

    }

    void CreateGFF()
    {
        switch (templateType)
        {
            case KItemPicker.ItemType.MODEL:
                Debug.LogWarning("Creating new models not yet supported");
                break;
            case KItemPicker.ItemType.CREATURE:
                AuroraUTC utc = new AuroraUTC();
                AddItem(templateName, utc, templateType);
                break;
            case KItemPicker.ItemType.DOOR:
                AuroraUTD utd = new AuroraUTD();
                AddItem(templateName, utd, templateType);
                break;
            case KItemPicker.ItemType.PLACEABLE:
                AuroraUTP utp = new AuroraUTP();
                AddItem(templateName, utp, templateType);
                break;
            case KItemPicker.ItemType.TRIGGER:
                AuroraUTT utt = new AuroraUTT();
                AddItem(templateName, utt, templateType);
                break;
            case KItemPicker.ItemType.ENCOUNTER:
                AuroraUTE ute = new AuroraUTE();
                AddItem(templateName, ute, templateType);
                break;
            case KItemPicker.ItemType.SOUND:
                AuroraUTS uts = new AuroraUTS();
                AddItem(templateName, uts, templateType);
                break;
            case KItemPicker.ItemType.STORE:
                AuroraUTM utm = new AuroraUTM();
                AddItem(templateName, utm, templateType);
                break;
            case KItemPicker.ItemType.WAYPOINT:
                AuroraUTW utw = new AuroraUTW();
                AddItem(templateName, utw, templateType);
                break;
            case KItemPicker.ItemType.CAMERA:
                Debug.LogWarning("Creating new cameras not yet supported");
                break;
        }
    }

    void AddItem(string name, AuroraStruct item, KItemPicker.ItemType itemType)
    {
        newTemplates.Add((name, item, itemType));
    }

    // Source: https://stackoverflow.com/questions/11074381/deep-copy-of-a-c-sharp-object
    public static T DeepClone<T>(T obj)
    {
        using (var ms = new MemoryStream())
        {
            var formatter = new BinaryFormatter();
            formatter.Serialize(ms, obj);
            ms.Position = 0;
            return (T)formatter.Deserialize(ms);
        }
    }

    void DuplicateTemplate()
    {
        // Create a new template from the current one
        AuroraStruct clone = DeepClone(selected);

        KItemPicker.ItemType itemType;

        if (selected.GetType() == typeof(AuroraUTC))
            itemType = KItemPicker.ItemType.CREATURE;
        else if (selected.GetType() == typeof(AuroraUTD))
            itemType = KItemPicker.ItemType.DOOR;
        else if (selected.GetType() == typeof(AuroraUTP))
            itemType = KItemPicker.ItemType.PLACEABLE;
        else if (selected.GetType() == typeof(AuroraUTT))
            itemType = KItemPicker.ItemType.TRIGGER;
        else if (selected.GetType() == typeof(AuroraUTE))
            itemType = KItemPicker.ItemType.ENCOUNTER;
        else if (selected.GetType() == typeof(AuroraUTS))
            itemType = KItemPicker.ItemType.SOUND;
        else if (selected.GetType() == typeof(AuroraUTM))
            itemType = KItemPicker.ItemType.STORE;
        else if (selected.GetType() == typeof(AuroraUTW))
            itemType = KItemPicker.ItemType.WAYPOINT;
        else
            itemType = KItemPicker.ItemType.CREATURE;

        AddItem(templateName, clone, itemType);
    }

    void DeleteTemplate()
    {
        // Firstly, make sure the current template is not from the module
        // (otherwise, for now at least, we don't delete it since there's no
        // undo functionality)
        for (int i = 0; i < newTemplates.Count; i++)
        {
            (_, AuroraStruct template, _) = newTemplates[i];
            if (template == selected)
            {
                newTemplates.RemoveAt(i);
                return;
            }
        }

        Debug.LogWarning("We do not currently delete templates from the module, for safety");
    }

    void SaveModule()
    {
        SaveModuleFiles();
    }

    void SaveModuleFiles()
    {
        // We will save the files to a temporary folder
        string folder = AuroraPrefs.GetModuleOutLocation();

        // Convert all the templates to GFF format, via XML
        foreach ((string name, AuroraStruct template, KItemPicker.ItemType type) in newTemplates)
        {
            string ext = KItemPicker.NameMap[type];
            CreateGFFFile(folder, name, template, ext);
        }

        // Copy the current module's _s.rim file to the temp folder
        File.Copy(modulePath + "\\" + moduleName + "_s.rim", folder + "tmp.rim");
        UnpackArchive(folder, "tmp.rim", "unrim");
        UnityEngine.Windows.File.Delete(folder + "tmp.rim");

        // If we are working with TSL, we also copy the _dlg.erf and .mod files if they exist
        if (AuroraPrefs.TargetGame() == Game.TSL)
        {
            File.Copy(modulePath + "\\" + moduleName + "_dlg.erf", folder + "tmp_dlg.erf");
            UnpackArchive(folder, "tmp_dlg.erf", "unerf");
            UnityEngine.Windows.File.Delete(folder + "tmp_dlg.erf");

            File.Copy(modulePath + "\\" + moduleName + ".mod", folder + "tmp.mod");
            UnpackArchive(folder, "tmp.mod", "unerf");
            UnityEngine.Windows.File.Delete(folder + "tmp.mod");
        }

        if (AuroraPrefs.TargetGame() == Game.KotOR)
            CreateArchive(folder, "module_s.rim", "rim");
        else
            CreateArchive(folder, "module.mod", "erf", "--mod");
    }

    public static void CreateArchive(string folder, string name, string type, string args = "")
    {

        // Find all the files in the tmp folder
        List<string> archiveFiles = new List<string>();
        foreach (string path in Directory.GetFiles(folder))
        {
            Debug.Log(path);
            archiveFiles.Add(path);
        }

        // Create the archive
        AuroraEngine.Resources.RunXoreosTools(
            folder + name + " " + String.Join(" ", archiveFiles),
            type,
            args
        );

        // Delete all the temporary files
        foreach (string tmpFile in Directory.GetFiles(folder))
        {
            if (tmpFile != folder + name)
            {
                UnityEngine.Windows.File.Delete(tmpFile);
            }
        }

        // Modify the tag at the start of the file
        if (args == null || args == "")
        {
            return;
        }

        string toWrite = "ERF V1.0";
        if (args == "--mod")
        {
            // WRITE "MOD v1.0" as the first 8 bytes of the array
            toWrite = "MOD V1.0";
        }

        // Write to the array
        using (FileStream stream = new FileStream(folder + name, FileMode.Open))
        using (BinaryWriter binary = new BinaryWriter(stream))
        {
            binary.Seek(0, SeekOrigin.Begin);
            foreach (byte b in Encoding.ASCII.GetBytes(toWrite))
            {
                binary.Write(b);
            }
        }
    }

    public static void UnpackArchive(string folder, string name, string type)
    {
        AuroraEngine.Resources.RunXoreosTools(
            folder + name,
            type,
            "e",
            folder
        );
    }
    public static void CreateGFFFile(string folder, string name, AuroraStruct template, string ext)
    {
        // Create an XML file for the GFF template
        string xmlpath = folder + "tmp.xml";
        string xml = template.ToXML(ext.ToUpper());
        Debug.Log(xml);
        File.WriteAllText(xmlpath, xml);

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
