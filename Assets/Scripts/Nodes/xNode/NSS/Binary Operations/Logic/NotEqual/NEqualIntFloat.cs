using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace XNode
{
	[CreateNodeMenu("BinaryOps/NEquality/IntFloat")]
	public class NEqualIntFloat : NEqualityOperation
	{
		[Input] public new int x;
		[Input] public new float y;
		[Output] public new bool result;
	}
}
