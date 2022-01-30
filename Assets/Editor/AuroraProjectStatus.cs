using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using AuroraEngine;
using System.IO;
using System;
using System.Linq;
using System.Reflection;

[Serializable]
public class ProjectStatus
{
    public Dictionary<string, int> baseGameActions;
    public Dictionary<string, Dictionary<string, int>> moduleActions;

    public Dictionary<string, bool> implemented;
    public Dictionary<string, bool> todo;
}

public class AuroraProjectStatus : EditorWindow
{
    List<NCSFile> files;
    ProjectStatus status;

    Vector2 scroll = new Vector2();
    string module;
    string model_name;

    [MenuItem("KotOR/Project Status")]
    public static void ShowWindow()
    {
        EditorWindow.GetWindow(typeof(AuroraProjectStatus));
    }

    public void OnGUI()
    {
        if (GUILayout.Button("Compute"))
        {
            Compute();
        }

        if (status != null)
        {
            ShowStatus();
        }

        model_name = EditorGUILayout.TextField("Model Name", model_name);
        if (GUILayout.Button("Instantiate Model"))
        {
            InstantiateModel();
        }
        ListModels();
    }

    void InstantiateModel()
    {
        AuroraEngine.Resources.LoadModel(model_name);

        // AuroraData data = new AuroraData(
        //     Game.TSL,
        //     null
        // );

        // foreach ((string resref, ResourceType key) in data.keyObject.resourceKeys.Keys)
        // {
        //     // Type code for MDL
        //     if (key == ResourceType.MDL && resref.Contains(model_name))
        //     {
        //         Debug.Log("Loading " + resref);
        //         AuroraEngine.Resources.LoadModel(resref);
        //     }
        // }
    }

    void ListModels()
    {
        // AuroraData data = new AuroraData(
        //     Game.TSL,
        //     null
        // );

        // foreach ((string resref, ResourceType key) in data.keyObject.resourceKeys.Keys)
        // {
        //     // Type code for MDL
        //     if (key == ResourceType.MDL && resref.Contains(model_name))
        //     {
        //         GUILayout.Label(resref);
        //     }
        // }
    }

    void Compute()
    {
        // Compute the implementation status of the project
        GetAllNCSFiles();
        GetImplemented();
    }

    void GetAllNCSFiles()
    {
        // Gets every NCS file in the game, including from all
        // modules
        files = new List<NCSFile>();

        // Load base game files
        AuroraData data = new AuroraData(
            Game.KotOR,
            null
        );

        Dictionary<string, int> baseGameActions = new Dictionary<string, int>();
        foreach ((string resref, ResourceType key) in data.keyObject.resourceKeys.Keys)
        {
            // Type code for NCS scripts is 2010
            if (key == ResourceType.NCS)
            {
                Debug.Log(resref);
                using (Stream stream = data.GetStream(resref, key))
                {
                    NCSFile file = new NCSFile(stream);
                    foreach (NCSOperation op in file.operations)
                    {
                        if (op.opcode == 0x05)
                        {
                            // This operation is an action, so we have to find the type and
                            // add it to the list
                            string action = NWScript_Actions.ACTIONS[int.Parse(op.args[1])];
                            if (!baseGameActions.ContainsKey(action))
                            {
                                baseGameActions.Add(action, 0);
                            }
                            baseGameActions[action]++;
                        }
                    }
                }
            }
        }

        Dictionary<string, Dictionary<string, int>> moduleActions = new Dictionary<string, Dictionary<string, int>>();

        Debug.Log("Found " + baseGameActions.Count + " actions in base game");

        // For each module, load the module data and get all the NCS files
        // First, get the list of modules
        string[] modules = Directory.GetFiles(
            AuroraData.GetPath("modules")
        );

        HashSet<string> moduleNames = new HashSet<string>();
        foreach (string module in modules)
        {
            string basename = Path.GetFileNameWithoutExtension(module.Replace("_s.rim", ""));
            moduleNames.Add(basename);
        }

        foreach (string module in moduleNames)
        {
            if (module != "end_m01aa")
            {
                // This is just for testing
                continue;
            }
            data.moduleName = module;
            data.LoadModuleFromGameFiles(false);
            Debug.Log("Loaded module " + module);

            // Now, get all the NCS files
            Dictionary<string, int> moduleCounts = new Dictionary<string, int>();

            // Get all items from the rim, srim, dlg, and mod files
            // rim file
            if (data.srim != null)
            {
                RIMObject rim = (RIMObject)data.srim;
                foreach ((string resref, ResourceType key) in rim.resources.Keys)
                {
                    // Type code for NCS scripts is 2010
                    if (key == ResourceType.NCS)
                    {
                        Debug.Log(resref);
                        using (Stream stream = data.GetStream(resref, key))
                        {
                            NCSFile file;
                            try
                            {
                                file = new NCSFile(stream);
                            }
                            catch (Exception e)
                            {
                                Debug.LogWarning("Failed to load script '" + resref + "' from module " + module + ": " + e.Message);
                                continue;
                            }
                            foreach (NCSOperation op in file.operations)
                            {
                                if (op.opcode == 0x05)
                                {
                                    // This operation is an action, so we have to find the type and
                                    // add it to the list
                                    string action = NWScript_Actions.ACTIONS[int.Parse(op.args[1])];
                                    if (!moduleCounts.ContainsKey(action))
                                    {
                                        moduleCounts.Add(action, 0);
                                    }
                                    moduleCounts[action]++;
                                }
                            }
                        }
                    }
                }
            }

            // Save the counts
            moduleActions.Add(module, moduleCounts);
        }

        foreach (string module in moduleNames)
        {
            if (!moduleActions.ContainsKey(module))
            {
                continue;
            }
            Debug.Log("Module " + module + " has " + moduleActions[module].Count + " actions");
        }

        status = new ProjectStatus()
        {
            baseGameActions = baseGameActions,
            moduleActions = moduleActions
        };
    }

    void GetImplemented()
    {
        // Get all methods from AuroraEngine.NWScript
        Type type = typeof(NWScript);
        MethodInfo[] methods = type.GetMethods();

        // Set implemented to true if the method does not contain a
        // NotImplementedException
        status.implemented = new Dictionary<string, bool>();
        status.todo = new Dictionary<string, bool>();

        string nwscript_location = "/Users/lachlanoneill/Documents/dev/NorthernLights/Assets/Scripts/ncs/nwscript.cs";
        string[] lines = File.ReadAllLines(nwscript_location);

        foreach (MethodInfo method in methods)
        {
            for (int idx = 0; idx < lines.Length; idx++)
            {
                if (lines[idx].Contains("public static") &&
                (lines[idx].Contains(" " + method.Name + " ") || lines[idx].Contains(" " + method.Name + "(")))
                {
                    bool implemented = true;
                    bool todo = false;
                    for (int next_idx = idx + 1; next_idx < lines.Length; next_idx++)
                    {
                        if (lines[next_idx].Contains("public static"))
                        {
                            // This is a the end of the method
                            break;
                        }
                        if (lines[next_idx].ToLower().Contains("todo"))
                        {
                            todo = true;
                            break;
                        }
                        if (lines[next_idx].Contains("throw new NotImplementedException"))
                        {
                            // This method is not implemented
                            implemented = false;
                            break;
                        }
                    }
                    status.implemented.Add(method.Name, implemented);
                    status.todo.Add(method.Name, todo);
                }
            }
        }
    }

    void ShowStatus()
    {
        // Show the status of the project
        module = EditorGUILayout.TextField("Module", module);

        Dictionary<string, int> actions = null;
        if (module == "")
        {
            actions = status.baseGameActions;
        }
        else if (status.moduleActions.ContainsKey(module))
        {
            actions = status.moduleActions[module];
        }

        if (actions == null)
        {
            return;
        }
        // Scrollable list of actions
        scroll = GUILayout.BeginScrollView(scroll);

        // Sort actions by count
        List<KeyValuePair<string, int>> sorted = actions.ToList();
        sorted.Sort((a, b) => b.Value.CompareTo(a.Value));

        foreach (KeyValuePair<string, int> action in sorted)
        {

            if (status.todo[action.Key])
            {
                GUI.color = Color.yellow;
            }
            else if (status.implemented[action.Key])
            {
                GUI.color = Color.green;
            }
            else
            {
                GUI.color = Color.red;
            }
            GUILayout.Label(action.Key + ": " + action.Value);
            GUI.color = Color.white;
        }
        GUILayout.EndScrollView();
    }

}