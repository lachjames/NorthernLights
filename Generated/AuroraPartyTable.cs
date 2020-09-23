using System;
using System.Collections.Generic;
using static AuroraEngine.GFFObject;
using UnityEngine;
using AuroraEngine;

[Serializable]public class AuroraPartyTable : AuroraStruct {
    // Field definitions
    [GFF("structid", Compatibility.BOTH, ExistsIn.SAVE)] public uint structid;
    [GFF("PT_GOLD", Compatibility.BOTH, ExistsIn.SAVE)] public UInt32 PT_GOLD;
    [GFF("PT_XP_POOL", Compatibility.BOTH, ExistsIn.SAVE)] public Int32 PT_XP_POOL;
    [GFF("PT_PLAYEDSECONDS", Compatibility.BOTH, ExistsIn.SAVE)] public UInt32 PT_PLAYEDSECONDS;
    [GFF("PT_CONTROLLED_NP", Compatibility.BOTH, ExistsIn.SAVE)] public Int32 PT_CONTROLLED_NP;
    [GFF("PT_SOLOMODE", Compatibility.BOTH, ExistsIn.SAVE)] public Byte PT_SOLOMODE;
    [GFF("PT_CHEAT_USED", Compatibility.BOTH, ExistsIn.SAVE)] public Byte PT_CHEAT_USED;
    [GFF("PT_NUM_MEMBERS", Compatibility.BOTH, ExistsIn.SAVE)] public Byte PT_NUM_MEMBERS;
    [GFF("PT_AISTATE", Compatibility.BOTH, ExistsIn.SAVE)] public Int32 PT_AISTATE;
    [GFF("PT_FOLLOWSTATE", Compatibility.BOTH, ExistsIn.SAVE)] public Int32 PT_FOLLOWSTATE;
    [GFF("PT_TUT_WND_SHOWN", Compatibility.BOTH, ExistsIn.SAVE)] public Byte[] PT_TUT_WND_SHOWN;
    [GFF("PT_LAST_GUI_PNL", Compatibility.BOTH, ExistsIn.SAVE)] public Int32 PT_LAST_GUI_PNL;
    [GFF("JNL_SortOrder", Compatibility.BOTH, ExistsIn.SAVE)] public Int32 JNL_SortOrder;
    [GFF("PT_PCNAME", Compatibility.TSL, ExistsIn.SAVE)] public CExoString PT_PCNAME = new CExoString();
    [GFF("PT_ITEM_COMPONEN", Compatibility.TSL, ExistsIn.SAVE)] public UInt32 PT_ITEM_COMPONEN;
    [GFF("PT_ITEM_CHEMICAL", Compatibility.TSL, ExistsIn.SAVE)] public UInt32 PT_ITEM_CHEMICAL;
    [GFF("PT_SWOOP1", Compatibility.TSL, ExistsIn.SAVE)] public UInt32 PT_SWOOP1;
    [GFF("PT_SWOOP2", Compatibility.TSL, ExistsIn.SAVE)] public UInt32 PT_SWOOP2;
    [GFF("PT_SWOOP3", Compatibility.TSL, ExistsIn.SAVE)] public UInt32 PT_SWOOP3;
    [GFF("PT_NUM_PUPPETS", Compatibility.TSL, ExistsIn.SAVE)] public Byte PT_NUM_PUPPETS;

    // Struct definitions
    [GFF("GlxyMap", Compatibility.BOTH, ExistsIn.SAVE)] public AGlxyMap GlxyMap = new AGlxyMap();

    // List definitions
    [GFF("PT_AVAIL_NPCS", Compatibility.BOTH, ExistsIn.SAVE)] public List<APT_AVAIL_NPCS> PT_AVAIL_NPCS = new List<APT_AVAIL_NPCS>();
    [GFF("PT_PAZAAKCARDS", Compatibility.BOTH, ExistsIn.SAVE)] public List<APT_PAZAAKCARDS> PT_PAZAAKCARDS = new List<APT_PAZAAKCARDS>();
    [GFF("PT_PAZSIDELIST", Compatibility.BOTH, ExistsIn.SAVE)] public List<APT_PAZSIDELIST> PT_PAZSIDELIST = new List<APT_PAZSIDELIST>();
    [GFF("PT_FB_MSG_LIST", Compatibility.BOTH, ExistsIn.SAVE)] public List<APT_FB_MSG_LIST> PT_FB_MSG_LIST = new List<APT_FB_MSG_LIST>();
    [GFF("PT_DLG_MSG_LIST", Compatibility.BOTH, ExistsIn.SAVE)] public List<APT_DLG_MSG_LIST> PT_DLG_MSG_LIST = new List<APT_DLG_MSG_LIST>();
    [GFF("PT_COST_MULT_LIS", Compatibility.BOTH, ExistsIn.SAVE)] public List<APT_COST_MULT_LIS> PT_COST_MULT_LIS = new List<APT_COST_MULT_LIS>();
    [GFF("JNL_Entries", Compatibility.BOTH, ExistsIn.SAVE)] public List<AJNL_Entries> JNL_Entries = new List<AJNL_Entries>();
    [GFF("PT_MEMBERS", Compatibility.BOTH, ExistsIn.SAVE)] public List<APT_MEMBERS> PT_MEMBERS = new List<APT_MEMBERS>();
    [GFF("PT_AVAIL_PUPS", Compatibility.TSL, ExistsIn.SAVE)] public List<APT_AVAIL_PUPS> PT_AVAIL_PUPS = new List<APT_AVAIL_PUPS>();
    [GFF("PT_INFLUENCE", Compatibility.TSL, ExistsIn.SAVE)] public List<APT_INFLUENCE> PT_INFLUENCE = new List<APT_INFLUENCE>();
    [GFF("PT_COM_MSG_LIST", Compatibility.TSL, ExistsIn.SAVE)] public List<APT_COM_MSG_LIST> PT_COM_MSG_LIST = new List<APT_COM_MSG_LIST>();
    [GFF("PT_PUPPETS", Compatibility.TSL, ExistsIn.SAVE)] public List<APT_PUPPETS> PT_PUPPETS = new List<APT_PUPPETS>();

    // Class definitions    
    [Serializable]public class AGlxyMap : AuroraStruct {
        // Field definitions
        [GFF("structid", Compatibility.BOTH, ExistsIn.SAVE)] public uint structid;
        [GFF("GlxyMapNumPnts", Compatibility.BOTH, ExistsIn.SAVE)] public UInt32 GlxyMapNumPnts;
        [GFF("GlxyMapPlntMsk", Compatibility.BOTH, ExistsIn.SAVE)] public UInt32 GlxyMapPlntMsk;
        [GFF("GlxyMapSelPnt", Compatibility.BOTH, ExistsIn.SAVE)] public Int32 GlxyMapSelPnt;
        
    }
    
    [Serializable]public class APT_AVAIL_NPCS : AuroraStruct {
        // Field definitions
        [GFF("structid", Compatibility.BOTH, ExistsIn.SAVE)] public uint structid;
        [GFF("PT_NPC_AVAIL", Compatibility.BOTH, ExistsIn.SAVE)] public Byte PT_NPC_AVAIL;
        [GFF("PT_NPC_SELECT", Compatibility.BOTH, ExistsIn.SAVE)] public Byte PT_NPC_SELECT;
        
    }
    
    [Serializable]public class APT_PAZAAKCARDS : AuroraStruct {
        // Field definitions
        [GFF("structid", Compatibility.BOTH, ExistsIn.SAVE)] public uint structid;
        [GFF("PT_PAZAAKCOUNT", Compatibility.BOTH, ExistsIn.SAVE)] public Int32 PT_PAZAAKCOUNT;
        
    }
    
    [Serializable]public class APT_PAZSIDELIST : AuroraStruct {
        // Field definitions
        [GFF("structid", Compatibility.BOTH, ExistsIn.SAVE)] public uint structid;
        [GFF("PT_PAZSIDECARD", Compatibility.BOTH, ExistsIn.SAVE)] public Int32 PT_PAZSIDECARD;
        [GFF("FORFEITVIOL", Compatibility.TSL, ExistsIn.SAVE)] public Int32 FORFEITVIOL;
        [GFF("FORFEITCONDS", Compatibility.TSL, ExistsIn.SAVE)] public Int32 FORFEITCONDS;
        
    }
    
    [Serializable]public class APT_FB_MSG_LIST : AuroraStruct {
        // Field definitions
        [GFF("structid", Compatibility.BOTH, ExistsIn.SAVE)] public uint structid;
        [GFF("PT_FB_MSG_MSG", Compatibility.BOTH, ExistsIn.SAVE)] public CExoString PT_FB_MSG_MSG = new CExoString();
        [GFF("PT_FB_MSG_TYPE", Compatibility.BOTH, ExistsIn.SAVE)] public UInt32 PT_FB_MSG_TYPE;
        [GFF("PT_FB_MSG_COLOR", Compatibility.BOTH, ExistsIn.SAVE)] public Byte PT_FB_MSG_COLOR;
        
    }
    
    [Serializable]public class APT_DLG_MSG_LIST : AuroraStruct {
        // Field definitions
        [GFF("structid", Compatibility.BOTH, ExistsIn.SAVE)] public uint structid;
        [GFF("PT_DLG_MSG_SPKR", Compatibility.BOTH, ExistsIn.SAVE)] public CExoString PT_DLG_MSG_SPKR = new CExoString();
        [GFF("PT_DLG_MSG_MSG", Compatibility.BOTH, ExistsIn.SAVE)] public CExoString PT_DLG_MSG_MSG = new CExoString();
        
    }
    
    [Serializable]public class APT_COST_MULT_LIS : AuroraStruct {
        // Field definitions
        [GFF("structid", Compatibility.BOTH, ExistsIn.SAVE)] public uint structid;
        [GFF("PT_COST_MULT_VAL", Compatibility.BOTH, ExistsIn.SAVE)] public Single PT_COST_MULT_VAL;
        [GFF("PT_DISABLEMAP", Compatibility.TSL, ExistsIn.SAVE)] public Int32 PT_DISABLEMAP;
        [GFF("PT_DISABLEREGEN", Compatibility.TSL, ExistsIn.SAVE)] public Int32 PT_DISABLEREGEN;
        [GFF("DISPLAYSPENDING", Compatibility.TSL, ExistsIn.SAVE)] public Byte DISPLAYSPENDING;
        [GFF("ITEMRECEIVED", Compatibility.TSL, ExistsIn.SAVE)] public Byte ITEMRECEIVED;
        [GFF("ITEMLOST", Compatibility.TSL, ExistsIn.SAVE)] public Byte ITEMLOST;
        [GFF("JOURNAL", Compatibility.TSL, ExistsIn.SAVE)] public Byte JOURNAL;
        [GFF("LIGHTSHIFT", Compatibility.TSL, ExistsIn.SAVE)] public Byte LIGHTSHIFT;
        [GFF("DARKSHIFT", Compatibility.TSL, ExistsIn.SAVE)] public Byte DARKSHIFT;
        [GFF("CREDITS", Compatibility.TSL, ExistsIn.SAVE)] public Int32 CREDITS;
        [GFF("CREDITSNET", Compatibility.TSL, ExistsIn.SAVE)] public Byte CREDITSNET;
        [GFF("XP", Compatibility.TSL, ExistsIn.SAVE)] public Int32 XP;
        [GFF("STEALTHXP", Compatibility.TSL, ExistsIn.SAVE)] public Int32 STEALTHXP;
        [GFF("SOUNDPENDING", Compatibility.TSL, ExistsIn.SAVE)] public Byte SOUNDPENDING;
        [GFF("LEVELUPSOUND", Compatibility.TSL, ExistsIn.SAVE)] public Byte LEVELUPSOUND;
        [GFF("NEWQUESTSOUND", Compatibility.TSL, ExistsIn.SAVE)] public Byte NEWQUESTSOUND;
        [GFF("COMPLETESOUND", Compatibility.TSL, ExistsIn.SAVE)] public Byte COMPLETESOUND;
        [GFF("DARKALIGNSOUND", Compatibility.TSL, ExistsIn.SAVE)] public Byte DARKALIGNSOUND;
        [GFF("LIGHTALIGNSOUND", Compatibility.TSL, ExistsIn.SAVE)] public Byte LIGHTALIGNSOUND;
        [GFF("SUPPRESSED", Compatibility.TSL, ExistsIn.SAVE)] public Int32 SUPPRESSED;
        [GFF("INFGAIN", Compatibility.TSL, ExistsIn.SAVE)] public Int32 INFGAIN;
        [GFF("INFLOST", Compatibility.TSL, ExistsIn.SAVE)] public Int32 INFLOST;
        [GFF("MAXFPGAIN", Compatibility.TSL, ExistsIn.SAVE)] public Int32 MAXFPGAIN;
        [GFF("MAXFPLOST", Compatibility.TSL, ExistsIn.SAVE)] public Int32 MAXFPLOST;
        
    }
    
    [Serializable]public class AJNL_Entries : AuroraStruct {
        // Field definitions
        [GFF("structid", Compatibility.BOTH, ExistsIn.SAVE)] public uint structid;
        [GFF("JNL_PlotID", Compatibility.BOTH, ExistsIn.SAVE)] public CExoString JNL_PlotID = new CExoString();
        [GFF("JNL_State", Compatibility.BOTH, ExistsIn.SAVE)] public Int32 JNL_State;
        [GFF("JNL_Date", Compatibility.BOTH, ExistsIn.SAVE)] public UInt32 JNL_Date;
        [GFF("JNL_Time", Compatibility.BOTH, ExistsIn.SAVE)] public UInt32 JNL_Time;
        
    }
    
    [Serializable]public class APT_MEMBERS : AuroraStruct {
        // Field definitions
        [GFF("structid", Compatibility.BOTH, ExistsIn.SAVE)] public uint structid;
        [GFF("PT_MEMBER_ID", Compatibility.BOTH, ExistsIn.SAVE)] public Int32 PT_MEMBER_ID;
        [GFF("PT_IS_LEADER", Compatibility.BOTH, ExistsIn.SAVE)] public Byte PT_IS_LEADER;
        
    }
    
    [Serializable]public class APT_AVAIL_PUPS : AuroraStruct {
        // Field definitions
        [GFF("structid", Compatibility.TSL, ExistsIn.SAVE)] public uint structid;
        [GFF("PT_PUP_AVAIL", Compatibility.TSL, ExistsIn.SAVE)] public Byte PT_PUP_AVAIL;
        [GFF("PT_PUP_SELECT", Compatibility.TSL, ExistsIn.SAVE)] public Byte PT_PUP_SELECT;
        
    }
    
    [Serializable]public class APT_INFLUENCE : AuroraStruct {
        // Field definitions
        [GFF("structid", Compatibility.TSL, ExistsIn.SAVE)] public uint structid;
        [GFF("PT_NPC_INFLUENCE", Compatibility.TSL, ExistsIn.SAVE)] public Int32 PT_NPC_INFLUENCE;
        
    }
    
    [Serializable]public class APT_COM_MSG_LIST : AuroraStruct {
        // Field definitions
        [GFF("structid", Compatibility.TSL, ExistsIn.SAVE)] public uint structid;
        [GFF("PT_COM_MSG_MSG", Compatibility.TSL, ExistsIn.SAVE)] public CExoString PT_COM_MSG_MSG = new CExoString();
        [GFF("PT_COM_MSG_TYPE", Compatibility.TSL, ExistsIn.SAVE)] public UInt32 PT_COM_MSG_TYPE;
        [GFF("PT_COM_MSG_COOR", Compatibility.TSL, ExistsIn.SAVE)] public Byte PT_COM_MSG_COOR;
        
    }
    
    [Serializable]public class APT_PUPPETS : AuroraStruct {
        // Field definitions
        [GFF("structid", Compatibility.TSL, ExistsIn.SAVE)] public uint structid;
        [GFF("PT_PUPPET_ID", Compatibility.TSL, ExistsIn.SAVE)] public Int32 PT_PUPPET_ID;
        
    }
    
}
