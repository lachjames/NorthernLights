using System;
using System.Collections.Generic;
using static AuroraEngine.GFFObject;
using UnityEngine;

public class AuroraUTM : AuroraStruct {
    // Field definitions
    public uint structid;
    public String ResRef;
    public CExoLocString LocName;
    public String Tag;
    public Int32 MarkUp;
    public Int32 MarkDown;
    public String OnOpenStore;
    public Byte BuySellFlag;
    public Byte ID;
    public String Comment;

    // List definitions
    public List<AItem> ItemList;

    // Class definitions    
    public class AItem : AuroraStruct {
        // Field definitions
        public uint structid;
        public String InventoryRes;
        public UInt16 Repos_PosX;
        public UInt16 Repos_Posy;
        public Byte Infinite;
        
    }
    
}
