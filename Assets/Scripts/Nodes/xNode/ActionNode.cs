using AuroraEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using XNode;

public class ExecutableNode : AuroraNode
{
	[Input] public Conditional trigger;
	[Output] public Conditional after;

	public AuroraNode GetAfter ()
    {
		Debug.Log("Getting next node");

		foreach (NodePort port in Outputs)
        {
			if (port.fieldName == "after")
            {
				if (port.Connection == null)
                {
					Debug.Log("Port is not connected, so execution terminates here");
					return null;
                }
				Debug.Log("Connecting to the next node");
				return (AuroraNode)port.Connection.node;
            }
        }

		throw new Exception("Did not find after");
    }

    public override AuroraNode Execute()
    {
		return GetAfter();
    }
}

public abstract class ComputeNode: ExecutableNode
{
	public abstract Type ParentClass { get; }

	public string ActionName;
	string lastActionName;

	object returnValue;

	// Use this for initialization
	protected override void Init()
	{
		base.Init();

	}

	// Return the correct value of an output port when requested
	public override object GetValue(NodePort port)
	{
		return returnValue;
	}

	public void UpdateAction()
	{
		if (lastActionName == ActionName)
		{
			return;
		}

		// If we reach this point, the action name has changed
		lastActionName = ActionName;

		// Remove all the old ports
		foreach (var p in new List<NodePort>(DynamicPorts))
		{
			RemoveDynamicPort(p);
		}

		// Find the MethodInfo for the action
		MethodInfo m = ParentClass.GetMethod(ActionName);

		// Create ports for the inputs
		foreach (ParameterInfo p in m.GetParameters())
		{
			AddDynamicInput(p.ParameterType, ConnectionType.Override, TypeConstraint.Inherited, p.Name);
		}

		// Create ports for the outputs if they exist
		if (m.ReturnType != typeof(void))
		{
			// Has a return value
			AddDynamicOutput(m.ReturnType, ConnectionType.Multiple, TypeConstraint.None, "return");
		}
	}

    public override AuroraNode Execute()
    {
		// Find the method
		MethodInfo m = ParentClass.GetMethod(ActionName);

		// Calculate the parameters of the method based on the inputs to the node
		List<object> parameters = new List<object>();

		foreach (NodePort input in DynamicInputs)
		{
			parameters.Add(input.GetInputValue());
		}

		// We assume the method is static, and run it
		returnValue = m.Invoke(null, parameters.ToArray());

		return base.Execute();
    }
}

[CreateNodeMenu("Functions/Custom")]
public class CustomNode : ComputeNode
{
	public override Type ParentClass
	{
		get
        {
			return typeof(NCSOverride);
        }
    }
}

[CreateNodeMenu("Functions/Action")]
public class ActionNode : ComputeNode
{
	public override Type ParentClass
	{
		get
		{
			return typeof(NWScript);
		}
	}

    public override AuroraNode Execute()
    {


        return base.Execute();
    }
}