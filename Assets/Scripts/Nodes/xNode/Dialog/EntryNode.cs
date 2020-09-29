using System.Collections.Generic;
using UnityEngine;

public class EntryNode : XNode.Node {
    [Input] public List<XNode.Node> prevNode;
    [Output] public List<EntryToReply> replies;

    public AuroraDLG.AEntry entry;
    public EntryNode ()
    {
        entry = new AuroraDLG.AEntry();
    }
}
