using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace XNode
{
	[CreateNodeMenu("BinaryOps/Div/IntFloat")]
	public class DivIntFloat : DivOperation
	{
		[Input] public new int x;
		[Input] public new float y;
		[Output] public new float result;
	}
}
