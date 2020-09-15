using System;
using System.Collections.Generic;
using static AuroraEngine.GFFObject;
using UnityEngine;

public class AuroraUTC : AuroraStruct {
    // Field definitions
    public uint structid;
    public String TemplateResRef;
    public Byte Race;
    public Byte SubraceIndex;
    public CExoLocString FirstName;
    public CExoLocString LastName;
    public UInt16 Appearance_Type;
    public Byte Gender;
    public Int32 Phenotype;
    public UInt16 PortraitId;
    public CExoLocString Description;
    public String Tag;
    public String Conversation;
    public Byte IsPC;
    public UInt16 FactionID;
    public Byte Disarmable;
    public String Subrace;
    public String Deity;
    public UInt16 SoundSetFile;
    public Byte Plot;
    public Byte Interruptable;
    public Byte NoPermDeath;
    public Byte BodyBag;
    public Byte BodyVariation;
    public Byte TextureVar;
    public Byte Min1HP;
    public Byte PartyInteract;
    public Byte Str;
    public Byte Dex;
    public Byte Con;
    public Byte Int;
    public Byte Wis;
    public Byte Cha;
    public Int32 WalkRate;
    public Byte NaturalAC;
    public Int16 HitPoints;
    public Int16 CurrentHitPoints;
    public Int16 MaxHitPoints;
    public Int16 ForcePoints;
    public Int16 CurrentForce;
    public Int16 refbonus;
    public Int16 willbonus;
    public Int16 fortbonus;
    public Byte GoodEvil;
    public Byte LawfulChaotic;
    public Single ChallengeRating;
    public Byte PerceptionRange;
    public String ScriptHeartbeat;
    public String ScriptOnNotice;
    public String ScriptSpellAt;
    public String ScriptAttacked;
    public String ScriptDamaged;
    public String ScriptDisturbed;
    public String ScriptEndRound;
    public String ScriptEndDialogu;
    public String ScriptDialogue;
    public String ScriptSpawn;
    public String ScriptRested;
    public String ScriptDeath;
    public String ScriptUserDefine;
    public String ScriptOnBlocked;
    public Byte PaletteID;
    public String Comment;
    public Byte NotReorienting;
    public String Portrait;
    public Byte SaveReflex;
    public Byte Wings;
    public Byte MoraleRecovery;
    public Byte Morale;
    public Byte MoraleBreakpoint;
    public Byte Tail;
    public Byte SaveWill;
    public Byte SaveFortitude;
    public String SubRace;
    public Int32 CRAdjust;
    public UInt32 SoundSet;
    public Byte Appearance_Head;
    public Int16 RefBonus;
    public Int16 WillBonus;
    public Int16 FortBonus;
    public Int32 Age;
    public Byte StartingPackage;
    public Byte MClassLevUpIn;
    public UInt32 Gold;
    public Char RefSaveThrow;
    public Char WillSaveThrow;
    public Char FortSaveThrow;
    public Int16 ArmorClass;
    public Int16 PregameCurrent;
    public Int16 MaxForcePoints;
    public UInt32 Experience;
    public Byte MovementRate;
    public Byte Color_Skin;
    public Byte Color_Hair;
    public Byte Color_Tattoo1;
    public Byte Color_Tattoo2;
    public Byte DuplicatingHead;
    public Byte UseBackupHead;
    public Int32 AIState;
    public UInt16 SkillPoints;
    public Byte DetectMode;
    public Byte StealthMode;
    public Int32 CreatureSize;
    public Byte IsDestroyable;
    public Byte IsRaiseable;
    public Byte DeadSelectable;
    public UInt32 AreaId;
    public Byte AmbientAnimState;
    public Int32 Animation;
    public Byte CreatnScrptFird;
    public Byte PM_IsDisguised;
    public Byte Listening;
    public Single XPosition;
    public Single YPosition;
    public Single ZPosition;
    public Single XOrientation;
    public Single YOrientation;
    public Single ZOrientation;
    public Int32 JoiningXP;
    public Byte Commandable;
    public UInt16 PM_Appearance;

    // Struct definitions
    public ACombatInfo CombatInfo;
    public ACombatRoundData CombatRoundData;
    public AFollowInfo FollowInfo;
    public ASWVarTable SWVarTable;

    // List definitions
    public List<ASkill> SkillList;
    public List<AClass> ClassList;
    public List<AEquip_Item> Equip_ItemList;
    public List<AFeat> FeatList;
    public List<AItem> ItemList;
    public List<ASpecAbility> SpecAbilityList;
    public List<APerception> PerceptionList;
    public List<AExpression> ExpressionList;
    public List<AEffect> EffectList;
    public List<AAction> ActionList;
    public List<ALvlStat> LvlStatList;

    // Class definitions    
    public class ACombatInfo : AuroraStruct {
        // Field definitions
        public uint structid;
        public Byte NumAttacks;
        public Char OnHandAttackMod;
        public Char OnHandDamageMod;
        public Char OffHandAttackMod;
        public Char OffHandDamageMod;
        public Byte ForceResistance;
        public Byte ArcaneSpellFail;
        public Byte ArmorCheckPen;
        public Byte UnarmedDamDice;
        public Byte UnarmedDamDie;
        public Byte OnHandCritRng;
        public Byte OnHandCritMult;
        public Byte OffHandWeaponEq;
        public Byte OffHandCritRng;
        public Byte OffHandCritMult;
        public UInt32 LeftEquip;
        public UInt32 RightEquip;
        public String LeftString;
        public String RightString;
        public Byte DamageDice;
        public Byte DamageDie;
    
        // List definitions
        public List<ADamage> DamageList;
        public List<AAttack> AttackList;
    
        // Class definitions    
        public class ADamage : AuroraStruct {
            // Field definitions
            public uint structid;
            public Char Modifier;
            public Byte ModifierType;
            public Byte WeaponWield;
            public Byte VersusGoodEvil;
            public Byte VersusRace;
            
        }
        
        public class AAttack : AuroraStruct {
            // Field definitions
            public uint structid;
            public Char Modifier;
            public Byte WeaponWield;
            public Byte VersusGoodEvil;
            public Byte VersusRace;
            
        }
        
    }
    
    public class ACombatRoundData : AuroraStruct {
        // Field definitions
        public uint structid;
        public Byte RoundStarted;
        public Byte SpellCastRound;
        public Byte DeflectArrow;
        public Byte WeaponSucks;
        public UInt32 DodgeTarget;
        public UInt32 NewAttackTarget;
        public Int32 Engaged;
        public Int32 Master;
        public UInt32 MasterID;
        public Byte RoundPaused;
        public UInt32 RoundPausedBy;
        public Byte InfinitePause;
        public Int32 PauseTimer;
        public Int32 Timer;
        public Int32 RoundLength;
        public Int32 OverlapAmount;
        public Int32 BleedTimer;
        public Byte CurrentAttack;
        public UInt16 AttackID;
        public Byte AttackGroup;
        public Int32 ParryIndex;
        public Int32 NumAOOs;
        public Int32 NumCleaves;
        public Int32 OnHandAttacks;
        public Int32 OffHandAttacks;
        public Int32 AdditAttacks;
        public Int32 EffectAttacks;
        public Byte ParryActions;
        public Int32 OffHandTaken;
        public Int32 ExtraTaken;
    
        // List definitions
        public List<AAttack> AttackList;
    
        // Class definitions    
        public class AAttack : AuroraStruct {
            // Field definitions
            public uint structid;
            public Byte AttackGroup;
            public UInt16 AnimationLength;
            public UInt32 MissedBy;
            public Byte AttackResult;
            public UInt32 ReactObject;
            public UInt16 ReaxnDelay;
            public UInt16 ReaxnAnimation;
            public UInt16 ReaxnAnimLength;
            public Byte Concealment;
            public UInt16 AttackType;
            public Byte AttackMode;
            public Int32 RangedAttack;
            public Int32 SneakAttack;
            public Byte WeaponAttackType;
            public Single RangedTargetX;
            public Single RangedTargetY;
            public Single RangedTargetZ;
            public Byte KillingBlow;
            public Byte CoupDeGrace;
            public Byte CriticalThreat;
            public Byte AttackDeflected;
            public UInt32 AmmoItem;
            public String AttackDebugText;
            public String DamageDebugText;
        
            // List definitions
            public List<ADamage> DamageList;
        
            // Class definitions    
            public class ADamage : AuroraStruct {
                // Field definitions
                public uint structid;
                public Int16 DamageValue;
                
            }
            
        }
        
    }
    
    public class AFollowInfo : AuroraStruct {
        // Field definitions
        public uint structid;
        public UInt32 FollowObject;
        public Vector3 FollowLocation;
        public Vector3 LastLeaderPos;
        public Vector3 LastFollowerPos;
        public Single MaxSpeed;
        public Byte StickToPos;
        public UInt32 Result;
        public UInt32 TimeElapsed;
        public Byte InSafetyRange;
        
    }
    
    public class ASWVarTable : AuroraStruct {
        // Field definitions
        public uint structid;
    
        // List definitions
        public List<ABitArray> BitArray;
        public List<AByteArray> ByteArray;
    
        // Class definitions    
        public class ABitArray : AuroraStruct {
            // Field definitions
            public uint structid;
            public UInt32 Variable;
            
        }
        
        public class AByteArray : AuroraStruct {
            // Field definitions
            public uint structid;
            public Byte Variable;
            
        }
        
    }
    
    public class ASkill : AuroraStruct {
        // Field definitions
        public uint structid;
        public Byte Rank;
        
    }
    
    public class AClass : AuroraStruct {
        // Field definitions
        public uint structid;
        public Int32 Class;
        public Int16 ClassLevel;
    
        // List definitions
        public List<AKnown0> KnownList0;
        public List<ASpellsPerDay> SpellsPerDayList;
    
        // Class definitions    
        public class AKnown0 : AuroraStruct {
            // Field definitions
            public uint structid;
            public UInt16 Spell;
            public Byte SpellMetaMagic;
            public Byte SpellFlags;
            
        }
        
        public class ASpellsPerDay : AuroraStruct {
            // Field definitions
            public uint structid;
            public Byte NumSpellsLeft;
            
        }
        
    }
    
    public class AEquip_Item : AuroraStruct {
        // Field definitions
        public uint structid;
        public String EquippedRes;
        public Byte Dropable;
        public UInt32 ObjectId;
        public Int32 BaseItem;
        public String Tag;
        public Byte Identified;
        public CExoLocString Description;
        public CExoLocString DescIdentified;
        public CExoLocString LocalizedName;
        public UInt16 StackSize;
        public Byte Stolen;
        public UInt32 Upgrades;
        public Byte Pickpocketable;
        public Byte ModelVariation;
        public Byte BodyVariation;
        public Byte TextureVar;
        public Byte Charges;
        public Byte MaxCharges;
        public UInt32 Cost;
        public UInt32 AddCost;
        public Byte Plot;
        public Single XPosition;
        public Single YPosition;
        public Single ZPosition;
        public Single XOrientation;
        public Single YOrientation;
        public Single ZOrientation;
        public Byte NonEquippable;
        public Byte NewItem;
        public Byte DELETING;
    
        // List definitions
        public List<AProperties> PropertiesList;
    
        // Class definitions    
        public class AProperties : AuroraStruct {
            // Field definitions
            public uint structid;
            public UInt16 PropertyName;
            public UInt16 Subtype;
            public Byte CostTable;
            public UInt16 CostValue;
            public Byte Param1;
            public Byte Param1Value;
            public Byte ChanceAppear;
            public Byte UsesPerDay;
            public Byte Useable;
            public Byte UpgradeType;
            
        }
        
    }
    
    public class AFeat : AuroraStruct {
        // Field definitions
        public uint structid;
        public UInt16 Feat;
        
    }
    
    public class AItem : AuroraStruct {
        // Field definitions
        public uint structid;
        public String InventoryRes;
        public UInt16 Repos_PosX;
        public UInt16 Repos_Posy;
        public Byte Dropable;
        public UInt32 ObjectId;
        public Int32 BaseItem;
        public String Tag;
        public Byte Identified;
        public CExoLocString Description;
        public CExoLocString DescIdentified;
        public CExoLocString LocalizedName;
        public UInt16 StackSize;
        public Byte Stolen;
        public UInt32 Upgrades;
        public Byte Pickpocketable;
        public Byte ModelVariation;
        public Byte Charges;
        public Byte MaxCharges;
        public UInt32 Cost;
        public UInt32 AddCost;
        public Byte Plot;
        public Single XPosition;
        public Single YPosition;
        public Single ZPosition;
        public Single XOrientation;
        public Single YOrientation;
        public Single ZOrientation;
        public Byte NonEquippable;
        public Byte NewItem;
        public Byte DELETING;
    
        // List definitions
        public List<AProperties> PropertiesList;
    
        // Class definitions    
        public class AProperties : AuroraStruct {
            // Field definitions
            public uint structid;
            public UInt16 PropertyName;
            public UInt16 Subtype;
            public Byte CostTable;
            public UInt16 CostValue;
            public Byte Param1;
            public Byte Param1Value;
            public Byte ChanceAppear;
            public Byte UsesPerDay;
            public Byte Useable;
            public Byte UpgradeType;
            
        }
        
    }
    
    public class ASpecAbility : AuroraStruct {
        // Field definitions
        public uint structid;
        public UInt16 Spell;
        public Byte SpellFlags;
        public Byte SpellCasterLevel;
        
    }
    
    public class APerception : AuroraStruct {
        // Field definitions
        public uint structid;
        public UInt32 ObjectId;
        public Byte PerceptionData;
        
    }
    
    public class AExpression : AuroraStruct {
        // Field definitions
        public uint structid;
        public Int32 ExpressionId;
        public String ExpressionString;
        
    }
    
    public class AEffect : AuroraStruct {
        // Field definitions
        public uint structid;
        public UInt64 Id;
        public UInt16 Type;
        public UInt16 SubType;
        public Single Duration;
        public Byte SkipOnLoad;
        public UInt32 ExpireDay;
        public UInt32 ExpireTime;
        public UInt32 CreatorId;
        public UInt32 SpellId;
        public Int32 IsExposed;
        public Int32 NumIntegers;
    
        // List definitions
        public List<AInt> IntList;
        public List<AFloat> FloatList;
        public List<AString> StringList;
        public List<AObject> ObjectList;
    
        // Class definitions    
        public class AInt : AuroraStruct {
            // Field definitions
            public uint structid;
            public Int32 Value;
            
        }
        
        public class AFloat : AuroraStruct {
            // Field definitions
            public uint structid;
            public Single Value;
            
        }
        
        public class AString : AuroraStruct {
            // Field definitions
            public uint structid;
            public String Value;
            
        }
        
        public class AObject : AuroraStruct {
            // Field definitions
            public uint structid;
            public UInt32 Value;
            
        }
        
    }
    
    public class AAction : AuroraStruct {
        // Field definitions
        public uint structid;
        public UInt32 ActionId;
        public UInt16 GroupActionId;
        public UInt16 NumParams;
    
        // List definitions
        public List<AParamaters> Paramaters;
    
        // Class definitions    
        public class AParamaters : AuroraStruct {
            // Field definitions
            public uint structid;
            public UInt32 Type;
            public Int32 Value;
        
            // Struct definitions
            public AValue Value;
        
            // Class definitions    
            public class AValue : AuroraStruct {
                // Field definitions
                public uint structid;
                public Int32 CodeSize;
                public Byte[] Code;
                public UInt32 CRC;
                public Int32 InstructionPtr;
                public Int32 SecondaryPtr;
                public String Name;
                public Int32 StackSize;
            
                // Struct definitions
                public AStack Stack;
            
                // Class definitions    
                public class AStack : AuroraStruct {
                    // Field definitions
                    public uint structid;
                    public Int32 BasePointer;
                    public Int32 StackPointer;
                    public Int32 TotalSize;
                
                    // List definitions
                    public List<AStack> Stack;
                
                    // Class definitions    
                    public class AStack : AuroraStruct {
                        // Field definitions
                        public uint structid;
                        public Char Type;
                        public Int32 Value;
                        
                    }
                    
                }
                
            }
            
        }
        
    }
    
    public class ALvlStat : AuroraStruct {
        // Field definitions
        public uint structid;
        public Byte LvlStatHitDie;
        public Byte LvlStatForce;
        public Byte LvlStatClass;
        public UInt16 SkillPoints;
        public Byte LvlStatAbility;
    
        // List definitions
        public List<ASkill> SkillList;
        public List<AFeat> FeatList;
        public List<AKnown0> KnownList0;
    
        // Class definitions    
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
        
        public class AKnown0 : AuroraStruct {
            // Field definitions
            public uint structid;
            public UInt16 Spell;
            
        }
        
    }
    
}
