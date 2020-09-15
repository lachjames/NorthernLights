using System;
using System.Collections.Generic;
using static AuroraEngine.GFFObject;
using UnityEngine;

public class AuroraUTW : AuroraStruct {
    // Field definitions
    public uint structid;
    public Byte Appearance;
    public String LinkedTo;
    public String TemplateResRef;
    public String Tag;
    public CExoLocString LocalizedName;
    public CExoLocString Description;
    public Byte HasMapNote;
    public CExoLocString MapNote;
    public Byte MapNoteEnabled;
    public Byte PaletteID;
    public String Comment;
    public String LinkedToModule;
    
}
