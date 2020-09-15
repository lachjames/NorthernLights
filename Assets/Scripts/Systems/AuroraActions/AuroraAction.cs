using AuroraEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements.Experimental;

public abstract class AuroraAction
{
    // This runs on every frame
    public AuroraObject owner;
    public int ActionNumber = 65535;

    public AuroraAction(AuroraObject obj)
    {
        owner = obj;
    }

    public virtual void RunAction()
    {
        throw new NotImplementedException();
    }

    // This should be called every frame BEFORE RunAction 
    // to check whether the action should be removed from the Action queue
    public virtual bool IsFinishedBefore()
    {
        return false;
    }

    // This should be called every frame AFTER RunAction 
    // to check whether the action should be removed from the Action queue
    public virtual bool IsFinishedAfter()
    {
        return false;
    }
}

#region Combat

public class ActionAttack : AuroraAction
{
    public new int ActionNumber = NWScript.ACTION_ATTACKOBJECT;

    public AuroraObject self, target;
    bool passive;
    float timer;

    bool attackHasTriggered = false;

    float attackRange = 4f;

    AuroraLocation location;
    ActionMoveToLocation moveAction;

    Item weapon;
    Item.WeaponType weaponType;

    public ActionAttack (AuroraObject obj, AuroraObject target, bool bPassive) : base(obj)
    {
        this.self = obj;
        this.target = target;
        this.passive = bPassive;

        location = AttackPosition(target);
        moveAction = new ActionMoveToLocation(obj, location, true);

        weapon = ((Creature)obj).GetMainWeapon();

        if (weapon == null)
        {
            weaponType = Item.WeaponType.MELEE;
        } else
        {
            weaponType = weapon.GetWeaponType();
        }

        if (weaponType == Item.WeaponType.MELEE)
        {
            // For melee weapons, we run up to the front of the target
        }
        else
        {
            // For ranged weapons, we run within a certain distance of the target
            // TODO: Use actual weapon range stats from baseitems.2da
            attackRange = 15f;
        }

        obj.attemptedAttackTarget = target;
    }

    public void DoAttack ()
    {
        Debug.Log("Creature " + this.self.tag + " attacking " + this.target.tag);

        self.attackTarget = target;
        target.lastAttacker = self;

        attackHasTriggered = true;

        // For now, just play the attack animations
        Creature attacker = (Creature)this.self;
        
        // Check for a cutscene attack
        if (attacker.forcedAttack != null)
        {
            // The next attack is forced
            attacker.PlayAnimation(attacker.forcedAttack.anim);
            if (attacker.forcedAttack.result > 0)
            {
                ((Creature)target).TakeDamage(attacker.forcedAttack.dmg);
            }
            attacker.forcedAttack = null;
            return;
        }

        // If we reach this point, the attack was not forced, so we must
        // calculate it using the rules for calculating damage; this is
        // all done by the Combat class
        Combat.AttackResult result = Combat.Attack(attacker, target);
        if (!result.hit)
        {
            // Missed
            attacker.PlayAnimation("b7a1");
        }
        else
        {
            // Hit
            attacker.PlayAnimation("b7a1");
            ((Creature)target).TakeDamage(result.damage);
        }
    }

    public AuroraLocation AttackPosition(AuroraObject target)
    {
        AuroraLocation loc = new AuroraLocation();

        Vector3 pos; 
        
        // Depending on if it's a ranged or melee attack, we will do different things
        if (weaponType == Item.WeaponType.MELEE)
        {
            // For melee weapons, we run up to the front of the target
            pos = target.transform.position + target.transform.forward * attackRange;
        } else
        {
            // For ranged weapons, we run within a certain distance of the target
            // TODO: Use actual weapon range stats from baseitems.2da
            pos = target.transform.position + target.transform.forward * 15f;
        }

        loc.position = new Vector3(
            pos.x,
            pos.z,
            pos.y
        );

        return loc;
    }

    public override void RunAction ()
    {
        // Check if we've already attacked and are waiting for the next combat round
        if (attackHasTriggered)
        {
            timer += Time.deltaTime;
            
            if (timer > 6f)
            {
                // This is the last frame of the round, so it is about to end
                ((Creature)self).OnEndRound();
            }
            
            return;
        }

        // Update the location we should stand in
        location.position = AttackPosition(target).position;

        // Check if we have finished moving to the enemy
        if (Vector3.Distance(self.transform.position, target.transform.position) < attackRange)
        {
            // We have finished moving towards the enemy
            DoAttack();
        } else
        {
            // We just need to move towards the enemy
            moveAction.RunAction();
        }
    }

    public override bool IsFinishedAfter()
    {
        return (timer > 6f);
    }
}

public class ActionUseFeat : AuroraAction
{
    public new int ActionNumber = NWScript.ACTION_ATTACKOBJECT;
    public ActionUseFeat(AuroraObject obj, int nFeat, AuroraObject oTarget) : base(obj)
    {

    }
}

public class ActionUseSkill : AuroraAction
{
    public new int ActionNumber = NWScript.ACTION_ATTACKOBJECT;
    public ActionUseSkill(AuroraObject obj, int nSkill, AuroraObject oTarget, int nSubSkill, AuroraObject oItemUsed) : base(obj)
    {

    }
}


public class ActionUseTalentOnObject : AuroraAction
{
    public new int ActionNumber = NWScript.ACTION_ATTACKOBJECT;
    public ActionUseTalentOnObject(AuroraObject obj, AuroraTalent tChosenTalent, AuroraObject oTarget) : base(obj)
    {

    }
}


public class ActionUseTalentAtLocation : AuroraAction
{
    public new int ActionNumber = NWScript.ACTION_ATTACKOBJECT;
    public ActionUseTalentAtLocation(AuroraObject obj, AuroraTalent tChosenTalent, AuroraLocation lTargetLocation) : base(obj)
    {

    }
}

public class ActionSurrenderToEnemies : AuroraAction
{
    public ActionSurrenderToEnemies(AuroraObject obj) : base(obj)
    {

    }
}


public class ActionEquipMostDamagingMelee : AuroraAction
{
    public new int ActionNumber = NWScript.ACTION_ATTACKOBJECT;
    public ActionEquipMostDamagingMelee(AuroraObject obj, AuroraObject oVersus, bool bOffHand) : base(obj)
    {

    }
}


public class ActionEquipMostDamagingRanged : AuroraAction
{
    public new int ActionNumber = NWScript.ACTION_ATTACKOBJECT;
    public ActionEquipMostDamagingRanged(AuroraObject obj, AuroraObject oVersus) : base(obj)
    {

    }
}
public class ActionEquipMostEffectiveArmor : AuroraAction
{
    public new int ActionNumber = NWScript.ACTION_ATTACKOBJECT;
    public ActionEquipMostEffectiveArmor(AuroraObject obj) : base(obj)
    {

    }
}
#endregion

#region Doors/Placeables
public class ActionOpenDoor : AuroraAction
{
    AuroraObject obj;
    Door door;
    public new int ActionNumber = NWScript.ACTION_OPENDOOR;
    public ActionOpenDoor(AuroraObject obj, AuroraObject oDoor) : base(obj)
    {
        this.obj = obj;
        this.door = (Door)oDoor;
    }

    public override void RunAction ()
    {
        door.lastOpenedBy = obj;
        door.OpenDoor();
    }

    public override bool IsFinishedAfter()
    {
        return true;
    }
}


public class ActionCloseDoor : AuroraAction
{
    public new int ActionNumber = NWScript.ACTION_CLOSEDOOR;
    AuroraObject obj;
    Door door;
    public ActionCloseDoor(AuroraObject obj, AuroraObject oDoor) : base(obj)
    {
        this.obj = obj;
        this.door = (Door)oDoor;
    }

    public override void RunAction()
    {
        // TODO: Do we need to store last closed by?
        //door.lastClosedBy = obj;
        door.CloseDoor();
    }

    public override bool IsFinishedAfter()
    {
        return true;
    }
}

public class ActionOpenLock : AuroraAction
{
    public new int ActionNumber = NWScript.ACTION_OPENLOCK;
    public ActionOpenLock(AuroraObject obj) : base(obj)
    {

    }

}

public class ActionLock : AuroraAction
{
    public new int ActionNumber = NWScript.ACTION_LOCK;
    public ActionLock(AuroraObject obj) : base(obj)
    {

    }

}

public class ActionInteractObject : AuroraAction
{
    public new int ActionNumber = NWScript.ACTION_USEOBJECT;
    public ActionInteractObject(AuroraObject obj, AuroraObject oPlaceable) : base(obj)
    {

    }
}
#endregion Doors/Placeables

#region Traps

public class ActionDisableTrap : AuroraAction
{
    public new int ActionNumber = NWScript.ACTION_DISABLETRAP;
    public ActionDisableTrap(AuroraObject obj) : base(obj)
    {

    }

}

public class ActionRecoverTrap : AuroraAction
{
    public new int ActionNumber = NWScript.ACTION_RECOVERTRAP;
    public ActionRecoverTrap(AuroraObject obj) : base(obj)
    {

    }

}

public class ActionFlagTrap : AuroraAction
{
    public new int ActionNumber = NWScript.ACTION_FLAGTRAP;
    public ActionFlagTrap(AuroraObject obj) : base(obj)
    {

    }
}


public class ActionExamineTrap : AuroraAction
{
    public new int ActionNumber = NWScript.ACTION_EXAMINETRAP;
    public ActionExamineTrap(AuroraObject obj) : base(obj)
    {

    }
}


public class ActionSetTrap : AuroraAction
{
    public new int ActionNumber = NWScript.ACTION_SETTRAP;
    public ActionSetTrap(AuroraObject obj) : base(obj)
    {

    }
}
#endregion Traps

#region Objects
public class ActionUseObject : AuroraAction
{
    public new int ActionNumber = NWScript.ACTION_USEOBJECT;
    public ActionUseObject(AuroraObject obj) : base(obj)
    {

    }

}
public class ActionUnlockObject : AuroraAction
{
    public new int ActionNumber = NWScript.ACTION_USEOBJECT;
    public ActionUnlockObject(AuroraObject obj, AuroraObject oTarget) : base(obj)
    {

    }

}
public class ActionLockObject : AuroraAction
{
    public new int ActionNumber = NWScript.ACTION_LOCK;
    public ActionLockObject(AuroraObject obj, AuroraObject oTarget) : base(obj)
    {

    }

}
#endregion Objects

#region Activities
public class ActionPlayAnimation : AuroraAction
{
    public new int ActionNumber = NWScript.ACTION_INVALID;
    float time = 0f;
    int anim;
    float speed, duration;

    public ActionPlayAnimation(AuroraObject obj, int nAnimation, float fSpeed, float fDurationSeconds) : base(obj)
    {
        anim = nAnimation;
        speed = fSpeed;
        duration = fDurationSeconds;

        if (duration == 0)
        {
            // TODO: Get actual animation durations
            duration = 2f;
        }
    }

    public override void RunAction()
    {
        owner.PlayAnimation(anim);
        time += Time.deltaTime;
    }

    public override bool IsFinishedAfter()
    {
        return time >= duration;
    }
}
public class ActionRest : AuroraAction
{
    public new int ActionNumber = NWScript.ACTION_REST;
    public ActionRest(AuroraObject obj) : base(obj)
    {

    }
}

public class ActionTaunt : AuroraAction
{
    public new int ActionNumber = NWScript.ACTION_TAUNT;
    public ActionTaunt(AuroraObject obj) : base(obj)
    {

    }

}

public class ActionSit : AuroraAction
{
    public new int ActionNumber = NWScript.ACTION_SIT;
    public ActionSit(AuroraObject obj) : base(obj)
    {

    }
}
#endregion Activities

#region Spells/Abilities
public class ActionItemCastSpell : AuroraAction
{
    public new int ActionNumber = NWScript.ACTION_CASTSPELL;
    public ActionItemCastSpell(AuroraObject obj) : base(obj)
    {

    }
}

public class ActionCastSpellAtObject : AuroraAction
{
    public new int ActionNumber = NWScript.ACTION_CASTSPELL;
    public ActionCastSpellAtObject(AuroraObject obj, int nSpell, AuroraObject oTarget, int nMetaMagic, bool bCheat, int nDomainLevel, int nProjectilePathType, bool bInstantSpell) : base(obj)
    {

    }
}

public class ActionCastSpell : AuroraAction
{
    public new int ActionNumber = NWScript.ACTION_CASTSPELL;
    public ActionCastSpell(AuroraObject obj) : base(obj)
    {

    }
}

public class ActionCastSpellAtLocation : AuroraAction
{
    public new int ActionNumber = NWScript.ACTION_CASTSPELL;
    public ActionCastSpellAtLocation(AuroraObject obj, int nSpell, AuroraLocation lTargetLocation, 
        int nMetaMagic, bool bCheat, int nProjectilePathType, bool bInstantSpell) : base(obj)
    {

    }
}

public class ActionCounterSpell : AuroraAction
{
    public new int ActionNumber = NWScript.ACTION_CASTSPELL;
    public ActionCounterSpell(AuroraObject obj) : base(obj)
    {

    }
}
public class ActionHeal : AuroraAction
{
    public new int ActionNumber = NWScript.ACTION_HEAL;
    public ActionHeal(AuroraObject obj) : base(obj)
    {

    }

}
public class ActionCastFakeSpellAtObject : AuroraAction
{
    public new int ActionNumber = NWScript.ACTION_CASTSPELL;
    public ActionCastFakeSpellAtObject(AuroraObject obj, int nSpell, AuroraObject oTarget, int nProjectilePathType) : base(obj)
    {

    }

}
public class ActionCastFakeSpellAtLocation : AuroraAction
{
    public new int ActionNumber = NWScript.ACTION_CASTSPELL;
    public ActionCastFakeSpellAtLocation(AuroraObject obj, int nSpell, AuroraLocation lTarget, int nProjectilePathType) : base(obj)
    {

    }

}

//public class ApplyEffectToObject : AuroraAction
//{
//    public ApplyEffectToObject(AuroraObject obj, int nDurationType, AuroraEffect eEffect, AuroraObject oTarget, float fDuration) : base(obj)
//    {

//    }

//}
#endregion Spells/Abilities

#region Dialog
public class ActionStartConversation : AuroraAction
{
    public new int ActionNumber = NWScript.ACTION_DIALOGOBJECT;
    string sDialogResRef;
    AuroraObject converse;

    public ActionStartConversation(AuroraObject obj, AuroraObject oObjectToConverse, string sDialogResRef, bool bPrivateConversation, int nConversationType,
        bool bIgnoreStartRange, string sNameObjectToIgnore1, string sNameObjectToIgnore2, string sNameObjectToIgnore3, string sNameObjectToIgnore4,
        string sNameObjectToIgnore5, string sNameObjectToIgnore6, bool bUseLeader) : base(obj)
    {
        this.sDialogResRef = sDialogResRef;
        converse = oObjectToConverse;
    }

   public override void RunAction()
    {
        // TODO: Use all the other variables from this action
        DialogSystem dialogSystem = GameObject.Find("Dialog System").GetComponent<DialogSystem>();

        AuroraObject nonPC = owner;
        if (GameObject.Find("State System").GetComponent<StateSystem>().PC == nonPC)
        {
            nonPC = converse;
        }
        
        // Get the default conversation for the character if it's not provided
        if (sDialogResRef == "")
        {
            // NWNLexicon: "PCs can have dialogue with NPCs, placeables, triggers, and doors"
            if (nonPC.template.GetType() == typeof(AuroraUTC))
            {
                sDialogResRef = ((AuroraUTC)nonPC.template).Conversation;
            }
            else if (nonPC.template.GetType() == typeof(AuroraUTP))
            {
                sDialogResRef = ((AuroraUTP)nonPC.template).Conversation;
            }
            else if (nonPC.template.GetType() == typeof(AuroraUTT))
            {
                throw new Exception("Conversations with triggers not yet implemented");
            }
            else if (nonPC.template.GetType() == typeof(AuroraUTD))
            {
                sDialogResRef = ((AuroraUTD)nonPC.template).Conversation;
            }
            else
            {
                throw new Exception("Cannot start a dialog with object of type " + nonPC.template.GetType());
            }
        }

        if (sDialogResRef == null || sDialogResRef == "")
        {
            Debug.Log("Aborting the current dialog");
            dialogSystem.AbortDialog();

            Debug.Log("Starting new dialog if one exists");
            Debug.Log(((AuroraUTC)owner.template).Conversation);
            // Get the default dialog for the current caller
            if (((AuroraUTC)owner.template).Conversation != null && ((AuroraUTC)nonPC.template).Conversation != "")
            {
                dialogSystem.StartDialog(((AuroraUTC)owner.template).Conversation, owner);
            }
        } else
        {
            Debug.Log("Starting dialog " + sDialogResRef);
            dialogSystem.StartDialog(sDialogResRef, owner);
        }
    }

   public override bool IsFinishedAfter()
    {
        return true;
    }
}
public class ActionStopConversation : AuroraAction
{
    public new int ActionNumber = NWScript.ACTION_DIALOGOBJECT;
    public ActionStopConversation(AuroraObject obj) : base(obj)
    {

    }

    public override void RunAction()
    {
        // TODO: Should this be EndDialog or AbortDialog?
        DialogSystem dialogSystem = GameObject.Find("Dialog System").GetComponent<DialogSystem>();
        dialogSystem.EndDialog();
    }

    public override bool IsFinishedAfter()
    {
        return true;
    }
}

public class ActionResumeConversation : AuroraAction
{
    public new int ActionNumber = NWScript.ACTION_DIALOGOBJECT;
    public ActionResumeConversation(AuroraObject obj) : base(obj)
    {

    }

    public override void RunAction()
    {
        DialogSystem dlg = GameObject.Find("Dialog System").GetComponent<DialogSystem>();
        dlg.ResumeDialog();
    }

    public override bool IsFinishedAfter()
    {
        return true;
    }
}
public class ActionPauseConversation : AuroraAction
{
    public new int ActionNumber = NWScript.ACTION_DIALOGOBJECT;
    public ActionPauseConversation(AuroraObject obj) : base(obj)
    {

    }

    public override void RunAction()
    {
        DialogSystem dlg = GameObject.Find("Dialog System").GetComponent<DialogSystem>();
        dlg.PauseDialog();
    }

    public override bool IsFinishedAfter()
    {
        return true;
    }
}


public class ActionDialogObject : AuroraAction
{
    public new int ActionNumber = NWScript.ACTION_DIALOGOBJECT;
    public ActionDialogObject(AuroraObject obj) : base(obj)
    {

    }

}

public class ActionSpeakString : AuroraAction
{
    public new int ActionNumber = NWScript.ACTION_DIALOGOBJECT;
    public ActionSpeakString(AuroraObject obj, string sStringToSpeak, int nTalkVolume) : base(obj)
    {

    }
}

public class ActionSpeakStringByStrRef : AuroraAction
{
    public new int ActionNumber = NWScript.ACTION_DIALOGOBJECT;
    public ActionSpeakStringByStrRef(AuroraObject obj, int nStrRef, int nTalkVolume) : base(obj)
    {

    }
}

public class ActionBarkString : AuroraAction
{
    public new int ActionNumber = NWScript.ACTION_DIALOGOBJECT;
    public ActionBarkString(AuroraObject obj, int strRef) : base(obj)
    {

    }
}


#endregion Dialog

#region Movement
public abstract class MovementAction : AuroraAction
{
    public bool started = false;
    public bool run = false;
    public float range = 0f;
    public NavMeshAgent agent;

    public float timeout;

    public MovementAction (AuroraObject obj) : base(obj)
    {
        agent = obj.GetComponent<NavMeshAgent>();
    }

    public abstract Vector3 TargetPosition();

    public override void RunAction()
    {
        Vector3 targetPosition = TargetPosition();
        // Force the obj to look at where it's going
        if (!started)
        {
            owner.gameObject.transform.rotation = Quaternion.LookRotation(
                targetPosition - owner.gameObject.transform.position,
                owner.gameObject.transform.up
            );
            agent.updateRotation = false;
            started = true;
        }
        else
        {
            agent.updateRotation = true;
        }

        agent.SetDestination(targetPosition);
        agent.stoppingDistance = range;

        float dist = Vector3.Distance(
            owner.transform.position,
            targetPosition
        );

        if (dist < range)
        {
            owner.PlayAnimation("pause3");
            return;
        }

        // We're still moving if we reach here
        if (run)
        {
            owner.PlayAnimation("run");
        }
        else
        {
            owner.PlayAnimation("walk");
        }
    }

    public override bool IsFinishedAfter()
    {
        float dist = Vector3.Distance(
            owner.gameObject.transform.position,
            TargetPosition()
        );

        return dist < range;
    }
}

public class ActionRandomWalk : MovementAction
{
    Vector3 basePos;
    Vector3 curTarget;
    float time = 0;
    public new int ActionNumber = NWScript.ACTION_MOVETOPOINT;
    public ActionRandomWalk(AuroraObject obj) : base(obj)
    {
        basePos = obj.transform.position;
        curTarget = obj.transform.position;
        time = 6f;
    }

    public override Vector3 TargetPosition()
    {
        if (time > 6f)
        {
            time -= 6f;
            curTarget = basePos + new Vector3(
                UnityEngine.Random.Range(-2, 2),
                UnityEngine.Random.Range(-2, 2),
                UnityEngine.Random.Range(-2, 2)
            );
        }

        // Calculate a new target position
        return curTarget;
    }
}

//public class ActionFollow : MovementAction
//{
//    float time = 0f;
//    public ActionFollow(AuroraObject obj) : base(obj)
//    {

//    }

//    public override Vector3 TargetPosition()
//    {
//        if (time > 6f)
//        {
//            time -= 6f;
//            curTarget = basePos + new Vector3(
//                UnityEngine.Random.Range(-2, 2),
//                UnityEngine.Random.Range(-2, 2),
//                UnityEngine.Random.Range(-2, 2)
//            );
//        }

//        // Calculate a new target position
//        return curTarget;
//    }
//}

public class ActionFollowLeader : MovementAction
{
    // TODO: Make it not just follow the PC
    StateSystem stateSystem;
    public new int ActionNumber = NWScript.ACTION_FOLLOWLEADER;
    public ActionFollowLeader(AuroraObject obj) : base(obj)
    {
        stateSystem = GameObject.Find("State System").GetComponent<StateSystem>();
    }

    public override Vector3 TargetPosition ()
    {
        return stateSystem.PC.transform.position;
    }
}

//public class ActionMoveToPoint : MovementAction
//{
//    public ActionMoveToPoint(AuroraObject obj) : base(obj)
//    {

//    }
//}

public class ActionMoveToLocation : MovementAction
{
    AuroraLocation loc;
    public new int ActionNumber = NWScript.ACTION_MOVETOPOINT;
    public ActionMoveToLocation(AuroraObject obj, AuroraLocation location, bool bRun) : base(obj)
    {
        this.loc = location;
        this.run = bRun;

        this.range = 0.2f;
    }

    public override Vector3 TargetPosition()
    {
        return loc.GetVector();
    }
}

public class ActionMoveToObject : MovementAction
{
    AuroraObject target;
    public new int ActionNumber = NWScript.ACTION_MOVETOPOINT;
    public ActionMoveToObject(AuroraObject obj, AuroraObject other, bool bRun, float fRange) : base(obj)
    {
        target = other;
        run = bRun;
        range = 2 * fRange;
    }

    public override Vector3 TargetPosition()
    {
        return target.transform.position;
    }
}
//public class ActionMoveAwayFromLocation : MovementAction
//{
//    public ActionMoveAwayFromLocation(AuroraObject obj, AuroraLocation lMoveAwayFrom, bool bRun, float fMoveAwayRange) : base(obj)
//    {

//    }
//}
//public class ActionMoveAwayFromObject : MovementAction
//{
//    public ActionMoveAwayFromObject(AuroraObject obj, AuroraObject other, bool bRun, float fMoveAwayRange) : base(obj)
//    {
        
//    }
//}

public class ActionForceFollowObject : MovementAction
{
    public new int ActionNumber = NWScript.ACTION_FOLLOW;
    AuroraObject target;
    public ActionForceFollowObject(AuroraObject obj, AuroraObject oFollow, float fFollowDistance) : base(obj)
    {
        target = oFollow;
        range = fFollowDistance;
    }

    public override Vector3 TargetPosition()
    {
        return target.transform.position;
    }

    // This runs until the action is cleared with ClearAllActions()
    public override bool IsFinishedAfter()
    {
        return false;
    }
}

public class ActionForceMoveToLocation : MovementAction
{
    public new int ActionNumber = NWScript.ACTION_MOVETOPOINT;
    AuroraLocation loc;
    float startTime = 0f;
    public ActionForceMoveToLocation(AuroraObject obj, AuroraLocation lDestination, bool bRun, float fTimeout) : base(obj)
    {
        // TODO: Implement timeout
        loc = lDestination;
        timeout = fTimeout;
        startTime = Time.time;
    }

    public override Vector3 TargetPosition()
    {
        return loc.GetVector();
    }

    // This runs until the action is cleared with ClearAllActions()
    public override bool IsFinishedAfter()
    {
        if (Time.time - startTime > timeout)
        {
            owner.transform.position = loc.GetVector();
            return true;
        }

        return false;
    }
}

public class ActionForceMoveToObject : MovementAction
{
    public new int ActionNumber = NWScript.ACTION_MOVETOPOINT;
    AuroraObject target;
    float startTime = 0f;
    public ActionForceMoveToObject(AuroraObject obj, AuroraObject oMoveTo, bool bRun, float fRange, float fTimeout) : base(obj)
    {
        // TODO: Implement timeout
        target = oMoveTo;
        run = bRun;
        range = fRange;
        timeout = fTimeout;
        startTime = Time.time;
    }

    public override Vector3 TargetPosition()
    {
        return target.transform.position;
    }

    // This runs until the action is cleared with ClearAllActions()
    public override bool IsFinishedAfter()
    {
        if (Time.time - startTime > timeout)
        {
            owner.transform.position = target.transform.position;
            return true;
        }
        return false;
    }
}



public class ActionJumpToObject : MovementAction
{
    public new int ActionNumber = NWScript.ACTION_MOVETOPOINT;
    AuroraObject target;

    // TODO: Open question as to what the bool argument does, as per NWN Lexicon documentation
    public ActionJumpToObject(AuroraObject obj, AuroraObject oToJumpTo, bool bWalkStraightLineToPoint) : base(obj)
    {
        target = oToJumpTo;
    }

    public override void RunAction ()
    {
        owner.transform.position = target.transform.position;
    }

    public override bool IsFinishedAfter()
    {
        return true;
    }

    public override Vector3 TargetPosition ()
    {
        return target.transform.position;
    }
}
public class ActionJumpToLocation : MovementAction
{
    public new int ActionNumber = NWScript.ACTION_MOVETOPOINT;
    AuroraLocation loc;
    public ActionJumpToLocation(AuroraObject obj, AuroraLocation location) : base(obj)
    {
        loc = location;
    }

    public override void RunAction()
    {
        owner.transform.position = loc.GetVector();
    }

    public override bool IsFinishedAfter()
    {
        return true;
    }

    public override Vector3 TargetPosition()
    {
        return loc.GetVector();
    }
}
#endregion "Movement"

#region Items
public class ActionGiveItem : AuroraAction
{
    public new int ActionNumber = NWScript.ACTION_INVALID;
    public ActionGiveItem(AuroraObject obj, AuroraObject oItem, AuroraObject oGiveTo) : base(obj)
    {

    }
}
public class ActionTakeItem : AuroraAction
{
    public new int ActionNumber = NWScript.ACTION_INVALID;
    public ActionTakeItem(AuroraObject obj, AuroraObject oItem, AuroraObject oGiveTo) : base(obj)
    {

    }
}

public class ActionEquipItem : AuroraAction
{
    public new int ActionNumber = NWScript.ACTION_ATTACKOBJECT;
    public ActionEquipItem(AuroraObject obj, AuroraObject item, int nInventorySlot, bool bInstant) : base(obj)
    {

    }
}

public class ActionUnequipItem : AuroraAction
{
    public new int ActionNumber = NWScript.ACTION_ATTACKOBJECT;
    public ActionUnequipItem(AuroraObject obj, AuroraObject item, bool bInstant) : base(obj)
    {

    }

    public override void RunAction ()
    {
        //AuroraObject caller = AuroraObject.GetObjectSelf();

        //foreach (int key in caller.equipment.Keys)
        //{
        //    if (caller.equipment[key] == oItem)
        //    {
        //        caller.equipment.Remove(key);
        //    }
        //}
    }
}

public class ActionPickUpItem : AuroraAction
{
    public new int ActionNumber = NWScript.ACTION_PICKUPITEM;
    public ActionPickUpItem(AuroraObject obj, AuroraObject item) : base(obj)
    {

    }
}
//public class ActionPutDownItem : AuroraAction
//{
//    public new int ActionNumber = NWScript.;
//    public ActionPutDownItem(AuroraObject obj, AuroraObject item) : base(obj)
//    {

//    }
//}

public class ActionDropItem : AuroraAction
{
    public new int ActionNumber = NWScript.ACTION_DROPITEM;
    AuroraObject item;
    public ActionDropItem(AuroraObject obj, AuroraObject item) : base(obj)
    {
        this.item = item;
    }
}
#endregion Items

#region Utility
public class ActionWait : AuroraAction
{
    public new int ActionNumber = NWScript.ACTION_WAIT;
 
    // Do nothing for fSeconds seconds
    float elapsed = 0;
    float totalTime = 0;
    public ActionWait(AuroraObject obj, float fSeconds) : base(obj)
    {
        totalTime = fSeconds;
    }

    public override void RunAction()
    {
        elapsed += Time.deltaTime;
    }

    public override bool IsFinishedAfter()
    {
        return (elapsed >= totalTime);
    }
}

public class ActionInvalid : AuroraAction
{
    public new int ActionNumber = NWScript.ACTION_INVALID;
    public ActionInvalid(AuroraObject obj) : base(obj)
    {

    }
}

public class ActionQueueEmpty : AuroraAction
{
    public new int ActionNumber = NWScript.ACTION_QUEUEEMPTY;
    public ActionQueueEmpty(AuroraObject obj) : base(obj)
    {

    }
}

public class ActionObjDoCommand : AuroraAction
{
    public new int ActionNumber = NWScript.ACTION_INVALID;
    NCSContext context;
    public ActionObjDoCommand(AuroraObject obj, NCSContext ctx) : base(obj)
    {
        context = ctx;
    }

    public override void RunAction()
    {
        // Runs the NCS script
        StateSystem stateSystem = GameObject.Find("State System").GetComponent<StateSystem>();

        StateSystem.AuroraCommand cmd = new StateSystem.AuroraCommand()
        {
            obj = owner,
            context = context
        };
        
        stateSystem.ExecuteCommand(cmd);
    }

    public override bool IsFinishedAfter()
    {
        return true;
    }
}
//public class ApplyEffectAtLocation : AuroraAction
//{
//    public ApplyEffectAtLocation(AuroraObject obj, int nDurationType, AuroraEffect eEffect, AuroraLocation lLocation, float fDuration) : base(obj)
//    {

//    }
//}
#endregion Utility

#region Unused
public class ActionAnimalEmpathy : AuroraAction
{
    public new int ActionNumber = NWScript.ACTION_ANIMALEMPATHY;
    public ActionAnimalEmpathy(AuroraObject obj) : base(obj)
    {

    }

}

public class ActionPickpocket : AuroraAction
{
    public new int ActionNumber = NWScript.ACTION_PICKPOCKET;
    public ActionPickpocket(AuroraObject obj) : base(obj)
    {

    }

}
#endregion Unused