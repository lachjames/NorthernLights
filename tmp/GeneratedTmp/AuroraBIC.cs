using System;
using System.Collections.Generic;
using static AuroraEngine.GFFObject;
using UnityEngine;

public class AuroraBIC : AuroraStruct {
    // Field definitions
    public uint structid;
    public Byte BodyPart_LBicep;
    public Byte Disarmable;
    public Byte Appearance_Head;
    public Byte SaveFortitude;
    public Byte Race;
    public Byte BodyPart_LShoul;
    public Byte Con;
    public String Tag;
    public Byte ArmorPart_RFoot;
    public String ScriptSpawn;
    public Byte NaturalAC;
    public Byte SaveWill;
    public Byte MoraleBreakpoint;
    public Byte Wings;
    public UInt16 Appearance_Type;
    public String ScriptUserDefine;
    public Byte BodyPart_LFArm;
    public Byte Color_Skin;
    public Single ChallengeRating;
    public Byte BodyPart_LShin;
    public Byte BodyPart_RShoul;
    public Byte LawfulChaotic;
    public Int16 CurrentHitPoints;
    public Int32 WalkRate;
    public Byte Int;
    public String ScriptRested;
    public Int16 HitPoints;
    public Byte Str;
    public String Comment;
    public Byte SaveReflex;
    public Byte Dex;
    public String ScriptEndRound;
    public Byte BodyPart_Torso;
    public Byte Morale;
    public String ScriptOnNotice;
    public Byte BodyPart_LHand;
    public Byte BodyPart_LFoot;
    public Int32 CRAdjust;
    public Int32 Phenotype;
    public CExoLocString FirstName;
    public Byte BodyPart_Neck;
    public CExoLocString Description;
    public String Deity;
    public String ScriptDeath;
    public Byte BodyPart_RShin;
    public Byte BodyPart_RFArm;
    public String Conversation;
    public String Portrait;
    public Byte Wis;
    public Byte BodyPart_LThigh;
    public String SubRace;
    public Byte BodyPart_RBicep;
    public String ScriptDialogue;
    public String ScriptHeartbeat;
    public Byte BodyPart_Pelvis;
    public Byte BodyPart_RHand;
    public Byte BodyPart_RThigh;
    public Byte Color_Tattoo2;
    public String TemplateResRef;
    public Byte GoodEvil;
    public Byte MoraleRecovery;
    public String ScriptAttacked;
    public Byte Color_Hair;
    public String ScriptDisturbed;
    public CExoLocString LastName;
    public Byte Cha;
    public String ScriptDamaged;
    public Byte Color_Tattoo1;
    public Byte Gender;
    public String ScriptSpellAt;
    public Byte BodyPart_Belt;
    public Byte Tail;

    // List definitions
    public List<AClass> ClassList;
    public List<ASkill> SkillList;
    public List<AFeat> FeatList;

    // Class definitions    
    public class AClass : AuroraStruct {
        // Field definitions
        public uint structid;
        public Int16 ClassLevel;
        public Int32 Class;
    
        // List definitions
        public List<AKnown0> KnownList0;
        public List<AMemorized0> MemorizedList0;
    
        // Class definitions    
        public class AKnown0 : AuroraStruct {
            // Field definitions
            public uint structid;
            public UInt16 Spell;
            public Byte SpellMetaMagic;
            public Byte SpellFlags;
            
        }
        
        public class AMemorized0 : AuroraStruct {
            // Field definitions
            public uint structid;
            public UInt16 Spell;
            public Byte SpellMetaMagic;
            public Byte SpellFlags;
            
        }
        
    }
    
    public class ASkill : AuroraStruct {
        // Field definitions
        public uint structid;
        public Byte Rank;
        
    }
    
    public class AFeat : AuroraStruct {
        // Field definitions
        public uint structid;
        public UInt16 Feat;
        
    }
    
}
