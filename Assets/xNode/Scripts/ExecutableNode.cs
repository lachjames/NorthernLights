using System;
using System.Collections.Generic;
using UnityEngine;

namespace XNode
{
    [Serializable]
    public class ExecutableNode : AuroraNode
    {
        public static HashSet<ExecutableNode> traversed = new HashSet<ExecutableNode>();

        [Input] public Conditional trigger;
        [Output] public Conditional after;

        public ExecutableNode GetAfter()
        {
            foreach (NodePort port in Outputs)
            {
                if (port.fieldName == "after")
                {
                    if (port.Connection == null)
                    {
                        Debug.Log("Port is not connected, so execution terminates here");
                        return null;
                    }
                    Debug.Log("Node " + this + " connected to " + port.Connection.node);
                    return (ExecutableNode)port.Connection.node;
                }
            }

            return null;
        }

        public override AuroraNode Execute()
        {
            return GetAfter();
        }

        public override string GetCode()
        {
            return GetAfterCode();
        }

        public string GetAfterCode()
        {
            traversed.Add(this);

            Debug.Log("Just got code from " + GetType());
            ExecutableNode afterNode = GetAfter();

            if (afterNode == this)
            {
                throw new Exception("A node cannot be its own after node!");
            }

            if (traversed.Contains(afterNode))
            {
                throw new Exception("Infinite loop detected from node of type " + GetType());
            }

            if (afterNode != null)
            {
                traversed.Add(afterNode);
                return afterNode.GetCode();
            }

            return "";
        }
    }
}
