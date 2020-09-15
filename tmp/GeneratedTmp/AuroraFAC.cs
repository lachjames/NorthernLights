using System;
using System.Collections.Generic;
using static AuroraEngine.GFFObject;
using UnityEngine;

public class AuroraFAC : AuroraStruct {
    // Field definitions
    public uint structid;

    // List definitions
    public List<AFaction> FactionList;
    public List<ARep> RepList;

    // Class definitions    
    public class AFaction : AuroraStruct {
        // Field definitions
        public uint structid;
        public UInt32 FactionParentID;
        public String FactionName;
        public UInt16 FactionGlobal;
        
    }
    
    public class ARep : AuroraStruct {
        // Field definitions
        public uint structid;
        public UInt32 FactionID1;
        public UInt32 FactionID2;
        public UInt32 FactionRep;
        
    }
    
}
