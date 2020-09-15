using System;
using System.Collections.Generic;
using static AuroraEngine.GFFObject;
using UnityEngine;
using AuroraEngine;

[Serializable]public class AuroraBIC : AuroraStruct {
    // Field definitions
    [GFF("structid")] public uint structid;
    [GFF("BodyPart_LBicep")] public Byte BodyPart_LBicep;
    [GFF("Disarmable")] public Byte Disarmable;
    [GFF("Appearance_Head")] public Byte Appearance_Head;
    [GFF("SaveFortitude")] public Byte SaveFortitude;
    [GFF("Race")] public Byte Race;
    [GFF("BodyPart_LShoul")] public Byte BodyPart_LShoul;
    [GFF("Con")] public Byte Con;
    [GFF("Tag")] public CExoString Tag;
    [GFF("ArmorPart_RFoot")] public Byte ArmorPart_RFoot;
    [GFF("ScriptSpawn")] public String ScriptSpawn;
    [GFF("NaturalAC")] public Byte NaturalAC;
    [GFF("SaveWill")] public Byte SaveWill;
    [GFF("MoraleBreakpoint")] public Byte MoraleBreakpoint;
    [GFF("Wings")] public Byte Wings;
    [GFF("Appearance_Type")] public UInt16 Appearance_Type;
    [GFF("ScriptUserDefine")] public String ScriptUserDefine;
    [GFF("BodyPart_LFArm")] public Byte BodyPart_LFArm;
    [GFF("Color_Skin")] public Byte Color_Skin;
    [GFF("ChallengeRating")] public Single ChallengeRating;
    [GFF("BodyPart_LShin")] public Byte BodyPart_LShin;
    [GFF("BodyPart_RShoul")] public Byte BodyPart_RShoul;
    [GFF("LawfulChaotic")] public Byte LawfulChaotic;
    [GFF("CurrentHitPoints")] public Int16 CurrentHitPoints;
    [GFF("WalkRate")] public Int32 WalkRate;
    [GFF("Int")] public Byte Int;
    [GFF("ScriptRested")] public String ScriptRested;
    [GFF("HitPoints")] public Int16 HitPoints;
    [GFF("Str")] public Byte Str;
    [GFF("Comment")] public CExoString Comment;
    [GFF("SaveReflex")] public Byte SaveReflex;
    [GFF("Dex")] public Byte Dex;
    [GFF("ScriptEndRound")] public String ScriptEndRound;
    [GFF("BodyPart_Torso")] public Byte BodyPart_Torso;
    [GFF("Morale")] public Byte Morale;
    [GFF("ScriptOnNotice")] public String ScriptOnNotice;
    [GFF("BodyPart_LHand")] public Byte BodyPart_LHand;
    [GFF("BodyPart_LFoot")] public Byte BodyPart_LFoot;
    [GFF("CRAdjust")] public Int32 CRAdjust;
    [GFF("Phenotype")] public Int32 Phenotype;
    [GFF("FirstName")] public CExoLocString FirstName;
    [GFF("BodyPart_Neck")] public Byte BodyPart_Neck;
    [GFF("Description")] public CExoLocString Description;
    [GFF("Deity")] public CExoString Deity;
    [GFF("ScriptDeath")] public String ScriptDeath;
    [GFF("BodyPart_RShin")] public Byte BodyPart_RShin;
    [GFF("BodyPart_RFArm")] public Byte BodyPart_RFArm;
    [GFF("Conversation")] public String Conversation;
    [GFF("Portrait")] public String Portrait;
    [GFF("Wis")] public Byte Wis;
    [GFF("BodyPart_LThigh")] public Byte BodyPart_LThigh;
    [GFF("SubRace")] public CExoString SubRace;
    [GFF("BodyPart_RBicep")] public Byte BodyPart_RBicep;
    [GFF("ScriptDialogue")] public String ScriptDialogue;
    [GFF("ScriptHeartbeat")] public String ScriptHeartbeat;
    [GFF("BodyPart_Pelvis")] public Byte BodyPart_Pelvis;
    [GFF("BodyPart_RHand")] public Byte BodyPart_RHand;
    [GFF("BodyPart_RThigh")] public Byte BodyPart_RThigh;
    [GFF("Color_Tattoo2")] public Byte Color_Tattoo2;
    [GFF("TemplateResRef")] public String TemplateResRef;
    [GFF("GoodEvil")] public Byte GoodEvil;
    [GFF("MoraleRecovery")] public Byte MoraleRecovery;
    [GFF("ScriptAttacked")] public String ScriptAttacked;
    [GFF("Color_Hair")] public Byte Color_Hair;
    [GFF("ScriptDisturbed")] public String ScriptDisturbed;
    [GFF("LastName")] public CExoLocString LastName;
    [GFF("Cha")] public Byte Cha;
    [GFF("ScriptDamaged")] public String ScriptDamaged;
    [GFF("Color_Tattoo1")] public Byte Color_Tattoo1;
    [GFF("Gender")] public Byte Gender;
    [GFF("ScriptSpellAt")] public String ScriptSpellAt;
    [GFF("BodyPart_Belt")] public Byte BodyPart_Belt;
    [GFF("Tail")] public Byte Tail;

    // List definitions
    [GFF("ClassList")] public List<AClass> ClassList = new List<AClass>();
    [GFF("SkillList")] public List<ASkill> SkillList = new List<ASkill>();
    [GFF("FeatList")] public List<AFeat> FeatList = new List<AFeat>();

    // Class definitions    
    [Serializable]public class AClass : AuroraStruct {
        // Field definitions
        [GFF("structid")] public uint structid;
        [GFF("ClassLevel")] public Int16 ClassLevel;
        [GFF("Class")] public Int32 Class;
    
        // List definitions
        [GFF("KnownList0")] public List<AKnown0> KnownList0 = new List<AKnown0>();
        [GFF("MemorizedList0")] public List<AMemorized0> MemorizedList0 = new List<AMemorized0>();
    
        // Class definitions    
        [Serializable]public class AKnown0 : AuroraStruct {
            // Field definitions
            [GFF("structid")] public uint structid;
            [GFF("Spell")] public UInt16 Spell;
            [GFF("SpellMetaMagic")] public Byte SpellMetaMagic;
            [GFF("SpellFlags")] public Byte SpellFlags;
            
        }
        
        [Serializable]public class AMemorized0 : AuroraStruct {
            // Field definitions
            [GFF("structid")] public uint structid;
            [GFF("Spell")] public UInt16 Spell;
            [GFF("SpellMetaMagic")] public Byte SpellMetaMagic;
            [GFF("SpellFlags")] public Byte SpellFlags;
            
        }
        
    }
    
    [Serializable]public class ASkill : AuroraStruct {
        // Field definitions
        [GFF("structid")] public uint structid;
        [GFF("Rank")] public Byte Rank;
        
    }
    
    [Serializable]public class AFeat : AuroraStruct {
        // Field definitions
        [GFF("structid")] public uint structid;
        [GFF("Feat")] public UInt16 Feat;
        
    }
    
}
