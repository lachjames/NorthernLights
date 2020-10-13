using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cutscene
{
    public List<CutsceneShot> shots = new List<CutsceneShot>();

    Dictionary<string, string> CreateScripts ()
    {
        // For each shot, create a script
        Dictionary<string, string> scripts = new Dictionary<string, string>();

        foreach (CutsceneShot shot in shots)
        {
            scripts[shot.shotName] = shot.GenerateScript();
        }

        return scripts;
    }

    AuroraDLG CreateDLG ()
    {
        throw new System.Exception();
    }
}

public class CutsceneShot
{
    public string shotName = "shot";
    public List<ShotEffect> effects = new List<ShotEffect>();

    public string shotTalker, shotDialog, shotCamera;

    string template = "  DelayCommand({0}, ExecuteScript({1}, OBJECT_SELF));\n";
    public string GenerateScript ()
    {
        string script = "void main() {\n";

        foreach (ShotEffect effect in effects)
        {
            string effectLine = string.Format(template, effect.startTime, effect.effectName);
            script += effectLine;
        }

        script += "}";

        return script;
    }
}

public abstract class ShotEffect
{
    public string effectName = "effect";
    public float startTime;

    public abstract void ShowEditor();
    public abstract string GenerateScript();
}