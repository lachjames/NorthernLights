using AuroraEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AuroraScript
{
    public string resref;
}

//public class AuroraEffect
//{
//    public static AuroraEffect INVALID_EFFECT = new AuroraEffect();

//    public AuroraEngine.AuroraObject creator;
//    public int DurationType;
//    public int SubType;
//}

public class AuroraLocation
{
    public Vector3 position;

    public Vector3 GetVector ()
    {
        return new Vector3(
            position.x,
            position.z,
            position.y
        );
    }
}

public class AuroraVector
{
    public float x, y, z;
    public AuroraVector ()
    {

    }

    public AuroraVector(float x, float y, float z)
    {
        this.x = x;
        this.y = y;
        this.z = z;
    }
}

public class AuroraTalent
{
    public enum TalentType
    {
        SPELL, FEAT, SKILL
    }
    public AuroraObject owner;
    public int id;
    public TalentType talentType;
    
    public AuroraTalent (AuroraObject owner, int id, TalentType talentType)
    {
        this.owner = owner;
        this.id = id;
        this.talentType = talentType;
    }
}

//public class AuroraAction
//{

//}

public class AuroraEvent
{
    public enum EventType
    {
        UserDefinedEvent
    }

    public EventType eventType;
    public int eventArg;

    public AuroraObject target;

    public AuroraEvent (EventType t, int arg) {
        eventType = t;
        eventArg = arg;
    }
}

public class AuroraObjectID
{

}