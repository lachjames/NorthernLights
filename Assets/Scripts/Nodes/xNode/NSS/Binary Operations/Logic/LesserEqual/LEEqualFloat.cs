using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace XNode
{
	[CreateNodeMenu("BinaryOps/LEEquality/Float")]
	public class LEEqualFloat : LEEqualityOperation
	{
		[Input] public new float x, y;
		[Output] public new bool result;
	}
}
