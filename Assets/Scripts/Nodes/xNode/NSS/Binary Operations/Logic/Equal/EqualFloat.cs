using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace XNode
{
	[CreateNodeMenu("BinaryOps/Equality/Float")]
	public class EqualFloat : EqualityOperation
	{
		[Input] public new float x, y;
		[Output] public new bool result;
	}
}
