using System;
using System.Collections.Generic;
using static AuroraEngine.GFFObject;
using UnityEngine;
using AuroraEngine;

[Serializable]public class AuroraUTS : AuroraStruct {
    // Field definitions
    [GFF("structid", Compatibility.BOTH, ExistsIn.BASE)] public uint structid;
    [GFF("Tag", Compatibility.BOTH, ExistsIn.BASE)] public CExoString Tag = new CExoString();
    [GFF("LocName", Compatibility.BOTH, ExistsIn.BASE)] public CExoLocString LocName = new CExoLocString();
    [GFF("TemplateResRef", Compatibility.BOTH, ExistsIn.BASE)] public String TemplateResRef;
    [GFF("Active", Compatibility.BOTH, ExistsIn.BASE)] public Byte Active;
    [GFF("Continuous", Compatibility.BOTH, ExistsIn.BASE)] public Byte Continuous;
    [GFF("Looping", Compatibility.BOTH, ExistsIn.BASE)] public Byte Looping;
    [GFF("Positional", Compatibility.BOTH, ExistsIn.BASE)] public Byte Positional;
    [GFF("RandomPosition", Compatibility.BOTH, ExistsIn.BASE)] public Byte RandomPosition;
    [GFF("Random", Compatibility.BOTH, ExistsIn.BASE)] public Byte Random;
    [GFF("Elevation", Compatibility.BOTH, ExistsIn.BASE)] public Single Elevation;
    [GFF("MaxDistance", Compatibility.BOTH, ExistsIn.BASE)] public Single MaxDistance;
    [GFF("MinDistance", Compatibility.BOTH, ExistsIn.BASE)] public Single MinDistance;
    [GFF("RandomRangeX", Compatibility.BOTH, ExistsIn.BASE)] public Single RandomRangeX;
    [GFF("RandomRangeY", Compatibility.BOTH, ExistsIn.BASE)] public Single RandomRangeY;
    [GFF("Interval", Compatibility.BOTH, ExistsIn.BASE)] public UInt32 Interval;
    [GFF("IntervalVrtn", Compatibility.BOTH, ExistsIn.BASE)] public UInt32 IntervalVrtn;
    [GFF("PitchVariation", Compatibility.BOTH, ExistsIn.BASE)] public Single PitchVariation;
    [GFF("Priority", Compatibility.BOTH, ExistsIn.BASE)] public Byte Priority;
    [GFF("Hours", Compatibility.BOTH, ExistsIn.BASE)] public UInt32 Hours;
    [GFF("Times", Compatibility.BOTH, ExistsIn.BASE)] public Byte Times;
    [GFF("Volume", Compatibility.BOTH, ExistsIn.BASE)] public Byte Volume;
    [GFF("VolumeVrtn", Compatibility.BOTH, ExistsIn.BASE)] public Byte VolumeVrtn;
    [GFF("PaletteID", Compatibility.BOTH, ExistsIn.BASE)] public Byte PaletteID;
    [GFF("Comment", Compatibility.BOTH, ExistsIn.BASE)] public CExoString Comment = new CExoString();
    [GFF("KTInfoVersion", Compatibility.TSL, ExistsIn.BASE)] public CExoString KTInfoVersion = new CExoString();
    [GFF("KTInfoDate", Compatibility.TSL, ExistsIn.BASE)] public CExoString KTInfoDate = new CExoString();
    [GFF("KTGameVerIndex", Compatibility.TSL, ExistsIn.BASE)] public Int32 KTGameVerIndex;

    // List definitions
    [GFF("Sounds", Compatibility.BOTH, ExistsIn.BASE)] public List<ASounds> Sounds = new List<ASounds>();

    // Class definitions    
    [Serializable]public class ASounds : AuroraStruct {
        // Field definitions
        [GFF("structid", Compatibility.BOTH, ExistsIn.BASE)] public uint structid;
        [GFF("Sound", Compatibility.BOTH, ExistsIn.BASE)] public String Sound;
        
    }
    
}
