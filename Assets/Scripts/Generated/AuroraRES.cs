using System;
using System.Collections.Generic;
using static AuroraEngine.GFFObject;
using UnityEngine;
using AuroraEngine;

[Serializable]public class AuroraRES : AuroraStruct {
    // Field definitions
    [GFF("structid")] public uint structid;

    // List definitions
    [GFF("ItemList")] public List<AItem> ItemList = new List<AItem>();

    // Class definitions    
    [Serializable]public class AItem : AuroraStruct {
        // Field definitions
        [GFF("structid")] public uint structid;
        [GFF("BaseItem")] public Int32 BaseItem;
        [GFF("Tag")] public CExoString Tag;
        [GFF("Identified")] public Byte Identified;
        [GFF("Description")] public CExoLocString Description;
        [GFF("DescIdentified")] public CExoLocString DescIdentified;
        [GFF("LocalizedName")] public CExoLocString LocalizedName;
        [GFF("StackSize")] public UInt16 StackSize;
        [GFF("Stolen")] public Byte Stolen;
        [GFF("Upgrades")] public UInt32 Upgrades;
        [GFF("Dropable")] public Byte Dropable;
        [GFF("Pickpocketable")] public Byte Pickpocketable;
        [GFF("ModelVariation")] public Byte ModelVariation;
        [GFF("Charges")] public Byte Charges;
        [GFF("MaxCharges")] public Byte MaxCharges;
        [GFF("Cost")] public UInt32 Cost;
        [GFF("AddCost")] public UInt32 AddCost;
        [GFF("Plot")] public Byte Plot;
        [GFF("XPosition")] public Single XPosition;
        [GFF("YPosition")] public Single YPosition;
        [GFF("ZPosition")] public Single ZPosition;
        [GFF("XOrientation")] public Single XOrientation;
        [GFF("YOrientation")] public Single YOrientation;
        [GFF("ZOrientation")] public Single ZOrientation;
        [GFF("NonEquippable")] public Byte NonEquippable;
        [GFF("NewItem")] public Byte NewItem;
        [GFF("DELETING")] public Byte DELETING;
        [GFF("BodyVariation")] public Byte BodyVariation;
        [GFF("TextureVar")] public Byte TextureVar;
    
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
            [GFF("UsesPerDay")] public Byte UsesPerDay;
            [GFF("Useable")] public Byte Useable;
            [GFF("UpgradeType")] public Byte UpgradeType;
            
        }
        
    }
    
}
