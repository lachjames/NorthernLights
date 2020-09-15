using System;
using System.Collections.Generic;
using static AuroraEngine.GFFObject;
using UnityEngine;

public class AuroraUTI : AuroraStruct {
    // Field definitions
    public uint structid;
    public String TemplateResRef;
    public Int32 BaseItem;
    public CExoLocString LocalizedName;
    public CExoLocString Description;
    public CExoLocString DescIdentified;
    public String Tag;
    public Byte Charges;
    public UInt32 Cost;
    public Byte Stolen;
    public UInt16 StackSize;
    public Byte Plot;
    public UInt32 AddCost;
    public Byte Identified;
    public Byte BodyVariation;
    public Byte TextureVar;
    public Byte PaletteID;
    public String Comment;
    public Byte ModelVariation;
    public Byte ModelPart3;
    public Byte ModelPart2;
    public Byte ModelPart1;

    // List definitions
    public List<AProperties> PropertiesList;

    // Class definitions    
    public class AProperties : AuroraStruct {
        // Field definitions
        public uint structid;
        public UInt16 PropertyName;
        public UInt16 Subtype;
        public Byte CostTable;
        public UInt16 CostValue;
        public Byte Param1;
        public Byte Param1Value;
        public Byte ChanceAppear;
        public Byte UpgradeType;
        
    }
    
}
