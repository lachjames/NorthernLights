using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace XNode
{
	[CreateNodeMenu("BinaryOps/Equality/IntFloat")]
	public class EqualIntFloat : EqualityOperation
	{
		[Input] public new int x;
		[Input] public new float y;
		[Output] public new bool result;
	}
}
