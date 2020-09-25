using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace XNode
{
	[CreateNodeMenu("BinaryOps/Sub/FloatInt")]
	public class SubFloatInt : SubOperation
	{
		[Input] public new float x;
		[Input] public new int y;
		[Output] public new float result;
	}
}
