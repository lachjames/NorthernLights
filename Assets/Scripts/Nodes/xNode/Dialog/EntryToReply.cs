using UnityEngine;

public class EntryToReply : XNode.Node
{
    [Input] public EntryNode entry;
    [Output] public ReplyNode reply;

    public AuroraDLG.AEntry.AReplies e2r;

    public EntryToReply ()
    {
        e2r = new AuroraDLG.AEntry.AReplies();
    }
}
