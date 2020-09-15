using System;
using System.Collections.Generic;
using static AuroraEngine.GFFObject;
using UnityEngine;
using AuroraEngine;

[Serializable]public class AuroraGUI : AuroraStruct {
    // Field definitions
    [GFF("structid")] public uint structid;
    [GFF("CONTROLTYPE")] public Int32 CONTROLTYPE;
    [GFF("Obj_Locked")] public Byte Obj_Locked;
    [GFF("TAG")] public CExoString TAG;
    [GFF("Obj_ParentID")] public Int32 Obj_ParentID;
    [GFF("ALPHA")] public Single ALPHA;
    [GFF("COLOR")] public Vector3 COLOR;
    [GFF("Obj_Layer")] public Int32 Obj_Layer;

    // Struct definitions
    [GFF("EXTENT")] public AEXTENT EXTENT = new AEXTENT();
    [GFF("BORDER")] public ABORDER BORDER = new ABORDER();

    // List definitions
    [GFF("CONTROLS")] public List<ACONTROLS> CONTROLS = new List<ACONTROLS>();

    // Class definitions    
    [Serializable]public class AEXTENT : AuroraStruct {
        // Field definitions
        [GFF("structid")] public uint structid;
        [GFF("LEFT")] public Int32 LEFT;
        [GFF("TOP")] public Int32 TOP;
        [GFF("WIDTH")] public Int32 WIDTH;
        [GFF("HEIGHT")] public Int32 HEIGHT;
        
    }
    
    [Serializable]public class ABORDER : AuroraStruct {
        // Field definitions
        [GFF("structid")] public uint structid;
        [GFF("CORNER")] public String CORNER;
        [GFF("EDGE")] public String EDGE;
        [GFF("FILL")] public String FILL;
        [GFF("FILLSTYLE")] public Int32 FILLSTYLE;
        [GFF("DIMENSION")] public Int32 DIMENSION;
        [GFF("INNEROFFSET")] public Int32 INNEROFFSET;
        [GFF("COLOR")] public Vector3 COLOR;
        [GFF("PULSING")] public Byte PULSING;
        
    }
    
    [Serializable]public class ACONTROLS : AuroraStruct {
        // Field definitions
        [GFF("structid")] public uint structid;
        [GFF("CONTROLTYPE")] public Int32 CONTROLTYPE;
        [GFF("ID")] public Int32 ID;
        [GFF("Obj_Locked")] public Byte Obj_Locked;
        [GFF("Obj_Parent")] public CExoString Obj_Parent;
        [GFF("TAG")] public CExoString TAG;
        [GFF("Obj_ParentID")] public Int32 Obj_ParentID;
        [GFF("COLOR")] public Vector3 COLOR;
        [GFF("LOOPING")] public Byte LOOPING;
        [GFF("PADDING")] public Int32 PADDING;
        [GFF("LEFTSCROLLBAR")] public Byte LEFTSCROLLBAR;
        [GFF("MAXVALUE")] public Int32 MAXVALUE;
        [GFF("CURVALUE")] public Int32 CURVALUE;
        [GFF("Obj_Layer")] public Int32 Obj_Layer;
        [GFF("STARTFROMLEFT")] public Byte STARTFROMLEFT;
        [GFF("ISSELECTED")] public Byte ISSELECTED;
        [GFF("PARENTID")] public Int32 PARENTID;
    
        // Struct definitions
        [GFF("EXTENT")] public AEXTENT EXTENT = new AEXTENT();
        [GFF("BORDER")] public ABORDER BORDER = new ABORDER();
        [GFF("TEXT")] public ATEXT TEXT = new ATEXT();
        [GFF("HILIGHT")] public AHILIGHT HILIGHT = new AHILIGHT();
        [GFF("MOVETO")] public AMOVETO MOVETO = new AMOVETO();
        [GFF("PROTOITEM")] public APROTOITEM PROTOITEM = new APROTOITEM();
        [GFF("SCROLLBAR")] public ASCROLLBAR SCROLLBAR = new ASCROLLBAR();
        [GFF("THUMB")] public ATHUMB THUMB = new ATHUMB();
        [GFF("PROGRESS")] public APROGRESS PROGRESS = new APROGRESS();
        [GFF("SELECTED")] public ASELECTED SELECTED = new ASELECTED();
        [GFF("HILIGHTSELECTED")] public AHILIGHTSELECTED HILIGHTSELECTED = new AHILIGHTSELECTED();
    
        // Class definitions    
        [Serializable]public class AEXTENT : AuroraStruct {
            // Field definitions
            [GFF("structid")] public uint structid;
            [GFF("LEFT")] public Int32 LEFT;
            [GFF("TOP")] public Int32 TOP;
            [GFF("WIDTH")] public Int32 WIDTH;
            [GFF("HEIGHT")] public Int32 HEIGHT;
            
        }
        
        [Serializable]public class ABORDER : AuroraStruct {
            // Field definitions
            [GFF("structid")] public uint structid;
            [GFF("CORNER")] public String CORNER;
            [GFF("EDGE")] public String EDGE;
            [GFF("FILL")] public String FILL;
            [GFF("FILLSTYLE")] public Int32 FILLSTYLE;
            [GFF("DIMENSION")] public Int32 DIMENSION;
            [GFF("INNEROFFSET")] public Int32 INNEROFFSET;
            [GFF("COLOR")] public Vector3 COLOR;
            [GFF("PULSING")] public Byte PULSING;
            
        }
        
        [Serializable]public class ATEXT : AuroraStruct {
            // Field definitions
            [GFF("structid")] public uint structid;
            [GFF("ALIGNMENT")] public Int32 ALIGNMENT;
            [GFF("COLOR")] public Vector3 COLOR;
            [GFF("FONT")] public String FONT;
            [GFF("STRREF")] public UInt32 STRREF;
            [GFF("PULSING")] public Byte PULSING;
            [GFF("TEXT")] public CExoString TEXT;
            
        }
        
        [Serializable]public class AHILIGHT : AuroraStruct {
            // Field definitions
            [GFF("structid")] public uint structid;
            [GFF("CORNER")] public String CORNER;
            [GFF("EDGE")] public String EDGE;
            [GFF("FILL")] public String FILL;
            [GFF("FILLSTYLE")] public Int32 FILLSTYLE;
            [GFF("DIMENSION")] public Int32 DIMENSION;
            [GFF("INNEROFFSET")] public Int32 INNEROFFSET;
            [GFF("COLOR")] public Vector3 COLOR;
            [GFF("PULSING")] public Byte PULSING;
            
        }
        
        [Serializable]public class AMOVETO : AuroraStruct {
            // Field definitions
            [GFF("structid")] public uint structid;
            [GFF("DOWN")] public Int32 DOWN;
            [GFF("LEFT")] public Int32 LEFT;
            [GFF("RIGHT")] public Int32 RIGHT;
            [GFF("UP")] public Int32 UP;
            
        }
        
        [Serializable]public class APROTOITEM : AuroraStruct {
            // Field definitions
            [GFF("structid")] public uint structid;
            [GFF("CONTROLTYPE")] public Int32 CONTROLTYPE;
            [GFF("Obj_Parent")] public CExoString Obj_Parent;
            [GFF("TAG")] public CExoString TAG;
            [GFF("Obj_ParentID")] public Int32 Obj_ParentID;
            [GFF("ISSELECTED")] public Byte ISSELECTED;
        
            // Struct definitions
            [GFF("EXTENT")] public AEXTENT EXTENT = new AEXTENT();
            [GFF("BORDER")] public ABORDER BORDER = new ABORDER();
            [GFF("TEXT")] public ATEXT TEXT = new ATEXT();
            [GFF("HILIGHT")] public AHILIGHT HILIGHT = new AHILIGHT();
            [GFF("SELECTED")] public ASELECTED SELECTED = new ASELECTED();
            [GFF("HILIGHTSELECTED")] public AHILIGHTSELECTED HILIGHTSELECTED = new AHILIGHTSELECTED();
        
            // Class definitions    
            [Serializable]public class AEXTENT : AuroraStruct {
                // Field definitions
                [GFF("structid")] public uint structid;
                [GFF("LEFT")] public Int32 LEFT;
                [GFF("TOP")] public Int32 TOP;
                [GFF("WIDTH")] public Int32 WIDTH;
                [GFF("HEIGHT")] public Int32 HEIGHT;
                
            }
            
            [Serializable]public class ABORDER : AuroraStruct {
                // Field definitions
                [GFF("structid")] public uint structid;
                [GFF("CORNER")] public String CORNER;
                [GFF("EDGE")] public String EDGE;
                [GFF("FILL")] public String FILL;
                [GFF("FILLSTYLE")] public Int32 FILLSTYLE;
                [GFF("DIMENSION")] public Int32 DIMENSION;
                [GFF("INNEROFFSET")] public Int32 INNEROFFSET;
                [GFF("COLOR")] public Vector3 COLOR;
                [GFF("PULSING")] public Byte PULSING;
                
            }
            
            [Serializable]public class ATEXT : AuroraStruct {
                // Field definitions
                [GFF("structid")] public uint structid;
                [GFF("ALIGNMENT")] public Int32 ALIGNMENT;
                [GFF("COLOR")] public Vector3 COLOR;
                [GFF("FONT")] public String FONT;
                [GFF("TEXT")] public CExoString TEXT;
                [GFF("STRREF")] public UInt32 STRREF;
                [GFF("PULSING")] public Byte PULSING;
                
            }
            
            [Serializable]public class AHILIGHT : AuroraStruct {
                // Field definitions
                [GFF("structid")] public uint structid;
                [GFF("CORNER")] public String CORNER;
                [GFF("EDGE")] public String EDGE;
                [GFF("FILL")] public String FILL;
                [GFF("FILLSTYLE")] public Int32 FILLSTYLE;
                [GFF("DIMENSION")] public Int32 DIMENSION;
                [GFF("INNEROFFSET")] public Int32 INNEROFFSET;
                [GFF("COLOR")] public Vector3 COLOR;
                [GFF("PULSING")] public Byte PULSING;
                
            }
            
            [Serializable]public class ASELECTED : AuroraStruct {
                // Field definitions
                [GFF("structid")] public uint structid;
                [GFF("CORNER")] public String CORNER;
                [GFF("EDGE")] public String EDGE;
                [GFF("FILL")] public String FILL;
                [GFF("FILLSTYLE")] public Int32 FILLSTYLE;
                [GFF("DIMENSION")] public Int32 DIMENSION;
                [GFF("INNEROFFSET")] public Int32 INNEROFFSET;
                [GFF("COLOR")] public Vector3 COLOR;
                [GFF("PULSING")] public Byte PULSING;
                
            }
            
            [Serializable]public class AHILIGHTSELECTED : AuroraStruct {
                // Field definitions
                [GFF("structid")] public uint structid;
                [GFF("CORNER")] public String CORNER;
                [GFF("EDGE")] public String EDGE;
                [GFF("FILL")] public String FILL;
                [GFF("FILLSTYLE")] public Int32 FILLSTYLE;
                [GFF("DIMENSION")] public Int32 DIMENSION;
                [GFF("INNEROFFSET")] public Int32 INNEROFFSET;
                [GFF("COLOR")] public Vector3 COLOR;
                [GFF("PULSING")] public Byte PULSING;
                
            }
            
        }
        
        [Serializable]public class ASCROLLBAR : AuroraStruct {
            // Field definitions
            [GFF("structid")] public uint structid;
            [GFF("CONTROLTYPE")] public Int32 CONTROLTYPE;
            [GFF("Obj_Parent")] public CExoString Obj_Parent;
            [GFF("TAG")] public CExoString TAG;
            [GFF("Obj_ParentID")] public Int32 Obj_ParentID;
            [GFF("DRAWMODE")] public Byte DRAWMODE;
            [GFF("MAXVALUE")] public Int32 MAXVALUE;
            [GFF("VISIBLEVALUE")] public Int32 VISIBLEVALUE;
            [GFF("CURVALUE")] public Int32 CURVALUE;
        
            // Struct definitions
            [GFF("EXTENT")] public AEXTENT EXTENT = new AEXTENT();
            [GFF("BORDER")] public ABORDER BORDER = new ABORDER();
            [GFF("DIR")] public ADIR DIR = new ADIR();
            [GFF("THUMB")] public ATHUMB THUMB = new ATHUMB();
        
            // Class definitions    
            [Serializable]public class AEXTENT : AuroraStruct {
                // Field definitions
                [GFF("structid")] public uint structid;
                [GFF("LEFT")] public Int32 LEFT;
                [GFF("TOP")] public Int32 TOP;
                [GFF("WIDTH")] public Int32 WIDTH;
                [GFF("HEIGHT")] public Int32 HEIGHT;
                
            }
            
            [Serializable]public class ABORDER : AuroraStruct {
                // Field definitions
                [GFF("structid")] public uint structid;
                [GFF("CORNER")] public String CORNER;
                [GFF("EDGE")] public String EDGE;
                [GFF("FILL")] public String FILL;
                [GFF("FILLSTYLE")] public Int32 FILLSTYLE;
                [GFF("DIMENSION")] public Int32 DIMENSION;
                [GFF("INNEROFFSET")] public Int32 INNEROFFSET;
                [GFF("COLOR")] public Vector3 COLOR;
                [GFF("PULSING")] public Byte PULSING;
                
            }
            
            [Serializable]public class ADIR : AuroraStruct {
                // Field definitions
                [GFF("structid")] public uint structid;
                [GFF("IMAGE")] public String IMAGE;
                [GFF("DRAWSTYLE")] public Int32 DRAWSTYLE;
                [GFF("FLIPSTYLE")] public Int32 FLIPSTYLE;
                [GFF("ROTATE")] public Single ROTATE;
                [GFF("ALIGNMENT")] public Int32 ALIGNMENT;
                [GFF("ROTATESTYLE")] public Int32 ROTATESTYLE;
                
            }
            
            [Serializable]public class ATHUMB : AuroraStruct {
                // Field definitions
                [GFF("structid")] public uint structid;
                [GFF("IMAGE")] public String IMAGE;
                [GFF("DRAWSTYLE")] public Int32 DRAWSTYLE;
                [GFF("FLIPSTYLE")] public Int32 FLIPSTYLE;
                [GFF("ROTATE")] public Single ROTATE;
                [GFF("ALIGNMENT")] public Int32 ALIGNMENT;
                [GFF("ROTATESTYLE")] public Int32 ROTATESTYLE;
                
            }
            
        }
        
        [Serializable]public class ATHUMB : AuroraStruct {
            // Field definitions
            [GFF("structid")] public uint structid;
            [GFF("IMAGE")] public String IMAGE;
            [GFF("DRAWSTYLE")] public Int32 DRAWSTYLE;
            [GFF("FLIPSTYLE")] public Int32 FLIPSTYLE;
            [GFF("ROTATE")] public Single ROTATE;
            [GFF("ALIGNMENT")] public Int32 ALIGNMENT;
            
        }
        
        [Serializable]public class APROGRESS : AuroraStruct {
            // Field definitions
            [GFF("structid")] public uint structid;
            [GFF("CORNER")] public String CORNER;
            [GFF("EDGE")] public String EDGE;
            [GFF("FILL")] public String FILL;
            [GFF("FILLSTYLE")] public Int32 FILLSTYLE;
            [GFF("DIMENSION")] public Int32 DIMENSION;
            [GFF("INNEROFFSET")] public Int32 INNEROFFSET;
            [GFF("COLOR")] public Vector3 COLOR;
            [GFF("PULSING")] public Byte PULSING;
            
        }
        
        [Serializable]public class ASELECTED : AuroraStruct {
            // Field definitions
            [GFF("structid")] public uint structid;
            [GFF("CORNER")] public String CORNER;
            [GFF("EDGE")] public String EDGE;
            [GFF("FILL")] public String FILL;
            [GFF("FILLSTYLE")] public Int32 FILLSTYLE;
            [GFF("DIMENSION")] public Int32 DIMENSION;
            [GFF("INNEROFFSET")] public Int32 INNEROFFSET;
            [GFF("COLOR")] public Vector3 COLOR;
            [GFF("PULSING")] public Byte PULSING;
            
        }
        
        [Serializable]public class AHILIGHTSELECTED : AuroraStruct {
            // Field definitions
            [GFF("structid")] public uint structid;
            [GFF("CORNER")] public String CORNER;
            [GFF("EDGE")] public String EDGE;
            [GFF("FILL")] public String FILL;
            [GFF("FILLSTYLE")] public Int32 FILLSTYLE;
            [GFF("DIMENSION")] public Int32 DIMENSION;
            [GFF("INNEROFFSET")] public Int32 INNEROFFSET;
            [GFF("COLOR")] public Vector3 COLOR;
            [GFF("PULSING")] public Byte PULSING;
            
        }
        
    }
    
}
