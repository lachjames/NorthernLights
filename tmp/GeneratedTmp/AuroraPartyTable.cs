using System;
using System.Collections.Generic;
using static AuroraEngine.GFFObject;
using UnityEngine;

public class AuroraPartyTable : AuroraStruct {
    // Field definitions
    public uint structid;
    public UInt32 PT_GOLD;
    public Int32 PT_XP_POOL;
    public UInt32 PT_PLAYEDSECONDS;
    public Int32 PT_CONTROLLED_NP;
    public Byte PT_SOLOMODE;
    public Byte PT_CHEAT_USED;
    public Byte PT_NUM_MEMBERS;
    public Int32 PT_AISTATE;
    public Int32 PT_FOLLOWSTATE;
    public Byte[] PT_TUT_WND_SHOWN;
    public Int32 PT_LAST_GUI_PNL;
    public Int32 JNL_SortOrder;

    // Struct definitions
    public AGlxyMap GlxyMap;

    // List definitions
    public List<APT_AVAIL_NPCS> PT_AVAIL_NPCS;
    public List<APT_PAZAAKCARDS> PT_PAZAAKCARDS;
    public List<APT_PAZSIDELIST> PT_PAZSIDELIST;
    public List<APT_FB_MSG_LIST> PT_FB_MSG_LIST;
    public List<APT_DLG_MSG_LIST> PT_DLG_MSG_LIST;
    public List<APT_COST_MULT_LIS> PT_COST_MULT_LIS;
    public List<AJNL_Entries> JNL_Entries;
    public List<APT_MEMBERS> PT_MEMBERS;

    // Class definitions    
    public class AGlxyMap : AuroraStruct {
        // Field definitions
        public uint structid;
        public UInt32 GlxyMapNumPnts;
        public UInt32 GlxyMapPlntMsk;
        public Int32 GlxyMapSelPnt;
        
    }
    
    public class APT_AVAIL_NPCS : AuroraStruct {
        // Field definitions
        public uint structid;
        public Byte PT_NPC_AVAIL;
        public Byte PT_NPC_SELECT;
        
    }
    
    public class APT_PAZAAKCARDS : AuroraStruct {
        // Field definitions
        public uint structid;
        public Int32 PT_PAZAAKCOUNT;
        
    }
    
    public class APT_PAZSIDELIST : AuroraStruct {
        // Field definitions
        public uint structid;
        public Int32 PT_PAZSIDECARD;
        
    }
    
    public class APT_FB_MSG_LIST : AuroraStruct {
        // Field definitions
        public uint structid;
        public String PT_FB_MSG_MSG;
        public UInt32 PT_FB_MSG_TYPE;
        public Byte PT_FB_MSG_COLOR;
        
    }
    
    public class APT_DLG_MSG_LIST : AuroraStruct {
        // Field definitions
        public uint structid;
        public String PT_DLG_MSG_SPKR;
        public String PT_DLG_MSG_MSG;
        
    }
    
    public class APT_COST_MULT_LIS : AuroraStruct {
        // Field definitions
        public uint structid;
        public Single PT_COST_MULT_VAL;
        
    }
    
    public class AJNL_Entries : AuroraStruct {
        // Field definitions
        public uint structid;
        public String JNL_PlotID;
        public Int32 JNL_State;
        public UInt32 JNL_Date;
        public UInt32 JNL_Time;
        
    }
    
    public class APT_MEMBERS : AuroraStruct {
        // Field definitions
        public uint structid;
        public Int32 PT_MEMBER_ID;
        public Byte PT_IS_LEADER;
        
    }
    
}
