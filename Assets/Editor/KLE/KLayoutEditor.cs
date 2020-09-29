using AuroraEngine;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using UnityEditor;
using UnityEngine;

public class KLayoutEditor : EditorWindow
{
    float SCALE_FACTOR = 0.5f;
    AuroraLayout curLayout;

    int tab;
    Vector2 scrollPos;

    AuroraStruct curData;

    string curObjectName = "";

    [MenuItem("KotOR/Layout Editor")]
    public static void ShowWindow()
    {
        GetWindow<KLayoutEditor>(false, "Layout Editor", true);
    }

    public void OnGUI()
    {
        // Loading layouts
        if (GUILayout.Button("Load Layout"))
        {
            LoadLayout();
        }

        if (curLayout == null)
        {
            return;
        }

        // Saving layouts
        if (GUILayout.Button("Save Layout"))
        {
            SaveLayout();
        }

        GUILayout.Space(5);

        // Editing layouts
        curObjectName = GUILayout.TextField(curObjectName);
        if (GUILayout.Button("Create room with above model"))
        {
            // Create a new room with model name curObjectName
            AuroraRoom room = new AuroraRoom(curObjectName, Vector3.zero);
            curLayout.rooms.Add(room);

            CreateRoomObject(room);
        }

        if (GUILayout.Button("Delete selected room"))
        {
            DeleteSelectedRoom();
        }
    }

    void LoadLayout ()
    {
        string filename = EditorUtility.OpenFilePanel("Select LYT file", "", "lyt");
        curLayout = new AuroraLayout(filename);

        // Load room objects
        foreach (AuroraRoom room in curLayout.rooms)
        {
            CreateRoomObject(room);
        }

        // Load door objects
        foreach (AuroraDoorHook hook in curLayout.doorHooks)
        {
            GameObject hookObj = new GameObject();
            AuroraLayoutDoor doorComponent = hookObj.AddComponent<AuroraLayoutDoor>();

            doorComponent.Initialize(hook);

            hookObj.transform.position = new Vector3(
                hook.position.x,
                hook.position.z,
                hook.position.y
            );

            hookObj.transform.rotation = new Quaternion(
                -hook.rotation.x,
                -hook.rotation.z,
                -hook.rotation.y,
                hook.rotation.w
            );
        }
    }

    private static void CreateRoomObject(AuroraRoom room)
    {
        GameObject roomObj = new GameObject();
        AuroraLayoutRoom roomComponent = roomObj.AddComponent<AuroraLayoutRoom>();

        roomComponent.Initialize(room);

        roomObj.transform.position = new Vector3(
            room.position.x,
            room.position.z,
            room.position.y
        );
        roomObj.transform.localScale = Vector3.one;
    }

    void SaveLayout ()
    {
        string layoutString = curLayout.GetString();
        string filename = EditorUtility.SaveFilePanel("Select location to save LYT file", "", "layout.lyt", "lyt");

        File.WriteAllText(filename, layoutString);
    }
    
    void DeleteSelectedRoom()
    {
        AuroraLayoutRoom layoutRoom = Selection.activeTransform.GetComponent<AuroraLayoutRoom>();
        AuroraRoom selectedRoom = layoutRoom.room;

        // Delete the object from our layout
        curLayout.rooms.Remove(selectedRoom);

        // Destroy the Unity object too
        DestroyImmediate(layoutRoom.gameObject);
    }
}
