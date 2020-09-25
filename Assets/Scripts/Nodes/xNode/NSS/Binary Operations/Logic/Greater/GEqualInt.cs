using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace XNode
{
	[CreateNodeMenu("BinaryOps/GEquality/Int")]
	public class GEqualInt : GEqualityOperation
	{
		[Input] public new int x, y;
		[Output] public new bool result;
	}
}
