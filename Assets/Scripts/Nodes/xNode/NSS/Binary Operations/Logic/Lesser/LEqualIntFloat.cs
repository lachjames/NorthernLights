using AuroraEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace XNode
{
	[CreateNodeMenu("BinaryOps/LEquality/IntFloat")]
	public class LEqualIntFloat : LEqualityOperation
	{
		[Input] public new int x;
		[Input] public new float y;
		[Output] public new bool result;
	}
}
