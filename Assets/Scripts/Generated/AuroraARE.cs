using System;
using System.Collections.Generic;
using static AuroraEngine.GFFObject;
using UnityEngine;
using AuroraEngine;

[Serializable]public class AuroraARE : AuroraStruct {
    // Field definitions
    [GFF("structid")] public uint structid;
    [GFF("ID")] public Int32 ID;
    [GFF("Creator_ID")] public Int32 Creator_ID;
    [GFF("Version")] public UInt32 Version;
    [GFF("Tag")] public CExoString Tag;
    [GFF("Name")] public CExoLocString Name;
    [GFF("Comments")] public CExoString Comments;
    [GFF("Flags")] public UInt32 Flags;
    [GFF("ModSpotCheck")] public Int32 ModSpotCheck;
    [GFF("ModListenCheck")] public Int32 ModListenCheck;
    [GFF("AlphaTest")] public Single AlphaTest;
    [GFF("CameraStyle")] public Int32 CameraStyle;
    [GFF("DefaultEnvMap")] public String DefaultEnvMap;
    [GFF("Grass_TexName")] public String Grass_TexName;
    [GFF("Grass_Density")] public Single Grass_Density;
    [GFF("Grass_QuadSize")] public Single Grass_QuadSize;
    [GFF("Grass_Ambient")] public UInt32 Grass_Ambient;
    [GFF("Grass_Diffuse")] public UInt32 Grass_Diffuse;
    [GFF("Grass_Prob_LL")] public Single Grass_Prob_LL;
    [GFF("Grass_Prob_LR")] public Single Grass_Prob_LR;
    [GFF("Grass_Prob_UL")] public Single Grass_Prob_UL;
    [GFF("Grass_Prob_UR")] public Single Grass_Prob_UR;
    [GFF("MoonAmbientColor")] public UInt32 MoonAmbientColor;
    [GFF("MoonDiffuseColor")] public UInt32 MoonDiffuseColor;
    [GFF("MoonFogOn")] public Byte MoonFogOn;
    [GFF("MoonFogNear")] public Single MoonFogNear;
    [GFF("MoonFogFar")] public Single MoonFogFar;
    [GFF("MoonFogColor")] public UInt32 MoonFogColor;
    [GFF("MoonShadows")] public Byte MoonShadows;
    [GFF("SunAmbientColor")] public UInt32 SunAmbientColor;
    [GFF("SunDiffuseColor")] public UInt32 SunDiffuseColor;
    [GFF("SunFogOn")] public Byte SunFogOn;
    [GFF("SunFogNear")] public Single SunFogNear;
    [GFF("SunFogFar")] public Single SunFogFar;
    [GFF("SunFogColor")] public UInt32 SunFogColor;
    [GFF("SunShadows")] public Byte SunShadows;
    [GFF("DynAmbientColor")] public UInt32 DynAmbientColor;
    [GFF("IsNight")] public Byte IsNight;
    [GFF("LightingScheme")] public Byte LightingScheme;
    [GFF("ShadowOpacity")] public Byte ShadowOpacity;
    [GFF("DayNightCycle")] public Byte DayNightCycle;
    [GFF("ChanceRain")] public Int32 ChanceRain;
    [GFF("ChanceSnow")] public Int32 ChanceSnow;
    [GFF("ChanceLightning")] public Int32 ChanceLightning;
    [GFF("WindPower")] public Int32 WindPower;
    [GFF("LoadScreenID")] public UInt16 LoadScreenID;
    [GFF("PlayerVsPlayer")] public Byte PlayerVsPlayer;
    [GFF("NoRest")] public Byte NoRest;
    [GFF("NoHangBack")] public Byte NoHangBack;
    [GFF("PlayerOnly")] public Byte PlayerOnly;
    [GFF("Unescapable")] public Byte Unescapable;
    [GFF("StealthXPEnabled")] public Byte StealthXPEnabled;
    [GFF("StealthXPLoss")] public UInt32 StealthXPLoss;
    [GFF("StealthXPMax")] public UInt32 StealthXPMax;
    [GFF("OnEnter")] public String OnEnter;
    [GFF("OnExit")] public String OnExit;
    [GFF("OnHeartbeat")] public String OnHeartbeat;
    [GFF("OnUserDefined")] public String OnUserDefined;

    // Struct definitions
    [GFF("Map")] public AMap Map = new AMap();
    [GFF("MiniGame")] public AMiniGame MiniGame = new AMiniGame();

    // List definitions
    [GFF("Rooms")] public List<ARooms> Rooms = new List<ARooms>();

    // Class definitions    
    [Serializable]public class AMap : AuroraStruct {
        // Field definitions
        [GFF("structid")] public uint structid;
        [GFF("MapResX")] public Int32 MapResX;
        [GFF("NorthAxis")] public Int32 NorthAxis;
        [GFF("WorldPt1X")] public Single WorldPt1X;
        [GFF("WorldPt1Y")] public Single WorldPt1Y;
        [GFF("WorldPt2X")] public Single WorldPt2X;
        [GFF("WorldPt2Y")] public Single WorldPt2Y;
        [GFF("MapPt1X")] public Single MapPt1X;
        [GFF("MapPt1Y")] public Single MapPt1Y;
        [GFF("MapPt2X")] public Single MapPt2X;
        [GFF("MapPt2Y")] public Single MapPt2Y;
        [GFF("MapZoom")] public Int32 MapZoom;
        
    }
    
    [Serializable]public class AMiniGame : AuroraStruct {
        // Field definitions
        [GFF("structid")] public uint structid;
        [GFF("Type")] public UInt32 Type;
        [GFF("Near_Clip")] public Single Near_Clip;
        [GFF("Far_Clip")] public Single Far_Clip;
        [GFF("CameraViewAngle")] public Single CameraViewAngle;
        [GFF("Bump_Plane")] public UInt32 Bump_Plane;
        [GFF("UseInertia")] public Byte UseInertia;
        [GFF("DoBumping")] public Byte DoBumping;
        [GFF("DOF")] public UInt32 DOF;
        [GFF("MovementPerSec")] public Single MovementPerSec;
        [GFF("LateralAccel")] public Single LateralAccel;
        [GFF("Music")] public String Music;
    
        // Struct definitions
        [GFF("Mouse")] public AMouse Mouse = new AMouse();
        [GFF("Player")] public APlayer Player = new APlayer();
    
        // List definitions
        [GFF("Enemies")] public List<AEnemies> Enemies = new List<AEnemies>();
        [GFF("Obstacles")] public List<AObstacles> Obstacles = new List<AObstacles>();
    
        // Class definitions    
        [Serializable]public class AMouse : AuroraStruct {
            // Field definitions
            [GFF("structid")] public uint structid;
            [GFF("AxisX")] public UInt32 AxisX;
            [GFF("AxisY")] public UInt32 AxisY;
            [GFF("FlipAxisX")] public Byte FlipAxisX;
            [GFF("FlipAxisY")] public Byte FlipAxisY;
            
        }
        
        [Serializable]public class APlayer : AuroraStruct {
            // Field definitions
            [GFF("structid")] public uint structid;
            [GFF("Track")] public String Track;
            [GFF("Num_Loops")] public Int32 Num_Loops;
            [GFF("Sphere_Radius")] public Single Sphere_Radius;
            [GFF("Invince_Period")] public Single Invince_Period;
            [GFF("Hit_Points")] public UInt32 Hit_Points;
            [GFF("Max_HPs")] public UInt32 Max_HPs;
            [GFF("Bump_Damage")] public Int32 Bump_Damage;
            [GFF("Camera")] public String Camera;
            [GFF("CameraRotate")] public Byte CameraRotate;
            [GFF("Minimum_Speed")] public Single Minimum_Speed;
            [GFF("Maximum_Speed")] public Single Maximum_Speed;
            [GFF("Accel_Secs")] public Single Accel_Secs;
            [GFF("Start_Offset_X")] public Single Start_Offset_X;
            [GFF("Start_Offset_Y")] public Single Start_Offset_Y;
            [GFF("Start_Offset_Z")] public Single Start_Offset_Z;
            [GFF("TunnelInfinite")] public Vector3 TunnelInfinite;
            [GFF("TunnelXPos")] public Single TunnelXPos;
            [GFF("TunnelYPos")] public Single TunnelYPos;
            [GFF("TunnelZPos")] public Single TunnelZPos;
            [GFF("TunnelXNeg")] public Single TunnelXNeg;
            [GFF("TunnelYNeg")] public Single TunnelYNeg;
            [GFF("TunnelZNeg")] public Single TunnelZNeg;
            [GFF("Target_Offset_X")] public Single Target_Offset_X;
            [GFF("Target_Offset_Y")] public Single Target_Offset_Y;
            [GFF("Target_Offset_Z")] public Single Target_Offset_Z;
        
            // Struct definitions
            [GFF("Sounds")] public ASounds Sounds = new ASounds();
            [GFF("Scripts")] public AScripts Scripts = new AScripts();
        
            // List definitions
            [GFF("Models")] public List<AModels> Models = new List<AModels>();
            [GFF("Gun_Banks")] public List<AGun_Banks> Gun_Banks = new List<AGun_Banks>();
        
            // Class definitions    
            [Serializable]public class ASounds : AuroraStruct {
                // Field definitions
                [GFF("structid")] public uint structid;
                [GFF("Death")] public String Death;
                [GFF("Engine")] public String Engine;
                
            }
            
            [Serializable]public class AScripts : AuroraStruct {
                // Field definitions
                [GFF("structid")] public uint structid;
                [GFF("OnCreate")] public String OnCreate;
                [GFF("OnHeartbeat")] public String OnHeartbeat;
                [GFF("OnDamage")] public String OnDamage;
                [GFF("OnDeath")] public String OnDeath;
                [GFF("OnFire")] public String OnFire;
                [GFF("OnHitBullet")] public String OnHitBullet;
                [GFF("OnHitFollower")] public String OnHitFollower;
                [GFF("OnHitObstacle")] public String OnHitObstacle;
                [GFF("OnTrackLoop")] public String OnTrackLoop;
                [GFF("OnAnimEvent")] public String OnAnimEvent;
                
            }
            
            [Serializable]public class AModels : AuroraStruct {
                // Field definitions
                [GFF("structid")] public uint structid;
                [GFF("Model")] public String Model;
                [GFF("RotatingModel")] public Byte RotatingModel;
                
            }
            
            [Serializable]public class AGun_Banks : AuroraStruct {
                // Field definitions
                [GFF("structid")] public uint structid;
                [GFF("BankID")] public UInt32 BankID;
                [GFF("Gun_Model")] public String Gun_Model;
                [GFF("Fire_Sound")] public String Fire_Sound;
            
                // Struct definitions
                [GFF("Bullet")] public ABullet Bullet = new ABullet();
            
                // Class definitions    
                [Serializable]public class ABullet : AuroraStruct {
                    // Field definitions
                    [GFF("structid")] public uint structid;
                    [GFF("Damage")] public UInt32 Damage;
                    [GFF("Lifespan")] public Single Lifespan;
                    [GFF("Bullet_Model")] public String Bullet_Model;
                    [GFF("Rate_Of_Fire")] public Single Rate_Of_Fire;
                    [GFF("Collision_Sound")] public String Collision_Sound;
                    [GFF("Speed")] public Single Speed;
                    [GFF("Target_Type")] public UInt32 Target_Type;
                    
                }
                
            }
            
        }
        
        [Serializable]public class AEnemies : AuroraStruct {
            // Field definitions
            [GFF("structid")] public uint structid;
            [GFF("Track")] public String Track;
            [GFF("Num_Loops")] public Int32 Num_Loops;
            [GFF("Sphere_Radius")] public Single Sphere_Radius;
            [GFF("Invince_Period")] public Single Invince_Period;
            [GFF("Hit_Points")] public UInt32 Hit_Points;
            [GFF("Max_HPs")] public UInt32 Max_HPs;
            [GFF("Bump_Damage")] public Int32 Bump_Damage;
            [GFF("Trigger")] public Byte Trigger;
        
            // Struct definitions
            [GFF("Sounds")] public ASounds Sounds = new ASounds();
            [GFF("Scripts")] public AScripts Scripts = new AScripts();
        
            // List definitions
            [GFF("Models")] public List<AModels> Models = new List<AModels>();
            [GFF("Gun_Banks")] public List<AGun_Banks> Gun_Banks = new List<AGun_Banks>();
        
            // Class definitions    
            [Serializable]public class ASounds : AuroraStruct {
                // Field definitions
                [GFF("structid")] public uint structid;
                [GFF("Death")] public String Death;
                [GFF("Engine")] public String Engine;
                
            }
            
            [Serializable]public class AScripts : AuroraStruct {
                // Field definitions
                [GFF("structid")] public uint structid;
                [GFF("OnCreate")] public String OnCreate;
                [GFF("OnHeartbeat")] public String OnHeartbeat;
                [GFF("OnDamage")] public String OnDamage;
                [GFF("OnDeath")] public String OnDeath;
                [GFF("OnFire")] public String OnFire;
                [GFF("OnHitBullet")] public String OnHitBullet;
                [GFF("OnHitFollower")] public String OnHitFollower;
                [GFF("OnHitObstacle")] public String OnHitObstacle;
                [GFF("OnTrackLoop")] public String OnTrackLoop;
                [GFF("OnAnimEvent")] public String OnAnimEvent;
                
            }
            
            [Serializable]public class AModels : AuroraStruct {
                // Field definitions
                [GFF("structid")] public uint structid;
                [GFF("Model")] public String Model;
                [GFF("RotatingModel")] public Byte RotatingModel;
                
            }
            
            [Serializable]public class AGun_Banks : AuroraStruct {
                // Field definitions
                [GFF("structid")] public uint structid;
                [GFF("BankID")] public UInt32 BankID;
                [GFF("Gun_Model")] public String Gun_Model;
                [GFF("Fire_Sound")] public String Fire_Sound;
                [GFF("Inaccuracy")] public Single Inaccuracy;
                [GFF("Sensing_Radius")] public Single Sensing_Radius;
                [GFF("Horiz_Spread")] public Single Horiz_Spread;
                [GFF("Vert_Spread")] public Single Vert_Spread;
            
                // Struct definitions
                [GFF("Bullet")] public ABullet Bullet = new ABullet();
            
                // Class definitions    
                [Serializable]public class ABullet : AuroraStruct {
                    // Field definitions
                    [GFF("structid")] public uint structid;
                    [GFF("Damage")] public UInt32 Damage;
                    [GFF("Lifespan")] public Single Lifespan;
                    [GFF("Bullet_Model")] public String Bullet_Model;
                    [GFF("Rate_Of_Fire")] public Single Rate_Of_Fire;
                    [GFF("Collision_Sound")] public String Collision_Sound;
                    [GFF("Speed")] public Single Speed;
                    [GFF("Target_Type")] public UInt32 Target_Type;
                    
                }
                
            }
            
        }
        
        [Serializable]public class AObstacles : AuroraStruct {
            // Field definitions
            [GFF("structid")] public uint structid;
            [GFF("Name")] public String Name;
        
            // Struct definitions
            [GFF("Scripts")] public AScripts Scripts = new AScripts();
        
            // Class definitions    
            [Serializable]public class AScripts : AuroraStruct {
                // Field definitions
                [GFF("structid")] public uint structid;
                [GFF("OnAnimEvent")] public String OnAnimEvent;
                [GFF("OnCreate")] public String OnCreate;
                [GFF("OnHeartbeat")] public String OnHeartbeat;
                [GFF("OnHitFollower")] public String OnHitFollower;
                [GFF("OnHitBullet")] public String OnHitBullet;
                
            }
            
        }
        
    }
    
    [Serializable]public class ARooms : AuroraStruct {
        // Field definitions
        [GFF("structid")] public uint structid;
        [GFF("RoomName")] public CExoString RoomName;
        [GFF("EnvAudio")] public Int32 EnvAudio;
        [GFF("AmbientScale")] public Single AmbientScale;
    
        // List definitions
        [GFF("PartSounds")] public List<APartSounds> PartSounds = new List<APartSounds>();
    
        // Class definitions    
        [Serializable]public class APartSounds : AuroraStruct {
            // Field definitions
            [GFF("structid")] public uint structid;
            [GFF("ModelPart")] public CExoString ModelPart;
            [GFF("OmenEvent")] public CExoString OmenEvent;
            [GFF("Sound")] public String Sound;
            [GFF("Looping")] public Byte Looping;
            
        }
        
    }
    
}
