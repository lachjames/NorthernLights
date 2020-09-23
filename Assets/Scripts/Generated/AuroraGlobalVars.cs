using System;
using System.Collections.Generic;
using static AuroraEngine.GFFObject;
using UnityEngine;
using AuroraEngine;

[Serializable]public class AuroraGlobalVars : AuroraStruct {
    // Field definitions
    [GFF("structid", Compatibility.BOTH, ExistsIn.SAVE)] public uint structid;
    [GFF("ValBoolean", Compatibility.BOTH, ExistsIn.SAVE)] public Byte[] ValBoolean;
    [GFF("ValNumber", Compatibility.BOTH, ExistsIn.SAVE)] public Byte[] ValNumber;
    [GFF("ValLocation", Compatibility.BOTH, ExistsIn.SAVE)] public Byte[] ValLocation;

    // List definitions
    [GFF("CatBoolean", Compatibility.BOTH, ExistsIn.SAVE)] public List<ACatBoolean> CatBoolean = new List<ACatBoolean>();
    [GFF("CatNumber", Compatibility.BOTH, ExistsIn.SAVE)] public List<ACatNumber> CatNumber = new List<ACatNumber>();
    [GFF("CatLocation", Compatibility.BOTH, ExistsIn.SAVE)] public List<ACatLocation> CatLocation = new List<ACatLocation>();
    [GFF("CatString", Compatibility.BOTH, ExistsIn.SAVE)] public List<ACatString> CatString = new List<ACatString>();
    [GFF("ValString", Compatibility.BOTH, ExistsIn.SAVE)] public List<AValString> ValString = new List<AValString>();

    // Class definitions    
    [Serializable]public class ACatBoolean : AuroraStruct {
        // Field definitions
        [GFF("structid", Compatibility.BOTH, ExistsIn.SAVE)] public uint structid;
        [GFF("Name", Compatibility.BOTH, ExistsIn.SAVE)] public CExoString Name = new CExoString();
        
    }
    
    [Serializable]public class ACatNumber : AuroraStruct {
        // Field definitions
        [GFF("structid", Compatibility.BOTH, ExistsIn.SAVE)] public uint structid;
        [GFF("Name", Compatibility.BOTH, ExistsIn.SAVE)] public CExoString Name = new CExoString();
        
    }
    
    [Serializable]public class ACatLocation : AuroraStruct {
        // Field definitions
        [GFF("structid", Compatibility.BOTH, ExistsIn.SAVE)] public uint structid;
        [GFF("Name", Compatibility.BOTH, ExistsIn.SAVE)] public CExoString Name = new CExoString();
        
    }
    
    [Serializable]public class ACatString : AuroraStruct {
        // Field definitions
        [GFF("structid", Compatibility.BOTH, ExistsIn.SAVE)] public uint structid;
        [GFF("Name", Compatibility.BOTH, ExistsIn.SAVE)] public CExoString Name = new CExoString();
        
    }
    
    [Serializable]public class AValString : AuroraStruct {
        // Field definitions
        [GFF("structid", Compatibility.BOTH, ExistsIn.SAVE)] public uint structid;
        [GFF("String", Compatibility.BOTH, ExistsIn.SAVE)] public CExoString String = new CExoString();
        
    }
    
}
