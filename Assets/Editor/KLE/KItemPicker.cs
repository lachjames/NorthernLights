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
        GetWindow<KItemPicker>(false, "KotOR Object Picker", true);
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
        AuroraObject container;
        GameObject parent;

        switch (curItemType)
        {
            case ItemType.CREATURE:
                parent = GameObject.Find("Creatures");
                container = AuroraEngine.Resources.LoadCreature(resref, new AuroraGIT.ACreature()
                {
                    structid = (uint)parent.transform.childCount,
                    TemplateResRef = resref
                });
                break;
            case ItemType.DOOR:
                parent = GameObject.Find("Doors");
                container = AuroraEngine.Resources.LoadDoor(resref, new AuroraGIT.ADoor()
                {
                    structid = (uint)parent.transform.childCount,
                    TemplateResRef = resref
                });
                break;
            case ItemType.PLACEABLE:
                parent = GameObject.Find("Placeables");
                container = AuroraEngine.Resources.LoadPlaceable(resref, new AuroraGIT.APlaceable()
                {
                    structid = (uint)parent.transform.childCount,
                    TemplateResRef = resref
                });
                break;
            case ItemType.TRIGGER:
                parent = GameObject.Find("Triggers");
                container = AuroraEngine.Resources.LoadTrigger(resref, new AuroraGIT.ATrigger()
                {
                    structid = (uint)parent.transform.childCount,
                    TemplateResRef = resref
                });
                break;
            case ItemType.ENCOUNTER:
                parent = GameObject.Find("Encounters");
                container = AuroraEngine.Resources.LoadEncounter(resref, new AuroraGIT.AEncounter()
                {
                    structid = (uint)parent.transform.childCount,
                    TemplateResRef = resref
                });
                break;
            case ItemType.SOUND:
                parent = GameObject.Find("Sounds");
                container = AuroraEngine.Resources.LoadSound(resref, new AuroraGIT.ASound()
                {
                    structid = (uint)parent.transform.childCount,
                    TemplateResRef = resref
                });
                break;
            case ItemType.STORE:
                parent = GameObject.Find("Stores");
                container = AuroraEngine.Resources.LoadStore(resref, new AuroraGIT.AStore()
                {
                    structid = (uint)parent.transform.childCount,
                    ResRef = resref
                });
                break;
            case ItemType.WAYPOINT:
                parent = GameObject.Find("Waypoints");
                container = AuroraEngine.Resources.LoadWaypoint(resref, new AuroraGIT.AWaypoint()
                {
                    structid = (uint)parent.transform.childCount,
                    TemplateResRef = resref
                });
                break;
            case ItemType.CAMERA:
                throw new NotImplementedException("Camera not yet implemented");
            default:
                throw new NotImplementedException("Item type " + curItemType + " not yet implemented");
        }

        container.transform.SetParent(parent.transform);
        container.transform.position = FindSpawnPoint();
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
        foreach ((string name, AuroraEngine.ResourceType rt) in AuroraEngine.Resources.data.module.data.srim.resources.Keys)
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