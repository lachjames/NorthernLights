using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEngine;

public class CinemaThemesWindow : EditorWindow
{
    #region UI Fields
    private int selectedCameraIndex = 0;
    private int selectedLutIndex = 0;
    private Texture2D texture;
    #endregion

    private List<string> cameraList = new List<string>();
    private List<Texture2D> luts;
    private string[] lutGuids;
    private const string ASSET_FILTER = "3D16 t:texture2D";

#if UNITY_5 || UNITY_2017_1_OR_NEWER
    private Type colorCorrectionScriptType = null;
#endif
    private int controlId = -1;
    private const float TOOLBAR_HEIGHT = 17;
    private bool colorCorrectionScriptFound = false;
    private bool lutsFound = false;
    private Texture2D picker;

#region Language
    private const string TITLE = "Themes";
    private const string MENU_ITEM = "Window/Cinema Suite/Cinema Themes/Cinema Themes %#t";
    private const string MISSING_COMPONENT_ERROR_MSG = "Color Correction Component not found! \nPlease download Unity's free \"Legacy Image Effects\" package from the Asset Store.";
    private const string MISSING_LUTS_ERROR_MSG = "No LUTs were found in the project! \nPlease re-import the Cinema Themes package.";
    private const string MISSING_CAMERA_ERROR_MSG = "Invalid camera selection!\nEnsure a camera exists in the scene, and pick an existing camera from the camera list.";
    private const string DEPRICATED_IMAGE_EFFECTS_MSG = "Unity's free Legacy Image Effects has been depricated, and is no longer available. Please click the button below to view the available post-processing options supported by Unity.";
#endregion

    /// <summary>
    /// Called when the Themes window is opened.
    /// </summary>
    public void Awake()
    {
#if UNITY_5 && !UNITY_5_0 || UNITY_2017_1_OR_NEWER
        base.titleContent = new GUIContent(TITLE);
#else
        base.title = TITLE;
#endif
        this.minSize = new Vector2(300, 200f);
    }

    /// <summary>
    /// Called when the Themes window is enabled.
    /// </summary>
    public void OnEnable()
    {
        LoadLUTs();


#if UNITY_5 || UNITY_2017_1_OR_NEWER
        
        foreach (Assembly a in AppDomain.CurrentDomain.GetAssemblies())
        {
            Type type = a.GetType("UnityStandardAssets.ImageEffects.ColorCorrectionLookup");
            if(type != null)
            {
                colorCorrectionScriptType = type;
                colorCorrectionScriptFound = true;
            }
        }
#elif !UNITY_5
        // Attempt to find the Color Correction script. (This is a wacky workaround since it's a .js file)
        string[] strings = Unsupported.GetSubmenus("Component");
        foreach (string s in strings)
        {
            if(s.Contains("Color Correction (3D Lookup Texture)"))
            {
                colorCorrectionScriptFound = true;
            }
        }       
#endif

        picker = EditorGUIUtility.Load("Cinema Suite/Cinema Themes/Director_PickerIcon.png") as Texture2D;
    }


    protected void OnGUI()
    {
        Rect toolbar = new Rect(0, 0, base.position.width, TOOLBAR_HEIGHT);
        EditorGUILayout.BeginHorizontal(EditorStyles.toolbar, GUILayout.Width(toolbar.width));

        GUILayout.FlexibleSpace();

        // Check if the Welcome Window exists and if so, show an icon for it.
        var helpWindowType = Type.GetType("CinemaSuite.CinemaSuiteWelcome");
        if (helpWindowType != null)
        {
            if (GUILayout.Button(new GUIContent("?", "Help"), EditorStyles.toolbarButton))
            {
                EditorWindow.GetWindow(helpWindowType);
            }
        }

        EditorGUILayout.EndHorizontal();
        EditorGUILayout.Space();

        // check for changes in assets, reload if neccessary
        if (!Enumerable.SequenceEqual(AssetDatabase.FindAssets(ASSET_FILTER), lutGuids))
        {
            LoadLUTs();
        }

        // Check if script and luts exist in the project.
        if (!colorCorrectionScriptFound)
        {
            //EditorGUILayout.HelpBox(MISSING_COMPONENT_ERROR_MSG, MessageType.Error);
#if UNITY_5_5_OR_NEWER
            //if (GUILayout.Button("Download from Asset Store"))
            //{
            //    Application.OpenURL("https://assetstore.unity.com/packages/essentials/legacy-image-effects-83913");
            //}

            EditorGUILayout.HelpBox(DEPRICATED_IMAGE_EFFECTS_MSG, MessageType.Warning);
            if (GUILayout.Button(new GUIContent("View Unity Post-Processing Options")))
            {
                Application.OpenURL("https://docs.unity3d.com/Manual/PostProcessingOverview.html");
            }
#endif
            return;
        }
        if(!lutsFound)
        {
            EditorGUILayout.HelpBox(MISSING_LUTS_ERROR_MSG, MessageType.Error);
            return;
        }

        cameraList.Clear();

        // get all cameras in scene
        List<string> duplicateNames = new List<string>();
        foreach(Camera camera in Camera.allCameras)
        {
            if (cameraList.Contains(camera.name) && !duplicateNames.Contains(camera.name))
            {
                duplicateNames.Add(camera.name);
            }
            else
            {
                cameraList.Add(camera.name);
            }
        }

        selectedCameraIndex = EditorGUILayout.Popup("Camera", selectedCameraIndex, cameraList.ToArray());

        // If the last camera is selected and then deleted, select the new last index.
        if (selectedCameraIndex >= Camera.allCamerasCount)
        {
            selectedCameraIndex = Camera.allCamerasCount > 0 ? Camera.allCamerasCount - 1 : 0;
        }
        
        EditorGUILayout.BeginHorizontal();        

        var stringList = luts.ConvertAll(obj => camelCaseFix( obj.name.Substring(0, obj.name.Length - 4)));

        int tempIndex = EditorGUILayout.Popup("LUT", selectedLutIndex, stringList.ToArray());
        if(tempIndex != selectedLutIndex)
        {
            selectedLutIndex = tempIndex;
            texture = luts[selectedLutIndex];
        }

        GUIStyle style = new GUIStyle(EditorStyles.whiteLabel);
        style.normal.background = picker;
        controlId = GUIUtility.GetControlID(FocusType.Passive);
        if (GUILayout.Button(string.Empty, style, GUILayout.Width(16)))
        {
            EditorGUIUtility.ShowObjectPicker<Texture2D>(texture, false, "3D16", controlId);
        }

        if (Event.current.type == EventType.ExecuteCommand && Event.current.commandName == "ObjectSelectorClosed")
        {
            if (EditorGUIUtility.GetObjectPickerControlID() == controlId)
            {
                UnityEngine.Object pickedObject = EditorGUIUtility.GetObjectPickerObject();
                if(pickedObject is Texture2D)
                {
                    for(int i = 0; i < luts.Count; i++)
                    {
                        if(luts[i] == pickedObject as Texture2D)
                        {
                            selectedLutIndex = i;
                            break;
                        }
                    }

                    texture = pickedObject as Texture2D;
                }
                Event.current.Use();
            }
        }

        EditorGUILayout.EndHorizontal();


        bool validSelections = true;
        bool cameraExists = Camera.allCamerasCount > 0;
        if (selectedCameraIndex < 0 || selectedCameraIndex >= Camera.allCamerasCount)
        {
            EditorGUILayout.HelpBox(MISSING_CAMERA_ERROR_MSG, MessageType.Error);
            validSelections = false;
        }
        if (texture != null && !ValidDimensions(texture))
        {
            EditorGUILayout.HelpBox("Invalid texture dimensions!\nPick another texture or adjust dimension to e.g. 256x16.", MessageType.Error);
            validSelections = false;
        }
        // display list of duplicate camera names, if any
        if (duplicateNames.Count > 0)
        {
            string warningMsg = "Duplicate camera names!\nCan only apply themes to cameras with unique names.\nDupicate name(s):";
            foreach (string name in duplicateNames)
            {
                warningMsg += "\n" + name;
            }
            EditorGUILayout.HelpBox(warningMsg, MessageType.Warning);

            if (!cameraExists || duplicateNames.Contains(Camera.allCameras[selectedCameraIndex].name))
            {
                validSelections = false;
            }
        }

        EditorGUILayout.BeginHorizontal();
        EditorGUI.BeginDisabledGroup(!(validSelections && texture != null));

        bool isComponentAttached = cameraExists ? isColorCorrectionAttached(Camera.allCameras[selectedCameraIndex]) : false;
        EditorGUI.BeginDisabledGroup(isComponentAttached);
        if (GUILayout.Button("<"))
        {
            selectedLutIndex--;
            if (selectedLutIndex < 0)
            {
                selectedLutIndex = selectedLutIndex + luts.Count;
            }
            texture = luts[selectedLutIndex];
            AddThemeToCamera(texture, Camera.allCameras[selectedCameraIndex]);
        }
        EditorGUI.EndDisabledGroup();

        EditorGUI.BeginDisabledGroup(!cameraExists || AssetDatabase.GetAssetPath(texture) == getTempTexturePath(Camera.allCameras[selectedCameraIndex]));
        if (GUILayout.Button("Apply"))
        {
            AddThemeToCamera(texture, Camera.allCameras[selectedCameraIndex]);
        }
        EditorGUI.EndDisabledGroup();

        EditorGUI.BeginDisabledGroup(isComponentAttached);
        if (GUILayout.Button(">"))
        {
            selectedLutIndex++;
            selectedLutIndex = selectedLutIndex % luts.Count;
            texture = luts[selectedLutIndex];
            AddThemeToCamera(texture, Camera.allCameras[selectedCameraIndex]);
        }
        EditorGUI.EndDisabledGroup();
        EditorGUI.EndDisabledGroup();

        EditorGUILayout.EndHorizontal();
    }

    public bool ValidDimensions(Texture2D tex)
    {
        if (!tex) return false;
        int h = tex.height;
        if (h != Mathf.FloorToInt(Mathf.Sqrt(tex.width)))
        {
            return false;
        }
        return true;
    }

    protected void LoadLUTs()
    {
        luts = new List<Texture2D>();
        lutGuids = AssetDatabase.FindAssets(ASSET_FILTER);
        foreach (string guid in lutGuids)
        {
            Texture2D t2d = AssetDatabase.LoadAssetAtPath(AssetDatabase.GUIDToAssetPath(guid), typeof(Texture2D)) as Texture2D;
            luts.Add(t2d);
        }

        if (luts.Count > 0)
        {
            texture = luts[0];
            lutsFound = true;
        }
        else
        {
            lutsFound = false;
        }
    }

    protected void AddThemeToCamera(Texture2D theme, Camera camera)
    {
        string themePath = AssetDatabase.GetAssetPath(theme);

        // Add Color Correction (3D Texture Lookup) script component
        // do nothing if it already exists

#if UNITY_5 || UNITY_2017_1_OR_NEWER
        if (camera.gameObject.GetComponent(colorCorrectionScriptType) == null)
        {
            camera.gameObject.AddComponent(colorCorrectionScriptType);
        }
        var ccl = camera.gameObject.GetComponent(colorCorrectionScriptType);
#else
        if (camera.gameObject.GetComponent("ColorCorrectionLut") == null)
        {
            camera.gameObject.AddComponent("ColorCorrectionLut");
        }
        var ccl = camera.gameObject.GetComponent("ColorCorrectionLut");
#endif

        // Check to see if the texture's import settings are correct (same code as in ColorCorrectionLutEditor.js)
        TextureImporter textureImporter = (TextureImporter)AssetImporter.GetAtPath(themePath);
        bool doImport = false;
        if (textureImporter.isReadable == false) {
            doImport = true;
        }
        if (textureImporter.mipmapEnabled == true) {
            doImport = true;
        }
#if UNITY_5_5_OR_NEWER
        if (textureImporter.textureCompression != TextureImporterCompression.Uncompressed) {
            doImport = true;
        }
#else
        if (textureImporter.textureFormat != TextureImporterFormat.AutomaticTruecolor) {
            doImport = true;
        }
#endif
        if (doImport)
        {
            textureImporter.isReadable = true;
            textureImporter.mipmapEnabled = false;
#if UNITY_5_5_OR_NEWER
            textureImporter.textureCompression = TextureImporterCompression.Uncompressed;
#else
            textureImporter.textureFormat = TextureImporterFormat.AutomaticTruecolor;
#endif
            AssetDatabase.ImportAsset(themePath, ImportAssetOptions.ForceUpdate);
            //tex = AssetDatabase.LoadMainAssetAtPath(path);
        }

        // Add LUT texture to the previous component
        // make sure component exists        
        if (ccl != null)
        {
            // We use reflection, so that this script doesn't throw errors when
            // Image Effects aren't present.
            MethodInfo method = ccl.GetType().GetMethod("Convert");
            method.Invoke(ccl, new object[] { theme, themePath });
        }
    }

    private bool isColorCorrectionAttached(Camera camera)
    {
#if UNITY_5 || UNITY_2017_1_OR_NEWER
        return (camera.gameObject.GetComponent(colorCorrectionScriptType) == null);
#else
        return (camera.gameObject.GetComponent("ColorCorrectionLut") == null);
#endif
    }

    private string getTempTexturePath(Camera camera)
    {
        string tempPath = string.Empty;

#if UNITY_5 || UNITY_2017_1_OR_NEWER
        var ccl = camera.gameObject.GetComponent(colorCorrectionScriptType);
#else
        var ccl = camera.gameObject.GetComponent("ColorCorrectionLut");
#endif

        if (ccl != null)
        {
            FieldInfo field = ccl.GetType().GetField("basedOnTempTex");
            tempPath = field.GetValue(ccl) as string;
        }
        return tempPath;
    }

    /// <summary>
    /// Convert a camelCase string to user friendly version.
    /// </summary>
    /// <param name="input">Camel Case text</param>
    /// <returns>regular text</returns>
    private string camelCaseFix(string input)
    {
        return System.Text.RegularExpressions.Regex.Replace(input, "(?<=.)([A-Z])", " $0",
            System.Text.RegularExpressions.RegexOptions.Compiled);
    }

    /// <summary>
    /// Show the Cinema Themes Window
    /// </summary>
    [MenuItem(MENU_ITEM, false, 40)]
    private static void ShowWindow()
    {
        EditorWindow.GetWindow<CinemaThemesWindow>();

        // Check if we should show the welcome window
        bool showWelcome = true;
        if (EditorPrefs.HasKey("CinemaSuite.WelcomeWindow.ShowOnStartup"))
        {
            showWelcome = EditorPrefs.GetBool("CinemaSuite.WelcomeWindow.ShowOnStartup");
        }

        if (showWelcome)
        {
            // Check if the Welcome Window exists and if so, show it.
            var helpWindowType = Type.GetType("CinemaSuite.CinemaSuiteWelcome");
            if (helpWindowType != null)
            {
                EditorWindow.GetWindow(helpWindowType);
            }
        }
    }
}