using System;
using System.Collections.Generic;
using static AuroraEngine.GFFObject;
using UnityEngine;

public class AuroraDLG : AuroraStruct {
    // Field definitions
    public uint structid;
    public UInt32 DelayEntry;
    public UInt32 DelayReply;
    public UInt32 NumWords;
    public String EndConversation;
    public String EndConverAbort;
    public Byte Skippable;
    public String CameraModel;
    public String VO_ID;
    public Int32 ConversationType;
    public Byte ComputerType;
    public Byte OldHitCheck;
    public String AmbientTrack;
    public Byte UnequipItems;
    public Byte AnimatedCut;
    public Byte UnequipHItem;

    // List definitions
    public List<AEntry> EntryList;
    public List<AReply> ReplyList;
    public List<AStarting> StartingList;
    public List<AStunt> StuntList;

    // Class definitions    
    public class AEntry : AuroraStruct {
        // Field definitions
        public uint structid;
        public String Speaker;
        public CExoLocString Text;
        public String VO_ResRef;
        public String Script;
        public UInt32 Delay;
        public String Comment;
        public String Sound;
        public String Quest;
        public Int32 PlotIndex;
        public Single PlotXPPercentage;
        public String Listener;
        public UInt32 WaitFlags;
        public UInt32 CameraAngle;
        public Byte FadeType;
        public Byte SoundExists;
        public Single CamHeightOffset;
        public Single TarHeightOffset;
        public Int32 CameraID;
        public Int32 CamVidEffect;
        public Single FadeLength;
        public Single FadeDelay;
        public Vector3 FadeColor;
        public UInt32 QuestEntry;
        public Single CamFieldOfView;
        public UInt16 CameraAnimation;
    
        // List definitions
        public List<AAnim> AnimList;
        public List<AReplies> RepliesList;
    
        // Class definitions    
        public class AAnim : AuroraStruct {
            // Field definitions
            public uint structid;
            public String Participant;
            public UInt16 Animation;
            
        }
        
        public class AReplies : AuroraStruct {
            // Field definitions
            public uint structid;
            public UInt32 Index;
            public String Active;
            public Byte IsChild;
            public String LinkComment;
            
        }
        
    }
    
    public class AReply : AuroraStruct {
        // Field definitions
        public uint structid;
        public CExoLocString Text;
        public String VO_ResRef;
        public String Script;
        public UInt32 Delay;
        public String Comment;
        public String Sound;
        public String Quest;
        public Int32 PlotIndex;
        public Single PlotXPPercentage;
        public String Listener;
        public UInt32 WaitFlags;
        public UInt32 CameraAngle;
        public Byte FadeType;
        public Byte SoundExists;
        public Single CamHeightOffset;
        public Single TarHeightOffset;
        public UInt32 QuestEntry;
        public Single FadeDelay;
        public Vector3 FadeColor;
        public Int32 CameraID;
        public Int32 CamVidEffect;
        public Single FadeLength;
        public Single CamFieldOfView;
        public UInt16 CameraAnimation;
    
        // List definitions
        public List<AEntries> EntriesList;
        public List<AAnim> AnimList;
    
        // Class definitions    
        public class AEntries : AuroraStruct {
            // Field definitions
            public uint structid;
            public UInt32 Index;
            public String Active;
            public Byte IsChild;
            public String LinkComment;
            
        }
        
        public class AAnim : AuroraStruct {
            // Field definitions
            public uint structid;
            public String Participant;
            public UInt16 Animation;
            
        }
        
    }
    
    public class AStarting : AuroraStruct {
        // Field definitions
        public uint structid;
        public UInt32 Index;
        public String Active;
        
    }
    
    public class AStunt : AuroraStruct {
        // Field definitions
        public uint structid;
        public String Participant;
        public String StuntModel;
        
    }
    
}
