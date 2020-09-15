using System;
using System.Collections.Generic;
using static AuroraEngine.GFFObject;
using UnityEngine;

public class AuroraUTP : AuroraStruct {
    // Field definitions
    public uint structid;
    public String Tag;
    public CExoLocString LocName;
    public CExoLocString Description;
    public String TemplateResRef;
    public Byte AutoRemoveKey;
    public Byte CloseLockDC;
    public String Conversation;
    public Byte Interruptable;
    public UInt32 Faction;
    public Byte Plot;
    public Byte Min1HP;
    public Byte KeyRequired;
    public Byte Lockable;
    public Byte Locked;
    public Byte OpenLockDC;
    public UInt16 PortraitId;
    public Byte TrapDetectable;
    public Byte TrapDetectDC;
    public Byte TrapDisarmable;
    public Byte DisarmDC;
    public Byte TrapFlag;
    public Byte TrapOneShot;
    public Byte TrapType;
    public String KeyName;
    public Byte AnimationState;
    public UInt32 Appearance;
    public Int16 HP;
    public Int16 CurrentHP;
    public Byte Hardness;
    public Byte Fort;
    public Byte Ref;
    public Byte Will;
    public String OnClosed;
    public String OnDamaged;
    public String OnDeath;
    public String OnDisarm;
    public String OnHeartbeat;
    public String OnLock;
    public String OnMeleeAttacked;
    public String OnOpen;
    public String OnSpellCastAt;
    public String OnTrapTriggered;
    public String OnUnlock;
    public String OnUserDefined;
    public Byte HasInventory;
    public Byte PartyInteract;
    public Byte BodyBag;
    public Byte Static;
    public Byte Type;
    public Byte Useable;
    public String OnEndDialogue;
    public String OnInvDisturbed;
    public String OnUsed;
    public Byte PaletteID;
    public String Comment;
    public Byte IsComputer;
    public String Portrait;

    // List definitions
    public List<AItem> ItemList;

    // Class definitions    
    public class AItem : AuroraStruct {
        // Field definitions
        public uint structid;
        public String InventoryRes;
        public UInt16 Repos_PosX;
        public UInt16 Repos_Posy;
        
    }
    
}
