using System;
using System.Collections.Generic;
using static AuroraEngine.GFFObject;
using UnityEngine;
using AuroraEngine;

[Serializable]public class AuroraGlobalVars : AuroraStruct {
    // Field definitions
    [GFF("structid")] public uint structid;
    [GFF("ValBoolean")] public Byte[] ValBoolean;
    [GFF("ValNumber")] public Byte[] ValNumber;
    [GFF("ValLocation")] public Byte[] ValLocation;

    // List definitions
    [GFF("CatBoolean")] public List<ACatBoolean> CatBoolean = new List<ACatBoolean>();
    [GFF("CatNumber")] public List<ACatNumber> CatNumber = new List<ACatNumber>();
    [GFF("CatLocation")] public List<ACatLocation> CatLocation = new List<ACatLocation>();
    [GFF("CatString")] public List<ACatString> CatString = new List<ACatString>();
    [GFF("ValString")] public List<AValString> ValString = new List<AValString>();

    // Class definitions    
    [Serializable]public class ACatBoolean : AuroraStruct {
        // Field definitions
        [GFF("structid")] public uint structid;
        [GFF("Name")] public CExoString Name;
        
    }
    
    [Serializable]public class ACatNumber : AuroraStruct {
        // Field definitions
        [GFF("structid")] public uint structid;
        [GFF("Name")] public CExoString Name;
        
    }
    
    [Serializable]public class ACatLocation : AuroraStruct {
        // Field definitions
        [GFF("structid")] public uint structid;
        [GFF("Name")] public CExoString Name;
        
    }
    
    [Serializable]public class ACatString : AuroraStruct {
        // Field definitions
        [GFF("structid")] public uint structid;
        [GFF("Name")] public CExoString Name;
        
    }
    
    [Serializable]public class AValString : AuroraStruct {
        // Field definitions
        [GFF("structid")] public uint structid;
        [GFF("String")] public CExoString String;
        
    }
    
}
