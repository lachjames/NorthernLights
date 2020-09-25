using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace XNode
{
	[CreateNodeMenu("Functions/Action")]
	public class ActionNode : ComputeNode
	{
		public override Type ParentClass
		{
			get
			{
				return typeof(AuroraEngine.NWScript);
			}
		}

		public override AuroraNode Execute()
		{
			return base.Execute();
		}
	}
}
