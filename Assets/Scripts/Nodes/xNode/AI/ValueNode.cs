using AuroraEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

[CreateNodeMenu("Values/String")]
public class StringNode : AuroraNode {

	[Output] public string output;
	public string Value;

	// Use this for initialization
	protected override void Init() {
		base.Init();
		
	}

	// Return the correct value of an output port when requested
	public override object GetValue(NodePort port) {
		return Value;
	}
}

[CreateNodeMenu("Values/Int")]
public class IntNode : AuroraNode {

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
}

[CreateNodeMenu("Values/Float")]
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
}

[CreateNodeMenu("Values/ObjectSelf")]
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
}