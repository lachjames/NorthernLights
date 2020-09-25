using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace XNode
{
	[CreateNodeMenu("BinaryOps/Equality/Int")]
	public class EqualInt : EqualityOperation
	{
		[Input] public new int x, y;
		[Output] public new bool result;
	}
}
