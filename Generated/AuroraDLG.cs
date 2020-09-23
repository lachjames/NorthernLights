using System;
using System.Collections.Generic;
using static AuroraEngine.GFFObject;
using UnityEngine;
using AuroraEngine;

[Serializable]public class AuroraDLG : AuroraStruct {
    // Field definitions
    [GFF("structid", Compatibility.BOTH, ExistsIn.BASE)] public uint structid;
    [GFF("DelayEntry", Compatibility.BOTH, ExistsIn.BASE)] public UInt32 DelayEntry;
    [GFF("DelayReply", Compatibility.BOTH, ExistsIn.BASE)] public UInt32 DelayReply;
    [GFF("NumWords", Compatibility.BOTH, ExistsIn.BASE)] public UInt32 NumWords;
    [GFF("EndConversation", Compatibility.BOTH, ExistsIn.BASE)] public String EndConversation;
    [GFF("EndConverAbort", Compatibility.BOTH, ExistsIn.BASE)] public String EndConverAbort;
    [GFF("Skippable", Compatibility.BOTH, ExistsIn.BASE)] public Byte Skippable;
    [GFF("CameraModel", Compatibility.BOTH, ExistsIn.BASE)] public String CameraModel;
    [GFF("VO_ID", Compatibility.BOTH, ExistsIn.BASE)] public CExoString VO_ID = new CExoString();
    [GFF("ConversationType", Compatibility.BOTH, ExistsIn.BASE)] public Int32 ConversationType;
    [GFF("ComputerType", Compatibility.BOTH, ExistsIn.BASE)] public Byte ComputerType;
    [GFF("OldHitCheck", Compatibility.BOTH, ExistsIn.BASE)] public Byte OldHitCheck;
    [GFF("AmbientTrack", Compatibility.BOTH, ExistsIn.BASE)] public String AmbientTrack;
    [GFF("UnequipItems", Compatibility.BOTH, ExistsIn.BASE)] public Byte UnequipItems;
    [GFF("AnimatedCut", Compatibility.BOTH, ExistsIn.BASE)] public Byte AnimatedCut;
    [GFF("UnequipHItem", Compatibility.BOTH, ExistsIn.BASE)] public Byte UnequipHItem;
    [GFF("NextNodeID", Compatibility.TSL, ExistsIn.BASE)] public Int32 NextNodeID;
    [GFF("DeletedVOFiles", Compatibility.TSL, ExistsIn.BASE)] public CExoString DeletedVOFiles = new CExoString();
    [GFF("PostProcOwner", Compatibility.TSL, ExistsIn.BASE)] public Int32 PostProcOwner;
    [GFF("AlienRaceOwner", Compatibility.TSL, ExistsIn.BASE)] public Int32 AlienRaceOwner;
    [GFF("RecordNoVO", Compatibility.TSL, ExistsIn.BASE)] public Int32 RecordNoVO;
    [GFF("EditorInfo", Compatibility.TSL, ExistsIn.BASE)] public CExoString EditorInfo = new CExoString();

    // List definitions
    [GFF("EntryList", Compatibility.BOTH, ExistsIn.BASE)] public List<AEntry> EntryList = new List<AEntry>();
    [GFF("ReplyList", Compatibility.BOTH, ExistsIn.BASE)] public List<AReply> ReplyList = new List<AReply>();
    [GFF("StartingList", Compatibility.BOTH, ExistsIn.BASE)] public List<AStarting> StartingList = new List<AStarting>();
    [GFF("StuntList", Compatibility.BOTH, ExistsIn.BASE)] public List<AStunt> StuntList = new List<AStunt>();

    // Class definitions    
    [Serializable]public class AEntry : AuroraStruct {
        // Field definitions
        [GFF("structid", Compatibility.BOTH, ExistsIn.BASE)] public uint structid;
        [GFF("Speaker", Compatibility.BOTH, ExistsIn.BASE)] public CExoString Speaker = new CExoString();
        [GFF("Text", Compatibility.BOTH, ExistsIn.BASE)] public CExoLocString Text = new CExoLocString();
        [GFF("VO_ResRef", Compatibility.BOTH, ExistsIn.BASE)] public String VO_ResRef;
        [GFF("Script", Compatibility.BOTH, ExistsIn.BASE)] public String Script;
        [GFF("Delay", Compatibility.BOTH, ExistsIn.BASE)] public UInt32 Delay;
        [GFF("Comment", Compatibility.BOTH, ExistsIn.BASE)] public CExoString Comment = new CExoString();
        [GFF("Sound", Compatibility.BOTH, ExistsIn.BASE)] public String Sound;
        [GFF("Quest", Compatibility.BOTH, ExistsIn.BASE)] public CExoString Quest = new CExoString();
        [GFF("PlotIndex", Compatibility.BOTH, ExistsIn.BASE)] public Int32 PlotIndex;
        [GFF("PlotXPPercentage", Compatibility.BOTH, ExistsIn.BASE)] public Single PlotXPPercentage;
        [GFF("Listener", Compatibility.BOTH, ExistsIn.BASE)] public CExoString Listener = new CExoString();
        [GFF("WaitFlags", Compatibility.BOTH, ExistsIn.BASE)] public UInt32 WaitFlags;
        [GFF("CameraAngle", Compatibility.BOTH, ExistsIn.BASE)] public UInt32 CameraAngle;
        [GFF("FadeType", Compatibility.BOTH, ExistsIn.BASE)] public Byte FadeType;
        [GFF("SoundExists", Compatibility.BOTH, ExistsIn.BASE)] public Byte SoundExists;
        [GFF("CamHeightOffset", Compatibility.BOTH, ExistsIn.BASE)] public Single CamHeightOffset;
        [GFF("TarHeightOffset", Compatibility.BOTH, ExistsIn.BASE)] public Single TarHeightOffset;
        [GFF("CameraID", Compatibility.BOTH, ExistsIn.BASE)] public Int32 CameraID;
        [GFF("CamVidEffect", Compatibility.BOTH, ExistsIn.BASE)] public Int32 CamVidEffect;
        [GFF("FadeLength", Compatibility.BOTH, ExistsIn.BASE)] public Single FadeLength;
        [GFF("FadeDelay", Compatibility.BOTH, ExistsIn.BASE)] public Single FadeDelay;
        [GFF("FadeColor", Compatibility.BOTH, ExistsIn.BASE)] public Vector3 FadeColor;
        [GFF("QuestEntry", Compatibility.BOTH, ExistsIn.BASE)] public UInt32 QuestEntry;
        [GFF("CamFieldOfView", Compatibility.BOTH, ExistsIn.BASE)] public Single CamFieldOfView;
        [GFF("CameraAnimation", Compatibility.BOTH, ExistsIn.BASE)] public UInt16 CameraAnimation;
        [GFF("Script2", Compatibility.TSL, ExistsIn.BASE)] public String Script2;
        [GFF("ActionParam1", Compatibility.TSL, ExistsIn.BASE)] public Int32 ActionParam1;
        [GFF("ActionParam2", Compatibility.TSL, ExistsIn.BASE)] public Int32 ActionParam2;
        [GFF("ActionParam3", Compatibility.TSL, ExistsIn.BASE)] public Int32 ActionParam3;
        [GFF("ActionParam4", Compatibility.TSL, ExistsIn.BASE)] public Int32 ActionParam4;
        [GFF("ActionParam5", Compatibility.TSL, ExistsIn.BASE)] public Int32 ActionParam5;
        [GFF("ActionParam1b", Compatibility.TSL, ExistsIn.BASE)] public Int32 ActionParam1b;
        [GFF("ActionParam2b", Compatibility.TSL, ExistsIn.BASE)] public Int32 ActionParam2b;
        [GFF("ActionParam3b", Compatibility.TSL, ExistsIn.BASE)] public Int32 ActionParam3b;
        [GFF("ActionParam4b", Compatibility.TSL, ExistsIn.BASE)] public Int32 ActionParam4b;
        [GFF("ActionParam5b", Compatibility.TSL, ExistsIn.BASE)] public Int32 ActionParam5b;
        [GFF("ActionParamStrA", Compatibility.TSL, ExistsIn.BASE)] public CExoString ActionParamStrA = new CExoString();
        [GFF("ActionParamStrB", Compatibility.TSL, ExistsIn.BASE)] public CExoString ActionParamStrB = new CExoString();
        [GFF("NodeUnskippable", Compatibility.TSL, ExistsIn.BASE)] public Int32 NodeUnskippable;
        [GFF("PostProcNode", Compatibility.TSL, ExistsIn.BASE)] public Int32 PostProcNode;
        [GFF("AlienRaceNode", Compatibility.TSL, ExistsIn.BASE)] public Int32 AlienRaceNode;
        [GFF("Emotion", Compatibility.TSL, ExistsIn.BASE)] public Int32 Emotion;
        [GFF("RecordVO", Compatibility.TSL, ExistsIn.BASE)] public Int32 RecordVO;
        [GFF("RecordNoVOOverri", Compatibility.TSL, ExistsIn.BASE)] public Int32 RecordNoVOOverri;
        [GFF("FacialAnim", Compatibility.TSL, ExistsIn.BASE)] public Int32 FacialAnim;
        [GFF("NodeID", Compatibility.TSL, ExistsIn.BASE)] public Int32 NodeID;
        [GFF("VOTextChanged", Compatibility.TSL, ExistsIn.BASE)] public Byte VOTextChanged;
        [GFF("Changed", Compatibility.TSL, ExistsIn.BASE)] public Byte Changed;
        [GFF("RecordNoOverri", Compatibility.TSL, ExistsIn.BASE)] public Int32 RecordNoOverri;
    
        // List definitions
        [GFF("AnimList", Compatibility.BOTH, ExistsIn.BASE)] public List<AAnim> AnimList = new List<AAnim>();
        [GFF("RepliesList", Compatibility.BOTH, ExistsIn.BASE)] public List<AReplies> RepliesList = new List<AReplies>();
    
        // Class definitions    
        [Serializable]public class AAnim : AuroraStruct {
            // Field definitions
            [GFF("structid", Compatibility.BOTH, ExistsIn.BASE)] public uint structid;
            [GFF("Participant", Compatibility.BOTH, ExistsIn.BASE)] public CExoString Participant = new CExoString();
            [GFF("Animation", Compatibility.BOTH, ExistsIn.BASE)] public UInt16 Animation;
            
        }
        
        [Serializable]public class AReplies : AuroraStruct {
            // Field definitions
            [GFF("structid", Compatibility.BOTH, ExistsIn.BASE)] public uint structid;
            [GFF("Index", Compatibility.BOTH, ExistsIn.BASE)] public UInt32 Index;
            [GFF("Active", Compatibility.BOTH, ExistsIn.BASE)] public String Active;
            [GFF("IsChild", Compatibility.BOTH, ExistsIn.BASE)] public Byte IsChild;
            [GFF("LinkComment", Compatibility.BOTH, ExistsIn.BASE)] public CExoString LinkComment = new CExoString();
            [GFF("Active2", Compatibility.TSL, ExistsIn.BASE)] public String Active2;
            [GFF("Param1", Compatibility.TSL, ExistsIn.BASE)] public Int32 Param1;
            [GFF("Param2", Compatibility.TSL, ExistsIn.BASE)] public Int32 Param2;
            [GFF("Param3", Compatibility.TSL, ExistsIn.BASE)] public Int32 Param3;
            [GFF("Param4", Compatibility.TSL, ExistsIn.BASE)] public Int32 Param4;
            [GFF("Param5", Compatibility.TSL, ExistsIn.BASE)] public Int32 Param5;
            [GFF("Param1b", Compatibility.TSL, ExistsIn.BASE)] public Int32 Param1b;
            [GFF("Param2b", Compatibility.TSL, ExistsIn.BASE)] public Int32 Param2b;
            [GFF("Param3b", Compatibility.TSL, ExistsIn.BASE)] public Int32 Param3b;
            [GFF("Param4b", Compatibility.TSL, ExistsIn.BASE)] public Int32 Param4b;
            [GFF("Param5b", Compatibility.TSL, ExistsIn.BASE)] public Int32 Param5b;
            [GFF("Not", Compatibility.TSL, ExistsIn.BASE)] public Byte Not;
            [GFF("Not2", Compatibility.TSL, ExistsIn.BASE)] public Byte Not2;
            [GFF("Logic", Compatibility.TSL, ExistsIn.BASE)] public Int32 Logic;
            [GFF("ParamStrA", Compatibility.TSL, ExistsIn.BASE)] public CExoString ParamStrA = new CExoString();
            [GFF("ParamStrB", Compatibility.TSL, ExistsIn.BASE)] public CExoString ParamStrB = new CExoString();
            
        }
        
    }
    
    [Serializable]public class AReply : AuroraStruct {
        // Field definitions
        [GFF("structid", Compatibility.BOTH, ExistsIn.BASE)] public uint structid;
        [GFF("Text", Compatibility.BOTH, ExistsIn.BASE)] public CExoLocString Text = new CExoLocString();
        [GFF("VO_ResRef", Compatibility.BOTH, ExistsIn.BASE)] public String VO_ResRef;
        [GFF("Script", Compatibility.BOTH, ExistsIn.BASE)] public String Script;
        [GFF("Delay", Compatibility.BOTH, ExistsIn.BASE)] public UInt32 Delay;
        [GFF("Comment", Compatibility.BOTH, ExistsIn.BASE)] public CExoString Comment = new CExoString();
        [GFF("Sound", Compatibility.BOTH, ExistsIn.BASE)] public String Sound;
        [GFF("Quest", Compatibility.BOTH, ExistsIn.BASE)] public CExoString Quest = new CExoString();
        [GFF("PlotIndex", Compatibility.BOTH, ExistsIn.BASE)] public Int32 PlotIndex;
        [GFF("PlotXPPercentage", Compatibility.BOTH, ExistsIn.BASE)] public Single PlotXPPercentage;
        [GFF("Listener", Compatibility.BOTH, ExistsIn.BASE)] public CExoString Listener = new CExoString();
        [GFF("WaitFlags", Compatibility.BOTH, ExistsIn.BASE)] public UInt32 WaitFlags;
        [GFF("CameraAngle", Compatibility.BOTH, ExistsIn.BASE)] public UInt32 CameraAngle;
        [GFF("FadeType", Compatibility.BOTH, ExistsIn.BASE)] public Byte FadeType;
        [GFF("SoundExists", Compatibility.BOTH, ExistsIn.BASE)] public Byte SoundExists;
        [GFF("CamHeightOffset", Compatibility.BOTH, ExistsIn.BASE)] public Single CamHeightOffset;
        [GFF("TarHeightOffset", Compatibility.BOTH, ExistsIn.BASE)] public Single TarHeightOffset;
        [GFF("QuestEntry", Compatibility.BOTH, ExistsIn.BASE)] public UInt32 QuestEntry;
        [GFF("FadeDelay", Compatibility.BOTH, ExistsIn.BASE)] public Single FadeDelay;
        [GFF("FadeColor", Compatibility.BOTH, ExistsIn.BASE)] public Vector3 FadeColor;
        [GFF("CameraID", Compatibility.BOTH, ExistsIn.BASE)] public Int32 CameraID;
        [GFF("CamVidEffect", Compatibility.BOTH, ExistsIn.BASE)] public Int32 CamVidEffect;
        [GFF("FadeLength", Compatibility.BOTH, ExistsIn.BASE)] public Single FadeLength;
        [GFF("CamFieldOfView", Compatibility.BOTH, ExistsIn.BASE)] public Single CamFieldOfView;
        [GFF("CameraAnimation", Compatibility.BOTH, ExistsIn.BASE)] public UInt16 CameraAnimation;
        [GFF("Script2", Compatibility.TSL, ExistsIn.BASE)] public String Script2;
        [GFF("ActionParam1", Compatibility.TSL, ExistsIn.BASE)] public Int32 ActionParam1;
        [GFF("ActionParam2", Compatibility.TSL, ExistsIn.BASE)] public Int32 ActionParam2;
        [GFF("ActionParam3", Compatibility.TSL, ExistsIn.BASE)] public Int32 ActionParam3;
        [GFF("ActionParam4", Compatibility.TSL, ExistsIn.BASE)] public Int32 ActionParam4;
        [GFF("ActionParam5", Compatibility.TSL, ExistsIn.BASE)] public Int32 ActionParam5;
        [GFF("ActionParam1b", Compatibility.TSL, ExistsIn.BASE)] public Int32 ActionParam1b;
        [GFF("ActionParam2b", Compatibility.TSL, ExistsIn.BASE)] public Int32 ActionParam2b;
        [GFF("ActionParam3b", Compatibility.TSL, ExistsIn.BASE)] public Int32 ActionParam3b;
        [GFF("ActionParam4b", Compatibility.TSL, ExistsIn.BASE)] public Int32 ActionParam4b;
        [GFF("ActionParam5b", Compatibility.TSL, ExistsIn.BASE)] public Int32 ActionParam5b;
        [GFF("ActionParamStrA", Compatibility.TSL, ExistsIn.BASE)] public CExoString ActionParamStrA = new CExoString();
        [GFF("ActionParamStrB", Compatibility.TSL, ExistsIn.BASE)] public CExoString ActionParamStrB = new CExoString();
        [GFF("NodeUnskippable", Compatibility.TSL, ExistsIn.BASE)] public Int32 NodeUnskippable;
        [GFF("PostProcNode", Compatibility.TSL, ExistsIn.BASE)] public Int32 PostProcNode;
        [GFF("AlienRaceNode", Compatibility.TSL, ExistsIn.BASE)] public Int32 AlienRaceNode;
        [GFF("Emotion", Compatibility.TSL, ExistsIn.BASE)] public Int32 Emotion;
        [GFF("RecordVO", Compatibility.TSL, ExistsIn.BASE)] public Int32 RecordVO;
        [GFF("RecordNoVOOverri", Compatibility.TSL, ExistsIn.BASE)] public Int32 RecordNoVOOverri;
        [GFF("FacialAnim", Compatibility.TSL, ExistsIn.BASE)] public Int32 FacialAnim;
        [GFF("Changed", Compatibility.TSL, ExistsIn.BASE)] public Byte Changed;
        [GFF("NodeID", Compatibility.TSL, ExistsIn.BASE)] public Int32 NodeID;
        [GFF("RecordNoOverri", Compatibility.TSL, ExistsIn.BASE)] public Int32 RecordNoOverri;
        [GFF("VOTextChanged", Compatibility.TSL, ExistsIn.BASE)] public Int32 VOTextChanged;
    
        // List definitions
        [GFF("EntriesList", Compatibility.BOTH, ExistsIn.BASE)] public List<AEntries> EntriesList = new List<AEntries>();
        [GFF("AnimList", Compatibility.BOTH, ExistsIn.BASE)] public List<AAnim> AnimList = new List<AAnim>();
    
        // Class definitions    
        [Serializable]public class AEntries : AuroraStruct {
            // Field definitions
            [GFF("structid", Compatibility.BOTH, ExistsIn.BASE)] public uint structid;
            [GFF("Index", Compatibility.BOTH, ExistsIn.BASE)] public UInt32 Index;
            [GFF("Active", Compatibility.BOTH, ExistsIn.BASE)] public String Active;
            [GFF("IsChild", Compatibility.BOTH, ExistsIn.BASE)] public Byte IsChild;
            [GFF("LinkComment", Compatibility.BOTH, ExistsIn.BASE)] public CExoString LinkComment = new CExoString();
            [GFF("Active2", Compatibility.TSL, ExistsIn.BASE)] public String Active2;
            [GFF("Param1", Compatibility.TSL, ExistsIn.BASE)] public Int32 Param1;
            [GFF("Param2", Compatibility.TSL, ExistsIn.BASE)] public Int32 Param2;
            [GFF("Param3", Compatibility.TSL, ExistsIn.BASE)] public Int32 Param3;
            [GFF("Param4", Compatibility.TSL, ExistsIn.BASE)] public Int32 Param4;
            [GFF("Param5", Compatibility.TSL, ExistsIn.BASE)] public Int32 Param5;
            [GFF("Param1b", Compatibility.TSL, ExistsIn.BASE)] public Int32 Param1b;
            [GFF("Param2b", Compatibility.TSL, ExistsIn.BASE)] public Int32 Param2b;
            [GFF("Param3b", Compatibility.TSL, ExistsIn.BASE)] public Int32 Param3b;
            [GFF("Param4b", Compatibility.TSL, ExistsIn.BASE)] public Int32 Param4b;
            [GFF("Param5b", Compatibility.TSL, ExistsIn.BASE)] public Int32 Param5b;
            [GFF("Not", Compatibility.TSL, ExistsIn.BASE)] public Byte Not;
            [GFF("Not2", Compatibility.TSL, ExistsIn.BASE)] public Byte Not2;
            [GFF("Logic", Compatibility.TSL, ExistsIn.BASE)] public Int32 Logic;
            [GFF("ParamStrA", Compatibility.TSL, ExistsIn.BASE)] public CExoString ParamStrA = new CExoString();
            [GFF("ParamStrB", Compatibility.TSL, ExistsIn.BASE)] public CExoString ParamStrB = new CExoString();
            
        }
        
        [Serializable]public class AAnim : AuroraStruct {
            // Field definitions
            [GFF("structid", Compatibility.BOTH, ExistsIn.BASE)] public uint structid;
            [GFF("Participant", Compatibility.BOTH, ExistsIn.BASE)] public CExoString Participant = new CExoString();
            [GFF("Animation", Compatibility.BOTH, ExistsIn.BASE)] public UInt16 Animation;
            
        }
        
    }
    
    [Serializable]public class AStarting : AuroraStruct {
        // Field definitions
        [GFF("structid", Compatibility.BOTH, ExistsIn.BASE)] public uint structid;
        [GFF("Index", Compatibility.BOTH, ExistsIn.BASE)] public UInt32 Index;
        [GFF("Active", Compatibility.BOTH, ExistsIn.BASE)] public String Active;
        [GFF("Active2", Compatibility.TSL, ExistsIn.BASE)] public String Active2;
        [GFF("Param1", Compatibility.TSL, ExistsIn.BASE)] public Int32 Param1;
        [GFF("Param2", Compatibility.TSL, ExistsIn.BASE)] public Int32 Param2;
        [GFF("Param3", Compatibility.TSL, ExistsIn.BASE)] public Int32 Param3;
        [GFF("Param4", Compatibility.TSL, ExistsIn.BASE)] public Int32 Param4;
        [GFF("Param5", Compatibility.TSL, ExistsIn.BASE)] public Int32 Param5;
        [GFF("Param1b", Compatibility.TSL, ExistsIn.BASE)] public Int32 Param1b;
        [GFF("Param2b", Compatibility.TSL, ExistsIn.BASE)] public Int32 Param2b;
        [GFF("Param3b", Compatibility.TSL, ExistsIn.BASE)] public Int32 Param3b;
        [GFF("Param4b", Compatibility.TSL, ExistsIn.BASE)] public Int32 Param4b;
        [GFF("Param5b", Compatibility.TSL, ExistsIn.BASE)] public Int32 Param5b;
        [GFF("Not", Compatibility.TSL, ExistsIn.BASE)] public Byte Not;
        [GFF("Not2", Compatibility.TSL, ExistsIn.BASE)] public Byte Not2;
        [GFF("Logic", Compatibility.TSL, ExistsIn.BASE)] public Int32 Logic;
        [GFF("ParamStrA", Compatibility.TSL, ExistsIn.BASE)] public CExoString ParamStrA = new CExoString();
        [GFF("ParamStrB", Compatibility.TSL, ExistsIn.BASE)] public CExoString ParamStrB = new CExoString();
        [GFF("IsChild", Compatibility.TSL, ExistsIn.BASE)] public Byte IsChild;
        
    }
    
    [Serializable]public class AStunt : AuroraStruct {
        // Field definitions
        [GFF("structid", Compatibility.BOTH, ExistsIn.BASE)] public uint structid;
        [GFF("Participant", Compatibility.BOTH, ExistsIn.BASE)] public CExoString Participant = new CExoString();
        [GFF("StuntModel", Compatibility.BOTH, ExistsIn.BASE)] public String StuntModel;
        
    }
    
}
