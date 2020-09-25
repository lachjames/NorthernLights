using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace XNode
{
	[CreateNodeMenu("BinaryOps/LEquality/Int")]
	public class LEqualInt : LEqualityOperation
	{
		[Input] public new int x, y;
		[Output] public new bool result;
	}
}
