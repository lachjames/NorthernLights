using System;
using System.Collections.Generic;
using static AuroraEngine.GFFObject;
using UnityEngine;
using AuroraEngine;

[Serializable]public class AuroraUTC : AuroraStruct {
    // Field definitions
    [GFF("structid", Compatibility.BOTH, ExistsIn.BOTH)] public uint structid;
    [GFF("TemplateResRef", Compatibility.BOTH, ExistsIn.BASE)] public String TemplateResRef;
    [GFF("Race", Compatibility.BOTH, ExistsIn.BOTH)] public Byte Race;
    [GFF("SubraceIndex", Compatibility.BOTH, ExistsIn.BOTH)] public Byte SubraceIndex;
    [GFF("FirstName", Compatibility.BOTH, ExistsIn.BOTH)] public CExoLocString FirstName;
    [GFF("LastName", Compatibility.BOTH, ExistsIn.BOTH)] public CExoLocString LastName;
    [GFF("Appearance_Type", Compatibility.BOTH, ExistsIn.BOTH)] public UInt16 Appearance_Type;
    [GFF("Gender", Compatibility.BOTH, ExistsIn.BOTH)] public Byte Gender;
    [GFF("Phenotype", Compatibility.BOTH, ExistsIn.BOTH)] public Int32 Phenotype;
    [GFF("PortraitId", Compatibility.BOTH, ExistsIn.BOTH)] public UInt16 PortraitId;
    [GFF("Description", Compatibility.BOTH, ExistsIn.BOTH)] public CExoLocString Description;
    [GFF("Tag", Compatibility.BOTH, ExistsIn.BOTH)] public CExoString Tag;
    [GFF("Conversation", Compatibility.BOTH, ExistsIn.BOTH)] public String Conversation;
    [GFF("IsPC", Compatibility.BOTH, ExistsIn.BOTH)] public Byte IsPC;
    [GFF("FactionID", Compatibility.BOTH, ExistsIn.BOTH)] public UInt16 FactionID;
    [GFF("Disarmable", Compatibility.BOTH, ExistsIn.BOTH)] public Byte Disarmable;
    [GFF("Subrace", Compatibility.BOTH, ExistsIn.BOTH)] public CExoString Subrace;
    [GFF("Deity", Compatibility.BOTH, ExistsIn.BOTH)] public CExoString Deity;
    [GFF("SoundSetFile", Compatibility.BOTH, ExistsIn.BOTH)] public UInt16 SoundSetFile;
    [GFF("Plot", Compatibility.BOTH, ExistsIn.BOTH)] public Byte Plot;
    [GFF("Interruptable", Compatibility.BOTH, ExistsIn.BOTH)] public Byte Interruptable;
    [GFF("NoPermDeath", Compatibility.BOTH, ExistsIn.BASE)] public Byte NoPermDeath;
    [GFF("BodyBag", Compatibility.BOTH, ExistsIn.BOTH)] public Byte BodyBag;
    [GFF("BodyVariation", Compatibility.BOTH, ExistsIn.BASE)] public Byte BodyVariation;
    [GFF("TextureVar", Compatibility.BOTH, ExistsIn.BASE)] public Byte TextureVar;
    [GFF("Min1HP", Compatibility.BOTH, ExistsIn.BOTH)] public Byte Min1HP;
    [GFF("PartyInteract", Compatibility.BOTH, ExistsIn.BOTH)] public Byte PartyInteract;
    [GFF("Str", Compatibility.BOTH, ExistsIn.BOTH)] public Byte Str;
    [GFF("Dex", Compatibility.BOTH, ExistsIn.BOTH)] public Byte Dex;
    [GFF("Con", Compatibility.BOTH, ExistsIn.BOTH)] public Byte Con;
    [GFF("Int", Compatibility.BOTH, ExistsIn.BOTH)] public Byte Int;
    [GFF("Wis", Compatibility.BOTH, ExistsIn.BOTH)] public Byte Wis;
    [GFF("Cha", Compatibility.BOTH, ExistsIn.BOTH)] public Byte Cha;
    [GFF("WalkRate", Compatibility.BOTH, ExistsIn.BASE)] public Int32 WalkRate;
    [GFF("NaturalAC", Compatibility.BOTH, ExistsIn.BOTH)] public Byte NaturalAC;
    [GFF("HitPoints", Compatibility.BOTH, ExistsIn.BOTH)] public Int16 HitPoints;
    [GFF("CurrentHitPoints", Compatibility.BOTH, ExistsIn.BOTH)] public Int16 CurrentHitPoints;
    [GFF("MaxHitPoints", Compatibility.BOTH, ExistsIn.BOTH)] public Int16 MaxHitPoints;
    [GFF("ForcePoints", Compatibility.BOTH, ExistsIn.BOTH)] public Int16 ForcePoints;
    [GFF("CurrentForce", Compatibility.BOTH, ExistsIn.BOTH)] public Int16 CurrentForce;
    [GFF("refbonus", Compatibility.BOTH, ExistsIn.BOTH)] public Int16 refbonus;
    [GFF("willbonus", Compatibility.BOTH, ExistsIn.BOTH)] public Int16 willbonus;
    [GFF("fortbonus", Compatibility.BOTH, ExistsIn.BOTH)] public Int16 fortbonus;
    [GFF("GoodEvil", Compatibility.BOTH, ExistsIn.BOTH)] public Byte GoodEvil;
    [GFF("LawfulChaotic", Compatibility.BOTH, ExistsIn.BASE)] public Byte LawfulChaotic;
    [GFF("ChallengeRating", Compatibility.BOTH, ExistsIn.BOTH)] public Single ChallengeRating;
    [GFF("PerceptionRange", Compatibility.BOTH, ExistsIn.BASE)] public Byte PerceptionRange;
    [GFF("ScriptHeartbeat", Compatibility.BOTH, ExistsIn.BOTH)] public String ScriptHeartbeat;
    [GFF("ScriptOnNotice", Compatibility.BOTH, ExistsIn.BOTH)] public String ScriptOnNotice;
    [GFF("ScriptSpellAt", Compatibility.BOTH, ExistsIn.BOTH)] public String ScriptSpellAt;
    [GFF("ScriptAttacked", Compatibility.BOTH, ExistsIn.BOTH)] public String ScriptAttacked;
    [GFF("ScriptDamaged", Compatibility.BOTH, ExistsIn.BOTH)] public String ScriptDamaged;
    [GFF("ScriptDisturbed", Compatibility.BOTH, ExistsIn.BOTH)] public String ScriptDisturbed;
    [GFF("ScriptEndRound", Compatibility.BOTH, ExistsIn.BOTH)] public String ScriptEndRound;
    [GFF("ScriptEndDialogu", Compatibility.BOTH, ExistsIn.BOTH)] public String ScriptEndDialogu;
    [GFF("ScriptDialogue", Compatibility.BOTH, ExistsIn.BOTH)] public String ScriptDialogue;
    [GFF("ScriptSpawn", Compatibility.BOTH, ExistsIn.BOTH)] public String ScriptSpawn;
    [GFF("ScriptRested", Compatibility.BOTH, ExistsIn.BOTH)] public String ScriptRested;
    [GFF("ScriptDeath", Compatibility.BOTH, ExistsIn.BOTH)] public String ScriptDeath;
    [GFF("ScriptUserDefine", Compatibility.BOTH, ExistsIn.BOTH)] public String ScriptUserDefine;
    [GFF("ScriptOnBlocked", Compatibility.BOTH, ExistsIn.BOTH)] public String ScriptOnBlocked;
    [GFF("PaletteID", Compatibility.BOTH, ExistsIn.BASE)] public Byte PaletteID;
    [GFF("Comment", Compatibility.BOTH, ExistsIn.BASE)] public CExoString Comment;
    [GFF("NotReorienting", Compatibility.BOTH, ExistsIn.BOTH)] public Byte NotReorienting;
    [GFF("Portrait", Compatibility.KotOR, ExistsIn.BASE)] public String Portrait;
    [GFF("SaveReflex", Compatibility.KotOR, ExistsIn.BASE)] public Byte SaveReflex;
    [GFF("Wings", Compatibility.BOTH, ExistsIn.BOTH)] public Byte Wings;
    [GFF("MoraleRecovery", Compatibility.KotOR, ExistsIn.BASE)] public Byte MoraleRecovery;
    [GFF("Morale", Compatibility.KotOR, ExistsIn.BASE)] public Byte Morale;
    [GFF("MoraleBreakpoint", Compatibility.KotOR, ExistsIn.BASE)] public Byte MoraleBreakpoint;
    [GFF("Tail", Compatibility.BOTH, ExistsIn.BOTH)] public Byte Tail;
    [GFF("SaveWill", Compatibility.KotOR, ExistsIn.BASE)] public Byte SaveWill;
    [GFF("SaveFortitude", Compatibility.KotOR, ExistsIn.BASE)] public Byte SaveFortitude;
    [GFF("SubRace", Compatibility.KotOR, ExistsIn.BASE)] public CExoString SubRace;
    [GFF("CRAdjust", Compatibility.KotOR, ExistsIn.BASE)] public Int32 CRAdjust;
    [GFF("SoundSet", Compatibility.KotOR, ExistsIn.BASE)] public UInt32 SoundSet;
    [GFF("Appearance_Head", Compatibility.BOTH, ExistsIn.BOTH)] public Byte Appearance_Head;
    [GFF("RefBonus", Compatibility.KotOR, ExistsIn.BASE)] public Int16 RefBonus;
    [GFF("WillBonus", Compatibility.KotOR, ExistsIn.BASE)] public Int16 WillBonus;
    [GFF("FortBonus", Compatibility.KotOR, ExistsIn.BASE)] public Int16 FortBonus;
    [GFF("BlindSpot", Compatibility.TSL, ExistsIn.BOTH)] public Single BlindSpot;
    [GFF("Hologram", Compatibility.TSL, ExistsIn.BOTH)] public Byte Hologram;
    [GFF("IgnoreCrePath", Compatibility.TSL, ExistsIn.BOTH)] public Byte IgnoreCrePath;
    [GFF("MultiplierSet", Compatibility.TSL, ExistsIn.BOTH)] public Byte MultiplierSet;
    [GFF("WillNotRender", Compatibility.TSL, ExistsIn.BOTH)] public Byte WillNotRender;
    [GFF("KTInfoVersion", Compatibility.TSL, ExistsIn.BASE)] public CExoString KTInfoVersion;
    [GFF("KTInfoDate", Compatibility.TSL, ExistsIn.BASE)] public CExoString KTInfoDate;
    [GFF("KTGameVerIndex", Compatibility.TSL, ExistsIn.BASE)] public Int32 KTGameVerIndex;
    [GFF("Age", Compatibility.BOTH, ExistsIn.SAVE)] public Int32 Age;
    [GFF("StartingPackage", Compatibility.BOTH, ExistsIn.SAVE)] public Byte StartingPackage;
    [GFF("MClassLevUpIn", Compatibility.BOTH, ExistsIn.SAVE)] public Byte MClassLevUpIn;
    [GFF("Gold", Compatibility.BOTH, ExistsIn.SAVE)] public UInt32 Gold;
    [GFF("RefSaveThrow", Compatibility.BOTH, ExistsIn.SAVE)] public Char RefSaveThrow;
    [GFF("WillSaveThrow", Compatibility.BOTH, ExistsIn.SAVE)] public Char WillSaveThrow;
    [GFF("FortSaveThrow", Compatibility.BOTH, ExistsIn.SAVE)] public Char FortSaveThrow;
    [GFF("ArmorClass", Compatibility.BOTH, ExistsIn.SAVE)] public Int16 ArmorClass;
    [GFF("PregameCurrent", Compatibility.BOTH, ExistsIn.SAVE)] public Int16 PregameCurrent;
    [GFF("MaxForcePoints", Compatibility.BOTH, ExistsIn.SAVE)] public Int16 MaxForcePoints;
    [GFF("Experience", Compatibility.BOTH, ExistsIn.SAVE)] public UInt32 Experience;
    [GFF("MovementRate", Compatibility.BOTH, ExistsIn.SAVE)] public Byte MovementRate;
    [GFF("Color_Skin", Compatibility.BOTH, ExistsIn.SAVE)] public Byte Color_Skin;
    [GFF("Color_Hair", Compatibility.BOTH, ExistsIn.SAVE)] public Byte Color_Hair;
    [GFF("Color_Tattoo1", Compatibility.BOTH, ExistsIn.SAVE)] public Byte Color_Tattoo1;
    [GFF("Color_Tattoo2", Compatibility.BOTH, ExistsIn.SAVE)] public Byte Color_Tattoo2;
    [GFF("DuplicatingHead", Compatibility.BOTH, ExistsIn.SAVE)] public Byte DuplicatingHead;
    [GFF("UseBackupHead", Compatibility.BOTH, ExistsIn.SAVE)] public Byte UseBackupHead;
    [GFF("AIState", Compatibility.BOTH, ExistsIn.SAVE)] public Int32 AIState;
    [GFF("SkillPoints", Compatibility.BOTH, ExistsIn.SAVE)] public UInt16 SkillPoints;
    [GFF("DetectMode", Compatibility.BOTH, ExistsIn.SAVE)] public Byte DetectMode;
    [GFF("StealthMode", Compatibility.BOTH, ExistsIn.SAVE)] public Byte StealthMode;
    [GFF("CreatureSize", Compatibility.BOTH, ExistsIn.SAVE)] public Int32 CreatureSize;
    [GFF("IsDestroyable", Compatibility.BOTH, ExistsIn.SAVE)] public Byte IsDestroyable;
    [GFF("IsRaiseable", Compatibility.BOTH, ExistsIn.SAVE)] public Byte IsRaiseable;
    [GFF("DeadSelectable", Compatibility.BOTH, ExistsIn.SAVE)] public Byte DeadSelectable;
    [GFF("AreaId", Compatibility.BOTH, ExistsIn.SAVE)] public UInt32 AreaId;
    [GFF("AmbientAnimState", Compatibility.BOTH, ExistsIn.SAVE)] public Byte AmbientAnimState;
    [GFF("Animation", Compatibility.BOTH, ExistsIn.SAVE)] public Int32 Animation;
    [GFF("CreatnScrptFird", Compatibility.BOTH, ExistsIn.SAVE)] public Byte CreatnScrptFird;
    [GFF("PM_IsDisguised", Compatibility.BOTH, ExistsIn.SAVE)] public Byte PM_IsDisguised;
    [GFF("Listening", Compatibility.BOTH, ExistsIn.SAVE)] public Byte Listening;
    [GFF("XPosition", Compatibility.BOTH, ExistsIn.SAVE)] public Single XPosition;
    [GFF("YPosition", Compatibility.BOTH, ExistsIn.SAVE)] public Single YPosition;
    [GFF("ZPosition", Compatibility.BOTH, ExistsIn.SAVE)] public Single ZPosition;
    [GFF("XOrientation", Compatibility.BOTH, ExistsIn.SAVE)] public Single XOrientation;
    [GFF("YOrientation", Compatibility.BOTH, ExistsIn.SAVE)] public Single YOrientation;
    [GFF("ZOrientation", Compatibility.BOTH, ExistsIn.SAVE)] public Single ZOrientation;
    [GFF("JoiningXP", Compatibility.BOTH, ExistsIn.SAVE)] public Int32 JoiningXP;
    [GFF("Commandable", Compatibility.BOTH, ExistsIn.SAVE)] public Byte Commandable;
    [GFF("PM_Appearance", Compatibility.KotOR, ExistsIn.SAVE)] public UInt16 PM_Appearance;
    [GFF("ItemComponent", Compatibility.TSL, ExistsIn.SAVE)] public UInt32 ItemComponent;
    [GFF("Chemicals", Compatibility.TSL, ExistsIn.SAVE)] public UInt32 Chemicals;
    [GFF("PCLevelAtSpawn", Compatibility.TSL, ExistsIn.SAVE)] public Byte PCLevelAtSpawn;
    [GFF("Confused", Compatibility.TSL, ExistsIn.SAVE)] public Byte Confused;
    [GFF("BonusForcePoints", Compatibility.TSL, ExistsIn.SAVE)] public Int32 BonusForcePoints;
    [GFF("AssignedPup", Compatibility.TSL, ExistsIn.SAVE)] public Int32 AssignedPup;
    [GFF("PlayerCreated", Compatibility.TSL, ExistsIn.SAVE)] public Int32 PlayerCreated;
    [GFF("BaseCNPCAlignmen", Compatibility.TSL, ExistsIn.SAVE)] public Char BaseCNPCAlignmen;
    [GFF("FuryDamageBonus", Compatibility.TSL, ExistsIn.SAVE)] public Char FuryDamageBonus;
    [GFF("CurrentForm", Compatibility.TSL, ExistsIn.SAVE)] public UInt32 CurrentForm;
    [GFF("ForceAlwaysUpdat", Compatibility.TSL, ExistsIn.SAVE)] public Byte ForceAlwaysUpdat;

    // Struct definitions
    [GFF("CombatInfo", Compatibility.BOTH, ExistsIn.SAVE)] public ACombatInfo CombatInfo = new ACombatInfo();
    [GFF("CombatRoundData", Compatibility.BOTH, ExistsIn.SAVE)] public ACombatRoundData CombatRoundData = new ACombatRoundData();
    [GFF("FollowInfo", Compatibility.BOTH, ExistsIn.SAVE)] public AFollowInfo FollowInfo = new AFollowInfo();
    [GFF("SWVarTable", Compatibility.BOTH, ExistsIn.SAVE)] public ASWVarTable SWVarTable = new ASWVarTable();

    // List definitions
    [GFF("SkillList", Compatibility.BOTH, ExistsIn.BOTH)] public List<ASkill> SkillList = new List<ASkill>();
    [GFF("ClassList", Compatibility.BOTH, ExistsIn.BOTH)] public List<AClass> ClassList = new List<AClass>();
    [GFF("Equip_ItemList", Compatibility.BOTH, ExistsIn.BOTH)] public List<AEquip_Item> Equip_ItemList = new List<AEquip_Item>();
    [GFF("FeatList", Compatibility.BOTH, ExistsIn.BOTH)] public List<AFeat> FeatList = new List<AFeat>();
    [GFF("ItemList", Compatibility.BOTH, ExistsIn.BOTH)] public List<AItem> ItemList = new List<AItem>();
    [GFF("SpecAbilityList", Compatibility.BOTH, ExistsIn.BOTH)] public List<ASpecAbility> SpecAbilityList = new List<ASpecAbility>();
    [GFF("PerceptionList", Compatibility.BOTH, ExistsIn.SAVE)] public List<APerception> PerceptionList = new List<APerception>();
    [GFF("ExpressionList", Compatibility.BOTH, ExistsIn.SAVE)] public List<AExpression> ExpressionList = new List<AExpression>();
    [GFF("EffectList", Compatibility.BOTH, ExistsIn.SAVE)] public List<AEffect> EffectList = new List<AEffect>();
    [GFF("ActionList", Compatibility.BOTH, ExistsIn.SAVE)] public List<AAction> ActionList = new List<AAction>();
    [GFF("LvlStatList", Compatibility.BOTH, ExistsIn.SAVE)] public List<ALvlStat> LvlStatList = new List<ALvlStat>();

    // Class definitions    
    [Serializable]public class ACombatInfo : AuroraStruct {
        // Field definitions
        [GFF("structid", Compatibility.BOTH, ExistsIn.SAVE)] public uint structid;
        [GFF("NumAttacks", Compatibility.BOTH, ExistsIn.SAVE)] public Byte NumAttacks;
        [GFF("OnHandAttackMod", Compatibility.BOTH, ExistsIn.SAVE)] public Char OnHandAttackMod;
        [GFF("OnHandDamageMod", Compatibility.BOTH, ExistsIn.SAVE)] public Char OnHandDamageMod;
        [GFF("OffHandAttackMod", Compatibility.BOTH, ExistsIn.SAVE)] public Char OffHandAttackMod;
        [GFF("OffHandDamageMod", Compatibility.BOTH, ExistsIn.SAVE)] public Char OffHandDamageMod;
        [GFF("ForceResistance", Compatibility.BOTH, ExistsIn.SAVE)] public Byte ForceResistance;
        [GFF("ArcaneSpellFail", Compatibility.BOTH, ExistsIn.SAVE)] public Byte ArcaneSpellFail;
        [GFF("ArmorCheckPen", Compatibility.BOTH, ExistsIn.SAVE)] public Byte ArmorCheckPen;
        [GFF("UnarmedDamDice", Compatibility.BOTH, ExistsIn.SAVE)] public Byte UnarmedDamDice;
        [GFF("UnarmedDamDie", Compatibility.BOTH, ExistsIn.SAVE)] public Byte UnarmedDamDie;
        [GFF("OnHandCritRng", Compatibility.BOTH, ExistsIn.SAVE)] public Byte OnHandCritRng;
        [GFF("OnHandCritMult", Compatibility.BOTH, ExistsIn.SAVE)] public Byte OnHandCritMult;
        [GFF("OffHandWeaponEq", Compatibility.BOTH, ExistsIn.SAVE)] public Byte OffHandWeaponEq;
        [GFF("OffHandCritRng", Compatibility.BOTH, ExistsIn.SAVE)] public Byte OffHandCritRng;
        [GFF("OffHandCritMult", Compatibility.BOTH, ExistsIn.SAVE)] public Byte OffHandCritMult;
        [GFF("LeftEquip", Compatibility.BOTH, ExistsIn.SAVE)] public UInt32 LeftEquip;
        [GFF("RightEquip", Compatibility.BOTH, ExistsIn.SAVE)] public UInt32 RightEquip;
        [GFF("LeftString", Compatibility.BOTH, ExistsIn.SAVE)] public CExoString LeftString;
        [GFF("RightString", Compatibility.BOTH, ExistsIn.SAVE)] public CExoString RightString;
        [GFF("DamageDice", Compatibility.BOTH, ExistsIn.SAVE)] public Byte DamageDice;
        [GFF("DamageDie", Compatibility.BOTH, ExistsIn.SAVE)] public Byte DamageDie;
    
        // List definitions
        [GFF("AttackList", Compatibility.TSL, ExistsIn.SAVE)] public List<AAttack> AttackList = new List<AAttack>();
        [GFF("DamageList", Compatibility.TSL, ExistsIn.SAVE)] public List<ADamage> DamageList = new List<ADamage>();
    
        // Class definitions    
        [Serializable]public class AAttack : AuroraStruct {
            // Field definitions
            [GFF("structid", Compatibility.TSL, ExistsIn.SAVE)] public uint structid;
            [GFF("Modifier", Compatibility.TSL, ExistsIn.SAVE)] public Char Modifier;
            [GFF("WeaponWield", Compatibility.TSL, ExistsIn.SAVE)] public Byte WeaponWield;
            [GFF("VersusGoodEvil", Compatibility.TSL, ExistsIn.SAVE)] public Byte VersusGoodEvil;
            [GFF("VersusRace", Compatibility.TSL, ExistsIn.SAVE)] public Byte VersusRace;
            
        }
        
        [Serializable]public class ADamage : AuroraStruct {
            // Field definitions
            [GFF("structid", Compatibility.TSL, ExistsIn.SAVE)] public uint structid;
            [GFF("Modifier", Compatibility.TSL, ExistsIn.SAVE)] public Char Modifier;
            [GFF("ModifierType", Compatibility.TSL, ExistsIn.SAVE)] public Byte ModifierType;
            [GFF("WeaponWield", Compatibility.TSL, ExistsIn.SAVE)] public Byte WeaponWield;
            [GFF("VersusGoodEvil", Compatibility.TSL, ExistsIn.SAVE)] public Byte VersusGoodEvil;
            [GFF("VersusRace", Compatibility.TSL, ExistsIn.SAVE)] public Byte VersusRace;
            
        }
        
    }
    
    [Serializable]public class ACombatRoundData : AuroraStruct {
        // Field definitions
        [GFF("structid", Compatibility.BOTH, ExistsIn.SAVE)] public uint structid;
        
    }
    
    [Serializable]public class AFollowInfo : AuroraStruct {
        // Field definitions
        [GFF("structid", Compatibility.BOTH, ExistsIn.SAVE)] public uint structid;
        [GFF("FollowObject", Compatibility.BOTH, ExistsIn.SAVE)] public UInt32 FollowObject;
        [GFF("FollowLocation", Compatibility.BOTH, ExistsIn.SAVE)] public Vector3 FollowLocation;
        [GFF("LastLeaderPos", Compatibility.BOTH, ExistsIn.SAVE)] public Vector3 LastLeaderPos;
        [GFF("LastFollowerPos", Compatibility.BOTH, ExistsIn.SAVE)] public Vector3 LastFollowerPos;
        [GFF("MaxSpeed", Compatibility.BOTH, ExistsIn.SAVE)] public Single MaxSpeed;
        [GFF("StickToPos", Compatibility.BOTH, ExistsIn.SAVE)] public Byte StickToPos;
        [GFF("Result", Compatibility.BOTH, ExistsIn.SAVE)] public UInt32 Result;
        [GFF("TimeElapsed", Compatibility.BOTH, ExistsIn.SAVE)] public UInt32 TimeElapsed;
        [GFF("InSafetyRange", Compatibility.BOTH, ExistsIn.SAVE)] public Byte InSafetyRange;
        
    }
    
    [Serializable]public class ASWVarTable : AuroraStruct {
        // Field definitions
        [GFF("structid", Compatibility.BOTH, ExistsIn.SAVE)] public uint structid;
    
        // List definitions
        [GFF("BitArray", Compatibility.BOTH, ExistsIn.SAVE)] public List<ABitArray> BitArray = new List<ABitArray>();
        [GFF("ByteArray", Compatibility.BOTH, ExistsIn.SAVE)] public List<AByteArray> ByteArray = new List<AByteArray>();
    
        // Class definitions    
        [Serializable]public class ABitArray : AuroraStruct {
            // Field definitions
            [GFF("structid", Compatibility.BOTH, ExistsIn.SAVE)] public uint structid;
            [GFF("Variable", Compatibility.BOTH, ExistsIn.SAVE)] public UInt32 Variable;
            
        }
        
        [Serializable]public class AByteArray : AuroraStruct {
            // Field definitions
            [GFF("structid", Compatibility.BOTH, ExistsIn.SAVE)] public uint structid;
            [GFF("Variable", Compatibility.BOTH, ExistsIn.SAVE)] public Byte Variable;
            
        }
        
    }
    
    [Serializable]public class ASkill : AuroraStruct {
        // Field definitions
        [GFF("structid", Compatibility.BOTH, ExistsIn.BOTH)] public uint structid;
        [GFF("Rank", Compatibility.BOTH, ExistsIn.BOTH)] public Byte Rank;
        
    }
    
    [Serializable]public class AClass : AuroraStruct {
        // Field definitions
        [GFF("structid", Compatibility.BOTH, ExistsIn.BOTH)] public uint structid;
        [GFF("Class", Compatibility.BOTH, ExistsIn.BOTH)] public Int32 Class;
        [GFF("ClassLevel", Compatibility.BOTH, ExistsIn.BOTH)] public Int16 ClassLevel;
    
        // List definitions
        [GFF("KnownList0", Compatibility.BOTH, ExistsIn.BOTH)] public List<AKnown0> KnownList0 = new List<AKnown0>();
        [GFF("SpellsPerDayList", Compatibility.BOTH, ExistsIn.SAVE)] public List<ASpellsPerDay> SpellsPerDayList = new List<ASpellsPerDay>();
    
        // Class definitions    
        [Serializable]public class AKnown0 : AuroraStruct {
            // Field definitions
            [GFF("structid", Compatibility.BOTH, ExistsIn.BOTH)] public uint structid;
            [GFF("Spell", Compatibility.BOTH, ExistsIn.BOTH)] public UInt16 Spell;
            [GFF("SpellMetaMagic", Compatibility.BOTH, ExistsIn.BASE)] public Byte SpellMetaMagic;
            [GFF("SpellFlags", Compatibility.BOTH, ExistsIn.BASE)] public Byte SpellFlags;
            
        }
        
        [Serializable]public class ASpellsPerDay : AuroraStruct {
            // Field definitions
            [GFF("structid", Compatibility.BOTH, ExistsIn.SAVE)] public uint structid;
            [GFF("NumSpellsLeft", Compatibility.BOTH, ExistsIn.SAVE)] public Byte NumSpellsLeft;
            
        }
        
    }
    
    [Serializable]public class AEquip_Item : AuroraStruct {
        // Field definitions
        [GFF("structid", Compatibility.BOTH, ExistsIn.BOTH)] public uint structid;
        [GFF("EquippedRes", Compatibility.BOTH, ExistsIn.BASE)] public String EquippedRes;
        [GFF("Dropable", Compatibility.BOTH, ExistsIn.BOTH)] public Byte Dropable;
        [GFF("ObjectId", Compatibility.BOTH, ExistsIn.SAVE)] public UInt32 ObjectId;
        [GFF("BaseItem", Compatibility.BOTH, ExistsIn.SAVE)] public Int32 BaseItem;
        [GFF("Tag", Compatibility.BOTH, ExistsIn.SAVE)] public CExoString Tag;
        [GFF("Identified", Compatibility.BOTH, ExistsIn.SAVE)] public Byte Identified;
        [GFF("Description", Compatibility.BOTH, ExistsIn.SAVE)] public CExoLocString Description;
        [GFF("DescIdentified", Compatibility.BOTH, ExistsIn.SAVE)] public CExoLocString DescIdentified;
        [GFF("LocalizedName", Compatibility.BOTH, ExistsIn.SAVE)] public CExoLocString LocalizedName;
        [GFF("StackSize", Compatibility.BOTH, ExistsIn.SAVE)] public UInt16 StackSize;
        [GFF("Stolen", Compatibility.BOTH, ExistsIn.SAVE)] public Byte Stolen;
        [GFF("Upgrades", Compatibility.BOTH, ExistsIn.SAVE)] public UInt32 Upgrades;
        [GFF("Pickpocketable", Compatibility.BOTH, ExistsIn.SAVE)] public Byte Pickpocketable;
        [GFF("ModelVariation", Compatibility.BOTH, ExistsIn.SAVE)] public Byte ModelVariation;
        [GFF("BodyVariation", Compatibility.BOTH, ExistsIn.SAVE)] public Byte BodyVariation;
        [GFF("TextureVar", Compatibility.BOTH, ExistsIn.SAVE)] public Byte TextureVar;
        [GFF("Charges", Compatibility.BOTH, ExistsIn.SAVE)] public Byte Charges;
        [GFF("MaxCharges", Compatibility.BOTH, ExistsIn.SAVE)] public Byte MaxCharges;
        [GFF("Cost", Compatibility.BOTH, ExistsIn.SAVE)] public UInt32 Cost;
        [GFF("AddCost", Compatibility.BOTH, ExistsIn.SAVE)] public UInt32 AddCost;
        [GFF("Plot", Compatibility.BOTH, ExistsIn.SAVE)] public Byte Plot;
        [GFF("XPosition", Compatibility.BOTH, ExistsIn.SAVE)] public Single XPosition;
        [GFF("YPosition", Compatibility.BOTH, ExistsIn.SAVE)] public Single YPosition;
        [GFF("ZPosition", Compatibility.BOTH, ExistsIn.SAVE)] public Single ZPosition;
        [GFF("XOrientation", Compatibility.BOTH, ExistsIn.SAVE)] public Single XOrientation;
        [GFF("YOrientation", Compatibility.BOTH, ExistsIn.SAVE)] public Single YOrientation;
        [GFF("ZOrientation", Compatibility.BOTH, ExistsIn.SAVE)] public Single ZOrientation;
        [GFF("NonEquippable", Compatibility.BOTH, ExistsIn.SAVE)] public Byte NonEquippable;
        [GFF("NewItem", Compatibility.BOTH, ExistsIn.SAVE)] public Byte NewItem;
        [GFF("DELETING", Compatibility.BOTH, ExistsIn.SAVE)] public Byte DELETING;
        [GFF("UpgradeLevel", Compatibility.TSL, ExistsIn.SAVE)] public Byte UpgradeLevel;
        [GFF("UpgradeSlot0", Compatibility.TSL, ExistsIn.SAVE)] public Int32 UpgradeSlot0;
        [GFF("UpgradeSlot1", Compatibility.TSL, ExistsIn.SAVE)] public Int32 UpgradeSlot1;
        [GFF("UpgradeSlot2", Compatibility.TSL, ExistsIn.SAVE)] public Int32 UpgradeSlot2;
        [GFF("UpgradeSlot3", Compatibility.TSL, ExistsIn.SAVE)] public Int32 UpgradeSlot3;
        [GFF("UpgradeSlot4", Compatibility.TSL, ExistsIn.SAVE)] public Int32 UpgradeSlot4;
        [GFF("UpgradeSlot5", Compatibility.TSL, ExistsIn.SAVE)] public Int32 UpgradeSlot5;
    
        // List definitions
        [GFF("PropertiesList", Compatibility.BOTH, ExistsIn.SAVE)] public List<AProperties> PropertiesList = new List<AProperties>();
    
        // Class definitions    
        [Serializable]public class AProperties : AuroraStruct {
            // Field definitions
            [GFF("structid", Compatibility.BOTH, ExistsIn.SAVE)] public uint structid;
            [GFF("PropertyName", Compatibility.BOTH, ExistsIn.SAVE)] public UInt16 PropertyName;
            [GFF("Subtype", Compatibility.BOTH, ExistsIn.SAVE)] public UInt16 Subtype;
            [GFF("CostTable", Compatibility.BOTH, ExistsIn.SAVE)] public Byte CostTable;
            [GFF("CostValue", Compatibility.BOTH, ExistsIn.SAVE)] public UInt16 CostValue;
            [GFF("Param1", Compatibility.BOTH, ExistsIn.SAVE)] public Byte Param1;
            [GFF("Param1Value", Compatibility.BOTH, ExistsIn.SAVE)] public Byte Param1Value;
            [GFF("ChanceAppear", Compatibility.BOTH, ExistsIn.SAVE)] public Byte ChanceAppear;
            [GFF("UsesPerDay", Compatibility.BOTH, ExistsIn.SAVE)] public Byte UsesPerDay;
            [GFF("Useable", Compatibility.BOTH, ExistsIn.SAVE)] public Byte Useable;
            [GFF("UpgradeType", Compatibility.BOTH, ExistsIn.SAVE)] public Byte UpgradeType;
            [GFF("PropUpgrade", Compatibility.TSL, ExistsIn.SAVE)] public UInt16 PropUpgrade;
            
        }
        
    }
    
    [Serializable]public class AFeat : AuroraStruct {
        // Field definitions
        [GFF("structid", Compatibility.BOTH, ExistsIn.BOTH)] public uint structid;
        [GFF("Feat", Compatibility.BOTH, ExistsIn.BOTH)] public UInt16 Feat;
        
    }
    
    [Serializable]public class AItem : AuroraStruct {
        // Field definitions
        [GFF("structid", Compatibility.BOTH, ExistsIn.BOTH)] public uint structid;
        [GFF("InventoryRes", Compatibility.BOTH, ExistsIn.BASE)] public String InventoryRes;
        [GFF("Repos_PosX", Compatibility.BOTH, ExistsIn.BASE)] public UInt16 Repos_PosX;
        [GFF("Repos_Posy", Compatibility.BOTH, ExistsIn.BASE)] public UInt16 Repos_Posy;
        [GFF("Dropable", Compatibility.BOTH, ExistsIn.BOTH)] public Byte Dropable;
        [GFF("Repos_PosY", Compatibility.TSL, ExistsIn.BASE)] public UInt16 Repos_PosY;
        [GFF("ObjectId", Compatibility.BOTH, ExistsIn.SAVE)] public UInt32 ObjectId;
        [GFF("BaseItem", Compatibility.BOTH, ExistsIn.SAVE)] public Int32 BaseItem;
        [GFF("Tag", Compatibility.BOTH, ExistsIn.SAVE)] public CExoString Tag;
        [GFF("Identified", Compatibility.BOTH, ExistsIn.SAVE)] public Byte Identified;
        [GFF("Description", Compatibility.BOTH, ExistsIn.SAVE)] public CExoLocString Description;
        [GFF("DescIdentified", Compatibility.BOTH, ExistsIn.SAVE)] public CExoLocString DescIdentified;
        [GFF("LocalizedName", Compatibility.BOTH, ExistsIn.SAVE)] public CExoLocString LocalizedName;
        [GFF("StackSize", Compatibility.BOTH, ExistsIn.SAVE)] public UInt16 StackSize;
        [GFF("Stolen", Compatibility.BOTH, ExistsIn.SAVE)] public Byte Stolen;
        [GFF("Upgrades", Compatibility.BOTH, ExistsIn.SAVE)] public UInt32 Upgrades;
        [GFF("Pickpocketable", Compatibility.BOTH, ExistsIn.SAVE)] public Byte Pickpocketable;
        [GFF("ModelVariation", Compatibility.BOTH, ExistsIn.SAVE)] public Byte ModelVariation;
        [GFF("Charges", Compatibility.BOTH, ExistsIn.SAVE)] public Byte Charges;
        [GFF("MaxCharges", Compatibility.BOTH, ExistsIn.SAVE)] public Byte MaxCharges;
        [GFF("Cost", Compatibility.BOTH, ExistsIn.SAVE)] public UInt32 Cost;
        [GFF("AddCost", Compatibility.BOTH, ExistsIn.SAVE)] public UInt32 AddCost;
        [GFF("Plot", Compatibility.BOTH, ExistsIn.SAVE)] public Byte Plot;
        [GFF("XPosition", Compatibility.BOTH, ExistsIn.SAVE)] public Single XPosition;
        [GFF("YPosition", Compatibility.BOTH, ExistsIn.SAVE)] public Single YPosition;
        [GFF("ZPosition", Compatibility.BOTH, ExistsIn.SAVE)] public Single ZPosition;
        [GFF("XOrientation", Compatibility.BOTH, ExistsIn.SAVE)] public Single XOrientation;
        [GFF("YOrientation", Compatibility.BOTH, ExistsIn.SAVE)] public Single YOrientation;
        [GFF("ZOrientation", Compatibility.BOTH, ExistsIn.SAVE)] public Single ZOrientation;
        [GFF("NonEquippable", Compatibility.BOTH, ExistsIn.SAVE)] public Byte NonEquippable;
        [GFF("NewItem", Compatibility.BOTH, ExistsIn.SAVE)] public Byte NewItem;
        [GFF("DELETING", Compatibility.BOTH, ExistsIn.SAVE)] public Byte DELETING;
        [GFF("UpgradeLevel", Compatibility.TSL, ExistsIn.SAVE)] public Byte UpgradeLevel;
        [GFF("UpgradeSlot0", Compatibility.TSL, ExistsIn.SAVE)] public Int32 UpgradeSlot0;
        [GFF("UpgradeSlot1", Compatibility.TSL, ExistsIn.SAVE)] public Int32 UpgradeSlot1;
        [GFF("UpgradeSlot2", Compatibility.TSL, ExistsIn.SAVE)] public Int32 UpgradeSlot2;
        [GFF("UpgradeSlot3", Compatibility.TSL, ExistsIn.SAVE)] public Int32 UpgradeSlot3;
        [GFF("UpgradeSlot4", Compatibility.TSL, ExistsIn.SAVE)] public Int32 UpgradeSlot4;
        [GFF("UpgradeSlot5", Compatibility.TSL, ExistsIn.SAVE)] public Int32 UpgradeSlot5;
    
        // List definitions
        [GFF("PropertiesList", Compatibility.BOTH, ExistsIn.SAVE)] public List<AProperties> PropertiesList = new List<AProperties>();
    
        // Class definitions    
        [Serializable]public class AProperties : AuroraStruct {
            // Field definitions
            [GFF("structid", Compatibility.BOTH, ExistsIn.SAVE)] public uint structid;
            [GFF("PropertyName", Compatibility.BOTH, ExistsIn.SAVE)] public UInt16 PropertyName;
            [GFF("Subtype", Compatibility.BOTH, ExistsIn.SAVE)] public UInt16 Subtype;
            [GFF("CostTable", Compatibility.BOTH, ExistsIn.SAVE)] public Byte CostTable;
            [GFF("CostValue", Compatibility.BOTH, ExistsIn.SAVE)] public UInt16 CostValue;
            [GFF("Param1", Compatibility.BOTH, ExistsIn.SAVE)] public Byte Param1;
            [GFF("Param1Value", Compatibility.BOTH, ExistsIn.SAVE)] public Byte Param1Value;
            [GFF("ChanceAppear", Compatibility.BOTH, ExistsIn.SAVE)] public Byte ChanceAppear;
            [GFF("UsesPerDay", Compatibility.BOTH, ExistsIn.SAVE)] public Byte UsesPerDay;
            [GFF("Useable", Compatibility.BOTH, ExistsIn.SAVE)] public Byte Useable;
            [GFF("UpgradeType", Compatibility.BOTH, ExistsIn.SAVE)] public Byte UpgradeType;
            [GFF("PropUpgrade", Compatibility.TSL, ExistsIn.SAVE)] public UInt16 PropUpgrade;
            
        }
        
    }
    
    [Serializable]public class ASpecAbility : AuroraStruct {
        // Field definitions
        [GFF("structid", Compatibility.BOTH, ExistsIn.BOTH)] public uint structid;
        [GFF("Spell", Compatibility.BOTH, ExistsIn.BOTH)] public UInt16 Spell;
        [GFF("SpellFlags", Compatibility.BOTH, ExistsIn.BOTH)] public Byte SpellFlags;
        [GFF("SpellCasterLevel", Compatibility.BOTH, ExistsIn.BOTH)] public Byte SpellCasterLevel;
        
    }
    
    [Serializable]public class APerception : AuroraStruct {
        // Field definitions
        [GFF("structid", Compatibility.BOTH, ExistsIn.SAVE)] public uint structid;
        [GFF("ObjectId", Compatibility.BOTH, ExistsIn.SAVE)] public UInt32 ObjectId;
        [GFF("PerceptionData", Compatibility.BOTH, ExistsIn.SAVE)] public Byte PerceptionData;
        
    }
    
    [Serializable]public class AExpression : AuroraStruct {
        // Field definitions
        [GFF("structid", Compatibility.BOTH, ExistsIn.SAVE)] public uint structid;
        [GFF("ExpressionId", Compatibility.BOTH, ExistsIn.SAVE)] public Int32 ExpressionId;
        [GFF("ExpressionString", Compatibility.BOTH, ExistsIn.SAVE)] public CExoString ExpressionString;
        
    }
    
    [Serializable]public class AEffect : AuroraStruct {
        // Field definitions
        [GFF("structid", Compatibility.BOTH, ExistsIn.SAVE)] public uint structid;
        [GFF("Id", Compatibility.BOTH, ExistsIn.SAVE)] public UInt64 Id;
        [GFF("Type", Compatibility.BOTH, ExistsIn.SAVE)] public UInt16 Type;
        [GFF("SubType", Compatibility.BOTH, ExistsIn.SAVE)] public UInt16 SubType;
        [GFF("Duration", Compatibility.BOTH, ExistsIn.SAVE)] public Single Duration;
        [GFF("SkipOnLoad", Compatibility.BOTH, ExistsIn.SAVE)] public Byte SkipOnLoad;
        [GFF("ExpireDay", Compatibility.BOTH, ExistsIn.SAVE)] public UInt32 ExpireDay;
        [GFF("ExpireTime", Compatibility.BOTH, ExistsIn.SAVE)] public UInt32 ExpireTime;
        [GFF("CreatorId", Compatibility.BOTH, ExistsIn.SAVE)] public UInt32 CreatorId;
        [GFF("SpellId", Compatibility.BOTH, ExistsIn.SAVE)] public UInt32 SpellId;
        [GFF("IsExposed", Compatibility.BOTH, ExistsIn.SAVE)] public Int32 IsExposed;
        [GFF("NumIntegers", Compatibility.BOTH, ExistsIn.SAVE)] public Int32 NumIntegers;
    
        // List definitions
        [GFF("IntList", Compatibility.BOTH, ExistsIn.SAVE)] public List<AInt> IntList = new List<AInt>();
        [GFF("FloatList", Compatibility.BOTH, ExistsIn.SAVE)] public List<AFloat> FloatList = new List<AFloat>();
        [GFF("StringList", Compatibility.BOTH, ExistsIn.SAVE)] public List<AString> StringList = new List<AString>();
        [GFF("ObjectList", Compatibility.BOTH, ExistsIn.SAVE)] public List<AObject> ObjectList = new List<AObject>();
    
        // Class definitions    
        [Serializable]public class AInt : AuroraStruct {
            // Field definitions
            [GFF("structid", Compatibility.BOTH, ExistsIn.SAVE)] public uint structid;
            [GFF("Value", Compatibility.BOTH, ExistsIn.SAVE)] public Int32 Value;
            
        }
        
        [Serializable]public class AFloat : AuroraStruct {
            // Field definitions
            [GFF("structid", Compatibility.BOTH, ExistsIn.SAVE)] public uint structid;
            [GFF("Value", Compatibility.BOTH, ExistsIn.SAVE)] public Single Value;
            
        }
        
        [Serializable]public class AString : AuroraStruct {
            // Field definitions
            [GFF("structid", Compatibility.BOTH, ExistsIn.SAVE)] public uint structid;
            [GFF("Value", Compatibility.BOTH, ExistsIn.SAVE)] public CExoString Value;
            
        }
        
        [Serializable]public class AObject : AuroraStruct {
            // Field definitions
            [GFF("structid", Compatibility.BOTH, ExistsIn.SAVE)] public uint structid;
            [GFF("Value", Compatibility.BOTH, ExistsIn.SAVE)] public UInt32 Value;
            
        }
        
    }
    
    [Serializable]public class AAction : AuroraStruct {
        // Field definitions
        [GFF("structid", Compatibility.BOTH, ExistsIn.SAVE)] public uint structid;
        [GFF("ActionId", Compatibility.BOTH, ExistsIn.SAVE)] public UInt32 ActionId;
        [GFF("GroupActionId", Compatibility.BOTH, ExistsIn.SAVE)] public UInt16 GroupActionId;
        [GFF("NumParams", Compatibility.BOTH, ExistsIn.SAVE)] public UInt16 NumParams;
    
        // List definitions
        [GFF("Paramaters", Compatibility.BOTH, ExistsIn.SAVE)] public List<AParamaters> Paramaters = new List<AParamaters>();
    
        // Class definitions    
        [Serializable]public class AParamaters : AuroraStruct {
            // Field definitions
            [GFF("structid", Compatibility.BOTH, ExistsIn.SAVE)] public uint structid;
            [GFF("Type", Compatibility.BOTH, ExistsIn.SAVE)] public UInt32 Type;
            [GFF("Value", Compatibility.BOTH, ExistsIn.SAVE)] public Single Value;
        
            // Struct definitions
            [GFF("Value", Compatibility.BOTH, ExistsIn.SAVE)] public AValue Value2 = new AValue();
        
            // Class definitions    
            [Serializable]public class AValue : AuroraStruct {
                // Field definitions
                [GFF("structid", Compatibility.BOTH, ExistsIn.SAVE)] public uint structid;
                [GFF("CodeSize", Compatibility.BOTH, ExistsIn.SAVE)] public Int32 CodeSize;
                [GFF("Code", Compatibility.BOTH, ExistsIn.SAVE)] public Byte[] Code;
                [GFF("CRC", Compatibility.BOTH, ExistsIn.SAVE)] public UInt32 CRC;
                [GFF("InstructionPtr", Compatibility.BOTH, ExistsIn.SAVE)] public Int32 InstructionPtr;
                [GFF("SecondaryPtr", Compatibility.BOTH, ExistsIn.SAVE)] public Int32 SecondaryPtr;
                [GFF("Name", Compatibility.BOTH, ExistsIn.SAVE)] public CExoString Name;
                [GFF("StackSize", Compatibility.BOTH, ExistsIn.SAVE)] public Int32 StackSize;
            
                // Struct definitions
                [GFF("Stack", Compatibility.BOTH, ExistsIn.SAVE)] public AStack Stack = new AStack();
            
                // Class definitions    
                [Serializable]public class AStack : AuroraStruct {
                    // Field definitions
                    [GFF("structid", Compatibility.BOTH, ExistsIn.SAVE)] public uint structid;
                    [GFF("BasePointer", Compatibility.BOTH, ExistsIn.SAVE)] public Int32 BasePointer;
                    [GFF("StackPointer", Compatibility.BOTH, ExistsIn.SAVE)] public Int32 StackPointer;
                    [GFF("TotalSize", Compatibility.BOTH, ExistsIn.SAVE)] public Int32 TotalSize;
                
                    // List definitions
                    [GFF("Stack", Compatibility.BOTH, ExistsIn.SAVE)] public List<AStack2> Stack = new List<AStack2>();
                
                    // Class definitions    
                    [Serializable]public class AStack2 : AuroraStruct {
                        // Field definitions
                        [GFF("structid", Compatibility.BOTH, ExistsIn.SAVE)] public uint structid;
                        [GFF("Type", Compatibility.BOTH, ExistsIn.SAVE)] public Char Type;
                        [GFF("Value", Compatibility.BOTH, ExistsIn.SAVE)] public Int32 Value;
                    }
                }
            }
        }
    }
    
    [Serializable]public class ALvlStat : AuroraStruct {
        // Field definitions
        [GFF("structid", Compatibility.BOTH, ExistsIn.SAVE)] public uint structid;
        [GFF("LvlStatHitDie", Compatibility.BOTH, ExistsIn.SAVE)] public Byte LvlStatHitDie;
        [GFF("LvlStatForce", Compatibility.BOTH, ExistsIn.SAVE)] public Byte LvlStatForce;
        [GFF("LvlStatClass", Compatibility.BOTH, ExistsIn.SAVE)] public Byte LvlStatClass;
        [GFF("SkillPoints", Compatibility.BOTH, ExistsIn.SAVE)] public UInt16 SkillPoints;
        [GFF("LvlStatAbility", Compatibility.BOTH, ExistsIn.SAVE)] public Byte LvlStatAbility;
    
        // List definitions
        [GFF("SkillList", Compatibility.BOTH, ExistsIn.SAVE)] public List<ASkill> SkillList = new List<ASkill>();
        [GFF("FeatList", Compatibility.BOTH, ExistsIn.SAVE)] public List<AFeat> FeatList = new List<AFeat>();
        [GFF("KnownList0", Compatibility.BOTH, ExistsIn.SAVE)] public List<AKnown0> KnownList0 = new List<AKnown0>();
    
        // Class definitions    
        [Serializable]public class ASkill : AuroraStruct {
            // Field definitions
            [GFF("structid", Compatibility.BOTH, ExistsIn.SAVE)] public uint structid;
            [GFF("Rank", Compatibility.BOTH, ExistsIn.SAVE)] public Byte Rank;
            
        }
        
        [Serializable]public class AFeat : AuroraStruct {
            // Field definitions
            [GFF("structid", Compatibility.BOTH, ExistsIn.SAVE)] public uint structid;
            [GFF("Feat", Compatibility.BOTH, ExistsIn.SAVE)] public UInt16 Feat;
            
        }
        
        [Serializable]public class AKnown0 : AuroraStruct {
            // Field definitions
            [GFF("structid", Compatibility.BOTH, ExistsIn.SAVE)] public uint structid;
            [GFF("Spell", Compatibility.BOTH, ExistsIn.SAVE)] public UInt16 Spell;
            
        }
        
    }
    
}
