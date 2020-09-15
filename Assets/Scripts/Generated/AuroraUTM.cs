using System;
using System.Collections.Generic;
using static AuroraEngine.GFFObject;
using UnityEngine;
using AuroraEngine;

[Serializable]public class AuroraUTM : AuroraStruct {
    // Field definitions
    [GFF("structid")] public uint structid;
    [GFF("ResRef")] public String ResRef;
    [GFF("LocName")] public CExoLocString LocName;
    [GFF("Tag")] public CExoString Tag;
    [GFF("MarkUp")] public Int32 MarkUp;
    [GFF("MarkDown")] public Int32 MarkDown;
    [GFF("OnOpenStore")] public String OnOpenStore;
    [GFF("BuySellFlag")] public Byte BuySellFlag;
    [GFF("ID")] public Byte ID;
    [GFF("Comment")] public CExoString Comment;

    // List definitions
    [GFF("ItemList")] public List<AItem> ItemList = new List<AItem>();

    // Class definitions    
    [Serializable]public class AItem : AuroraStruct {
        // Field definitions
        [GFF("structid")] public uint structid;
        [GFF("InventoryRes")] public String InventoryRes;
        [GFF("Repos_PosX")] public UInt16 Repos_PosX;
        [GFF("Repos_Posy")] public UInt16 Repos_Posy;
        [GFF("Infinite")] public Byte Infinite;
        
    }
    
}
