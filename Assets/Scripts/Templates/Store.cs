using UnityEngine;

namespace AuroraEngine
{
	public class Store : AuroraObject
	{
		public static Store Create (AuroraUTM utm, AuroraGIT.AStore gitData)
		{
			GameObject gameObject;

			//get the resource reference for this object, which we'll use as it's in-engine name
			string name = utm.ResRef;

			//create a new game object and load the model into the scene
			gameObject = new GameObject();
			gameObject.name = name;

            //add the template component to the new object
            Store store = gameObject.AddComponent<Store>();
            store.template = utm;
			store.gitData = gitData;

			return store;
		}

        public void OnOpenStore()
        {
            stateManager.RunScript(((AuroraUTM)template).OnOpenStore, this);
        }
    }
}
