using AuroraEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

namespace XNode
{
	[CreateNodeMenu("Values/String")]
    [Serializable]
	public class StringNode : AuroraNode
	{

		[Output] public string output;
		public string Value;

		// Use this for initialization
		protected override void Init()
		{
			base.Init();

		}

		// Return the correct value of an output port when requested
		public override object GetValue(NodePort port)
		{
			return Value;
		}

		public override string GetCode()
		{
			return '"' + Value + '"';
		}
	}

	[CreateNodeMenu("Values/Int")]
    [Serializable]
	public class IntNode : AuroraNode
	{

		[Output] public int output;
		public string Value;

		// Use this for initialization
		protected override void Init()
		{
			base.Init();

		}

		// Return the correct value of an output port when requested
		public override object GetValue(NodePort port)
		{
			return int.Parse(Value);
		}
		public override string GetCode()
		{
			return Value;
		}

	}

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
			return Value;
		}

	}

	[CreateNodeMenu("Values/ObjectSelf")]
    [Serializable]
	public class ObjectSelf : AuroraNode
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
