using AuroraEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace XNode
{
	[CreateNodeMenu("BinaryOps/Equality/AuroraObject")]
	public class EqualAuroraObject : EqualityOperation
	{
		[Input] public new AuroraObject x, y;
		[Output] public new bool result;
	}
}
