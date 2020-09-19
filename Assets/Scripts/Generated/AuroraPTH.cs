using System;
using System.Collections.Generic;
using static AuroraEngine.GFFObject;
using UnityEngine;
using AuroraEngine;

[Serializable]public class AuroraPTH : AuroraStruct {
    // Field definitions
    [GFF("structid", Compatibility.BOTH, ExistsIn.BASE)] public uint structid;

    // List definitions
    [GFF("Path_Points", Compatibility.BOTH, ExistsIn.BASE)] public List<APath_Points> Path_Points = new List<APath_Points>();
    [GFF("Path_Conections", Compatibility.BOTH, ExistsIn.BASE)] public List<APath_Conections> Path_Conections = new List<APath_Conections>();

    // Class definitions    
    [Serializable]public class APath_Points : AuroraStruct {
        // Field definitions
        [GFF("structid", Compatibility.BOTH, ExistsIn.BASE)] public uint structid;
        [GFF("Conections", Compatibility.BOTH, ExistsIn.BASE)] public UInt32 Conections;
        [GFF("First_Conection", Compatibility.BOTH, ExistsIn.BASE)] public UInt32 First_Conection;
        [GFF("X", Compatibility.BOTH, ExistsIn.BASE)] public Single X;
        [GFF("Y", Compatibility.BOTH, ExistsIn.BASE)] public Single Y;
        
    }
    
    [Serializable]public class APath_Conections : AuroraStruct {
        // Field definitions
        [GFF("structid", Compatibility.BOTH, ExistsIn.BASE)] public uint structid;
        [GFF("Destination", Compatibility.BOTH, ExistsIn.BASE)] public UInt32 Destination;
        
    }
    
}
