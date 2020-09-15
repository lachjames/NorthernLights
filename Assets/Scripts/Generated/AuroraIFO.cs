using System;
using System.Collections.Generic;
using static AuroraEngine.GFFObject;
using UnityEngine;
using AuroraEngine;

[Serializable]public class AuroraIFO : AuroraStruct {
    // Field definitions
    [GFF("structid")] public uint structid;
    [GFF("Mod_ID")] public Byte[] Mod_ID;
    [GFF("Mod_Creator_ID")] public Int32 Mod_Creator_ID;
    [GFF("Mod_Version")] public UInt32 Mod_Version;
    [GFF("Mod_VO_ID")] public CExoString Mod_VO_ID;
    [GFF("Expansion_Pack")] public UInt16 Expansion_Pack;
    [GFF("Mod_Name")] public CExoLocString Mod_Name;
    [GFF("Mod_Tag")] public CExoString Mod_Tag;
    [GFF("Mod_Hak")] public CExoString Mod_Hak;
    [GFF("Mod_Description")] public CExoLocString Mod_Description;
    [GFF("Mod_IsSaveGame")] public Byte Mod_IsSaveGame;
    [GFF("Mod_Entry_Area")] public String Mod_Entry_Area;
    [GFF("Mod_Entry_X")] public Single Mod_Entry_X;
    [GFF("Mod_Entry_Y")] public Single Mod_Entry_Y;
    [GFF("Mod_Entry_Z")] public Single Mod_Entry_Z;
    [GFF("Mod_Entry_Dir_X")] public Single Mod_Entry_Dir_X;
    [GFF("Mod_Entry_Dir_Y")] public Single Mod_Entry_Dir_Y;
    [GFF("Mod_DawnHour")] public Byte Mod_DawnHour;
    [GFF("Mod_DuskHour")] public Byte Mod_DuskHour;
    [GFF("Mod_MinPerHour")] public Byte Mod_MinPerHour;
    [GFF("Mod_StartMonth")] public Byte Mod_StartMonth;
    [GFF("Mod_StartDay")] public Byte Mod_StartDay;
    [GFF("Mod_StartHour")] public Byte Mod_StartHour;
    [GFF("Mod_StartYear")] public UInt32 Mod_StartYear;
    [GFF("Mod_XPScale")] public Byte Mod_XPScale;
    [GFF("Mod_OnHeartbeat")] public String Mod_OnHeartbeat;
    [GFF("Mod_OnModLoad")] public String Mod_OnModLoad;
    [GFF("Mod_OnModStart")] public String Mod_OnModStart;
    [GFF("Mod_OnClientEntr")] public String Mod_OnClientEntr;
    [GFF("Mod_OnClientLeav")] public String Mod_OnClientLeav;
    [GFF("Mod_OnActvtItem")] public String Mod_OnActvtItem;
    [GFF("Mod_OnAcquirItem")] public String Mod_OnAcquirItem;
    [GFF("Mod_OnUsrDefined")] public String Mod_OnUsrDefined;
    [GFF("Mod_OnUnAqreItem")] public String Mod_OnUnAqreItem;
    [GFF("Mod_OnPlrDeath")] public String Mod_OnPlrDeath;
    [GFF("Mod_OnPlrDying")] public String Mod_OnPlrDying;
    [GFF("Mod_OnPlrLvlUp")] public String Mod_OnPlrLvlUp;
    [GFF("Mod_OnSpawnBtnDn")] public String Mod_OnSpawnBtnDn;
    [GFF("Mod_OnPlrRest")] public String Mod_OnPlrRest;
    [GFF("Mod_StartMovie")] public String Mod_StartMovie;

    // List definitions
    [GFF("Mod_Area_list")] public List<AMod_Area_list> Mod_Area_list = new List<AMod_Area_list>();

    // Class definitions    
    [Serializable]public class AMod_Area_list : AuroraStruct {
        // Field definitions
        [GFF("structid")] public uint structid;
        [GFF("Area_Name")] public String Area_Name;
        
    }
    
}
