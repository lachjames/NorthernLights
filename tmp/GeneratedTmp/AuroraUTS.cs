using System;
using System.Collections.Generic;
using static AuroraEngine.GFFObject;
using UnityEngine;

public class AuroraUTS : AuroraStruct {
    // Field definitions
    public uint structid;
    public String Tag;
    public CExoLocString LocName;
    public String TemplateResRef;
    public Byte Active;
    public Byte Continuous;
    public Byte Looping;
    public Byte Positional;
    public Byte RandomPosition;
    public Byte Random;
    public Single Elevation;
    public Single MaxDistance;
    public Single MinDistance;
    public Single RandomRangeX;
    public Single RandomRangeY;
    public UInt32 Interval;
    public UInt32 IntervalVrtn;
    public Single PitchVariation;
    public Byte Priority;
    public UInt32 Hours;
    public Byte Times;
    public Byte Volume;
    public Byte VolumeVrtn;
    public Byte PaletteID;
    public String Comment;

    // List definitions
    public List<ASounds> Sounds;

    // Class definitions    
    public class ASounds : AuroraStruct {
        // Field definitions
        public uint structid;
        public String Sound;
        
    }
    
}
