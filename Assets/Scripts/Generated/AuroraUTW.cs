using System;
using System.Collections.Generic;
using static AuroraEngine.GFFObject;
using UnityEngine;
using AuroraEngine;

[Serializable]public class AuroraUTW : AuroraStruct {
    // Field definitions
    [GFF("structid", Compatibility.BOTH, ExistsIn.BASE)] public uint structid;
    [GFF("Appearance", Compatibility.BOTH, ExistsIn.BASE)] public Byte Appearance;
    [GFF("LinkedTo", Compatibility.BOTH, ExistsIn.BASE)] public CExoString LinkedTo = new CExoString();
    [GFF("TemplateResRef", Compatibility.BOTH, ExistsIn.BASE)] public String TemplateResRef;
    [GFF("Tag", Compatibility.BOTH, ExistsIn.BASE)] public CExoString Tag = new CExoString();
    [GFF("LocalizedName", Compatibility.BOTH, ExistsIn.BASE)] public CExoLocString LocalizedName = new CExoLocString();
    [GFF("Description", Compatibility.BOTH, ExistsIn.BASE)] public CExoLocString Description = new CExoLocString();
    [GFF("HasMapNote", Compatibility.BOTH, ExistsIn.BASE)] public Byte HasMapNote;
    [GFF("MapNote", Compatibility.BOTH, ExistsIn.BASE)] public CExoLocString MapNote = new CExoLocString();
    [GFF("MapNoteEnabled", Compatibility.BOTH, ExistsIn.BASE)] public Byte MapNoteEnabled;
    [GFF("PaletteID", Compatibility.BOTH, ExistsIn.BASE)] public Byte PaletteID;
    [GFF("Comment", Compatibility.BOTH, ExistsIn.BASE)] public CExoString Comment = new CExoString();
    [GFF("LinkedToModule", Compatibility.KotOR, ExistsIn.BASE)] public String LinkedToModule;
    [GFF("KTInfoVersion", Compatibility.TSL, ExistsIn.BASE)] public CExoString KTInfoVersion = new CExoString();
    [GFF("KTInfoDate", Compatibility.TSL, ExistsIn.BASE)] public CExoString KTInfoDate = new CExoString();
    [GFF("KTGameVerIndex", Compatibility.TSL, ExistsIn.BASE)] public Int32 KTGameVerIndex;
    
}
