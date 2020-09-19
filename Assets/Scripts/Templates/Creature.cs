using UnityEditor.UI;
using UnityEngine;
using UnityEngine.AI;

namespace AuroraEngine
{
	public class Creature : AuroraObject
	{
        public GameObject head;

        bool spawned = false;
        bool sawPlayerLastFrame = false;

        DialogSystem dialogSystem;

        public AuroraObject objectSeen;
        public AuroraObject objectHeard;

        public ForcedAttack forcedAttack = null;
		public static Creature Create(AuroraUTC utc, AuroraGIT.ACreature gitData)
		{
            //GameObject gameObject;
			//get the resource reference for this object, which we'll use as it's in-engine name
			string name = utc.TemplateResRef;

			//get the appearance row number in appearance.2da
			int appearance = utc.Appearance_Type;

            string modelType = Resources.From2DA("appearance", appearance, "modeltype");

			//get the model name for this appearance id
			string modelRef = Resources.Load2DA("appearance")[appearance, "modela"];
			if (modelRef == null) {
				modelRef = Resources.Load2DA("appearance")[appearance, "race"];
			}
			string texRef = Resources.Load2DA("appearance")[appearance, "texa"];

            string cubemapRef = Resources.From2DA("appearance", appearance, "envmap");
            if (cubemapRef == "" || cubemapRef == "DEFAULT")
            {
                cubemapRef = null;
            }

			//create a new game object and load the model into the scene
			GameObject gameObject = Resources.LoadModel(modelRef, null, null, cubemapRef);
			gameObject.name = name;

            GameObject headObj = null;
            switch (modelType.ToLower())
            {
                case "b":
                    // Model requires a head
                    int headID = int.Parse(Resources.From2DA("appearance", appearance, "normalhead"));
                    string headName = Resources.From2DA("heads", headID, "head");
                    headObj = Resources.LoadModel(headName, null, gameObject, cubemapRef);
                    break;
                case "f":
                default:
                    // Model includes head
                    break;
            }

            // Add a character controller for movement
            NavMeshAgent agent = gameObject.AddComponent<NavMeshAgent>();

            // Make the creature commandable by default
            utc.Commandable = 1;

			//add the template component to the new object
			Creature creature = gameObject.AddComponent<Creature>();
			creature.template = utc;
            creature.gitData = gitData;

            creature.head = headObj;

            LookAtHook hook = gameObject.GetComponentInChildren<LookAtHook>();
            if (hook != null)
            {
                hook.obj = creature;
            }

            //if (headObj != null)
            //{
            //    Transform headPosition = gameObject.transform.Find("cutscenedummy/rootdummy/torso_g/torsoupr_g/headhook");
            //    character.head.transform.localPosition = headPosition.position - character.head.transform.position;
            //    character.head.transform.localRotation = Quaternion.identity;
            //}

            return creature;
		}

        public override void Initialize () {
            base.Initialize();
            //PlayAnimation("pause1");
        }

        public override void Update()
        {
            if (!initialized)
            {
                return;
            }
            
            // TODO: Make this more inline with what the actual engine does
            if (isDead)
            {
                PlayAnimation("dead");
                return;
            }

            base.Update();

            if (!spawned)
            {
                spawned = true;

                dialogSystem = GameObject.Find("Dialog System").GetComponent<DialogSystem>();
                OnSpawn();
            }

            // Check for 

            // Check for perception of the player
            if (SeesObject(stateManager.PC))
            {
                if (!sawPlayerLastFrame)
                {
                    // Saw the player for the first time
                    lastPerceptionVanished = true;
                    lastPerceived = stateManager.PC;
                    OnNotice();
                    lastPerceived = null;
                } else
                {
                    // Already seen the player
                }
                sawPlayerLastFrame = true;
            } else
            {
                if (sawPlayerLastFrame)
                {
                    // We call this script if the player vanishes too
                    lastPerceptionVanished = false;
                    lastPerceived = stateManager.PC;
                    OnNotice();
                    lastPerceived = null;
                }

                lastPerceived = null;
                sawPlayerLastFrame = false;
            }
        }
        public override void Selected()
        {
            // Start the dialog associated between the PC and this creature
            if (NWScript.GetIsEnemy(this, stateManager.PC) == 0)
            {
                // Do nothing as combat system will take care of this for us
            } else
            {
                // Start a dialog if one exists
                dialogSystem.StartDialog(((AuroraUTC)template).Conversation, stateManager.PC);
            }
        }

        public class ForcedAttack
        {
            public int anim, result, dmg;
        }

        public void TakeDamage (int amount)
        {
            ((AuroraUTC)template).HitPoints -= (short)amount;
            if (amount >= 0)
            {
                OnDamaged();
            }
            if (((AuroraUTC)template).CurrentHitPoints <= 0)
            {
                // Creature has died
                Died();
            }
        }

        public void Died ()
        {
            // Clear the actions queue and stop any more actions from happening (?)
            // TODO: Make commandable actually do something
            actions.Clear();
            ((AuroraUTC)template).Commandable = 0;

            isDead = true;

            PlayAnimation("death");
            OnDeath();
        }

        public void ForceNextAttack (int anim, int result, int dmg)
        {
            // Force the next attack to run with this animation/result/damage
            // combination

            forcedAttack = new ForcedAttack()
            {
                anim = anim,
                result = result,
                dmg = dmg
            };
        }

        public Item GetMainWeapon ()
        {
            AuroraUTC utc = (AuroraUTC)template;
            foreach (AuroraUTC.AEquip_Item equipped in utc.Equip_ItemList)
            {
                if (equipped.structid == 16)
                {
                    // Main weapon is in slot 16
                    string resref = equipped.EquippedRes;
                    Item item = Resources.LoadItem(resref);
                    return item;
                }
            }

            return null;
        }

        public override void OnHeartbeat ()
        {
            stateManager.RunScript(((AuroraUTC)template).ScriptHeartbeat, this);
        }

        public void OnNotice()
        {
            stateManager.RunScript(((AuroraUTC)template).ScriptOnNotice, this);
        }

        public void OnSpellAt()
        {
            stateManager.RunScript(((AuroraUTC)template).ScriptSpellAt, this);
        }

        public void OnAttacked()
        {
            stateManager.RunScript(((AuroraUTC)template).ScriptAttacked, this);
        }

        public void OnDamaged()
        {
            stateManager.RunScript(((AuroraUTC)template).ScriptDamaged, this);
        }

        public void OnDisturbed()
        {
            stateManager.RunScript(((AuroraUTC)template).ScriptDisturbed, this);
        }

        public void OnEndRound()
        {
            stateManager.RunScript(((AuroraUTC)template).ScriptEndRound, this);
        }

        public void OnEndDialogue()
        {
            stateManager.RunScript(((AuroraUTC)template).ScriptEndDialogu, this);
        }

        public void OnDialogue()
        {
            stateManager.RunScript(((AuroraUTC)template).ScriptDialogue, this);
        }

        public void OnSpawn()
        {
            stateManager.RunScript(((AuroraUTC)template).ScriptSpawn, this);
        }

        public void OnRested()
        {
            stateManager.RunScript(((AuroraUTC)template).ScriptRested, this);
        }

        public void OnDeath()
        {
            stateManager.RunScript(((AuroraUTC)template).ScriptDeath, this);
        }

        public override void OnUserDefined()
        {
            stateManager.RunScript(((AuroraUTC)template).ScriptUserDefine, this);
        }

        public void OnBlocked ()
        {
            stateManager.RunScript(((AuroraUTC)template).ScriptOnBlocked, this);
        }
    }
}
