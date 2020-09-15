using System;
using System.Collections.Generic;
using static AuroraEngine.GFFObject;
using UnityEngine;
using AuroraEngine;

[Serializable]public class AuroraUTP : AuroraStruct {
    // Field definitions
    [GFF("structid")] public uint structid;
    [GFF("Tag")] public CExoString Tag;
    [GFF("LocName")] public CExoLocString LocName;
    [GFF("Description")] public CExoLocString Description;
    [GFF("TemplateResRef")] public String TemplateResRef;
    [GFF("AutoRemoveKey")] public Byte AutoRemoveKey;
    [GFF("CloseLockDC")] public Byte CloseLockDC;
    [GFF("Conversation")] public String Conversation;
    [GFF("Interruptable")] public Byte Interruptable;
    [GFF("Faction")] public UInt32 Faction;
    [GFF("Plot")] public Byte Plot;
    [GFF("Min1HP")] public Byte Min1HP;
    [GFF("KeyRequired")] public Byte KeyRequired;
    [GFF("Lockable")] public Byte Lockable;
    [GFF("Locked")] public Byte Locked;
    [GFF("OpenLockDC")] public Byte OpenLockDC;
    [GFF("PortraitId")] public UInt16 PortraitId;
    [GFF("TrapDetectable")] public Byte TrapDetectable;
    [GFF("TrapDetectDC")] public Byte TrapDetectDC;
    [GFF("TrapDisarmable")] public Byte TrapDisarmable;
    [GFF("DisarmDC")] public Byte DisarmDC;
    [GFF("TrapFlag")] public Byte TrapFlag;
    [GFF("TrapOneShot")] public Byte TrapOneShot;
    [GFF("TrapType")] public Byte TrapType;
    [GFF("KeyName")] public CExoString KeyName;
    [GFF("AnimationState")] public Byte AnimationState;
    [GFF("Appearance")] public UInt32 Appearance;
    [GFF("HP")] public Int16 HP;
    [GFF("CurrentHP")] public Int16 CurrentHP;
    [GFF("Hardness")] public Byte Hardness;
    [GFF("Fort")] public Byte Fort;
    [GFF("Ref")] public Byte Ref;
    [GFF("Will")] public Byte Will;
    [GFF("OnClosed")] public String OnClosed;
    [GFF("OnDamaged")] public String OnDamaged;
    [GFF("OnDeath")] public String OnDeath;
    [GFF("OnDisarm")] public String OnDisarm;
    [GFF("OnHeartbeat")] public String OnHeartbeat;
    [GFF("OnLock")] public String OnLock;
    [GFF("OnMeleeAttacked")] public String OnMeleeAttacked;
    [GFF("OnOpen")] public String OnOpen;
    [GFF("OnSpellCastAt")] public String OnSpellCastAt;
    [GFF("OnTrapTriggered")] public String OnTrapTriggered;
    [GFF("OnUnlock")] public String OnUnlock;
    [GFF("OnUserDefined")] public String OnUserDefined;
    [GFF("HasInventory")] public Byte HasInventory;
    [GFF("PartyInteract")] public Byte PartyInteract;
    [GFF("BodyBag")] public Byte BodyBag;
    [GFF("Static")] public Byte Static;
    [GFF("Type")] public Byte Type;
    [GFF("Useable")] public Byte Useable;
    [GFF("OnEndDialogue")] public String OnEndDialogue;
    [GFF("OnInvDisturbed")] public String OnInvDisturbed;
    [GFF("OnUsed")] public String OnUsed;
    [GFF("PaletteID")] public Byte PaletteID;
    [GFF("Comment")] public CExoString Comment;
    [GFF("IsComputer")] public Byte IsComputer;
    [GFF("Portrait")] public String Portrait;

    // List definitions
    [GFF("ItemList")] public List<AItem> ItemList = new List<AItem>();

    // Class definitions    
    [Serializable]public class AItem : AuroraStruct {
        // Field definitions
        [GFF("structid")] public uint structid;
        [GFF("InventoryRes")] public String InventoryRes;
        [GFF("Repos_PosX")] public UInt16 Repos_PosX;
        [GFF("Repos_Posy")] public UInt16 Repos_Posy;
        
    }
    
}
