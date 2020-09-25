using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace XNode
{
	[CreateNodeMenu("BinaryOps/GEEquality/Int")]
	public class GEEqualInt : GEEqualityOperation
	{
		[Input] public new int x, y;
		[Output] public new bool result;
	}
}
