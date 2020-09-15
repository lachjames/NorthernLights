using System;
using System.Collections.Generic;
using static AuroraEngine.GFFObject;
using UnityEngine;
using AuroraEngine;

[Serializable]public class AuroraPartyTable : AuroraStruct {
    // Field definitions
    [GFF("structid")] public uint structid;
    [GFF("PT_GOLD")] public UInt32 PT_GOLD;
    [GFF("PT_XP_POOL")] public Int32 PT_XP_POOL;
    [GFF("PT_PLAYEDSECONDS")] public UInt32 PT_PLAYEDSECONDS;
    [GFF("PT_CONTROLLED_NP")] public Int32 PT_CONTROLLED_NP;
    [GFF("PT_SOLOMODE")] public Byte PT_SOLOMODE;
    [GFF("PT_CHEAT_USED")] public Byte PT_CHEAT_USED;
    [GFF("PT_NUM_MEMBERS")] public Byte PT_NUM_MEMBERS;
    [GFF("PT_AISTATE")] public Int32 PT_AISTATE;
    [GFF("PT_FOLLOWSTATE")] public Int32 PT_FOLLOWSTATE;
    [GFF("PT_TUT_WND_SHOWN")] public Byte[] PT_TUT_WND_SHOWN;
    [GFF("PT_LAST_GUI_PNL")] public Int32 PT_LAST_GUI_PNL;
    [GFF("JNL_SortOrder")] public Int32 JNL_SortOrder;

    // Struct definitions
    [GFF("GlxyMap")] public AGlxyMap GlxyMap = new AGlxyMap();

    // List definitions
    [GFF("PT_AVAIL_NPCS")] public List<APT_AVAIL_NPCS> PT_AVAIL_NPCS = new List<APT_AVAIL_NPCS>();
    [GFF("PT_PAZAAKCARDS")] public List<APT_PAZAAKCARDS> PT_PAZAAKCARDS = new List<APT_PAZAAKCARDS>();
    [GFF("PT_PAZSIDELIST")] public List<APT_PAZSIDELIST> PT_PAZSIDELIST = new List<APT_PAZSIDELIST>();
    [GFF("PT_FB_MSG_LIST")] public List<APT_FB_MSG_LIST> PT_FB_MSG_LIST = new List<APT_FB_MSG_LIST>();
    [GFF("PT_DLG_MSG_LIST")] public List<APT_DLG_MSG_LIST> PT_DLG_MSG_LIST = new List<APT_DLG_MSG_LIST>();
    [GFF("PT_COST_MULT_LIS")] public List<APT_COST_MULT_LIS> PT_COST_MULT_LIS = new List<APT_COST_MULT_LIS>();
    [GFF("JNL_Entries")] public List<AJNL_Entries> JNL_Entries = new List<AJNL_Entries>();
    [GFF("PT_MEMBERS")] public List<APT_MEMBERS> PT_MEMBERS = new List<APT_MEMBERS>();

    // Class definitions    
    [Serializable]public class AGlxyMap : AuroraStruct {
        // Field definitions
        [GFF("structid")] public uint structid;
        [GFF("GlxyMapNumPnts")] public UInt32 GlxyMapNumPnts;
        [GFF("GlxyMapPlntMsk")] public UInt32 GlxyMapPlntMsk;
        [GFF("GlxyMapSelPnt")] public Int32 GlxyMapSelPnt;
        
    }
    
    [Serializable]public class APT_AVAIL_NPCS : AuroraStruct {
        // Field definitions
        [GFF("structid")] public uint structid;
        [GFF("PT_NPC_AVAIL")] public Byte PT_NPC_AVAIL;
        [GFF("PT_NPC_SELECT")] public Byte PT_NPC_SELECT;
        
    }
    
    [Serializable]public class APT_PAZAAKCARDS : AuroraStruct {
        // Field definitions
        [GFF("structid")] public uint structid;
        [GFF("PT_PAZAAKCOUNT")] public Int32 PT_PAZAAKCOUNT;
        
    }
    
    [Serializable]public class APT_PAZSIDELIST : AuroraStruct {
        // Field definitions
        [GFF("structid")] public uint structid;
        [GFF("PT_PAZSIDECARD")] public Int32 PT_PAZSIDECARD;
        
    }
    
    [Serializable]public class APT_FB_MSG_LIST : AuroraStruct {
        // Field definitions
        [GFF("structid")] public uint structid;
        [GFF("PT_FB_MSG_MSG")] public CExoString PT_FB_MSG_MSG;
        [GFF("PT_FB_MSG_TYPE")] public UInt32 PT_FB_MSG_TYPE;
        [GFF("PT_FB_MSG_COLOR")] public Byte PT_FB_MSG_COLOR;
        
    }
    
    [Serializable]public class APT_DLG_MSG_LIST : AuroraStruct {
        // Field definitions
        [GFF("structid")] public uint structid;
        [GFF("PT_DLG_MSG_SPKR")] public CExoString PT_DLG_MSG_SPKR;
        [GFF("PT_DLG_MSG_MSG")] public CExoString PT_DLG_MSG_MSG;
        
    }
    
    [Serializable]public class APT_COST_MULT_LIS : AuroraStruct {
        // Field definitions
        [GFF("structid")] public uint structid;
        [GFF("PT_COST_MULT_VAL")] public Single PT_COST_MULT_VAL;
        
    }
    
    [Serializable]public class AJNL_Entries : AuroraStruct {
        // Field definitions
        [GFF("structid")] public uint structid;
        [GFF("JNL_PlotID")] public CExoString JNL_PlotID;
        [GFF("JNL_State")] public Int32 JNL_State;
        [GFF("JNL_Date")] public UInt32 JNL_Date;
        [GFF("JNL_Time")] public UInt32 JNL_Time;
        
    }
    
    [Serializable]public class APT_MEMBERS : AuroraStruct {
        // Field definitions
        [GFF("structid")] public uint structid;
        [GFF("PT_MEMBER_ID")] public Int32 PT_MEMBER_ID;
        [GFF("PT_IS_LEADER")] public Byte PT_IS_LEADER;
        
    }
    
}
