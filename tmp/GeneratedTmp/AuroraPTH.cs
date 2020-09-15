using System;
using System.Collections.Generic;
using static AuroraEngine.GFFObject;
using UnityEngine;

public class AuroraPTH : AuroraStruct {
    // Field definitions
    public uint structid;

    // List definitions
    public List<APath_Points> Path_Points;
    public List<APath_Conections> Path_Conections;

    // Class definitions    
    public class APath_Points : AuroraStruct {
        // Field definitions
        public uint structid;
        public UInt32 Conections;
        public UInt32 First_Conection;
        public Single X;
        public Single Y;
        
    }
    
    public class APath_Conections : AuroraStruct {
        // Field definitions
        public uint structid;
        public UInt32 Destination;
        
    }
    
}
