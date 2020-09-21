using System;
using System.Collections.Generic;
using static AuroraEngine.GFFObject;
using UnityEngine;
using AuroraEngine;

[Serializable]public class AuroraRES : AuroraStruct {
    // Field definitions
    [GFF("structid", Compatibility.BOTH, ExistsIn.SAVE)] public uint structid;

    // List definitions
    [GFF("ItemList", Compatibility.BOTH, ExistsIn.SAVE)] public List<AItem> ItemList = new List<AItem>();

    // Class definitions    
    [Serializable]public class AItem : AuroraStruct {
        // Field definitions
        [GFF("structid", Compatibility.BOTH, ExistsIn.SAVE)] public uint structid;
        [GFF("BaseItem", Compatibility.BOTH, ExistsIn.SAVE)] public Int32 BaseItem;
        [GFF("Tag", Compatibility.BOTH, ExistsIn.SAVE)] public CExoString Tag;
        [GFF("Identified", Compatibility.BOTH, ExistsIn.SAVE)] public Byte Identified;
        [GFF("Description", Compatibility.BOTH, ExistsIn.SAVE)] public CExoLocString Description;
        [GFF("DescIdentified", Compatibility.BOTH, ExistsIn.SAVE)] public CExoLocString DescIdentified;
        [GFF("LocalizedName", Compatibility.BOTH, ExistsIn.SAVE)] public CExoLocString LocalizedName;
        [GFF("StackSize", Compatibility.BOTH, ExistsIn.SAVE)] public UInt16 StackSize;
        [GFF("Stolen", Compatibility.BOTH, ExistsIn.SAVE)] public Byte Stolen;
        [GFF("Upgrades", Compatibility.BOTH, ExistsIn.SAVE)] public UInt32 Upgrades;
        [GFF("Dropable", Compatibility.BOTH, ExistsIn.SAVE)] public Byte Dropable;
        [GFF("Pickpocketable", Compatibility.BOTH, ExistsIn.SAVE)] public Byte Pickpocketable;
        [GFF("ModelVariation", Compatibility.BOTH, ExistsIn.SAVE)] public Byte ModelVariation;
        [GFF("Charges", Compatibility.BOTH, ExistsIn.SAVE)] public Byte Charges;
        [GFF("MaxCharges", Compatibility.BOTH, ExistsIn.SAVE)] public Byte MaxCharges;
        [GFF("Cost", Compatibility.BOTH, ExistsIn.SAVE)] public UInt32 Cost;
        [GFF("AddCost", Compatibility.BOTH, ExistsIn.SAVE)] public UInt32 AddCost;
        [GFF("Plot", Compatibility.BOTH, ExistsIn.SAVE)] public Byte Plot;
        [GFF("XPosition", Compatibility.BOTH, ExistsIn.SAVE)] public Single XPosition;
        [GFF("YPosition", Compatibility.BOTH, ExistsIn.SAVE)] public Single YPosition;
        [GFF("ZPosition", Compatibility.BOTH, ExistsIn.SAVE)] public Single ZPosition;
        [GFF("XOrientation", Compatibility.BOTH, ExistsIn.SAVE)] public Single XOrientation;
        [GFF("YOrientation", Compatibility.BOTH, ExistsIn.SAVE)] public Single YOrientation;
        [GFF("ZOrientation", Compatibility.BOTH, ExistsIn.SAVE)] public Single ZOrientation;
        [GFF("NonEquippable", Compatibility.BOTH, ExistsIn.SAVE)] public Byte NonEquippable;
        [GFF("NewItem", Compatibility.BOTH, ExistsIn.SAVE)] public Byte NewItem;
        [GFF("DELETING", Compatibility.BOTH, ExistsIn.SAVE)] public Byte DELETING;
        [GFF("BodyVariation", Compatibility.BOTH, ExistsIn.SAVE)] public Byte BodyVariation;
        [GFF("TextureVar", Compatibility.BOTH, ExistsIn.SAVE)] public Byte TextureVar;
        [GFF("UpgradeLevel", Compatibility.TSL, ExistsIn.SAVE)] public Byte UpgradeLevel;
        [GFF("UpgradeSlot0", Compatibility.TSL, ExistsIn.SAVE)] public Int32 UpgradeSlot0;
        [GFF("UpgradeSlot1", Compatibility.TSL, ExistsIn.SAVE)] public Int32 UpgradeSlot1;
        [GFF("UpgradeSlot2", Compatibility.TSL, ExistsIn.SAVE)] public Int32 UpgradeSlot2;
        [GFF("UpgradeSlot3", Compatibility.TSL, ExistsIn.SAVE)] public Int32 UpgradeSlot3;
        [GFF("UpgradeSlot4", Compatibility.TSL, ExistsIn.SAVE)] public Int32 UpgradeSlot4;
        [GFF("UpgradeSlot5", Compatibility.TSL, ExistsIn.SAVE)] public Int32 UpgradeSlot5;
    
        // List definitions
        [GFF("PropertiesList", Compatibility.BOTH, ExistsIn.SAVE)] public List<AProperties> PropertiesList = new List<AProperties>();
    
        // Class definitions    
        [Serializable]public class AProperties : AuroraStruct {
            // Field definitions
            [GFF("structid", Compatibility.BOTH, ExistsIn.SAVE)] public uint structid;
            [GFF("PropertyName", Compatibility.BOTH, ExistsIn.SAVE)] public UInt16 PropertyName;
            [GFF("Subtype", Compatibility.BOTH, ExistsIn.SAVE)] public UInt16 Subtype;
            [GFF("CostTable", Compatibility.BOTH, ExistsIn.SAVE)] public Byte CostTable;
            [GFF("CostValue", Compatibility.BOTH, ExistsIn.SAVE)] public UInt16 CostValue;
            [GFF("Param1", Compatibility.BOTH, ExistsIn.SAVE)] public Byte Param1;
            [GFF("Param1Value", Compatibility.BOTH, ExistsIn.SAVE)] public Byte Param1Value;
            [GFF("ChanceAppear", Compatibility.BOTH, ExistsIn.SAVE)] public Byte ChanceAppear;
            [GFF("UsesPerDay", Compatibility.BOTH, ExistsIn.SAVE)] public Byte UsesPerDay;
            [GFF("Useable", Compatibility.BOTH, ExistsIn.SAVE)] public Byte Useable;
            [GFF("UpgradeType", Compatibility.BOTH, ExistsIn.SAVE)] public Byte UpgradeType;
            [GFF("PropUpgrade", Compatibility.TSL, ExistsIn.SAVE)] public UInt16 PropUpgrade;
            
        }
        
    }
    
}
