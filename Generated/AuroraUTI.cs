using System;
using System.Collections.Generic;
using static AuroraEngine.GFFObject;
using UnityEngine;
using AuroraEngine;

[Serializable]public class AuroraUTI : AuroraStruct {
    // Field definitions
    [GFF("structid", Compatibility.BOTH, ExistsIn.BASE)] public uint structid;
    [GFF("TemplateResRef", Compatibility.BOTH, ExistsIn.BASE)] public String TemplateResRef;
    [GFF("BaseItem", Compatibility.BOTH, ExistsIn.BASE)] public Int32 BaseItem;
    [GFF("LocalizedName", Compatibility.BOTH, ExistsIn.BASE)] public CExoLocString LocalizedName;
    [GFF("Description", Compatibility.BOTH, ExistsIn.BASE)] public CExoLocString Description;
    [GFF("DescIdentified", Compatibility.BOTH, ExistsIn.BASE)] public CExoLocString DescIdentified;
    [GFF("Tag", Compatibility.BOTH, ExistsIn.BASE)] public CExoString Tag;
    [GFF("Charges", Compatibility.BOTH, ExistsIn.BASE)] public Byte Charges;
    [GFF("Cost", Compatibility.BOTH, ExistsIn.BASE)] public UInt32 Cost;
    [GFF("Stolen", Compatibility.BOTH, ExistsIn.BASE)] public Byte Stolen;
    [GFF("StackSize", Compatibility.BOTH, ExistsIn.BASE)] public UInt16 StackSize;
    [GFF("Plot", Compatibility.BOTH, ExistsIn.BASE)] public Byte Plot;
    [GFF("AddCost", Compatibility.BOTH, ExistsIn.BASE)] public UInt32 AddCost;
    [GFF("Identified", Compatibility.BOTH, ExistsIn.BASE)] public Byte Identified;
    [GFF("BodyVariation", Compatibility.BOTH, ExistsIn.BASE)] public Byte BodyVariation;
    [GFF("TextureVar", Compatibility.BOTH, ExistsIn.BASE)] public Byte TextureVar;
    [GFF("PaletteID", Compatibility.BOTH, ExistsIn.BASE)] public Byte PaletteID;
    [GFF("Comment", Compatibility.BOTH, ExistsIn.BASE)] public CExoString Comment;
    [GFF("ModelVariation", Compatibility.BOTH, ExistsIn.BASE)] public Byte ModelVariation;
    [GFF("ModelPart3", Compatibility.TSL, ExistsIn.BASE)] public Byte ModelPart3;
    [GFF("ModelPart2", Compatibility.TSL, ExistsIn.BASE)] public Byte ModelPart2;
    [GFF("ModelPart1", Compatibility.TSL, ExistsIn.BASE)] public Byte ModelPart1;
    [GFF("UpgradeLevel", Compatibility.KotOR, ExistsIn.BASE)] public Byte UpgradeLevel;
    [GFF("KTInfoVersion", Compatibility.KotOR, ExistsIn.BASE)] public CExoString KTInfoVersion;
    [GFF("KTInfoDate", Compatibility.KotOR, ExistsIn.BASE)] public CExoString KTInfoDate;
    [GFF("KTGameVerIndex", Compatibility.KotOR, ExistsIn.BASE)] public Int32 KTGameVerIndex;

    // List definitions
    [GFF("PropertiesList", Compatibility.BOTH, ExistsIn.BASE)] public List<AProperties> PropertiesList = new List<AProperties>();

    // Class definitions    
    [Serializable]public class AProperties : AuroraStruct {
        // Field definitions
        [GFF("structid", Compatibility.BOTH, ExistsIn.BASE)] public uint structid;
        [GFF("PropertyName", Compatibility.BOTH, ExistsIn.BASE)] public UInt16 PropertyName;
        [GFF("Subtype", Compatibility.BOTH, ExistsIn.BASE)] public UInt16 Subtype;
        [GFF("CostTable", Compatibility.BOTH, ExistsIn.BASE)] public Byte CostTable;
        [GFF("CostValue", Compatibility.BOTH, ExistsIn.BASE)] public UInt16 CostValue;
        [GFF("Param1", Compatibility.BOTH, ExistsIn.BASE)] public Byte Param1;
        [GFF("Param1Value", Compatibility.BOTH, ExistsIn.BASE)] public Byte Param1Value;
        [GFF("ChanceAppear", Compatibility.BOTH, ExistsIn.BASE)] public Byte ChanceAppear;
        [GFF("UpgradeType", Compatibility.BOTH, ExistsIn.BASE)] public Byte UpgradeType;
        
    }
    
}
