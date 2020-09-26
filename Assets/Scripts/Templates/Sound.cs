using UnityEngine;

namespace AuroraEngine
{
	public class SoundPoint : AuroraObject
	{
		public static SoundPoint Create (AuroraUTS uts, AuroraGIT.ASound gitData)
		{
			GameObject gameObject;

			//get the resource reference for this object, which we'll use as it's in-engine name
			string name = gitData.Tag;

			//create a new game object and load the model into the scene
			gameObject = new GameObject();
			gameObject.name = name;

            //add the template component to the new object
            SoundPoint soundPoint = gameObject.AddComponent<SoundPoint>();
            soundPoint.template = uts;
			soundPoint.gitData = gitData;

			return soundPoint;
		}
    }
}
