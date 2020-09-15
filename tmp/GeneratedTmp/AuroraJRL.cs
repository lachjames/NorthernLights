using System;
using System.Collections.Generic;
using static AuroraEngine.GFFObject;
using UnityEngine;

public class AuroraJRL : AuroraStruct {
    // Field definitions
    public uint structid;

    // List definitions
    public List<ACategories> Categories;

    // Class definitions    
    public class ACategories : AuroraStruct {
        // Field definitions
        public uint structid;
        public CExoLocString Name;
        public UInt32 Priority;
        public String Comment;
        public String Tag;
        public Int32 PlotIndex;
        public Int32 PlanetID;
        public UInt32 XP;
        public UInt16 Picture;
    
        // List definitions
        public List<AEntry> EntryList;
    
        // Class definitions    
        public class AEntry : AuroraStruct {
            // Field definitions
            public uint structid;
            public UInt32 ID;
            public UInt16 End;
            public CExoLocString Text;
            public Single XP_Percentage;
            
        }
        
    }
    
}
