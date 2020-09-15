using System;
using System.Collections.Generic;
using static AuroraEngine.GFFObject;
using UnityEngine;
using AuroraEngine;

[Serializable]public class AuroraUTW : AuroraStruct {
    // Field definitions
    [GFF("structid")] public uint structid;
    [GFF("Appearance")] public Byte Appearance;
    [GFF("LinkedTo")] public CExoString LinkedTo;
    [GFF("TemplateResRef")] public String TemplateResRef;
    [GFF("Tag")] public CExoString Tag;
    [GFF("LocalizedName")] public CExoLocString LocalizedName;
    [GFF("Description")] public CExoLocString Description;
    [GFF("HasMapNote")] public Byte HasMapNote;
    [GFF("MapNote")] public CExoLocString MapNote;
    [GFF("MapNoteEnabled")] public Byte MapNoteEnabled;
    [GFF("PaletteID")] public Byte PaletteID;
    [GFF("Comment")] public CExoString Comment;
    [GFF("LinkedToModule")] public String LinkedToModule;
    
}
