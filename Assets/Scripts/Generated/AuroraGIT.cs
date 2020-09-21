using System;
using System.Collections.Generic;
using static AuroraEngine.GFFObject;
using UnityEngine;
using AuroraEngine;

[Serializable]public class AuroraGIT : AuroraStruct {
    // Field definitions
    [GFF("structid", Compatibility.BOTH, ExistsIn.BASE)] public uint structid;
    [GFF("UseTemplates", Compatibility.BOTH, ExistsIn.BASE)] public Byte UseTemplates;
    [GFF("KTInfoVersion", Compatibility.TSL, ExistsIn.BASE)] public CExoString KTInfoVersion;
    [GFF("KTInfoDate", Compatibility.TSL, ExistsIn.BASE)] public CExoString KTInfoDate;
    [GFF("KTGameVerIndex", Compatibility.TSL, ExistsIn.BASE)] public Int32 KTGameVerIndex;

    // Struct definitions
    [GFF("AreaProperties", Compatibility.BOTH, ExistsIn.BASE)] public AAreaProperties AreaProperties = new AAreaProperties();
    //[GFF("", Compatibility.TSL, ExistsIn.BASE)] public A  = new A();

    // List definitions
    [GFF("Creature List", Compatibility.BOTH, ExistsIn.BASE)] public List<ACreature > CreatureList = new List<ACreature >();
    [GFF("Door List", Compatibility.BOTH, ExistsIn.BASE)] public List<ADoor > DoorList = new List<ADoor >();
    [GFF("SoundList", Compatibility.BOTH, ExistsIn.BASE)] public List<ASound> SoundList = new List<ASound>();
    [GFF("WaypointList", Compatibility.BOTH, ExistsIn.BASE)] public List<AWaypoint> WaypointList = new List<AWaypoint>();
    [GFF("Placeable List", Compatibility.BOTH, ExistsIn.BASE)] public List<APlaceable > PlaceableList = new List<APlaceable >();
    [GFF("Encounter List", Compatibility.BOTH, ExistsIn.BASE)] public List<AEncounter > EncounterList = new List<AEncounter >();
    [GFF("StoreList", Compatibility.BOTH, ExistsIn.BASE)] public List<AStore> StoreList = new List<AStore>();
    [GFF("TriggerList", Compatibility.BOTH, ExistsIn.BASE)] public List<ATrigger> TriggerList = new List<ATrigger>();
    [GFF("CameraList", Compatibility.BOTH, ExistsIn.BASE)] public List<ACamera> CameraList = new List<ACamera>();
    [GFF("List", Compatibility.KotOR, ExistsIn.BASE)] public List<AData> List = new List<AData>();

    // Class definitions    
    [Serializable]public class AAreaProperties : AuroraStruct {
        // Field definitions
        [GFF("structid", Compatibility.BOTH, ExistsIn.BASE)] public uint structid;
        [GFF("AmbientSndDay", Compatibility.BOTH, ExistsIn.BASE)] public Int32 AmbientSndDay;
        [GFF("AmbientSndNight", Compatibility.BOTH, ExistsIn.BASE)] public Int32 AmbientSndNight;
        [GFF("AmbientSndDayVol", Compatibility.BOTH, ExistsIn.BASE)] public Int32 AmbientSndDayVol;
        [GFF("AmbientSndNitVol", Compatibility.BOTH, ExistsIn.BASE)] public Int32 AmbientSndNitVol;
        [GFF("EnvAudio", Compatibility.BOTH, ExistsIn.BASE)] public Int32 EnvAudio;
        [GFF("MusicBattle", Compatibility.BOTH, ExistsIn.BASE)] public Int32 MusicBattle;
        [GFF("MusicDay", Compatibility.BOTH, ExistsIn.BASE)] public Int32 MusicDay;
        [GFF("MusicNight", Compatibility.BOTH, ExistsIn.BASE)] public Int32 MusicNight;
        [GFF("MusicDelay", Compatibility.BOTH, ExistsIn.BASE)] public Int32 MusicDelay;
        
    }
    
    [Serializable]public class A : AuroraStruct {
        // Field definitions
        [GFF("structid", Compatibility.TSL, ExistsIn.BASE)] public uint structid;
        [GFF("AmbientSndDay", Compatibility.TSL, ExistsIn.BASE)] public Int32 AmbientSndDay;
        [GFF("AmbientSndNight", Compatibility.TSL, ExistsIn.BASE)] public Int32 AmbientSndNight;
        [GFF("AmbientSndDayVol", Compatibility.TSL, ExistsIn.BASE)] public Int32 AmbientSndDayVol;
        [GFF("AmbientSndNitVol", Compatibility.TSL, ExistsIn.BASE)] public Int32 AmbientSndNitVol;
        [GFF("EnvAudio", Compatibility.TSL, ExistsIn.BASE)] public Int32 EnvAudio;
        [GFF("MusicBattle", Compatibility.TSL, ExistsIn.BASE)] public Int32 MusicBattle;
        [GFF("MusicDay", Compatibility.TSL, ExistsIn.BASE)] public Int32 MusicDay;
        [GFF("MusicNight", Compatibility.TSL, ExistsIn.BASE)] public Int32 MusicNight;
        [GFF("MusicDelay", Compatibility.TSL, ExistsIn.BASE)] public Int32 MusicDelay;
        
    }
    
    [Serializable]public class ACreature  : AuroraStruct {
        // Field definitions
        [GFF("structid", Compatibility.BOTH, ExistsIn.BASE)] public uint structid;
        [GFF("XPosition", Compatibility.BOTH, ExistsIn.BASE)] public Single XPosition;
        [GFF("YPosition", Compatibility.BOTH, ExistsIn.BASE)] public Single YPosition;
        [GFF("ZPosition", Compatibility.BOTH, ExistsIn.BASE)] public Single ZPosition;
        [GFF("XOrientation", Compatibility.BOTH, ExistsIn.BASE)] public Single XOrientation;
        [GFF("YOrientation", Compatibility.BOTH, ExistsIn.BASE)] public Single YOrientation;
        [GFF("TemplateResRef", Compatibility.BOTH, ExistsIn.BASE)] public String TemplateResRef;
        
    }
    
    [Serializable]public class ADoor  : AuroraStruct {
        // Field definitions
        [GFF("structid", Compatibility.BOTH, ExistsIn.BASE)] public uint structid;
        [GFF("TemplateResRef", Compatibility.BOTH, ExistsIn.BASE)] public String TemplateResRef;
        [GFF("LinkedToModule", Compatibility.BOTH, ExistsIn.BASE)] public String LinkedToModule;
        [GFF("LinkedToFlags", Compatibility.BOTH, ExistsIn.BASE)] public Byte LinkedToFlags;
        [GFF("X", Compatibility.BOTH, ExistsIn.BASE)] public Single X;
        [GFF("Y", Compatibility.BOTH, ExistsIn.BASE)] public Single Y;
        [GFF("Z", Compatibility.BOTH, ExistsIn.BASE)] public Single Z;
        [GFF("Bearing", Compatibility.BOTH, ExistsIn.BASE)] public Single Bearing;
        [GFF("UseTweakColor", Compatibility.BOTH, ExistsIn.BASE)] public Byte UseTweakColor;
        [GFF("Tag", Compatibility.BOTH, ExistsIn.BASE)] public CExoString Tag;
        [GFF("LinkedTo", Compatibility.BOTH, ExistsIn.BASE)] public CExoString LinkedTo;
        [GFF("TransitionDestin", Compatibility.BOTH, ExistsIn.BASE)] public CExoLocString TransitionDestin;
        [GFF("TweakColor", Compatibility.TSL, ExistsIn.BASE)] public UInt32 TweakColor;
        
    }
    
    [Serializable]public class ASound : AuroraStruct {
        // Field definitions
        [GFF("structid", Compatibility.BOTH, ExistsIn.BASE)] public uint structid;
        [GFF("TemplateResRef", Compatibility.BOTH, ExistsIn.BASE)] public String TemplateResRef;
        [GFF("XPosition", Compatibility.BOTH, ExistsIn.BASE)] public Single XPosition;
        [GFF("YPosition", Compatibility.BOTH, ExistsIn.BASE)] public Single YPosition;
        [GFF("ZPosition", Compatibility.BOTH, ExistsIn.BASE)] public Single ZPosition;
        [GFF("Appearance", Compatibility.BOTH, ExistsIn.BASE)] public Byte Appearance;
        [GFF("HasMapNote", Compatibility.BOTH, ExistsIn.BASE)] public Byte HasMapNote;
        [GFF("MapNoteEnabled", Compatibility.BOTH, ExistsIn.BASE)] public Byte MapNoteEnabled;
        [GFF("XOrientation", Compatibility.BOTH, ExistsIn.BASE)] public Single XOrientation;
        [GFF("YOrientation", Compatibility.BOTH, ExistsIn.BASE)] public Single YOrientation;
        [GFF("GeneratedType", Compatibility.BOTH, ExistsIn.BASE)] public UInt32 GeneratedType;
        [GFF("LinkedTo", Compatibility.TSL, ExistsIn.BASE)] public CExoString LinkedTo;
        [GFF("Tag", Compatibility.TSL, ExistsIn.BASE)] public CExoString Tag;
        [GFF("LocalizedName", Compatibility.TSL, ExistsIn.BASE)] public CExoLocString LocalizedName;
        [GFF("Description", Compatibility.TSL, ExistsIn.BASE)] public CExoLocString Description;
        [GFF("MapNote", Compatibility.TSL, ExistsIn.BASE)] public CExoLocString MapNote;
        
    }
    
    [Serializable]public class AWaypoint : AuroraStruct {
        // Field definitions
        [GFF("structid", Compatibility.BOTH, ExistsIn.BASE)] public uint structid;
        [GFF("Appearance", Compatibility.BOTH, ExistsIn.BASE)] public Byte Appearance;
        [GFF("TemplateResRef", Compatibility.BOTH, ExistsIn.BASE)] public String TemplateResRef;
        [GFF("HasMapNote", Compatibility.BOTH, ExistsIn.BASE)] public Byte HasMapNote;
        [GFF("MapNoteEnabled", Compatibility.BOTH, ExistsIn.BASE)] public Byte MapNoteEnabled;
        [GFF("XPosition", Compatibility.BOTH, ExistsIn.BASE)] public Single XPosition;
        [GFF("YPosition", Compatibility.BOTH, ExistsIn.BASE)] public Single YPosition;
        [GFF("ZPosition", Compatibility.BOTH, ExistsIn.BASE)] public Single ZPosition;
        [GFF("XOrientation", Compatibility.BOTH, ExistsIn.BASE)] public Single XOrientation;
        [GFF("YOrientation", Compatibility.BOTH, ExistsIn.BASE)] public Single YOrientation;
        [GFF("LinkedTo", Compatibility.BOTH, ExistsIn.BASE)] public CExoString LinkedTo;
        [GFF("Tag", Compatibility.BOTH, ExistsIn.BASE)] public CExoString Tag;
        [GFF("LocalizedName", Compatibility.BOTH, ExistsIn.BASE)] public CExoLocString LocalizedName;
        [GFF("Description", Compatibility.BOTH, ExistsIn.BASE)] public CExoLocString Description;
        [GFF("MapNote", Compatibility.BOTH, ExistsIn.BASE)] public CExoLocString MapNote;
        
    }
    
    [Serializable]public class APlaceable  : AuroraStruct {
        // Field definitions
        [GFF("structid", Compatibility.BOTH, ExistsIn.BASE)] public uint structid;
        [GFF("TemplateResRef", Compatibility.BOTH, ExistsIn.BASE)] public String TemplateResRef;
        [GFF("X", Compatibility.BOTH, ExistsIn.BASE)] public Single X;
        [GFF("Y", Compatibility.BOTH, ExistsIn.BASE)] public Single Y;
        [GFF("Z", Compatibility.BOTH, ExistsIn.BASE)] public Single Z;
        [GFF("Bearing", Compatibility.BOTH, ExistsIn.BASE)] public Single Bearing;
        [GFF("UseTweakColor", Compatibility.BOTH, ExistsIn.BASE)] public Byte UseTweakColor;
        [GFF("TweakColor", Compatibility.TSL, ExistsIn.BASE)] public UInt32 TweakColor;
        
    }
    
    [Serializable]public class AEncounter  : AuroraStruct {
        // Field definitions
        [GFF("structid", Compatibility.BOTH, ExistsIn.BASE)] public uint structid;
        [GFF("TemplateResRef", Compatibility.BOTH, ExistsIn.BASE)] public String TemplateResRef;
        [GFF("XPosition", Compatibility.BOTH, ExistsIn.BASE)] public Single XPosition;
        [GFF("YPosition", Compatibility.BOTH, ExistsIn.BASE)] public Single YPosition;
        [GFF("ZPosition", Compatibility.BOTH, ExistsIn.BASE)] public Single ZPosition;
    
        // List definitions
        [GFF("Geometry", Compatibility.BOTH, ExistsIn.BASE)] public List<AGeometry> Geometry = new List<AGeometry>();
        [GFF("SpawnPointList", Compatibility.BOTH, ExistsIn.BASE)] public List<ASpawnPoint> SpawnPointList = new List<ASpawnPoint>();
    
        // Class definitions    
        [Serializable]public class AGeometry : AuroraStruct {
            // Field definitions
            [GFF("structid", Compatibility.BOTH, ExistsIn.BASE)] public uint structid;
            [GFF("X", Compatibility.BOTH, ExistsIn.BASE)] public Single X;
            [GFF("Y", Compatibility.BOTH, ExistsIn.BASE)] public Single Y;
            [GFF("Z", Compatibility.BOTH, ExistsIn.BASE)] public Single Z;
            
        }
        
        [Serializable]public class ASpawnPoint : AuroraStruct {
            // Field definitions
            [GFF("structid", Compatibility.BOTH, ExistsIn.BASE)] public uint structid;
            [GFF("X", Compatibility.BOTH, ExistsIn.BASE)] public Single X;
            [GFF("Y", Compatibility.BOTH, ExistsIn.BASE)] public Single Y;
            [GFF("Z", Compatibility.BOTH, ExistsIn.BASE)] public Single Z;
            [GFF("Orientation", Compatibility.BOTH, ExistsIn.BASE)] public Single Orientation;
            
        }
        
    }
    
    [Serializable]public class AStore : AuroraStruct {
        // Field definitions
        [GFF("structid", Compatibility.BOTH, ExistsIn.BASE)] public uint structid;
        [GFF("XPosition", Compatibility.BOTH, ExistsIn.BASE)] public Single XPosition;
        [GFF("YPosition", Compatibility.BOTH, ExistsIn.BASE)] public Single YPosition;
        [GFF("ZPosition", Compatibility.BOTH, ExistsIn.BASE)] public Single ZPosition;
        [GFF("XOrientation", Compatibility.BOTH, ExistsIn.BASE)] public Single XOrientation;
        [GFF("YOrientation", Compatibility.BOTH, ExistsIn.BASE)] public Single YOrientation;
        [GFF("ResRef", Compatibility.BOTH, ExistsIn.BASE)] public String ResRef;
        
    }
    
    [Serializable]public class ATrigger : AuroraStruct {
        // Field definitions
        [GFF("structid", Compatibility.BOTH, ExistsIn.BASE)] public uint structid;
        [GFF("TemplateResRef", Compatibility.BOTH, ExistsIn.BASE)] public String TemplateResRef;
        [GFF("XPosition", Compatibility.BOTH, ExistsIn.BASE)] public Single XPosition;
        [GFF("YPosition", Compatibility.BOTH, ExistsIn.BASE)] public Single YPosition;
        [GFF("ZPosition", Compatibility.BOTH, ExistsIn.BASE)] public Single ZPosition;
        [GFF("XOrientation", Compatibility.BOTH, ExistsIn.BASE)] public Single XOrientation;
        [GFF("YOrientation", Compatibility.BOTH, ExistsIn.BASE)] public Single YOrientation;
        [GFF("ZOrientation", Compatibility.BOTH, ExistsIn.BASE)] public Single ZOrientation;
        [GFF("Tag", Compatibility.BOTH, ExistsIn.BASE)] public CExoString Tag;
        [GFF("TransitionDestin", Compatibility.BOTH, ExistsIn.BASE)] public CExoLocString TransitionDestin;
        [GFF("LinkedToModule", Compatibility.BOTH, ExistsIn.BASE)] public String LinkedToModule;
        [GFF("LinkedTo", Compatibility.BOTH, ExistsIn.BASE)] public CExoString LinkedTo;
        [GFF("LinkedToFlags", Compatibility.BOTH, ExistsIn.BASE)] public Byte LinkedToFlags;
    
        // List definitions
        [GFF("Geometry", Compatibility.BOTH, ExistsIn.BASE)] public List<AGeometry> Geometry = new List<AGeometry>();
    
        // Class definitions    
        [Serializable]public class AGeometry : AuroraStruct {
            // Field definitions
            [GFF("structid", Compatibility.BOTH, ExistsIn.BASE)] public uint structid;
            [GFF("PointX", Compatibility.BOTH, ExistsIn.BASE)] public Single PointX;
            [GFF("PointY", Compatibility.BOTH, ExistsIn.BASE)] public Single PointY;
            [GFF("PointZ", Compatibility.BOTH, ExistsIn.BASE)] public Single PointZ;
            
        }
        
    }
    
    [Serializable]public class ACamera : AuroraStruct {
        // Field definitions
        [GFF("structid", Compatibility.BOTH, ExistsIn.BASE)] public uint structid;
        [GFF("CameraID", Compatibility.BOTH, ExistsIn.BASE)] public Int32 CameraID;
        [GFF("Position", Compatibility.BOTH, ExistsIn.BASE)] public Vector3 Position;
        [GFF("Pitch", Compatibility.BOTH, ExistsIn.BASE)] public Single Pitch;
        [GFF("MicRange", Compatibility.BOTH, ExistsIn.BASE)] public Single MicRange;
        [GFF("Orientation", Compatibility.BOTH, ExistsIn.BASE)] public Quaternion Orientation;
        [GFF("Height", Compatibility.BOTH, ExistsIn.BASE)] public Single Height;
        [GFF("FieldOfView", Compatibility.BOTH, ExistsIn.BASE)] public Single FieldOfView;
        [GFF("EAOrientation", Compatibility.TSL, ExistsIn.BASE)] public Vector3 EAOrientation;
        
    }
    
    [Serializable]public class AData : AuroraStruct {
        // Field definitions
        [GFF("structid", Compatibility.KotOR, ExistsIn.BASE)] public uint structid;
        [GFF("XPosition", Compatibility.KotOR, ExistsIn.BASE)] public Single XPosition;
        [GFF("YPosition", Compatibility.KotOR, ExistsIn.BASE)] public Single YPosition;
        [GFF("ZPosition", Compatibility.KotOR, ExistsIn.BASE)] public Single ZPosition;
        [GFF("XOrientation", Compatibility.KotOR, ExistsIn.BASE)] public Single XOrientation;
        [GFF("YOrientation", Compatibility.KotOR, ExistsIn.BASE)] public Single YOrientation;
        [GFF("TemplateResRef", Compatibility.KotOR, ExistsIn.BASE)] public String TemplateResRef;
        
    }
    
}
