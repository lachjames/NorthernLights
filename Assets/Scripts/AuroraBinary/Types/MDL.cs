using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

[System.Serializable]
public class MDL : BinaryStructure
{
    public GeometryHeader geometryHeader;

    public byte modelType;
    public byte unk;
    public byte padding;
    public byte disableFog;

    public uint childModelCount;

    public PointerArray animationPointer;
    public uint unk2;

    [BinaryArray(typeof(float), 3)]
    public float[] boundingBoxMin;

    [BinaryArray(typeof(float), 3)]
    public float[] boundingBoxMax;

    public float radius;
    public float animationScale;

    [BinaryText(32)]
    public string supermodelName;

    public NamesHeader nameHeader;

    [BinaryPointerArray("animationPointer")] public Pointer[] animationPointers;
    [BinaryDerefArray("animationPointer", "animationPointers")] public AnimationNode[] animations;

    [BinaryCustom("ReadNodes")] public MDLNode rootNode;
    
    public int ReadNodes(byte[] data, int start, FieldInfo f, object target, Dictionary<string, byte[]> other)
    {
        //Debug.Log("Loading model " + geometryHeader.modelName + " with supermodel " + supermodelName);
        int rootOffset = (int)geometryHeader.rootNodeOffset;

        MDLNode node = new MDLNode();
        node.Load(data, other, rootOffset);

        rootNode = node;
        return start;
    }
}

[BinaryVariableSize]
public class AnimationNode : BinaryStructure
{
    public AnimationHeader animationHeader;

    public MDLNode rootNode;
}

public class AnimationEvent : BinaryStructure
{
    public float time;
    //public int unk;
    [BinaryText(32)] public string name;
}

[BinaryFixedSize(12)]
public class FileHeader : BinaryStructure
{
    public uint unused;
    public uint mdlSize;
    public uint mdxSize;
}

[BinaryFixedSize(80)]
public class GeometryHeader : BinaryStructure
{
    public uint funcPointer;
    public uint funcPointer2;

    [BinaryText(32)]
    public string modelName;

    public uint rootNodeOffset;
    public uint nodeCount;

    [BinaryArray(typeof(uint), 7)]
    public uint[] unk;

    public byte geomType;

    [BinaryArray(typeof(byte), 3)]
    public byte[] padding;

    [BinaryLoadFromOffset("rootNodeOffset", "mdx")] public MeshNode rootNode;
}

[BinaryFixedSize(28)]
public class NamesHeader : BinaryStructure
{
    public uint rootNodeOffset;
    public uint unused;
    public uint mdxFileSize;
    public uint mdxOffset;

    public PointerArray namesPointer;
    [BinaryPointerArray("namesPointer")] public Pointer[] nameOffsets;

    // The names are located right after the nameOffsets
    [BinaryDerefArray("namesPointer", "nameOffsets")] public NodeName[] names;
}

public class NodeName : BinaryStructure
{
    [BinaryText(32)] public string name;
}

[BinaryFixedSize(136)]
public class AnimationHeader : BinaryStructure
{
    public GeometryHeader geometryHeader;
    public float animationLength;
    public float transitionTime;

    [BinaryText(32)]
    public string animationRoot;

    public PointerArray eventPointer;
    public uint unk;

    [BinaryPointerArray("eventPointer")] public AnimationEvent[] events;
}

public class MDLNode : BinaryStructure
{
    public NodeHeader nodeHeader;

    [BinaryConditional("HasTriMesh")] public TrimeshHeader trimeshHeader;
    [BinaryConditional("HasSkinMesh")] public SkinmeshHeader skinmeshHeader;
    [BinaryConditional("HasDanglyMesh")] public DanglymeshHeader danglymeshHeader;
    [BinaryConditional("HasSaberMesh")] public SabermeshHeader sabermeshHeader;
    [BinaryConditional("HasAABB")] public AABBHeader aabbHeader;
    [BinaryConditional("HasReference")] public ReferenceHeader referenceHeader;
    [BinaryConditional("HasEmitter")] public EmitterHeader emitterHeader;
    [BinaryConditional("HasLight")] public LightHeader lightHeader;

    // Calculated using the methods below
    [BinaryCustom("ReadVtx")] public Vector3[] vertices;
    [BinarySkip()] public Vector3[] tVertices; // ReadVtx also loads this
    [BinarySkip()] public Vector2[][] uvs;
    [BinarySkip()] public float[][] weights;
    [BinarySkip()] public int[][] weightIdxs;

    [BinaryCustom("ReadFaces")] public int[] faces;

    [BinaryCustom("ReadChildren")] public MDLNode[] childNodes;


    [BinaryCustom("ReadParameters")]public LightParameters lightParameters;
    [BinarySkip()]public EmitterParameters emitterParameters;
    [BinarySkip()]public MeshParameters meshParameters;

    public bool HasTriMesh(byte[] data, int offset, FieldInfo f, object target, Dictionary<string, byte[]> other)
    {
        return HasFlag(nodeHeader.nodeType, 0x20);
    }

    public bool HasSkinMesh(byte[] data, int offset, FieldInfo f, object target, Dictionary<string, byte[]> other)
    {
        return HasFlag(nodeHeader.nodeType, 0x40);
    }
    public bool HasDanglyMesh(byte[] data, int offset, FieldInfo f, object target, Dictionary<string, byte[]> other)
    {
        return HasFlag(nodeHeader.nodeType, 0x100);
    }
    public bool HasSaberMesh(byte[] data, int offset, FieldInfo f, object target, Dictionary<string, byte[]> other)
    {
        return HasFlag(nodeHeader.nodeType, 0x400);
    }
    public bool HasAABB(byte[] data, int offset, FieldInfo f, object target, Dictionary<string, byte[]> other)
    {
        return HasFlag(nodeHeader.nodeType, 0x200);
    }
    public bool HasReference(byte[] data, int offset, FieldInfo f, object target, Dictionary<string, byte[]> other)
    {
        return HasFlag(nodeHeader.nodeType, 0x10);
    }
    public bool HasEmitter(byte[] data, int offset, FieldInfo f, object target, Dictionary<string, byte[]> other)
    {
        return HasFlag(nodeHeader.nodeType, 0x04);
    }
    public bool HasLight(byte[] data, int offset, FieldInfo f, object target, Dictionary<string, byte[]> other)
    {
        return HasFlag(nodeHeader.nodeType, 0x02);
    }

    bool HasFlag(ushort nodeType, int flag)
    {
        return (nodeType & flag) == flag;
    }

    public int ReadChildren(byte[] data, int offset, FieldInfo f, object target, Dictionary<string, byte[]> other)
    {
        int childArrayOffset = (int)nodeHeader.childArray.pointer;

        MDLNode[] children = new MDLNode[nodeHeader.childArray.used];

        //Debug.Log("Node has " + nodeHeader.childArray.used + " children");

        // Read from the child array
        for (int i = 0; i < nodeHeader.childArray.used; i++)
        {
            //Debug.Log("Getting child offset from: " + (childArrayOffset + 4 * i));
            // Read the offset for the child node
            int childOffset = BitConverter.ToInt32(data, childArrayOffset + 4 * i);

            // Load the node
            children[i] = new MDLNode();
            children[i].Load(data, other, childOffset);
        }

        childNodes = children;

        return offset;
    }

    public int ReadVtx(byte[] data, int offset, FieldInfo f, object target, Dictionary<string, byte[]> other)
    {
        data = other["mdx"];
        // Read the vertex data from the .mdx file
        if (trimeshHeader == null)
        {
            return offset;
        }

        // Vertex arrays
        vertices = new Vector3[trimeshHeader.vertexCount];
        tVertices = new Vector3[trimeshHeader.vertexCount];

        // UV array
        uvs = new Vector2[trimeshHeader.textureCount][];

        for (int j = 0; j < uvs.Length; j++)
        {
            uvs[j] = new Vector2[trimeshHeader.vertexCount];
        }

        weights = new float[trimeshHeader.vertexCount][];
        weightIdxs = new int[trimeshHeader.vertexCount][];

        // Weight arrays
        for (int v = 0; v < trimeshHeader.vertexCount; v++)
        {
            weights[v] = new float[4];
            weightIdxs[v] = new int[4];
        }

        // We will read the data manually, rather than using BinaryStructure for this,
        // because this is the main data loading component of reading the models
        // (aside from loading animations)

        // Read the vertices one by one
        int pos = (int)trimeshHeader.mdxDataOffset;
        for (int i = 0; i < trimeshHeader.vertexCount; i++)
        {
            vertices[i] = new Vector3(
                BitConverter.ToSingle(data, pos),
                BitConverter.ToSingle(data, pos + 8),
                BitConverter.ToSingle(data, pos + 4)
            );

            tVertices[i] = new Vector3(
                BitConverter.ToSingle(data, pos + 12),
                BitConverter.ToSingle(data, pos + 20),
                BitConverter.ToSingle(data, pos + 16)
            );

            for (int j = 0; j < trimeshHeader.textureCount; j++)
            {
                uvs[j][i] = new Vector2(
                    BitConverter.ToSingle(data, pos + 24 + 8 * j),
                    BitConverter.ToSingle(data, pos + 24 + 8 * j + 4)
                );
            }

            // If we need to read weights, we can do so here
            if (skinmeshHeader != null)
            {
                // Read the weights from the offset
                int weightOffset = (int)skinmeshHeader.offsetToMDXSkinWeights;
                weights[i] = new float[] {
                    BitConverter.ToSingle(data, pos + weightOffset),
                    BitConverter.ToSingle(data, pos + weightOffset + 4),
                    BitConverter.ToSingle(data, pos + weightOffset + 8),
                    BitConverter.ToSingle(data, pos + weightOffset + 12)
                };

                if (weights[i][0] == 0)
                {
                    Debug.LogWarning("Zero weight found!");
                }

                int weightIdxOffset = (int)skinmeshHeader.offsetToMXDXSkinBoneReferenceIndexes;

                weightIdxs[i][0] = (int)BitConverter.ToSingle(data, pos + weightIdxOffset);
                weightIdxs[i][1] = (int)BitConverter.ToSingle(data, pos + weightIdxOffset + 4);
                weightIdxs[i][2] = (int)BitConverter.ToSingle(data, pos + weightIdxOffset + 8);
                weightIdxs[i][3] = (int)BitConverter.ToSingle(data, pos + weightIdxOffset + 12);
            }
            pos += (int)trimeshHeader.mdxDataSize;

            //Debug.Log(vertices[i]);
        }

        return offset;
    }

    public int ReadFaces(byte[] data, int offset, FieldInfo f, object target, Dictionary<string, byte[]> other)
    {
        data = other["mdl"];
        if (trimeshHeader == null)
        {
            faces = new int[0];
            return offset;
        }

        if (trimeshHeader.textureCount == 0)
        {
            faces = new int[0];
            return offset;
        }

        int pos = 20 + (int)trimeshHeader.vertexOffsetsArray.pointer;

        //Debug.Log("Loading faces from position " + pos);

        faces = new int[3 * trimeshHeader.facesCount];

        for (int i = 0; i < trimeshHeader.facesCount; i++)
        {
            //Debug.Log("Loading face " + i + " from offset " + pos);
            faces[3 * i + 0] = BitConverter.ToUInt16(data, (int)pos);
            faces[3 * i + 1] = BitConverter.ToUInt16(data, (int)pos + 4);
            faces[3 * i + 2] = BitConverter.ToUInt16(data, (int)pos + 2);
            //Debug.Log("Found face: " + faces[3 * i + 0] + ", " + faces[3 * i + 1] + ", " + faces[3 * i + 2]);
            pos += 6;
        }

        return offset;
    }

    public int ReadParameters(byte[] data, int offset, FieldInfo f, object target, Dictionary<string, byte[]> other)
    {
        if (trimeshHeader != null || skinmeshHeader != null ||
            danglymeshHeader != null || sabermeshHeader != null)
        {
            ReadMeshParameters();
        }

        // If this is a light
        if (lightHeader != null)
        {
            ReadLightParameters();
        }

        // If this is an emitter
        if (emitterHeader != null)
        {
            ReadEmitterParameters();
        }

        return offset;
    }

    public void ReadMeshParameters ()
    {
        meshParameters = new MeshParameters();
        for (int i = 0; i < nodeHeader.controllers.Length; i++)
        {
            Controller c = nodeHeader.controllers[i];
            ControllerData d = nodeHeader.controllerData[i];

            switch (c.controllerType)
            {
                case 100:
                    meshParameters.selfIllumColor = new Color(
                        d.data[0][0],
                        d.data[0][0],
                        d.data[0][0]
                    );
                    break;
                case 128:
                    meshParameters.alpha = d.data[0][0];
                    break;
            }
        }
    }

    public void ReadLightParameters ()
    {
        lightParameters = new LightParameters();

        for (int i = 0; i < nodeHeader.controllers.Length; i++)
        {
            Controller c = nodeHeader.controllers[i];
            ControllerData d = nodeHeader.controllerData[i];

            switch(c.controllerType)
            {
                case 76:
                    // Color
                    lightParameters.color = new Color(
                        d.data[0][0],
                        d.data[0][1],
                        d.data[0][2]
                    );
                    break;
                case 88:
                    lightParameters.radius = d.data[0][0];
                    break;
                case 96:
                    lightParameters.radius = d.data[0][0];
                    break;
                case 100:
                    lightParameters.verticalDisplacement = d.data[0][0];
                    break;
                case 140:
                    lightParameters.multiplier = d.data[0][0];
                    break;
                default:
                    break;
            }
        }
    }
    public void ReadEmitterParameters ()
    {
        emitterParameters = new EmitterParameters();

        for (int i = 0; i < nodeHeader.controllers.Length; i++)
        {
            Controller c = nodeHeader.controllers[i];
            ControllerData d = nodeHeader.controllerData[i];

            switch (c.controllerType)
            {
                case 80:
                    // AlphaEnd
                    emitterParameters.alphaEnd = d.data[0][0];
                    break;
                case 84:
                    // AlphaStart
                    emitterParameters.alphaStart = d.data[0][0];
                    break;
                case 88:
                    // BirthRate
                    emitterParameters.birthRate = d.data[0][0];
                    break;
                case 92:
                    // BounceCoefficient
                    emitterParameters.bounceCoefficient = d.data[0][0];
                    break;
                case 96:
                    // ColorEnd
                    emitterParameters.colorEnd = d.data[0][0];
                    break;
                case 108:
                    // ColorStart
                    emitterParameters.colorStart = d.data[0][0];
                    break;
                case 120:
                    // CombineTime
                    emitterParameters.combineTime = d.data[0][0];
                    break;
                case 124:
                    // Drag
                    emitterParameters.drag = d.data[0][0];
                    break;
                case 128:
                    // FPS
                    emitterParameters.fps = d.data[0][0];
                    break;
                case 132:
                    // FrameEnd
                    emitterParameters.frameEnd = d.data[0][0];
                    break;
                case 136:
                    // FrameStart
                    emitterParameters.frameStart = d.data[0][0];
                    break;
                case 140:
                    // Grav
                    emitterParameters.gravity = d.data[0][0];
                    break;
                case 144:
                    // LifeExp
                    emitterParameters.lifeExp = d.data[0][0];
                    break;
                case 148:
                    // Mass
                    emitterParameters.mass = d.data[0][0];
                    break;
                case 152:
                    // P2P_Bezier2
                    emitterParameters.p2pBezier2 = d.data[0][0];
                    break;
                case 156:
                    // P2P_Bezier3
                    emitterParameters.p2pBezier3= d.data[0][0];
                    break;
                case 160:
                    // ParticleRotation
                    emitterParameters.particleRotation = d.data[0][0];
                    break;
                case 164:
                    // RandomVelocity
                    emitterParameters.randomVelocity = d.data[0][0];
                    break;
                case 168:
                    // SizeStart
                    emitterParameters.sizeStart = d.data[0][0];
                    break;
                case 172:
                    // SizeEnd
                    emitterParameters.sizeEnd = d.data[0][0];
                    break;
                case 176:
                    // SizeStart_Y
                    emitterParameters.sizeStartY= d.data[0][0];
                    break;
                case 180:
                    // SizeStart_X
                    emitterParameters.sizeStartX= d.data[0][0];
                    break;
                case 184:
                    // Spread
                    emitterParameters.spread = d.data[0][0];
                    break;
                case 188:
                    // Threshold
                    emitterParameters.threshold = d.data[0][0];
                    break;
                case 192:
                    // Velocity
                    emitterParameters.velocity = d.data[0][0];
                    break;
                case 196:
                    // XSize
                    emitterParameters.xSize = d.data[0][0];
                    break;
                case 200:
                    // YSize
                    emitterParameters.ySize = d.data[0][0];
                    break;
                case 204:
                    // BlurLength
                    emitterParameters.blurLength = d.data[0][0];
                    break;
                case 208:
                    // LightningDelay
                    emitterParameters.lightningDelay = d.data[0][0];
                    break;
                case 212:
                    // LightningRadius
                    emitterParameters.lightningRadius = d.data[0][0];
                    break;
                case 216:
                    // LightningScale
                    emitterParameters.lightningScale = d.data[0][0];
                    break;
                case 228:
                    // Detonate
                    emitterParameters.detonate = d.data[0][0];
                    break;
                case 464:
                    // AlphaMid
                    emitterParameters.alphaMid = d.data[0][0];
                    break;
                case 468:
                    // ColorMid
                    emitterParameters.colorMid = d.data[0][0];
                    break;
                case 480:
                    // PercentStart
                    emitterParameters.percentStart = d.data[0][0];
                    break;
                case 481:
                    // PercentMid
                    emitterParameters.percentMid = d.data[0][0];
                    break;
                case 482:
                    // PercentEnd
                    emitterParameters.percentEnd = d.data[0][0];
                    break;
                case 484:
                    // SizeMid
                    emitterParameters.sizeMid = d.data[0][0];
                    break;
                case 488:
                    // SizeMid_Y
                    emitterParameters.sizeMidY = d.data[0][0];
                    break;
                default:
                    break;
            }
        }
    }
}

public struct LightParameters
{
    public Color color;
    public float radius;
    public float shadowRadius;
    public float verticalDisplacement;
    public float multiplier;
}

public struct EmitterParameters
{
    public float alphaEnd;
    public float alphaStart;
    public float birthRate;
    public float bounceCoefficient;
    public float colorEnd;
    public float colorStart;
    public float combineTime;
    public float drag;
    public float fps;
    public float frameEnd;
    public float frameStart;
    public float gravity;
    public float lifeExp;
    public float mass;
    public float p2pBezier2;
    public float p2pBezier3;
    public float particleRotation;
    public float randomVelocity;
    public float sizeStart;
    public float sizeEnd;
    public float sizeStartY;
    public float sizeStartX;
    public float spread;
    public float threshold;
    public float velocity;
    public float xSize;
    public float ySize;
    public float blurLength;
    public float lightningDelay;
    public float lightningRadius;
    public float lightningScale;
    public float detonate; // Think something strange happens with this one?
    public float alphaMid;
    public float colorMid;
    public float percentStart;
    public float percentMid;
    public float percentEnd;
    public float sizeMid;
    public float sizeMidY;
}

public struct MeshParameters {
    public Color selfIllumColor;
    public float alpha;
}

public class Skin : BinaryStructure
{

}

[BinaryFixedSize(16)]
public class Controller : BinaryStructure
{
    public uint controllerType;
    public ushort unk;
    public ushort dataRowCount;
    public ushort firstKeyOffset;
    public ushort firstDataOffset;
    public byte columnCount;

    [BinaryArray(typeof(byte), 3)]
    public byte[] unk2;
}

[BinaryFixedSize(80)]
public class NodeHeader : BinaryStructure
{
    public ushort nodeType;
    public ushort supernode;
    public ushort nodeNumber;
    public ushort padding;
    public uint rootNodeOffset;
    public uint parentNodeOffset;

    [BinaryArray(typeof(float), 3)]
    public float[] position;

    [BinaryArray(typeof(float), 4)]
    public float[] rotation;

    public PointerArray childArray;
    public PointerArray controllerArray;
    public PointerArray controllerDataArray;

    //public uint[] childrenOffsets;

    //public Controller[] controllers;
    [BinaryPointerArray("controllerArray", false)]
    public Controller[] controllers;

    [BinaryCustom("LoadControllers")]
    public ControllerData[] controllerData;

    public int LoadControllers(byte[] data, int offset, FieldInfo f, object target, Dictionary<string, byte[]> other)
    {
        //float[] rawData = new float[controllerDataArray.max];
        //int[] rawInts = new int[controllerDataArray.max];
        //Debug.Log("Raw data size: " + rawData.Length);

        //int pos = (int)controllerDataArray.pointer;
        //for (int i = 0; i < controllerDataArray.used; i++)
        //{
        //    rawData[i] = BitConverter.ToSingle(data, pos);
        //    rawInts[i] = BitConverter.ToInt32(data, pos);
        //    pos += 4;
        //}

        controllerData = new ControllerData[controllerArray.used];

        int n = 0;
        foreach (Controller c in controllers)
        {
            //Debug.Log(
            //    "Loading data for controller with type " + c.controllerType +
            //    "; #rows = " + c.dataRowCount + ", #cols = " + c.columnCount + "; " +
            //    c.firstKeyOffset + ", " + c.firstDataOffset
            //);

            controllerData[n] = new ControllerData();

            // Create a data table to hold the times
            controllerData[n].times = new float[c.dataRowCount];

            // Read the times
            int idx = (int)c.firstKeyOffset;
            for (int i = 0; i < c.dataRowCount; i++)
            {
                controllerData[n].times[i] = BitConverter.ToSingle(data, (int)controllerDataArray.pointer + 4 * idx);
                idx++;
            }

            //Debug.Log(string.Join(",", controllerData[n].times));

            // Check if we are in the special Quaternion case
            if (c.controllerType == 20 && c.columnCount == 2)
            {
                controllerData[n].data = new float[c.dataRowCount][];
                for (int i = 0; i < c.dataRowCount; i++)
                {
                    controllerData[n].data[i] = new float[4];
                }

                int qIdx = c.firstDataOffset;
                for (int r = 0; r < c.dataRowCount; r++)
                {
                    // This is from the KotOR-Unity project
                    // (I think they ported this from xoreos though)
                    int temp = BitConverter.ToInt32(data, (int)controllerDataArray.pointer + 4 * qIdx);

                    int x1 = temp & 0x07FF;
                    int y1 = (temp >> 11) & 0x07FF;
                    int z1 = (temp >> 22) & 0x03FF;

                    float x = ((temp & 0x07FF) / 1023.0f) - 1.0f;
                    float y = (((temp >> 11) & 0x07FF) / 1023.0f) - 1.0f;
                    float z = (((temp >> 22) & 0x03FF) / 511.0f) - 1.0f;
                    float w = 0;

                    float magSquared = x * x + y * y + z * z;
                    float magnitude = Mathf.Sqrt(magSquared);

                    if (magSquared < 1.0)
                    {
                        w = (float)Math.Sqrt(1.0 - magSquared);
                    }
                    else
                    {
                        x /= magnitude;
                        y /= magnitude;
                        z /= magnitude;
                    }

                    controllerData[n].data[r][0] = x;
                    controllerData[n].data[r][1] = y;
                    controllerData[n].data[r][2] = z;
                    controllerData[n].data[r][3] = w;

                    qIdx++;
                }

                n++;
                continue;
            }

            // Create a data table to hold the data
            controllerData[n].data = new float[c.dataRowCount][];
            for (int i = 0; i < c.dataRowCount; i++)
            {
                controllerData[n].data[i] = new float[c.columnCount];
            }

            //if (c.firstDataOffset + c.dataRowCount * c.columnCount > rawData.Length)
            //{
            //    Debug.LogWarning("Not enough data to read controller type " + controllers[n].controllerType);
            //    n++;
            //    continue;
            //}

            // It seems that on some doors, columnCount is set to 19 where it should
            // be set to 9?!
            if (c.controllerType == 8 && c.columnCount > 9)
            {
                c.columnCount = 9;
            }

            // Read the data
            idx = (int)c.firstDataOffset;
            for (int row = 0; row < c.dataRowCount; row++)
            {
                for (int col = 0; col < c.columnCount; col++)
                {
                    //if (idx >= rawData.Length)
                    //{
                    //    // This might be a different data size than 4 bytes?
                    //    //Debug.LogWarning("Failed to load raw controllers; data size is wrong?");
                    //    break;
                    //    //return offset;
                    //}
                    controllerData[n].data[row][col] = BitConverter.ToSingle(data, (int)controllerDataArray.pointer + 4 * idx);
                    idx++;
                }
            }

            // Move to the next controller
            n++;
        }
        return offset;
    }
}

public class ControllerData : BinaryStructure
{
    public float[] times;
    public float[][] data;
}

[BinaryFixedSize(332)]
public class TrimeshHeader : BinaryStructure
{
    public uint functionPointer;
    public uint functionPointer2;

    public uint facesOffset;
    public uint facesCount;
    public uint facesCapacity;

    [BinaryArray(typeof(float), 3)] public float[] boundingBoxMin;
    [BinaryArray(typeof(float), 3)] public float[] boundingBoxMax;

    public float radius;

    [BinaryArray(typeof(float), 3)] public float[] averagePoint;
    [BinaryArray(typeof(float), 3)] public float[] diffuseColor;
    [BinaryArray(typeof(float), 3)] public float[] ambientColor;

    public uint unk;

    [BinaryText(32)] public string textureName;
    [BinaryText(32)] public string lightmapName;
    [BinaryText(12)] public string tex3;
    [BinaryText(12)] public string tex4;

    public PointerArray vertexIdxArray;
    public PointerArray vertexOffsetsArray;
    public PointerArray invertedCountersArray;

    [BinaryArray(typeof(uint), 3)] public uint[] unk3;

    [BinaryArray(typeof(byte), 8)] public byte[] saberValues;

    public uint unk4;

    [BinaryArray(typeof(float), 4)] public float[] unk5;

    public uint mdxDataSize;
    public uint mdxDataBitmap;
    public uint mdxVerticesOffset;
    public uint mdxNormalsOffset;
    public uint mdxUnknownOffset;
    public uint mdxTextureUVsOffset;
    public uint mdxLightmapUVsOffset;
    public uint mdxTex3Offset; // Speculation?
    public uint mdxTex4Offset; // Speculation?
    public uint mdxBumpMapoffset; // Speculation?
    public uint mdxWeightsOffset; // Speculation?
    public uint mdxWeightIdxOffset; // Speculation?
    public uint mdxUnkownOffset7; // Speculation?

    public ushort vertexCount;
    public ushort textureCount;
    public byte hasLightmap;
    public byte hasShadow1;
    public byte hasShadow2;
    public byte hasShadow3;
    public byte hasRender1;
    public byte hasRender2;
    public byte hasRender3;

    public byte unk6;
    public float totalArea;
    public uint unk7;

    // These two fields are only used in TSL models, not for K1 models
    [BinaryTSL()] public uint unk8;
    [BinaryTSL()] public uint unk9;

    public uint mdxDataOffset;
    public uint verticesOffset;

    //[BinaryPointerArray("facesArray", "mdxDataOffset")] public Face[] faces;
}

[BinaryFixedSize(28)]
public class DanglymeshHeader : BinaryStructure
{
    public uint offsetToConstraints;
    public uint constraintsCount;
    public uint constraintsCount2;
    public float displacement;
    public float tightness;
    public float period;
    public float unknown;
}

[BinaryFixedSize(108)]
public class SkinmeshHeader : BinaryStructure
{
    public PointerArray weightsArray;

    public uint offsetToMDXSkinWeights;
    public uint offsetToMXDXSkinBoneReferenceIndexes;

    public uint offsetBoneMap;
    public uint bonesMapCount;

    public PointerArray boneQuatsArray;
    public PointerArray boneVertsArray;
    public PointerArray boneConstsArray;

    [BinaryArray(typeof(ushort), 17)] public ushort[] unknown;
    public ushort padding;

    [BinaryPointerArray("boneQuatsArray")] public Quat[] quats;
    [BinaryPointerArray("boneVertsArray")] public Vertex[] verts;
    [BinaryPointerArray("boneConstsArray")] public Const[] consts;

    [BinaryCustom("BoneMap")] public int[] boneMap;

    public int BoneMap(byte[] data, int offset, FieldInfo f, object target, Dictionary<string, byte[]> other)
    {
        boneMap = new int[bonesMapCount];

        int pos = (int)offsetBoneMap;
        for (int i = 0; i < bonesMapCount; i++)
        {
            boneMap[i] = (int)BitConverter.ToSingle(data, pos);
            pos += 4;
        }
        return offset;
    }

    //[BinaryCustom("ReadWeights")] public AuroraBoneWeight[] weights;
    //[BinaryCustom("CalculateBoneWeights")] public BoneWeight[] boneWeights;

    //public int CalculateBoneWeights(byte[] data, int offset, FieldInfo f, object target, Dictionary<string, byte[]> other)
    //{
    //    boneWeights = new BoneWeight[weights.Length];
    //    int i = 0;
    //    foreach (AuroraBoneWeight bw in weights)
    //    {
    //        boneWeights[i] = new BoneWeight {
    //            weight0 = bw.w0,
    //            weight1 = bw.w1,
    //            weight2 = bw.w2,
    //            weight3 = bw.w3,
    //            boneIndex0 = (int)bw.b0,
    //            boneIndex1 = (int)bw.b1,
    //            boneIndex2 = (int)bw.b2,
    //            boneIndex3 = (int)bw.b3
    //        };
    //        i++;
    //    }
    //    return offset;
    //}
}

[BinaryFixedSize(20)]
public class SabermeshHeader : BinaryStructure
{
    public uint offsetToVertices;
    public uint offsetToTVertices;
    public uint offsetToUnknown;
    public uint unk1;
    public uint unk2;
}

[BinaryFixedSize(20)]
public class AABBHeader : BinaryStructure
{
    public uint offsetToVertices;
    public uint offsetToTVertices;
    public uint offsetToUnknown;
    public uint unk1;
    public uint unk2;
}
[BinaryFixedSize(20)]
public class ReferenceHeader : BinaryStructure
{
    [BinaryText(64)] public string refModel;
    public uint reattachable;
}

[BinaryFixedSize(20)]
public class EmitterHeader : BinaryStructure
{
    public float deadSpace;
    public float blastRadius;
    public float blastLength;
    public uint numBranches;
    public uint controlptssmoothing;
    public uint xGrid;
    public uint yGrid;
    public uint style;
    [BinaryText(32)] public string update;
    [BinaryText(32)] public string render;
    [BinaryText(32)] public string blend;
    [BinaryText(64)] public string texture;
    [BinaryText(16)] public string chunkName;
    public uint twoSidedTexture;
    public uint loop;
    public uint renderOrder;
    public ushort padding;
    public uint flags;
}
[BinaryFixedSize(20)]
public class LightHeader : BinaryStructure
{
    public float radius;
    public PointerArray unkArray;
    public PointerArray sizeArray;
    public PointerArray posArray;
    public PointerArray colorShiftsArray;
    public PointerArray flareTexturePointersArray;
    public uint priority;
    public uint ambientOnly;
    public uint dynamicType;
    public uint affectDynamic;
    public uint shadow;
    public uint generateFlare;
    public uint fadingLight;

    //[BinaryPointerArray("unkArray")] public ConstInt[] unk;
    [BinaryPointerArray("sizeArray")] public Const[] flareSizes;
    [BinaryPointerArray("posArray")] public Const[] flarePos;

    // MDLOps skips this, and it bugs out when I try to load it,
    // so maybe there's a problem with the implementation here?
    //[BinaryPointerArray("colorShifts")] public Vertex[] colorShifts;

    [BinaryPointerArray("flareTexturePointersArray")] public Pointer[] flareTexturePointers;
    [BinaryDerefArray("flareTexturePointersArray", "flareTexturePointers")] public FlareTextureName[] flareTextureNames;
}

public class AInt : BinaryStructure
{

}

public class FlareTextureName : BinaryStructure
{
    [BinaryText(64)] public string texName;
}


[BinaryFixedSize(32)]
public class AuroraBoneWeight : BinaryStructure
{
    public float w0, w1, w2, w3;
    public float b0, b1, b2, b3;
}


[BinaryFixedSize(12)]
public class Vertex : BinaryStructure
{
    public float x, y, z;

    public Vector3 ToVector3 ()
    {
        //return new Vector3(x, y, z);
        return new Vector3(x, z, y);
    }
}

[BinaryFixedSize(16)]
public class Quat : BinaryStructure
{
    public float x, y, z, w;

    public Quaternion ToQuaternion ()
    {
        //return new Quaternion(x, y, z, w);
        return new Quaternion(-x, -z, -y, w);
    }
}

[BinaryFixedSize(2)]
public class Const : BinaryStructure
{
    public float c;
}

public class ConstInt : BinaryStructure
{
    public int c;
}

[BinaryFixedSize(12)]
public class UV : BinaryStructure
{
    public float x, y;
}

[BinaryFixedSize(32)]
public class Face : BinaryStructure
{
    //public Vertex norma;
    //public float planeCoefficient;
    //public uint material;

    //public ushort faceAdjacency1;
    //public ushort faceAdjacency2;
    //public ushort faceAdjacency3;
    public ushort vertex1;
    public ushort vertex2;
    public ushort vertex3;
}

[BinaryVariableSize()]
public class MeshNode : BinaryStructure
{

}