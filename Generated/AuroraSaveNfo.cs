using System;
using System.Collections.Generic;
using static AuroraEngine.GFFObject;
using UnityEngine;
using AuroraEngine;

[Serializable]public class AuroraSaveNfo : AuroraStruct {
    // Field definitions
    [GFF("structid")] public uint structid;
    [GFF("AREANAME")] public CExoString AREANAME;
    [GFF("LASTMODULE")] public CExoString LASTMODULE;
    [GFF("TIMEPLAYED")] public UInt32 TIMEPLAYED;
    [GFF("CHEATUSED")] public Byte CHEATUSED;
    [GFF("SAVEGAMENAME")] public CExoString SAVEGAMENAME;
    [GFF("GAMEPLAYHINT")] public Byte GAMEPLAYHINT;
    [GFF("STORYHINT")] public Byte STORYHINT;
    [GFF("LIVE1")] public CExoString LIVE1;
    [GFF("LIVE2")] public CExoString LIVE2;
    [GFF("LIVE3")] public CExoString LIVE3;
    [GFF("LIVE4")] public CExoString LIVE4;
    [GFF("LIVE5")] public CExoString LIVE5;
    [GFF("LIVE6")] public CExoString LIVE6;
    [GFF("LIVECONTENT")] public Byte LIVECONTENT;
    [GFF("PORTRAIT0")] public String PORTRAIT0;
    [GFF("PORTRAIT1")] public String PORTRAIT1;
    [GFF("PORTRAIT2")] public String PORTRAIT2;
    
}
