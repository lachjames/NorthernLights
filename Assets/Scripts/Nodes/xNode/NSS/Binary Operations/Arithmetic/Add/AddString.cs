using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace XNode
{
	[CreateNodeMenu("BinaryOps/Add/String")]
	public class AddString : AddOperation
	{
		[Input] public new string x, y;
		[Output] public new string result;
	}
}
