using AuroraEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace XNode
{
	[CreateNodeMenu("BinaryOps/NEquality/AuroraObject")]
	public class NEqualAuroraObject : NEqualityOperation
	{
		[Input] public new AuroraObject x, y;
		[Output] public new bool result;
	}
}
