using System;
using System.Collections.Generic;
using static AuroraEngine.GFFObject;
using UnityEngine;
using AuroraEngine;

[Serializable]public class AuroraBTC : AuroraStruct {
    // Field definitions
    [GFF("structid")] public uint structid;
    [GFF("FirstName")] public CExoLocString FirstName;
    [GFF("FactionID")] public UInt16 FactionID;
    [GFF("ScriptOnNotice")] public String ScriptOnNotice;
    [GFF("Deity")] public CExoString Deity;
    [GFF("ScriptSpawn")] public String ScriptSpawn;
    [GFF("Phenotype")] public Int32 Phenotype;
    [GFF("SaveFortitude")] public Byte SaveFortitude;
    [GFF("ScriptHeartbeat")] public String ScriptHeartbeat;
    [GFF("ScriptAttacked")] public String ScriptAttacked;
    [GFF("ScriptSpellAt")] public String ScriptSpellAt;
    [GFF("Disarmable")] public Byte Disarmable;
    [GFF("Con")] public Byte Con;
    [GFF("Cha")] public Byte Cha;
    [GFF("NaturalAC")] public Byte NaturalAC;
    [GFF("ScriptDisturbed")] public String ScriptDisturbed;
    [GFF("Int")] public Byte Int;
    [GFF("GoodEvil")] public Byte GoodEvil;
    [GFF("Race")] public Byte Race;
    [GFF("Tag")] public CExoString Tag;
    [GFF("Morale")] public Byte Morale;
    [GFF("ChallengeRating")] public Single ChallengeRating;
    [GFF("ScriptEndRound")] public String ScriptEndRound;
    [GFF("MoraleRecovery")] public Byte MoraleRecovery;
    [GFF("HitPoints")] public Int16 HitPoints;
    [GFF("IsPC")] public Byte IsPC;
    [GFF("Tail")] public Byte Tail;
    [GFF("Dex")] public Byte Dex;
    [GFF("SaveWill")] public Byte SaveWill;
    [GFF("ScriptDeath")] public String ScriptDeath;
    [GFF("Description")] public CExoLocString Description;
    [GFF("Portrait")] public String Portrait;
    [GFF("LastName")] public CExoLocString LastName;
    [GFF("Wings")] public Byte Wings;
    [GFF("TemplateResRef")] public String TemplateResRef;
    [GFF("Wis")] public Byte Wis;
    [GFF("ScriptDamaged")] public String ScriptDamaged;
    [GFF("MoraleBreakpoint")] public Byte MoraleBreakpoint;
    [GFF("ScriptDialogue")] public String ScriptDialogue;
    [GFF("SubRace")] public CExoString SubRace;
    [GFF("Conversation")] public String Conversation;
    [GFF("CRAdjust")] public Int32 CRAdjust;
    [GFF("Appearance_Type")] public UInt16 Appearance_Type;
    [GFF("WalkRate")] public Int32 WalkRate;
    [GFF("LawfulChaotic")] public Byte LawfulChaotic;
    [GFF("ScriptRested")] public String ScriptRested;
    [GFF("ScriptUserDefine")] public String ScriptUserDefine;
    [GFF("Str")] public Byte Str;
    [GFF("Gender")] public Byte Gender;
    [GFF("Comment")] public CExoString Comment;
    [GFF("SaveReflex")] public Byte SaveReflex;
    [GFF("PaletteID")] public Byte PaletteID;
    [GFF("Interruptable")] public Byte Interruptable;
    [GFF("ScriptOnBlocked")] public String ScriptOnBlocked;
    [GFF("SoundSet")] public UInt32 SoundSet;
    [GFF("CurrentHitPoints")] public Int16 CurrentHitPoints;
    [GFF("Appearance_Head")] public Byte Appearance_Head;
    [GFF("Plot")] public Byte Plot;
    [GFF("PerceptionRange")] public Byte PerceptionRange;

    // List definitions
    [GFF("SkillList")] public List<ASkill> SkillList = new List<ASkill>();
    [GFF("ClassList")] public List<AClass> ClassList = new List<AClass>();
    [GFF("SpecAbilityList")] public List<ASpecAbility> SpecAbilityList = new List<ASpecAbility>();
    [GFF("Equip_ItemList")] public List<AEquip_Item> Equip_ItemList = new List<AEquip_Item>();

    // Class definitions    
    [Serializable]public class ASkill : AuroraStruct {
        // Field definitions
        [GFF("structid")] public uint structid;
        [GFF("Rank")] public Byte Rank;
        
    }
    
    [Serializable]public class AClass : AuroraStruct {
        // Field definitions
        [GFF("structid")] public uint structid;
        [GFF("ClassLevel")] public Int16 ClassLevel;
        [GFF("Class")] public Int32 Class;
        
    }
    
    [Serializable]public class ASpecAbility : AuroraStruct {
        // Field definitions
        [GFF("structid")] public uint structid;
        [GFF("Spell")] public UInt16 Spell;
        [GFF("SpellFlags")] public Byte SpellFlags;
        [GFF("SpellCasterLevel")] public Byte SpellCasterLevel;
        
    }
    
    [Serializable]public class AEquip_Item : AuroraStruct {
        // Field definitions
        [GFF("structid")] public uint structid;
        [GFF("EquippedRes")] public String EquippedRes;
        
    }
    
}
