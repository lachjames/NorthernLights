using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static XNode.Node;

[CreateNodeMenu("Quests/Phases/Deliver")]
public class Deliver : QuestPhase
{
    public string itemName;
    public string recipient;
}