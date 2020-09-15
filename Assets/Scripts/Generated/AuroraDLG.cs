using System;
using System.Collections.Generic;
using static AuroraEngine.GFFObject;
using UnityEngine;
using AuroraEngine;

[Serializable]public class AuroraDLG : AuroraStruct {
    // Field definitions
    [GFF("structid")] public uint structid;
    [GFF("DelayEntry")] public UInt32 DelayEntry;
    [GFF("DelayReply")] public UInt32 DelayReply;
    [GFF("NumWords")] public UInt32 NumWords;
    [GFF("EndConversation")] public String EndConversation;
    [GFF("EndConverAbort")] public String EndConverAbort;
    [GFF("Skippable")] public Byte Skippable;
    [GFF("CameraModel")] public String CameraModel;
    [GFF("VO_ID")] public CExoString VO_ID;
    [GFF("ConversationType")] public Int32 ConversationType;
    [GFF("ComputerType")] public Byte ComputerType;
    [GFF("OldHitCheck")] public Byte OldHitCheck;
    [GFF("AmbientTrack")] public String AmbientTrack;
    [GFF("UnequipItems")] public Byte UnequipItems;
    [GFF("AnimatedCut")] public Byte AnimatedCut;
    [GFF("UnequipHItem")] public Byte UnequipHItem;

    // List definitions
    [GFF("EntryList")] public List<AEntry> EntryList = new List<AEntry>();
    [GFF("ReplyList")] public List<AReply> ReplyList = new List<AReply>();
    [GFF("StartingList")] public List<AStarting> StartingList = new List<AStarting>();
    [GFF("StuntList")] public List<AStunt> StuntList = new List<AStunt>();

    // Class definitions    
    [Serializable]public class AEntry : AuroraStruct {
        // Field definitions
        [GFF("structid")] public uint structid;
        [GFF("Speaker")] public CExoString Speaker;
        [GFF("Text")] public CExoLocString Text;
        [GFF("VO_ResRef")] public String VO_ResRef;
        [GFF("Script")] public String Script;
        [GFF("Delay")] public UInt32 Delay;
        [GFF("Comment")] public CExoString Comment;
        [GFF("Sound")] public String Sound;
        [GFF("Quest")] public CExoString Quest;
        [GFF("PlotIndex")] public Int32 PlotIndex;
        [GFF("PlotXPPercentage")] public Single PlotXPPercentage;
        [GFF("Listener")] public CExoString Listener;
        [GFF("WaitFlags")] public UInt32 WaitFlags;
        [GFF("CameraAngle")] public UInt32 CameraAngle;
        [GFF("FadeType")] public Byte FadeType;
        [GFF("SoundExists")] public Byte SoundExists;
        [GFF("CamHeightOffset")] public Single CamHeightOffset;
        [GFF("TarHeightOffset")] public Single TarHeightOffset;
        [GFF("CameraID")] public Int32 CameraID;
        [GFF("CamVidEffect")] public Int32 CamVidEffect;
        [GFF("FadeLength")] public Single FadeLength;
        [GFF("FadeDelay")] public Single FadeDelay;
        [GFF("FadeColor")] public Vector3 FadeColor;
        [GFF("QuestEntry")] public UInt32 QuestEntry;
        [GFF("CamFieldOfView")] public Single CamFieldOfView;
        [GFF("CameraAnimation")] public UInt16 CameraAnimation;
    
        // List definitions
        [GFF("AnimList")] public List<AAnim> AnimList = new List<AAnim>();
        [GFF("RepliesList")] public List<AReplies> RepliesList = new List<AReplies>();
    
        // Class definitions    
        [Serializable]public class AAnim : AuroraStruct {
            // Field definitions
            [GFF("structid")] public uint structid;
            [GFF("Participant")] public CExoString Participant;
            [GFF("Animation")] public UInt16 Animation;
            
        }
        
        [Serializable]public class AReplies : AuroraStruct {
            // Field definitions
            [GFF("structid")] public uint structid;
            [GFF("Index")] public UInt32 Index;
            [GFF("Active")] public String Active;
            [GFF("IsChild")] public Byte IsChild;
            [GFF("LinkComment")] public CExoString LinkComment;
            
        }
        
    }
    
    [Serializable]public class AReply : AuroraStruct {
        // Field definitions
        [GFF("structid")] public uint structid;
        [GFF("Text")] public CExoLocString Text;
        [GFF("VO_ResRef")] public String VO_ResRef;
        [GFF("Script")] public String Script;
        [GFF("Delay")] public UInt32 Delay;
        [GFF("Comment")] public CExoString Comment;
        [GFF("Sound")] public String Sound;
        [GFF("Quest")] public CExoString Quest;
        [GFF("PlotIndex")] public Int32 PlotIndex;
        [GFF("PlotXPPercentage")] public Single PlotXPPercentage;
        [GFF("Listener")] public CExoString Listener;
        [GFF("WaitFlags")] public UInt32 WaitFlags;
        [GFF("CameraAngle")] public UInt32 CameraAngle;
        [GFF("FadeType")] public Byte FadeType;
        [GFF("SoundExists")] public Byte SoundExists;
        [GFF("CamHeightOffset")] public Single CamHeightOffset;
        [GFF("TarHeightOffset")] public Single TarHeightOffset;
        [GFF("QuestEntry")] public UInt32 QuestEntry;
        [GFF("FadeDelay")] public Single FadeDelay;
        [GFF("FadeColor")] public Vector3 FadeColor;
        [GFF("CameraID")] public Int32 CameraID;
        [GFF("CamVidEffect")] public Int32 CamVidEffect;
        [GFF("FadeLength")] public Single FadeLength;
        [GFF("CamFieldOfView")] public Single CamFieldOfView;
        [GFF("CameraAnimation")] public UInt16 CameraAnimation;
    
        // List definitions
        [GFF("EntriesList")] public List<AEntries> EntriesList = new List<AEntries>();
        [GFF("AnimList")] public List<AAnim> AnimList = new List<AAnim>();
    
        // Class definitions    
        [Serializable]public class AEntries : AuroraStruct {
            // Field definitions
            [GFF("structid")] public uint structid;
            [GFF("Index")] public UInt32 Index;
            [GFF("Active")] public String Active;
            [GFF("IsChild")] public Byte IsChild;
            [GFF("LinkComment")] public CExoString LinkComment;
            
        }
        
        [Serializable]public class AAnim : AuroraStruct {
            // Field definitions
            [GFF("structid")] public uint structid;
            [GFF("Participant")] public CExoString Participant;
            [GFF("Animation")] public UInt16 Animation;
            
        }
        
    }
    
    [Serializable]public class AStarting : AuroraStruct {
        // Field definitions
        [GFF("structid")] public uint structid;
        [GFF("Index")] public UInt32 Index;
        [GFF("Active")] public String Active;
        
    }
    
    [Serializable]public class AStunt : AuroraStruct {
        // Field definitions
        [GFF("structid")] public uint structid;
        [GFF("Participant")] public CExoString Participant;
        [GFF("StuntModel")] public String StuntModel;
        
    }
    
}
