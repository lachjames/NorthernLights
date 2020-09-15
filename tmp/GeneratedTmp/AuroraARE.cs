using System;
using System.Collections.Generic;
using static AuroraEngine.GFFObject;
using UnityEngine;

public class AuroraARE : AuroraStruct {
    // Field definitions
    public uint structid;
    public Int32 ID;
    public Int32 Creator_ID;
    public UInt32 Version;
    public String Tag;
    public CExoLocString Name;
    public String Comments;
    public UInt32 Flags;
    public Int32 ModSpotCheck;
    public Int32 ModListenCheck;
    public Single AlphaTest;
    public Int32 CameraStyle;
    public String DefaultEnvMap;
    public String Grass_TexName;
    public Single Grass_Density;
    public Single Grass_QuadSize;
    public UInt32 Grass_Ambient;
    public UInt32 Grass_Diffuse;
    public Single Grass_Prob_LL;
    public Single Grass_Prob_LR;
    public Single Grass_Prob_UL;
    public Single Grass_Prob_UR;
    public UInt32 MoonAmbientColor;
    public UInt32 MoonDiffuseColor;
    public Byte MoonFogOn;
    public Single MoonFogNear;
    public Single MoonFogFar;
    public UInt32 MoonFogColor;
    public Byte MoonShadows;
    public UInt32 SunAmbientColor;
    public UInt32 SunDiffuseColor;
    public Byte SunFogOn;
    public Single SunFogNear;
    public Single SunFogFar;
    public UInt32 SunFogColor;
    public Byte SunShadows;
    public UInt32 DynAmbientColor;
    public Byte IsNight;
    public Byte LightingScheme;
    public Byte ShadowOpacity;
    public Byte DayNightCycle;
    public Int32 ChanceRain;
    public Int32 ChanceSnow;
    public Int32 ChanceLightning;
    public Int32 WindPower;
    public UInt16 LoadScreenID;
    public Byte PlayerVsPlayer;
    public Byte NoRest;
    public Byte NoHangBack;
    public Byte PlayerOnly;
    public Byte Unescapable;
    public Byte StealthXPEnabled;
    public UInt32 StealthXPLoss;
    public UInt32 StealthXPMax;
    public String OnEnter;
    public String OnExit;
    public String OnHeartbeat;
    public String OnUserDefined;

    // Struct definitions
    public AMap Map;
    public AMiniGame MiniGame;

    // List definitions
    public List<ARooms> Rooms;

    // Class definitions    
    public class AMap : AuroraStruct {
        // Field definitions
        public uint structid;
        public Int32 MapResX;
        public Int32 NorthAxis;
        public Single WorldPt1X;
        public Single WorldPt1Y;
        public Single WorldPt2X;
        public Single WorldPt2Y;
        public Single MapPt1X;
        public Single MapPt1Y;
        public Single MapPt2X;
        public Single MapPt2Y;
        public Int32 MapZoom;
        
    }
    
    public class AMiniGame : AuroraStruct {
        // Field definitions
        public uint structid;
        public UInt32 Type;
        public Single Near_Clip;
        public Single Far_Clip;
        public Single CameraViewAngle;
        public UInt32 Bump_Plane;
        public Byte UseInertia;
        public Byte DoBumping;
        public UInt32 DOF;
        public Single MovementPerSec;
        public Single LateralAccel;
        public String Music;
    
        // Struct definitions
        public AMouse Mouse;
        public APlayer Player;
    
        // List definitions
        public List<AEnemies> Enemies;
        public List<AObstacles> Obstacles;
    
        // Class definitions    
        public class AMouse : AuroraStruct {
            // Field definitions
            public uint structid;
            public UInt32 AxisX;
            public UInt32 AxisY;
            public Byte FlipAxisX;
            public Byte FlipAxisY;
            
        }
        
        public class APlayer : AuroraStruct {
            // Field definitions
            public uint structid;
            public String Track;
            public Int32 Num_Loops;
            public Single Sphere_Radius;
            public Single Invince_Period;
            public UInt32 Hit_Points;
            public UInt32 Max_HPs;
            public Int32 Bump_Damage;
            public String Camera;
            public Byte CameraRotate;
            public Single Minimum_Speed;
            public Single Maximum_Speed;
            public Single Accel_Secs;
            public Single Start_Offset_X;
            public Single Start_Offset_Y;
            public Single Start_Offset_Z;
            public Vector3 TunnelInfinite;
            public Single TunnelXPos;
            public Single TunnelYPos;
            public Single TunnelZPos;
            public Single TunnelXNeg;
            public Single TunnelYNeg;
            public Single TunnelZNeg;
            public Single Target_Offset_X;
            public Single Target_Offset_Y;
            public Single Target_Offset_Z;
        
            // Struct definitions
            public ASounds Sounds;
            public AScripts Scripts;
        
            // List definitions
            public List<AModels> Models;
            public List<AGun_Banks> Gun_Banks;
        
            // Class definitions    
            public class ASounds : AuroraStruct {
                // Field definitions
                public uint structid;
                public String Death;
                public String Engine;
                
            }
            
            public class AScripts : AuroraStruct {
                // Field definitions
                public uint structid;
                public String OnCreate;
                public String OnHeartbeat;
                public String OnDamage;
                public String OnDeath;
                public String OnFire;
                public String OnHitBullet;
                public String OnHitFollower;
                public String OnHitObstacle;
                public String OnTrackLoop;
                public String OnAnimEvent;
                
            }
            
            public class AModels : AuroraStruct {
                // Field definitions
                public uint structid;
                public String Model;
                public Byte RotatingModel;
                
            }
            
            public class AGun_Banks : AuroraStruct {
                // Field definitions
                public uint structid;
                public UInt32 BankID;
                public String Gun_Model;
                public String Fire_Sound;
            
                // Struct definitions
                public ABullet Bullet;
            
                // Class definitions    
                public class ABullet : AuroraStruct {
                    // Field definitions
                    public uint structid;
                    public UInt32 Damage;
                    public Single Lifespan;
                    public String Bullet_Model;
                    public Single Rate_Of_Fire;
                    public String Collision_Sound;
                    public Single Speed;
                    public UInt32 Target_Type;
                    
                }
                
            }
            
        }
        
        public class AEnemies : AuroraStruct {
            // Field definitions
            public uint structid;
            public String Track;
            public Int32 Num_Loops;
            public Single Sphere_Radius;
            public Single Invince_Period;
            public UInt32 Hit_Points;
            public UInt32 Max_HPs;
            public Int32 Bump_Damage;
            public Byte Trigger;
        
            // Struct definitions
            public ASounds Sounds;
            public AScripts Scripts;
        
            // List definitions
            public List<AModels> Models;
            public List<AGun_Banks> Gun_Banks;
        
            // Class definitions    
            public class ASounds : AuroraStruct {
                // Field definitions
                public uint structid;
                public String Death;
                public String Engine;
                
            }
            
            public class AScripts : AuroraStruct {
                // Field definitions
                public uint structid;
                public String OnCreate;
                public String OnHeartbeat;
                public String OnDamage;
                public String OnDeath;
                public String OnFire;
                public String OnHitBullet;
                public String OnHitFollower;
                public String OnHitObstacle;
                public String OnTrackLoop;
                public String OnAnimEvent;
                
            }
            
            public class AModels : AuroraStruct {
                // Field definitions
                public uint structid;
                public String Model;
                public Byte RotatingModel;
                
            }
            
            public class AGun_Banks : AuroraStruct {
                // Field definitions
                public uint structid;
                public UInt32 BankID;
                public String Gun_Model;
                public String Fire_Sound;
                public Single Inaccuracy;
                public Single Sensing_Radius;
                public Single Horiz_Spread;
                public Single Vert_Spread;
            
                // Struct definitions
                public ABullet Bullet;
            
                // Class definitions    
                public class ABullet : AuroraStruct {
                    // Field definitions
                    public uint structid;
                    public UInt32 Damage;
                    public Single Lifespan;
                    public String Bullet_Model;
                    public Single Rate_Of_Fire;
                    public String Collision_Sound;
                    public Single Speed;
                    public UInt32 Target_Type;
                    
                }
                
            }
            
        }
        
        public class AObstacles : AuroraStruct {
            // Field definitions
            public uint structid;
            public String Name;
        
            // Struct definitions
            public AScripts Scripts;
        
            // Class definitions    
            public class AScripts : AuroraStruct {
                // Field definitions
                public uint structid;
                public String OnAnimEvent;
                public String OnCreate;
                public String OnHeartbeat;
                public String OnHitFollower;
                public String OnHitBullet;
                
            }
            
        }
        
    }
    
    public class ARooms : AuroraStruct {
        // Field definitions
        public uint structid;
        public String RoomName;
        public Int32 EnvAudio;
        public Single AmbientScale;
    
        // List definitions
        public List<APartSounds> PartSounds;
    
        // Class definitions    
        public class APartSounds : AuroraStruct {
            // Field definitions
            public uint structid;
            public String ModelPart;
            public String OmenEvent;
            public String Sound;
            public Byte Looping;
            
        }
        
    }
    
}
