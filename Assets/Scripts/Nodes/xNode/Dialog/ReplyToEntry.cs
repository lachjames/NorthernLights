using UnityEngine;

public class ReplyToEntry : XNode.Node {
    [Input] public ReplyNode reply;
    [Output] public EntryNode entry;

    public AuroraDLG.AReply.AEntries r2e;

    public ReplyToEntry ()
    {
        r2e = new AuroraDLG.AReply.AEntries();
    }
}