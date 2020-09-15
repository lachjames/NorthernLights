//using AuroraEngine;
//using System;
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class AuroraBase
//{
//    public uint id;
//}

//// Creature types (UTC)
//public class AuroraCreature : AuroraBase
//{
//    public string TemplateResRef;
//    public byte Race;
//    public byte SubraceIndex;
//    public GFFObject.CExoLocString FirstName;
//    public GFFObject.CExoLocString LastName;
//    public ushort Appearance_Type;
//    public byte Gender;
//    public int Phenotype;
//    public ushort PortraitId;
//    public GFFObject.CExoLocString Description;
//    public string Tag;
//    public string Conversation;
//    public byte IsPC;
//    public ushort FactionID;
//    public byte Disarmable;
//    public string Subrace;
//    public string Deity;
//    public ushort SoundSetFile;
//    public byte Plot, Interruptable, NoPermDeath, NotReorienting, BodyBag, BodyVariation,
//        TextureVar, Min1HP, PartyInteract, Hologram, IgnoreCrePath, MultiplierSet,
//        Str, Dex, Con, Int, Wis, Cha;
//    public int WalkRate;
//    public byte NaturalAC;
//    public short HitPoints, CurrentHitPoints, MaxHitPoints, ForcePoints,
//        CurrentForce, refbonus, willbonus, fortbonus;
//    public byte GoodEvil, LawfulChaotic;
//    public float BlindSpot;
//    public float ChallengeRating;
//    public byte PerceptionRange;
//    public string ScriptHeartbeat, ScriptOnNotice, ScriptSpellAt, ScriptAttacked,
//        ScriptDamaged, ScriptDisturbed, ScriptEndRound, ScriptEndDialogu, ScriptDialogue,
//        ScriptSpawn, ScriptRested, ScriptDeath, ScriptUserDefine, ScriptOnBlocked;

//    public List<SkillObj> SkillList;
//    public List<FeatObj> FeatList;

//    public List<TemplateObj> TemplateList;
//    public List<SpecAbilityObj> SpecAbilityList;

//    public List<ClassObj> ClassList;
//    public List<ItemObj> ItemList;
//    public List<EquippedItemObj> Equip_ItemList;

//    public byte PaletteID;
//    public string Comment;
//}

//public class SkillObj : AuroraBase
//{
//    public byte Rank;
//}

//public class FeatObj : AuroraBase
//{
//    public ushort Feat;
//}

//public class TemplateObj : AuroraBase
//{

//}

//public class SpecAbilityObj : AuroraBase
//{
//    public ushort Spell;
//    public byte SpellCasterLevel, SpellFlags;
//}

//public class ClassObj : AuroraBase
//{
//    public int Class;
//    public short ClassLevel;

//    public List<KnownSpellObj> KnownList0;
//}

//public class KnownSpellObj : AuroraBase
//{
//    public ushort Spell;
//    public byte SpellMetaMagic, SpellFlags;
//}

//public class ItemObj : AuroraBase
//{
//    public string InventoryRes;
//    public ushort Repos_PosX, Repos_Posy;
//    public byte Dropable;
//}

//public class EquippedItemObj : AuroraBase
//{
//    public string EquippedRes;
//}

//// Aurora Area File (ARE, GIT, GIC)
//public class AuroraArea : AuroraBase
//{
//    public int ID;
//    public int Creator_ID;
//    public uint Version;
//    public string Untitled;
//    public string Tag;
//    public GFFObject.CExoLocString Name;
//    public string Comments;
//    public AuroraMap Map;
//    public List<ExpansionObj> Expansion_List;
//    public uint Flags;
//    public int ModSpotCheck, ModListenCheck;
//    public float AlphaTest;
//    public int CameraStyle;
//    public string DefaultEnvMap, Grass_TexName;
//    public float Grass_Density, Grass_QuadSize;
//    public uint Grass_Ambient, Grass_Diffuse, Grass_Emissive;
//    public float Grass_Prob_LL, Grass_Prob_LR, Grass_Prob_UL, Grass_Prob_UR;
//    public uint MoonAmbientColor, MoonDiffuseColor;
//    public byte MoonFogOn;
//    public float MoonFogNear, MoonFogFar;
//    public uint MoonFogColor;
//    public byte MoonShadows;
//    public uint SunAmbientColor, SunDiffuseColor;
//    public byte SunFogOn;
//    public float SunFogNear, SunFogFar;
//    public uint SunFogColor;
//    public byte SunShadows;
//    public uint DynAmbientColor;
//    public byte IsNight, LightingScheme, ShadowOpacity, DayNightCycle;
//    public int ChanceRain, ChanceSnow, ChanceLightning, WindPower;
//    public uint LoadScreenID;
//    public byte PlayerVsPlayer, NoRest, NoHangBack, PlayerOnly, Unescapable,
//        DisableTransit, StealthXPEnabled;
//    public uint StealthXPLoss, StealthXPMax;
//    public uint DirtyARGBOne, DirtySizeOne, DirtyFormulaOne, DirtuFuncOne;
//    public uint DirtyARGBTwo, DirtySizeTwo, DirtyFormulaTwo, DirtyFuncTwo;
//    public uint DirtyARGBThree, DirtySizeThree, DirtyFormulaThre, DirtyFuncThree;
//    public List<RoomObj> Rooms;
//    public string OnEnter, OnExit, OnHeartbeat, OnUserDefined;
//}

//public class AuroraMap : AuroraBase
//{
//    public int MapResX;
//    public int NorthAxis;
//    public float WorldPt1X, WorldPt1Y, WorldPt2X, WorldPt2Y, 
//        MapPt1X, MapPt1Y, MapPt2X, MapPt2Y;
//    public int MapZoom;
//}

//public class ExpansionObj : AuroraBase
//{

//}

//public class RoomObj : AuroraBase
//{
//    public string RoomName;
//    public int EnvAudio;
//    public float AmbientScale;
//    public int ForceRating;
//    public byte DisableWeather;
//}

//// Aurora GIT
//public class AuroraGit : AuroraBase
//{
//    public List<AuroraAreaProperties> AreaProperties;
//    public List<AuroraCreature> CreatureList;
//    public List<AuroraDoor> DoorList;
//    public List<AuroraEncounter> EncounterList;
//    public List<AuroraItem> List;
//    public List<AuroraPlaceable> PlaceableList;
//    public List<AuroraSound> SoundList;
//    public List<AuroraStore> StoreList;
//    public List<AuroraTrigger> TriggerList;
//    public List<AuroraWaypoint> WaypointList;
//}

//public class AuroraAreaProperties : AuroraBase
//{
//    public int AmbientSndDay, AmbientSndDayVol, AmbientSndNight, AmbientSndNitVol,
//        EnvAudio, MusicBattle, MusicDay, MusicDelay, MusicNight;
//}

//// Aurora Situated Object (UTD, UTP)
//public class AuroraSituated : AuroraBase
//{
//    public string Tag;
//    public GFFObject.CExoLocString LocName, Description;
//    public string TemplateResRef;
//    public byte AutoRemoveKey, CloseLockDC;
//    public string Conversation;
//    public byte Interruptable;
//    public uint Faction;
//    public byte Plot;
//    public byte Min1HP, KeyRequired, Lockable, Locked,
//        OpenLockDC;
//    public ushort PortraitId;
//    public byte TrapDetectable, TrapDetectDC, TrapDisarmable, DisarmDC,
//        TrapFlag, TrapOneShot, TrapType;
//    public string KeyName;
//    public byte AnimationState;
//    public uint Appearance;
//    public short HP;
//    public short CurrentHP;
//    public byte Hardness, Fort, Ref, Will;
//    public string OnClosed, OnDamaged, OnDeath, OnDisarm, OnHeartbeat, OnLock,
//        OnMeleeAttacked, OnOpen, OnSpellCastAt, OnTrapTriggered, OnUnlock,
//        OnUserDefined;
//    public byte Static;
//    public string OnFailToOpen;
//    public byte PaletteID;
//    public string Comment;
//}

//public class AuroraDoor : AuroraSituated
//{
//    public ushort LoadScreenID;
//    public byte GenericType;
//    public string OnClick;
//}

//public class AuroraPlaceable : AuroraSituated
//{
//    public byte NotBlastable;
//    public byte OpenLockDiff;
//    public char OpenLockDiffMod;
//    public byte HasInventory, PartyInteract, BodyBag, Type, Useable;
//    public string OnEndDialogue, OnInvDisturbed, OnUsed;
//    public List<ItemObj> ItemList;
//}

//public class AuroraDialogue : AuroraBase
//{
//    public uint DelayEntry, DelayReply, NumWords;
//    public string EndConverAbort, EndConversation;
//    public byte Skippable;
//    public List<AuroraStunt> StuntList;
//    public string CameraModel;
//    public string VO_ID;
//    public int ConversationType;
//    public byte ComputerType;
//    public byte OldHitCheck;
//    public string AmbientTrack;
//    public byte UnequipItems;
//    public byte AnimatedCut;
//    public byte UnequipHItem;
//    public List<AuroraEntry> EntryList;
//    public List<AuroraReply> ReplyList;
//    public List<AuroraStarting> StartingList;
//}

//public class AuroraStunt : AuroraBase
//{
//    // TODO: Implement this
//}


//public class AuroraLine : AuroraBase
//{
//    public GFFObject.CExoLocString Text;
//    public string VO_ResRef;
//    public string Script;
//    public uint Delay;
//    public string Comment;
//    public string Sound;
//    public string Quest;
//    public int PlotIndex;
//    public Single PlotXPPercentage;
//    public string Listener;
//    public uint WaitFlags;
//    public uint CameraAngle;
//    public byte FadeType;
//    public Single CamHeightOffset, TarHeightOffset;
//    public List<AuroraAnimation> AnimList;
//    public uint QuestEntry;
//    public byte SoundExists;
//    public int CameraID;
//    public int CamVidEffect;
//}

//public class AuroraAnimation : AuroraBase
//{
//    // TODO: Implement this
//}

//public class AuroraEntry : AuroraLine
//{
//    public string Speaker;
//    public List<AuroraReplyLink> RepliesList;
//}

//public class AuroraReply : AuroraLine
//{
//    public List<AuroraEntryLink> EntriesList;
//}

//public class AuroraStarting : AuroraBase
//{
//    public uint Index;
//    public string Active;
//}

//public class AuroraLink : AuroraBase
//{
//    public uint Index;
//    public string Active;
//    public byte IsChild;
//    public string LinkComment;
//}

//public class AuroraEntryLink : AuroraLink
//{
//}

//public class AuroraReplyLink : AuroraLink
//{
//}

//public class AuroraItem : AuroraBase
//{
//}

//public class AuroraTrigger : AuroraBase
//{

//}

//public class AuroraStore : AuroraBase
//{
//    public byte BlackMarket;
//    public int BM_MarkDown, IdentifyPrice;
//    public GFFObject.CExoLocString LocName;
//    public int MarkDown, MarkUp, MaxBuyPrice;

//}

//public class AuroraSound : AuroraBase
//{

//}


//public class AuroraWaypoint : AuroraBase
//{

//}