using System;
using System.Collections.Generic;
using static AuroraEngine.GFFObject;
using UnityEngine;
using AuroraEngine;

[Serializable]public class AuroraUTE : AuroraStruct {
    // Field definitions
    [GFF("structid", Compatibility.BOTH, ExistsIn.BASE)] public uint structid;
    [GFF("Tag", Compatibility.BOTH, ExistsIn.BASE)] public CExoString Tag;
    [GFF("LocalizedName", Compatibility.BOTH, ExistsIn.BASE)] public CExoLocString LocalizedName;
    [GFF("TemplateResRef", Compatibility.BOTH, ExistsIn.BASE)] public String TemplateResRef;
    [GFF("Active", Compatibility.BOTH, ExistsIn.BASE)] public Byte Active;
    [GFF("Difficulty", Compatibility.BOTH, ExistsIn.BASE)] public Int32 Difficulty;
    [GFF("DifficultyIndex", Compatibility.BOTH, ExistsIn.BASE)] public Int32 DifficultyIndex;
    [GFF("Faction", Compatibility.BOTH, ExistsIn.BASE)] public UInt32 Faction;
    [GFF("MaxCreatures", Compatibility.BOTH, ExistsIn.BASE)] public Int32 MaxCreatures;
    [GFF("PlayerOnly", Compatibility.BOTH, ExistsIn.BASE)] public Byte PlayerOnly;
    [GFF("RecCreatures", Compatibility.BOTH, ExistsIn.BASE)] public Int32 RecCreatures;
    [GFF("Reset", Compatibility.BOTH, ExistsIn.BASE)] public Byte Reset;
    [GFF("ResetTime", Compatibility.BOTH, ExistsIn.BASE)] public Int32 ResetTime;
    [GFF("Respawns", Compatibility.BOTH, ExistsIn.BASE)] public Int32 Respawns;
    [GFF("SpawnOption", Compatibility.BOTH, ExistsIn.BASE)] public Int32 SpawnOption;
    [GFF("OnEntered", Compatibility.BOTH, ExistsIn.BASE)] public String OnEntered;
    [GFF("OnExit", Compatibility.BOTH, ExistsIn.BASE)] public String OnExit;
    [GFF("OnExhausted", Compatibility.BOTH, ExistsIn.BASE)] public String OnExhausted;
    [GFF("OnHeartbeat", Compatibility.BOTH, ExistsIn.BASE)] public String OnHeartbeat;
    [GFF("OnUserDefined", Compatibility.BOTH, ExistsIn.BASE)] public String OnUserDefined;
    [GFF("PaletteID", Compatibility.BOTH, ExistsIn.BASE)] public Byte PaletteID;
    [GFF("Comment", Compatibility.BOTH, ExistsIn.BASE)] public CExoString Comment;

    // List definitions
    [GFF("CreatureList", Compatibility.BOTH, ExistsIn.BASE)] public List<ACreature> CreatureList = new List<ACreature>();

    // Class definitions    
    [Serializable]public class ACreature : AuroraStruct {
        // Field definitions
        [GFF("structid", Compatibility.BOTH, ExistsIn.BASE)] public uint structid;
        [GFF("Appearance", Compatibility.BOTH, ExistsIn.BASE)] public Int32 Appearance;
        [GFF("CR", Compatibility.BOTH, ExistsIn.BASE)] public Single CR;
        [GFF("ResRef", Compatibility.BOTH, ExistsIn.BASE)] public String ResRef;
        [GFF("SingleSpawn", Compatibility.BOTH, ExistsIn.BASE)] public Byte SingleSpawn;
        [GFF("GuaranteedCount", Compatibility.KotOR, ExistsIn.BASE)] public Int32 GuaranteedCount;
        
    }
    
}
