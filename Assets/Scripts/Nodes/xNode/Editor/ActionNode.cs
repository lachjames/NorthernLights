using AuroraEngine;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using XNode;

public class ExecutableNode : Node
{
	[Input] public Conditional trigger;
	[Output] public Conditional after;
}

[ExecuteInEditMode]
public class ActionNode : ExecutableNode
{
	public string ActionName;
	string lastActionName;

	// Use this for initialization
	protected override void Init() {
		base.Init();
		
	}

	// Return the correct value of an output port when requested
	public override object GetValue(NodePort port) {
		return null;
	}

	public void UpdateAction ()
    {
		if (lastActionName == ActionName)
        {
			return;
        }
		
		// If we reach this point, the action name has changed
		lastActionName = ActionName;
		
		// Remove all the old ports
		foreach (var p in new List<NodePort> (DynamicPorts))
        {
			RemoveDynamicPort(p);
        }

		// Find the MethodInfo for the action
		MethodInfo m = typeof(NWScript).GetMethod(ActionName);

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
}