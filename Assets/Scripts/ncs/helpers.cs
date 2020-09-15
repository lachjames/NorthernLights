using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AuroraEngine
{
    public partial class NWScript
    {
        public static Dictionary<int, Type> objectTypes = new Dictionary<int, Type>()
        {
            { OBJECT_TYPE_CREATURE, typeof(Creature) },
            { OBJECT_TYPE_ITEM, typeof(Item) },
            { OBJECT_TYPE_TRIGGER, typeof(Trigger) },
            { OBJECT_TYPE_DOOR, typeof(Door) },
            //{ OBJECT_TYPE_AREA_OF_EFFECT, typeof() },
            { OBJECT_TYPE_WAYPOINT, typeof(Waypoint) },
            { OBJECT_TYPE_PLACEABLE, typeof(Placeable) },
            { OBJECT_TYPE_STORE, typeof(Store) },
            { OBJECT_TYPE_ENCOUNTER, typeof(Encounter) },
            //{ OBJECT_TYPE_SOUND, typeof(AuroraSound) },
            { OBJECT_TYPE_ALL, typeof(AuroraObject) },
            //{ OBJECT_TYPE_INVALID, typeof(AuroraObject) } // Exclude this as OBJECT_TYPE_ALL == OBJECT_TYPE_INVALID
        };
    }
}