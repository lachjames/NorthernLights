using AuroraEngine;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

// Create a new type of Settings Asset.

public class AuroraPrefs : ScriptableObject
{
    public const string k_MyCustomSettingsPath = "Assets/Editor/AuroraPreferences.asset";

    [SerializeField]
    private int m_Number;

    [SerializeField]
    private string k1Location;
    [SerializeField]
    private string k1SaveLocation;
    
    [SerializeField]
    private string tslLocation;
    [SerializeField]
    private string tslSaveLocation;

    [SerializeField]
    private string moduleOutLocation;

    [SerializeField]
    private Game game;

    public static AuroraPrefs prefs;

    public static AuroraPrefs GetOrCreateSettings()
    {
        var settings = AssetDatabase.LoadAssetAtPath<AuroraPrefs>(k_MyCustomSettingsPath);
        if (settings == null)
        {
            Debug.LogWarning("Creating settings file");
            settings = ScriptableObject.CreateInstance<AuroraPrefs>();
            settings.k1Location = "D:\\SteamLibrary\\steamapps\\common\\swkotor";
            settings.tslLocation = "D:\\SteamLibrary\\steamapps\\common\\Knights of the Old Republic II";
            settings.game = Game.KotOR;
            AssetDatabase.CreateAsset(settings, k_MyCustomSettingsPath);
            AssetDatabase.SaveAssets();
        }

        prefs = settings;
        return settings;
    }

    internal static SerializedObject GetSerializedSettings()
    {
        return new SerializedObject(GetOrCreateSettings());
    }

    public static string GetKotorLocation ()
    {
        if (prefs == null)
        {
            prefs = GetOrCreateSettings();
        }
        if (prefs.game == Game.KotOR)
            return prefs.k1Location;

        return prefs.tslLocation;
    }

    public static string GetK1Location()
    {
        return prefs.k1Location;
    }

    public static string GetTSLLocation()
    {
        return prefs.tslLocation;
    }

    public static string GetK1SaveLocation()
    {
        return prefs.k1SaveLocation;
    }

    public static string GetTSLSaveLocation()
    {
        return prefs.tslSaveLocation;
    }

    public static string GetModuleOutLocation ()
    {
        string modOut = prefs.moduleOutLocation;
        if (!modOut.EndsWith("\\"))
        {
            modOut += "\\";
        }
        return modOut;
    }

    //public Game TargetGame ()
    //{
    //    return game;
    //}

    public static Game TargetGame ()
    {
        if (prefs == null)
        {
            prefs = GetOrCreateSettings();
        }
        return prefs.game;
    }
}

// Register a SettingsProvider using IMGUI for the drawing framework:
static class MyCustomSettingsIMGUIRegister
{
    [SettingsProvider]
    public static SettingsProvider CreateMyCustomSettingsProvider()
    {
        // First parameter is the path in the Settings window.
        // Second parameter is the scope of this setting: it only appears in the Project Settings window.
        var provider = new SettingsProvider("Project/Aurora Preferences", SettingsScope.Project)
        {
            //// By default the last token of the path is used as display name if no label is provided.
            //label = "Aurora Preferences",
            // Create the SettingsProvider and initialize its drawing (IMGUI) function in place:
            guiHandler = (searchContext) =>
            {
                SerializedObject settings = AuroraPrefs.GetSerializedSettings();
                EditorGUILayout.PropertyField(settings.FindProperty("game"), new GUIContent("Target Game"));

                EditorGUILayout.Space();

                EditorGUILayout.PropertyField(settings.FindProperty("k1Location"), new GUIContent("KotOR Location"));
                EditorGUILayout.PropertyField(settings.FindProperty("tslLocation"), new GUIContent("TSL Location"));
                
                EditorGUILayout.Space();
                
                EditorGUILayout.PropertyField(settings.FindProperty("k1SaveLocation"), new GUIContent("KotOR Save Location"));
                EditorGUILayout.PropertyField(settings.FindProperty("tslSaveLocation"), new GUIContent("TSL Save Location"));

                EditorGUILayout.Space();

                EditorGUILayout.LabelField("NOTE: The 'Module Out Location' directory is used for temp storage, and its contents WILL OFTEN be fully and non-reversibly deleted!");
                EditorGUILayout.PropertyField(settings.FindProperty("moduleOutLocation"), new GUIContent("Module Out Location"));
                settings.ApplyModifiedProperties();
            },

            //// Populate the search keywords to enable smart search filtering and label highlighting:
            //keywords = new HashSet<string>(new[] { "Number", "Some String" })
        };

        return provider;
    }
}
