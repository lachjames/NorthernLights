using System;
using System.Collections.Generic;
using static AuroraEngine.GFFObject;
using UnityEngine;
using AuroraEngine;

[Serializable]public class AuroraUTT : AuroraStruct {
    // Field definitions
    [GFF("structid", Compatibility.BOTH, ExistsIn.BASE)] public uint structid;
    [GFF("Tag", Compatibility.BOTH, ExistsIn.BASE)] public CExoString Tag = new CExoString();
    [GFF("TemplateResRef", Compatibility.BOTH, ExistsIn.BASE)] public String TemplateResRef;
    [GFF("LocalizedName", Compatibility.BOTH, ExistsIn.BASE)] public CExoLocString LocalizedName = new CExoLocString();
    [GFF("AutoRemoveKey", Compatibility.BOTH, ExistsIn.BASE)] public Byte AutoRemoveKey;
    [GFF("Faction", Compatibility.BOTH, ExistsIn.BASE)] public UInt32 Faction;
    [GFF("Cursor", Compatibility.BOTH, ExistsIn.BASE)] public Byte Cursor;
    [GFF("HighlightHeight", Compatibility.BOTH, ExistsIn.BASE)] public Single HighlightHeight;
    [GFF("KeyName", Compatibility.BOTH, ExistsIn.BASE)] public CExoString KeyName = new CExoString();
    [GFF("LoadScreenID", Compatibility.BOTH, ExistsIn.BASE)] public UInt16 LoadScreenID;
    [GFF("PortraitId", Compatibility.BOTH, ExistsIn.BASE)] public UInt16 PortraitId;
    [GFF("Type", Compatibility.BOTH, ExistsIn.BASE)] public Int32 Type;
    [GFF("TrapDetectable", Compatibility.BOTH, ExistsIn.BASE)] public Byte TrapDetectable;
    [GFF("TrapDetectDC", Compatibility.BOTH, ExistsIn.BASE)] public Byte TrapDetectDC;
    [GFF("TrapDisarmable", Compatibility.BOTH, ExistsIn.BASE)] public Byte TrapDisarmable;
    [GFF("DisarmDC", Compatibility.BOTH, ExistsIn.BASE)] public Byte DisarmDC;
    [GFF("TrapFlag", Compatibility.BOTH, ExistsIn.BASE)] public Byte TrapFlag;
    [GFF("TrapOneShot", Compatibility.BOTH, ExistsIn.BASE)] public Byte TrapOneShot;
    [GFF("TrapType", Compatibility.BOTH, ExistsIn.BASE)] public Byte TrapType;
    [GFF("OnDisarm", Compatibility.BOTH, ExistsIn.BASE)] public String OnDisarm;
    [GFF("OnTrapTriggered", Compatibility.BOTH, ExistsIn.BASE)] public String OnTrapTriggered;
    [GFF("OnClick", Compatibility.BOTH, ExistsIn.BASE)] public String OnClick;
    [GFF("ScriptHeartbeat", Compatibility.BOTH, ExistsIn.BASE)] public String ScriptHeartbeat;
    [GFF("ScriptOnEnter", Compatibility.BOTH, ExistsIn.BASE)] public String ScriptOnEnter;
    [GFF("ScriptOnExit", Compatibility.BOTH, ExistsIn.BASE)] public String ScriptOnExit;
    [GFF("ScriptUserDefine", Compatibility.BOTH, ExistsIn.BASE)] public String ScriptUserDefine;
    [GFF("PaletteID", Compatibility.BOTH, ExistsIn.BASE)] public Byte PaletteID;
    [GFF("Comment", Compatibility.BOTH, ExistsIn.BASE)] public CExoString Comment = new CExoString();
    [GFF("Portrait", Compatibility.BOTH, ExistsIn.BASE)] public String Portrait;
    [GFF("LinkedTo", Compatibility.BOTH, ExistsIn.BASE)] public CExoString LinkedTo = new CExoString();
    [GFF("PartyRequired", Compatibility.BOTH, ExistsIn.BASE)] public Byte PartyRequired;
    [GFF("LinkedToFlags", Compatibility.BOTH, ExistsIn.BASE)] public Byte LinkedToFlags;
    [GFF("LinkedToModule", Compatibility.KotOR, ExistsIn.BASE)] public String LinkedToModule;
    [GFF("KTInfoVersion", Compatibility.TSL, ExistsIn.BASE)] public CExoString KTInfoVersion = new CExoString();
    [GFF("KTInfoDate", Compatibility.TSL, ExistsIn.BASE)] public CExoString KTInfoDate = new CExoString();
    [GFF("KTGameVerIndex", Compatibility.TSL, ExistsIn.BASE)] public Int32 KTGameVerIndex;
    
}
