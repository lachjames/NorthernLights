using AuroraEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using XNode;

[Serializable]
public class Conditional
{
	public static Conditional Trigger = new Conditional();
}

public class OnBeginScript : Node
{
	[Output] public Conditional onBegin;
}

[ExecuteInEditMode]
public class ConditionalNode : ExecutableNode
{
	[Input] public int input;
	[Output] public Conditional onTrue;
	[Output] public Conditional onFalse;

	// Use this for initialization
	protected override void Init() {
		base.Init();
	}

	// Return the correct value of an output port when requested
	public override object GetValue(NodePort port) {
		return null;
	}
}