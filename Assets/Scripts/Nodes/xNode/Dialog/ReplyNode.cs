using System.Collections.Generic;
using UnityEngine;

public class ReplyNode : XNode.Node
{
    [Input] public EntryToReply prevNode;
    [Output] public List<ReplyToEntry> entries;

    public AuroraDLG.AReply reply;

    public ReplyNode ()
    {
        reply = new AuroraDLG.AReply();
    }
}
