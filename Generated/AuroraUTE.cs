using System;
using System.Collections.Generic;
using static AuroraEngine.GFFObject;
using UnityEngine;
using AuroraEngine;

[Serializable]public class AuroraUTE : AuroraStruct {
    // Field definitions
    [GFF("structid")] public uint structid;
    [GFF("Tag")] public CExoString Tag;
    [GFF("LocalizedName")] public CExoLocString LocalizedName;
    [GFF("TemplateResRef")] public String TemplateResRef;
    [GFF("Active")] public Byte Active;
    [GFF("Difficulty")] public Int32 Difficulty;
    [GFF("DifficultyIndex")] public Int32 DifficultyIndex;
    [GFF("Faction")] public UInt32 Faction;
    [GFF("MaxCreatures")] public Int32 MaxCreatures;
    [GFF("PlayerOnly")] public Byte PlayerOnly;
    [GFF("RecCreatures")] public Int32 RecCreatures;
    [GFF("Reset")] public Byte Reset;
    [GFF("ResetTime")] public Int32 ResetTime;
    [GFF("Respawns")] public Int32 Respawns;
    [GFF("SpawnOption")] public Int32 SpawnOption;
    [GFF("OnEntered")] public String OnEntered;
    [GFF("OnExit")] public String OnExit;
    [GFF("OnExhausted")] public String OnExhausted;
    [GFF("OnHeartbeat")] public String OnHeartbeat;
    [GFF("OnUserDefined")] public String OnUserDefined;
    [GFF("PaletteID")] public Byte PaletteID;
    [GFF("Comment")] public CExoString Comment;

    // List definitions
    [GFF("CreatureList")] public List<ACreature> CreatureList = new List<ACreature>();

    // Class definitions    
    [Serializable]public class ACreature : AuroraStruct {
        // Field definitions
        [GFF("structid")] public uint structid;
        [GFF("Appearance")] public Int32 Appearance;
        [GFF("CR")] public Single CR;
        [GFF("ResRef")] public String ResRef;
        [GFF("SingleSpawn")] public Byte SingleSpawn;
        
    }
    
}
