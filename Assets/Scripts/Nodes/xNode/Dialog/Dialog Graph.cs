using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;
using Microsoft.Msagl;
using Microsoft.Msagl.Core.Layout;
using UnityEngine.Experimental.AI;
using System.Linq;
using Microsoft.Msagl.Miscellaneous;
using Microsoft.Msagl.Prototype.Ranking;
using Microsoft.Msagl.Layout.Layered;

[CreateAssetMenu]
public class DialogGraph : NodeGraph { 
    public void LoadDLG (AuroraDLG dlg)
    {
        // Clear the graph
        Clear();

        Dictionary<AuroraDLG.AEntry, XNode.Node> entries = new Dictionary<AuroraDLG.AEntry, XNode.Node>();
        Dictionary<AuroraDLG.AReply, XNode.Node> replies = new Dictionary<AuroraDLG.AReply, XNode.Node>();

        Dictionary<(AuroraDLG.AEntry, AuroraDLG.AEntry.AReplies), XNode.Node> entryReplies = new Dictionary<(AuroraDLG.AEntry, AuroraDLG.AEntry.AReplies), XNode.Node>();
        Dictionary<(AuroraDLG.AReply, AuroraDLG.AReply.AEntries), XNode.Node> replyEntries = new Dictionary<(AuroraDLG.AReply, AuroraDLG.AReply.AEntries), XNode.Node>();

        // Add all entry nodes
        foreach (AuroraDLG.AEntry entry in dlg.EntryList)
        {
            entries[entry] = AddNode<EntryNode>();
        }

        // Add all reply nodes
        foreach (AuroraDLG.AReply reply in dlg.ReplyList)
        {
            replies[reply] = AddNode<ReplyNode>();
        }

        // Add all the edges
        foreach (AuroraDLG.AEntry entry in dlg.EntryList)
        {
            foreach (AuroraDLG.AEntry.AReplies reply in entry.RepliesList)
            {
                // Create a new EntryToReply node
                EntryToReply e2r = AddNode<EntryToReply>();
                entryReplies[(entry, reply)] = e2r;
         
                // Connect the entry to the 
            }

        }

    }

    public void AutoLayout ()
    {
        GeometryGraph graph = new GeometryGraph();

        Dictionary<Microsoft.Msagl.Core.Layout.Node, XNode.Node> ms2x= new Dictionary<Microsoft.Msagl.Core.Layout.Node, XNode.Node>();
        Dictionary<XNode.Node, Microsoft.Msagl.Core.Layout.Node> x2ms = new Dictionary<XNode.Node, Microsoft.Msagl.Core.Layout.Node>();

        // Create all the nodes
        foreach (XNode.Node xNode in nodes)
        {
            Microsoft.Msagl.Core.Layout.Node msNode = new Microsoft.Msagl.Core.Layout.Node();
            ms2x[msNode] = xNode;
            x2ms[xNode] = msNode;
        }

        // Create the edges
        foreach (XNode.Node xSource in nodes)
        {
            Microsoft.Msagl.Core.Layout.Node source = x2ms[xSource];

            foreach (NodePort port in xSource.Outputs.First().GetConnections())
            {
                XNode.Node xTarget = port.node;
                Microsoft.Msagl.Core.Layout.Node target = x2ms[xTarget];

                Edge edge = new Edge(source, target);
                source.AddOutEdge(edge);
                target.AddInEdge(edge);
            }
        }

        // Choose a layout algorithm
        LayoutAlgorithmSettings settings = new RankingLayoutSettings();
        //LayoutAlgorithmSettings settings = new SugiyamaLayoutSettings();
        
        // Automatically create a layout for the graph
        LayoutHelpers.CalculateLayout(graph, settings, null);

        // Apply the layout to the XNode nodes
        foreach (XNode.Node node in nodes)
        {
            Microsoft.Msagl.Core.Layout.Node msNode = x2ms[node];

            node.position = new Vector2((float)msNode.Center.X, (float)msNode.Center.Y);
        }
    }
}

public class StartNode : XNode.Node
{
    [Output] public List<EntryNode> entries;
}

public class EntryNode : XNode.Node {
    [Input] public List<XNode.Node> prevNode;
    [Output] public List<EntryToReply> replies;
}

public class ReplyNode : XNode.Node
{
    [Input] public EntryToReply prevNode;
    [Output] public List<ReplyToEntry> entries;
}

public class EntryToReply : XNode.Node
{
    [Input] public EntryNode entry;
    [Output] public ReplyNode reply;
}

public class ReplyToEntry : XNode.Node {
    [Input] public ReplyNode reply;
    [Output] public EntryNode entry;
}