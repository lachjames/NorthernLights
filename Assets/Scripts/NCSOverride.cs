using AuroraEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NCSOverride
{
    public static int GetZero (int x)
    {
        return 0;
    }
    public static int k_ai_master (AuroraObject self, int scriptVar)
    {
        switch (scriptVar)
        {
            case 3001: //This can replace a determine combat round call without an intruder
                break;
            case 3002: //This can replace a determine combat round call with the GetFirstPC as the intruder
                break;
            case 3003: //This can replace a determine combat round call with the Member Index 0 as the intruder
                break;
            /*
            // Enemy AI events
                int KOTOR_DEFAULT_EVENT_ON_HEARTBEAT           = 1001;
                int KOTOR_DEFAULT_EVENT_ON_PERCEPTION          = 1002;
                int KOTOR_DEFAULT_EVENT_ON_COMBAT_ROUND_END    = 1003;
                int KOTOR_DEFAULT_EVENT_ON_ATTACKED            = 1005;
                int KOTOR_DEFAULT_EVENT_ON_DAMAGE              = 1006;
                int KOTOR_DEFAULT_EVENT_ON_DEATH               = 1007;
                int KOTOR_DEFAULT_EVENT_ON_DISTURBED           = 1008;
                int KOTOR_DEFAULT_EVENT_ON_BLOCKED             = 1009;
                int KOTOR_DEFAULT_EVENT_ON_FORCE_AFFECTED      = 1010;
                int KOTOR_DEFAULT_EVENT_ON_GLOBAL_DIALOGUE_END = 1011;
                int KOTOR_DEFAULT_EVENT_ON_PATH_BLOCKED        = 1012;
            */
            case 1001: //KOTOR_DEFAULT_EVENT_ON_HEARTBEAT
                // If we are not fighting an enemy, just play the ambient animations
                // and move to the next waypoint
                break;
            case 1002: //KOTOR_DEFAULT_EVENT_ON_PERCEPTION
                // Attack the PC
                self.actions.Clear();
                self.actions.Add(new ActionAttack(self, StateSystem.stateSystem.PC, false));
                break;
            case 1003: //KOTOR_DEFAULT_EVENT_ON_COMBAT_ROUND_END
                // Attack the PC
                self.actions.Clear();
                self.actions.Add(new ActionAttack(self, StateSystem.stateSystem.PC, false));
                break;
            case 1005: //KOTOR_DEFAULT_EVENT_ON_ATTACKED
                // Attack the PC
                self.actions.Clear();
                self.actions.Add(new ActionAttack(self, StateSystem.stateSystem.PC, false));
                break;
            case 1006: //KOTOR_DEFAULT_EVENT_ON_DAMAGE
                // Attack the PC
                self.actions.Clear();
                self.actions.Add(new ActionAttack(self, StateSystem.stateSystem.PC, false));
                break;
            case 1007: //KOTOR_DEFAULT_EVENT_ON_DEATH
                // Nothing
                break;
            case 1008: //KOTOR_DEFAULT_EVENT_ON_DISTURBED
                // Not used
                break;
            case 1009: //KOTOR_DEFAULT_EVENT_ON_BLOCKED
                // TODO
                break;
            case 1010: //KOTOR_DEFAULT_EVENT_ON_FORCE_AFFECTED
                // Attack the PC
                self.actions.Clear();
                self.actions.Add(new ActionAttack(self, StateSystem.stateSystem.PC, false));
                break;
            case 1011: //KOTOR_DEFAULT_EVENT_ON_GLOBAL_DIALOGUE_END
                // TODO
                break;
            case 1012: //KOTOR_DEFAULT_EVENT_ON_PATH_BLOCKED
                // TODO
                break;
            /*
            // Friendly AI events
                int KOTOR_HENCH_EVENT_ON_HEARTBEAT           = 2001;
                int KOTOR_HENCH_EVENT_ON_PERCEPTION          = 2002;
                int KOTOR_HENCH_EVENT_ON_COMBAT_ROUND_END    = 2003;
                int KOTOR_HENCH_EVENT_ON_DIALOGUE            = 2004;
                int KOTOR_HENCH_EVENT_ON_ATTACKED            = 2005;
                int KOTOR_HENCH_EVENT_ON_DAMAGE              = 2006;
                int KOTOR_HENCH_EVENT_ON_DEATH               = 2007;
                int KOTOR_HENCH_EVENT_ON_DISTURBED           = 2008;
                int KOTOR_HENCH_EVENT_ON_BLOCKED             = 2009;
                int KOTOR_HENCH_EVENT_ON_FORCE_AFFECTED      = 2010;
                int KOTOR_HENCH_EVENT_ON_GLOBAL_DIALOGUE_END = 2011;
                int KOTOR_HENCH_EVENT_ON_PATH_BLOCKED        = 2012;
                int KOTOR_HENCH_EVENT_ON_ENTER_5m            = 2013;
                int KOTOR_HENCH_EVENT_ON_EXIT_5m             = 2014;
            */
            case 2001: //KOTOR_HENCH_EVENT_ON_HEARTBEAT
                break;
            case 2002: //KOTOR_HENCH_EVENT_ON_PERCEPTION
                break;
            case 2003: //KOTOR_HENCH_EVENT_ON_COMBAT_ROUND_END
                break;
            case 2004: //KOTOR_HENCH_EVENT_ON_DIALOGUE
                break;
            case 2005: //KOTOR_HENCH_EVENT_ON_ATTACKED
                break;
            case 2006: //KOTOR_HENCH_EVENT_ON_DAMAGE
                break;
            case 2007: //KOTOR_HENCH_EVENT_ON_DEATH
                break;
            case 2008: //KOTOR_HENCH_EVENT_ON_DISTURBED
                break;
            case 2009: //KOTOR_HENCH_EVENT_ON_BLOCKED
                break;
            case 2010: //KOTOR_HENCH_EVENT_ON_FORCE_AFFECTED
                break;
            case 2011: //KOTOR_HENCH_EVENT_ON_GLOBAL_DIALOGUE_END
                break;
            case 2012: //KOTOR_HENCH_EVENT_ON_PATH_BLOCKED
                break;
            case 2013: //KOTOR_HENCH_EVENT_ON_ENTER_5m
                break;
            case 2014: //KOTOR_HENCH_EVENT_ON_EXIT_5m
                break;
        }

        return 0;
    }

    //public static int k_zon_control (AuroraObject self, int scriptVar)
    //{
    //    return 0;
    //}
}
