using System;

namespace XNode
{
    [Serializable]
    public class AuroraNode : Node
    {
        public virtual AuroraNode Execute()
        {
            return null;
        }

        public virtual string GetCode ()
        {
            throw new NotImplementedException();
        }
    }
}
