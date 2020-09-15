using System;
using System.Collections.Generic;
using static AuroraEngine.GFFObject;
using UnityEngine;
using AuroraEngine;

[Serializable]public class AuroraPTH : AuroraStruct {
    // Field definitions
    [GFF("structid")] public uint structid;

    // List definitions
    [GFF("Path_Points")] public List<APath_Points> Path_Points = new List<APath_Points>();
    [GFF("Path_Conections")] public List<APath_Conections> Path_Conections = new List<APath_Conections>();

    // Class definitions    
    [Serializable]public class APath_Points : AuroraStruct {
        // Field definitions
        [GFF("structid")] public uint structid;
        [GFF("Conections")] public UInt32 Conections;
        [GFF("First_Conection")] public UInt32 First_Conection;
        [GFF("X")] public Single X;
        [GFF("Y")] public Single Y;
        
    }
    
    [Serializable]public class APath_Conections : AuroraStruct {
        // Field definitions
        [GFF("structid")] public uint structid;
        [GFF("Destination")] public UInt32 Destination;
        
    }
    
}
