using AuroraEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace XNode
{
	[CreateNodeMenu("BinaryOps/GEquality/IntFloat")]
	public class GEqualIntFloat : GEqualityOperation
	{
		[Input] public new int x;
		[Input] public new float y;
		[Output] public new bool result;
	}
}
