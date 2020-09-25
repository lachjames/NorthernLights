using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace XNode
{
	[CreateNodeMenu("BinaryOps/Add/IntFloat")]
	public class AddIntFloat : AddOperation
	{
		[Input] public new int x;
		[Input] public new int y;
		[Output] public new float result;
	}
}
