using AuroraEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class LoadingSystem : MonoBehaviour
{
    public Game targetGame = Game.KotOR;

    public string levelName;
    public int FPSTarget = 60;

    Queue<Action> actions = new Queue<Action>();
    bool locked = false;

    public StateSystem stateManager;
    public DialogSystem dialogManager;
    public MovieSystem movieSystem;
    public GUISystem guiSystem;
    public AISystem aiSystem;
    public CombatSystem combatSystem;
    public MusicSystem musicSystem;

    int maxActions = -1;

    // Start is called before the first frame update
    void Start()
    {
        if (Application.isPlaying)
            Load(levelName);
    }

    void Update ()
    {

    }

    void OnGUI()
    {
        if (locked)
        {
            // Show a loading screen
            GUI.DrawTexture(
                new Rect(0, 0, Screen.width, Screen.height),
                Texture2D.whiteTexture,
                ScaleMode.StretchToFill
            );

            // Draw a progress bar

            float barWidth = Screen.width * 2 / 3;
            float barPaddingW = (Screen.width - barWidth) / 2;

            float barHeight = Screen.height / 8;
            float barPaddingH = (Screen.height - barHeight) * 3 / 4;

            Rect bar = new Rect(
                barPaddingW,
                barPaddingH,
                barWidth * (1 - actions.Count / maxActions),
                barHeight
            );

            GUI.DrawTexture(
                bar,
                Texture2D.redTexture,
                ScaleMode.StretchToFill
            );

            GUI.Label(
                new Rect(Screen.width / 2 - 20, Screen.height / 2 - 20, 40, 40),
                actions.Count.ToString()
            );
        }
    }

    public void Load(string levelName)
    {
        Lock();

        // Load the data for the game and module
        AuroraEngine.Resources.Load(levelName);

        if (Application.isPlaying)
        {
            // Create the player character
            actions.Enqueue(() => CreatePC());

            // The LoadItems coroutine runs every frame
            StartCoroutine("LoadItems");
        } else
        {
            LoadAllAtOnce();
        }
    }

    public void AddAction (Action action)
    {
        actions.Enqueue(action);
    }

    void Lock ()
    {
        locked = true;
    }

    void Unlock ()
    {
        Debug.Log("Unlocking game");
        locked = false;

        stateManager.Initialize();
        dialogManager.Initialize();
        movieSystem.Initialize();
        guiSystem.Initialize();
        aiSystem.Initialize();
        combatSystem.Initialize();
        musicSystem.Initialize();
    }

    public bool IsLocked ()
    {
        return locked;
    }

    IEnumerator LoadItems ()
    {
        while (true)
        {
            if (actions.Count == 0)
            {
                Unlock();
                yield break;
            }

            maxActions = actions.Count > maxActions ? actions.Count : maxActions;
            
            //float maxTime = 1f / FPSTarget;

            //float startTime = Time.time;
            //float frameTime = 0f;
            //while (frameTime < maxTime && actions.Count > 0)
            //{
            // Invoke the action
            Action action = actions.Dequeue();

            try
            {
                action.Invoke();
            } catch (Exception e)
            {
                Debug.LogError(e);
            }
            // Set the frametime
            //frameTime = (Time.time - startTime);
            //}

            // Wait until the next frame now
            yield return new WaitForEndOfFrame();
        }
    }

    void LoadAllAtOnce ()
    {
        Debug.Log("Loading actions");
        foreach (Action action in actions)
        {
            try
            {
                action.Invoke();
            } catch
            {
                Debug.Log("Action failed");
            }
        }

        actions.Clear();
        Unlock();
    }

    AuroraObject CreatePC()
    {
        // Create the PC
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        AuroraObject pcObj = player.AddComponent<Creature>();

        stateManager.PC = pcObj;

        // Set the PC as the leader of the party
        stateManager.party[0] = pcObj;

        AuroraUTC template = new AuroraUTC();

        // Initialize the lists
        template.ClassList = new List<AuroraUTC.AClass>();
        template.Equip_ItemList = new List<AuroraUTC.AEquip_Item>();
        template.FeatList = new List<AuroraUTC.AFeat>();
        template.ItemList = new List<AuroraUTC.AItem>();
        template.SkillList = new List<AuroraUTC.ASkill>();
        template.SpecAbilityList = new List<AuroraUTC.ASpecAbility>();

        // Set some default scripts
        template.ScriptUserDefine = "k_def_userdef01";

        // Temporary stuff; this should be set by character creation later
        template.Gender = 0;
        template.ClassList.Add(new AuroraUTC.AClass()
        {
            structid = 0,
            Class = 0,
            ClassLevel = 1
        });

        pcObj.template = template;

        return pcObj;
    }
}
