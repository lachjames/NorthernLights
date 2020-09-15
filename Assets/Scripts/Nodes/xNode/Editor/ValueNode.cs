using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

[CreateNodeMenu("Values/String")]
public class StringNode : Node {

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
public class IntNode : Node
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
}

[CreateNodeMenu("Values/Float")]
public class FloatNode : Node
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