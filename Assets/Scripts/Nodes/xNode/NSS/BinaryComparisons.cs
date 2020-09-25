using AuroraEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace XNode
{
	public abstract class EqualityOperation : BinaryOperation
	{
		public override string Operator => "==";
	}

	public abstract class NEqualityOperation : BinaryOperation
	{
		public override string Operator => "!=";
	}

	public abstract class GEqualityOperation : BinaryOperation
	{
		public override string Operator => ">";
	}

	public abstract class GEEqualityOperation : BinaryOperation
	{
		public override string Operator => ">=";
	}

	public abstract class LEqualityOperation : BinaryOperation
	{
		public override string Operator => "<";
	}
	public abstract class LEEqualityOperation : BinaryOperation
	{
		public override string Operator => "<=";
	}

}