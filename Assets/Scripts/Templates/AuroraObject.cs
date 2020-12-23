using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Networking;

namespace AuroraEngine
{
    public enum ObjectType
    {
        ALL = 32767,
        AOE = 16,
        CREATURE = 1,
        DOOR = 8,
        ENCOUNTER = 256,
        INVALID = 32767,
        ITEM = 2,
        PLACEABLE = 64,
        STORE = 128,
        TILE = 512,
        TRIGGER = 4,
        WAYPOINT = 32
    }

    [SelectionBase]
    public class AuroraObject : MonoBehaviour
	{
        public string resref;

        public float timeSinceHeartbeat = 0f;

        public int gitIndex;
        public Animation animation;
        public string curAnim = "";
        public bool animLoop;

        public static AuroraObject OBJECT_INVALID = null;

        public static StateSystem stateManager;
        //public static Stack<AuroraObject> ObjectSelfStack = new Stack<AuroraObject>();

        public AuroraStruct template, gitData;

        float actionTimer = 0f;

        // Main metadata
        public string aurora_tag;
        public AuroraObjectType auroraObjectType;
        public AuroraLocation location;
        //public int goldValue;
        //public int gender;
        //public bool objectEnabled;

        // Dictionaries
        public Dictionary<int, AuroraObject> equipment = new Dictionary<int, AuroraObject>();
        public Dictionary<string, AuroraObject> possessions = new Dictionary<string, AuroraObject>();
        // Lists
        public List<AuroraObject> attackers = new List<AuroraObject>();

        public List<AuroraEffect> effects = new List<AuroraEffect>();
        public List<AuroraAction> actions = new List<AuroraAction>();

        public List<int> properties = new List<int>();

        public int[] localInts = new int[128];
        public bool[] localBools = new bool[128];

        // Strings
        public string listenPattern;
        
        // Ints
        public int xp;
        public int gold;
        public int stackSize;
        public int creatureSize;
        public int racialType;
        public int hitDice;

        public int lastAttackMode;
        public int lastAttackAction;
        public int lastForcePowerUsed;
        public int lastCombatFeatUsed;
        public int lastAttackResult;
        public int wasForcePowerSuccessful;
        public int whyForcePowerUnsuccessful;

        public int baseItemType;

        public int listenNumber;

        // Booleans
        public bool listening;
        public bool isDead;
        public bool locked;
        public bool open;
        public bool inConversation;
        public bool inCombat;
        public bool escapable;
        public bool identified;
        public bool isPoisoned;
        public bool debilitated;
        public bool isEncounterCreature;
        public bool lastPerceptionVanished;
        public bool lockHeadFollowInDialog; // TODO: Make this actually do something?
        // Interactions
        public AuroraObject lastDamager;
        public AuroraObject lastDisarmed;
        public AuroraObject lastDisturbed;
        public AuroraObject lastLocked;
        public AuroraObject lastUnlocked;
        public AuroraObject lastKiller;
        public AuroraObject lastAttacker;
        public AuroraObject lastUsedBy;

        public AuroraObject lastTriggerer;
        public AuroraObject lastEntered;
        public AuroraObject lastExited;

        public AuroraObject lastPerceived;

        // Personal data
        public AuroraObject lastEquipped;
        public AuroraObject lastWeaponUsed;
        public AuroraObject clickingObject;
        public AuroraObject possessor;
        public AuroraObject lastHostileTarget;
        public AuroraObject lastHostileActor;

        // Combat targets
        public AuroraObject attackTarget;
        public AuroraObject attemptedAttackTarget;
        public AuroraObject spellTarget;
        public AuroraObject attemptedSpellTarget;


        public AuroraObject lastOpenedBy;
        public float bearing { get { return transform.rotation.eulerAngles.y * Mathf.Deg2Rad * -1; } }
        //public Vector2 orientation { get { return new Vector2(Mathf.Atan(bearing) * -1, 1).normaized; } }

        public bool initialized = false;

        public void Awake()
        {
            if (stateManager == null)
            {
                stateManager = GameObject.Find("State System").GetComponent<StateSystem>();
            }
        }

        // Start is called before the first frame update
        public virtual void Initialize()
        {
            // Add a random offset to the time since heartbeat, to make the heartbeats not
            // all run on the same frame
            timeSinceHeartbeat += UnityEngine.Random.Range(0f, 6f);
            initialized = true;

            animation = GetComponent<Animation>();
            if (animation == null)
            {
                animation = GetComponentInParent<Animation>();
            }
            if (animation == null)
            {
                animation = GetComponentInChildren<Animation>();
            }
        }

        public virtual void Update()
        {
            if (!initialized)
            {
                return;
            }

            timeSinceHeartbeat += Time.deltaTime;
            if (timeSinceHeartbeat > 6f)
            {
                //Debug.Log("Calling OnHeartbeat on " + gameObject.name);
                timeSinceHeartbeat -= 6f;
                OnHeartbeat();
            }

            if (curAnim != "")
            {
                if (animation.GetClip(curAnim))
                {
                    animation.CrossFade(curAnim);
                } else if (animation.GetClip("c" + curAnim)) {
                    animation.CrossFade("c" + curAnim);
                }
            }
            actionTimer += Time.deltaTime;

            if (actionTimer > 6f)
            {
                actionTimer -= 6f;
            }

            RunOneAction();
        }

        void RunOneAction ()
        {
            if (actions.Count == 0)
            {
                return;
            }

            AuroraAction action = actions[0];
            //Debug.Log("Found action of type " + action.GetType().Name + " on " + gameObject.name);

            // Check if the action should not run
            if (action.IsFinishedBefore())
            {
                actions.RemoveAt(0);
                return;
            }

            // Run the action for this frame
            try
            {
                action.RunAction();
            }
            catch (NotImplementedException e)
            {
                // This is ok
                Debug.Log("Skipping not-implemented action: " + e);
                actions.RemoveAt(0);
                return;
            }

            // Check if the action should now be deleted
            if (action.IsFinishedAfter())
            {
                actions.RemoveAt(0);
                return;
            }
        }

        public void AddAction (AuroraAction action)
        {
            // TODO: Implement commandable check for all the types that have it
            //if (GetType() == typeof(Creature))
            //{
            //    AuroraUTC utc = (AuroraUTC)template;
            //    if (utc.Commandable == 0)
            //    {
            //        // Cannot add the action
            //        return;
            //    }
            //}

            actions.Add(action);
        }

        // *** Determine whether this object can see the target object ***
        public bool SeesObject (AuroraObject target, float forwardOffset = 0f)
        {
            // Start at our position, plus a vertical offset and a forward offset (so the object doesn't
            // detect itself)
            Vector3 startPos = transform.position + forwardOffset * transform.forward + 1.5f * Vector3.up;
            Vector3 direction = target.transform.position - transform.position;

            // Raycast and see if we hit the target
            Ray ray = new Ray(startPos, direction);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, float.PositiveInfinity, stateManager.visionMask))
            {
                if (forwardOffset == 0)
                {
                    Debug.DrawLine(startPos, hit.point, Color.red);
                }

                // Check if we hit ourselves
                if (IsParent(hit.transform.gameObject, gameObject))
                {
                    // We hit ourselves
                    return SeesObject(target, hit.distance + 0.01f);
                }

                // Check if we hit the target
                if (IsParent(hit.transform.gameObject, target.gameObject))
                {
                    //Debug.Log("Raycast from " + name + " hit " + target.name);
                    return true;
                }

                // We hit something which was not the target
                //Debug.Log("Raycast from " + name + " hit non-target " + hit.transform.name);
                return false;
            }

            //Debug.Log("Raycast from " + name + " did not hit anything");
            // We hit nothing so return false
            return false;
        }

        bool IsParent(GameObject child, GameObject parent)
        {
            // Determines whether parent is in the "parenting" chain of obj
            if (child == parent)
            {
                // Reached the parent
                return true;
            }

            if (child.transform.parent == null)
            {
                // Reached the root and did not find parent
                return false;
            }

            return IsParent(child.transform.parent.gameObject, parent);
        }

        public virtual void PlayAnimation (string anim, bool loop = false)
        {
            //Debug.Log("Playing animation " + anim);
            curAnim = anim;
            animLoop = loop;
        }

        public void PlayAnimation(int anim, bool loop = false)
        {
            Debug.Log("Loading animation " + anim);
            // Find the animation name by the index in the  2DA file animations.2da

            if (!AnimationMap.DialogAnimationMap.ContainsKey(anim - 10000))
            {
                Debug.LogWarning("Could not find animation " + anim);
                return;
            }
            PlayAnimation(AnimationMap.DialogAnimationMap[anim - 10000], loop);
        }


        public virtual void Selected ()
        {
            throw new NotImplementedException("Selected() not implemented yet");
        }

        public void RunEvent (AuroraEvent.EventType t)
        {
            switch (t)
            {
                case AuroraEvent.EventType.UserDefinedEvent:
                    OnUserDefined();
                    break;
            }
        }

        public virtual void OnHeartbeat ()
        {

        }
        public virtual void OnUserDefined()
        {
            throw new NotImplementedException();
        }

        //public static AuroraObject GetObjectSelf()
        //{
        //    if (ObjectSelfStack.Count == 0)
        //    {
        //        throw new Exception("Invalid ObjectSelfStack found");
        //    }

        //    if (ObjectSelfStack.Peek() == null)
        //    {
        //        throw new Exception("Null object found");
        //    }

        //    return ObjectSelfStack.Peek();
        //}

        public static AuroraObject GetObjectInvalid()
        {
            return null;
        }

        public static AuroraObject GetObjectTypeInvalid()
        {
            return null;
        }

        public enum AuroraObjectType
        {
            CREATURE, DOOR, PLACEABLE, TRIGGER, AOE, MODULE, AREA, ENCOUNTER, SOUND, STORE, ITEM
        }
    }

    public class GFFAttribute : System.Attribute
    {
        public string name;
        public Game game;
        public Compatibility compatibility;
        public ExistsIn existsIn;

        public GFFAttribute (string name, Compatibility compat = Compatibility.BOTH, ExistsIn exists = ExistsIn.BOTH)
        {
            this.name = name;
            this.compatibility = compat;
            this.existsIn = exists;
        }
    }

    public static class AnimationMap
    {
        public static Dictionary<int, string> DialogAnimationMap = new Dictionary<int, string>()
        {
            {6, "dead" },
            {28, "taunt" },
            {29, "greeting" },
            {30, "listen" },
            {33, "worship" },
            {34, "salute" },
            {35, "now" },
            {38, "tlknorm" }, // Talk_Normal
            {39, "tlkplead" },
            {40, "tlkforce" },
            {41, "tlklaugh" },
            {42, "tlksad" },
            {44, "victory" },
            {55, "" }, // Scratch head?
            {58, "drunk" },
            {70, "inject" },
            {120, "flirt" },
            {121, "usecomplp" },
            {124, "horror" },
            {125, "usecomp" },
            {126, "persuade" },
            {127, "activate" },
            {137, "sleep" },
            {139, "prone" },
            {148, "pause1" }, // Ready?
            {149, "pause1" },
            {150, "choke" }, // "Choked" Choke or choking animation?
            {154, "talkinj" },
            {155, "listeninj" },
            {163, "Kneel_Talk_Angry" }, // Not sure what this is
            {164, "Kneel_Talk_Sad" }
        };
    }
}
