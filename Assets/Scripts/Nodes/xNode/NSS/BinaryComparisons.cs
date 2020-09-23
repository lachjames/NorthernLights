using AuroraEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace XNode
{
	#region Equality
	public abstract class EqualityOperation : BinaryOperation
	{
		public override string Operator => "==";
	}

	[CreateNodeMenu("BinaryOps/Equality/String")]
	public class EqualString : EqualityOperation
	{
		[Input] public new string x, y;
		[Output] public new bool result;
	}

	[CreateNodeMenu("BinaryOps/Equality/Int")]
	public class EqualInt : EqualityOperation
	{
		[Input] public new int x, y;
		[Output] public new bool result;
	}

	[CreateNodeMenu("BinaryOps/Equality/Float")]
	public class EqualFloat : EqualityOperation
	{
		[Input] public new float x, y;
		[Output] public new bool result;
	}

	[CreateNodeMenu("BinaryOps/Equality/AuroraObject")]
	public class EqualAuroraObject : EqualityOperation
	{
		[Input] public new AuroraObject x, y;
		[Output] public new bool result;
	}
	#endregion Equality

	#region NEqual
	public abstract class NEqualOperation : BinaryOperation
	{
		public override string Operator => "!=";
	}

	[CreateNodeMenu("BinaryOps/NotEqual/String")]
	public class NEqualString : NEqualOperation
	{
		[Input] public new string x, y;
		[Output] public new bool result;
	}

	[CreateNodeMenu("BinaryOps/NotEqual/Int")]
	public class NEqualInt : NEqualOperation
	{
		[Input] public new int x, y;
		[Output] public new bool result;
	}

	[CreateNodeMenu("BinaryOps/NotEqual/Float")]
	public class NEqualFloat : NEqualOperation
	{
		[Input] public new float x, y;
		[Output] public new bool result;
	}

	[CreateNodeMenu("BinaryOps/NotEqual/AuroraObject")]
	public class NEqualAuroraObject : NEqualOperation
	{
		[Input] public new AuroraObject x, y;
		[Output] public new bool result;
	}
	#endregion NEqual
}