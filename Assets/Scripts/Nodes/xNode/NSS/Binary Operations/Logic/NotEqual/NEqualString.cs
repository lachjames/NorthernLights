using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace XNode
{
	[CreateNodeMenu("BinaryOps/NEquality/String")]
	public class NEqualString : NEqualityOperation
	{
		[Input] public new string x, y;
		[Output] public new bool result;
	}
}
