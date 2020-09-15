using System;
using System.Collections.Generic;
using static AuroraEngine.GFFObject;
using UnityEngine;

public class AuroraUTE : AuroraStruct {
    // Field definitions
    public uint structid;
    public String Tag;
    public CExoLocString LocalizedName;
    public String TemplateResRef;
    public Byte Active;
    public Int32 Difficulty;
    public Int32 DifficultyIndex;
    public UInt32 Faction;
    public Int32 MaxCreatures;
    public Byte PlayerOnly;
    public Int32 RecCreatures;
    public Byte Reset;
    public Int32 ResetTime;
    public Int32 Respawns;
    public Int32 SpawnOption;
    public String OnEntered;
    public String OnExit;
    public String OnExhausted;
    public String OnHeartbeat;
    public String OnUserDefined;
    public Byte PaletteID;
    public String Comment;

    // List definitions
    public List<ACreature> CreatureList;

    // Class definitions    
    public class ACreature : AuroraStruct {
        // Field definitions
        public uint structid;
        public Int32 Appearance;
        public Single CR;
        public String ResRef;
        public Byte SingleSpawn;
        
    }
    
}
