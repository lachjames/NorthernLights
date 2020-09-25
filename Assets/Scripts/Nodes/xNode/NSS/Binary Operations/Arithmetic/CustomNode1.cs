using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace XNode
{
	[CreateNodeMenu("Functions/Custom")]
	[Serializable]
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
}
