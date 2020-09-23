using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace XNode
{
    #region Addition
    public abstract class AddOperation : BinaryOperation
	{
		public override string Operator => "+";
	}

	[CreateNodeMenu("BinaryOps/Add/String")]
	public class AddString : AddOperation
	{
		[Input] public new string x, y;
		[Output] public new string result;
	}

	[CreateNodeMenu("BinaryOps/Add/Int")]
	public class AddInt : AddOperation
	{
		[Input] public new int x, y;
		[Output] public new int result;
	}

	[CreateNodeMenu("BinaryOps/Add/Float")]
	public class AddFloat : AddOperation
	{
		[Input] public new float x, y;
		[Output] public new float result;
	}
    #endregion Addition

    #region Subtraction
    public abstract class SubOperation : BinaryOperation
	{
		public override string Operator => "-";
	}

	[CreateNodeMenu("BinaryOps/Sub/Int")]
	public class SubInt : SubOperation
	{
		[Input] public new int x, y;
		[Output] public new int result;
	}

	[CreateNodeMenu("BinaryOps/Sub/Float")]
	public class SubFloat : SubOperation
	{
		[Input] public new float x, y;
		[Output] public new float result;
	}
    #endregion Subtraction

    #region Multiplication
    public abstract class MultOperation : BinaryOperation
	{
		public override string Operator => "*";
	}

	[CreateNodeMenu("BinaryOps/Mult/Int")]
	public class MultInt : MultOperation
	{
		[Input] public new int x, y;
		[Output] public new int result;
	}

	[CreateNodeMenu("BinaryOps/Mult/Float")]
	public class MultFloat : MultOperation
	{
		[Input] public new float x, y;
		[Output] public new float result;
	}
	#endregion Multiplication

	#region Division
	public abstract class DivOperation : BinaryOperation
	{
		public override string Operator => "/";
	}

	[CreateNodeMenu("BinaryOps/Div/Int")]
	public class DivInt : DivOperation
	{
		[Input] public new int x, y;
		[Output] public new int result;
	}

	[CreateNodeMenu("BinaryOps/Div/Float")]
	public class DivFloat : DivOperation
	{
		[Input] public new float x, y;
		[Output] public new float result;
	}
	#endregion Division
}