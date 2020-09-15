using System;
using System.Collections.Generic;
using static AuroraEngine.GFFObject;
using UnityEngine;

public class AuroraGUI : AuroraStruct {
    // Field definitions
    public uint structid;
    public Int32 CONTROLTYPE;
    public Byte Obj_Locked;
    public String TAG;
    public Int32 Obj_ParentID;
    public Single ALPHA;
    public Vector3 COLOR;
    public Int32 Obj_Layer;

    // Struct definitions
    public AEXTENT EXTENT;
    public ABORDER BORDER;

    // List definitions
    public List<ACONTROLS> CONTROLS;

    // Class definitions    
    public class AEXTENT : AuroraStruct {
        // Field definitions
        public uint structid;
        public Int32 LEFT;
        public Int32 TOP;
        public Int32 WIDTH;
        public Int32 HEIGHT;
        
    }
    
    public class ABORDER : AuroraStruct {
        // Field definitions
        public uint structid;
        public String CORNER;
        public String EDGE;
        public String FILL;
        public Int32 FILLSTYLE;
        public Int32 DIMENSION;
        public Int32 INNEROFFSET;
        public Vector3 COLOR;
        public Byte PULSING;
        
    }
    
    public class ACONTROLS : AuroraStruct {
        // Field definitions
        public uint structid;
        public Int32 CONTROLTYPE;
        public Int32 ID;
        public Byte Obj_Locked;
        public String Obj_Parent;
        public String TAG;
        public Int32 Obj_ParentID;
        public Vector3 COLOR;
        public Byte LOOPING;
        public Int32 PADDING;
        public Byte LEFTSCROLLBAR;
        public Int32 MAXVALUE;
        public Int32 CURVALUE;
        public Int32 Obj_Layer;
        public Byte STARTFROMLEFT;
        public Byte ISSELECTED;
        public Int32 PARENTID;
    
        // Struct definitions
        public AEXTENT EXTENT;
        public ABORDER BORDER;
        public ATEXT TEXT;
        public AHILIGHT HILIGHT;
        public AMOVETO MOVETO;
        public APROTOITEM PROTOITEM;
        public ASCROLLBAR SCROLLBAR;
        public ATHUMB THUMB;
        public APROGRESS PROGRESS;
        public ASELECTED SELECTED;
        public AHILIGHTSELECTED HILIGHTSELECTED;
    
        // Class definitions    
        public class AEXTENT : AuroraStruct {
            // Field definitions
            public uint structid;
            public Int32 LEFT;
            public Int32 TOP;
            public Int32 WIDTH;
            public Int32 HEIGHT;
            
        }
        
        public class ABORDER : AuroraStruct {
            // Field definitions
            public uint structid;
            public String CORNER;
            public String EDGE;
            public String FILL;
            public Int32 FILLSTYLE;
            public Int32 DIMENSION;
            public Int32 INNEROFFSET;
            public Vector3 COLOR;
            public Byte PULSING;
            
        }
        
        public class ATEXT : AuroraStruct {
            // Field definitions
            public uint structid;
            public Int32 ALIGNMENT;
            public Vector3 COLOR;
            public String FONT;
            public UInt32 STRREF;
            public Byte PULSING;
            public String TEXT;
            
        }
        
        public class AHILIGHT : AuroraStruct {
            // Field definitions
            public uint structid;
            public String CORNER;
            public String EDGE;
            public String FILL;
            public Int32 FILLSTYLE;
            public Int32 DIMENSION;
            public Int32 INNEROFFSET;
            public Vector3 COLOR;
            public Byte PULSING;
            
        }
        
        public class AMOVETO : AuroraStruct {
            // Field definitions
            public uint structid;
            public Int32 DOWN;
            public Int32 LEFT;
            public Int32 RIGHT;
            public Int32 UP;
            
        }
        
        public class APROTOITEM : AuroraStruct {
            // Field definitions
            public uint structid;
            public Int32 CONTROLTYPE;
            public String Obj_Parent;
            public String TAG;
            public Int32 Obj_ParentID;
            public Byte ISSELECTED;
        
            // Struct definitions
            public AEXTENT EXTENT;
            public ABORDER BORDER;
            public ATEXT TEXT;
            public AHILIGHT HILIGHT;
            public ASELECTED SELECTED;
            public AHILIGHTSELECTED HILIGHTSELECTED;
        
            // Class definitions    
            public class AEXTENT : AuroraStruct {
                // Field definitions
                public uint structid;
                public Int32 LEFT;
                public Int32 TOP;
                public Int32 WIDTH;
                public Int32 HEIGHT;
                
            }
            
            public class ABORDER : AuroraStruct {
                // Field definitions
                public uint structid;
                public String CORNER;
                public String EDGE;
                public String FILL;
                public Int32 FILLSTYLE;
                public Int32 DIMENSION;
                public Int32 INNEROFFSET;
                public Vector3 COLOR;
                public Byte PULSING;
                
            }
            
            public class ATEXT : AuroraStruct {
                // Field definitions
                public uint structid;
                public Int32 ALIGNMENT;
                public Vector3 COLOR;
                public String FONT;
                public String TEXT;
                public UInt32 STRREF;
                public Byte PULSING;
                
            }
            
            public class AHILIGHT : AuroraStruct {
                // Field definitions
                public uint structid;
                public String CORNER;
                public String EDGE;
                public String FILL;
                public Int32 FILLSTYLE;
                public Int32 DIMENSION;
                public Int32 INNEROFFSET;
                public Vector3 COLOR;
                public Byte PULSING;
                
            }
            
            public class ASELECTED : AuroraStruct {
                // Field definitions
                public uint structid;
                public String CORNER;
                public String EDGE;
                public String FILL;
                public Int32 FILLSTYLE;
                public Int32 DIMENSION;
                public Int32 INNEROFFSET;
                public Vector3 COLOR;
                public Byte PULSING;
                
            }
            
            public class AHILIGHTSELECTED : AuroraStruct {
                // Field definitions
                public uint structid;
                public String CORNER;
                public String EDGE;
                public String FILL;
                public Int32 FILLSTYLE;
                public Int32 DIMENSION;
                public Int32 INNEROFFSET;
                public Vector3 COLOR;
                public Byte PULSING;
                
            }
            
        }
        
        public class ASCROLLBAR : AuroraStruct {
            // Field definitions
            public uint structid;
            public Int32 CONTROLTYPE;
            public String Obj_Parent;
            public String TAG;
            public Int32 Obj_ParentID;
            public Byte DRAWMODE;
            public Int32 MAXVALUE;
            public Int32 VISIBLEVALUE;
            public Int32 CURVALUE;
        
            // Struct definitions
            public AEXTENT EXTENT;
            public ABORDER BORDER;
            public ADIR DIR;
            public ATHUMB THUMB;
        
            // Class definitions    
            public class AEXTENT : AuroraStruct {
                // Field definitions
                public uint structid;
                public Int32 LEFT;
                public Int32 TOP;
                public Int32 WIDTH;
                public Int32 HEIGHT;
                
            }
            
            public class ABORDER : AuroraStruct {
                // Field definitions
                public uint structid;
                public String CORNER;
                public String EDGE;
                public String FILL;
                public Int32 FILLSTYLE;
                public Int32 DIMENSION;
                public Int32 INNEROFFSET;
                public Vector3 COLOR;
                public Byte PULSING;
                
            }
            
            public class ADIR : AuroraStruct {
                // Field definitions
                public uint structid;
                public String IMAGE;
                public Int32 DRAWSTYLE;
                public Int32 FLIPSTYLE;
                public Single ROTATE;
                public Int32 ALIGNMENT;
                public Int32 ROTATESTYLE;
                
            }
            
            public class ATHUMB : AuroraStruct {
                // Field definitions
                public uint structid;
                public String IMAGE;
                public Int32 DRAWSTYLE;
                public Int32 FLIPSTYLE;
                public Single ROTATE;
                public Int32 ALIGNMENT;
                public Int32 ROTATESTYLE;
                
            }
            
        }
        
        public class ATHUMB : AuroraStruct {
            // Field definitions
            public uint structid;
            public String IMAGE;
            public Int32 DRAWSTYLE;
            public Int32 FLIPSTYLE;
            public Single ROTATE;
            public Int32 ALIGNMENT;
            
        }
        
        public class APROGRESS : AuroraStruct {
            // Field definitions
            public uint structid;
            public String CORNER;
            public String EDGE;
            public String FILL;
            public Int32 FILLSTYLE;
            public Int32 DIMENSION;
            public Int32 INNEROFFSET;
            public Vector3 COLOR;
            public Byte PULSING;
            
        }
        
        public class ASELECTED : AuroraStruct {
            // Field definitions
            public uint structid;
            public String CORNER;
            public String EDGE;
            public String FILL;
            public Int32 FILLSTYLE;
            public Int32 DIMENSION;
            public Int32 INNEROFFSET;
            public Vector3 COLOR;
            public Byte PULSING;
            
        }
        
        public class AHILIGHTSELECTED : AuroraStruct {
            // Field definitions
            public uint structid;
            public String CORNER;
            public String EDGE;
            public String FILL;
            public Int32 FILLSTYLE;
            public Int32 DIMENSION;
            public Int32 INNEROFFSET;
            public Vector3 COLOR;
            public Byte PULSING;
            
        }
        
    }
    
}
