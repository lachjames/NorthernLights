using UnityEngine;

namespace AuroraEngine
{
	public class CameraPoint : AuroraObject
	{
		public static CameraPoint Create (AuroraGIT.ACamera acam)
		{
			GameObject gameObject;

            //get the resource reference for this object, which we'll use as it's in-engine name
            string name = "cam_" + acam.CameraID;

            //create a new game object and load the model into the scene
            gameObject = new GameObject();
			gameObject.name = name;

            //add the template component to the new object
            CameraPoint character = gameObject.AddComponent<CameraPoint>();

            return character;
		}

        public GameObject LoadCamera (string resref)
        {
            GameObject gameObject = Resources.LoadModel(resref);
            gameObject.name = resref;
            gameObject.transform.parent = transform;

            return gameObject;
        }
    }
}
