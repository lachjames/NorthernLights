using System;
using System.Collections.Generic;
using static AuroraEngine.GFFObject;
using UnityEngine;
using AuroraEngine;

[Serializable]public class AuroraITP : AuroraStruct {
    // Field definitions
    [GFF("structid")] public uint structid;
    [GFF("NEXT_USEABLE_ID")] public Byte NEXT_USEABLE_ID;
    [GFF("RESTYPE")] public UInt16 RESTYPE;

    // List definitions
    [GFF("MAIN")] public List<AMAIN> MAIN = new List<AMAIN>();

    // Class definitions    
    [Serializable]public class AMAIN : AuroraStruct {
        // Field definitions
        [GFF("structid")] public uint structid;
        [GFF("ID")] public Byte ID;
        [GFF("DELETE_ME")] public CExoString DELETE_ME;
        [GFF("TYPE")] public Byte TYPE;
        [GFF("Type")] public Byte Type;
    
        // List definitions
        [GFF("LIST")] public List<ALIST> LIST = new List<ALIST>();
    
        // Class definitions    
        [Serializable]public class ALIST : AuroraStruct {
            // Field definitions
            [GFF("structid")] public uint structid;
            [GFF("ID")] public Byte ID;
            [GFF("DELETE_ME")] public CExoString DELETE_ME;
            [GFF("NAME")] public CExoString NAME;
            [GFF("RESREF")] public String RESREF;
            [GFF("CR")] public Single CR;
            [GFF("Type")] public Byte Type;
        
            // List definitions
            [GFF("LIST")] public List<ALIST> LIST = new List<ALIST>();
        
            // Class definitions    
            [Serializable]public class ALIST : AuroraStruct {
                // Field definitions
                [GFF("structid")] public uint structid;
                [GFF("NAME")] public CExoString NAME;
                [GFF("RESREF")] public String RESREF;
                [GFF("CR")] public Single CR;
                
            }
            
        }
        
    }
    
}
