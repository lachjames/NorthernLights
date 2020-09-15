using System;
using System.Collections.Generic;
using static AuroraEngine.GFFObject;
using UnityEngine;
using AuroraEngine;

[Serializable]public class AuroraUTI : AuroraStruct {
    // Field definitions
    [GFF("structid")] public uint structid;
    [GFF("TemplateResRef")] public String TemplateResRef;
    [GFF("BaseItem")] public Int32 BaseItem;
    [GFF("LocalizedName")] public CExoLocString LocalizedName;
    [GFF("Description")] public CExoLocString Description;
    [GFF("DescIdentified")] public CExoLocString DescIdentified;
    [GFF("Tag")] public CExoString Tag;
    [GFF("Charges")] public Byte Charges;
    [GFF("Cost")] public UInt32 Cost;
    [GFF("Stolen")] public Byte Stolen;
    [GFF("StackSize")] public UInt16 StackSize;
    [GFF("Plot")] public Byte Plot;
    [GFF("AddCost")] public UInt32 AddCost;
    [GFF("Identified")] public Byte Identified;
    [GFF("BodyVariation")] public Byte BodyVariation;
    [GFF("TextureVar")] public Byte TextureVar;
    [GFF("PaletteID")] public Byte PaletteID;
    [GFF("Comment")] public CExoString Comment;
    [GFF("ModelVariation")] public Byte ModelVariation;
    [GFF("ModelPart3")] public Byte ModelPart3;
    [GFF("ModelPart2")] public Byte ModelPart2;
    [GFF("ModelPart1")] public Byte ModelPart1;

    // List definitions
    [GFF("PropertiesList")] public List<AProperties> PropertiesList = new List<AProperties>();

    // Class definitions    
    [Serializable]public class AProperties : AuroraStruct {
        // Field definitions
        [GFF("structid")] public uint structid;
        [GFF("PropertyName")] public UInt16 PropertyName;
        [GFF("Subtype")] public UInt16 Subtype;
        [GFF("CostTable")] public Byte CostTable;
        [GFF("CostValue")] public UInt16 CostValue;
        [GFF("Param1")] public Byte Param1;
        [GFF("Param1Value")] public Byte Param1Value;
        [GFF("ChanceAppear")] public Byte ChanceAppear;
        [GFF("UpgradeType")] public Byte UpgradeType;
        
    }
    
}
