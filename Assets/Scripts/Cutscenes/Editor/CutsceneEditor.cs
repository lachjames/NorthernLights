using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;
using System.Linq;
using System.Runtime.Remoting.Activation;

public class CutsceneEditor : EditorWindow
{
    Cutscene cutscene;
    CutsceneShot curShot;
    ShotEffect curEffect;

    int newEffectType;

    Vector2 shotScroll, effectScroll;
    int selectedEffect;

    static List<Type> effectTypes = new List<Type>();

    // Add menu named "My Window" to the Window menu
    [MenuItem("KotOR/Cutscene Editor")]
    static void Init()
    {
        // Get existing open window or if none, make a new one:
        CutsceneEditor window = (CutsceneEditor)EditorWindow.GetWindow(typeof(CutsceneEditor));
        window.Show();
    }


    public void OnGUI()
    {
        if (effectTypes.Count == 0)
        {
            // Cache the effect types using Reflection
            // Reference: https://stackoverflow.com/questions/8928464/for-an-object-can-i-get-all-its-subclasses-using-reflection-or-other-ways
            effectTypes = new List<Type>(
                typeof(ShotEffect).Assembly.GetTypes().Where(
                    type => type.IsSubclassOf(typeof(ShotEffect))
                )
            );
        }

        using (new EditorGUILayout.VerticalScope())
        {
            TopBar();
            Editor();
        }
    }

    void TopBar ()
    {
        using (new EditorGUILayout.HorizontalScope())
        {
            if (GUILayout.Button("New Cutscene"))
            {
                NewCutscene();
            }

            if (GUILayout.Button("Load Cutscene"))
            {
                LoadCutscene();
            }
            if (GUILayout.Button("Save Cutscene"))
            {
                SaveCutscene();
            }
        }
    }

    void LoadCutscene ()
    {

    }

    void SaveCutscene()
    {

    }

    void NewCutscene ()
    {
        cutscene = new Cutscene();
    }

    void Editor ()
    {
        if (cutscene == null)
        {
            return;
        }
        using (new EditorGUILayout.HorizontalScope())
        {
            LeftSidebar();
            ShotEditor();
        }
    }

    void LeftSidebar ()
    {
        using (new EditorGUILayout.VerticalScope(GUILayout.Width(200)))
        {
            // Editor buttons
            if (GUILayout.Button("New Shot"))
            {
                AddShot();
            }

            List<string> effectTypeNames = new List<string>();
            foreach (Type t in effectTypes)
            {
                effectTypeNames.Add(t.Name);
            }
            newEffectType = EditorGUILayout.Popup(newEffectType, effectTypeNames.ToArray());

            if (GUILayout.Button("Add Effect"))
            {
                AddEffect(effectTypes[newEffectType]);
            }

            // Shot list
            using (var scroll = new EditorGUILayout.ScrollViewScope(shotScroll))
            {
                shotScroll = scroll.scrollPosition;
                foreach (CutsceneShot shot in cutscene.shots)
                {
                    if (GUILayout.Button(shot.shotName))
                    {
                        curShot = shot;
                    }
                }
            }

            // Effect list
            using (var scroll = new EditorGUILayout.ScrollViewScope(effectScroll))
            {
                effectScroll = scroll.scrollPosition;
                foreach (ShotEffect effect in curShot.effects)
                {
                    if (GUILayout.Button(effect.effectName))
                    {
                        curEffect = effect;
                    }
                }
            }
        }
    }

    void AddShot()
    {
        cutscene.shots.Add(new CutsceneShot());
    }

    void AddEffect (Type t)
    {
        ShotEffect effect = (ShotEffect)Activator.CreateInstance(t);
        curShot.effects.Add(effect);
        effect.effectName = t.Name + curShot.effects.Count;
    }

    void ShotEditor ()
    {
        if (curShot == null)
        {
            return;
        }
        using (new EditorGUILayout.VerticalScope())
        {
            using (new EditorGUILayout.HorizontalScope())
            {
                GUILayout.Label("Shot Name:", GUILayout.Width(200));
                curShot.shotName = EditorGUILayout.TextField(curShot.shotName);
            }
            using (new EditorGUILayout.HorizontalScope())
            {
                GUILayout.Label("Shot Talker:", GUILayout.Width(200));
                curShot.shotTalker = EditorGUILayout.TextField(curShot.shotTalker);
            }
            using (new EditorGUILayout.HorizontalScope())
            {
                GUILayout.Label("Shot Dialog:", GUILayout.Width(200));
                curShot.shotDialog = EditorGUILayout.TextField(curShot.shotDialog);
            }
            using (new EditorGUILayout.HorizontalScope())
            {
                GUILayout.Label("Shot Camera:", GUILayout.Width(200));
                curShot.shotCamera = EditorGUILayout.TextField(curShot.shotCamera);
            }

            EditorGUILayout.LabelField("Shot Script:");
            GUILayout.TextArea(curShot.GenerateScript());

            GUILayout.Space(50);

            if (curEffect == null) {
                return;
            }
            EffectEditor(curEffect);
        }
    }

    void EffectEditor (ShotEffect effect)
    {
        using (new EditorGUILayout.HorizontalScope())
        {
            GUILayout.Label("Effect Name:", GUILayout.Width(200));
            effect.effectName = EditorGUILayout.TextField(effect.effectName);
        }
        using (new EditorGUILayout.HorizontalScope())
        {
            GUILayout.Label("Start Time:", GUILayout.Width(200));
            effect.startTime = EditorGUILayout.FloatField(effect.startTime);
        }
        effect.ShowEditor();

        EditorGUILayout.LabelField("Effect Script:");
        GUILayout.TextArea(effect.GenerateScript());
    }
}
