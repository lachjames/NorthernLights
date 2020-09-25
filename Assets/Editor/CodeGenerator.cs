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
using UnityEngine.Networking.NetworkSystem;
using System.Net.Configuration;

/* Some general post-generation manual changes are required.
 *  - Renaming some classes with the same names as their parents
 *  - Renaming two different typed variables with the same name
 * 
 * Some specific corrections must also be made:
 *  - In AuroraDLG, VOTextChanged's type must be set to Int32, not Byte
 *  - In AuroraARE, the instance of AMiniGame must be commented out
*/
public class CodeGenerator : EditorWindow
{
    const string TAB = "    ";
    string OutputLocation = "D:\\KOTOR\\KotOR-Unity\\Generated";
    //string OutputLocation = "D:\\KOTOR\\KotOR-Unity\\tmp\\GeneratedTmp";
    string MetadataLocation = "D:\\KOTOR\\KOTOR1\\KOTOR\\tools\\aurorapdf\\tables";

    //string SaveLocation = "C:\\Users\\lachl\\Downloads\\My kotor saves 1.1";
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

        Dictionary<string, ClassDefinition> k1BaseDefs = LoadBaseGameGFFs(Compatibility.KotOR);
        Dictionary<string, ClassDefinition> tslBaseDefs = LoadBaseGameGFFs(Compatibility.TSL);

        Dictionary<string, ClassDefinition> k1SaveDefs = LoadSaveGFFs(Compatibility.KotOR);
        Dictionary<string, ClassDefinition> tslSaveDefs = LoadSaveGFFs(Compatibility.TSL);

        //Dictionary<string, ClassDefinition> k1SaveDefs = new Dictionary<string, ClassDefinition>();
        //Dictionary<string, ClassDefinition> tslSaveDefs = new Dictionary<string, ClassDefinition>();

        Dictionary<string, ClassDefinition> defs = CombineDefinitions(k1BaseDefs, tslBaseDefs, k1SaveDefs, tslSaveDefs);

        foreach (string str in defs.Keys)
        {
            Debug.Log("Created class " + str + " from TSL base game files");
        }

        // Generate and write code to disk
        foreach (string className in defs.Keys)
        {
            string code = preamble + defs[className].ToString();
            File.WriteAllText(OutputLocation + "\\" + className + ".cs", code);
        }
    }

    Dictionary<string, ClassDefinition> LoadBaseGameGFFs(Compatibility compat)
    {
        string loc = compat == Compatibility.KotOR ? AuroraPrefs.GetK1Location() : AuroraPrefs.GetTSLLocation();
        
        Dictionary<string, ClassDefinition> defs = new Dictionary<string, ClassDefinition>();
        // Read GFF objects from disk
        Debug.Log("Loading BIFs");
        LoadGFFsFromBIFs(loc + "\\data", defs, compat, ExistsIn.BASE);

        Debug.Log("Loading RIMs");
        LoadGFFsFromRIMs(loc + "\\modules", defs, compat, ExistsIn.BASE);

        if (compat == Compatibility.TSL)
        {
            // Load data from all .erf files (which are ERF files, and contain DLG files for the module)
            foreach (string erf in Directory.GetFiles(loc + "\\modules", "*.erf"))
            {
                LoadGFFsFromERF(erf, defs, compat, ExistsIn.BASE);
            }

            // Load data from all .mod files (which are ERF files)
            foreach (string mod in Directory.GetFiles(loc + "\\modules", "*.mod"))
            {
                LoadGFFsFromERF(mod, defs, compat, ExistsIn.BASE);
            }
        }

        return defs;
    }
    Dictionary<string, ClassDefinition> LoadSaveGFFs(Compatibility compat)
    {
        string loc = compat == Compatibility.KotOR ? AuroraPrefs.GetK1SaveLocation() : AuroraPrefs.GetTSLSaveLocation();

        Dictionary<string, ClassDefinition> defs = new Dictionary<string, ClassDefinition>();
        foreach (string saveFolder in Directory.GetDirectories(loc))
        {
            Debug.Log(saveFolder);

            string[] subFolders = Directory.GetDirectories(saveFolder);

            // Shuffle the subfolders and pick some
            //System.Random rnd = new System.Random();
            //subFolders = subFolders.OrderBy(c => rnd.Next()).ToArray();
            int i = 0;
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
                LoadGFFFromFile(subFolder + "\\GLOBALVARS.res", defs, "AuroraGlobalVars", compat, ExistsIn.SAVE);
                LoadGFFFromFile(subFolder + "\\PARTYTABLE.res", defs, "AuroraPartyTable", compat, ExistsIn.SAVE);
                LoadGFFFromFile(subFolder + "\\savenfo.res", defs, "AuroraSaveNfo", compat, ExistsIn.SAVE);

                // Load the SAV (in ERF format)
                LoadGFFsFromERF(subFolder + "\\SAVEGAME.sav", defs, compat, ExistsIn.SAVE);
                //if (i >= 2)
                //{
                //    break;
                //}
                //break;
            }
        }

        return defs;
    }

    void LoadGFFsFromRIMs(string moduleDir, Dictionary<string, ClassDefinition> defs, Compatibility compat, ExistsIn existsIn)
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
                LoadRIM(obj, resource, defs, compat, existsIn);
            }
        }
    }
    void LoadGFFsFromERF(string filename, Dictionary<string, ClassDefinition> defs, Compatibility compat, ExistsIn existsIn)
    {
        // We load every module in the game files

        // Find the list of module names
        // TODO: Implement this for KOTOR 2, which uses a different file structure
        //Debug.Log("Loading " + filename);
        ERFObject obj = new ERFObject(filename);

        LoadERFObj(obj, defs, compat, existsIn);
    }

    void LoadGFFsFromBIFs (string dataDir, Dictionary<string, ClassDefinition> defs, Compatibility compat, ExistsIn existsIn)
    {

        // We load every BIF file in the game files

        // Find the list of module names
        // TODO: Implement this for KOTOR 2, which uses a different file structure

        foreach (string filename in Directory.GetFiles(dataDir))
        {
            //Debug.Log("Loading " + filename);
            BIFObject obj = new BIFObject(filename);
            LoadBIF(obj, defs, compat, existsIn);
        }
    }
    
    void LoadGFFFromFile(string location, Dictionary<string, ClassDefinition> defs, string className, Compatibility compat, ExistsIn existsIn)
    {
        using (Stream stream = File.OpenRead(location))
        {
            GFFObject gff = (new GFFLoader(stream)).GetObject();
            LoadGFF(gff, defs, className, compat, existsIn);
        }
    }

    void LoadGFF(GFFObject gff, Dictionary<string, ClassDefinition> defs, string className, Compatibility compat, ExistsIn existsIn)
    {
        if (!defs.ContainsKey(className))
        {
            defs[className] = new ClassDefinition();
        }
        // Update the class definition
        defs[className].AddToDefinition(gff, className, 0, compat, existsIn);
    }

    void LoadRIM(RIMObject obj, RIMObject.Resource resource, Dictionary<string, ClassDefinition> defs, Compatibility compat, ExistsIn existsIn)
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
            LoadGFF(gffObject, defs, className, compat, existsIn);
        }
        catch
        {
            // Just keep going
            Debug.LogWarning("Failed to load " + resource.ResRef);
        }
    }

    void LoadERFObj (ERFObject obj, Dictionary<string, ClassDefinition> defs, Compatibility compat, ExistsIn existsIn)
    {
        foreach ((string resRef, ResourceType resType) in obj.resourceKeys.Keys)
        {
            //Debug.Log("Loading erf object " + resRef);
            LoadERF(obj, resRef, resType, defs, compat, existsIn);
        }
    }

    void LoadERF(ERFObject obj, string resRef, ResourceType resType, Dictionary<string, ClassDefinition> defs, Compatibility compat, ExistsIn existsIn)
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
            LoadERFObj(new ERFObject(stream), defs, compat, existsIn);
            //Debug.Log("Finished loading nested ERF file " + resRef);
        }
        else
        {
            // Load the resource from the ERF
            GFFObject gffObject = new GFFLoader(stream).GetObject();
            // Update the class definition
            LoadGFF(gffObject, defs, className, compat, existsIn);
        }
    }
    void LoadBIF(BIFObject obj, Dictionary<string, ClassDefinition> defs, Compatibility compat, ExistsIn existsIn)
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
                LoadGFF(gffObject, defs, className, compat, existsIn);
            }
            catch
            {
                // Just keep going
                Debug.LogWarning("Failed to load " + resource.ID);
            }
        }
    }

    Dictionary<string, ClassDefinition> CombineDefinitions (Dictionary<string, ClassDefinition> k1Base, Dictionary<string, ClassDefinition> tslBase,
        Dictionary<string, ClassDefinition> k1Saves, Dictionary<string, ClassDefinition> tslSaves)
    {
        Dictionary<string, ClassDefinition> defs = new Dictionary<string, ClassDefinition>();

        HashSet<string> baseTypes = new HashSet<string>();
        baseTypes.UnionWith(k1Base.Keys);
        baseTypes.UnionWith(tslBase.Keys);
        baseTypes.UnionWith(k1Saves.Keys);
        baseTypes.UnionWith(tslSaves.Keys);
        
        foreach (string defName in baseTypes)
        {
            ClassDefinition k1BaseDef = k1Base.ContainsKey(defName) ? k1Base[defName] : null;
            ClassDefinition tslBaseDef = tslBase.ContainsKey(defName) ? tslBase[defName] : null;
            ClassDefinition k1SaveDef = k1Saves.ContainsKey(defName) ? k1Saves[defName] : null;
            ClassDefinition tslSaveDef = tslSaves.ContainsKey(defName) ? tslSaves[defName] : null;

            ClassDefinition def = new ClassDefinition();
            def.CreateDefinition(k1BaseDef, tslBaseDef, k1SaveDef, tslSaveDef);

            defs[defName] = def;
        }

        return defs;
    } 

    class ClassDefinition {
        public string Name;
        public int Level;

        public Compatibility Compat;
        public ExistsIn ExistsIn;

        public Dictionary<string, (string, Compatibility, ExistsIn)> Fields = new Dictionary<string, (string, Compatibility, ExistsIn)>()
        {
            { "structid", ("uint", Compatibility.BOTH, ExistsIn.BOTH) }
        };
        public Dictionary<string, (ClassDefinition, Compatibility, ExistsIn)> Structs = new Dictionary<string, (ClassDefinition, Compatibility, ExistsIn)>();
        public Dictionary<string, (ClassDefinition, Compatibility, ExistsIn)> Lists = new Dictionary<string, (ClassDefinition, Compatibility, ExistsIn)>();

        public void AddToDefinition(GFFObject obj, string name, int level, Compatibility compat, ExistsIn existsIn)
        {
            Name = name;
            Level = level;
            Compat = compat;
            ExistsIn = existsIn;

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
                    ClassDefinition structDef = new ClassDefinition();
                    // Add a struct definition if one does not exist
                    if (!Structs.ContainsKey(child.Label))
                    {
                        Structs[child.Label] = (structDef, compat, existsIn);
                    }

                    // Update the struct definition with this GFFObject
                    if (child.Label == Name)
                    {
                        // We need to append a suffix to the name
                        structDef.AddToDefinition(child, "A" + child.Label.Replace(" ", "") + "2", Level + 1, compat, existsIn);
                    } else
                    {
                        structDef.AddToDefinition(child, "A" + child.Label.Replace(" ", ""), Level + 1, compat, existsIn);
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
                    ClassDefinition listDef;
                    if (!Lists.ContainsKey(child.Label))
                    {
                        listDef = new ClassDefinition();
                        Lists[child.Label] = (listDef, compat, existsIn);
                    } else
                    {
                        (listDef, _, _) = Lists[child.Label];
                    }

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
                        listDef.AddToDefinition(
                            listObject,
                            listObjName,
                            Level + 1,
                            compat,
                            existsIn
                        );
                    }
                } else
                {
                    // Add the field to the list of Fields
                    if (Fields.ContainsKey(child.Label))
                    {
                        continue;
                    }
                    Fields[child.Label] = (child.Value.GetType().Name, compat, existsIn);
                }
            }
        }

        public void CreateDefinition (ClassDefinition k1Base, ClassDefinition tslBase, ClassDefinition k1Save, ClassDefinition tslSave)
        {
            // Determine when the class is created
            if (k1Base == null && tslBase == null)
            {
                ExistsIn = ExistsIn.SAVE;
            } else if (k1Save == null && tslSave == null)
            {
                ExistsIn = ExistsIn.BASE;
            } else
            {
                ExistsIn = ExistsIn.BOTH;
            }

            // Determine which game(s) the class appears in
            if (k1Base == null && k1Save == null)
            {
                Compat = Compatibility.TSL;
            }
            else if (tslBase == null && tslSave == null)
            {
                Compat = Compatibility.KotOR;
            }
            else
            {
                Compat = Compatibility.BOTH;
            }

            // Get the name of the class
            if (tslSave != null)
                Name = tslSave.Name;
            if (tslBase != null)
                Name = tslBase.Name;
            if (k1Save != null)
                Name = k1Save.Name;
            if (k1Base != null)
                Name = k1Base.Name;

            // Create a list of all the fields in all four definitions
            List<string> fieldNames = new List<string>();
            if (k1Base != null)
                fieldNames.AddRange(k1Base.Fields.Keys);
            if (tslBase != null)
                fieldNames.AddRange(tslBase.Fields.Keys);
            if (k1Save != null)
                fieldNames.AddRange(k1Save.Fields.Keys);
            if (tslSave != null)
                fieldNames.AddRange(tslSave.Fields.Keys);

            foreach (string fieldName in fieldNames)
            {
                (Compatibility c, ExistsIn e) = GetMetadata(
                    fieldName,
                    k1Base != null ? k1Base.Fields.ContainsKey(fieldName) : false,
                    tslBase != null ? tslBase.Fields.ContainsKey(fieldName) : false,
                    k1Save != null ? k1Save.Fields.ContainsKey(fieldName) : false,
                    tslSave != null ? tslSave.Fields.ContainsKey(fieldName) : false
                );

                string fieldType = null;
                // Get the field type
                if (tslSave != null && tslSave.Fields.ContainsKey(fieldName))
                {
                    (fieldType, _, _) = tslSave.Fields[fieldName];
                }
                else if (tslBase != null && tslBase.Fields.ContainsKey(fieldName))
                {
                    (fieldType, _, _) = tslBase.Fields[fieldName];
                }
                else if (k1Save != null && k1Save.Fields.ContainsKey(fieldName))
                {
                    (fieldType, _, _) = k1Save.Fields[fieldName];
                }
                else if (k1Base != null && k1Base.Fields.ContainsKey(fieldName))
                {
                    (fieldType, _, _) = k1Base.Fields[fieldName];
                } else
                {
                    // This should never happen
                    throw new Exception();
                }

                Fields[fieldName] = (fieldType, c, e);
            }

            // Create a list of all the lists in all four definitions
            List<string> listNames = new List<string>();
            if (k1Base != null)
                listNames.AddRange(k1Base.Lists.Keys);
            if (tslBase != null)
                listNames.AddRange(tslBase.Lists.Keys);
            if (k1Save != null)
                listNames.AddRange(k1Save.Lists.Keys);
            if (tslSave != null)
                listNames.AddRange(tslSave.Lists.Keys);

            foreach (string listName in listNames)
            {
                (Compatibility c, ExistsIn e) = GetMetadata(
                    listName,
                    k1Base != null ? k1Base.Lists.ContainsKey(listName) : false,
                    tslBase != null ? tslBase.Lists.ContainsKey(listName) : false,
                    k1Save != null ? k1Save.Lists.ContainsKey(listName) : false,
                    tslSave != null ? tslSave.Lists.ContainsKey(listName) : false
                );

                ClassDefinition k1BaseClass = null;
                ClassDefinition k1SaveClass = null;
                ClassDefinition tslBaseClass = null;
                ClassDefinition tslSaveClass = null;
                if (k1Base != null && k1Base.Lists.ContainsKey(listName))
                {
                    (k1BaseClass, _, _) = k1Base.Lists[listName];
                }
                if (k1Save != null && k1Save.Lists.ContainsKey(listName))
                {
                    (k1SaveClass, _, _) = k1Save.Lists[listName];
                }
                if (tslBase != null && tslBase.Lists.ContainsKey(listName))
                {
                    (tslBaseClass, _, _) = tslBase.Lists[listName];
                }
                if (tslSave != null && tslSave.Lists.ContainsKey(listName))
                {
                    (tslSaveClass, _, _) = tslSave.Lists[listName];
                }

                ClassDefinition listDef = new ClassDefinition();
                listDef.CreateDefinition(k1BaseClass, tslBaseClass, k1SaveClass, tslSaveClass);
                Lists[listName] = (listDef, c, e);
            }


            // Create a list of all the lists in all four definitions
            List<string> structNames = new List<string>();
            if (k1Base != null)
                structNames.AddRange(k1Base.Structs.Keys);
            if (tslBase != null)
                structNames.AddRange(tslBase.Structs.Keys);
            if (k1Save != null)
                structNames.AddRange(k1Save.Structs.Keys);
            if (tslSave != null)
                structNames.AddRange(tslSave.Structs.Keys);

            foreach (string structName in structNames)
            {
                (Compatibility c, ExistsIn e) = GetMetadata(
                    structName,
                    k1Base != null ? k1Base.Structs.ContainsKey(structName) : false,
                    tslBase != null ? tslBase.Structs.ContainsKey(structName) : false,
                    k1Save != null ? k1Save.Structs.ContainsKey(structName) : false,
                    tslSave != null ? tslSave.Structs.ContainsKey(structName) : false
                );
                
                ClassDefinition k1BaseClass = null;
                ClassDefinition k1SaveClass = null;
                ClassDefinition tslBaseClass = null;
                ClassDefinition tslSaveClass = null;
                if (k1Base != null && k1Base.Structs.ContainsKey(structName))
                {
                    (k1BaseClass, _, _) = k1Base.Structs[structName];
                }
                if (k1Save != null && k1Save.Structs.ContainsKey(structName))
                {
                    (k1SaveClass, _, _) = k1Save.Structs[structName];
                }
                if (tslBase != null && tslBase.Structs.ContainsKey(structName))
                {
                    (tslBaseClass, _, _) = tslBase.Structs[structName];
                }
                if (tslSave != null && tslSave.Structs.ContainsKey(structName))
                {
                    (tslSaveClass, _, _) = tslSave.Structs[structName];
                }

                ClassDefinition structDef = new ClassDefinition();
                structDef.CreateDefinition(k1BaseClass, tslBaseClass, k1SaveClass, tslSaveClass);
                Structs[structName] = (structDef, c, e);
            }
        }

        (Compatibility, ExistsIn) GetMetadata(string fieldName, bool k1Base,  bool tslBase, bool k1Save, bool tslSave)
        {
            Compatibility c;
            ExistsIn e;

            if (!k1Base && !tslBase)
            {
                // Field is save-only
                e = ExistsIn.SAVE;
            }
            else if (!k1Save && !tslSave)
            {
                // Field is base-only
                e = ExistsIn.BASE;
            }
            else
            {
                // Field is in both base and saves
                e = ExistsIn.BOTH;
            }


            if (!k1Base && !k1Save)
            {
                // Field is k1-only
                c = Compatibility.TSL;
            }
            else if (!tslBase && !tslSave)
            {
                // Field is tsl-only
                c = Compatibility.KotOR;
            }
            else
            {
                // Field is in both games
                c = Compatibility.BOTH;
            }

            return (c, e);
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
                (string fieldType, Compatibility c, ExistsIn e) = Fields[fieldName];
                string attribute = "[GFF(\"" + fieldName + "\", Compatibility." + c.ToString() + ", ExistsIn." + e.ToString() + ")] ";
                definition += TAB + attribute + "public " + fieldType + " " + fieldName.Replace(" ", "");
                if (fieldType == "CExoLocString")
                {
                    definition += " = new CExoLocString()";
                } else if (fieldType == "CExoString")
                {
                    definition += " = new CExoString()";
                }

                definition += ";\n";
            }

            // Add the structs
            if (Structs.Count > 0)
                definition += "\n" + TAB + "// Struct definitions\n";

            foreach (string structName in Structs.Keys)
            {
                (ClassDefinition structDef, Compatibility c, ExistsIn e) = Structs[structName];
                string attribute = "[GFF(\"" + structName + "\", Compatibility." + c.ToString() + ", ExistsIn." + e.ToString() + ")] ";
                definition += TAB + attribute + "public " + structDef.Name + " " + structName.Replace(" ", "") + " = new " + structDef.Name + "();\n";
            }

            // Add the lists
            if (Lists.Count > 0)
                definition += "\n" + TAB + "// List definitions\n";

            foreach (string listName in Lists.Keys)
            {
                (ClassDefinition listDef, Compatibility c, ExistsIn e) = Lists[listName];
                string attribute = "[GFF(\"" + listName + "\", Compatibility." + c.ToString() + ", ExistsIn." + e.ToString() + ")] ";
                definition += TAB + attribute + "public " + "List<" + listDef.Name + "> " + listName.Replace(" ", "") + " = new List<" + listDef.Name + ">();\n";
            }

            if (Structs.Count > 0 || Lists.Count > 0)
                definition += "\n" + TAB + "// Class definitions";

            string classDefinitions = "";

            // For each struct type, add its definition too
            foreach ((ClassDefinition structClass, _, _) in Structs.Values)
            {
                classDefinitions += "\n" + structClass.ToString();
            }
            // For each list type, add its definition too
            foreach ((ClassDefinition listClass, _, _) in Lists.Values)
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
