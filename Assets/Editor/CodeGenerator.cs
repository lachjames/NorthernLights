using AuroraEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;
using Newtonsoft.Json;

public class CodeGenerator : EditorWindow
{
    const string TAB = "    ";
    string OutputLocation = "D:\\KOTOR\\KotOR-Unity\\Generated";
    //string OutputLocation = "D:\\KOTOR\\KotOR-Unity\\tmp\\GeneratedTmp";
    string MetadataLocation = "D:\\KOTOR\\KOTOR1\\KOTOR\\tools\\aurorapdf\\tables";

    string SaveLocation = "C:\\Users\\lachl\\Downloads\\My kotor saves 1.1";
    string TmpLocation = "D:\\KOTOR\\KotOR-Unity\\tmp";

    bool loadedGFFs = false;

    ResourceType[] gffTypes = new ResourceType[]
    {
        ResourceType.RES,
        ResourceType.ARE,
        ResourceType.IFO,
        ResourceType.BIC,
        ResourceType.GIT,
        ResourceType.BTI, ResourceType.UTI,
        ResourceType.BTC, ResourceType.UTC,
        ResourceType.DLG,
        ResourceType.ITP,
        ResourceType.BTT, ResourceType.UTT,
        ResourceType.BTS, ResourceType.UTS,
        ResourceType.GFF,
        ResourceType.FAC,
        ResourceType.BTE, ResourceType.UTE,
        ResourceType.BTD, ResourceType.UTD,
        ResourceType.BTP, ResourceType.UTP,
        ResourceType.GIC,
        ResourceType.GUI,
        ResourceType.BTM, ResourceType.UTM,
        ResourceType.BTG, ResourceType.UTG,
        ResourceType.JRL,
        ResourceType.UTW,
        ResourceType.PTM,
        ResourceType.PTT,
        ResourceType.CUT,
        ResourceType.QDB,
        ResourceType.QST,
        ResourceType.PTH,
        ResourceType.QST2,
        ResourceType.STO,
        ResourceType.CWA
    };

    string preamble = @"using System;
using System.Collections.Generic;
using static AuroraEngine.GFFObject;
using UnityEngine;
using AuroraEngine;

";

    [MenuItem("Window/Aurora/Code Generation")]
    public static void ShowWindow()
    {
        EditorWindow.GetWindow(typeof(CodeGenerator));
    }

    public void OnGUI()
    {
        using (new EditorGUILayout.VerticalScope())
        {
            if (GUILayout.Button("Load GFFs"))
            {
                LoadGFFs();
            }

            if (!loadedGFFs)
            {
                return;
            }
        }
    }

    // Source: https://stackoverflow.com/questions/7413612/how-to-limit-the-execution-time-of-a-function-in-c-sharp
    // Used for debugging infinite loop errors
    //public static bool ExecuteWithTimeLimit(TimeSpan timeSpan, Action codeBlock)
    //{
    //    try
    //    {
    //        Task task = Task.Factory.StartNew(() => codeBlock());
    //        task.Wait(timeSpan);
    //        return task.IsCompleted;
    //    }
    //    catch (AggregateException ae)
    //    {
    //        throw ae.InnerExceptions[0];
    //    }
    //}

    void LoadGFFs ()
    {
        Debug.Log("Loading GFFs");

        LoadingSystem manager = GameObject.Find("Loading System").GetComponent<LoadingSystem>();
        Dictionary<string, ClassDefinition> defs = new Dictionary<string, ClassDefinition>();

        // Read metadata JSON
        //List<GFFMetadata> metadata = LoadMetadata();

        // Read GFF objects from disk
        Debug.Log("Loading BIFs");
        LoadGFFsFromBIFs(AuroraPrefs.GetKotorLocation() + "\\data", defs);

        Debug.Log("Loading RIMs");
        LoadGFFsFromRIMs(AuroraPrefs.GetKotorLocation() + "\\modules", defs);

        Debug.Log("Loading saves");
        foreach (string saveFolder in Directory.GetDirectories(SaveLocation))
        {
            Debug.Log(saveFolder);

            string[] subFolders = Directory.GetDirectories(saveFolder);

            // Shuffle the subfolders and pick some
            //System.Random rnd = new System.Random();
            //subFolders = subFolders.OrderBy(c => rnd.Next()).ToArray();
            //int i = 0;
            foreach (string subFolder in subFolders)
            {
                Debug.Log(subFolder);
                /* Saves consist of five files:
                     - GLOBALVARS.res: generic .res file
                     - PARTYTABLE.res: generic .res file
                     - SAVEGAME.sav: ERF file containing save information
                     - savenfo.res: generic .res file
                     - Screen.tga (can ignore this)
                */
                // Load the GFFs
                LoadGFFFromFile(subFolder + "\\GLOBALVARS.res", defs, "AuroraGlobalVars");
                LoadGFFFromFile(subFolder + "\\PARTYTABLE.res", defs, "AuroraPartyTable");
                LoadGFFFromFile(subFolder + "\\savenfo.res", defs, "AuroraSaveNfo");

                // Load the SAV (in ERF format)
                LoadGFFsFromERF(subFolder + "\\SAVEGAME.sav", defs);
                //if (i >= 10)
                //{
                //    break;
                //}
                //break;
            }
        }

        //foreach (string className in defs.Keys)
        //{
        //    defs[className].Match(metadata);
        //}

        // Generate and write code to disk
        foreach (string className in defs.Keys)
        {
            string code = preamble + defs[className].ToString();
            File.WriteAllText(OutputLocation + "\\" + className + ".cs", code);
        }
    }

    void LoadGFFsFromRIMs(string moduleDir, Dictionary<string, ClassDefinition> defs)
    {
        // We load every module in the game files

        // Find the list of module names
        // TODO: Implement this for KOTOR 2, which uses a different file structure

        foreach (string filename in Directory.GetFiles(moduleDir))
        {
            //Debug.Log("Loading " + filename);
            RIMObject obj = new RIMObject(filename);
            List<RIMObject.Resource> resources = new List<RIMObject.Resource>(obj.resources.Values);

            //Debug.Log(resources.Count());

            for (int i = 0; i < resources.Count(); i++)
            {
                RIMObject.Resource resource = resources[i];
                LoadRIM(obj, resource, defs);
            }
        }
    }
    void LoadGFFsFromERF(string filename, Dictionary<string, ClassDefinition> defs)
    {
        // We load every module in the game files

        // Find the list of module names
        // TODO: Implement this for KOTOR 2, which uses a different file structure
        //Debug.Log("Loading " + filename);
        ERFObject obj = new ERFObject(filename);

        LoadERFObj(obj, defs);
    }

    void LoadGFFsFromBIFs (string dataDir, Dictionary<string, ClassDefinition> defs)
    {

        // We load every BIF file in the game files

        // Find the list of module names
        // TODO: Implement this for KOTOR 2, which uses a different file structure

        foreach (string filename in Directory.GetFiles(dataDir))
        {
            //Debug.Log("Loading " + filename);
            BIFObject obj = new BIFObject(filename);
            LoadBIF(obj, defs);
        }
    }
    
    void LoadGFFFromFile(string location, Dictionary<string, ClassDefinition> defs, string className)
    {
        using (Stream stream = File.OpenRead(location))
        {
            GFFObject gff = (new GFFLoader(stream)).GetObject();
            LoadGFF(gff, defs, className);
        }
    }

    void LoadGFF(GFFObject gff, Dictionary<string, ClassDefinition> defs, string className)
    {
        if (!defs.ContainsKey(className))
        {
            defs[className] = new ClassDefinition();
        }
        // Update the class definition
        defs[className].AddToDefinition(gff, className, 0);
    }

    void LoadRIM(RIMObject obj, RIMObject.Resource resource, Dictionary<string, ClassDefinition> defs)
    {
        if (!gffTypes.Contains(resource.ResType))
        {
            return;
        }

        try
        {
            //Debug.Log("Loading resource " + resource.ResRef);
            string className = "Aurora" + resource.ResType.ToString().ToUpper().Replace(" ", "");

            // Load the resource from the RIM
            Stream stream = obj.GetResource(resource.ResRef, resource.ResType);
            GFFObject gffObject = new GFFLoader(stream).GetObject();
            LoadGFF(gffObject, defs, className);
        }
        catch
        {
            // Just keep going
            Debug.LogWarning("Failed to load " + resource.ResRef);
        }
    }

    void LoadERFObj (ERFObject obj, Dictionary<string, ClassDefinition> defs)
    {
        foreach ((string resRef, ResourceType resType) in obj.resourceKeys.Keys)
        {
            //Debug.Log("Loading erf object " + resRef);
            LoadERF(obj, resRef, resType, defs);
        }
    }

    void LoadERF(ERFObject obj, string resRef, ResourceType resType, Dictionary<string, ClassDefinition> defs)
    {
        if (!gffTypes.Contains(resType))
        {
            return;
        }

        string className = "Aurora" + resType.ToString().ToUpper().Replace(" ", "");
        if (!defs.ContainsKey(className))
        {
            defs[className] = new ClassDefinition();
        }

        Stream stream = obj.GetResource(resRef, resType);

        if (resType == ResourceType.ERF || resType == ResourceType.SAV)
        {
            // ERFs can contain ERFs themselves!
            //Debug.Log("Loading nested ERF file " + resRef);
            LoadERFObj(new ERFObject(stream), defs);
            //Debug.Log("Finished loading nested ERF file " + resRef);
        }
        else
        {
            // Load the resource from the ERF
            GFFObject gffObject = new GFFLoader(stream).GetObject();
            // Update the class definition
            LoadGFF(gffObject, defs, className);
        }
    }
    void LoadBIF(BIFObject obj, Dictionary<string, ClassDefinition> defs)
    {
        List<BIFObject.Resource> resources = obj.resources.ToList();

        //Debug.Log(resources.Count());

        for (int i = 0; i < resources.Count(); i++)
        {
            BIFObject.Resource resource = resources[i];
            ResourceType resType = (ResourceType)resource.ResType;
            if (!gffTypes.Contains(resType))
            {
                continue;
            }

            try
            {
                //Debug.Log("Loading resource " + resource.ResRef);
                string className = "Aurora" + resType.ToString().ToUpper().Replace(" ", "");

                // Load the resource from the RIM
                Stream stream = obj.GetResourceData(resource);
                GFFObject gffObject = new GFFLoader(stream).GetObject();
                LoadGFF(gffObject, defs, className);
            }
            catch
            {
                // Just keep going
                Debug.LogWarning("Failed to load " + resource.ID);
            }
        }
    }

    class ClassDefinition {
        public string Name;
        public int Level;

        public Dictionary<string, string> Fields = new Dictionary<string, string>()
        {
            { "structid", "uint" }
        };
        public Dictionary<string, ClassDefinition> Structs = new Dictionary<string, ClassDefinition>();
        public Dictionary<string, ClassDefinition> Lists = new Dictionary<string, ClassDefinition>();

        public void AddToDefinition(GFFObject obj, string name, int level)
        {
            Name = name;
            Level = level;

            if (obj.Type != GFFObject.FieldType.Struct)
            {
                throw new System.Exception("Can only add struct GFFObject to a class definition!");
            }

            // Add the struct types to the current definition, recursively
            Dictionary<string, GFFObject> dict = (Dictionary<string, GFFObject>)obj.Value;

            foreach (string key in dict.Keys)
            {
                GFFObject child = dict[key];
                if (child.Type == GFFObject.FieldType.Struct)
                {
                    // Add a struct definition if one does not exist
                    if (!Structs.ContainsKey(child.Label))
                    {
                        Structs[child.Label] = new ClassDefinition();
                    }

                    // Update the struct definition with this GFFObject
                    if (child.Label == Name)
                    {
                        // We need to append a suffix to the name
                        Structs[child.Label].AddToDefinition(child, "A" + child.Label.Replace(" ", "") + "2", Level + 1);
                    } else
                    {
                        Structs[child.Label].AddToDefinition(child, "A" + child.Label.Replace(" ", ""), Level + 1);
                    }

                } else if (child.Type == GFFObject.FieldType.List)
                {
                    // Check if the list is empty - if so, it gives us no information so just continue
                    GFFObject[] childList = (GFFObject[])child.Value;
                    if (childList.Count() == 0)
                    {
                        continue;
                    }

                    // If we reach this point, there is at least one item in the list;
                    // so we have to add their information to the definition

                    if (!Lists.ContainsKey(child.Label))
                    {
                        Lists[child.Label] = new ClassDefinition();
                    }

                    ClassDefinition listObjDefinition = Lists[child.Label];

                    foreach (GFFObject listObject in childList)
                    {
                        // Workaround for the GIT List issue
                        string listObjName;
                        string childName = child.Label.Replace("List", "");
                        if (childName == "")
                        {
                            listObjName = "A" + "Data";
                        } else
                        {
                            listObjName = "A" + childName;
                        }
                        listObjDefinition.AddToDefinition(
                            listObject,
                            listObjName,
                            Level + 1
                        );
                    }
                } else
                {
                    // Add the field to the list of Fields
                    if (Fields.ContainsKey(child.Label))
                    {
                        continue;
                    }
                    Fields[child.Label] = child.Value.GetType().Name;
                }
            }
        }

        public string FormatComment(string description)
        {
            // Turns the description into a comment
            string result = "";

            foreach (string line in description.Split('\n'))
            {
                result += TAB + "// " + line + "\n";
            }

            return result;
        }

        public new string ToString()
        {
            // Create the class definition
            string definition = "[Serializable]public class " + Name + " : AuroraStruct {\n";

            // Add the fields
            if (Fields.Count > 0)
                definition += TAB + "// Field definitions\n";

            foreach (string fieldName in Fields.Keys)
            {
                string attribute = "[GFF(\"" + fieldName + "\")] ";
                definition += TAB + attribute + "public " + Fields[fieldName] + " " + fieldName.Replace(" ", "")  + ";\n";
            }

            // Add the structs
            if (Structs.Count > 0)
                definition += "\n" + TAB + "// Struct definitions\n";

            foreach (string structName in Structs.Keys)
            {
                string attribute = "[GFF(\"" + structName + "\")] ";
                definition += TAB + attribute + "public " + Structs[structName].Name + " " + structName.Replace(" ", "") + " = new " + Structs[structName].Name + "();\n";
            }

            // Add the lists
            if (Lists.Count > 0)
                definition += "\n" + TAB + "// List definitions\n";

            foreach (string listName in Lists.Keys)
            {
                string attribute = "[GFF(\"" + listName + "\")] ";
                definition += TAB + attribute + "public " + "List<" + Lists[listName].Name + "> " + listName.Replace(" ", "") + " = new List<" + Lists[listName].Name + ">();\n";
            }

            if (Structs.Count > 0 || Lists.Count > 0)
                definition += "\n" + TAB + "// Class definitions";

            string classDefinitions = "";

            // For each struct type, add its definition too
            foreach (ClassDefinition structClass in Structs.Values)
            {
                classDefinitions += "\n" + structClass.ToString();
            }
            // For each list type, add its definition too
            foreach (ClassDefinition listClass in Lists.Values)
            {
                classDefinitions += "\n" + listClass.ToString();
            }

            string indented = "";
            foreach (string line in classDefinitions.Split(new[] { '\n' }))
            {
                indented += TAB;
                indented += line + "\n";
            }

            // Finish the definition with a closing bracket
            definition += indented + "}\n";

            return definition;
        }
    }
}
