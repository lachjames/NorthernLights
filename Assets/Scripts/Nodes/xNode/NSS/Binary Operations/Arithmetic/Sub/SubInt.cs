using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace XNode
{
	[CreateNodeMenu("BinaryOps/Sub/Int")]
	public class SubInt : SubOperation
	{
		[Input] public new int x, y;
		[Output] public new int result;
	}
}
