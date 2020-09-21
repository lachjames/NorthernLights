using System;
using System.Collections.Generic;
using static AuroraEngine.GFFObject;
using UnityEngine;
using AuroraEngine;

[Serializable]public class AuroraSaveNfo : AuroraStruct {
    // Field definitions
    [GFF("structid", Compatibility.BOTH, ExistsIn.SAVE)] public uint structid;
    [GFF("AREANAME", Compatibility.BOTH, ExistsIn.SAVE)] public CExoString AREANAME;
    [GFF("LASTMODULE", Compatibility.BOTH, ExistsIn.SAVE)] public CExoString LASTMODULE;
    [GFF("TIMEPLAYED", Compatibility.BOTH, ExistsIn.SAVE)] public UInt32 TIMEPLAYED;
    [GFF("CHEATUSED", Compatibility.BOTH, ExistsIn.SAVE)] public Byte CHEATUSED;
    [GFF("SAVEGAMENAME", Compatibility.BOTH, ExistsIn.SAVE)] public CExoString SAVEGAMENAME;
    [GFF("GAMEPLAYHINT", Compatibility.BOTH, ExistsIn.SAVE)] public Byte GAMEPLAYHINT;
    [GFF("STORYHINT", Compatibility.KotOR, ExistsIn.SAVE)] public Byte STORYHINT;
    [GFF("LIVE1", Compatibility.BOTH, ExistsIn.SAVE)] public CExoString LIVE1;
    [GFF("LIVE2", Compatibility.BOTH, ExistsIn.SAVE)] public CExoString LIVE2;
    [GFF("LIVE3", Compatibility.BOTH, ExistsIn.SAVE)] public CExoString LIVE3;
    [GFF("LIVE4", Compatibility.BOTH, ExistsIn.SAVE)] public CExoString LIVE4;
    [GFF("LIVE5", Compatibility.BOTH, ExistsIn.SAVE)] public CExoString LIVE5;
    [GFF("LIVE6", Compatibility.BOTH, ExistsIn.SAVE)] public CExoString LIVE6;
    [GFF("LIVECONTENT", Compatibility.BOTH, ExistsIn.SAVE)] public Byte LIVECONTENT;
    [GFF("PORTRAIT0", Compatibility.BOTH, ExistsIn.SAVE)] public String PORTRAIT0;
    [GFF("PORTRAIT1", Compatibility.BOTH, ExistsIn.SAVE)] public String PORTRAIT1;
    [GFF("PORTRAIT2", Compatibility.BOTH, ExistsIn.SAVE)] public String PORTRAIT2;
    [GFF("TIMESTAMP", Compatibility.TSL, ExistsIn.SAVE)] public UInt64 TIMESTAMP;
    [GFF("PCNAME", Compatibility.TSL, ExistsIn.SAVE)] public CExoString PCNAME;
    [GFF("SAVENUMBER", Compatibility.TSL, ExistsIn.SAVE)] public UInt32 SAVENUMBER;
    [GFF("STORYHINT0", Compatibility.TSL, ExistsIn.SAVE)] public Byte STORYHINT0;
    [GFF("STORYHINT1", Compatibility.TSL, ExistsIn.SAVE)] public Byte STORYHINT1;
    [GFF("STORYHINT2", Compatibility.TSL, ExistsIn.SAVE)] public Byte STORYHINT2;
    [GFF("STORYHINT3", Compatibility.TSL, ExistsIn.SAVE)] public Byte STORYHINT3;
    [GFF("STORYHINT4", Compatibility.TSL, ExistsIn.SAVE)] public Byte STORYHINT4;
    [GFF("STORYHINT5", Compatibility.TSL, ExistsIn.SAVE)] public Byte STORYHINT5;
    [GFF("STORYHINT6", Compatibility.TSL, ExistsIn.SAVE)] public Byte STORYHINT6;
    [GFF("STORYHINT7", Compatibility.TSL, ExistsIn.SAVE)] public Byte STORYHINT7;
    [GFF("STORYHINT8", Compatibility.TSL, ExistsIn.SAVE)] public Byte STORYHINT8;
    [GFF("STORYHINT9", Compatibility.TSL, ExistsIn.SAVE)] public Byte STORYHINT9;
    [GFF("PCAUTOSAVE", Compatibility.TSL, ExistsIn.SAVE)] public Byte PCAUTOSAVE;
    [GFF("SCREENSHOT", Compatibility.TSL, ExistsIn.SAVE)] public CExoString SCREENSHOT;

    // Struct definitions
    [GFF("AUTOSAVEPARAMS", Compatibility.TSL, ExistsIn.SAVE)] public AAUTOSAVEPARAMS AUTOSAVEPARAMS = new AAUTOSAVEPARAMS();

    // Class definitions    
    [Serializable]public class AAUTOSAVEPARAMS : AuroraStruct {
        // Field definitions
        [GFF("structid", Compatibility.TSL, ExistsIn.SAVE)] public uint structid;
        [GFF("LOADMUSIC", Compatibility.TSL, ExistsIn.SAVE)] public CExoString LOADMUSIC;
        [GFF("STARTWAYPOINT", Compatibility.TSL, ExistsIn.SAVE)] public CExoString STARTWAYPOINT;
        [GFF("MOVIE1", Compatibility.TSL, ExistsIn.SAVE)] public CExoString MOVIE1;
        [GFF("MOVIE2", Compatibility.TSL, ExistsIn.SAVE)] public CExoString MOVIE2;
        [GFF("MOVIE3", Compatibility.TSL, ExistsIn.SAVE)] public CExoString MOVIE3;
        [GFF("MOVIE4", Compatibility.TSL, ExistsIn.SAVE)] public CExoString MOVIE4;
        [GFF("MOVIE5", Compatibility.TSL, ExistsIn.SAVE)] public CExoString MOVIE5;
        [GFF("MOVIE6", Compatibility.TSL, ExistsIn.SAVE)] public CExoString MOVIE6;
        [GFF("TIME_YEAR", Compatibility.TSL, ExistsIn.SAVE)] public UInt32 TIME_YEAR;
        [GFF("TIME_MONTH", Compatibility.TSL, ExistsIn.SAVE)] public Byte TIME_MONTH;
        [GFF("TIME_DAY", Compatibility.TSL, ExistsIn.SAVE)] public Byte TIME_DAY;
        [GFF("TIME_HOUR", Compatibility.TSL, ExistsIn.SAVE)] public Byte TIME_HOUR;
        [GFF("TIME_MINUTE", Compatibility.TSL, ExistsIn.SAVE)] public UInt16 TIME_MINUTE;
        [GFF("TIME_SECOND", Compatibility.TSL, ExistsIn.SAVE)] public UInt16 TIME_SECOND;
        [GFF("TIME_MILLISECOND", Compatibility.TSL, ExistsIn.SAVE)] public UInt16 TIME_MILLISECOND;
        [GFF("TIME_PAUSEDAY", Compatibility.TSL, ExistsIn.SAVE)] public UInt32 TIME_PAUSEDAY;
        [GFF("TIME_PAUSETIME", Compatibility.TSL, ExistsIn.SAVE)] public UInt32 TIME_PAUSETIME;
    
        // Struct definitions
        [GFF("STATUSSUMMARY", Compatibility.TSL, ExistsIn.SAVE)] public ASTATUSSUMMARY STATUSSUMMARY = new ASTATUSSUMMARY();
    
        // Class definitions    
        [Serializable]public class ASTATUSSUMMARY : AuroraStruct {
            // Field definitions
            [GFF("structid", Compatibility.TSL, ExistsIn.SAVE)] public uint structid;
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
        
    }
    
}
