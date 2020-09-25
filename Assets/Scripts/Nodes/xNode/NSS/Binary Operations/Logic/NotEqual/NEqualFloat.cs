using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace XNode
{
	[CreateNodeMenu("BinaryOps/NEquality/Float")]
	public class NEqualFloat : NEqualityOperation
	{
		[Input] public new float x, y;
		[Output] public new bool result;
	}
}
