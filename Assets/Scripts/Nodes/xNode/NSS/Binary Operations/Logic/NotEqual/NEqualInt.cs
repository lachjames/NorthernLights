using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace XNode
{
	[CreateNodeMenu("BinaryOps/NEquality/Int")]
	public class NEqualInt : NEqualityOperation
	{
		[Input] public new int x, y;
		[Output] public new bool result;
	}
}
