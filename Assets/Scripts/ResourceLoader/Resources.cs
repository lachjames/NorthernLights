using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using UnityEngine;
using UnityEngine.Video;

namespace AuroraEngine
{
    public enum Game
	{
        KotOR, TSL
    }

    public enum Compatibility
    {
        KotOR, TSL, BOTH
    }

    public enum ExistsIn
    {
        BASE, SAVE, BOTH
    }

    // Reference: https://github.com/xoreos/xoreos/blob/master/src/aurora/types.h
    public enum ResourceType
    {
        None = -1,
        RES = 0, // Generic GFF.
        BMP = 1, // Image, Windows bitmap.
        MVE = 2, // Video, Infinity Engine.
        TGA = 3, // Image, Truevision TARGA image.
        WAV = 4, // Audio, Waveform.
        PLT = 6, // Packed layer texture.
        INI = 7, // Configuration, Windows INI.
        BMU = 8, // Audio, MP3 with extra header.
        MPG = 9, // Video, MPEG.
        TXT = 10, // Text, raw.
        WMA = 11, // Audio, Windows media.
        WMV = 12, // Video, Windows media.
        XMV = 13, // Video, Xbox.
        PLH = 2000,
        TEX = 2001, // Texture.
        MDL = 2002, // Geometry, BioWare model.
        THG = 2003,
        FNT = 2005, // Font.
        LUA = 2007, // Script, LUA source.
        SLT = 2008,
        NSS = 2009, // Script, NWScript source.
        NCS = 2010, // Script, NWScript bytecode.
        MOD = 2011, // Module, ERF.
        ARE = 2012, // Static area data, GFF.
        SET = 2013, // Tileset.
        IFO = 2014, // Module information, GFF.
        BIC = 2015, // Character data, GFF.
        WOK = 2016, // Walk mesh.
        TDA = 2017, // Table data, 2-dimensional text array.
        TLK = 2018, // Talk table.
        TXI = 2022, // Texture information.
        GIT = 2023, // Dynamic area data, GFF.
        BTI = 2024, // Item template (BioWare), GFF.
        UTI = 2025, // Item template (user), GFF.
        BTC = 2026, // Creature template (BioWare), GFF.
        UTC = 2027, // Creature template (user), GFF.
        DLG = 2029, // Dialog tree, GFF.
        ITP = 2030, // Toolset "palette" (tree of tiles or object templates), GFF.
        BTT = 2031, // Trigger template (BioWare), GFF.
        UTT = 2032, // Trigger template (user), GFF.
        DDS = 2033, // Texture, DirectDraw Surface.
        BTS = 2034, // Sound template (BioWare), GFF.
        UTS = 2035, // Sound template (user), GFF.
        LTR = 2036, // Letter combo probability information.
        GFF = 2037, // Generic GFF.
        FAC = 2038, // Faction information, GFF.
        BTE = 2039, // Encounter template (BioWare), GFF.
        UTE = 2040, // Encounter template (user), GFF.
        BTD = 2041, // Door template (BioWare), GFF.
        UTD = 2042, // Door template (user), GFF.
        BTP = 2043, // Placeable template (BioWare), GFF.
        UTP = 2044, // Placeable template (user), GFF.
        DFT = 2045, // Default values.
        DTF = 2045, // Default value file, INI.
        GIC = 2046, // Game instance comments, GFF.
        GUI = 2047, // GUI definition, GFF.
        CSS = 2048, // Script, conditional source script.
        CCS = 2049, // Script, conditional compiled script.
        BTM = 2050, // Store template (BioWare), GFF.
        UTM = 2051, // Store template (user), GFF.
        DWK = 2052, // Door walk mesh.
        PWK = 2053, // Placeable walk mesh.
        BTG = 2054, // Random item generator template (BioWare), GFF.
        UTG = 2055, // Random item generator template (user), GFF.
        JRL = 2056, // Journal data, GFF.
        SAV = 2057, // Game save, ERF.
        UTW = 2058, // Waypoint template, GFF.
        FPC = 2059, // Texture, custom 16-bit RGBA.
        SSF = 2060, // Sound Set File.
        HAK = 2061, // Resource hak pak, ERF.
        NWM = 2062, // Neverwinter Nights original campaign module, ERF.
        BIK = 2063, // Video, RAD Game Tools Bink.
        NDB = 2064, // Script debugger file.
        PTM = 2065, // Plot instance/manager, GFF.
        PTT = 2066, // Plot wizard template, GFF.
        NCM = 2067,
        MFX = 2068,
        MAT = 2069, // Material.
        MDB = 2070, // Geometry, BioWare model.
        SAY = 2071,
        TTF = 2072, // Font, True Type.
        TTC = 2073,
        CUT = 2074, // Cutscene, GFF.
        KA = 2075, // Karma, XML.
        JPG = 2076, // Image, JPEG.
        ICO = 2077, // Icon, Windows ICO.
        OGG = 2078, // Audio, Ogg Vorbis.
        SPT = 2079, // Tree data SpeedTree.
        SPW = 2080,
        WFX = 2081, // Woot effect class, XML.
        UGM = 2082,
        QDB = 2083, // Quest database, GFF.
        QST = 2084, // Quest, GFF.
        NPC = 2085,
        SPN = 2086,
        UTX = 2087,
        MMD = 2088,
        SMM = 2089,
        UTA = 2090,
        MDE = 2091,
        MDV = 2092,
        MDA = 2093,
        MBA = 2094,
        OCT = 2095,
        BFX = 2096,
        PDB = 2097,
        TheWitcherSave = 2098, // Game save in The Witcher.
        PVS = 2099,
        CFX = 2100,
        LUC = 2101, // Script, LUA bytecode.
        PRB = 2103,
        CAM = 2104, // Campaign information.
        VDS = 2105,
        BIN = 2106,
        WOB = 2107,
        API = 2108,
        Properties = 2109,
        PNG = 2110, // Image, Portable Network Graphics.
        LYT = 3000, // Area data, room layout.
        VIS = 3001, // Area data, room visibilities.
        RIM = 3002, // Module resources, RIM.
        PTH = 3003, // Path finder data, GFF.
        LIP = 3004, // Lipsync data.
        BWM = 3005,
        TXB = 3006, // Texture.
        TPC = 3007, // Texture.
        MDX = 3008, // Geometry, model mesh data.
        RSV = 3009,
        SIG = 3010,
        MAB = 3011, // Material, binary.
        QST2 = 3012, // Quest, GFF.
        STO = 3013, // GFF.
        HEX = 3015, // Hex grid file.
        MDX2 = 3016, // Geometry, model mesh data.
        TXB2 = 3017, // Texture.
        FSM = 3022, // Finite State Machine data.
        ART = 3023, // Area environment settings, INI.
        AMP = 3024, // Brightening control.
        CWA = 3025, // Crowd attributes, GFF.
        BIP = 3028, // Lipsync data, binary LIP.
        MDB2 = 4000,
        MDA2 = 4001,
        SPT2 = 4002,
        GR2 = 4003,
        FXA = 4004,
        FXE = 4005,
        JPG2 = 4007,
        PWC = 4008,
        ODA = 9996, // Table data, 1-dimensional text array.
        ERF = 9997, // Module resources.
        BIF = 9998, // Game resource data.
        KEY = 9999, // Game resource index.

        /** The upper limit for numerical type IDs found in archives. */
        MAXArchive,

        /* --- Entries for files not found in archives with numerical type IDs --- */

        // Found in NWN
        EXE = 19000, // Windows PE EXE file.
        DBF = 19001, // xBase database.
        CDX = 19002, // FoxPro database index.
        FPT = 19003, // FoxPro database memo file.

        // Found in NWN2's ZIP files
        ZIP = 20000, // Face bone definitions, FaceFX Actor.
        FXM = 20001, // Face metadata, FaceFX.
        FXS = 20002, // Face metadata, FaceFX.
        XML = 20003, // Extensible Markup Language.
        WLK = 20004, // Walk mesh.
        UTR = 20005, // Tree template (user), GFF.
        SEF = 20006, // Special effect file.
        PFX = 20007, // Particle effect.
        TFX = 20008, // Trail effect.
        IFX = 20009,
        LFX = 20010, // Line effect.
        BBX = 20011, // Billboard effect.
        PFB = 20012, // Prefab blueprint.
        UPE = 20013,
        USC = 20014,
        ULT = 20015, // Light template (user), GFF.
        FX = 20016,
        MAX = 20017,
        DOC = 20018,
        SCC = 20019,
        WMP = 20020, // World map, GFF.
        OSC = 20021,
        TRN = 20022,
        UEN = 20023,
        ROS = 20024,
        RST = 20025,
        PTX = 20026,
        LTX = 20027,
        TRX = 20028,

        // Found in Sonic Chronicles: The Dark Brotherhood
        NDS = 21000, // Archive, Nintendo DS ROM file.
        HERF = 21001, // Archive, hashed ERF.
        DICT = 21002, // HERF file name -> hashes dictionary.
        SMALL = 21003, // Compressed file, Nintendo LZSS.
        CBGT = 21004,
        CDPTH = 21005,
        EMIT = 21006,
        ITM = 21007, // Items, 2DA.
        NANR = 21008, // Animation, Nitro ANimation Resource.
        NBFP = 21009, // Palette, Nitro Basic File Palette.
        NBFS = 21010, // Image, Map, Nitro Basic File Screen.
        NCER = 21011, // Image, Nitro CEll Resource.
        NCGR = 21012, // Image, Nitro Character Graphic Resource.
        NCLR = 21013, // Palette, Nitro CoLoR.
        NFTR = 21014, // Font.
        NSBCA = 21015, // Model Animation.
        NSBMD = 21016, // Model.
        NSBTA = 21017, // Texture animation.
        NSBTP = 21018, // Texture part.
        NSBTX = 21019, // Texture.
        PAL = 21020, // Palette.
        RAW = 21021, // Image, raw.
        SADL = 21022,
        SDAT = 21023, // Audio, Sound DATa.
        SMP = 21024,
        SPL = 21025, // Spells, 2DA.
        VX = 21026, // Video, Actimagine.

        // Found in Dragon Age: Origins
        ANB = 22000, // Animation blend.
        ANI = 22001, // Animation sequence.
        CNS = 22002, // Script, client script source.
        CUR = 22003, // Cursor, Windows cursor.
        EVT = 22004, // Animation event.
        FDL = 22005,
        FXO = 22006,
        GAD = 22007, // GOB Animation Data.
        GDA = 22008, // Table data, GFF'd 2DA, 2-dimensional text array.
        GFX = 22009, // Vector graphics animation, Scaleform GFx.
        LDF = 22010, // Language definition file.
        LST = 22011, // Area list.
        MAL = 22012, // Material Library.
        MAO = 22013, // Material Object.
        MMH = 22014, // Model Mesh Hierarchy.
        MOP = 22015,
        MOR = 22016, // Head Morph.
        MSH = 22017, // Mesh.
        MTX = 22018,
        NCC = 22019, // Script, compiled client script.
        PHY = 22020, // Physics, Novodex collision info.
        PLO = 22021, // Plot information.
        STG = 22022, // Cutscene stage.
        TBI = 22023,
        TNT = 22024, // Material tint.
        ARL = 22025, // Area layout.
        FEV = 22026, // FMOD Event.
        FSB = 22027, // Audio, FMOD sound bank.
        OPF = 22028,
        CRF = 22029,
        RIMP = 22030,
        MET = 22031, // Resource meta information.
        META = 22032, // Resource meta information.
        FXR = 22033, // Face metadata, FaceFX.
        FXT = 22033, // Face metadata, FaceFX.
        CIF = 22034, // Campaign Information File, GFF4.
        CUB = 22035,
        DLB = 22036,
        NSC = 22037, // NWScript client script source.

        // Found in KotOR Mac
        MOV = 23000, // Video, QuickTime/MPEG-4.
        CURS = 23001, // Cursor, Mac CURS format.
        PICT = 23002, // Image, Mac PICT format.
        RSRC = 23003, // Mac resource fork.
        PLIST = 23004, // Mac property list (XML).

        // Found Jade Empire
        CRE = 24000, // Creature, GFF.
        PSO = 24001, // Shader.
        VSO = 24002, // Shader.
        ABC = 24003, // Font, character descriptions.
        SBM = 24004, // Font, character bitmap data.
        PVD = 24005,
        PLA = 24006, // Placeable, GFF.
        TRG = 24007, // Trigger, GFF.
        PK = 24008,

        // Found in Dragon Age II
        ALS = 25000,
        APL = 25001,
        Assembly = 25002,
        BAK = 25003,
        BNK = 25004,
        CL = 25005,
        CNV = 25006,
        CON = 25007,
        DAT = 25008,
        DX11 = 25009,
        IDS = 25010,
        LOG = 25011,
        MAP = 25012,
        MML = 25013,
        MP3 = 25014,
        PCK = 25015,
        RML = 25016,
        S = 25017,
        STA = 25018,
        SVR = 25019,
        VLM = 25020,
        WBD = 25021,
        XBX = 25022,
        XLS = 25023,

        // Found in the iOS version of Knights of the Old Republic
        BZF = 26000, // Game resource data, LZMA-compressed BIF.

        // Found in The Witcher
        ADV = 27000, // Extra adventure modules, ERF.

        // Found in the Android version of Jade Empire
        JSON = 28000, // JavaScript Object Notation.
        TLK_EXPERT = 28001, // Talk table for extra expert-level control strings, plain text.
        TLK_MOBILE = 28002, // Talk table for extra mobile port strings, plain text.
        TLK_TOUCH = 28003, // Talk table for extra touch control strings, plain text.
        OTF = 28004, // OpenType Font.
        PAR = 28005,

        // Found in the Xbox version of Jade Empire
        XWB = 29000, // XACT WaveBank.
        XSB = 29001, // XACT SoundBank.

        // Found in the Xbox version of Dragon Age: Origins
        XDS = 30000, // Texture.
        WND = 30001,

        // Our own types
        XEOSITEX = 40000, // Intermediate texture.

        // Found in the updated Neverwinter Nights
        WBM = 41000  // Video, WebM.
    }

    public static partial class Resources
	{
        public static AuroraData data;
        
		private static Game targetGame = Game.KotOR;

        public const int ANISO_LEVEL = 16;

        static Dictionary<string, Texture2D> loadedTextures = new Dictionary<string, Texture2D>();
        static Dictionary<string, Texture2D> loadedNormals = new Dictionary<string, Texture2D>();
        static Dictionary<string, Texture2D> loadedSpeculars = new Dictionary<string, Texture2D>();
        static Dictionary<string, NCSScript> scriptCache = new Dictionary<string, NCSScript>();

        public static void Load (string moduleName)
        {
            data = new AuroraData(targetGame, moduleName);
        }

		public static Texture2D LoadTexture2D(string resref)
		{
            if (!loadedTextures.ContainsKey(resref))
            {
                Texture2D tex;
                Stream stream;
                if (null != (stream = data.GetStream(resref, ResourceType.TPC)))
                {
                    TPCObject tpc = new TPCObject(stream);

                    tex = new Texture2D(tpc.Width, tpc.Height, tpc.Format, false);

                    tex.LoadRawTextureData(tpc.RawData);
                    tex.Apply();

                    tex.anisoLevel = ANISO_LEVEL;

                }
                else if (null != (stream = data.GetStream(resref, ResourceType.TGA)))
                {
                    tex = TGALoader.LoadTGA(stream);
                    tex.anisoLevel = ANISO_LEVEL;
                }
                else
                {
                    //Debug.Log("Missing texture: " + resref);
                    return new Texture2D(1, 1);
                }
                //loadedTextures[resref + "_base"] = tex;
                //tex = ImageFilter.Upscale(tex);

                loadedTextures[resref] = tex;
            }

            //return NormalGeneration.Diff2Normal(loadedTextures[resref]);
            return loadedTextures[resref];
        }

        public static Texture2D LoadNormal(string resref)
        {
            if (!loadedNormals.ContainsKey(resref))
            //if (!loadedNormals.ContainsKey(resref + "_base"))
            {
                loadedNormals[resref] = NormalMapTools.CreateNormalmap(loadedTextures[resref], 1f);
                //loadedNormals[resref] = NormalMapTools.CreateNormalmap(loadedTextures[resref + "_base"], 1f);
            }

            return loadedNormals[resref];
        }

        public static Texture2D LoadSpecular(string resref)
        {
            if (!loadedSpeculars.ContainsKey(resref))
            {
                loadedSpeculars[resref] = NormalMapTools.CreateSpecular(loadedTextures[resref], 1f, 0.5f);
            }

            return loadedSpeculars[resref];
        }

        public static Texture2D GenerateSpecularMap (Texture2D diffuse, float strength = 1f, float cutoff = 0.5f)
        {
            Texture2D spec = NormalMapTools.CreateSpecular(diffuse, strength, cutoff);
            return NormalMapTools.CombineRGBAndSpecular(diffuse, spec);
        }

        public static Texture2D GenerateBumpMap (Texture2D diffuse, float strength = 1f)
        {
            return NormalMapTools.CreateNormalmap(diffuse, strength);
        }

        public static NCSScript LoadScript(string resourceRef)
        {
            if (!scriptCache.ContainsKey(resourceRef))
            {
                Stream stream = data.GetStream(resourceRef, ResourceType.NCS);
                if (stream == null)
                {
                    UnityEngine.Debug.Log("Missing ncs: " + resourceRef);
                    return null;
                }

                scriptCache[resourceRef] = new NCSScript(stream, resourceRef);
            }

            return scriptCache[resourceRef];
        }

        public static string From2DA (string name, int idx, string row)
        {
            if (!data.loaded2das.ContainsKey(name))
            {
                Load2DA(name);
            }
            _2DAObject _2da = data.loaded2das[name];
            return _2da[idx, row];
        }

        public static TLKObject LoadTLK()
        {
            string xml = RunXoreosTools(AuroraPrefs.GetKotorLocation() + "/dialog.tlk", "tlk2xml", "--kotor");
            return new TLKObject(xml);
        }

        public static string GetString (int strref)
        {
            if (!data.tlk.strings.ContainsKey(strref))
            {
                return "";
            }
            return data.tlk.strings[strref].str;
        }

        public static VideoClip LoadMovie(string resourceRef)
        {
            return (VideoClip)UnityEngine.Resources.Load("movies/" + resourceRef, typeof(VideoClip));
        }

        public static Material LoadParticleMaterial(string matName)
        {
            Material mat = new Material(Shader.Find("Legacy Shaders/Particles/Alpha Blended"));
            Texture2D tex = LoadTexture2D(matName);

            // Settings source: https://forum.unity.com/threads/change-rendering-mode-via-script.476437/

            if (tex)
            {
                mat.SetTexture("_MainTex", tex);
            }
            return mat;
        }

        public static Material LoadMaterial(string diffuse, string lightmap = null, string cubemap = null)
		{
            Material mat = new Material(Shader.Find("Standard"));

            if (cubemap != null)
            {
                // Material should be reflective
            }

            //mat.SetFloat("_Metallic.Second", 1f);

            Texture2D tDiffuse = LoadTexture2D(diffuse);
            Texture2D tNormal = LoadNormal(diffuse);
            //Texture2D tSpecular = LoadSpecular(diffuse);
            //Texture2D tNormal = NormalGeneration.Diff2Normal(tDiffuse);
            if (tDiffuse) {
                // Diffuse map
				mat.SetTexture("_MainTex", tDiffuse);
                
                // Normal map
                mat.EnableKeyword("_NORMALMAP");
                mat.SetTexture("_BumpMap", tNormal);
                mat.SetFloat("_BumpScale", 0.5f);

                // Specular map
                //mat.EnableKeyword("_SPECGLOSSMAP");
                //mat.SetTexture("_SpecGlossMap", tSpecular);
            }

            Texture2D tLightmap;
            if (lightmap != null && (tLightmap = LoadTexture2D(lightmap)))
            {
                //LightmapData lm = new LightmapData();
                //lm.lightmapColor = tLightmap;
                mat.SetTexture("_LightMap", tLightmap);
            }

            return mat;
		}

		public static _2DAObject Load2DA(string resref)
		{
			_2DAObject _2da;

			if (data.loaded2das.TryGetValue(resref, out _2da)) {
				return _2da;
			}

			Stream stream = data.GetStream(resref, ResourceType.TDA);
			if (stream == null) {
				UnityEngine.Debug.LogWarning("Missing 2da: " + resref);
				return null;
			} else {
				_2da = new _2DAObject(stream);
                data.loaded2das.Add(resref, _2da);
				return _2da;
			}
		}

        public static LIP LoadLipSync(string resref)
        {
            // Load the stream
            Stream stream = data.GetStream(resref, ResourceType.LIP);

            if (stream == null)
            {
                UnityEngine.Debug.LogWarning("Missing lip: " + resref);
                return null;
            }

            // Read the lip file
            LIP lip = new LIP();
            Dictionary<string, Stream> other = new Dictionary<string, Stream>
            {
                { "lip", stream }
            };
            lip.Load(stream, other);

            return lip;
        }

        public static AudioClip LoadAudio(string resref)
        {
            using (FileStream stream = File.Open(AuroraPrefs.GetKotorLocation() + "\\streammusic\\" + resref + ".wav", FileMode.Open)) {
				WAVObject wav = new WAVObject(stream);

				AudioClip clip = AudioClip.Create(resref, wav.data.Length / wav.channels, wav.channels, wav.sampleRate, false);
				clip.SetData(wav.data, 0);

				return clip;
			}
		}

        public static AudioClip LoadVO (string resref, int index)
        {
            resref = resref.ToLower();

            AudioClip clip;

            if (data.voLocations.ContainsKey(resref))
            {
                // We know where the VO file is located
                using (FileStream stream = File.Open(data.voLocations[resref], FileMode.Open))
                {
                    WAVObject wav = new WAVObject(stream);

                    clip = AudioClip.Create(resref, wav.data.Length / wav.channels, wav.channels, wav.sampleRate, false);
                    clip.SetData(wav.data, 0);

                    return clip;
                }
            }

            if (!data.tlk.strings.ContainsKey(index))
            {
                return null;
            }

            if (data.tlk.strings[index].sound != null && data.tlk.strings[index].sound != "")
            {
                return LoadVO(data.tlk.strings[index].sound, -1);
            }

            return null;
        }

        static AudioClip LoadVOAlternative (string resref)
        {
            // Check if the resref is long enough
            if (resref.Length <= 11)
            {
                return null;
            }
            resref = resref.Replace("_", "") + "_";

            // Firstly, check if it's in the top-level


            // The first five characters are the top-level folder
            string topFolder = resref.Substring(1, 5);
            // Next six characters are the subfolder
            string subFolder = resref.Substring(6, 6);

            string fullname = AuroraPrefs.GetKotorLocation() + "\\streamwaves\\" + topFolder + "\\" + subFolder + "\\" + resref + ".wav";

            if (!File.Exists(fullname))
            {
                UnityEngine.Debug.Log("Did not find resref " + resref + " with filename " + fullname);
                return null;
            }

            using (FileStream stream = File.Open(fullname, FileMode.Open))
            {
                WAVObject wav = new WAVObject(stream);

                AudioClip clip = AudioClip.Create(resref, wav.data.Length / wav.channels, wav.channels, wav.sampleRate, false);
                clip.SetData(wav.data, 0);

                return clip;
            }
        }

        public static string RunXoreosTools(Stream stream, string utility, string arguments)
        {
            byte[] buffer = new byte[stream.Length];
            stream.Read(buffer, 0, (int)stream.Length);

            FileStream filestream = File.Create("D:\\KOTOR\\KotOR-Unity\\tmp\\tmp.ncs");
            stream.Seek(0, SeekOrigin.Begin);
            stream.CopyTo(filestream);
            filestream.Close();

            return RunXoreosTools("D:\\KOTOR\\KotOR-Unity\\tmp\\tmp.ncs", utility, arguments);
        }

        public static string RunXoreosTools(string loc, string utility, string arguments, string workingdir = null)
        {
            // Then we read it using xoreos-tools's disassembler
            Process p = new Process();
            p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.FileName = "D:\\KOTOR\\KOTOR1\\KotOR-Unity\\xt\\" + utility + ".exe";
            p.StartInfo.Arguments = arguments + " " + loc;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.EnableRaisingEvents = true;

            if (workingdir != null)
            {
                p.StartInfo.WorkingDirectory = workingdir;
            }

            StringBuilder outputBuilder = new StringBuilder();
            StringBuilder errorBuilder = new StringBuilder();

            using (AutoResetEvent outputWaitHandle = new AutoResetEvent(false))
            using (AutoResetEvent errorWaitHandle = new AutoResetEvent(false))
            {
                p.OutputDataReceived += (sender, e) => {
                    if (e.Data == null)
                    {
                        outputWaitHandle.Set();
                    }
                    else
                    {
                        outputBuilder.AppendLine(e.Data);
                    }
                };
                p.ErrorDataReceived += (sender, e) =>
                {
                    if (e.Data == null)
                    {
                        errorWaitHandle.Set();
                    }
                    else
                    {
                        errorBuilder.AppendLine(e.Data);
                    }
                };

                p.Start();

                p.BeginOutputReadLine();
                p.BeginErrorReadLine();

                if (p.WaitForExit(1000) &&
                    outputWaitHandle.WaitOne() &&
                    errorWaitHandle.WaitOne())
                {
                    // Process completed. Check process.ExitCode here.
                }
                else
                {
                    // Timed out.
                }
            }

            string output = outputBuilder.ToString();
            string error = errorBuilder.ToString();

            if (error != "")
            {
                UnityEngine.Debug.Log("Xoreos error output: " + error);
            }

            UnityEngine.Debug.Log(output);

            // Finally, we run the normal NCSScript reader on that
            return output;
        }
    }
}