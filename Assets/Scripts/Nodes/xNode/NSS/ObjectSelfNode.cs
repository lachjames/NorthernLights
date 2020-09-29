using AuroraEngine;
using System;

namespace XNode
{
    [CreateNodeMenu("Values/ObjectSelf")]
    [Serializable]
	public class ObjectSelfNode : AuroraNode
	{
		[Output] public AuroraObject output;

		// Use this for initialization
		protected override void Init()
		{
			base.Init();

		}

		// Return the correct value of an output port when requested
		public override object GetValue(NodePort port)
		{
			return StateSystem.stateSystem.GetObjectSelf();
		}
		public override string GetCode()
		{
			return "OBJECT_SELF";
		}

	}
}
