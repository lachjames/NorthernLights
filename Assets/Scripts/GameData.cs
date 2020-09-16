﻿using AuroraEngine;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using UnityEngine;

public class AuroraData
{
    Game game = Game.KotOR;

    string moduleName;
    public RIMObject rim, srim;
    public ERFObject dlg, mod;

    public StateSystem stateManager;
    public AISystem aiManager;
    public LoadingSystem loader;

    public KEYObject keyObject;
    public BIFObject[] bifObjects;
    public ERFObject textures, guiTextures;
    public Module module;

    public Dictionary<string, ERFObject> lips = new Dictionary<string, ERFObject>();
    public Dictionary<string, string> voLocations = new Dictionary<string, string>();

    public Dictionary<string, _2DAObject> loaded2das = new Dictionary<string, _2DAObject>();
    public TLKObject tlk;

    public AuroraData(Game game, string moduleName)
    {
        this.game = game;
        this.moduleName = moduleName;

        stateManager = GameObject.Find("State System").GetComponent<StateSystem>();
        aiManager = GameObject.Find("AI System").GetComponent<AISystem>();
        loader = GameObject.Find("Loading System").GetComponent<LoadingSystem>();

        LoadBase();

        if (moduleName != null)
            LoadModule();
    }

    void LoadBase ()
    {
        loaded2das = new Dictionary<string, _2DAObject>();

        keyObject = new KEYObject(loader.kotorDir + "\\chitin.key");

        KEYObject.BIFStream[] bifs = keyObject.GetBIFs();
        bifObjects = new BIFObject[bifs.Length];
        for (int i = 0; i < bifs.Length; i++)
        {
            bifObjects[i] = new BIFObject(loader.kotorDir + "\\" + bifs[i].Filename);
        }

        textures = new ERFObject(loader.kotorDir + "\\TexturePacks\\swpc_tex_tpa.erf");
        guiTextures = new ERFObject(loader.kotorDir + "\\TexturePacks\\swpc_tex_gui.erf");

        // Load the VO directory
        foreach (string filepath in Directory.GetFiles(loader.kotorDir + "\\streamwaves", "*.wav", SearchOption.AllDirectories))
        {
            string filename = filepath.Split('\\').Last().Replace(".wav", "");
            voLocations[filename.ToLower()] = filepath;
        }

        string tlkXML = RunXoreosTools(loader.kotorDir + "/dialog.tlk", "tlk2xml", "--kotor");
        tlk = new TLKObject(tlkXML);

        UnityEngine.Debug.Log("Loaded " + tlk.strings.Count + " strings from the TLK");
    }

    void LoadModule ()
    {
        rim = new RIMObject(loader.kotorDir + "\\modules\\" + moduleName + ".rim");
        srim = new RIMObject(loader.kotorDir + "\\modules\\" + moduleName + "_s.rim");

        UnityEngine.Debug.Log("Loaded " + rim.resources.Keys.Count + " items from " + moduleName + ".rim");
        UnityEngine.Debug.Log("Loaded " + srim.resources.Keys.Count + " items from " + moduleName + "_s.rim");

        module = new Module(moduleName, this);
    }

    public string From2DA(string name, int idx, string row)
    {
        if (!loaded2das.ContainsKey(name))
        {
            Load2DA(name);
        }
        _2DAObject _2da = loaded2das[name];
        return _2da[idx, row];
    }

    public _2DAObject Load2DA(string resref)
    {
        _2DAObject _2da;

        if (loaded2das.TryGetValue(resref, out _2da))
        {
            return _2da;
        }

        Stream stream = GetStreamFromBase(resref, ResourceType.TDA);
        if (stream == null)
        {
            UnityEngine.Debug.LogWarning("Missing 2da: " + resref);
            return null;
        }
        else
        {
            _2da = new _2DAObject(stream);
            loaded2das.Add(resref, _2da);
            return _2da;
        }
    }


    public T Get<T> (string resref, ResourceType rt)
    {
        // Check the override folder

        // Check the module
        T obj = GetFromModule<T>(resref, rt);
        if (obj != null)
            return obj;

        // Check the base game files
        obj = GetFromBase<T>(resref, rt);
        if (obj != null)
            return obj;

        return default;
    }

    public Stream GetStream (string resref, ResourceType rt)
    {
        Stream stream = GetStreamFromModule(resref, rt);
        if (stream != null)
            return stream;

        return GetStreamFromBase(resref, rt);
    }

    public Stream GetStreamFromModule (string resref, ResourceType rt)
    {
        // Check if the item is in the rim

        Stream stream = rim.GetResource(resref, rt);

        if (stream == null)
        {
            stream = srim.GetResource(resref, rt);
        }
        if (stream == null && dlg != null)
        {
            stream = dlg.GetResource(resref, rt);
        }
        if (stream == null && mod != null)
        {
            stream = mod.GetResource(resref, rt);
        }

        if (stream == null)
        {
            UnityEngine.Debug.LogWarning("Failed to load file " + resref + " of type " + rt);
        }

        return stream;
    }

    public T GetFromModule<T> (string resref, ResourceType rt)
    {
        Stream stream = GetStreamFromModule(resref, rt);

        if (stream == null)
            return default;

        GFFObject obj = new GFFLoader(stream).GetObject();

        return (T)obj.Serialize<T>();
    }

    public T GetFromBase<T> (string resref, ResourceType rt)
    {
        Stream stream = GetStreamFromBase(resref, rt);

        if (stream == null)
            return default;

        GFFObject gff = new GFFLoader(stream).GetObject();
        return (T)gff.Serialize<T>();
    }

    public Stream GetStreamFromBase (string resref, ResourceType type)
    {
        Stream resourceStream;
        uint id;

        // Then try and load from BIFs
        if (keyObject.TryGetResourceID(resref, type, out id))
        {
            uint bifIndex = id >> 20;
            BIFObject bif = bifObjects[bifIndex];

            return bif.GetResourceData(bif.GetResourceById(id));
        }

        // Try to load from lip ERFs
        foreach (ERFObject erf in lips.Values)
        {
            if ((resourceStream = erf.GetResource(resref, ResourceType.LIP)) != null)
            {
                return resourceStream;
            }
        }

        // And finally, try and load from global ERFs
        if ((resourceStream = textures.GetResource(resref, type)) != null)
        {
            return resourceStream;
        }
        if ((resourceStream = guiTextures.GetResource(resref, type)) != null)
        {
            return resourceStream;
        }

        return resourceStream;
    }

    public static string RunXoreosTools(string loc, string utility, string arguments)
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