using System;
using System.Collections.Generic;
using static AuroraEngine.GFFObject;
using UnityEngine;

public class AuroraITP : AuroraStruct {
    // Field definitions
    public uint structid;
    public Byte NEXT_USEABLE_ID;
    public UInt16 RESTYPE;

    // List definitions
    public List<AMAIN> MAIN;

    // Class definitions    
    public class AMAIN : AuroraStruct {
        // Field definitions
        public uint structid;
        public Byte ID;
        public String DELETE_ME;
        public Byte TYPE;
        public Byte Type;
    
        // List definitions
        public List<ALIST> LIST;
    
        // Class definitions    
        public class ALIST : AuroraStruct {
            // Field definitions
            public uint structid;
            public Byte ID;
            public String DELETE_ME;
            public String NAME;
            public String RESREF;
            public Single CR;
            public Byte Type;
        
            // List definitions
            public List<ALIST> LIST;
        
            // Class definitions    
            public class ALIST : AuroraStruct {
                // Field definitions
                public uint structid;
                public String NAME;
                public String RESREF;
                public Single CR;
                
            }
            
        }
        
    }
    
}
