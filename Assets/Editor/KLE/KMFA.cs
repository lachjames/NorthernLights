using AuroraEngine;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem.Android;
using UnityEngine.Networking;

public class KMFA : EditorWindow
{
    string audioLoc;
    string text;
    string data;

    AudioClip clip;

    Dictionary<string, byte> phoneme_map = new Dictionary<string, byte>()
    {
        { "AA", 4 }, // "OH"
        { "AE", 3 }, // "AH"
        { "AH", 3 }, // "AH"
        { "AO", 4 }, // "OH"
        { "AW", 4 }, // "OH"
        { "AY", 3 }, // "AH"
        { "B", 11 }, // "M/P/B"
        { "CH", 13 }, // "J/SH"
        { "D", 12 }, // "T/D"
        { "DH", 12 }, // "T/D"
        { "EH", 1 }, // "EH"
        { "ER", 0 }, // "EE"
        { "EY", 3 }, // "AH"
        { "F", 10 }, // "TH"
        { "G", 12 }, // "T/D"
        { "HH", 0 }, // "EE"
        { "IH", 0 }, // "EE"
        { "IY", 0 }, // "EE"
        { "JH", 13 }, // "J/SH"
        { "K", 15 }, // "K/G"
        { "L", 14 }, // "L"
        { "M", 11 }, // "M/P/B"
        { "N", 9 }, // "N/NG"
        { "NG", 9 }, // "N/NG"
        { "OW", 4 }, // "OH"
        { "OY", 4 }, // "OH"
        { "OOV", 5 }, // OOH (+ added from experimentation)
        { "P", 11 }, // "M/P/B"
        { "R", 14 }, // "L"
        { "S", 7 }, // "S/TS"
        { "SH", 13 }, // "J/SH"
        { "T", 12 }, // "T/D"
        { "TH", 8 }, // "F/V"
        { "UH", 0 }, // "EE"
        { "UW", 5 }, // "OOH"
        { "V", 8 }, // "F/V"
        { "W", 11 }, // "M/P/B"
        { "Y", 6 }, // "Y"
        { "Z", 7 }, // "S/TS"
        { "ZH", 7 }, // "S/TS"
    };

    [MenuItem("KotOR/Generate Lip Sync")]
    public static void ShowWindow()
    {
        GetWindow<KMFA>(false, "Generate Lip Sync", true);
    }

    public void OnGUI()
    {
        using (new EditorGUILayout.VerticalScope())
        {
            Menu();
        }
    }

    void Menu()
    {
        using (new EditorGUILayout.VerticalScope())
        {
            if (GUILayout.Button("Load Audio Clip"))
            {
                LoadFile();
            }
            text = GUILayout.TextField(text);
            if (GUILayout.Button("Generate LIP File"))
            {
                SaveFile();
            }
        }
    }

    void LoadFile ()
    {
        audioLoc = EditorUtility.OpenFilePanel("Load Audio File", "", "");
        WWW www = new WWW("file:///" + audioLoc);
        clip = www.GetAudioClip(false, true);
    }
    
    async Task ForcedAlignment ()
    {
        // Connects to a REST API, assumed to be on http://127.0.0.1:8765
        using (var httpClient = new HttpClient())
        {
            using (var request = new HttpRequestMessage(new HttpMethod("POST"), "http://localhost:8765/transcriptions?async=false"))
            {
                var multipartContent = new MultipartFormDataContent();
                multipartContent.Add(new ByteArrayContent(File.ReadAllBytes(audioLoc)), "audio", Path.GetFileName(audioLoc));
                multipartContent.Add(new StringContent(text), "transcript");
                request.Content = multipartContent;

                var response = await httpClient.SendAsync(request);
                data = await response.Content.ReadAsStringAsync();

                ConvertToLIP(data);
            }
        }
    }

    LIP ConvertToLIP(string data)
    {
        List<Frame> frames = new List<Frame>(); ;
        dynamic json = JObject.Parse(data);

        float line_duration = 0;

        foreach (dynamic word in json.words)
        {
            line_duration = Math.Max(line_duration, float.Parse(word.end.ToString()));
            float wordStart = float.Parse(word.start.ToString());
            float accumulated = 0f;
            foreach (dynamic phoneme in word.phones)
            {
                // Get the duration and phoneme type
                float duration = float.Parse(phoneme.duration.ToString());
                string phone = phoneme.phone.ToString().Split('_')[0].ToUpper();

                // Calculate the start time of the phoneme in the audio file
                float phonemeStart = wordStart + accumulated;

                // Add the duration of the phoneme to the accumulated time
                accumulated += duration;

                // Check if we know this phoneme (we should know them all...)
                if (!phoneme_map.ContainsKey(phone))
                {
                    Debug.Log("Did not find phoneme " + phone);
                    continue;
                }

                // Create a frame
                Frame frame = new Frame() { time = phonemeStart, shape = phoneme_map[phone] };
                frames.Add(frame);
            }
        }

        frames.Add(new Frame() { time = clip.length, shape = 0 });

        LIP lip = new LIP();
        lip.fileType = 542132556; // "LIP " converted to Int32 
        lip.fileVersion = 808333654; // "V1.0" converted to Int32
        lip.entryCount = frames.Count;
        lip.length = clip.length;

        lip.frames = frames.ToArray();

        Debug.Log("Created " + lip.frames.Length + " frames for line of length " + lip.length);

        return lip;
    }

    async void SaveFile ()
    {
        await ForcedAlignment();
        LIP lip = ConvertToLIP(data);

        string saveLoc = EditorUtility.SaveFilePanel("Save LIP File", "", "", "");
        using (Stream stream = new FileStream(saveLoc, FileMode.CreateNew))
        {
            lip.WriteToStream(stream);
        }
    }
}
