using System;
using System.Collections.Generic;
using static AuroraEngine.GFFObject;
using UnityEngine;
using AuroraEngine;

[Serializable]public class AuroraBTI : AuroraStruct {
    // Field definitions
    [GFF("structid", Compatibility.TSL, ExistsIn.BASE)] public uint structid;
    [GFF("Charges", Compatibility.TSL, ExistsIn.BASE)] public Byte Charges;
    [GFF("TemplateResRef", Compatibility.TSL, ExistsIn.BASE)] public String TemplateResRef;
    [GFF("LocalizedName", Compatibility.TSL, ExistsIn.BASE)] public CExoLocString LocalizedName;
    [GFF("Comment", Compatibility.TSL, ExistsIn.BASE)] public CExoString Comment;
    [GFF("ModelPart1", Compatibility.TSL, ExistsIn.BASE)] public Byte ModelPart1;
    [GFF("Tag", Compatibility.TSL, ExistsIn.BASE)] public CExoString Tag;
    [GFF("BaseItem", Compatibility.TSL, ExistsIn.BASE)] public Int32 BaseItem;
    [GFF("Description", Compatibility.TSL, ExistsIn.BASE)] public CExoLocString Description;
    [GFF("DescIdentified", Compatibility.TSL, ExistsIn.BASE)] public CExoLocString DescIdentified;
    [GFF("Cost", Compatibility.TSL, ExistsIn.BASE)] public UInt32 Cost;
    
}
