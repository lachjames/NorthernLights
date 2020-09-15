using System;
using System.Collections.Generic;
using static AuroraEngine.GFFObject;
using UnityEngine;
using AuroraEngine;

[Serializable]public class AuroraGIT : AuroraStruct {
    // Field definitions
    [GFF("structid")] public uint structid;
    [GFF("UseTemplates")] public Byte UseTemplates;

    // Struct definitions
    [GFF("AreaProperties")] public AAreaProperties AreaProperties = new AAreaProperties();

    // List definitions
    [GFF("Creature List")] public List<ACreature > CreatureList = new List<ACreature >();
    [GFF("Door List")] public List<ADoor > DoorList = new List<ADoor >();
    [GFF("Encounter List")] public List<AEncounter > EncounterList = new List<AEncounter >();
    [GFF("SoundList")] public List<ASound> SoundList = new List<ASound>();
    [GFF("StoreList")] public List<AStore> StoreList = new List<AStore>();
    [GFF("TriggerList")] public List<ATrigger> TriggerList = new List<ATrigger>();
    [GFF("WaypointList")] public List<AWaypoint> WaypointList = new List<AWaypoint>();
    [GFF("Placeable List")] public List<APlaceable > PlaceableList = new List<APlaceable >();
    [GFF("CameraList")] public List<ACamera> CameraList = new List<ACamera>();
    [GFF("List")] public List<AData> List = new List<AData>();

    // Class definitions    
    [Serializable]public class AAreaProperties : AuroraStruct {
        // Field definitions
        [GFF("structid")] public uint structid;
        [GFF("AmbientSndDay")] public Int32 AmbientSndDay;
        [GFF("AmbientSndNight")] public Int32 AmbientSndNight;
        [GFF("AmbientSndDayVol")] public Int32 AmbientSndDayVol;
        [GFF("AmbientSndNitVol")] public Int32 AmbientSndNitVol;
        [GFF("EnvAudio")] public Int32 EnvAudio;
        [GFF("MusicBattle")] public Int32 MusicBattle;
        [GFF("MusicDay")] public Int32 MusicDay;
        [GFF("MusicNight")] public Int32 MusicNight;
        [GFF("MusicDelay")] public Int32 MusicDelay;
        
    }
    
    [Serializable]public class ACreature  : AuroraStruct {
        // Field definitions
        [GFF("structid")] public uint structid;
        [GFF("XPosition")] public Single XPosition;
        [GFF("YPosition")] public Single YPosition;
        [GFF("ZPosition")] public Single ZPosition;
        [GFF("XOrientation")] public Single XOrientation;
        [GFF("YOrientation")] public Single YOrientation;
        [GFF("TemplateResRef")] public String TemplateResRef;
        
    }
    
    [Serializable]public class ADoor  : AuroraStruct {
        // Field definitions
        [GFF("structid")] public uint structid;
        [GFF("TemplateResRef")] public String TemplateResRef;
        [GFF("Tag")] public CExoString Tag;
        [GFF("LinkedToModule")] public String LinkedToModule;
        [GFF("LinkedTo")] public CExoString LinkedTo;
        [GFF("LinkedToFlags")] public Byte LinkedToFlags;
        [GFF("TransitionDestin")] public CExoLocString TransitionDestin;
        [GFF("X")] public Single X;
        [GFF("Y")] public Single Y;
        [GFF("Z")] public Single Z;
        [GFF("Bearing")] public Single Bearing;
        
    }
    
    [Serializable]public class AEncounter  : AuroraStruct {
        // Field definitions
        [GFF("structid")] public uint structid;
        [GFF("TemplateResRef")] public String TemplateResRef;
        [GFF("XPosition")] public Single XPosition;
        [GFF("YPosition")] public Single YPosition;
        [GFF("ZPosition")] public Single ZPosition;
    
        // List definitions
        [GFF("Geometry")] public List<AGeometry> Geometry = new List<AGeometry>();
        [GFF("SpawnPointList")] public List<ASpawnPoint> SpawnPointList = new List<ASpawnPoint>();
    
        // Class definitions    
        [Serializable]public class AGeometry : AuroraStruct {
            // Field definitions
            [GFF("structid")] public uint structid;
            [GFF("X")] public Single X;
            [GFF("Y")] public Single Y;
            [GFF("Z")] public Single Z;
            
        }
        
        [Serializable]public class ASpawnPoint : AuroraStruct {
            // Field definitions
            [GFF("structid")] public uint structid;
            [GFF("X")] public Single X;
            [GFF("Y")] public Single Y;
            [GFF("Z")] public Single Z;
            [GFF("Orientation")] public Single Orientation;
            
        }
        
    }
    
    [Serializable]public class ASound : AuroraStruct {
        // Field definitions
        [GFF("structid")] public uint structid;
        [GFF("TemplateResRef")] public String TemplateResRef;
        [GFF("GeneratedType")] public UInt32 GeneratedType;
        [GFF("XPosition")] public Single XPosition;
        [GFF("YPosition")] public Single YPosition;
        [GFF("ZPosition")] public Single ZPosition;
        
    }
    
    [Serializable]public class AStore : AuroraStruct {
        // Field definitions
        [GFF("structid")] public uint structid;
        [GFF("XPosition")] public Single XPosition;
        [GFF("YPosition")] public Single YPosition;
        [GFF("ZPosition")] public Single ZPosition;
        [GFF("XOrientation")] public Single XOrientation;
        [GFF("YOrientation")] public Single YOrientation;
        [GFF("ResRef")] public String ResRef;
        
    }
    
    [Serializable]public class ATrigger : AuroraStruct {
        // Field definitions
        [GFF("structid")] public uint structid;
        [GFF("TemplateResRef")] public String TemplateResRef;
        [GFF("XPosition")] public Single XPosition;
        [GFF("YPosition")] public Single YPosition;
        [GFF("ZPosition")] public Single ZPosition;
        [GFF("XOrientation")] public Single XOrientation;
        [GFF("YOrientation")] public Single YOrientation;
        [GFF("ZOrientation")] public Single ZOrientation;
        [GFF("Tag")] public CExoString Tag;
        [GFF("TransitionDestin")] public CExoLocString TransitionDestin;
        [GFF("LinkedToModule")] public String LinkedToModule;
        [GFF("LinkedTo")] public CExoString LinkedTo;
        [GFF("LinkedToFlags")] public Byte LinkedToFlags;
    
        // List definitions
        [GFF("Geometry")] public List<AGeometry> Geometry = new List<AGeometry>();
    
        // Class definitions    
        [Serializable]public class AGeometry : AuroraStruct {
            // Field definitions
            [GFF("structid")] public uint structid;
            [GFF("PointX")] public Single PointX;
            [GFF("PointY")] public Single PointY;
            [GFF("PointZ")] public Single PointZ;
            
        }
        
    }
    
    [Serializable]public class AWaypoint : AuroraStruct {
        // Field definitions
        [GFF("structid")] public uint structid;
        [GFF("Appearance")] public Byte Appearance;
        [GFF("LinkedTo")] public CExoString LinkedTo;
        [GFF("TemplateResRef")] public String TemplateResRef;
        [GFF("Tag")] public CExoString Tag;
        [GFF("LocalizedName")] public CExoLocString LocalizedName;
        [GFF("Description")] public CExoLocString Description;
        [GFF("HasMapNote")] public Byte HasMapNote;
        [GFF("MapNote")] public CExoLocString MapNote;
        [GFF("MapNoteEnabled")] public Byte MapNoteEnabled;
        [GFF("XPosition")] public Single XPosition;
        [GFF("YPosition")] public Single YPosition;
        [GFF("ZPosition")] public Single ZPosition;
        [GFF("XOrientation")] public Single XOrientation;
        [GFF("YOrientation")] public Single YOrientation;
        
    }
    
    [Serializable]public class APlaceable  : AuroraStruct {
        // Field definitions
        [GFF("structid")] public uint structid;
        [GFF("TemplateResRef")] public String TemplateResRef;
        [GFF("X")] public Single X;
        [GFF("Y")] public Single Y;
        [GFF("Z")] public Single Z;
        [GFF("Bearing")] public Single Bearing;
        
    }
    
    [Serializable]public class ACamera : AuroraStruct {
        // Field definitions
        [GFF("structid")] public uint structid;
        [GFF("CameraID")] public Int32 CameraID;
        [GFF("Position")] public Vector3 Position;
        [GFF("Pitch")] public Single Pitch;
        [GFF("MicRange")] public Single MicRange;
        [GFF("Orientation")] public Quaternion Orientation;
        [GFF("Height")] public Single Height;
        [GFF("FieldOfView")] public Single FieldOfView;
        
    }
    
    [Serializable]public class AData : AuroraStruct {
        // Field definitions
        [GFF("structid")] public uint structid;
        [GFF("XPosition")] public Single XPosition;
        [GFF("YPosition")] public Single YPosition;
        [GFF("ZPosition")] public Single ZPosition;
        [GFF("XOrientation")] public Single XOrientation;
        [GFF("YOrientation")] public Single YOrientation;
        [GFF("TemplateResRef")] public String TemplateResRef;
        
    }
    
}
