using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace XNode
{
	[CreateNodeMenu("BinaryOps/Div/FloatInt")]
	public class DivFloatInt : DivOperation
	{
		[Input] public new float x;
		[Input] public new int y;
		[Output] public new float result;
	}
}
