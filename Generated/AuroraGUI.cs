using System;
using System.Collections.Generic;
using static AuroraEngine.GFFObject;
using UnityEngine;
using AuroraEngine;

[Serializable]public class AuroraGUI : AuroraStruct {
    // Field definitions
    [GFF("structid", Compatibility.BOTH, ExistsIn.BASE)] public uint structid;
    [GFF("CONTROLTYPE", Compatibility.BOTH, ExistsIn.BASE)] public Int32 CONTROLTYPE;
    [GFF("Obj_Locked", Compatibility.BOTH, ExistsIn.BASE)] public Byte Obj_Locked;
    [GFF("TAG", Compatibility.BOTH, ExistsIn.BASE)] public CExoString TAG;
    [GFF("Obj_ParentID", Compatibility.BOTH, ExistsIn.BASE)] public Int32 Obj_ParentID;
    [GFF("ALPHA", Compatibility.BOTH, ExistsIn.BASE)] public Single ALPHA;
    [GFF("COLOR", Compatibility.BOTH, ExistsIn.BASE)] public Vector3 COLOR;
    [GFF("Obj_Layer", Compatibility.TSL, ExistsIn.BASE)] public Int32 Obj_Layer;

    // List definitions
    [GFF("CONTROLS", Compatibility.BOTH, ExistsIn.BASE)] public List<ACONTROLS> CONTROLS = new List<ACONTROLS>();
    [GFF("EXTENT", Compatibility.BOTH, ExistsIn.BASE)] public List<AEXTENT> EXTENT = new List<AEXTENT>();
    [GFF("BORDER", Compatibility.BOTH, ExistsIn.BASE)] public List<ABORDER> BORDER = new List<ABORDER>();

    // Class definitions    
    [Serializable]public class ACONTROLS : AuroraStruct {
        // Field definitions
        [GFF("structid", Compatibility.BOTH, ExistsIn.BASE)] public uint structid;
        [GFF("CONTROLTYPE", Compatibility.BOTH, ExistsIn.BASE)] public Int32 CONTROLTYPE;
        [GFF("ID", Compatibility.BOTH, ExistsIn.BASE)] public Int32 ID;
        [GFF("Obj_Locked", Compatibility.BOTH, ExistsIn.BASE)] public Byte Obj_Locked;
        [GFF("Obj_Parent", Compatibility.BOTH, ExistsIn.BASE)] public CExoString Obj_Parent;
        [GFF("TAG", Compatibility.BOTH, ExistsIn.BASE)] public CExoString TAG;
        [GFF("Obj_ParentID", Compatibility.BOTH, ExistsIn.BASE)] public Int32 Obj_ParentID;
        [GFF("COLOR", Compatibility.BOTH, ExistsIn.BASE)] public Vector3 COLOR;
        [GFF("LOOPING", Compatibility.BOTH, ExistsIn.BASE)] public Byte LOOPING;
        [GFF("PADDING", Compatibility.BOTH, ExistsIn.BASE)] public Int32 PADDING;
        [GFF("LEFTSCROLLBAR", Compatibility.BOTH, ExistsIn.BASE)] public Byte LEFTSCROLLBAR;
        [GFF("MAXVALUE", Compatibility.BOTH, ExistsIn.BASE)] public Int32 MAXVALUE;
        [GFF("CURVALUE", Compatibility.BOTH, ExistsIn.BASE)] public Int32 CURVALUE;
        [GFF("Obj_Layer", Compatibility.TSL, ExistsIn.BASE)] public Int32 Obj_Layer;
        [GFF("STARTFROMLEFT", Compatibility.BOTH, ExistsIn.BASE)] public Byte STARTFROMLEFT;
        [GFF("ISSELECTED", Compatibility.BOTH, ExistsIn.BASE)] public Byte ISSELECTED;
        [GFF("PARENTID", Compatibility.TSL, ExistsIn.BASE)] public Int32 PARENTID;
    
        // List definitions
        [GFF("EXTENT", Compatibility.BOTH, ExistsIn.BASE)] public List<AEXTENT> EXTENT = new List<AEXTENT>();
        [GFF("BORDER", Compatibility.BOTH, ExistsIn.BASE)] public List<ABORDER> BORDER = new List<ABORDER>();
        [GFF("TEXT", Compatibility.BOTH, ExistsIn.BASE)] public List<ATEXT> TEXT = new List<ATEXT>();
        [GFF("HILIGHT", Compatibility.BOTH, ExistsIn.BASE)] public List<AHILIGHT> HILIGHT = new List<AHILIGHT>();
        [GFF("MOVETO", Compatibility.BOTH, ExistsIn.BASE)] public List<AMOVETO> MOVETO = new List<AMOVETO>();
        [GFF("PROTOITEM", Compatibility.BOTH, ExistsIn.BASE)] public List<APROTOITEM> PROTOITEM = new List<APROTOITEM>();
        [GFF("SCROLLBAR", Compatibility.BOTH, ExistsIn.BASE)] public List<ASCROLLBAR> SCROLLBAR = new List<ASCROLLBAR>();
        [GFF("THUMB", Compatibility.BOTH, ExistsIn.BASE)] public List<ATHUMB> THUMB = new List<ATHUMB>();
        [GFF("PROGRESS", Compatibility.BOTH, ExistsIn.BASE)] public List<APROGRESS> PROGRESS = new List<APROGRESS>();
        [GFF("SELECTED", Compatibility.BOTH, ExistsIn.BASE)] public List<ASELECTED> SELECTED = new List<ASELECTED>();
        [GFF("HILIGHTSELECTED", Compatibility.BOTH, ExistsIn.BASE)] public List<AHILIGHTSELECTED> HILIGHTSELECTED = new List<AHILIGHTSELECTED>();
    
        // Class definitions    
        [Serializable]public class AEXTENT : AuroraStruct {
            // Field definitions
            [GFF("structid", Compatibility.BOTH, ExistsIn.BASE)] public uint structid;
            [GFF("LEFT", Compatibility.BOTH, ExistsIn.BASE)] public Int32 LEFT;
            [GFF("TOP", Compatibility.BOTH, ExistsIn.BASE)] public Int32 TOP;
            [GFF("WIDTH", Compatibility.BOTH, ExistsIn.BASE)] public Int32 WIDTH;
            [GFF("HEIGHT", Compatibility.BOTH, ExistsIn.BASE)] public Int32 HEIGHT;
            
        }
        
        [Serializable]public class ABORDER : AuroraStruct {
            // Field definitions
            [GFF("structid", Compatibility.BOTH, ExistsIn.BASE)] public uint structid;
            [GFF("CORNER", Compatibility.BOTH, ExistsIn.BASE)] public String CORNER;
            [GFF("EDGE", Compatibility.BOTH, ExistsIn.BASE)] public String EDGE;
            [GFF("FILL", Compatibility.BOTH, ExistsIn.BASE)] public String FILL;
            [GFF("FILLSTYLE", Compatibility.BOTH, ExistsIn.BASE)] public Int32 FILLSTYLE;
            [GFF("DIMENSION", Compatibility.BOTH, ExistsIn.BASE)] public Int32 DIMENSION;
            [GFF("INNEROFFSET", Compatibility.BOTH, ExistsIn.BASE)] public Int32 INNEROFFSET;
            [GFF("COLOR", Compatibility.BOTH, ExistsIn.BASE)] public Vector3 COLOR;
            [GFF("PULSING", Compatibility.BOTH, ExistsIn.BASE)] public Byte PULSING;
            [GFF("INNEROFFSETY", Compatibility.KotOR, ExistsIn.BASE)] public Int32 INNEROFFSETY;
            
        }
        
        [Serializable]public class ATEXT : AuroraStruct {
            // Field definitions
            [GFF("structid", Compatibility.BOTH, ExistsIn.BASE)] public uint structid;
            [GFF("ALIGNMENT", Compatibility.BOTH, ExistsIn.BASE)] public Int32 ALIGNMENT;
            [GFF("COLOR", Compatibility.BOTH, ExistsIn.BASE)] public Vector3 COLOR;
            [GFF("FONT", Compatibility.BOTH, ExistsIn.BASE)] public String FONT;
            [GFF("STRREF", Compatibility.BOTH, ExistsIn.BASE)] public UInt32 STRREF;
            [GFF("PULSING", Compatibility.BOTH, ExistsIn.BASE)] public Byte PULSING;
            [GFF("TEXT", Compatibility.KotOR, ExistsIn.BASE)] public CExoString TEXT;
            
        }
        
        [Serializable]public class AHILIGHT : AuroraStruct {
            // Field definitions
            [GFF("structid", Compatibility.BOTH, ExistsIn.BASE)] public uint structid;
            [GFF("CORNER", Compatibility.BOTH, ExistsIn.BASE)] public String CORNER;
            [GFF("EDGE", Compatibility.BOTH, ExistsIn.BASE)] public String EDGE;
            [GFF("FILL", Compatibility.BOTH, ExistsIn.BASE)] public String FILL;
            [GFF("FILLSTYLE", Compatibility.BOTH, ExistsIn.BASE)] public Int32 FILLSTYLE;
            [GFF("DIMENSION", Compatibility.BOTH, ExistsIn.BASE)] public Int32 DIMENSION;
            [GFF("INNEROFFSET", Compatibility.BOTH, ExistsIn.BASE)] public Int32 INNEROFFSET;
            [GFF("COLOR", Compatibility.BOTH, ExistsIn.BASE)] public Vector3 COLOR;
            [GFF("PULSING", Compatibility.BOTH, ExistsIn.BASE)] public Byte PULSING;
            [GFF("INNEROFFSETY", Compatibility.KotOR, ExistsIn.BASE)] public Int32 INNEROFFSETY;
            
        }
        
        [Serializable]public class AMOVETO : AuroraStruct {
            // Field definitions
            [GFF("structid", Compatibility.BOTH, ExistsIn.BASE)] public uint structid;
            [GFF("DOWN", Compatibility.BOTH, ExistsIn.BASE)] public Int32 DOWN;
            [GFF("LEFT", Compatibility.BOTH, ExistsIn.BASE)] public Int32 LEFT;
            [GFF("RIGHT", Compatibility.BOTH, ExistsIn.BASE)] public Int32 RIGHT;
            [GFF("UP", Compatibility.BOTH, ExistsIn.BASE)] public Int32 UP;
            
        }
        
        [Serializable]public class APROTOITEM : AuroraStruct {
            // Field definitions
            [GFF("structid", Compatibility.BOTH, ExistsIn.BASE)] public uint structid;
            [GFF("CONTROLTYPE", Compatibility.BOTH, ExistsIn.BASE)] public Int32 CONTROLTYPE;
            [GFF("Obj_Parent", Compatibility.BOTH, ExistsIn.BASE)] public CExoString Obj_Parent;
            [GFF("TAG", Compatibility.BOTH, ExistsIn.BASE)] public CExoString TAG;
            [GFF("Obj_ParentID", Compatibility.BOTH, ExistsIn.BASE)] public Int32 Obj_ParentID;
        
            // List definitions
            [GFF("EXTENT", Compatibility.BOTH, ExistsIn.BASE)] public List<AEXTENT> EXTENT = new List<AEXTENT>();
            [GFF("BORDER", Compatibility.BOTH, ExistsIn.BASE)] public List<ABORDER> BORDER = new List<ABORDER>();
            [GFF("TEXT", Compatibility.BOTH, ExistsIn.BASE)] public List<ATEXT> TEXT = new List<ATEXT>();
        
            // Class definitions    
            [Serializable]public class AEXTENT : AuroraStruct {
                // Field definitions
                [GFF("structid", Compatibility.BOTH, ExistsIn.BASE)] public uint structid;
                [GFF("LEFT", Compatibility.BOTH, ExistsIn.BASE)] public Int32 LEFT;
                [GFF("TOP", Compatibility.BOTH, ExistsIn.BASE)] public Int32 TOP;
                [GFF("WIDTH", Compatibility.BOTH, ExistsIn.BASE)] public Int32 WIDTH;
                [GFF("HEIGHT", Compatibility.BOTH, ExistsIn.BASE)] public Int32 HEIGHT;
                
            }
            
            [Serializable]public class ABORDER : AuroraStruct {
                // Field definitions
                [GFF("structid", Compatibility.BOTH, ExistsIn.BASE)] public uint structid;
                [GFF("CORNER", Compatibility.BOTH, ExistsIn.BASE)] public String CORNER;
                [GFF("EDGE", Compatibility.BOTH, ExistsIn.BASE)] public String EDGE;
                [GFF("FILL", Compatibility.BOTH, ExistsIn.BASE)] public String FILL;
                [GFF("FILLSTYLE", Compatibility.BOTH, ExistsIn.BASE)] public Int32 FILLSTYLE;
                [GFF("DIMENSION", Compatibility.BOTH, ExistsIn.BASE)] public Int32 DIMENSION;
                [GFF("INNEROFFSET", Compatibility.BOTH, ExistsIn.BASE)] public Int32 INNEROFFSET;
                [GFF("COLOR", Compatibility.BOTH, ExistsIn.BASE)] public Vector3 COLOR;
                [GFF("PULSING", Compatibility.BOTH, ExistsIn.BASE)] public Byte PULSING;
                [GFF("INNEROFFSETY", Compatibility.KotOR, ExistsIn.BASE)] public Int32 INNEROFFSETY;
                
            }
            
            [Serializable]public class ATEXT : AuroraStruct {
                // Field definitions
                [GFF("structid", Compatibility.BOTH, ExistsIn.BASE)] public uint structid;
                [GFF("ALIGNMENT", Compatibility.BOTH, ExistsIn.BASE)] public Int32 ALIGNMENT;
                [GFF("COLOR", Compatibility.BOTH, ExistsIn.BASE)] public Vector3 COLOR;
                [GFF("FONT", Compatibility.BOTH, ExistsIn.BASE)] public String FONT;
                [GFF("TEXT", Compatibility.BOTH, ExistsIn.BASE)] public CExoString TEXT;
                [GFF("STRREF", Compatibility.BOTH, ExistsIn.BASE)] public UInt32 STRREF;
                [GFF("PULSING", Compatibility.BOTH, ExistsIn.BASE)] public Byte PULSING;
                
            }
            
        }
        
        [Serializable]public class ASCROLLBAR : AuroraStruct {
            // Field definitions
            [GFF("structid", Compatibility.BOTH, ExistsIn.BASE)] public uint structid;
            [GFF("CONTROLTYPE", Compatibility.BOTH, ExistsIn.BASE)] public Int32 CONTROLTYPE;
            [GFF("Obj_Parent", Compatibility.BOTH, ExistsIn.BASE)] public CExoString Obj_Parent;
            [GFF("TAG", Compatibility.BOTH, ExistsIn.BASE)] public CExoString TAG;
            [GFF("Obj_ParentID", Compatibility.BOTH, ExistsIn.BASE)] public Int32 Obj_ParentID;
            [GFF("DRAWMODE", Compatibility.BOTH, ExistsIn.BASE)] public Byte DRAWMODE;
            [GFF("MAXVALUE", Compatibility.BOTH, ExistsIn.BASE)] public Int32 MAXVALUE;
            [GFF("VISIBLEVALUE", Compatibility.BOTH, ExistsIn.BASE)] public Int32 VISIBLEVALUE;
            [GFF("CURVALUE", Compatibility.BOTH, ExistsIn.BASE)] public Int32 CURVALUE;
        
            // List definitions
            [GFF("EXTENT", Compatibility.BOTH, ExistsIn.BASE)] public List<AEXTENT> EXTENT = new List<AEXTENT>();
            [GFF("BORDER", Compatibility.BOTH, ExistsIn.BASE)] public List<ABORDER> BORDER = new List<ABORDER>();
            [GFF("DIR", Compatibility.BOTH, ExistsIn.BASE)] public List<ADIR> DIR = new List<ADIR>();
            [GFF("THUMB", Compatibility.BOTH, ExistsIn.BASE)] public List<ATHUMB> THUMB = new List<ATHUMB>();
        
            // Class definitions    
            [Serializable]public class AEXTENT : AuroraStruct {
                // Field definitions
                [GFF("structid", Compatibility.BOTH, ExistsIn.BASE)] public uint structid;
                [GFF("LEFT", Compatibility.BOTH, ExistsIn.BASE)] public Int32 LEFT;
                [GFF("TOP", Compatibility.BOTH, ExistsIn.BASE)] public Int32 TOP;
                [GFF("WIDTH", Compatibility.BOTH, ExistsIn.BASE)] public Int32 WIDTH;
                [GFF("HEIGHT", Compatibility.BOTH, ExistsIn.BASE)] public Int32 HEIGHT;
                
            }
            
            [Serializable]public class ABORDER : AuroraStruct {
                // Field definitions
                [GFF("structid", Compatibility.BOTH, ExistsIn.BASE)] public uint structid;
                [GFF("CORNER", Compatibility.BOTH, ExistsIn.BASE)] public String CORNER;
                [GFF("EDGE", Compatibility.BOTH, ExistsIn.BASE)] public String EDGE;
                [GFF("FILL", Compatibility.BOTH, ExistsIn.BASE)] public String FILL;
                [GFF("FILLSTYLE", Compatibility.BOTH, ExistsIn.BASE)] public Int32 FILLSTYLE;
                [GFF("DIMENSION", Compatibility.BOTH, ExistsIn.BASE)] public Int32 DIMENSION;
                [GFF("INNEROFFSET", Compatibility.BOTH, ExistsIn.BASE)] public Int32 INNEROFFSET;
                [GFF("COLOR", Compatibility.BOTH, ExistsIn.BASE)] public Vector3 COLOR;
                [GFF("PULSING", Compatibility.BOTH, ExistsIn.BASE)] public Byte PULSING;
                [GFF("INNEROFFSETY", Compatibility.KotOR, ExistsIn.BASE)] public Int32 INNEROFFSETY;
                
            }
            
            [Serializable]public class ADIR : AuroraStruct {
                // Field definitions
                [GFF("structid", Compatibility.BOTH, ExistsIn.BASE)] public uint structid;
                [GFF("IMAGE", Compatibility.BOTH, ExistsIn.BASE)] public String IMAGE;
                [GFF("DRAWSTYLE", Compatibility.BOTH, ExistsIn.BASE)] public Int32 DRAWSTYLE;
                [GFF("FLIPSTYLE", Compatibility.BOTH, ExistsIn.BASE)] public Int32 FLIPSTYLE;
                [GFF("ROTATE", Compatibility.BOTH, ExistsIn.BASE)] public Single ROTATE;
                [GFF("ALIGNMENT", Compatibility.BOTH, ExistsIn.BASE)] public Int32 ALIGNMENT;
                
            }
            
            [Serializable]public class ATHUMB : AuroraStruct {
                // Field definitions
                [GFF("structid", Compatibility.BOTH, ExistsIn.BASE)] public uint structid;
                [GFF("IMAGE", Compatibility.BOTH, ExistsIn.BASE)] public String IMAGE;
                [GFF("DRAWSTYLE", Compatibility.BOTH, ExistsIn.BASE)] public Int32 DRAWSTYLE;
                [GFF("FLIPSTYLE", Compatibility.BOTH, ExistsIn.BASE)] public Int32 FLIPSTYLE;
                [GFF("ROTATE", Compatibility.BOTH, ExistsIn.BASE)] public Single ROTATE;
                [GFF("ALIGNMENT", Compatibility.BOTH, ExistsIn.BASE)] public Int32 ALIGNMENT;
                
            }
            
        }
        
        [Serializable]public class ATHUMB : AuroraStruct {
            // Field definitions
            [GFF("structid", Compatibility.BOTH, ExistsIn.BASE)] public uint structid;
            [GFF("IMAGE", Compatibility.BOTH, ExistsIn.BASE)] public String IMAGE;
            [GFF("DRAWSTYLE", Compatibility.BOTH, ExistsIn.BASE)] public Int32 DRAWSTYLE;
            [GFF("FLIPSTYLE", Compatibility.BOTH, ExistsIn.BASE)] public Int32 FLIPSTYLE;
            [GFF("ROTATE", Compatibility.BOTH, ExistsIn.BASE)] public Single ROTATE;
            [GFF("ALIGNMENT", Compatibility.BOTH, ExistsIn.BASE)] public Int32 ALIGNMENT;
            
        }
        
        [Serializable]public class APROGRESS : AuroraStruct {
            // Field definitions
            [GFF("structid", Compatibility.BOTH, ExistsIn.BASE)] public uint structid;
            [GFF("CORNER", Compatibility.BOTH, ExistsIn.BASE)] public String CORNER;
            [GFF("EDGE", Compatibility.BOTH, ExistsIn.BASE)] public String EDGE;
            [GFF("FILL", Compatibility.BOTH, ExistsIn.BASE)] public String FILL;
            [GFF("FILLSTYLE", Compatibility.BOTH, ExistsIn.BASE)] public Int32 FILLSTYLE;
            [GFF("DIMENSION", Compatibility.BOTH, ExistsIn.BASE)] public Int32 DIMENSION;
            [GFF("INNEROFFSET", Compatibility.BOTH, ExistsIn.BASE)] public Int32 INNEROFFSET;
            [GFF("COLOR", Compatibility.BOTH, ExistsIn.BASE)] public Vector3 COLOR;
            [GFF("PULSING", Compatibility.BOTH, ExistsIn.BASE)] public Byte PULSING;
            [GFF("INNEROFFSETY", Compatibility.KotOR, ExistsIn.BASE)] public Int32 INNEROFFSETY;
            
        }
        
        [Serializable]public class ASELECTED : AuroraStruct {
            // Field definitions
            [GFF("structid", Compatibility.BOTH, ExistsIn.BASE)] public uint structid;
            [GFF("CORNER", Compatibility.BOTH, ExistsIn.BASE)] public String CORNER;
            [GFF("EDGE", Compatibility.BOTH, ExistsIn.BASE)] public String EDGE;
            [GFF("FILL", Compatibility.BOTH, ExistsIn.BASE)] public String FILL;
            [GFF("FILLSTYLE", Compatibility.BOTH, ExistsIn.BASE)] public Int32 FILLSTYLE;
            [GFF("DIMENSION", Compatibility.BOTH, ExistsIn.BASE)] public Int32 DIMENSION;
            [GFF("INNEROFFSET", Compatibility.BOTH, ExistsIn.BASE)] public Int32 INNEROFFSET;
            [GFF("COLOR", Compatibility.BOTH, ExistsIn.BASE)] public Vector3 COLOR;
            [GFF("PULSING", Compatibility.BOTH, ExistsIn.BASE)] public Byte PULSING;
            
        }
        
        [Serializable]public class AHILIGHTSELECTED : AuroraStruct {
            // Field definitions
            [GFF("structid", Compatibility.BOTH, ExistsIn.BASE)] public uint structid;
            [GFF("CORNER", Compatibility.BOTH, ExistsIn.BASE)] public String CORNER;
            [GFF("EDGE", Compatibility.BOTH, ExistsIn.BASE)] public String EDGE;
            [GFF("FILL", Compatibility.BOTH, ExistsIn.BASE)] public String FILL;
            [GFF("FILLSTYLE", Compatibility.BOTH, ExistsIn.BASE)] public Int32 FILLSTYLE;
            [GFF("DIMENSION", Compatibility.BOTH, ExistsIn.BASE)] public Int32 DIMENSION;
            [GFF("INNEROFFSET", Compatibility.BOTH, ExistsIn.BASE)] public Int32 INNEROFFSET;
            [GFF("COLOR", Compatibility.BOTH, ExistsIn.BASE)] public Vector3 COLOR;
            [GFF("PULSING", Compatibility.BOTH, ExistsIn.BASE)] public Byte PULSING;
            
        }
        
    }
    
    [Serializable]public class AEXTENT : AuroraStruct {
        // Field definitions
        [GFF("structid", Compatibility.BOTH, ExistsIn.BASE)] public uint structid;
        [GFF("LEFT", Compatibility.BOTH, ExistsIn.BASE)] public Int32 LEFT;
        [GFF("TOP", Compatibility.BOTH, ExistsIn.BASE)] public Int32 TOP;
        [GFF("WIDTH", Compatibility.BOTH, ExistsIn.BASE)] public Int32 WIDTH;
        [GFF("HEIGHT", Compatibility.BOTH, ExistsIn.BASE)] public Int32 HEIGHT;
        
    }
    
    [Serializable]public class ABORDER : AuroraStruct {
        // Field definitions
        [GFF("structid", Compatibility.BOTH, ExistsIn.BASE)] public uint structid;
        [GFF("CORNER", Compatibility.BOTH, ExistsIn.BASE)] public String CORNER;
        [GFF("EDGE", Compatibility.BOTH, ExistsIn.BASE)] public String EDGE;
        [GFF("FILL", Compatibility.BOTH, ExistsIn.BASE)] public String FILL;
        [GFF("FILLSTYLE", Compatibility.BOTH, ExistsIn.BASE)] public Int32 FILLSTYLE;
        [GFF("DIMENSION", Compatibility.BOTH, ExistsIn.BASE)] public Int32 DIMENSION;
        [GFF("INNEROFFSET", Compatibility.BOTH, ExistsIn.BASE)] public Int32 INNEROFFSET;
        [GFF("COLOR", Compatibility.BOTH, ExistsIn.BASE)] public Vector3 COLOR;
        [GFF("PULSING", Compatibility.BOTH, ExistsIn.BASE)] public Byte PULSING;
        [GFF("INNEROFFSETY", Compatibility.KotOR, ExistsIn.BASE)] public Int32 INNEROFFSETY;
        
    }
    
}
