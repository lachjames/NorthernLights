using System;
using System.Collections.Generic;
using static AuroraEngine.GFFObject;
using UnityEngine;

public class AuroraGlobalVars : AuroraStruct {
    // Field definitions
    public uint structid;
    public Byte[] ValBoolean;
    public Byte[] ValNumber;
    public Byte[] ValLocation;

    // List definitions
    public List<ACatBoolean> CatBoolean;
    public List<ACatNumber> CatNumber;
    public List<ACatLocation> CatLocation;
    public List<ACatString> CatString;
    public List<AValString> ValString;

    // Class definitions    
    public class ACatBoolean : AuroraStruct {
        // Field definitions
        public uint structid;
        public String Name;
        
    }
    
    public class ACatNumber : AuroraStruct {
        // Field definitions
        public uint structid;
        public String Name;
        
    }
    
    public class ACatLocation : AuroraStruct {
        // Field definitions
        public uint structid;
        public String Name;
        
    }
    
    public class ACatString : AuroraStruct {
        // Field definitions
        public uint structid;
        public String Name;
        
    }
    
    public class AValString : AuroraStruct {
        // Field definitions
        public uint structid;
        public String String;
        
    }
    
}
