using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace XNode
{
	[CreateNodeMenu("BinaryOps/Mult/Int")]
	public class MultInt : MultOperation
	{
		[Input] public new int x, y;
		[Output] public new int result;
	}
}
