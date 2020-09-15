using System.IO;
using UnityEngine;

namespace AuroraEngine
{
	public class Area : AuroraObject
	{
		public static Area Create(AuroraARE are)
		{
			GameObject gameObject;

			//get the resource reference for this object, which we'll use as it's in-engine name
			string name = are.Tag;

            //add the template component to the new object
            gameObject = new GameObject("Area");

            Area area = gameObject.AddComponent<Area>();
            area.template = are;

			return area;
		}

        public void OnEnter()
        {
            stateManager.RunScript(((AuroraARE)template).OnEnter, this);
        }
        public void OnExit()
        {
            stateManager.RunScript(((AuroraARE)template).OnExit, this);
        }
        public override void OnHeartbeat()
        {
            stateManager.RunScript(((AuroraARE)template).OnHeartbeat, this);
        }
        public override void OnUserDefined()
        {
            stateManager.RunScript(((AuroraARE)template).OnUserDefined, this);
        }
    }
}
