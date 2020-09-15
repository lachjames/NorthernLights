using System;
using System.Collections.Generic;
using static AuroraEngine.GFFObject;
using UnityEngine;

public class AuroraIFO : AuroraStruct {
    // Field definitions
    public uint structid;
    public Byte[] Mod_ID;
    public Int32 Mod_Creator_ID;
    public UInt32 Mod_Version;
    public String Mod_VO_ID;
    public UInt16 Expansion_Pack;
    public CExoLocString Mod_Name;
    public String Mod_Tag;
    public String Mod_Hak;
    public CExoLocString Mod_Description;
    public Byte Mod_IsSaveGame;
    public String Mod_Entry_Area;
    public Single Mod_Entry_X;
    public Single Mod_Entry_Y;
    public Single Mod_Entry_Z;
    public Single Mod_Entry_Dir_X;
    public Single Mod_Entry_Dir_Y;
    public Byte Mod_DawnHour;
    public Byte Mod_DuskHour;
    public Byte Mod_MinPerHour;
    public Byte Mod_StartMonth;
    public Byte Mod_StartDay;
    public Byte Mod_StartHour;
    public UInt32 Mod_StartYear;
    public Byte Mod_XPScale;
    public String Mod_OnHeartbeat;
    public String Mod_OnModLoad;
    public String Mod_OnModStart;
    public String Mod_OnClientEntr;
    public String Mod_OnClientLeav;
    public String Mod_OnActvtItem;
    public String Mod_OnAcquirItem;
    public String Mod_OnUsrDefined;
    public String Mod_OnUnAqreItem;
    public String Mod_OnPlrDeath;
    public String Mod_OnPlrDying;
    public String Mod_OnPlrLvlUp;
    public String Mod_OnSpawnBtnDn;
    public String Mod_OnPlrRest;
    public String Mod_StartMovie;

    // List definitions
    public List<AMod_Area_list> Mod_Area_list;

    // Class definitions    
    public class AMod_Area_list : AuroraStruct {
        // Field definitions
        public uint structid;
        public String Area_Name;
        
    }
    
}
