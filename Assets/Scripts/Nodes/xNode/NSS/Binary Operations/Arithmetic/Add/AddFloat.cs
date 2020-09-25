using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace XNode
{
	[CreateNodeMenu("BinaryOps/Add/Float")]
	public class AddFloat : AddOperation
	{
		[Input] public new float x, y;
		[Output] public new float result;
	}
}
