using AuroraEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using XNode;

namespace XNode
{
    [Serializable]
	public abstract class ComputeNode : ExecutableNode
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

			if (m == null)
			{
				return;
			}

			// Create ports for the inputs
			foreach (ParameterInfo p in m.GetParameters())
			{
				if (p.ParameterType == typeof(NCSContext))
                {
					AddDynamicInput(typeof(Conditional), ConnectionType.Override, TypeConstraint.Inherited, p.Name);
				}
				else
                {
					AddDynamicInput(p.ParameterType, ConnectionType.Override, TypeConstraint.Inherited, p.Name);
				}
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

		public override string GetCode()
		{
			// Find the method
			MethodInfo m = ParentClass.GetMethod(ActionName);

			// Calculate the parameters of the method based on the inputs to the node
			List<string> parameters = new List<string>();

			bool semicolon = true;

            foreach (NodePort input in Inputs)
            {
				if (input.fieldName == "trigger")
                {
					if (input.Connection == null)
					{
						semicolon = false;
					}
					// Skip the trigger node
					continue;
                }
				if (input.Connection == null)
				{
					throw new Exception("Empty input for " + input.fieldName);
				}
				parameters.Add(((AuroraNode)input.Connection.node).GetCode());
            }

			if (semicolon)
            {
				return ActionName + "(" + String.Join(",", parameters) + ");\n" + GetAfterCode();
			} else
            {
				return ActionName + "(" + String.Join(",", parameters) + ")";
			}
		}
	}

}
