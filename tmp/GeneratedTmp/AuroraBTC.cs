using System;
using System.Collections.Generic;
using static AuroraEngine.GFFObject;
using UnityEngine;

public class AuroraBTC : AuroraStruct {
    // Field definitions
    public uint structid;
    public CExoLocString FirstName;
    public UInt16 FactionID;
    public String ScriptOnNotice;
    public String Deity;
    public String ScriptSpawn;
    public Int32 Phenotype;
    public Byte SaveFortitude;
    public String ScriptHeartbeat;
    public String ScriptAttacked;
    public String ScriptSpellAt;
    public Byte Disarmable;
    public Byte Con;
    public Byte Cha;
    public Byte NaturalAC;
    public String ScriptDisturbed;
    public Byte Int;
    public Byte GoodEvil;
    public Byte Race;
    public String Tag;
    public Byte Morale;
    public Single ChallengeRating;
    public String ScriptEndRound;
    public Byte MoraleRecovery;
    public Int16 HitPoints;
    public Byte IsPC;
    public Byte Tail;
    public Byte Dex;
    public Byte SaveWill;
    public String ScriptDeath;
    public CExoLocString Description;
    public String Portrait;
    public CExoLocString LastName;
    public Byte Wings;
    public String TemplateResRef;
    public Byte Wis;
    public String ScriptDamaged;
    public Byte MoraleBreakpoint;
    public String ScriptDialogue;
    public String SubRace;
    public String Conversation;
    public Int32 CRAdjust;
    public UInt16 Appearance_Type;
    public Int32 WalkRate;
    public Byte LawfulChaotic;
    public String ScriptRested;
    public String ScriptUserDefine;
    public Byte Str;
    public Byte Gender;
    public String Comment;
    public Byte SaveReflex;
    public Byte PaletteID;
    public Byte Interruptable;
    public String ScriptOnBlocked;
    public UInt32 SoundSet;
    public Int16 CurrentHitPoints;
    public Byte Appearance_Head;
    public Byte Plot;
    public Byte PerceptionRange;

    // List definitions
    public List<ASkill> SkillList;
    public List<AClass> ClassList;
    public List<ASpecAbility> SpecAbilityList;
    public List<AEquip_Item> Equip_ItemList;

    // Class definitions    
    public class ASkill : AuroraStruct {
        // Field definitions
        public uint structid;
        public Byte Rank;
        
    }
    
    public class AClass : AuroraStruct {
        // Field definitions
        public uint structid;
        public Int16 ClassLevel;
        public Int32 Class;
        
    }
    
    public class ASpecAbility : AuroraStruct {
        // Field definitions
        public uint structid;
        public UInt16 Spell;
        public Byte SpellFlags;
        public Byte SpellCasterLevel;
        
    }
    
    public class AEquip_Item : AuroraStruct {
        // Field definitions
        public uint structid;
        public String EquippedRes;
        
    }
    
}
