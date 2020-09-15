using System;
using System.Collections.Generic;
using static AuroraEngine.GFFObject;
using UnityEngine;
using AuroraEngine;

[Serializable]public class AuroraBTI : AuroraStruct {
    // Field definitions
    [GFF("structid")] public uint structid;
    [GFF("Charges")] public Byte Charges;
    [GFF("TemplateResRef")] public String TemplateResRef;
    [GFF("LocalizedName")] public CExoLocString LocalizedName;
    [GFF("Comment")] public CExoString Comment;
    [GFF("ModelPart1")] public Byte ModelPart1;
    [GFF("Tag")] public CExoString Tag;
    [GFF("BaseItem")] public Int32 BaseItem;
    [GFF("Description")] public CExoLocString Description;
    [GFF("DescIdentified")] public CExoLocString DescIdentified;
    [GFF("Cost")] public UInt32 Cost;
    
}
