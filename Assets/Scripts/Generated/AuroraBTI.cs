using System;
using System.Collections.Generic;
using static AuroraEngine.GFFObject;
using UnityEngine;
using AuroraEngine;

[Serializable]public class AuroraBTI : AuroraStruct {
    // Field definitions
    [GFF("structid", Compatibility.KotOR, ExistsIn.BASE)] public uint structid;
    [GFF("Charges", Compatibility.KotOR, ExistsIn.BASE)] public Byte Charges;
    [GFF("TemplateResRef", Compatibility.KotOR, ExistsIn.BASE)] public String TemplateResRef;
    [GFF("LocalizedName", Compatibility.KotOR, ExistsIn.BASE)] public CExoLocString LocalizedName = new CExoLocString();
    [GFF("Comment", Compatibility.KotOR, ExistsIn.BASE)] public CExoString Comment = new CExoString();
    [GFF("ModelPart1", Compatibility.KotOR, ExistsIn.BASE)] public Byte ModelPart1;
    [GFF("Tag", Compatibility.KotOR, ExistsIn.BASE)] public CExoString Tag = new CExoString();
    [GFF("BaseItem", Compatibility.KotOR, ExistsIn.BASE)] public Int32 BaseItem;
    [GFF("Description", Compatibility.KotOR, ExistsIn.BASE)] public CExoLocString Description = new CExoLocString();
    [GFF("DescIdentified", Compatibility.KotOR, ExistsIn.BASE)] public CExoLocString DescIdentified = new CExoLocString();
    [GFF("Cost", Compatibility.KotOR, ExistsIn.BASE)] public UInt32 Cost;
    
}
