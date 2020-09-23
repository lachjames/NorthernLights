using System;
using System.Collections.Generic;
using static AuroraEngine.GFFObject;
using UnityEngine;
using AuroraEngine;

[Serializable]public class AuroraBIC : AuroraStruct {
    // Field definitions
    [GFF("structid", Compatibility.BOTH, ExistsIn.BASE)] public uint structid;
    [GFF("BodyPart_LBicep", Compatibility.BOTH, ExistsIn.BASE)] public Byte BodyPart_LBicep;
    [GFF("Disarmable", Compatibility.BOTH, ExistsIn.BASE)] public Byte Disarmable;
    [GFF("Appearance_Head", Compatibility.BOTH, ExistsIn.BASE)] public Byte Appearance_Head;
    [GFF("SaveFortitude", Compatibility.BOTH, ExistsIn.BASE)] public Byte SaveFortitude;
    [GFF("Race", Compatibility.BOTH, ExistsIn.BASE)] public Byte Race;
    [GFF("BodyPart_LShoul", Compatibility.BOTH, ExistsIn.BASE)] public Byte BodyPart_LShoul;
    [GFF("Con", Compatibility.BOTH, ExistsIn.BASE)] public Byte Con;
    [GFF("Tag", Compatibility.BOTH, ExistsIn.BASE)] public CExoString Tag = new CExoString();
    [GFF("ArmorPart_RFoot", Compatibility.BOTH, ExistsIn.BASE)] public Byte ArmorPart_RFoot;
    [GFF("ScriptSpawn", Compatibility.BOTH, ExistsIn.BASE)] public String ScriptSpawn;
    [GFF("NaturalAC", Compatibility.BOTH, ExistsIn.BASE)] public Byte NaturalAC;
    [GFF("SaveWill", Compatibility.BOTH, ExistsIn.BASE)] public Byte SaveWill;
    [GFF("MoraleBreakpoint", Compatibility.BOTH, ExistsIn.BASE)] public Byte MoraleBreakpoint;
    [GFF("Wings", Compatibility.BOTH, ExistsIn.BASE)] public Byte Wings;
    [GFF("Appearance_Type", Compatibility.BOTH, ExistsIn.BASE)] public UInt16 Appearance_Type;
    [GFF("ScriptUserDefine", Compatibility.BOTH, ExistsIn.BASE)] public String ScriptUserDefine;
    [GFF("BodyPart_LFArm", Compatibility.BOTH, ExistsIn.BASE)] public Byte BodyPart_LFArm;
    [GFF("Color_Skin", Compatibility.BOTH, ExistsIn.BASE)] public Byte Color_Skin;
    [GFF("ChallengeRating", Compatibility.BOTH, ExistsIn.BASE)] public Single ChallengeRating;
    [GFF("BodyPart_LShin", Compatibility.BOTH, ExistsIn.BASE)] public Byte BodyPart_LShin;
    [GFF("BodyPart_RShoul", Compatibility.BOTH, ExistsIn.BASE)] public Byte BodyPart_RShoul;
    [GFF("LawfulChaotic", Compatibility.BOTH, ExistsIn.BASE)] public Byte LawfulChaotic;
    [GFF("CurrentHitPoints", Compatibility.BOTH, ExistsIn.BASE)] public Int16 CurrentHitPoints;
    [GFF("WalkRate", Compatibility.BOTH, ExistsIn.BASE)] public Int32 WalkRate;
    [GFF("Int", Compatibility.BOTH, ExistsIn.BASE)] public Byte Int;
    [GFF("ScriptRested", Compatibility.BOTH, ExistsIn.BASE)] public String ScriptRested;
    [GFF("HitPoints", Compatibility.BOTH, ExistsIn.BASE)] public Int16 HitPoints;
    [GFF("Str", Compatibility.BOTH, ExistsIn.BASE)] public Byte Str;
    [GFF("Comment", Compatibility.BOTH, ExistsIn.BASE)] public CExoString Comment = new CExoString();
    [GFF("SaveReflex", Compatibility.BOTH, ExistsIn.BASE)] public Byte SaveReflex;
    [GFF("Dex", Compatibility.BOTH, ExistsIn.BASE)] public Byte Dex;
    [GFF("ScriptEndRound", Compatibility.BOTH, ExistsIn.BASE)] public String ScriptEndRound;
    [GFF("BodyPart_Torso", Compatibility.BOTH, ExistsIn.BASE)] public Byte BodyPart_Torso;
    [GFF("Morale", Compatibility.BOTH, ExistsIn.BASE)] public Byte Morale;
    [GFF("ScriptOnNotice", Compatibility.BOTH, ExistsIn.BASE)] public String ScriptOnNotice;
    [GFF("BodyPart_LHand", Compatibility.BOTH, ExistsIn.BASE)] public Byte BodyPart_LHand;
    [GFF("BodyPart_LFoot", Compatibility.BOTH, ExistsIn.BASE)] public Byte BodyPart_LFoot;
    [GFF("CRAdjust", Compatibility.BOTH, ExistsIn.BASE)] public Int32 CRAdjust;
    [GFF("Phenotype", Compatibility.BOTH, ExistsIn.BASE)] public Int32 Phenotype;
    [GFF("FirstName", Compatibility.BOTH, ExistsIn.BASE)] public CExoLocString FirstName = new CExoLocString();
    [GFF("BodyPart_Neck", Compatibility.BOTH, ExistsIn.BASE)] public Byte BodyPart_Neck;
    [GFF("Description", Compatibility.BOTH, ExistsIn.BASE)] public CExoLocString Description = new CExoLocString();
    [GFF("Deity", Compatibility.BOTH, ExistsIn.BASE)] public CExoString Deity = new CExoString();
    [GFF("ScriptDeath", Compatibility.BOTH, ExistsIn.BASE)] public String ScriptDeath;
    [GFF("BodyPart_RShin", Compatibility.BOTH, ExistsIn.BASE)] public Byte BodyPart_RShin;
    [GFF("BodyPart_RFArm", Compatibility.BOTH, ExistsIn.BASE)] public Byte BodyPart_RFArm;
    [GFF("Conversation", Compatibility.BOTH, ExistsIn.BASE)] public String Conversation;
    [GFF("Portrait", Compatibility.BOTH, ExistsIn.BASE)] public String Portrait;
    [GFF("Wis", Compatibility.BOTH, ExistsIn.BASE)] public Byte Wis;
    [GFF("BodyPart_LThigh", Compatibility.BOTH, ExistsIn.BASE)] public Byte BodyPart_LThigh;
    [GFF("SubRace", Compatibility.BOTH, ExistsIn.BASE)] public CExoString SubRace = new CExoString();
    [GFF("BodyPart_RBicep", Compatibility.BOTH, ExistsIn.BASE)] public Byte BodyPart_RBicep;
    [GFF("ScriptDialogue", Compatibility.BOTH, ExistsIn.BASE)] public String ScriptDialogue;
    [GFF("ScriptHeartbeat", Compatibility.BOTH, ExistsIn.BASE)] public String ScriptHeartbeat;
    [GFF("BodyPart_Pelvis", Compatibility.BOTH, ExistsIn.BASE)] public Byte BodyPart_Pelvis;
    [GFF("BodyPart_RHand", Compatibility.BOTH, ExistsIn.BASE)] public Byte BodyPart_RHand;
    [GFF("BodyPart_RThigh", Compatibility.BOTH, ExistsIn.BASE)] public Byte BodyPart_RThigh;
    [GFF("Color_Tattoo2", Compatibility.BOTH, ExistsIn.BASE)] public Byte Color_Tattoo2;
    [GFF("TemplateResRef", Compatibility.BOTH, ExistsIn.BASE)] public String TemplateResRef;
    [GFF("GoodEvil", Compatibility.BOTH, ExistsIn.BASE)] public Byte GoodEvil;
    [GFF("MoraleRecovery", Compatibility.BOTH, ExistsIn.BASE)] public Byte MoraleRecovery;
    [GFF("ScriptAttacked", Compatibility.BOTH, ExistsIn.BASE)] public String ScriptAttacked;
    [GFF("Color_Hair", Compatibility.BOTH, ExistsIn.BASE)] public Byte Color_Hair;
    [GFF("ScriptDisturbed", Compatibility.BOTH, ExistsIn.BASE)] public String ScriptDisturbed;
    [GFF("LastName", Compatibility.BOTH, ExistsIn.BASE)] public CExoLocString LastName = new CExoLocString();
    [GFF("Cha", Compatibility.BOTH, ExistsIn.BASE)] public Byte Cha;
    [GFF("ScriptDamaged", Compatibility.BOTH, ExistsIn.BASE)] public String ScriptDamaged;
    [GFF("Color_Tattoo1", Compatibility.BOTH, ExistsIn.BASE)] public Byte Color_Tattoo1;
    [GFF("Gender", Compatibility.BOTH, ExistsIn.BASE)] public Byte Gender;
    [GFF("ScriptSpellAt", Compatibility.BOTH, ExistsIn.BASE)] public String ScriptSpellAt;
    [GFF("BodyPart_Belt", Compatibility.BOTH, ExistsIn.BASE)] public Byte BodyPart_Belt;
    [GFF("Tail", Compatibility.BOTH, ExistsIn.BASE)] public Byte Tail;

    // List definitions
    [GFF("ClassList", Compatibility.BOTH, ExistsIn.BASE)] public List<AClass> ClassList = new List<AClass>();
    [GFF("SkillList", Compatibility.BOTH, ExistsIn.BASE)] public List<ASkill> SkillList = new List<ASkill>();
    [GFF("FeatList", Compatibility.BOTH, ExistsIn.BASE)] public List<AFeat> FeatList = new List<AFeat>();

    // Class definitions    
    [Serializable]public class AClass : AuroraStruct {
        // Field definitions
        [GFF("structid", Compatibility.BOTH, ExistsIn.BASE)] public uint structid;
        [GFF("ClassLevel", Compatibility.BOTH, ExistsIn.BASE)] public Int16 ClassLevel;
        [GFF("Class", Compatibility.BOTH, ExistsIn.BASE)] public Int32 Class;
    
        // List definitions
        [GFF("KnownList0", Compatibility.BOTH, ExistsIn.BASE)] public List<AKnown0> KnownList0 = new List<AKnown0>();
        [GFF("MemorizedList0", Compatibility.BOTH, ExistsIn.BASE)] public List<AMemorized0> MemorizedList0 = new List<AMemorized0>();
    
        // Class definitions    
        [Serializable]public class AKnown0 : AuroraStruct {
            // Field definitions
            [GFF("structid", Compatibility.BOTH, ExistsIn.BASE)] public uint structid;
            [GFF("Spell", Compatibility.BOTH, ExistsIn.BASE)] public UInt16 Spell;
            [GFF("SpellMetaMagic", Compatibility.BOTH, ExistsIn.BASE)] public Byte SpellMetaMagic;
            [GFF("SpellFlags", Compatibility.BOTH, ExistsIn.BASE)] public Byte SpellFlags;
            
        }
        
        [Serializable]public class AMemorized0 : AuroraStruct {
            // Field definitions
            [GFF("structid", Compatibility.BOTH, ExistsIn.BASE)] public uint structid;
            [GFF("Spell", Compatibility.BOTH, ExistsIn.BASE)] public UInt16 Spell;
            [GFF("SpellMetaMagic", Compatibility.BOTH, ExistsIn.BASE)] public Byte SpellMetaMagic;
            [GFF("SpellFlags", Compatibility.BOTH, ExistsIn.BASE)] public Byte SpellFlags;
            
        }
        
    }
    
    [Serializable]public class ASkill : AuroraStruct {
        // Field definitions
        [GFF("structid", Compatibility.BOTH, ExistsIn.BASE)] public uint structid;
        [GFF("Rank", Compatibility.BOTH, ExistsIn.BASE)] public Byte Rank;
        
    }
    
    [Serializable]public class AFeat : AuroraStruct {
        // Field definitions
        [GFF("structid", Compatibility.BOTH, ExistsIn.BASE)] public uint structid;
        [GFF("Feat", Compatibility.BOTH, ExistsIn.BASE)] public UInt16 Feat;
        
    }
    
}
