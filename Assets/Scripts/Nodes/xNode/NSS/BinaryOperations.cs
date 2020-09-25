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



    #endregion Addition

    #region Subtraction
    public abstract class SubOperation : BinaryOperation
	{
		public override string Operator => "-";
	}


    #endregion Subtraction

    #region Multiplication
    public abstract class MultOperation : BinaryOperation
	{
		public override string Operator => "*";
	}


	#endregion Multiplication

	#region Division
	public abstract class DivOperation : BinaryOperation
	{
		public override string Operator => "/";
	}


	#endregion Division
}