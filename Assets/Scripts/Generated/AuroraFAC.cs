using System;
using System.Collections.Generic;
using static AuroraEngine.GFFObject;
using UnityEngine;
using AuroraEngine;

[Serializable]public class AuroraFAC : AuroraStruct {
    // Field definitions
    [GFF("structid")] public uint structid;

    // List definitions
    [GFF("FactionList")] public List<AFaction> FactionList = new List<AFaction>();
    [GFF("RepList")] public List<ARep> RepList = new List<ARep>();

    // Class definitions    
    [Serializable]public class AFaction : AuroraStruct {
        // Field definitions
        [GFF("structid")] public uint structid;
        [GFF("FactionParentID")] public UInt32 FactionParentID;
        [GFF("FactionName")] public CExoString FactionName;
        [GFF("FactionGlobal")] public UInt16 FactionGlobal;
        
    }
    
    [Serializable]public class ARep : AuroraStruct {
        // Field definitions
        [GFF("structid")] public uint structid;
        [GFF("FactionID1")] public UInt32 FactionID1;
        [GFF("FactionID2")] public UInt32 FactionID2;
        [GFF("FactionRep")] public UInt32 FactionRep;
        
    }
    
}
