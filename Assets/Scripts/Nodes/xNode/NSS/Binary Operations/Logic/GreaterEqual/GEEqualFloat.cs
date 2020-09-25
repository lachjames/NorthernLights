using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace XNode
{
	[CreateNodeMenu("BinaryOps/GEEquality/Float")]
	public class GEEqualFloat : GEEqualityOperation
	{
		[Input] public new float x, y;
		[Output] public new bool result;
	}
}
