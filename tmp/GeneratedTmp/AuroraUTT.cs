using System;
using System.Collections.Generic;
using static AuroraEngine.GFFObject;
using UnityEngine;

public class AuroraUTT : AuroraStruct {
    // Field definitions
    public uint structid;
    public String Tag;
    public String TemplateResRef;
    public CExoLocString LocalizedName;
    public Byte AutoRemoveKey;
    public UInt32 Faction;
    public Byte Cursor;
    public Single HighlightHeight;
    public String KeyName;
    public UInt16 LoadScreenID;
    public UInt16 PortraitId;
    public Int32 Type;
    public Byte TrapDetectable;
    public Byte TrapDetectDC;
    public Byte TrapDisarmable;
    public Byte DisarmDC;
    public Byte TrapFlag;
    public Byte TrapOneShot;
    public Byte TrapType;
    public String OnDisarm;
    public String OnTrapTriggered;
    public String OnClick;
    public String ScriptHeartbeat;
    public String ScriptOnEnter;
    public String ScriptOnExit;
    public String ScriptUserDefine;
    public Byte PaletteID;
    public String Comment;
    public String Portrait;
    public String LinkedTo;
    public Byte PartyRequired;
    public Byte LinkedToFlags;
    public String LinkedToModule;
    
}
