using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace XNode
{
	[CreateNodeMenu("BinaryOps/GEquality/Float")]
	public class GEqualFloat : GEqualityOperation
	{
		[Input] public new float x, y;
		[Output] public new bool result;
	}
}
