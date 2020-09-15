using System;
using System.Collections.Generic;
using static AuroraEngine.GFFObject;
using UnityEngine;
using AuroraEngine;

[Serializable]public class AuroraUTC : AuroraStruct {
    // Field definitions
    [GFF("structid")] public uint structid;
    [GFF("TemplateResRef")] public String TemplateResRef;
    [GFF("Race")] public Byte Race;
    [GFF("SubraceIndex")] public Byte SubraceIndex;
    [GFF("FirstName")] public CExoLocString FirstName;
    [GFF("LastName")] public CExoLocString LastName;
    [GFF("Appearance_Type")] public UInt16 Appearance_Type;
    [GFF("Gender")] public Byte Gender;
    [GFF("Phenotype")] public Int32 Phenotype;
    [GFF("PortraitId")] public UInt16 PortraitId;
    [GFF("Description")] public CExoLocString Description;
    [GFF("Tag")] public CExoString Tag;
    [GFF("Conversation")] public String Conversation;
    [GFF("IsPC")] public Byte IsPC;
    [GFF("FactionID")] public UInt16 FactionID;
    [GFF("Disarmable")] public Byte Disarmable;
    [GFF("Subrace")] public CExoString Subrace;
    [GFF("Deity")] public CExoString Deity;
    [GFF("SoundSetFile")] public UInt16 SoundSetFile;
    [GFF("Plot")] public Byte Plot;
    [GFF("Interruptable")] public Byte Interruptable;
    [GFF("NoPermDeath")] public Byte NoPermDeath;
    [GFF("BodyBag")] public Byte BodyBag;
    [GFF("BodyVariation")] public Byte BodyVariation;
    [GFF("TextureVar")] public Byte TextureVar;
    [GFF("Min1HP")] public Byte Min1HP;
    [GFF("PartyInteract")] public Byte PartyInteract;
    [GFF("Str")] public Byte Str;
    [GFF("Dex")] public Byte Dex;
    [GFF("Con")] public Byte Con;
    [GFF("Int")] public Byte Int;
    [GFF("Wis")] public Byte Wis;
    [GFF("Cha")] public Byte Cha;
    [GFF("WalkRate")] public Int32 WalkRate;
    [GFF("NaturalAC")] public Byte NaturalAC;
    [GFF("HitPoints")] public Int16 HitPoints;
    [GFF("CurrentHitPoints")] public Int16 CurrentHitPoints;
    [GFF("MaxHitPoints")] public Int16 MaxHitPoints;
    [GFF("ForcePoints")] public Int16 ForcePoints;
    [GFF("CurrentForce")] public Int16 CurrentForce;
    [GFF("refbonus")] public Int16 refbonus;
    [GFF("willbonus")] public Int16 willbonus;
    [GFF("fortbonus")] public Int16 fortbonus;
    [GFF("GoodEvil")] public Byte GoodEvil;
    [GFF("LawfulChaotic")] public Byte LawfulChaotic;
    [GFF("ChallengeRating")] public Single ChallengeRating;
    [GFF("PerceptionRange")] public Byte PerceptionRange;
    [GFF("ScriptHeartbeat")] public String ScriptHeartbeat;
    [GFF("ScriptOnNotice")] public String ScriptOnNotice;
    [GFF("ScriptSpellAt")] public String ScriptSpellAt;
    [GFF("ScriptAttacked")] public String ScriptAttacked;
    [GFF("ScriptDamaged")] public String ScriptDamaged;
    [GFF("ScriptDisturbed")] public String ScriptDisturbed;
    [GFF("ScriptEndRound")] public String ScriptEndRound;
    [GFF("ScriptEndDialogu")] public String ScriptEndDialogu;
    [GFF("ScriptDialogue")] public String ScriptDialogue;
    [GFF("ScriptSpawn")] public String ScriptSpawn;
    [GFF("ScriptRested")] public String ScriptRested;
    [GFF("ScriptDeath")] public String ScriptDeath;
    [GFF("ScriptUserDefine")] public String ScriptUserDefine;
    [GFF("ScriptOnBlocked")] public String ScriptOnBlocked;
    [GFF("PaletteID")] public Byte PaletteID;
    [GFF("Comment")] public CExoString Comment;
    [GFF("NotReorienting")] public Byte NotReorienting;
    [GFF("Portrait")] public String Portrait;
    [GFF("SaveReflex")] public Byte SaveReflex;
    [GFF("Wings")] public Byte Wings;
    [GFF("MoraleRecovery")] public Byte MoraleRecovery;
    [GFF("Morale")] public Byte Morale;
    [GFF("MoraleBreakpoint")] public Byte MoraleBreakpoint;
    [GFF("Tail")] public Byte Tail;
    [GFF("SaveWill")] public Byte SaveWill;
    [GFF("SaveFortitude")] public Byte SaveFortitude;
    [GFF("SubRace")] public CExoString SubRace;
    [GFF("CRAdjust")] public Int32 CRAdjust;
    [GFF("SoundSet")] public UInt32 SoundSet;
    [GFF("Appearance_Head")] public Byte Appearance_Head;
    [GFF("RefBonus")] public Int16 RefBonus;
    [GFF("WillBonus")] public Int16 WillBonus;
    [GFF("FortBonus")] public Int16 FortBonus;
    [GFF("Age")] public Int32 Age;
    [GFF("StartingPackage")] public Byte StartingPackage;
    [GFF("MClassLevUpIn")] public Byte MClassLevUpIn;
    [GFF("Gold")] public UInt32 Gold;
    [GFF("RefSaveThrow")] public Char RefSaveThrow;
    [GFF("WillSaveThrow")] public Char WillSaveThrow;
    [GFF("FortSaveThrow")] public Char FortSaveThrow;
    [GFF("ArmorClass")] public Int16 ArmorClass;
    [GFF("PregameCurrent")] public Int16 PregameCurrent;
    [GFF("MaxForcePoints")] public Int16 MaxForcePoints;
    [GFF("Experience")] public UInt32 Experience;
    [GFF("MovementRate")] public Byte MovementRate;
    [GFF("Color_Skin")] public Byte Color_Skin;
    [GFF("Color_Hair")] public Byte Color_Hair;
    [GFF("Color_Tattoo1")] public Byte Color_Tattoo1;
    [GFF("Color_Tattoo2")] public Byte Color_Tattoo2;
    [GFF("DuplicatingHead")] public Byte DuplicatingHead;
    [GFF("UseBackupHead")] public Byte UseBackupHead;
    [GFF("AIState")] public Int32 AIState;
    [GFF("SkillPoints")] public UInt16 SkillPoints;
    [GFF("DetectMode")] public Byte DetectMode;
    [GFF("StealthMode")] public Byte StealthMode;
    [GFF("CreatureSize")] public Int32 CreatureSize;
    [GFF("IsDestroyable")] public Byte IsDestroyable;
    [GFF("IsRaiseable")] public Byte IsRaiseable;
    [GFF("DeadSelectable")] public Byte DeadSelectable;
    [GFF("AreaId")] public UInt32 AreaId;
    [GFF("AmbientAnimState")] public Byte AmbientAnimState;
    [GFF("Animation")] public Int32 Animation;
    [GFF("CreatnScrptFird")] public Byte CreatnScrptFird;
    [GFF("PM_IsDisguised")] public Byte PM_IsDisguised;
    [GFF("Listening")] public Byte Listening;
    [GFF("XPosition")] public Single XPosition;
    [GFF("YPosition")] public Single YPosition;
    [GFF("ZPosition")] public Single ZPosition;
    [GFF("XOrientation")] public Single XOrientation;
    [GFF("YOrientation")] public Single YOrientation;
    [GFF("ZOrientation")] public Single ZOrientation;
    [GFF("JoiningXP")] public Int32 JoiningXP;
    [GFF("Commandable")] public Byte Commandable;
    [GFF("PM_Appearance")] public UInt16 PM_Appearance;

    // Struct definitions
    [GFF("CombatInfo")] public ACombatInfo CombatInfo = new ACombatInfo();
    [GFF("CombatRoundData")] public ACombatRoundData CombatRoundData = new ACombatRoundData();
    [GFF("FollowInfo")] public AFollowInfo FollowInfo = new AFollowInfo();
    [GFF("SWVarTable")] public ASWVarTable SWVarTable = new ASWVarTable();

    // List definitions
    [GFF("SkillList")] public List<ASkill> SkillList = new List<ASkill>();
    [GFF("ClassList")] public List<AClass> ClassList = new List<AClass>();
    [GFF("Equip_ItemList")] public List<AEquip_Item> Equip_ItemList = new List<AEquip_Item>();
    [GFF("FeatList")] public List<AFeat> FeatList = new List<AFeat>();
    [GFF("ItemList")] public List<AItem> ItemList = new List<AItem>();
    [GFF("SpecAbilityList")] public List<ASpecAbility> SpecAbilityList = new List<ASpecAbility>();
    [GFF("PerceptionList")] public List<APerception> PerceptionList = new List<APerception>();
    [GFF("ExpressionList")] public List<AExpression> ExpressionList = new List<AExpression>();
    [GFF("EffectList")] public List<AEffect> EffectList = new List<AEffect>();
    [GFF("ActionList")] public List<AAction> ActionList = new List<AAction>();
    [GFF("LvlStatList")] public List<ALvlStat> LvlStatList = new List<ALvlStat>();

    // Class definitions    
    [Serializable]public class ACombatInfo : AuroraStruct {
        // Field definitions
        [GFF("structid")] public uint structid;
        [GFF("NumAttacks")] public Byte NumAttacks;
        [GFF("OnHandAttackMod")] public Char OnHandAttackMod;
        [GFF("OnHandDamageMod")] public Char OnHandDamageMod;
        [GFF("OffHandAttackMod")] public Char OffHandAttackMod;
        [GFF("OffHandDamageMod")] public Char OffHandDamageMod;
        [GFF("ForceResistance")] public Byte ForceResistance;
        [GFF("ArcaneSpellFail")] public Byte ArcaneSpellFail;
        [GFF("ArmorCheckPen")] public Byte ArmorCheckPen;
        [GFF("UnarmedDamDice")] public Byte UnarmedDamDice;
        [GFF("UnarmedDamDie")] public Byte UnarmedDamDie;
        [GFF("OnHandCritRng")] public Byte OnHandCritRng;
        [GFF("OnHandCritMult")] public Byte OnHandCritMult;
        [GFF("OffHandWeaponEq")] public Byte OffHandWeaponEq;
        [GFF("OffHandCritRng")] public Byte OffHandCritRng;
        [GFF("OffHandCritMult")] public Byte OffHandCritMult;
        [GFF("LeftEquip")] public UInt32 LeftEquip;
        [GFF("RightEquip")] public UInt32 RightEquip;
        [GFF("LeftString")] public CExoString LeftString;
        [GFF("RightString")] public CExoString RightString;
        [GFF("DamageDice")] public Byte DamageDice;
        [GFF("DamageDie")] public Byte DamageDie;
    
        // List definitions
        [GFF("DamageList")] public List<ADamage> DamageList = new List<ADamage>();
        [GFF("AttackList")] public List<AAttack> AttackList = new List<AAttack>();
    
        // Class definitions    
        [Serializable]public class ADamage : AuroraStruct {
            // Field definitions
            [GFF("structid")] public uint structid;
            [GFF("Modifier")] public Char Modifier;
            [GFF("ModifierType")] public Byte ModifierType;
            [GFF("WeaponWield")] public Byte WeaponWield;
            [GFF("VersusGoodEvil")] public Byte VersusGoodEvil;
            [GFF("VersusRace")] public Byte VersusRace;
            
        }
        
        [Serializable]public class AAttack : AuroraStruct {
            // Field definitions
            [GFF("structid")] public uint structid;
            [GFF("Modifier")] public Char Modifier;
            [GFF("WeaponWield")] public Byte WeaponWield;
            [GFF("VersusGoodEvil")] public Byte VersusGoodEvil;
            [GFF("VersusRace")] public Byte VersusRace;
            
        }
        
    }
    
    [Serializable]public class ACombatRoundData : AuroraStruct {
        // Field definitions
        [GFF("structid")] public uint structid;
        [GFF("RoundStarted")] public Byte RoundStarted;
        [GFF("SpellCastRound")] public Byte SpellCastRound;
        [GFF("DeflectArrow")] public Byte DeflectArrow;
        [GFF("WeaponSucks")] public Byte WeaponSucks;
        [GFF("DodgeTarget")] public UInt32 DodgeTarget;
        [GFF("NewAttackTarget")] public UInt32 NewAttackTarget;
        [GFF("Engaged")] public Int32 Engaged;
        [GFF("Master")] public Int32 Master;
        [GFF("MasterID")] public UInt32 MasterID;
        [GFF("RoundPaused")] public Byte RoundPaused;
        [GFF("RoundPausedBy")] public UInt32 RoundPausedBy;
        [GFF("InfinitePause")] public Byte InfinitePause;
        [GFF("PauseTimer")] public Int32 PauseTimer;
        [GFF("Timer")] public Int32 Timer;
        [GFF("RoundLength")] public Int32 RoundLength;
        [GFF("OverlapAmount")] public Int32 OverlapAmount;
        [GFF("BleedTimer")] public Int32 BleedTimer;
        [GFF("CurrentAttack")] public Byte CurrentAttack;
        [GFF("AttackID")] public UInt16 AttackID;
        [GFF("AttackGroup")] public Byte AttackGroup;
        [GFF("ParryIndex")] public Int32 ParryIndex;
        [GFF("NumAOOs")] public Int32 NumAOOs;
        [GFF("NumCleaves")] public Int32 NumCleaves;
        [GFF("OnHandAttacks")] public Int32 OnHandAttacks;
        [GFF("OffHandAttacks")] public Int32 OffHandAttacks;
        [GFF("AdditAttacks")] public Int32 AdditAttacks;
        [GFF("EffectAttacks")] public Int32 EffectAttacks;
        [GFF("ParryActions")] public Byte ParryActions;
        [GFF("OffHandTaken")] public Int32 OffHandTaken;
        [GFF("ExtraTaken")] public Int32 ExtraTaken;
    
        // List definitions
        [GFF("AttackList")] public List<AAttack> AttackList = new List<AAttack>();
    
        // Class definitions    
        [Serializable]public class AAttack : AuroraStruct {
            // Field definitions
            [GFF("structid")] public uint structid;
            [GFF("AttackGroup")] public Byte AttackGroup;
            [GFF("AnimationLength")] public UInt16 AnimationLength;
            [GFF("MissedBy")] public UInt32 MissedBy;
            [GFF("AttackResult")] public Byte AttackResult;
            [GFF("ReactObject")] public UInt32 ReactObject;
            [GFF("ReaxnDelay")] public UInt16 ReaxnDelay;
            [GFF("ReaxnAnimation")] public UInt16 ReaxnAnimation;
            [GFF("ReaxnAnimLength")] public UInt16 ReaxnAnimLength;
            [GFF("Concealment")] public Byte Concealment;
            [GFF("AttackType")] public UInt16 AttackType;
            [GFF("AttackMode")] public Byte AttackMode;
            [GFF("RangedAttack")] public Int32 RangedAttack;
            [GFF("SneakAttack")] public Int32 SneakAttack;
            [GFF("WeaponAttackType")] public Byte WeaponAttackType;
            [GFF("RangedTargetX")] public Single RangedTargetX;
            [GFF("RangedTargetY")] public Single RangedTargetY;
            [GFF("RangedTargetZ")] public Single RangedTargetZ;
            [GFF("KillingBlow")] public Byte KillingBlow;
            [GFF("CoupDeGrace")] public Byte CoupDeGrace;
            [GFF("CriticalThreat")] public Byte CriticalThreat;
            [GFF("AttackDeflected")] public Byte AttackDeflected;
            [GFF("AmmoItem")] public UInt32 AmmoItem;
            [GFF("AttackDebugText")] public CExoString AttackDebugText;
            [GFF("DamageDebugText")] public CExoString DamageDebugText;
        
            // List definitions
            [GFF("DamageList")] public List<ADamage> DamageList = new List<ADamage>();
        
            // Class definitions    
            [Serializable]public class ADamage : AuroraStruct {
                // Field definitions
                [GFF("structid")] public uint structid;
                [GFF("DamageValue")] public Int16 DamageValue;
                
            }
            
        }
        
    }
    
    [Serializable]public class AFollowInfo : AuroraStruct {
        // Field definitions
        [GFF("structid")] public uint structid;
        [GFF("FollowObject")] public UInt32 FollowObject;
        [GFF("FollowLocation")] public Vector3 FollowLocation;
        [GFF("LastLeaderPos")] public Vector3 LastLeaderPos;
        [GFF("LastFollowerPos")] public Vector3 LastFollowerPos;
        [GFF("MaxSpeed")] public Single MaxSpeed;
        [GFF("StickToPos")] public Byte StickToPos;
        [GFF("Result")] public UInt32 Result;
        [GFF("TimeElapsed")] public UInt32 TimeElapsed;
        [GFF("InSafetyRange")] public Byte InSafetyRange;
        
    }
    
    [Serializable]public class ASWVarTable : AuroraStruct {
        // Field definitions
        [GFF("structid")] public uint structid;
    
        // List definitions
        [GFF("BitArray")] public List<ABitArray> BitArray = new List<ABitArray>();
        [GFF("ByteArray")] public List<AByteArray> ByteArray = new List<AByteArray>();
    
        // Class definitions    
        [Serializable]public class ABitArray : AuroraStruct {
            // Field definitions
            [GFF("structid")] public uint structid;
            [GFF("Variable")] public UInt32 Variable;
            
        }
        
        [Serializable]public class AByteArray : AuroraStruct {
            // Field definitions
            [GFF("structid")] public uint structid;
            [GFF("Variable")] public Byte Variable;
            
        }
        
    }
    
    [Serializable]public class ASkill : AuroraStruct {
        // Field definitions
        [GFF("structid")] public uint structid;
        [GFF("Rank")] public Byte Rank;
        
    }
    
    [Serializable]public class AClass : AuroraStruct {
        // Field definitions
        [GFF("structid")] public uint structid;
        [GFF("Class")] public Int32 Class;
        [GFF("ClassLevel")] public Int16 ClassLevel;
    
        // List definitions
        [GFF("KnownList0")] public List<AKnown0> KnownList0 = new List<AKnown0>();
        [GFF("SpellsPerDayList")] public List<ASpellsPerDay> SpellsPerDayList = new List<ASpellsPerDay>();
    
        // Class definitions    
        [Serializable]public class AKnown0 : AuroraStruct {
            // Field definitions
            [GFF("structid")] public uint structid;
            [GFF("Spell")] public UInt16 Spell;
            [GFF("SpellMetaMagic")] public Byte SpellMetaMagic;
            [GFF("SpellFlags")] public Byte SpellFlags;
            
        }
        
        [Serializable]public class ASpellsPerDay : AuroraStruct {
            // Field definitions
            [GFF("structid")] public uint structid;
            [GFF("NumSpellsLeft")] public Byte NumSpellsLeft;
            
        }
        
    }
    
    [Serializable]public class AEquip_Item : AuroraStruct {
        // Field definitions
        [GFF("structid")] public uint structid;
        [GFF("EquippedRes")] public String EquippedRes;
        [GFF("Dropable")] public Byte Dropable;
        [GFF("ObjectId")] public UInt32 ObjectId;
        [GFF("BaseItem")] public Int32 BaseItem;
        [GFF("Tag")] public CExoString Tag;
        [GFF("Identified")] public Byte Identified;
        [GFF("Description")] public CExoLocString Description;
        [GFF("DescIdentified")] public CExoLocString DescIdentified;
        [GFF("LocalizedName")] public CExoLocString LocalizedName;
        [GFF("StackSize")] public UInt16 StackSize;
        [GFF("Stolen")] public Byte Stolen;
        [GFF("Upgrades")] public UInt32 Upgrades;
        [GFF("Pickpocketable")] public Byte Pickpocketable;
        [GFF("ModelVariation")] public Byte ModelVariation;
        [GFF("BodyVariation")] public Byte BodyVariation;
        [GFF("TextureVar")] public Byte TextureVar;
        [GFF("Charges")] public Byte Charges;
        [GFF("MaxCharges")] public Byte MaxCharges;
        [GFF("Cost")] public UInt32 Cost;
        [GFF("AddCost")] public UInt32 AddCost;
        [GFF("Plot")] public Byte Plot;
        [GFF("XPosition")] public Single XPosition;
        [GFF("YPosition")] public Single YPosition;
        [GFF("ZPosition")] public Single ZPosition;
        [GFF("XOrientation")] public Single XOrientation;
        [GFF("YOrientation")] public Single YOrientation;
        [GFF("ZOrientation")] public Single ZOrientation;
        [GFF("NonEquippable")] public Byte NonEquippable;
        [GFF("NewItem")] public Byte NewItem;
        [GFF("DELETING")] public Byte DELETING;
    
        // List definitions
        [GFF("PropertiesList")] public List<AProperties> PropertiesList = new List<AProperties>();
    
        // Class definitions    
        [Serializable]public class AProperties : AuroraStruct {
            // Field definitions
            [GFF("structid")] public uint structid;
            [GFF("PropertyName")] public UInt16 PropertyName;
            [GFF("Subtype")] public UInt16 Subtype;
            [GFF("CostTable")] public Byte CostTable;
            [GFF("CostValue")] public UInt16 CostValue;
            [GFF("Param1")] public Byte Param1;
            [GFF("Param1Value")] public Byte Param1Value;
            [GFF("ChanceAppear")] public Byte ChanceAppear;
            [GFF("UsesPerDay")] public Byte UsesPerDay;
            [GFF("Useable")] public Byte Useable;
            [GFF("UpgradeType")] public Byte UpgradeType;
            
        }
        
    }
    
    [Serializable]public class AFeat : AuroraStruct {
        // Field definitions
        [GFF("structid")] public uint structid;
        [GFF("Feat")] public UInt16 Feat;
        
    }
    
    [Serializable]public class AItem : AuroraStruct {
        // Field definitions
        [GFF("structid")] public uint structid;
        [GFF("InventoryRes")] public String InventoryRes;
        [GFF("Repos_PosX")] public UInt16 Repos_PosX;
        [GFF("Repos_Posy")] public UInt16 Repos_Posy;
        [GFF("Dropable")] public Byte Dropable;
        [GFF("ObjectId")] public UInt32 ObjectId;
        [GFF("BaseItem")] public Int32 BaseItem;
        [GFF("Tag")] public CExoString Tag;
        [GFF("Identified")] public Byte Identified;
        [GFF("Description")] public CExoLocString Description;
        [GFF("DescIdentified")] public CExoLocString DescIdentified;
        [GFF("LocalizedName")] public CExoLocString LocalizedName;
        [GFF("StackSize")] public UInt16 StackSize;
        [GFF("Stolen")] public Byte Stolen;
        [GFF("Upgrades")] public UInt32 Upgrades;
        [GFF("Pickpocketable")] public Byte Pickpocketable;
        [GFF("ModelVariation")] public Byte ModelVariation;
        [GFF("Charges")] public Byte Charges;
        [GFF("MaxCharges")] public Byte MaxCharges;
        [GFF("Cost")] public UInt32 Cost;
        [GFF("AddCost")] public UInt32 AddCost;
        [GFF("Plot")] public Byte Plot;
        [GFF("XPosition")] public Single XPosition;
        [GFF("YPosition")] public Single YPosition;
        [GFF("ZPosition")] public Single ZPosition;
        [GFF("XOrientation")] public Single XOrientation;
        [GFF("YOrientation")] public Single YOrientation;
        [GFF("ZOrientation")] public Single ZOrientation;
        [GFF("NonEquippable")] public Byte NonEquippable;
        [GFF("NewItem")] public Byte NewItem;
        [GFF("DELETING")] public Byte DELETING;
    
        // List definitions
        [GFF("PropertiesList")] public List<AProperties> PropertiesList = new List<AProperties>();
    
        // Class definitions    
        [Serializable]public class AProperties : AuroraStruct {
            // Field definitions
            [GFF("structid")] public uint structid;
            [GFF("PropertyName")] public UInt16 PropertyName;
            [GFF("Subtype")] public UInt16 Subtype;
            [GFF("CostTable")] public Byte CostTable;
            [GFF("CostValue")] public UInt16 CostValue;
            [GFF("Param1")] public Byte Param1;
            [GFF("Param1Value")] public Byte Param1Value;
            [GFF("ChanceAppear")] public Byte ChanceAppear;
            [GFF("UsesPerDay")] public Byte UsesPerDay;
            [GFF("Useable")] public Byte Useable;
            [GFF("UpgradeType")] public Byte UpgradeType;
            
        }
        
    }
    
    [Serializable]public class ASpecAbility : AuroraStruct {
        // Field definitions
        [GFF("structid")] public uint structid;
        [GFF("Spell")] public UInt16 Spell;
        [GFF("SpellFlags")] public Byte SpellFlags;
        [GFF("SpellCasterLevel")] public Byte SpellCasterLevel;
        
    }
    
    [Serializable]public class APerception : AuroraStruct {
        // Field definitions
        [GFF("structid")] public uint structid;
        [GFF("ObjectId")] public UInt32 ObjectId;
        [GFF("PerceptionData")] public Byte PerceptionData;
        
    }
    
    [Serializable]public class AExpression : AuroraStruct {
        // Field definitions
        [GFF("structid")] public uint structid;
        [GFF("ExpressionId")] public Int32 ExpressionId;
        [GFF("ExpressionString")] public CExoString ExpressionString;
        
    }
    
    [Serializable]public class AEffect : AuroraStruct {
        // Field definitions
        [GFF("structid")] public uint structid;
        [GFF("Id")] public UInt64 Id;
        [GFF("Type")] public UInt16 Type;
        [GFF("SubType")] public UInt16 SubType;
        [GFF("Duration")] public Single Duration;
        [GFF("SkipOnLoad")] public Byte SkipOnLoad;
        [GFF("ExpireDay")] public UInt32 ExpireDay;
        [GFF("ExpireTime")] public UInt32 ExpireTime;
        [GFF("CreatorId")] public UInt32 CreatorId;
        [GFF("SpellId")] public UInt32 SpellId;
        [GFF("IsExposed")] public Int32 IsExposed;
        [GFF("NumIntegers")] public Int32 NumIntegers;
    
        // List definitions
        [GFF("IntList")] public List<AInt> IntList = new List<AInt>();
        [GFF("FloatList")] public List<AFloat> FloatList = new List<AFloat>();
        [GFF("StringList")] public List<AString> StringList = new List<AString>();
        [GFF("ObjectList")] public List<AObject> ObjectList = new List<AObject>();
    
        // Class definitions    
        [Serializable]public class AInt : AuroraStruct {
            // Field definitions
            [GFF("structid")] public uint structid;
            [GFF("Value")] public Int32 Value;
            
        }
        
        [Serializable]public class AFloat : AuroraStruct {
            // Field definitions
            [GFF("structid")] public uint structid;
            [GFF("Value")] public Single Value;
            
        }
        
        [Serializable]public class AString : AuroraStruct {
            // Field definitions
            [GFF("structid")] public uint structid;
            [GFF("Value")] public CExoString Value;
            
        }
        
        [Serializable]public class AObject : AuroraStruct {
            // Field definitions
            [GFF("structid")] public uint structid;
            [GFF("Value")] public UInt32 Value;
            
        }
        
    }
    
    [Serializable]public class AAction : AuroraStruct {
        // Field definitions
        [GFF("structid")] public uint structid;
        [GFF("ActionId")] public UInt32 ActionId;
        [GFF("GroupActionId")] public UInt16 GroupActionId;
        [GFF("NumParams")] public UInt16 NumParams;
    
        // List definitions
        [GFF("Paramaters")] public List<AParamaters> Paramaters = new List<AParamaters>();
    
        // Class definitions    
        [Serializable]public class AParamaters : AuroraStruct {
            // Field definitions
            [GFF("structid")] public uint structid;
            [GFF("Type")] public UInt32 Type;
            [GFF("Value")] public Int32 Value;
        
            // Struct definitions
            [GFF("Value")] public AValue Value = new AValue();
        
            // Class definitions    
            [Serializable]public class AValue : AuroraStruct {
                // Field definitions
                [GFF("structid")] public uint structid;
                [GFF("CodeSize")] public Int32 CodeSize;
                [GFF("Code")] public Byte[] Code;
                [GFF("CRC")] public UInt32 CRC;
                [GFF("InstructionPtr")] public Int32 InstructionPtr;
                [GFF("SecondaryPtr")] public Int32 SecondaryPtr;
                [GFF("Name")] public CExoString Name;
                [GFF("StackSize")] public Int32 StackSize;
            
                // Struct definitions
                [GFF("Stack")] public AStack Stack = new AStack();
            
                // Class definitions    
                [Serializable]public class AStack : AuroraStruct {
                    // Field definitions
                    [GFF("structid")] public uint structid;
                    [GFF("BasePointer")] public Int32 BasePointer;
                    [GFF("StackPointer")] public Int32 StackPointer;
                    [GFF("TotalSize")] public Int32 TotalSize;
                
                    // List definitions
                    [GFF("Stack")] public List<AStack> Stack = new List<AStack>();
                
                    // Class definitions    
                    [Serializable]public class AStack : AuroraStruct {
                        // Field definitions
                        [GFF("structid")] public uint structid;
                        [GFF("Type")] public Char Type;
                        [GFF("Value")] public Int32 Value;
                        
                    }
                    
                }
                
            }
            
        }
        
    }
    
    [Serializable]public class ALvlStat : AuroraStruct {
        // Field definitions
        [GFF("structid")] public uint structid;
        [GFF("LvlStatHitDie")] public Byte LvlStatHitDie;
        [GFF("LvlStatForce")] public Byte LvlStatForce;
        [GFF("LvlStatClass")] public Byte LvlStatClass;
        [GFF("SkillPoints")] public UInt16 SkillPoints;
        [GFF("LvlStatAbility")] public Byte LvlStatAbility;
    
        // List definitions
        [GFF("SkillList")] public List<ASkill> SkillList = new List<ASkill>();
        [GFF("FeatList")] public List<AFeat> FeatList = new List<AFeat>();
        [GFF("KnownList0")] public List<AKnown0> KnownList0 = new List<AKnown0>();
    
        // Class definitions    
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
        
        [Serializable]public class AKnown0 : AuroraStruct {
            // Field definitions
            [GFF("structid")] public uint structid;
            [GFF("Spell")] public UInt16 Spell;
            
        }
        
    }
    
}
