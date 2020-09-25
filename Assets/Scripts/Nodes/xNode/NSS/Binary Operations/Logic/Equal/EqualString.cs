using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace XNode
{
	[CreateNodeMenu("BinaryOps/Equality/String")]
	public class EqualString : EqualityOperation
	{
		[Input] public new string x, y;
		[Output] public new bool result;
	}
}
