using AuroraEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;
using XNode;

namespace XNode
{
	[ExecuteInEditMode]
	public abstract class BinaryOperation : ExecutableNode
	{
		public virtual string Operator => throw new NotImplementedException();

		public object x, y;
		public object result;

		// Use this for initialization
		protected override void Init()
		{
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

		public override string GetCode()
		{
			string xStr = "";
			string yStr = "";
			foreach (NodePort input in Inputs)
			{
				if (input.fieldName == "x")
				{
					xStr = ((AuroraNode)input.Connection.node).GetCode();
				}
				else if (input.fieldName == "y")
				{
					yStr = ((AuroraNode)input.Connection.node).GetCode();
				}
			}

			return xStr + " " + Operator + " " + yStr;
		}
	}
}