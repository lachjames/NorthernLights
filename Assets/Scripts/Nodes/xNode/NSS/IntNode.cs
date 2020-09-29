using System;

namespace XNode
{
    [CreateNodeMenu("Values/Int")]
    [Serializable]
	public class IntNode : AuroraNode
	{

		[Output] public int output;
		public string Value;

		// Use this for initialization
		protected override void Init()
		{
			base.Init();

		}

		// Return the correct value of an output port when requested
		public override object GetValue(NodePort port)
		{
			return int.Parse(Value);
		}
		public override string GetCode()
		{
			return Value;
		}

	}
}
