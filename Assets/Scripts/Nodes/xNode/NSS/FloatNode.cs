using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

namespace XNode
{

    [CreateNodeMenu("Values/Float")]
    [Serializable]
	public class FloatNode : AuroraNode
	{

		[Output] public float output;
		public string Value;

		// Use this for initialization
		protected override void Init()
		{
			base.Init();

		}

		// Return the correct value of an output port when requested
		public override object GetValue(NodePort port)
		{
			return float.Parse(Value);
		}
		public override string GetCode()
		{
			return Value + (Value.EndsWith("f") ? "" : "f");
		}

	}
}
