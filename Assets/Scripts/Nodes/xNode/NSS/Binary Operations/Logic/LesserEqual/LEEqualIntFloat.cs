using AuroraEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace XNode
{
	[CreateNodeMenu("BinaryOps/LEEquality/IntFloat")]
	public class LEEqualIntFloat : LEEqualityOperation
	{
		[Input] public new int x;
		[Input] public new float y;
		[Output] public new bool result;
	}
}
