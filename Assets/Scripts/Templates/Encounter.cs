using UnityEngine;

namespace AuroraEngine
{
	public class Encounter : AuroraObject
	{
		public static Encounter Create(AuroraUTE ute, AuroraGIT.AEncounter gitData)
		{
			GameObject gameObject;

			//get the resource reference for this object, which we'll use as it's in-engine name
			string name = ute.TemplateResRef;

            //create a new game object and load the model into the scene
            gameObject = new GameObject();
			gameObject.name = name;

            //add the template component to the new object
            Encounter character = gameObject.AddComponent<Encounter>();
            character.template = ute;
            character.gitData = gitData;

			return character;
        }
        private void OnTriggerEnter(Collider other)
        {
            AuroraObject enteringObject = other.GetComponent<AuroraObject>();
            lastEntered = enteringObject;

            OnEntered();
        }

        private void OnTriggerExit(Collider other)
        {
            AuroraObject exitingObject = other.GetComponent<AuroraObject>();
            lastExited = exitingObject;

            OnExit();
        }

        public void OnEntered ()
        {
            stateManager.RunScript(((AuroraUTE)template).OnEntered, this);
        }

        public void OnExit ()
        {
            stateManager.RunScript(((AuroraUTE)template).OnExit, this);
        }

        public void OnExhausted ()
        {
            stateManager.RunScript(((AuroraUTE)template).OnExhausted, this);
        }

        public override void OnHeartbeat ()
        {
            stateManager.RunScript(((AuroraUTE)template).OnHeartbeat, this);
        }

        public override void OnUserDefined ()
        {
            stateManager.RunScript(((AuroraUTE)template).OnUserDefined, this);
        }
    }
}
