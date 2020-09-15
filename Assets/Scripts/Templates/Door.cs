using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace AuroraEngine
{
	public class Door : AuroraObject
	{
		private bool isOpen;

		public static Door Create(AuroraUTD utd)
		{
			GameObject gameObject;

			//get the resource reference for this object, which we'll use as it's in-engine name
			string name = utd.TemplateResRef;

			//get the appearance row number in genericdoors.2da
			int appearance = utd.GenericType;

			//get the model name for this door id
			string modelRef = Resources.Load2DA("genericdoors")[appearance, "modelname"];
			
			//create a new game object and load the model into the scene
			gameObject = Resources.LoadModel(modelRef);
			gameObject.name = name;

			//add the template component to the new object
			Door door = gameObject.AddComponent<Door>();
			door.template = utd;

            LookAtHook hook = gameObject.GetComponentInChildren<LookAtHook>();
            if (hook != null)
            {
                hook.obj = door;
            }

            return door;
		}

        //void OnMouseDown()
        //{
        //    // Open the door
        //    OpenDoor();
        //    OnOpen();
        //}

        public override void Selected ()
        {
            if (isOpen)
            {
                CloseDoor();
            } else
            {
                OpenDoor();
            }
        }

        public TooltipWindow GetTooltip ()
        {
            return new TooltipWindow(
                150, 150, this,
                new List<AuroraUI.AuroraUIElement>()
                {
                    new AuroraUI.Button(50, 80, "B")
                },
                new List<AuroraUI.AuroraUIElement>()
                {
                    new AuroraUI.Button(50, 80, "L"),
                    new AuroraUI.Button(50, 80, "T")
                },
                new List<AuroraUI.AuroraUIElement>()
                {
                    new AuroraUI.Button(50, 80, "M"),
                    new AuroraUI.Button(50, 80, "X")
                }
            );
        }

        public void OpenDoor()
		{
			isOpen = true;
			gameObject.GetComponent<Animation>().Play("opening1");

            // Make it no longer an obstacle
            GetComponent<NavMeshObstacle>().enabled = false;

            // TODO: Make this work for any party member, not just the PC
            lastOpenedBy = stateManager.PC;
            OnOpen();
		}

		public void CloseDoor()
		{
			isOpen = false;
			gameObject.GetComponent<Animation>().Play("closing1");

            // Make it an obstacle
            GetComponent<NavMeshObstacle>().enabled = true;

            OnClosed();
        }

        public void OnTrapTriggered()
        {
            stateManager.RunScript(((AuroraUTD)template).OnTrapTriggered, this);
        }

        public void OnFailToOpen()
        {
            stateManager.RunScript(((AuroraUTD)template).OnFailToOpen, this);
        }

        public void OnMeleeAttacked()
        {
            stateManager.RunScript(((AuroraUTD)template).OnMeleeAttacked, this);
        }

        public override void OnHeartbeat()
        {
            stateManager.RunScript(((AuroraUTD)template).OnHeartbeat, this);
        }

        public void OnSpellCastAt()
        {
            stateManager.RunScript(((AuroraUTD)template).OnSpellCastAt, this);
        }

        public void OnDamaged()
        {
            stateManager.RunScript(((AuroraUTD)template).OnDamaged, this);
        }

        public void OnOpen()
        {
            stateManager.RunScript(((AuroraUTD)template).OnOpen, this);
        }

        public void OnLock ()
        {
            stateManager.RunScript(((AuroraUTD)template).OnLock, this);
        }

        public void OnUnlock ()
        {
            stateManager.RunScript(((AuroraUTD)template).OnUnlock, this);
        }

        public override void OnUserDefined ()
        {
            stateManager.RunScript(((AuroraUTD)template).OnUserDefined, this);
        }

        public void OnClosed ()
        {
            stateManager.RunScript(((AuroraUTD)template).OnClosed, this);
        }

        public void OnDisarm ()
        {
            stateManager.RunScript(((AuroraUTD)template).OnDisarm, this);
        }

        public void OnClick ()
        {
            stateManager.RunScript(((AuroraUTD)template).OnClick, this);
        }
    }
}
