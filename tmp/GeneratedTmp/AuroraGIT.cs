using System;
using System.Collections.Generic;
using static AuroraEngine.GFFObject;
using UnityEngine;

public class AuroraGIT : AuroraStruct {
    // Field definitions
    public uint structid;
    public Byte UseTemplates;

    // Struct definitions
    public AAreaProperties AreaProperties;

    // List definitions
    public List<ACreature> CreatureList;
    public List<ADoor> DoorList;
    public List<AEncounter> EncounterList;
    public List<ASound> SoundList;
    public List<AStore> StoreList;
    public List<ATrigger> TriggerList;
    public List<AWaypoint> WaypointList;
    public List<APlaceable> PlaceableList;
    public List<ACamera> CameraList;
    public List<AData> List;

    // Class definitions    
    public class AAreaProperties : AuroraStruct {
        // Field definitions
        public uint structid;
        public Int32 AmbientSndDay;
        public Int32 AmbientSndNight;
        public Int32 AmbientSndDayVol;
        public Int32 AmbientSndNitVol;
        public Int32 EnvAudio;
        public Int32 MusicBattle;
        public Int32 MusicDay;
        public Int32 MusicNight;
        public Int32 MusicDelay;
        
    }
    
    public class ACreature : AuroraStruct {
        // Field definitions
        public uint structid;
        public Single XPosition;
        public Single YPosition;
        public Single ZPosition;
        public Single XOrientation;
        public Single YOrientation;
        public String TemplateResRef;
        
    }
    
    public class ADoor : AuroraStruct {
        // Field definitions
        public uint structid;
        public String TemplateResRef;
        public String Tag;
        public String LinkedToModule;
        public String LinkedTo;
        public Byte LinkedToFlags;
        public CExoLocString TransitionDestin;
        public Single X;
        public Single Y;
        public Single Z;
        public Single Bearing;
        
    }
    
    public class AEncounter : AuroraStruct {
        // Field definitions
        public uint structid;
        public String TemplateResRef;
        public Single XPosition;
        public Single YPosition;
        public Single ZPosition;
    
        // List definitions
        public List<AGeometry> Geometry;
        public List<ASpawnPoint> SpawnPointList;
    
        // Class definitions    
        public class AGeometry : AuroraStruct {
            // Field definitions
            public uint structid;
            public Single X;
            public Single Y;
            public Single Z;
            
        }
        
        public class ASpawnPoint : AuroraStruct {
            // Field definitions
            public uint structid;
            public Single X;
            public Single Y;
            public Single Z;
            public Single Orientation;
            
        }
        
    }
    
    public class ASound : AuroraStruct {
        // Field definitions
        public uint structid;
        public String TemplateResRef;
        public UInt32 GeneratedType;
        public Single XPosition;
        public Single YPosition;
        public Single ZPosition;
        
    }
    
    public class AStore : AuroraStruct {
        // Field definitions
        public uint structid;
        public Single XPosition;
        public Single YPosition;
        public Single ZPosition;
        public Single XOrientation;
        public Single YOrientation;
        public String ResRef;
        
    }
    
    public class ATrigger : AuroraStruct {
        // Field definitions
        public uint structid;
        public String TemplateResRef;
        public Single XPosition;
        public Single YPosition;
        public Single ZPosition;
        public Single XOrientation;
        public Single YOrientation;
        public Single ZOrientation;
        public String Tag;
        public CExoLocString TransitionDestin;
        public String LinkedToModule;
        public String LinkedTo;
        public Byte LinkedToFlags;
    
        // List definitions
        public List<AGeometry> Geometry;
    
        // Class definitions    
        public class AGeometry : AuroraStruct {
            // Field definitions
            public uint structid;
            public Single PointX;
            public Single PointY;
            public Single PointZ;
            
        }
        
    }
    
    public class AWaypoint : AuroraStruct {
        // Field definitions
        public uint structid;
        public Byte Appearance;
        public String LinkedTo;
        public String TemplateResRef;
        public String Tag;
        public CExoLocString LocalizedName;
        public CExoLocString Description;
        public Byte HasMapNote;
        public CExoLocString MapNote;
        public Byte MapNoteEnabled;
        public Single XPosition;
        public Single YPosition;
        public Single ZPosition;
        public Single XOrientation;
        public Single YOrientation;
        
    }
    
    public class APlaceable : AuroraStruct {
        // Field definitions
        public uint structid;
        public String TemplateResRef;
        public Single X;
        public Single Y;
        public Single Z;
        public Single Bearing;
        
    }
    
    public class ACamera : AuroraStruct {
        // Field definitions
        public uint structid;
        public Int32 CameraID;
        public Vector3 Position;
        public Single Pitch;
        public Single MicRange;
        public Quaternion Orientation;
        public Single Height;
        public Single FieldOfView;
        
    }
    
    public class AData : AuroraStruct {
        // Field definitions
        public uint structid;
        public Single XPosition;
        public Single YPosition;
        public Single ZPosition;
        public Single XOrientation;
        public Single YOrientation;
        public String TemplateResRef;
        
    }
    
}
