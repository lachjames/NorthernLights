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
using Microsoft.Msagl.Core.Geometry.Curves;

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
            ((EntryNode)entries[entry]).entry = entry;
        }

        // Add all reply nodes
        foreach (AuroraDLG.AReply reply in dlg.ReplyList)
        {
            replies[reply] = AddNode<ReplyNode>();
            ((ReplyNode)replies[reply]).reply = reply;
        }

        // Add all the edges
        foreach (AuroraDLG.AEntry entry in dlg.EntryList)
        {
            foreach (AuroraDLG.AEntry.AReplies reply in entry.RepliesList)
            {
                // Create a new EntryToReply node
                EntryToReply e2r = AddNode<EntryToReply>();
                e2r.e2r = reply;
                entryReplies[(entry, reply)] = e2r;

                Debug.Log("Creating connection");
                // Connect the entry to the e2r
                entries[entry].GetPort("replies").Connect(e2r.GetPort("entry"));
                
                // Connect the e2r to the reply
                foreach (AuroraDLG.AReply r in replies.Keys)
                {
                    if (r.structid == reply.Index)
                    {
                        // Found it
                        replies[r].GetPort("prevNode").Connect(e2r.GetPort("reply"));
                        break;
                    }
                }
            }
        }

        foreach (AuroraDLG.AReply reply in dlg.ReplyList)
        {
            foreach (AuroraDLG.AReply.AEntries entry in reply.EntriesList)
            {
                // Create a new ReplyToEntry node
                ReplyToEntry r2e = AddNode<ReplyToEntry>();
                r2e.r2e = entry;
                replyEntries[(reply, entry)] = r2e;

                // Connect the reply to the r2e
                replies[reply].GetPort("entries").Connect(r2e.GetPort("reply"));

                // Connect the r2e to the entry
                foreach (AuroraDLG.AEntry e in entries.Keys)
                {
                    if (e.structid == entry.Index)
                    {
                        // Found it
                        entries[e].GetPort("prevNode").Connect(r2e.GetPort("entry"));
                        break;
                    }
                }
            }

        }

        AutoLayout();
    }

    public AuroraDLG ToDLG ()
    {
        throw new System.Exception();
    }

    public void AutoLayout ()
    {
        GeometryGraph graph = new GeometryGraph();

        Dictionary<Microsoft.Msagl.Core.Layout.Node, XNode.Node> ms2x= new Dictionary<Microsoft.Msagl.Core.Layout.Node, XNode.Node>();
        Dictionary<XNode.Node, Microsoft.Msagl.Core.Layout.Node> x2ms = new Dictionary<XNode.Node, Microsoft.Msagl.Core.Layout.Node>();

        // Create all the nodes
        foreach (XNode.Node xNode in nodes)
        {
            Microsoft.Msagl.Core.Layout.Node msNode = new Microsoft.Msagl.Core.Layout.Node(
                CurveFactory.CreateRectangle(150, 300, new Microsoft.Msagl.Core.Geometry.Point()),
                xNode
            );

            ms2x[msNode] = xNode;
            x2ms[xNode] = msNode;

            graph.Nodes.Add(msNode);
        }

        // Create the edges
        foreach (XNode.Node xSource in nodes)
        {
            Microsoft.Msagl.Core.Layout.Node source = x2ms[xSource];

            foreach (NodePort port in xSource.Outputs.First().GetConnections())
            {
                XNode.Node xTarget = port.node;
                Microsoft.Msagl.Core.Layout.Node target = x2ms[xTarget];

                graph.Edges.Add(
                    new Edge(source, target)
                    {
                        Weight = 1
                    }
                );
            }
        }

        // Choose a layout algorithm
        //LayoutAlgorithmSettings settings = new RankingLayoutSettings();
        LayoutAlgorithmSettings settings = new SugiyamaLayoutSettings();

        // Automatically create a layout for the graph
        LayoutHelpers.CalculateLayout(graph, settings, null);

        // Apply the layout to the XNode nodes
        foreach (Microsoft.Msagl.Core.Layout.Node msNode in graph.Nodes)
        {
            (msNode.UserData as XNode.Node).position = new Vector2(
                (float)-msNode.BoundingBox.Center.Y,
                (float)-msNode.BoundingBox.Center.X
            );
        }
    }
}
