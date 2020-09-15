using System.IO;
using UnityEngine;

namespace AuroraEngine
{
	public class Placeable : AuroraObject
	{
		private bool isOpen;
        static GUISystem guiSystem;

		public static Placeable Create(AuroraUTP utp)
		{
            if (guiSystem == null)
            {
                guiSystem = GameObject.Find("GUI System").GetComponent<GUISystem>();
            }
			GameObject gameObject;

			//get the resource reference for this object, which we'll use as it's in-engine name
			string name = utp.TemplateResRef;

			//get the appearance row number in placeables.2da
			int appearance = (int)utp.Appearance;

			//get the model name for this appearance id
			string modelRef = Resources.Load2DA("placeables")[appearance, "modelname"];
			if (modelRef == "PLC_Invis") {
				gameObject = new GameObject(name);
			}
			else {
				gameObject = Resources.LoadModel(modelRef);
				gameObject.name = name;
			}

			//add the template component to the new object
			Placeable placeable = gameObject.AddComponent<Placeable>();
            placeable.template = utp;

            LookAtHook hook = gameObject.GetComponentInChildren<LookAtHook>();
            if (hook != null)
            {
                hook.obj = placeable;
            }

            return placeable;
		}

        private void OnMouseDown()
        {
            OpenPlc();
        }
        public override void Selected()
        {
            // TODO: Support other NPCs using the items too
            lastUsedBy = stateManager.PC;
            OnUsed();

            // TODO: Only open if it has items, and never close unless some conditions are met
            // Reference: https://nwnlexicon.com/index.php?title=OnOpen
            if (!isOpen)
            {
                OpenPlc();
            }
        }
        public void OpenPlc()
		{
			isOpen = true;
			gameObject.GetComponent<Animation>().Play("close2open");

            // TODO: Make this work for any party member, not just the PC
            lastOpenedBy = stateManager.PC;
            OnOpen();

            guiSystem.ShowModalWindow(new PlaceableWindow(guiSystem, 0.25f, 0.4f, this));
        }

		public void ClosePlc()
		{
			isOpen = false;
			gameObject.GetComponent<Animation>().Play("open2close");

            OnClosed();
            guiSystem.CloseModalWindow();
		}

        public void OnClosed()
        {
            stateManager.RunScript(((AuroraUTP)template).OnClosed, this);
        }
        public void OnDamaged()
        {
            stateManager.RunScript(((AuroraUTP)template).OnDamaged, this);
        }

        public void OnDeath ()
        {
            stateManager.RunScript(((AuroraUTP)template).OnDeath, this);
        }

        public void OnDisarm ()
        {
            stateManager.RunScript(((AuroraUTP)template).OnDisarm, this);
        }

        public override void OnHeartbeat()
        {
            stateManager.RunScript(((AuroraUTP)template).OnHeartbeat, this);
        }

        public void OnLock()
        {
            stateManager.RunScript(((AuroraUTP)template).OnLock, this);
        }

        public void OnMeleeAttacked()
        {
            stateManager.RunScript(((AuroraUTP)template).OnMeleeAttacked, this);
        }

        public void OnOpen()
        {
            stateManager.RunScript(((AuroraUTP)template).OnOpen, this);
        }

        public void OnSpellCastAt()
        {
            stateManager.RunScript(((AuroraUTP)template).OnSpellCastAt, this);
        }

        public void OnTrapTriggered()
        {
            stateManager.RunScript(((AuroraUTP)template).OnTrapTriggered, this);
        }
        public void OnUnlock()
        {
            stateManager.RunScript(((AuroraUTP)template).OnUnlock, this);
        }
        public override void OnUserDefined()
        {
            stateManager.RunScript(((AuroraUTP)template).OnUserDefined, this);
        }
        public void OnEndDialogue()
        {
            stateManager.RunScript(((AuroraUTP)template).OnEndDialogue, this);
        }
        public void OnInvDisturbed()
        {
            stateManager.RunScript(((AuroraUTP)template).OnInvDisturbed, this);
        }
        public void OnUsed()
        {
            stateManager.RunScript(((AuroraUTP)template).OnUsed, this);
        }
    }
}
