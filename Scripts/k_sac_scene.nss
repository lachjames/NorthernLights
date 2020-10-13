object CreateCreature(string resref, string waypoint) {
    return CreateObject(
        OBJECT_TYPE_CREATURE,
        resref,
        GetLocation(GetWaypointByTag(waypoint))
    );
}

void main () {
    if (GetEnteringObject() != GetFirstPC()) {
        return;
    }

    object atton = CreateCreature("p_atton", "WP_ATT_CELL");
    object brianna = CreateCreature("p_handmaiden", "WP_BRI_CELL");
    object visas = CreateCreature("p_visas", "WP_VISAS_CELL");
    object mira = CreateCreature("p_mira", "WP_MIRA_CELL");

    object attonGuard = GetNearestCreature(CREATURE_TYPE_IS_ALIVE, TRUE, atton);
    object briannaGuard = GetNearestCreature(CREATURE_TYPE_IS_ALIVE, TRUE, brianna);
    object visasGuard = GetNearestCreature(CREATURE_TYPE_IS_ALIVE, TRUE, visas);
    object miraGuard = GetNearestCreature(CREATURE_TYPE_IS_ALIVE, TRUE, mira);

    object attonDoor = GetObjectByTag("PrisonDoor04");
    object miraDoor = GetObjectByTag("PrisonDoor06");
    object visasDoor = GetObjectByTag("PrisonDoor05");
    object briannaDoor = GetObjectByTag("PrisonDoor07");
    
    AssignCommand(attonGuard, ActionForceFollowObject(atton, 3f));
    AssignCommand(briannaGuard, ActionForceFollowObject(brianna, 3f));
    AssignCommand(visasGuard, ActionForceFollowObject(visas, 3f));
    AssignCommand(miraGuard, ActionForceFollowObject(mira, 3f));

    DelayCommand(20f, AssignCommand(attonDoor, ActionOpenDoor(attonDoor)));
    DelayCommand(20f, AssignCommand(atton, ActionMoveToLocation(GetLocation(GetWaypointByTag("WP_ATT_HOSTAGE")))));

    DelayCommand(23f, AssignCommand(briannaDoor, ActionOpenDoor(briannaDoor)));
    DelayCommand(23f, AssignCommand(brianna, ActionMoveToLocation(GetLocation(GetWaypointByTag("WP_BRI_HOSTAGE")))));

    DelayCommand(26f, AssignCommand(visasDoor, ActionOpenDoor(visasDoor)));
    DelayCommand(26f, AssignCommand(visas, ActionMoveToLocation(GetLocation(GetWaypointByTag("WP_VISAS_HOSTAGE")))));

    DelayCommand(29f, AssignCommand(miraDoor, ActionOpenDoor(miraDoor)));
    DelayCommand(29f, AssignCommand(mira, ActionMoveToLocation(GetLocation(GetWaypointByTag("WP_MIRA_HOSTAGE")))));
}
