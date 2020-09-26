using UnityEngine;

namespace AuroraEngine
{
	public class Waypoint : AuroraObject
	{
		public static Waypoint Create (AuroraUTW utw, AuroraGIT.AWaypoint gitData)
		{
			GameObject gameObject;

			//get the resource reference for this object, which we'll use as it's in-engine name
			string name = gitData.Tag;

			//create a new game object and load the model into the scene
			gameObject = new GameObject();
			gameObject.name = name;

			//add the template component to the new object
			Waypoint waypoint = gameObject.AddComponent<Waypoint>();
            waypoint.template = utw;
			waypoint.gitData = gitData;

			return waypoint;
		}
    }
}
