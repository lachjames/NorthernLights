using AuroraEngine;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class KLE : EditorWindow
{
    string k1Location = "D:\\SteamLibrary\\steamapps\\common\\swkotor";
    string tslLocation = "D:\\SteamLibrary\\steamapps\\common\\Knights of the Old Republic II";
    int moduleIdx = 0;

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

    [MenuItem("KotOR/Instance Editor")]
    public static void ShowWindow()
    {
        GetWindow<KLE>(false, "Instance Editor", true);
    }

    public void OnGUI()
    {
        using (new EditorGUILayout.VerticalScope("box"))
        {
            if (GUILayout.Button("Load KOTOR"))
            {
                LoadGame();
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

            if (GUILayout.Button("Save module"))
            {
                SaveModule();
            }

            GUILayout.Space(10);

            if (GUILayout.Button("Add object"))
            {
                GetWindow<KItemPicker>(false, "KotOR Level Editor", true);
            }
        }
    }

    void LoadGame()
    {
        AuroraEngine.Resources.Load(null);

        modules = Directory.GetFiles(AuroraPrefs.GetKotorLocation() + "\\modules", "*");
        
        names = new List<string>();

        foreach (string mod in modules)
        {
            // Skip _s and DLG files
            if (mod.Contains("_s") || mod.Contains("dlg"))
            {
                continue;
            }
            string name = mod.Split('\\').Last().Replace(".rim", "").Replace(".mod", "");
            if (!names.Contains(name))
            {
                names.Add(name);
            }
        }
    }

    void LoadModule()
    {
        AuroraEngine.Resources.data.loader.Load(names[moduleIdx]);
    }

    void SaveModule ()
    {
        string folder = AuroraPrefs.GetModuleOutLocation();

        Module module = AuroraEngine.Resources.data.module;
        string moduleName = module.moduleName;

        if (AuroraPrefs.TargetGame() == Game.TSL)
        {
            string filename = EditorUtility.OpenFilePanel("MOD archive to duplicate and insert into", "", "mod");

            // Copy the .mod file to the moduleout folder
            File.Copy(filename, folder + "tmp.mod");

            // Unpack the mod
            KModuleEditor.UnpackArchive(folder, "tmp.mod", "unerf");

            // Delete the temporary module file
            UnityEngine.Windows.File.Delete(folder + "tmp.mod");
        }

        // Access/create the required files
        AuroraGIT git = GameObject.Find("Area").GetComponent<AreaManager>().CreateGIT();
        AuroraARE are = module.are;
        AuroraIFO ifo = module.ifo;
        string areaName = ifo.Mod_Entry_Area;
        
        // Create the GFF files
        KModuleEditor.CreateGFFFile(folder, areaName, git, "git");
        KModuleEditor.CreateGFFFile(folder, areaName, are, "are");
        KModuleEditor.CreateGFFFile(folder, "module", ifo, "ifo");

        // Package the items up
        if (AuroraPrefs.TargetGame() == Game.KotOR)
        {
            // Create a RIM archive
            KModuleEditor.CreateArchive(folder, moduleName + ".rim", "rim");
        }
        else
        {
            // Repack the MOD
            KModuleEditor.CreateArchive(folder, moduleName + ".mod", "erf", "--mod");
        }
    }
}
