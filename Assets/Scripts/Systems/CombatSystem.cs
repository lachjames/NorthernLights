using AuroraEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatSystem : MonoBehaviour
{
    // Start is called before the first frame update
    bool initialized = false;

    // Start is called before the first frame update
    public void Initialize()
    {
        initialized = true;
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!initialized)
        {
            return;
        }
    }
}

public static class Combat
{
    // An implementation of the ruleset used by the Aurora engine
    public class AttackResult
    {
        public bool hit;
        public bool crit;

        public int damage;
    }

    public class SaveResult
    {
        public bool saved;
    }

    public class SkillResult
    {
        public bool success;
    }

    public static AttackResult Attack(AuroraObject attacker, AuroraObject target)
    {
        // Firstly, determine whether the attack hits
        int hitD20 = NWScript.d20();

        // Then determine the amount of damage done
        int dmgD20 = NWScript.d20();

        // Determine if it's a crit (and, if so, crit damage)
        

        // Create a new AttackResult containing the information about the attack
        AttackResult result = new AttackResult()
        {
            hit = true,
            damage = 3
        };

        // Return the attack
        return result;
    }

    public static SaveResult SavingThrow (AuroraEffect effect, AuroraObject target)
    {
        SaveResult result = new SaveResult()
        {
            saved = true
        };

        return result;
    }

    //public static SkillResult SkillCheck (AuroraObject obj)
    //{
    //    SkillResult success = new SkillResult()
    //    {
    //        success = false
    //    };

    //    return success;
    //}
}