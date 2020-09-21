using System;
using System.Collections.Generic;
using static AuroraEngine.GFFObject;
using UnityEngine;
using AuroraEngine;

[Serializable]public class AuroraUTP : AuroraStruct {
    // Field definitions
    [GFF("structid", Compatibility.BOTH, ExistsIn.BASE)] public uint structid;
    [GFF("Tag", Compatibility.BOTH, ExistsIn.BASE)] public CExoString Tag;
    [GFF("LocName", Compatibility.BOTH, ExistsIn.BASE)] public CExoLocString LocName;
    [GFF("Description", Compatibility.BOTH, ExistsIn.BASE)] public CExoLocString Description;
    [GFF("TemplateResRef", Compatibility.BOTH, ExistsIn.BASE)] public String TemplateResRef;
    [GFF("AutoRemoveKey", Compatibility.BOTH, ExistsIn.BASE)] public Byte AutoRemoveKey;
    [GFF("CloseLockDC", Compatibility.BOTH, ExistsIn.BASE)] public Byte CloseLockDC;
    [GFF("Conversation", Compatibility.BOTH, ExistsIn.BASE)] public String Conversation;
    [GFF("Interruptable", Compatibility.BOTH, ExistsIn.BASE)] public Byte Interruptable;
    [GFF("Faction", Compatibility.BOTH, ExistsIn.BASE)] public UInt32 Faction;
    [GFF("Plot", Compatibility.BOTH, ExistsIn.BASE)] public Byte Plot;
    [GFF("Min1HP", Compatibility.BOTH, ExistsIn.BASE)] public Byte Min1HP;
    [GFF("KeyRequired", Compatibility.BOTH, ExistsIn.BASE)] public Byte KeyRequired;
    [GFF("Lockable", Compatibility.BOTH, ExistsIn.BASE)] public Byte Lockable;
    [GFF("Locked", Compatibility.BOTH, ExistsIn.BASE)] public Byte Locked;
    [GFF("OpenLockDC", Compatibility.BOTH, ExistsIn.BASE)] public Byte OpenLockDC;
    [GFF("PortraitId", Compatibility.BOTH, ExistsIn.BASE)] public UInt16 PortraitId;
    [GFF("TrapDetectable", Compatibility.BOTH, ExistsIn.BASE)] public Byte TrapDetectable;
    [GFF("TrapDetectDC", Compatibility.BOTH, ExistsIn.BASE)] public Byte TrapDetectDC;
    [GFF("TrapDisarmable", Compatibility.BOTH, ExistsIn.BASE)] public Byte TrapDisarmable;
    [GFF("DisarmDC", Compatibility.BOTH, ExistsIn.BASE)] public Byte DisarmDC;
    [GFF("TrapFlag", Compatibility.BOTH, ExistsIn.BASE)] public Byte TrapFlag;
    [GFF("TrapOneShot", Compatibility.BOTH, ExistsIn.BASE)] public Byte TrapOneShot;
    [GFF("TrapType", Compatibility.BOTH, ExistsIn.BASE)] public Byte TrapType;
    [GFF("KeyName", Compatibility.BOTH, ExistsIn.BASE)] public CExoString KeyName;
    [GFF("AnimationState", Compatibility.BOTH, ExistsIn.BASE)] public Byte AnimationState;
    [GFF("Appearance", Compatibility.BOTH, ExistsIn.BASE)] public UInt32 Appearance;
    [GFF("HP", Compatibility.BOTH, ExistsIn.BASE)] public Int16 HP;
    [GFF("CurrentHP", Compatibility.BOTH, ExistsIn.BASE)] public Int16 CurrentHP;
    [GFF("Hardness", Compatibility.BOTH, ExistsIn.BASE)] public Byte Hardness;
    [GFF("Fort", Compatibility.BOTH, ExistsIn.BASE)] public Byte Fort;
    [GFF("Ref", Compatibility.BOTH, ExistsIn.BASE)] public Byte Ref;
    [GFF("Will", Compatibility.BOTH, ExistsIn.BASE)] public Byte Will;
    [GFF("OnClosed", Compatibility.BOTH, ExistsIn.BASE)] public String OnClosed;
    [GFF("OnDamaged", Compatibility.BOTH, ExistsIn.BASE)] public String OnDamaged;
    [GFF("OnDeath", Compatibility.BOTH, ExistsIn.BASE)] public String OnDeath;
    [GFF("OnDisarm", Compatibility.BOTH, ExistsIn.BASE)] public String OnDisarm;
    [GFF("OnHeartbeat", Compatibility.BOTH, ExistsIn.BASE)] public String OnHeartbeat;
    [GFF("OnLock", Compatibility.BOTH, ExistsIn.BASE)] public String OnLock;
    [GFF("OnMeleeAttacked", Compatibility.BOTH, ExistsIn.BASE)] public String OnMeleeAttacked;
    [GFF("OnOpen", Compatibility.BOTH, ExistsIn.BASE)] public String OnOpen;
    [GFF("OnSpellCastAt", Compatibility.BOTH, ExistsIn.BASE)] public String OnSpellCastAt;
    [GFF("OnTrapTriggered", Compatibility.BOTH, ExistsIn.BASE)] public String OnTrapTriggered;
    [GFF("OnUnlock", Compatibility.BOTH, ExistsIn.BASE)] public String OnUnlock;
    [GFF("OnUserDefined", Compatibility.BOTH, ExistsIn.BASE)] public String OnUserDefined;
    [GFF("HasInventory", Compatibility.BOTH, ExistsIn.BASE)] public Byte HasInventory;
    [GFF("PartyInteract", Compatibility.BOTH, ExistsIn.BASE)] public Byte PartyInteract;
    [GFF("BodyBag", Compatibility.BOTH, ExistsIn.BASE)] public Byte BodyBag;
    [GFF("Static", Compatibility.BOTH, ExistsIn.BASE)] public Byte Static;
    [GFF("Type", Compatibility.BOTH, ExistsIn.BASE)] public Byte Type;
    [GFF("Useable", Compatibility.BOTH, ExistsIn.BASE)] public Byte Useable;
    [GFF("OnEndDialogue", Compatibility.BOTH, ExistsIn.BASE)] public String OnEndDialogue;
    [GFF("OnInvDisturbed", Compatibility.BOTH, ExistsIn.BASE)] public String OnInvDisturbed;
    [GFF("OnUsed", Compatibility.BOTH, ExistsIn.BASE)] public String OnUsed;
    [GFF("PaletteID", Compatibility.BOTH, ExistsIn.BASE)] public Byte PaletteID;
    [GFF("Comment", Compatibility.BOTH, ExistsIn.BASE)] public CExoString Comment;
    [GFF("IsComputer", Compatibility.BOTH, ExistsIn.BASE)] public Byte IsComputer;
    [GFF("Portrait", Compatibility.BOTH, ExistsIn.BASE)] public String Portrait;
    [GFF("NotBlastable", Compatibility.TSL, ExistsIn.BASE)] public Byte NotBlastable;
    [GFF("OpenLockDiff", Compatibility.TSL, ExistsIn.BASE)] public Byte OpenLockDiff;
    [GFF("OpenLockDiffMod", Compatibility.TSL, ExistsIn.BASE)] public Char OpenLockDiffMod;
    [GFF("OnFailToOpen", Compatibility.TSL, ExistsIn.BASE)] public String OnFailToOpen;
    [GFF("KTInfoVersion", Compatibility.TSL, ExistsIn.BASE)] public CExoString KTInfoVersion;
    [GFF("KTInfoDate", Compatibility.TSL, ExistsIn.BASE)] public CExoString KTInfoDate;
    [GFF("KTGameVerIndex", Compatibility.TSL, ExistsIn.BASE)] public Int32 KTGameVerIndex;

    // List definitions
    [GFF("ItemList", Compatibility.BOTH, ExistsIn.BASE)] public List<AItem> ItemList = new List<AItem>();

    // Class definitions    
    [Serializable]public class AItem : AuroraStruct {
        // Field definitions
        [GFF("structid", Compatibility.BOTH, ExistsIn.BASE)] public uint structid;
        [GFF("InventoryRes", Compatibility.BOTH, ExistsIn.BASE)] public String InventoryRes;
        [GFF("Repos_PosX", Compatibility.BOTH, ExistsIn.BASE)] public UInt16 Repos_PosX;
        [GFF("Repos_Posy", Compatibility.BOTH, ExistsIn.BASE)] public UInt16 Repos_Posy;
        [GFF("Repos_PosY", Compatibility.TSL, ExistsIn.BASE)] public UInt16 Repos_PosY;
        [GFF("Dropable", Compatibility.TSL, ExistsIn.BASE)] public Byte Dropable;
        
    }
    
}
