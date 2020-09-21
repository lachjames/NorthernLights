//using AuroraEngine;
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using XNode;

//public class ExecutionGraph
//{
//    public Node startNode;
//    public ExecutionGraph (NSSGraph graph)
//    {
//        // Find the start node
//        Node begin = null;
//        foreach (Node node in graph.nodes)
//        {
//            if (node.GetType() == typeof(OnBeginScript))
//            {
//                begin = node;
//                break;
//            }
//        }

//        if (begin == null)
//        {
//            // Graph has no start node
//            return;
//        }
//    }
//}

//public class ExecutionNode
//{
//    public Node node;
//    public ExecutionNode (Node node)
//    {
//        this.node = node;
//    }

//    public void Execute ()
//    {
//        // Depending on the type of node here, we will do different things
//    }
//}

//public class ExecutionContext
//{
//    Node currentNode;
//    ExecutionGraph graph;
//    public ExecutionContext(ExecutionGraph graph)
//    {
//        this.graph = graph;
//        currentNode = graph.startNode;
//    }

//    public void Step ()
//    {
//        // Execute the current node
//        //object value = currentNode.Execute();
//        //if (value != null)
//        //{

//        //}
//    }
//}