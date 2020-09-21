using System;
using System.Collections.Generic;
using static AuroraEngine.GFFObject;
using UnityEngine;
using AuroraEngine;

[Serializable]public class AuroraJRL : AuroraStruct {
    // Field definitions
    [GFF("structid", Compatibility.BOTH, ExistsIn.BASE)] public uint structid;

    // List definitions
    [GFF("Categories", Compatibility.BOTH, ExistsIn.BASE)] public List<ACategories> Categories = new List<ACategories>();

    // Class definitions    
    [Serializable]public class ACategories : AuroraStruct {
        // Field definitions
        [GFF("structid", Compatibility.BOTH, ExistsIn.BASE)] public uint structid;
        [GFF("Name", Compatibility.BOTH, ExistsIn.BASE)] public CExoLocString Name;
        [GFF("Priority", Compatibility.BOTH, ExistsIn.BASE)] public UInt32 Priority;
        [GFF("Comment", Compatibility.BOTH, ExistsIn.BASE)] public CExoString Comment;
        [GFF("Tag", Compatibility.BOTH, ExistsIn.BASE)] public CExoString Tag;
        [GFF("PlotIndex", Compatibility.BOTH, ExistsIn.BASE)] public Int32 PlotIndex;
        [GFF("PlanetID", Compatibility.BOTH, ExistsIn.BASE)] public Int32 PlanetID;
        [GFF("XP", Compatibility.KotOR, ExistsIn.BASE)] public UInt32 XP;
        [GFF("Picture", Compatibility.KotOR, ExistsIn.BASE)] public UInt16 Picture;
    
        // List definitions
        [GFF("EntryList", Compatibility.BOTH, ExistsIn.BASE)] public List<AEntry> EntryList = new List<AEntry>();
    
        // Class definitions    
        [Serializable]public class AEntry : AuroraStruct {
            // Field definitions
            [GFF("structid", Compatibility.BOTH, ExistsIn.BASE)] public uint structid;
            [GFF("ID", Compatibility.BOTH, ExistsIn.BASE)] public UInt32 ID;
            [GFF("End", Compatibility.BOTH, ExistsIn.BASE)] public UInt16 End;
            [GFF("Text", Compatibility.BOTH, ExistsIn.BASE)] public CExoLocString Text;
            [GFF("XP_Percentage", Compatibility.BOTH, ExistsIn.BASE)] public Single XP_Percentage;
            
        }
        
    }
    
}
