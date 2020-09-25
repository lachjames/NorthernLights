using AuroraEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace XNode
{
	[CreateNodeMenu("BinaryOps/LEEquality/FloatInt")]
	public class LEEqualFloatInt : LEEqualityOperation
	{
		[Input] public new float x;
		[Input] public new int y;
		[Output] public new bool result;
	}
}
