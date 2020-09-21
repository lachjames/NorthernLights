using System;
using System.Collections.Generic;
using static AuroraEngine.GFFObject;
using UnityEngine;
using AuroraEngine;

[Serializable]public class AuroraIFO : AuroraStruct {
    // Field definitions
    [GFF("structid", Compatibility.BOTH, ExistsIn.BASE)] public uint structid;
    [GFF("Mod_IsSaveGame", Compatibility.BOTH, ExistsIn.BASE)] public Byte Mod_IsSaveGame;
    [GFF("Mod_Entry_Area", Compatibility.BOTH, ExistsIn.BASE)] public String Mod_Entry_Area;
    [GFF("Mod_Entry_X", Compatibility.BOTH, ExistsIn.BASE)] public Single Mod_Entry_X;
    [GFF("Mod_Entry_Y", Compatibility.BOTH, ExistsIn.BASE)] public Single Mod_Entry_Y;
    [GFF("Mod_Entry_Z", Compatibility.BOTH, ExistsIn.BASE)] public Single Mod_Entry_Z;
    [GFF("Mod_Entry_Dir_X", Compatibility.BOTH, ExistsIn.BASE)] public Single Mod_Entry_Dir_X;
    [GFF("Mod_Entry_Dir_Y", Compatibility.BOTH, ExistsIn.BASE)] public Single Mod_Entry_Dir_Y;
    [GFF("Mod_DawnHour", Compatibility.BOTH, ExistsIn.BASE)] public Byte Mod_DawnHour;
    [GFF("Mod_DuskHour", Compatibility.BOTH, ExistsIn.BASE)] public Byte Mod_DuskHour;
    [GFF("Mod_MinPerHour", Compatibility.BOTH, ExistsIn.BASE)] public Byte Mod_MinPerHour;
    [GFF("Mod_StartMonth", Compatibility.BOTH, ExistsIn.BASE)] public Byte Mod_StartMonth;
    [GFF("Mod_StartDay", Compatibility.BOTH, ExistsIn.BASE)] public Byte Mod_StartDay;
    [GFF("Mod_StartHour", Compatibility.BOTH, ExistsIn.BASE)] public Byte Mod_StartHour;
    [GFF("Mod_XPScale", Compatibility.BOTH, ExistsIn.BASE)] public Byte Mod_XPScale;
    [GFF("Mod_OnHeartbeat", Compatibility.BOTH, ExistsIn.BASE)] public String Mod_OnHeartbeat;
    [GFF("Mod_OnModLoad", Compatibility.BOTH, ExistsIn.BASE)] public String Mod_OnModLoad;
    [GFF("Mod_OnModStart", Compatibility.BOTH, ExistsIn.BASE)] public String Mod_OnModStart;
    [GFF("Mod_OnClientEntr", Compatibility.BOTH, ExistsIn.BASE)] public String Mod_OnClientEntr;
    [GFF("Mod_OnClientLeav", Compatibility.BOTH, ExistsIn.BASE)] public String Mod_OnClientLeav;
    [GFF("Mod_OnActvtItem", Compatibility.BOTH, ExistsIn.BASE)] public String Mod_OnActvtItem;
    [GFF("Mod_OnAcquirItem", Compatibility.BOTH, ExistsIn.BASE)] public String Mod_OnAcquirItem;
    [GFF("Mod_OnUsrDefined", Compatibility.BOTH, ExistsIn.BASE)] public String Mod_OnUsrDefined;
    [GFF("Mod_OnUnAqreItem", Compatibility.BOTH, ExistsIn.BASE)] public String Mod_OnUnAqreItem;
    [GFF("Mod_OnPlrDeath", Compatibility.BOTH, ExistsIn.BASE)] public String Mod_OnPlrDeath;
    [GFF("Mod_OnPlrDying", Compatibility.BOTH, ExistsIn.BASE)] public String Mod_OnPlrDying;
    [GFF("Mod_OnPlrLvlUp", Compatibility.BOTH, ExistsIn.BASE)] public String Mod_OnPlrLvlUp;
    [GFF("Mod_OnSpawnBtnDn", Compatibility.BOTH, ExistsIn.BASE)] public String Mod_OnSpawnBtnDn;
    [GFF("Mod_OnPlrRest", Compatibility.BOTH, ExistsIn.BASE)] public String Mod_OnPlrRest;
    [GFF("Mod_StartMovie", Compatibility.BOTH, ExistsIn.BASE)] public String Mod_StartMovie;
    [GFF("Mod_ID", Compatibility.BOTH, ExistsIn.BASE)] public Byte[] Mod_ID;
    [GFF("Mod_Creator_ID", Compatibility.BOTH, ExistsIn.BASE)] public Int32 Mod_Creator_ID;
    [GFF("Mod_Version", Compatibility.BOTH, ExistsIn.BASE)] public UInt32 Mod_Version;
    [GFF("Mod_VO_ID", Compatibility.BOTH, ExistsIn.BASE)] public CExoString Mod_VO_ID;
    [GFF("Expansion_Pack", Compatibility.BOTH, ExistsIn.BASE)] public UInt16 Expansion_Pack;
    [GFF("Mod_Name", Compatibility.BOTH, ExistsIn.BASE)] public CExoLocString Mod_Name;
    [GFF("Mod_Tag", Compatibility.BOTH, ExistsIn.BASE)] public CExoString Mod_Tag;
    [GFF("Mod_Hak", Compatibility.BOTH, ExistsIn.BASE)] public CExoString Mod_Hak;
    [GFF("Mod_Description", Compatibility.BOTH, ExistsIn.BASE)] public CExoLocString Mod_Description;
    [GFF("Mod_StartYear", Compatibility.BOTH, ExistsIn.BASE)] public UInt32 Mod_StartYear;
    [GFF("KTInfoVersion", Compatibility.TSL, ExistsIn.BASE)] public CExoString KTInfoVersion;
    [GFF("KTInfoDate", Compatibility.TSL, ExistsIn.BASE)] public CExoString KTInfoDate;
    [GFF("KTGameVerIndex", Compatibility.TSL, ExistsIn.BASE)] public Int32 KTGameVerIndex;

    // List definitions
    [GFF("Mod_Area_list", Compatibility.BOTH, ExistsIn.BASE)] public List<AMod_Area_list> Mod_Area_list = new List<AMod_Area_list>();

    // Class definitions    
    [Serializable]public class AMod_Area_list : AuroraStruct {
        // Field definitions
        [GFF("structid", Compatibility.BOTH, ExistsIn.BASE)] public uint structid;
        [GFF("Area_Name", Compatibility.BOTH, ExistsIn.BASE)] public String Area_Name;
        
    }
    
}
