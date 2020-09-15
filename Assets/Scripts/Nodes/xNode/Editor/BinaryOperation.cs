using AuroraEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using XNode;

[ExecuteInEditMode]
public abstract class BinaryOperation : Node {
	public object x, y;
	public object result;

	// Use this for initialization
	protected override void Init() {
		base.Init();
	}

    public override void OnCreateConnection(NodePort from, NodePort to)
    {
		if (to.node != this)
        {
			return;
        }

		Type t = to.ValueType;

		// Remove all the old ports
		foreach (var p in new List<NodePort>(DynamicPorts))
		{
			RemoveDynamicPort(p);
		}

		AddDynamicInput(t, ConnectionType.Override, TypeConstraint.Inherited, "y");
		AddDynamicOutput(t, ConnectionType.Override, TypeConstraint.Inherited, "result");

		// Change the ports for y and result to 
		base.OnCreateConnection(from, to);
    }
}

[CreateNodeMenu("BinaryOps/Add/String")]
public class AddString : BinaryOperation
{
	[Input] public new string x, y;
	[Output] public new string result;
}

[CreateNodeMenu("BinaryOps/Add/Int")]
public class AddInt : BinaryOperation
{
	[Input] public new int x, y;
	[Output] public new int result;
}

[CreateNodeMenu("BinaryOps/Add/Float")]
public class AddFloat : BinaryOperation
{
	[Input] public new float x, y;
	[Output] public new float result;
}