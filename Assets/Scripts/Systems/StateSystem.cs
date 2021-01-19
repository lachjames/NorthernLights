using AuroraEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;

public class StateSystem : MonoBehaviour
{
    public static StateSystem stateSystem;

    public GameObject reflectionProbe;

    public Material TriggerMaterial;

    public LayerMask visionMask;

    GameObject player;

    Dictionary<string, int> globalIntegers = new Dictionary<string, int>();
    Dictionary<string, bool> globalBooleans = new Dictionary<string, bool>();
    Dictionary<string, float> globalFloats = new Dictionary<string, float>();
    Dictionary<string, AuroraLocation> globalLocations = new Dictionary<string, AuroraLocation>();
    Dictionary<string, string> globalStrings = new Dictionary<string, string>();

    public Dictionary<string, List<AuroraObject>> auroraObjects = new Dictionary<string, List<AuroraObject>>();

    public AuroraObject[] party = new AuroraObject[] { null, null, null };

    // Information for the start of the game
    public string startModule = "end_m01aa";

    // General variables used throughout the game
    public AuroraObject PC;
    public int nHour, nMinute, nSecond, nMillisecond;

    public Module currentModule;
    public AuroraARE currentArea;

    public bool soloMode;
    public bool conversationActive;

    public string lastConversation;

    // Variables for the "return to ship" mechanic
    public bool returnShow = false;
    public int returnStrRef = -1;
    public int srReturnQueryStrRef = -1;

    public Dictionary<string, AuroraObject> objects;

    public List<AuroraCommand> delayedCommands = new List<AuroraCommand>();
    public List<List<AuroraCommand>> assignedCommands = new List<List<AuroraCommand>>();
    List<List<AuroraEvent>> events = new List<List<AuroraEvent>>();
    public List<int> scriptVars = new List<int>();
    public List<int> userDefinedEventNumbers = new List<int>();

    public GameState gameState = GameState.LOADING;

    Stack<NCSContext> contexts = new Stack<NCSContext>();

    bool initialized = false;

    public AuroraObject enteringObject, exitingObject;

    // Lists used for "First" and "Next" functions
    List<AuroraObject> persistentObjects;
    List<AuroraEffect> iterEffects;
    List<AuroraObject> areaObjects;

    public bool pauseOnScript;

    public Dictionary<string, Func<AuroraObject, int, int>> scriptOverrides = new Dictionary<string, Func<AuroraObject, int, int>>()
    {
        //{ "k_ai_master", NCSOverride.k_ai_master }
    };

    public enum GameState
    {
        PLAYING, DIALOG, LOADING
    }

    public void Awake()
    {
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!initialized)
        {
            return;
        }
        // Check for delayed commands
        int i = 0;
        while (i < delayedCommands.Count)
        {
            AuroraCommand cmd = delayedCommands[i];
            cmd.curTime += Time.deltaTime;
            if (cmd.curTime >= cmd.delay)
            {
                // Show time
                delayedCommands.RemoveAt(i);
                ExecuteCommand(cmd);
            } else
            {
                i++;
            }
        }
    }

    public void Initialize()
    {
        initialized = true;
        
        StateSystem.stateSystem = this;

        AuroraObject.stateManager = this;

        // Initialize all AuroraObjects
        foreach (List<AuroraObject> objs in auroraObjects.Values)
        {
            foreach (AuroraObject obj in objs)
            {
                obj.Initialize();
            }
        }

        // This is called when we start the module
        // Load the first level
        currentModule = AuroraEngine.Resources.data.module;
        currentArea = currentModule.are;

        // Move the player to the starting position
        GameObject.FindGameObjectWithTag("Player").transform.position = currentModule.entryPosition;

        // Play the background music
        //AudioSource source = GetComponent<AudioSource>();
        //if (currentModule.ambientMusic)
        //{
        //    source.clip = currentModule.ambientMusic;
        //    source.Play();
        //}
        currentModule.area.lastEntered = PC;
        try
        {
            currentModule.OnEnter();
        } catch
        {

        }
    }

    public AuroraObject GetObjectSelf ()
    {
        return contexts.Peek().objectSelf;
    }

    void ExitModule (string moduleName)
    {
        throw new NotImplementedException();
    }


    public void AddObject (string tag, AuroraObject obj)
    {
        //Debug.Log("Adding object with tag " + tag);
        if (!auroraObjects.ContainsKey(tag))
        {
            auroraObjects[tag] = new List<AuroraObject>();
        }

        auroraObjects[tag].Add(obj);
    }

    public void AddEvent (AuroraObject oObject, AuroraEvent evToRun)
    {
        if (events.Count == 0)
        {
            throw new Exception("Cannot add event to empty events list");
        }
        AuroraEvent ev = new AuroraEvent(evToRun.eventType, evToRun.eventArg);
        ev.target = oObject;
        events[events.Count - 1].Add(ev);
    }

    public void RunEvents ()
    {
        if (events.Count == 0)
        {
            throw new Exception("Expected at least one event level here");
        }

        List<AuroraEvent> eventList = events[events.Count - 1];

        foreach (AuroraEvent ev in eventList)
        {
            RunEvent(ev);
        }
    }

    public void RunEvent (AuroraEvent ev)
    {
        //Debug.Log("Running event " + ev.eventType + " on " + ev.target);
        userDefinedEventNumbers.Add(ev.eventArg);
        ev.target.RunEvent(ev.eventType);
        userDefinedEventNumbers.RemoveAt(userDefinedEventNumbers.Count - 1);
    }

    public void RunAssignedCommands()
    {
        if (assignedCommands.Count == 0)
        {
            throw new Exception("Expected at least one event level here");
        }

        List<AuroraCommand> cmdList = assignedCommands[assignedCommands.Count - 1];

        foreach (AuroraCommand cmd in cmdList)
        {
            ExecuteCommand(cmd);
        }
    }


    public AuroraObject GetObjectByTag(string tag, int nth = 0)
    {
        if (tag == "")
        {
            return PC;
        }
        if (!auroraObjects.ContainsKey(tag))
        {
            Debug.Log("Could not find object with tag " + tag);
            return null;
        }

        List<AuroraObject> objects = auroraObjects[tag];
        if (nth >= objects.Count)
        {
            Debug.LogWarning("Found objects with tag " + tag + " but not enough to get item[" + nth + "]");
            return AuroraObject.OBJECT_INVALID;
        }

        //Debug.Log("Found object with tag " + tag + ": " + objects[nth]);
        return objects[nth];
    }

    public AuroraObject GetClosestObjectByTag (string tag, AuroraObject target, int nNth)
    {
        // nNth is 1-based for some reason...
        nNth -= 1;
        
        if (!auroraObjects.ContainsKey(tag))
        {
            return AuroraObject.OBJECT_INVALID;
        }

        List<AuroraObject> objs = new List<AuroraObject>(auroraObjects[tag]);
        if (nNth >= objs.Count)
        {
            return null;
        }

        objs.Sort(
            (x, y) => Vector3.Distance(target.transform.position, x.transform.position).CompareTo(Vector3.Distance(target.transform.position, y.transform.position))
        );

        return objs[nNth];
    }

    public void NewGameGlobals()
    {
        // Initialise the globals from the 2da file
        _2DAObject global2da = AuroraEngine.Resources.Load2DA("globalcat");
        for (int i = 0; i < global2da.data.Count; i++)
        {
            string globalName = global2da[i, "name"];
            string globalType = global2da[i, "type"];

            switch (globalType)
            {
                case "Number":
                    globalIntegers[globalName] = 0;
                    break;
                case "Boolean":
                    globalBooleans[globalName] = false;
                    break;
                case "String":
                    globalStrings[globalName] = "";
                    break;
                case "Location":
                    globalLocations[globalName] = new AuroraLocation();
                    break;
                default:
                    throw new Exception("Invalid global type " + globalType + " found");
            }
        }
    }

    int Execute (AuroraObject caller, NCSScript script, NCSContext context, int scriptVar, bool isConditional = false)
    {
        Debug.Log("Executing script" + script.scriptName);
        LoggedEvents.Log("Run Script", script.scriptName);

        if (pauseOnScript)
        {
            Debug.Log("Pausing before script " + script.scriptName);
            Debug.Break();
        }

        // Add a new level of nesting to ObjectSelfStack and events
        events.Add(new List<AuroraEvent>());
        assignedCommands.Add(new List<AuroraCommand>());
        contexts.Push(context);
        scriptVars.Add(scriptVar);

        context.objectSelf = caller;

        int value = -1;

        //try
        //{
            if (isConditional)
            {
                value = script.RunConditional(context);
            }
            else
            {
                script.Run(context);
            }
        //}
        //catch (Exception e)
        //{
        //    CreateStackTrace();
        //    Debug.LogError(e.Message + "\n" + e.Source + "\n" + e.StackTrace + "\n " + e.InnerException);
        //}

        RunEvents();
        RunAssignedCommands();

        scriptVars.RemoveAt(scriptVars.Count - 1);
        contexts.Pop();
        assignedCommands.RemoveAt(assignedCommands.Count - 1);
        events.RemoveAt(events.Count - 1);

        LoggedEvents.Log("Finished Script", script.scriptName);

        return value;
    }

    void CreateStackTrace ()
    {
        List<NCSContext> copiedContexts = new List<NCSContext>();
        foreach (NCSContext ctx in contexts)
        {
            copiedContexts.Add(ctx.Copy(ctx.GetPC()));
        }

        NCSTrace trace = new NCSTrace()
        {
            contexts = copiedContexts
        };

        NCSTrace.traces.Add(trace);
    }

    public void RunScript(string resref, AuroraObject caller, int scriptVar=-1)
    {
        //Debug.Log("Running script " + resref + " with OBJECT_SELF=" + caller);
        // TODO: Figure out what to do with "scriptVar"
        if (resref == null)
        {
            return;
        }
        if (resref == "")
        {
            // This is not referring to a script, so just return
            return;
        }

        if (scriptOverrides.ContainsKey(resref))
        {
            scriptOverrides[resref](caller, scriptVar);
            return;
        }

        NCSScript script = AuroraEngine.Resources.LoadScript(resref.Replace("\"", ""));
        if (script == null)
        {
            Debug.LogWarning("Could not find script " + resref);
            return;
        }
        NCSContext context = new NCSContext();

        Execute(caller, script, context, scriptVar);
    }

    public int RunConditionalScript(string resref, AuroraObject caller)
    {
        if (scriptOverrides.ContainsKey(resref))
        {
            return scriptOverrides[resref](caller, -1);
        }

        NCSScript script = AuroraEngine.Resources.LoadScript(resref.Replace("\"", ""));

        if (script == null)
        {
            Debug.LogWarning("Conditional script " + resref + " not found");
            return 0;
        }

        NCSContext context = new NCSContext();

        Debug.Log("Running conditional script " + resref);
        return Execute(caller, script, context, -1, true);
    }

    //public AuroraCreature CreatePC()
    //{
    //    return null;
    //    //return new AuroraCreature(null);
    //}

    //public AuroraModule CreateObject(Module mod)
    //{
    //    // Create an AuroraObject from a module
    //    AuroraModule module = new AuroraModule(null);
    //    module.SetModule(mod);
    //    module.lastEntered = PC;

    //    return module;
    //}

    //public AuroraObject CreateObject(GFFObject template, AuroraObject.AuroraObjectType auroraType)
    //{
    //    // Create an AuroraObject from a GFF template
    //    //switch (auroraType)
    //    //{
    //    //    case AuroraObject.AuroraObjectType.DOOR:
    //    //        return new AuroraDoor(template);
    //    //    case AuroraObject.AuroraObjectType.PLACEABLE:
    //    //        return new AuroraPlaceable(template);
    //    //    case AuroraObject.AuroraObjectType.TRIGGER:
    //    //        return new AuroraTrigger(template);
    //    //    case AuroraObject.AuroraObjectType.AOE:
    //    //        return new AuroraAOE(template);
    //    //    case AuroraObject.AuroraObjectType.MODULE:
    //    //        throw new Exception("Modules can only be made with CreateObject(Module mod)");
    //    //    case AuroraObject.AuroraObjectType.AREA:
    //    //        throw new Exception("Areas not yet implemented");
    //    //    case AuroraObject.AuroraObjectType.ENCOUNTER:
    //    //        return new AuroraEncounter(template);
    //    //    case AuroraObject.AuroraObjectType.SOUND:
    //    //        return new AuroraSound(template);
    //    //}
    //    return null;
    //}
    public AuroraObject CreateObject(int nObjectType, string sTemplate, AuroraLocation lLocation, int bUseAppearAnimation)
    {
        Vector3 pos = new Vector3(
            lLocation.position.x,
            lLocation.position.z,
            lLocation.position.y    
        );
        
        // TODO: Implement appear animation
        switch ((ObjectType)nObjectType)
        {
            case ObjectType.CREATURE:
                Creature creature = AuroraEngine.Resources.LoadCreature(sTemplate, null);
                creature.gameObject.transform.position = pos;
                creature.transform.SetParent(GameObject.Find("Creatures").transform);
                return creature;
            case ObjectType.PLACEABLE:
                Placeable placeable = AuroraEngine.Resources.LoadPlaceable(sTemplate, null);
                placeable.gameObject.transform.position = pos;
                placeable.transform.SetParent(GameObject.Find("Placeables").transform);
                return placeable;
            default:
                Debug.LogWarning("CreateObject not yet implemented for " + (ObjectType)nObjectType);
                break;
        }

        throw new Exception("Failed to create object of type " + (ObjectType)nObjectType);
    }

    public void LoadGlobals()
    {
        // Initialise the globals from a save file
        throw new NotImplementedException();
    }

    public void SetGlobalInteger(string name, int value)
    {
        globalIntegers[name] = value;
    }

    public int GetGlobalInteger(string name)
    {
        if (!globalIntegers.ContainsKey(name))
        {
            globalIntegers[name] = 0;
        }
        return globalIntegers[name];
    }

    public void SetGlobalBoolean(string name, bool value)
    {
        globalBooleans[name] = value;
    }

    public bool GetGlobalBoolean(string name)
    {
        if (!globalBooleans.ContainsKey(name))
        {
            globalBooleans[name] = false;
        }

        return globalBooleans[name];
    }

    public void SetGlobalFloat(string name, float value)
    {
        globalFloats[name] = value;
    }

    public float GetGlobalFloat(string name)
    {
        if (!globalFloats.ContainsKey(name))
        {
            globalFloats[name] = 0.0f;
        }

        return globalFloats[name];
    }

    public void SetGlobalString(string name, string value)
    {
        globalStrings[name] = value;
    }

    public string GetGlobalString(string name)
    {
        return globalStrings[name];
    }

    public void SetGlobalLocation(string name, AuroraLocation value)
    {
        globalLocations[name] = value;
    }

    public AuroraLocation GetGlobalLocation(string name)
    {
        return globalLocations[name];
    }

    public void ExecuteCommand(AuroraCommand cmd)
    {
        // Run the script with context = cmd.context
        //Debug.Log("Running command from script " + cmd.context.script.scriptName + " on " + cmd.obj);
        Execute(cmd.obj, cmd.context.script, cmd.context, -1);
    }

    public void AssignCommand (AuroraObject obj, NCSContext ctx)
    {
        //Debug.Log("Assigning command to " + obj);
        assignedCommands.Last().Add(new AuroraCommand()
        {
            obj = obj,
            context = ctx
        });
    }

    public void DelayCommand(AuroraObject owner, float delay, NCSContext context)
    {
        AuroraCommand cmd = new AuroraCommand();
        cmd.obj = owner;
        cmd.context = context;
        cmd.delay = delay;

        if (owner == null)
        {
            throw new Exception("Cannot delay command on a null object");
        }

        delayedCommands.Add(cmd);
    }

    public AuroraObject Nearest (AuroraObject from, Type t, int nth)
    {
        List<AuroraObject> objs = new List<AuroraObject>();
        foreach (List<AuroraObject> list in auroraObjects.Values)
        {
            foreach (AuroraObject obj in list)
            {
                if (obj.GetType() == t || obj.GetType().IsSubclassOf(t))
                {
                    objs.Add(obj);
                }
            }
        }
        
        if (nth >= objs.Count)
        {
            return null;
        }

        objs.Sort(
            (x, y) => Vector3.Distance(from.transform.position, x.transform.position).CompareTo(Vector3.Distance(from.transform.position, y.transform.position))
        );

        return objs[nth];
    }

    public AuroraObject Nearest(AuroraLocation loc, Type t, int nth)
    {
        List<AuroraObject> objs = new List<AuroraObject>();
        foreach (List<AuroraObject> list in auroraObjects.Values)
        {
            foreach (AuroraObject obj in list)
            {
                if (obj.GetType() == t || obj.GetType().IsSubclassOf(t))
                {
                    objs.Add(obj);
                }
            }
        }

        if (nth >= objs.Count)
        {
            return null;
        }

        objs.Sort(
            (x, y) => Vector3.Distance(loc.GetVector(), x.transform.position).CompareTo(Vector3.Distance(loc.GetVector(), y.transform.position))
        );

        return objs[nth];
    }


    public class AuroraCommand {
        public AuroraObject obj;
        public NCSContext context;
        public float delay, curTime;
    }

    public AuroraObject FirstPersistentObject(AuroraObject oPersistentObject, int nResidentObjectType, int nPersistentZone)
    {
        MeshCollider mc = oPersistentObject.GetComponent<MeshCollider>();

        persistentObjects = new List<AuroraObject>();

        foreach (List<AuroraObject> list in auroraObjects.Values)
        {
            foreach (AuroraObject obj in list)
            {
                Vector3 objPos = obj.transform.position;
                if (mc.ClosestPoint(objPos) == objPos)
                {
                    // Object is inside collider
                    persistentObjects.Add(obj);
                }
            }
        }

        return NextPersistentObject();
    }

    public AuroraObject NextPersistentObject()
    {
        if (persistentObjects.Count == 0)
        {
            return null;
        }
        AuroraObject toReturn = persistentObjects[0];
        persistentObjects.RemoveAt(0);
        return toReturn;
    }

    public AuroraEffect GetFirstEffect (AuroraObject target)
    {
        iterEffects = new List<AuroraEffect>(target.effects);
        return GetNextEffect();
    }

    public AuroraEffect GetNextEffect ()
    {
        if (iterEffects.Count == 0)
        {
            return null;
        }

        AuroraEffect effect = iterEffects[0];
        iterEffects.RemoveAt(0);
        return effect;
    }

    public AuroraObject GetFirstObjectInArea (int filter)
    {
        Type filterType = NWScript.objectTypes[filter];
        areaObjects = new List<AuroraObject>();
        foreach (List<AuroraObject> list in auroraObjects.Values)
        {
            foreach (AuroraObject obj in list)
            {
                if (obj.GetType() == filterType || obj.GetType().IsSubclassOf(filterType))
                {
                    areaObjects.Add(obj);
                }
            }
        }

        return GetNextObjectInArea();
    }

    public AuroraObject GetNextObjectInArea ()
    {
        if (areaObjects.Count == 0)
        {
            return null;
        }

        AuroraObject obj = areaObjects[0];
        areaObjects.RemoveAt(0);
        return obj;
    }

    public void SpeakString(string sStringToSpeak, int nTalkVolume)
    {
        Debug.Log("Speaking string " + sStringToSpeak + " with volume " + nTalkVolume);
    }
}

public static class LoggedEvents
{
    public static List<LogEvent> events = new List<LogEvent>();

    public static void DrawGUI ()
    {
        using (new GUILayout.VerticalScope())
        {
            foreach (LogEvent e in events)
            {
                using (new GUILayout.HorizontalScope())
                {
                    GUILayout.Label(e.name, GUILayout.Width(100));
                    GUILayout.Label(e.desc);
                }
            }
        }
    }

    public static void Log(string name, string desc)
    {
        events.Add(new LogEvent() {
            name = name,
            desc = desc
        });
    }
}

public class LogEvent
{
    public string name, desc;
}