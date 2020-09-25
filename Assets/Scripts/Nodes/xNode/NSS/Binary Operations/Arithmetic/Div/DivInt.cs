using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace XNode
{
	[CreateNodeMenu("BinaryOps/Div/Int")]
	public class DivInt : DivOperation
	{
		[Input] public new int x, y;
		[Output] public new int result;
	}
}
