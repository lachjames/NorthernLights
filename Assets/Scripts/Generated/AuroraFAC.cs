using System;
using System.Collections.Generic;
using static AuroraEngine.GFFObject;
using UnityEngine;
using AuroraEngine;

[Serializable]public class AuroraFAC : AuroraStruct {
    // Field definitions
    [GFF("structid", Compatibility.BOTH, ExistsIn.BOTH)] public uint structid;

    // List definitions
    [GFF("FactionList", Compatibility.BOTH, ExistsIn.BOTH)] public List<AFaction> FactionList = new List<AFaction>();
    [GFF("RepList", Compatibility.BOTH, ExistsIn.BOTH)] public List<ARep> RepList = new List<ARep>();

    // Class definitions    
    [Serializable]public class AFaction : AuroraStruct {
        // Field definitions
        [GFF("structid", Compatibility.BOTH, ExistsIn.BOTH)] public uint structid;
        [GFF("FactionParentID", Compatibility.BOTH, ExistsIn.BOTH)] public UInt32 FactionParentID;
        [GFF("FactionName", Compatibility.BOTH, ExistsIn.BOTH)] public CExoString FactionName = new CExoString();
        [GFF("FactionGlobal", Compatibility.BOTH, ExistsIn.BOTH)] public UInt16 FactionGlobal;
        
    }
    
    [Serializable]public class ARep : AuroraStruct {
        // Field definitions
        [GFF("structid", Compatibility.BOTH, ExistsIn.BOTH)] public uint structid;
        [GFF("FactionID1", Compatibility.BOTH, ExistsIn.BOTH)] public UInt32 FactionID1;
        [GFF("FactionID2", Compatibility.BOTH, ExistsIn.BOTH)] public UInt32 FactionID2;
        [GFF("FactionRep", Compatibility.BOTH, ExistsIn.BOTH)] public UInt32 FactionRep;
        
    }
    
}
