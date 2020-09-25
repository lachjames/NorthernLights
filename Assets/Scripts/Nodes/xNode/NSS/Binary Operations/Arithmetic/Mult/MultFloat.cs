using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace XNode
{
	[CreateNodeMenu("BinaryOps/Mult/Float")]
	public class MultFloat : MultOperation
	{
		[Input] public new float x, y;
		[Output] public new float result;
	}
}
