using System;
using System.Collections.Generic;
using static AuroraEngine.GFFObject;
using UnityEngine;
using AuroraEngine;

[Serializable]public class AuroraUTS : AuroraStruct {
    // Field definitions
    [GFF("structid")] public uint structid;
    [GFF("Tag")] public CExoString Tag;
    [GFF("LocName")] public CExoLocString LocName;
    [GFF("TemplateResRef")] public String TemplateResRef;
    [GFF("Active")] public Byte Active;
    [GFF("Continuous")] public Byte Continuous;
    [GFF("Looping")] public Byte Looping;
    [GFF("Positional")] public Byte Positional;
    [GFF("RandomPosition")] public Byte RandomPosition;
    [GFF("Random")] public Byte Random;
    [GFF("Elevation")] public Single Elevation;
    [GFF("MaxDistance")] public Single MaxDistance;
    [GFF("MinDistance")] public Single MinDistance;
    [GFF("RandomRangeX")] public Single RandomRangeX;
    [GFF("RandomRangeY")] public Single RandomRangeY;
    [GFF("Interval")] public UInt32 Interval;
    [GFF("IntervalVrtn")] public UInt32 IntervalVrtn;
    [GFF("PitchVariation")] public Single PitchVariation;
    [GFF("Priority")] public Byte Priority;
    [GFF("Hours")] public UInt32 Hours;
    [GFF("Times")] public Byte Times;
    [GFF("Volume")] public Byte Volume;
    [GFF("VolumeVrtn")] public Byte VolumeVrtn;
    [GFF("PaletteID")] public Byte PaletteID;
    [GFF("Comment")] public CExoString Comment;

    // List definitions
    [GFF("Sounds")] public List<ASounds> Sounds = new List<ASounds>();

    // Class definitions    
    [Serializable]public class ASounds : AuroraStruct {
        // Field definitions
        [GFF("structid")] public uint structid;
        [GFF("Sound")] public String Sound;
        
    }
    
}
