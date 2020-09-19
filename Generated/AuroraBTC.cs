using System;
using System.Collections.Generic;
using static AuroraEngine.GFFObject;
using UnityEngine;
using AuroraEngine;

[Serializable]public class AuroraBTC : AuroraStruct {
    // Field definitions
    [GFF("structid", Compatibility.BOTH, ExistsIn.BASE)] public uint structid;
    [GFF("FirstName", Compatibility.BOTH, ExistsIn.BASE)] public CExoLocString FirstName;
    [GFF("FactionID", Compatibility.BOTH, ExistsIn.BASE)] public UInt16 FactionID;
    [GFF("ScriptOnNotice", Compatibility.BOTH, ExistsIn.BASE)] public String ScriptOnNotice;
    [GFF("Deity", Compatibility.BOTH, ExistsIn.BASE)] public CExoString Deity;
    [GFF("ScriptSpawn", Compatibility.BOTH, ExistsIn.BASE)] public String ScriptSpawn;
    [GFF("Phenotype", Compatibility.BOTH, ExistsIn.BASE)] public Int32 Phenotype;
    [GFF("SaveFortitude", Compatibility.BOTH, ExistsIn.BASE)] public Byte SaveFortitude;
    [GFF("ScriptHeartbeat", Compatibility.BOTH, ExistsIn.BASE)] public String ScriptHeartbeat;
    [GFF("ScriptAttacked", Compatibility.BOTH, ExistsIn.BASE)] public String ScriptAttacked;
    [GFF("ScriptSpellAt", Compatibility.BOTH, ExistsIn.BASE)] public String ScriptSpellAt;
    [GFF("Disarmable", Compatibility.BOTH, ExistsIn.BASE)] public Byte Disarmable;
    [GFF("Con", Compatibility.BOTH, ExistsIn.BASE)] public Byte Con;
    [GFF("Cha", Compatibility.BOTH, ExistsIn.BASE)] public Byte Cha;
    [GFF("NaturalAC", Compatibility.BOTH, ExistsIn.BASE)] public Byte NaturalAC;
    [GFF("ScriptDisturbed", Compatibility.BOTH, ExistsIn.BASE)] public String ScriptDisturbed;
    [GFF("Int", Compatibility.BOTH, ExistsIn.BASE)] public Byte Int;
    [GFF("GoodEvil", Compatibility.BOTH, ExistsIn.BASE)] public Byte GoodEvil;
    [GFF("Race", Compatibility.BOTH, ExistsIn.BASE)] public Byte Race;
    [GFF("Tag", Compatibility.BOTH, ExistsIn.BASE)] public CExoString Tag;
    [GFF("Morale", Compatibility.BOTH, ExistsIn.BASE)] public Byte Morale;
    [GFF("ChallengeRating", Compatibility.BOTH, ExistsIn.BASE)] public Single ChallengeRating;
    [GFF("ScriptEndRound", Compatibility.BOTH, ExistsIn.BASE)] public String ScriptEndRound;
    [GFF("MoraleRecovery", Compatibility.BOTH, ExistsIn.BASE)] public Byte MoraleRecovery;
    [GFF("HitPoints", Compatibility.BOTH, ExistsIn.BASE)] public Int16 HitPoints;
    [GFF("IsPC", Compatibility.BOTH, ExistsIn.BASE)] public Byte IsPC;
    [GFF("Tail", Compatibility.BOTH, ExistsIn.BASE)] public Byte Tail;
    [GFF("Dex", Compatibility.BOTH, ExistsIn.BASE)] public Byte Dex;
    [GFF("SaveWill", Compatibility.BOTH, ExistsIn.BASE)] public Byte SaveWill;
    [GFF("ScriptDeath", Compatibility.BOTH, ExistsIn.BASE)] public String ScriptDeath;
    [GFF("Description", Compatibility.BOTH, ExistsIn.BASE)] public CExoLocString Description;
    [GFF("Portrait", Compatibility.BOTH, ExistsIn.BASE)] public String Portrait;
    [GFF("LastName", Compatibility.BOTH, ExistsIn.BASE)] public CExoLocString LastName;
    [GFF("Wings", Compatibility.BOTH, ExistsIn.BASE)] public Byte Wings;
    [GFF("TemplateResRef", Compatibility.BOTH, ExistsIn.BASE)] public String TemplateResRef;
    [GFF("Wis", Compatibility.BOTH, ExistsIn.BASE)] public Byte Wis;
    [GFF("ScriptDamaged", Compatibility.BOTH, ExistsIn.BASE)] public String ScriptDamaged;
    [GFF("MoraleBreakpoint", Compatibility.BOTH, ExistsIn.BASE)] public Byte MoraleBreakpoint;
    [GFF("ScriptDialogue", Compatibility.BOTH, ExistsIn.BASE)] public String ScriptDialogue;
    [GFF("SubRace", Compatibility.BOTH, ExistsIn.BASE)] public CExoString SubRace;
    [GFF("Conversation", Compatibility.BOTH, ExistsIn.BASE)] public String Conversation;
    [GFF("CRAdjust", Compatibility.BOTH, ExistsIn.BASE)] public Int32 CRAdjust;
    [GFF("Appearance_Type", Compatibility.BOTH, ExistsIn.BASE)] public UInt16 Appearance_Type;
    [GFF("WalkRate", Compatibility.BOTH, ExistsIn.BASE)] public Int32 WalkRate;
    [GFF("LawfulChaotic", Compatibility.BOTH, ExistsIn.BASE)] public Byte LawfulChaotic;
    [GFF("ScriptRested", Compatibility.BOTH, ExistsIn.BASE)] public String ScriptRested;
    [GFF("ScriptUserDefine", Compatibility.BOTH, ExistsIn.BASE)] public String ScriptUserDefine;
    [GFF("Str", Compatibility.BOTH, ExistsIn.BASE)] public Byte Str;
    [GFF("Gender", Compatibility.BOTH, ExistsIn.BASE)] public Byte Gender;
    [GFF("Comment", Compatibility.BOTH, ExistsIn.BASE)] public CExoString Comment;
    [GFF("SaveReflex", Compatibility.BOTH, ExistsIn.BASE)] public Byte SaveReflex;
    [GFF("PaletteID", Compatibility.BOTH, ExistsIn.BASE)] public Byte PaletteID;
    [GFF("Interruptable", Compatibility.BOTH, ExistsIn.BASE)] public Byte Interruptable;
    [GFF("ScriptOnBlocked", Compatibility.BOTH, ExistsIn.BASE)] public String ScriptOnBlocked;
    [GFF("SoundSet", Compatibility.BOTH, ExistsIn.BASE)] public UInt32 SoundSet;
    [GFF("CurrentHitPoints", Compatibility.BOTH, ExistsIn.BASE)] public Int16 CurrentHitPoints;
    [GFF("Appearance_Head", Compatibility.BOTH, ExistsIn.BASE)] public Byte Appearance_Head;
    [GFF("Plot", Compatibility.BOTH, ExistsIn.BASE)] public Byte Plot;
    [GFF("PerceptionRange", Compatibility.BOTH, ExistsIn.BASE)] public Byte PerceptionRange;

    // List definitions
    [GFF("SkillList", Compatibility.BOTH, ExistsIn.BASE)] public List<ASkill> SkillList = new List<ASkill>();
    [GFF("ClassList", Compatibility.BOTH, ExistsIn.BASE)] public List<AClass> ClassList = new List<AClass>();
    [GFF("SpecAbilityList", Compatibility.BOTH, ExistsIn.BASE)] public List<ASpecAbility> SpecAbilityList = new List<ASpecAbility>();
    [GFF("Equip_ItemList", Compatibility.BOTH, ExistsIn.BASE)] public List<AEquip_Item> Equip_ItemList = new List<AEquip_Item>();

    // Class definitions    
    [Serializable]public class ASkill : AuroraStruct {
        // Field definitions
        [GFF("structid", Compatibility.BOTH, ExistsIn.BASE)] public uint structid;
        [GFF("Rank", Compatibility.BOTH, ExistsIn.BASE)] public Byte Rank;
        
    }
    
    [Serializable]public class AClass : AuroraStruct {
        // Field definitions
        [GFF("structid", Compatibility.BOTH, ExistsIn.BASE)] public uint structid;
        [GFF("ClassLevel", Compatibility.BOTH, ExistsIn.BASE)] public Int16 ClassLevel;
        [GFF("Class", Compatibility.BOTH, ExistsIn.BASE)] public Int32 Class;
        
    }
    
    [Serializable]public class ASpecAbility : AuroraStruct {
        // Field definitions
        [GFF("structid", Compatibility.BOTH, ExistsIn.BASE)] public uint structid;
        [GFF("Spell", Compatibility.BOTH, ExistsIn.BASE)] public UInt16 Spell;
        [GFF("SpellFlags", Compatibility.BOTH, ExistsIn.BASE)] public Byte SpellFlags;
        [GFF("SpellCasterLevel", Compatibility.BOTH, ExistsIn.BASE)] public Byte SpellCasterLevel;
        
    }
    
    [Serializable]public class AEquip_Item : AuroraStruct {
        // Field definitions
        [GFF("structid", Compatibility.BOTH, ExistsIn.BASE)] public uint structid;
        [GFF("EquippedRes", Compatibility.BOTH, ExistsIn.BASE)] public String EquippedRes;
        
    }
    
}
