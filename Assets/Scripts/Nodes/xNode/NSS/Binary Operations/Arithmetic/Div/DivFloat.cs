using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace XNode
{
	[CreateNodeMenu("BinaryOps/Div/Float")]
	public class DivFloat : DivOperation
	{
		[Input] public new float x, y;
		[Output] public new float result;
	}
}
