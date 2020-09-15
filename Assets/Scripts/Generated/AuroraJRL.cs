using System;
using System.Collections.Generic;
using static AuroraEngine.GFFObject;
using UnityEngine;
using AuroraEngine;

[Serializable]public class AuroraJRL : AuroraStruct {
    // Field definitions
    [GFF("structid")] public uint structid;

    // List definitions
    [GFF("Categories")] public List<ACategories> Categories = new List<ACategories>();

    // Class definitions    
    [Serializable]public class ACategories : AuroraStruct {
        // Field definitions
        [GFF("structid")] public uint structid;
        [GFF("Name")] public CExoLocString Name;
        [GFF("Priority")] public UInt32 Priority;
        [GFF("Comment")] public CExoString Comment;
        [GFF("Tag")] public CExoString Tag;
        [GFF("PlotIndex")] public Int32 PlotIndex;
        [GFF("PlanetID")] public Int32 PlanetID;
        [GFF("XP")] public UInt32 XP;
        [GFF("Picture")] public UInt16 Picture;
    
        // List definitions
        [GFF("EntryList")] public List<AEntry> EntryList = new List<AEntry>();
    
        // Class definitions    
        [Serializable]public class AEntry : AuroraStruct {
            // Field definitions
            [GFF("structid")] public uint structid;
            [GFF("ID")] public UInt32 ID;
            [GFF("End")] public UInt16 End;
            [GFF("Text")] public CExoLocString Text;
            [GFF("XP_Percentage")] public Single XP_Percentage;
            
        }
        
    }
    
}
