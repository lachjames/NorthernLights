using AuroraEngine;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
