using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace XNode
{
	[CreateNodeMenu("BinaryOps/LEquality/Float")]
	public class LEqualFloat : LEqualityOperation
	{
		[Input] public new float x, y;
		[Output] public new bool result;
	}
}
