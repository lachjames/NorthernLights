using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace XNode
{
	[CreateNodeMenu("BinaryOps/Sub/Float")]
	public class SubFloat : SubOperation
	{
		[Input] public new float x, y;
		[Output] public new float result;
	}
}
