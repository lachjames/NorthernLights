using System.Collections.Generic;

public class StartNode : XNode.Node
{
    [Output] public List<EntryNode> entries;
    public AuroraDLG.AStarting start;
    public StartNode ()
    {
        start = new AuroraDLG.AStarting();
    }
}
