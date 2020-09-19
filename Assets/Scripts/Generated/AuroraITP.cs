using System;
using System.Collections.Generic;
using static AuroraEngine.GFFObject;
using UnityEngine;
using AuroraEngine;

[Serializable]public class AuroraITP : AuroraStruct {
    // Field definitions
    [GFF("structid", Compatibility.BOTH, ExistsIn.BASE)] public uint structid;
    [GFF("NEXT_USEABLE_ID", Compatibility.BOTH, ExistsIn.BASE)] public Byte NEXT_USEABLE_ID;
    [GFF("RESTYPE", Compatibility.BOTH, ExistsIn.BASE)] public UInt16 RESTYPE;

    // List definitions
    [GFF("MAIN", Compatibility.BOTH, ExistsIn.BASE)] public List<AMAIN> MAIN = new List<AMAIN>();

    // Class definitions    
    [Serializable]public class AMAIN : AuroraStruct {
        // Field definitions
        [GFF("structid", Compatibility.BOTH, ExistsIn.BASE)] public uint structid;
        [GFF("ID", Compatibility.BOTH, ExistsIn.BASE)] public Byte ID;
        [GFF("DELETE_ME", Compatibility.BOTH, ExistsIn.BASE)] public CExoString DELETE_ME;
        [GFF("TYPE", Compatibility.BOTH, ExistsIn.BASE)] public Byte TYPE;
        [GFF("Type", Compatibility.BOTH, ExistsIn.BASE)] public Byte Type;
    
        // List definitions
        [GFF("LIST", Compatibility.BOTH, ExistsIn.BASE)] public List<ALIST> LIST = new List<ALIST>();
    
        // Class definitions    
        [Serializable]public class ALIST : AuroraStruct {
            // Field definitions
            [GFF("structid", Compatibility.BOTH, ExistsIn.BASE)] public uint structid;
            [GFF("ID", Compatibility.BOTH, ExistsIn.BASE)] public Byte ID;
            [GFF("DELETE_ME", Compatibility.BOTH, ExistsIn.BASE)] public CExoString DELETE_ME;
            [GFF("NAME", Compatibility.BOTH, ExistsIn.BASE)] public CExoString NAME;
            [GFF("RESREF", Compatibility.BOTH, ExistsIn.BASE)] public String RESREF;
            [GFF("CR", Compatibility.BOTH, ExistsIn.BASE)] public Single CR;
            [GFF("Type", Compatibility.BOTH, ExistsIn.BASE)] public Byte Type;
        
            // List definitions
            [GFF("LIST", Compatibility.BOTH, ExistsIn.BASE)] public List<ALIST1> LIST = new List<ALIST1>();
        
            // Class definitions    
            [Serializable]public class ALIST1 : AuroraStruct {
                // Field definitions
                [GFF("structid", Compatibility.BOTH, ExistsIn.BASE)] public uint structid;
                [GFF("NAME", Compatibility.BOTH, ExistsIn.BASE)] public CExoString NAME;
                [GFF("RESREF", Compatibility.BOTH, ExistsIn.BASE)] public String RESREF;
                [GFF("CR", Compatibility.BOTH, ExistsIn.BASE)] public Single CR;
                
            }
            
        }
        
    }
    
}
