using UnityEngine;

namespace AuroraEngine
{
	public class Trigger : AuroraObject
	{
		public static Trigger Create (AuroraUTT utt)
		{
			GameObject gameObject;

			//get the resource reference for this object, which we'll use as it's in-engine name
			string name = utt.TemplateResRef;

			//create a new game object and load the model into the scene
			gameObject = new GameObject();
			gameObject.name = name;

			//add the template component to the new object
			Trigger character = gameObject.AddComponent<Trigger>();
            character.template = utt;

			return character;
		}

        private void OnTriggerEnter(Collider other)
        {
            AuroraObject enteringObject = other.GetComponent<AuroraObject>();
            
            lastEntered = enteringObject;
            OnEnter();
        }

        private void OnTriggerExit(Collider other)
        {
            AuroraObject exitingObject = other.GetComponent<AuroraObject>();
            
            lastExited = exitingObject;
            OnExit();
        }

        public override void OnHeartbeat()
        {
            stateManager.RunScript(((AuroraUTT)template).ScriptHeartbeat, this);
        }
        public void OnEnter()
        {
            stateManager.RunScript(((AuroraUTT)template).ScriptOnEnter, this);
        }
        public void OnExit()
        {
            stateManager.RunScript(((AuroraUTT)template).ScriptOnExit, this);
        }
        public override void OnUserDefined()
        {
            stateManager.RunScript(((AuroraUTT)template).ScriptUserDefine, this);
        }

        public void OnDisarm ()
        {
            stateManager.RunScript(((AuroraUTT)template).OnDisarm, this);
        }
        public void OnTrapTriggered ()
        {
            stateManager.RunScript(((AuroraUTT)template).OnTrapTriggered, this);
        }
        public void OnClick ()
        {
            stateManager.RunScript(((AuroraUTT)template).OnClick, this);
        }
    }
}
