using AuroraEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//public class AuroraObject : MonoBehaviour
//{
//    public static Stack<AuroraObject> objectSelfStack = new Stack<AuroraObject>();
    
//    // Main metadata
//    public GFFObject template;
//    public AuroraObjectType auroraObjectType;
//    public string tag;
//    public AuroraLocation location;
//    //public int goldValue;
//    //public int gender;
//    //public bool objectEnabled;

//    // Dictionaries
//    public Dictionary<int, AuroraObject> equipment = new Dictionary<int, AuroraObject>();
//    public Dictionary<string, AuroraObject> possessions = new Dictionary<string, AuroraObject>();
//    // Lists
//    public List<AuroraObject> attackers;

//    public List<AuroraEffect> effects;
//    public List<AuroraAction> actions;

//    public List<int> properties;

//    public List<int> localInts = new List<int>();
//    public List<bool> localBools = new List<bool>();

//    // Ints
//    public int xp;
//    public int gold;
//    public int stackSize;
//    public int creatureSize;
//    public int racialType;
//    public int hitDice;

//    public int lastAttackMode;
//    public int lastAttackAction;
//    public int lastForcePowerUsed;
//    public int lastCombatFeatUsed;
//    public int lastAttackResult;
//    public int wasForcePowerSuccessful;
//    public int whyForcePowerUnsuccessful;

//    public int baseItemType;

//    // Booleans
//    public bool commandable;
//    public bool listening;
//    public bool isDead;
//    public bool locked;
//    public bool open;
//    public bool inConversation;
//    public bool inCombat;
//    public bool escapable;
//    public bool identified;
//    public bool isPoisoned;
//    public bool debilitated;

//    // Interactions
//    public AuroraObject lastDamager;
//    public AuroraObject lastDisarmed;
//    public AuroraObject lastDisturbed;
//    public AuroraObject lastLocked;
//    public AuroraObject lastUnlocked;
//    public AuroraObject lastKiller;
//    public AuroraObject lastAttacker;
//    public AuroraObject lastUsedBy;

//    public AuroraObject lastTriggerer;
//    public AuroraObject lastEntered;
//    public AuroraObject lastExited;

//    // Personal data
//    public AuroraObject lastWeaponUsed;
//    public AuroraObject clickingObject;
//    public AuroraObject attackTarget;
//    public AuroraObject possessor;

//    public AuroraObject(GFFObject template)
//    {
//        this.template = template;
//    }

//    public static AuroraObject GetObjectSelf()
//    {
//        if (objectSelfStack.Count == 0)
//        {
//            return null;
//        }
//        return objectSelfStack.Peek();
//    }

//    public static AuroraObject GetObjectInvalid()
//    {
//        return null;
//    }

//    public static AuroraObject GetObjectTypeInvalid()
//    {
//        return null;
//    }

//    public enum AuroraObjectType
//    {
//        DOOR, PLACEABLE, TRIGGER, AOE, MODULE, AREA, ENCOUNTER, SOUND
//    }
//}