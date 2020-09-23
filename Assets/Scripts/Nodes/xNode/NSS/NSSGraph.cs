using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

namespace XNode
{
    [CreateAssetMenu]
    public class NSSGraph : NodeGraph
    {

    }
    [CreateNodeMenu("On Begin Script")]
    public class OnBeginScript : ExecutableNode
    {
        public override string GetCode()
        {
            return "void main () {\n" + GetAfterCode() + "}";
        }
    }
}
