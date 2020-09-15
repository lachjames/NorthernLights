using System;
using System.Collections.Generic;
using static AuroraEngine.GFFObject;
using UnityEngine;
using AuroraEngine;

[Serializable]public class AuroraUTT : AuroraStruct {
    // Field definitions
    [GFF("structid")] public uint structid;
    [GFF("Tag")] public CExoString Tag;
    [GFF("TemplateResRef")] public String TemplateResRef;
    [GFF("LocalizedName")] public CExoLocString LocalizedName;
    [GFF("AutoRemoveKey")] public Byte AutoRemoveKey;
    [GFF("Faction")] public UInt32 Faction;
    [GFF("Cursor")] public Byte Cursor;
    [GFF("HighlightHeight")] public Single HighlightHeight;
    [GFF("KeyName")] public CExoString KeyName;
    [GFF("LoadScreenID")] public UInt16 LoadScreenID;
    [GFF("PortraitId")] public UInt16 PortraitId;
    [GFF("Type")] public Int32 Type;
    [GFF("TrapDetectable")] public Byte TrapDetectable;
    [GFF("TrapDetectDC")] public Byte TrapDetectDC;
    [GFF("TrapDisarmable")] public Byte TrapDisarmable;
    [GFF("DisarmDC")] public Byte DisarmDC;
    [GFF("TrapFlag")] public Byte TrapFlag;
    [GFF("TrapOneShot")] public Byte TrapOneShot;
    [GFF("TrapType")] public Byte TrapType;
    [GFF("OnDisarm")] public String OnDisarm;
    [GFF("OnTrapTriggered")] public String OnTrapTriggered;
    [GFF("OnClick")] public String OnClick;
    [GFF("ScriptHeartbeat")] public String ScriptHeartbeat;
    [GFF("ScriptOnEnter")] public String ScriptOnEnter;
    [GFF("ScriptOnExit")] public String ScriptOnExit;
    [GFF("ScriptUserDefine")] public String ScriptUserDefine;
    [GFF("PaletteID")] public Byte PaletteID;
    [GFF("Comment")] public CExoString Comment;
    [GFF("Portrait")] public String Portrait;
    [GFF("LinkedTo")] public CExoString LinkedTo;
    [GFF("PartyRequired")] public Byte PartyRequired;
    [GFF("LinkedToFlags")] public Byte LinkedToFlags;
    [GFF("LinkedToModule")] public String LinkedToModule;
    
}
