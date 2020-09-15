using System;
using System.Collections.Generic;
using static AuroraEngine.GFFObject;
using UnityEngine;

public class AuroraRES : AuroraStruct {
    // Field definitions
    public uint structid;

    // List definitions
    public List<AItem> ItemList;

    // Class definitions    
    public class AItem : AuroraStruct {
        // Field definitions
        public uint structid;
        public Int32 BaseItem;
        public String Tag;
        public Byte Identified;
        public CExoLocString Description;
        public CExoLocString DescIdentified;
        public CExoLocString LocalizedName;
        public UInt16 StackSize;
        public Byte Stolen;
        public UInt32 Upgrades;
        public Byte Dropable;
        public Byte Pickpocketable;
        public Byte ModelVariation;
        public Byte Charges;
        public Byte MaxCharges;
        public UInt32 Cost;
        public UInt32 AddCost;
        public Byte Plot;
        public Single XPosition;
        public Single YPosition;
        public Single ZPosition;
        public Single XOrientation;
        public Single YOrientation;
        public Single ZOrientation;
        public Byte NonEquippable;
        public Byte NewItem;
        public Byte DELETING;
        public Byte BodyVariation;
        public Byte TextureVar;
    
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
            public Byte UsesPerDay;
            public Byte Useable;
            public Byte UpgradeType;
            
        }
        
    }
    
}
