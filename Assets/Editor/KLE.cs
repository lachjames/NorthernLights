using AuroraEngine;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEditor;
using UnityEngine;

public class KLE : EditorWindow
{
    public static Game game = Game.KotOR;

    bool isTSL = false;
    string location = "D:\\SteamLibrary\\steamapps\\common\\swkotor";
    int moduleIdx = 0;

    public AuroraEngine.Module module;

    string[] modules;
    List<string> names;

    string savedName = "";

    Dictionary<Type, string> extensions = new Dictionary<Type, string>() {
        { typeof(AuroraUTC), "utc" },
        { typeof(AuroraUTD), "utd" },
        { typeof(AuroraUTP), "utp" },
        { typeof(AuroraUTT), "utt" },
        { typeof(AuroraUTE), "ute" },
        { typeof(AuroraUTS), "uts" },
        { typeof(AuroraUTM), "utm" },
        { typeof(AuroraUTW), "utw" }
    };

    [MenuItem("KotOR/Open")]
    public static void ShowWindow()
    {
        GetWindow<KLE>(false, "KotOR Level Editor", true);
    }

    public void OnGUI()
    {
        using (new EditorGUILayout.VerticalScope("box"))
        {
            if (GUILayout.Button("Load KOTOR"))
            {
                LoadGame();
            }

            if (location == "")
            {
                return;
            }

            if (names == null)
            {
                return;
            }

            moduleIdx = EditorGUILayout.Popup(moduleIdx, names.ToArray());

            if (GUILayout.Button("Load module"))
            {
                LoadModule();
            }


            GUILayout.Space(10);
            savedName = GUILayout.TextField(savedName);

            //if (GUILayout.Button("Save module"))
            //{
            //    SaveModule();
            //}

            GUILayout.Space(10);

            if (GUILayout.Button("Add object"))
            {
                GetWindow<KItemPicker>(false, "KotOR Level Editor", true);
            }
        }
    }

    void LoadGame()
    {
        string loc = location + "\\modules";

        AuroraEngine.Resources.Load(null);

        modules = Directory.GetFiles(loc, "*.rim");
        names = new List<string>();

        foreach (string mod in modules)
        {
            if (mod.Contains("_s"))
            {
                continue;
            }
            names.Add(mod.Split('\\').Last().Replace(".rim", ""));
        }
    }

    void LoadModule()
    {
        AuroraEngine.Resources.data.loader.Load(names[moduleIdx]);
    }

    //    void SaveModule ()
    //    {
    //        string tmpFolder = "D:\\KOTOR\\KLE\\Kotor Level Editor\\tmp";
    //        /* A module consists of two files:
    //           mod.rim:
    //             - mod.are: An ARE file (GFF)
    //             - mod.git: A GIT file (GFF)
    //             - mod.ifo: An IFO file (IFO, need to write custom writer for this)

    //           mod_s.rim:
    //             - All other data files, in GFF format

    //           To save a module, we do the following:
    //             1. Save all the GFF files to a temporary folder using xoreos-tools' xml2gff
    //             2. Package into mod_s.rim using xoreos-tools
    //             3. Create the ARE, GIT, IFO, and LYT files
    //             4. Package mod.rim using xoreos-tools
    //             5. Save files into KotOR module directory
    //        */

    //        // Save all the GFF files to a temporary folder
    //        int i = 0;
    //        string filenames = "";

    //        foreach (GameObject g in FindObjectsOfType<GameObject>())
    //        {
    //            AuroraObject[] data = g.GetComponents<AuroraObject>();

    //            if (data.Length == 0)
    //            {
    //                continue;
    //            }

    //            AuroraObject container = data[0];

    //            if (data.Length > 1)
    //            {
    //                foreach (AuroraObject c in data)
    //                {
    //                    if (c.template != null)
    //                    {
    //                        container = c;
    //                        break;
    //                    }
    //                }
    //            }

    //            if (container.template != null)
    //            {

    //                string xml = container.template.ToXML();
    //                Debug.Log(xml);

    //                string ext = extensions[container.template.GetType()];

    //                File.WriteAllText(tmpFolder + "\\" + container.resref + "." + ext, xml);

    //                filenames += " \"" + tmpFolder + "\\" + container.resref + "." + ext + "\"";
    //            }
    //        }

    //        // Package the mod_s.rim file
    //        AuroraEngine.Resources.RunXoreosTools(
    //            "",
    //            "rim",
    //            savedName + "_s.rim " + filenames
    //        );

    //        string rimLoc = "";

    //        // Create the ARE file
    //        string areXML = module.are.ToXML();
    //        File.WriteAllText(tmpFolder + "\\" + savedName + "module.are", areXML);
    //        rimLoc += "\"" + tmpFolder + "\\module.are" + "\" ";
    //        // Create the GIT file
    //        string gitXML = module.git.ToXML();
    //        File.WriteAllText(tmpFolder + "\\" + savedName + ".git", gitXML);
    //        rimLoc += "\"" + tmpFolder + "\\module.git" + "\" ";

    //        // Create the IFO file
    //        string ifoXML = module.ifo.ToXML();
    //        File.WriteAllText(tmpFolder + "\\module.ifo", ifoXML);
    //        rimLoc += "\"" + tmpFolder + "\\module.ifo" + "\"";

    //        // Package mod.rim
    //        AuroraEngine.Resources.RunXoreosTools(
    //            "",
    //            "rim",
    //            savedName + ".rim " + rimLoc
    //        );

    //        // Create the LYT file


    //    }
}

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

            }
        }
    }

    void Editor ()
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

    void ItemSelection (ResourceType[] types)
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

                if (GUILayout.Button(name + " (" + rt + ")"))
                {
                    RIMObject.Resource resource = srim.resources[(name, rt)];
                    Stream stream = srim.GetResource(resource.ResRef, resource.ResType);
                    SelectedItem(stream, resource.ResType);
                }
            }
            // Get all items in the MOD

            // Get all items in the erf
        }
    }

    void SelectedItem (Stream stream, ResourceType rt)
    {
        if (rt == ResourceType.NCS)
        {
            // This is an NCS script
            return;
        } else if (rt == ResourceType.CAM) {
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

    void DrawEditor ()
    {
        // Draw the GFF editor for the selected item
        using (var scroll = new EditorGUILayout.ScrollViewScope(editorScroll))
        {
            editorScroll = scroll.scrollPosition;
            GFFEditor.DrawStruct(selected);
        }
    }

    void Reset ()
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
        if (KLE.game == Game.TSL)
        {
            string dlgLoc = modulePath + "\\" + moduleName + "_dlg.erf";
            dlg = new ERFObject(dlgLoc);

            string modLoc = modulePath + "\\" + moduleName + ".mod";
            mod = new ERFObject(modLoc);
        }
    }

    void SaveModule()
    {

    }
    void ImportModel()
    {

    }

    void ImportScript ()
    {

    }

    void ImportDialogue()
    {

    }

    void ImportGFF ()
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

    void AddItem (string name, AuroraStruct item, KItemPicker.ItemType itemType)
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

    void DuplicateTemplate ()
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
}

public class KItemPicker : EditorWindow
{
    public enum ItemType
    {
        MODEL, CREATURE, DOOR, PLACEABLE, TRIGGER, ENCOUNTER, SOUND, STORE, WAYPOINT, CAMERA
    }

    public static Dictionary<ItemType, AuroraEngine.ResourceType> TypeMap = new Dictionary<ItemType, AuroraEngine.ResourceType>()
    {
        { ItemType.MODEL, AuroraEngine.ResourceType.MDL },
        { ItemType.CREATURE, AuroraEngine.ResourceType.UTC },
        { ItemType.DOOR, AuroraEngine.ResourceType.UTD },
        { ItemType.PLACEABLE, AuroraEngine.ResourceType.UTP },
        { ItemType.TRIGGER, AuroraEngine.ResourceType.UTT },
        { ItemType.ENCOUNTER, AuroraEngine.ResourceType.UTE },
        { ItemType.SOUND, AuroraEngine.ResourceType.UTS },
        { ItemType.STORE, AuroraEngine.ResourceType.UTM },
        { ItemType.WAYPOINT, AuroraEngine.ResourceType.UTW },
        { ItemType.CAMERA, AuroraEngine.ResourceType.CAM },
    };

    ItemType curItemType;

    Vector2 modScroll, bifScroll;
    string[] bifItems = new string[0];
    string[] modItems = new string[0];
    string[] overItems = new string[0];

    int tab = 0;
    string search = "";

    List<object> tempObjects;

    [MenuItem("KotOR/Item Picker")]
    public static void ShowWindow()
    {
        GetWindow<KLE>(false, "KotOR Object Picker", true);
    }

    public void OnGUI()
    {
        using (new EditorGUILayout.VerticalScope("box"))
        {
            ItemType newItemType = (ItemType)EditorGUILayout.Popup((int)curItemType, Enum.GetNames(typeof(ItemType)));
            if (newItemType != curItemType)
            {
                curItemType = newItemType;
                GetItems();
            }

            tab = GUILayout.Toolbar(tab, new string[] { "Base", "Module", "Override", "All" });
            search = GUILayout.TextField(search);

            string[] resrefs = new string[] { };

            switch(tab)
            {
                case 0:
                    resrefs = bifItems;
                    break;
                case 1:
                    resrefs = modItems;
                    break;
                case 2:
                    resrefs = overItems;
                    break;
                case 3:
                    resrefs = bifItems.Concat(modItems).Concat(overItems).ToArray();
                    break;
            }

            if (search != "")
            {
                resrefs = resrefs.Where(p => p.Contains(search)).ToArray();
            }

            using (var scope = new EditorGUILayout.ScrollViewScope(modScroll, "box"))
            {
                modScroll = scope.scrollPosition;

                int i = 0;
                foreach (string item in resrefs)
                {
                    if (GUILayout.Button(item))
                    {
                        NewInstance(item);
                    }
                }
            }
        }
    }

    void NewInstance (string resref)
    {
        AuroraGIT git = GetWindow<KLE>(false, "KotOR Level Editor", false).module.git;

        AuroraObject container;
        GameObject parent;
        int idx = 0;

        switch (curItemType)
        {
            case ItemType.CREATURE:
                container = AuroraEngine.Resources.LoadCreature(resref);
                parent = GameObject.Find("Creatures");

                // Add the object to the module's GIT
                AuroraGIT.ACreature creature = new AuroraGIT.ACreature();
                creature.structid = (uint)git.CreatureList.Count();
                idx = (int)creature.structid;
                creature.TemplateResRef = resref;
                git.CreatureList.Add(creature);

                break;
            case ItemType.DOOR:
                container = AuroraEngine.Resources.LoadDoor(resref);
                parent = GameObject.Find("Doors");

                // Add the object to the module's GIT
                AuroraGIT.ADoor door = new AuroraGIT.ADoor();
                door.structid = (uint)git.CreatureList.Count();
                idx = (int)door.structid;
                door.TemplateResRef = resref;
                git.DoorList.Add(door);

                break;
            case ItemType.PLACEABLE:
                container = AuroraEngine.Resources.LoadPlaceable(resref);
                parent = GameObject.Find("Doors");

                // Add the object to the module's GIT
                AuroraGIT.APlaceable plc = new AuroraGIT.APlaceable();
                plc.structid = (uint)git.CreatureList.Count();
                idx = (int)plc.structid;
                plc.TemplateResRef = resref;
                git.PlaceableList.Add(plc);

                break;
            case ItemType.TRIGGER:
                container = AuroraEngine.Resources.LoadTrigger(resref);
                parent = GameObject.Find("Triggers");
                break;
            case ItemType.ENCOUNTER:
                container = AuroraEngine.Resources.LoadEncounter(resref);
                parent = GameObject.Find("Encounters");
                break;
            case ItemType.SOUND:
                container = AuroraEngine.Resources.LoadSound(resref);
                parent = GameObject.Find("Sounds");
                break;
            case ItemType.STORE:
                container = AuroraEngine.Resources.LoadStore(resref);
                parent = GameObject.Find("Stores");
                break;
            case ItemType.WAYPOINT:
                container = AuroraEngine.Resources.LoadWaypoint(resref);
                parent = GameObject.Find("Waypoints");
                break;
            case ItemType.CAMERA:
                throw new NotImplementedException("Camera not yet implemented");
            default:
                throw new NotImplementedException("Item type " + curItemType + " not yet implemented");
        }

        container.transform.SetParent(parent.transform);
        container.transform.position = FindSpawnPoint();
        container.gitIndex = idx;

    }

    void BIFItems ()
    {
        AuroraEngine.ResourceType curType = TypeMap[curItemType];
        List<string> objects = new List<string>();

        var dict = AuroraEngine.Resources.data.keyObject.resourceKeys;
        // Get items from the base BIFs
        foreach ((string name, AuroraEngine.ResourceType rt) in dict.Keys)
        {
            if (rt != curType)
            {
                continue;
            }

            // Get the relevant BIF object
            int bifIndex = (int)dict[(name, rt)] >> 20;
            AuroraEngine.BIFObject bif = AuroraEngine.Resources.data.bifObjects[bifIndex];

            Stream stream = bif.GetResourceData(
                bif.GetResourceById(
                    dict[(name, rt)]
                )
            );

            AuroraEngine.GFFObject obj = new AuroraEngine.GFFLoader(stream).GetObject();

            string resref = (string)obj["TemplateResRef"].Value;

            objects.Add(resref);
        }

        bifItems = objects.ToArray();
    }

    void MODItems ()
    {
        AuroraEngine.ResourceType curType = TypeMap[curItemType];
        List<string> objects = new List<string>();

        // Get items from the current module
        foreach ((string name, AuroraEngine.ResourceType rt) in GetWindow<KLE>(false, "KotOR Level Editor", false).module.data.srim.resources.Keys)
        {
            if (rt == curType)
            {
                objects.Add(name);
            }
        }

        // Get items from the override folder

        // Save all items as a string[] array
        modItems = objects.ToArray();
    }

    void OverItems ()
    {
        overItems = new string[] { };
    }


    void GetItems ()
    {
        BIFItems();
        MODItems();
        OverItems();
    }

    Vector3 FindSpawnPoint()
    {
        // Uses a raycast from the editor camera to find the spawn point in the center
        // of the screen
        Camera sceneCamera = SceneView.lastActiveSceneView.camera;
        int width = sceneCamera.pixelWidth;
        int height = sceneCamera.pixelHeight;

        Ray ray = sceneCamera.ScreenPointToRay(new Vector2(width / 2, height / 2));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            Debug.Log("Hit object " + hit.transform.name);
        }

        return hit.point;
    }
}