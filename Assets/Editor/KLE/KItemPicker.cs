using AuroraEngine;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class KItemPicker : EditorWindow
{
    public enum ItemType
    {
        MODEL, CREATURE, DOOR, PLACEABLE, TRIGGER, ENCOUNTER, SOUND, STORE, WAYPOINT, CAMERA
    }
    
    public static Dictionary<ItemType, string> NameMap = new Dictionary<ItemType, string>()
    {
        { ItemType.MODEL, "mdl" },
        { ItemType.CREATURE, "utc" },
        { ItemType.DOOR, "utd" },
        { ItemType.PLACEABLE, "utp" },
        { ItemType.TRIGGER, "utt" },
        { ItemType.ENCOUNTER, "ute" },
        { ItemType.SOUND, "uts" },
        { ItemType.STORE, "utm" },
        { ItemType.WAYPOINT, "utw" },
        { ItemType.CAMERA, "cam" },
    };

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