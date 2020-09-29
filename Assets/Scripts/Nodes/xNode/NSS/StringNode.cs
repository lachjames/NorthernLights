using System;

namespace XNode
{
    [CreateNodeMenu("Values/String")]
    [Serializable]
	public class StringNode : AuroraNode
	{

		[Output] public string output;
		public string Value;

		// Use this for initialization
		protected override void Init()
		{
			base.Init();

		}

		// Return the correct value of an output port when requested
		public override object GetValue(NodePort port)
		{
			return Value;
		}

		public override string GetCode()
		{
			return '"' + Value + '"';
		}
	}
}
