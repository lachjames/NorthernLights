using System;
using System.Collections.Generic;
using static AuroraEngine.GFFObject;
using UnityEngine;
using AuroraEngine;

[Serializable]public class AuroraUTM : AuroraStruct {
    // Field definitions
    [GFF("structid", Compatibility.BOTH, ExistsIn.BASE)] public uint structid;
    [GFF("ResRef", Compatibility.BOTH, ExistsIn.BASE)] public String ResRef;
    [GFF("LocName", Compatibility.BOTH, ExistsIn.BASE)] public CExoLocString LocName;
    [GFF("Tag", Compatibility.BOTH, ExistsIn.BASE)] public CExoString Tag;
    [GFF("MarkUp", Compatibility.BOTH, ExistsIn.BASE)] public Int32 MarkUp;
    [GFF("MarkDown", Compatibility.BOTH, ExistsIn.BASE)] public Int32 MarkDown;
    [GFF("OnOpenStore", Compatibility.BOTH, ExistsIn.BASE)] public String OnOpenStore;
    [GFF("BuySellFlag", Compatibility.BOTH, ExistsIn.BASE)] public Byte BuySellFlag;
    [GFF("ID", Compatibility.BOTH, ExistsIn.BASE)] public Byte ID;
    [GFF("Comment", Compatibility.BOTH, ExistsIn.BASE)] public CExoString Comment;
    [GFF("KTInfoVersion", Compatibility.TSL, ExistsIn.BASE)] public CExoString KTInfoVersion;
    [GFF("KTInfoDate", Compatibility.TSL, ExistsIn.BASE)] public CExoString KTInfoDate;
    [GFF("KTGameVerIndex", Compatibility.TSL, ExistsIn.BASE)] public Int32 KTGameVerIndex;

    // List definitions
    [GFF("ItemList", Compatibility.BOTH, ExistsIn.BASE)] public List<AItem> ItemList = new List<AItem>();

    // Class definitions    
    [Serializable]public class AItem : AuroraStruct {
        // Field definitions
        [GFF("structid", Compatibility.BOTH, ExistsIn.BASE)] public uint structid;
        [GFF("InventoryRes", Compatibility.BOTH, ExistsIn.BASE)] public String InventoryRes;
        [GFF("Repos_PosX", Compatibility.BOTH, ExistsIn.BASE)] public UInt16 Repos_PosX;
        [GFF("Repos_Posy", Compatibility.BOTH, ExistsIn.BASE)] public UInt16 Repos_Posy;
        [GFF("Infinite", Compatibility.BOTH, ExistsIn.BASE)] public Byte Infinite;
        [GFF("Repos_PosY", Compatibility.TSL, ExistsIn.BASE)] public UInt16 Repos_PosY;
        [GFF("Dropable", Compatibility.TSL, ExistsIn.BASE)] public Byte Dropable;
        
    }
    
}
