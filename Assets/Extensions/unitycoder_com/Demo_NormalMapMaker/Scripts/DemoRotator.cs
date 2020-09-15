// this script is only used for rotating the runtime demo scene object

using UnityEngine;
using System.Collections;

namespace unitycoder_demo
{

	public class DemoRotator : MonoBehaviour 
	{

		void Update () 
		{
			transform.Rotate(0,25*Time.deltaTime,0);
		}
	}
}