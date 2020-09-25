using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace XNode
{
	[CreateNodeMenu("BinaryOps/Add/Int")]
	public class AddInt : AddOperation
	{
		[Input] public new int x, y;
		[Output] public new int result;
	}
}
