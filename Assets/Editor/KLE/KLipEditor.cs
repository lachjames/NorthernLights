using AuroraEngine;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem.Android;
using UnityEngine.Networking;

public class KLipEditor : EditorWindow
{
    int WIDTH = 4096;
    int HEIGHT = 256;

    int ARROW_SIZE = 30;

    LIP lipData;
    AudioClip audioClip;
    Texture2D audioTexture;

    Vector2 editorScroll;

    [MenuItem("KotOR/Lip Editor")]
    public static void ShowWindow()
    {
        GetWindow<KLipEditor>(false, "Lip Editor", true);
    }

    public void OnGUI()
    {
        using (new EditorGUILayout.VerticalScope())
        {
            Menu();
            Editor();
        }
    }

    void Menu()
    {
        using (new EditorGUILayout.VerticalScope())
        {
            if (GUILayout.Button("Load LIP File"))
            {
                LoadFile();
            }
            if (GUILayout.Button("Save LIP File"))
            {
                SaveFile();
            }
        }
    }

    void Editor()
    {
        if (lipData != null)
        {
            DrawEditor();
        }
    }

    void DrawEditor()
    {
        // Draw the GFF editor for the selected item
        using (new EditorGUILayout.VerticalScope())
        {
            using (var scroll = new EditorGUILayout.ScrollViewScope(editorScroll))
            {
                editorScroll = scroll.scrollPosition;
                DrawEditorInterior();
            }
        }
    }

    private void DrawEditorInterior()
    {
        using (new EditorGUILayout.VerticalScope())
        {
            if (audioTexture != null)
            {
                GUI.DrawTexture(new Rect(0, 0, WIDTH, HEIGHT), audioTexture, ScaleMode.StretchToFill);
            }
            if (lipData != null)
            {
                DrawLips();
            }
        }
    }

    private void DrawLips()
    {
        using (new EditorGUILayout.HorizontalScope())
        {
            float lastFraction = 0;
            // For each phoneme, draw it out
            foreach (Frame frame in lipData.frames)
            {
                float fraction = frame.time / lipData.length;
                int pos = (int)(WIDTH * fraction);

                int diff = (int)((fraction - lastFraction) * WIDTH) - ARROW_SIZE - (ARROW_SIZE / 2);

                if (diff >= 0)
                {
                    GUILayout.Space(diff);
                }

                GUILayout.Button(
                    LIP.LIPCodes[frame.shape],
                    GUILayout.Width(ARROW_SIZE),
                    GUILayout.Height(ARROW_SIZE)
                );

                lastFraction = fraction;
            }
        }
    }

    void LoadFile ()
    {
        string loadLoc = EditorUtility.OpenFilePanel("Load LIP file", "", "");
        using (FileStream stream = new FileStream(loadLoc, FileMode.Open))
        {
            lipData = new LIP();
            lipData.Load(stream, new Dictionary<string, Stream>(), 0, 0);
            Debug.Log(lipData.frames.Length);
        }

        string audioLoc = EditorUtility.OpenFilePanel("Load Audio File", "", "");
        using (FileStream stream = new FileStream(audioLoc, FileMode.Open))
        {
            // Using the KotOR-Unity VO loading code, might as well!
            WAVObject wav = new WAVObject(stream);

            audioClip = AudioClip.Create("clip", wav.data.Length / wav.channels, wav.channels, wav.sampleRate, false);
            audioClip.SetData(wav.data, 0);
            
            audioTexture = PaintWaveformSpectrum(audioClip, 1, WIDTH, HEIGHT, Color.yellow);
        }
    }

    void SaveFile ()
    {
        string saveLoc = EditorUtility.SaveFilePanel("Load LIP file", "", "", "");
    }

    // Source: https://answers.unity.com/questions/699595/how-to-generate-waveform-from-audioclip.html
    public Texture2D PaintWaveformSpectrum(AudioClip audio, float saturation, int width, int height, Color col)
    {
        Texture2D tex = new Texture2D(width, height, TextureFormat.RGBA32, false);
        float[] samples = new float[audio.samples];
        float[] waveform = new float[width];
        audio.GetData(samples, 0);
        int packSize = (audio.samples / width) + 1;
        int s = 0;
        for (int i = 0; i < audio.samples; i += packSize)
        {
            waveform[s] = Mathf.Abs(samples[i]);
            s++;
        }

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                tex.SetPixel(x, y, Color.black);
            }
        }

        for (int x = 0; x < waveform.Length; x++)
        {
            for (int y = 0; y <= waveform[x] * ((float)height * .75f); y++)
            {
                tex.SetPixel(x, (height / 2) + y, col);
                tex.SetPixel(x, (height / 2) - y, col);
            }
        }
        tex.Apply();

        return tex;
    }
}
