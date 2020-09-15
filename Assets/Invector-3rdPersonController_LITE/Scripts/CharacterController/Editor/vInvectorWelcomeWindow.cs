using System;
using UnityEditor;
using UnityEngine;

namespace Invector.vCharacterController
{
    [InitializeOnLoad]
    public class vInvectorWelcomeWindow : EditorWindow
    {
        #region ToolBar Drawers
        /// <summary>
        /// ToolBar Class
        /// </summary>
        public class ToolBar
        {
            public string title;
            public UnityEngine.Events.UnityAction Draw;
            /// <summary>
            /// Create New Toolbar
            /// </summary>
            /// <param name="title">Title</param>
            /// <param name="onDraw">Method to draw when toolbar is selected</param>
            public ToolBar(string title, UnityEngine.Events.UnityAction onDraw)
            {
                this.title = title;
                this.Draw = onDraw;
            }
            public static implicit operator string(ToolBar tool)
            {
                return tool.title;
            }
        }

        /// <summary>
        /// Index of selected <seealso cref="toolBars"/>
        /// </summary>
        public int toolBarIndex = 0;

        /// <summary>
        /// List of Toolbars
        /// </summary>
        public ToolBar[] toolBars = new ToolBar[]
        {
            new ToolBar("Welcome",FirstRunPageContent),
            new ToolBar("Getting Started",GettingStartedPageContent),
            #if INVECTOR_BASIC
            new ToolBar("Add-ons",AddonsPageContent),
            #endif
            new ToolBar("Forum",Forum)
        };
        #endregion

        public const string _thirdPersonVersion = "2.0";        

        public const string _basicPath = "https://assetstore.unity.com/packages/templates/systems/third-person-controller-basic-locomotion-template-59332";
        public const string _meleePath = "https://assetstore.unity.com/packages/templates/systems/third-person-controller-melee-combat-template-44227";
        public const string _shooterPath = "https://assetstore.unity.com/packages/templates/systems/third-person-controller-shooter-template-84583";        

        public static Texture2D invectorBanner = null;
        public static Texture2D mobileIcon = null;
        public static Texture2D topdownIcon = null;
        public static Texture2D pointAndClickIcon = null;
        public static Texture2D platformIcon = null;
        public static Texture2D vMansionIcon = null;
        public static Texture2D assetStoreIcon = null;
        public static Texture2D climbAddon = null;
        public static Texture2D swimmingAddon = null;
        public static Texture2D stealthKillAddon = null;
        public static Texture2D builderAddon = null;
        public static Texture2D ziplineAddon = null;

        public static Vector2 scrollPosition;

        GUISkin skin;
        private const int windowWidth = 600;
        private const int windowHeight = 500;      

        [MenuItem("Invector/Welcome Window", false, windowWidth)]

        public static void Open()
        {
            GetWindow<vInvectorWelcomeWindow>(true);
        }

        public void OnEnable()
        {
            titleContent = new GUIContent("Welcome To Invector");
            maxSize = new Vector2(windowWidth, windowHeight);
            minSize = maxSize;
            InitStyle();
        }

        void InitStyle()
        {
            if (!skin) skin = Resources.Load("welcomeWindowSkin") as GUISkin;
            
            invectorBanner = (Texture2D)Resources.Load("invectorBanner", typeof(Texture2D));
            mobileIcon = (Texture2D)Resources.Load("mobileIcon", typeof(Texture2D));
            topdownIcon = (Texture2D)Resources.Load("topdownIcon", typeof(Texture2D));
            pointAndClickIcon = (Texture2D)Resources.Load("clickToMoveIcon", typeof(Texture2D));
            platformIcon = (Texture2D)Resources.Load("platformIcon", typeof(Texture2D));
            vMansionIcon = (Texture2D)Resources.Load("vMansionIcon", typeof(Texture2D));
            assetStoreIcon = (Texture2D)Resources.Load("Unity-Asset-Store", typeof(Texture2D));
            climbAddon = (Texture2D)Resources.Load("climbAddon", typeof(Texture2D));
            swimmingAddon = (Texture2D)Resources.Load("swimmingAddon", typeof(Texture2D));
            stealthKillAddon = (Texture2D)Resources.Load("stealthKillAddon", typeof(Texture2D));
            builderAddon = (Texture2D)Resources.Load("builderAddon", typeof(Texture2D));
            ziplineAddon = (Texture2D)Resources.Load("ziplineAddon", typeof(Texture2D));
        }

        public void OnGUI()
        {
            GUI.skin = skin;
            
            DrawHeader();
            DrawMenuButtons();
            DrawPageContent();
            DrawBottom();
        }

        private void DrawHeader()
        {
            GUILayout.Label(invectorBanner, GUILayout.Height(110));
        }

        private void DrawMenuButtons()
        {
            GUILayout.Space(-10);
            toolBarIndex = GUILayout.Toolbar(toolBarIndex, ToolbarNames());
        }

        private string[] ToolbarNames()
        {
            string[] names = new string[toolBars.Length];
            for (int i = 0; i < toolBars.Length; i++)
            {
                names[i] = toolBars[i];
            }
            return names;
        }

        private void DrawPageContent()
        {
            GUILayout.BeginArea(new Rect(4, 140, 592, 340));
            toolBars[toolBarIndex].Draw();            
            GUILayout.EndArea();            
            GUILayout.FlexibleSpace();            
        }

        private void DrawBottom()
        {
            GUILayout.BeginHorizontal("box");

            vEditorStartupPrefs.DisplayWelcomeScreen = GUILayout.Toggle(vEditorStartupPrefs.DisplayWelcomeScreen, "Display this window at startup");

            GUILayout.EndHorizontal();
        }
        
        #region Static ToolBars

        public static void FirstRunPageContent()
        {
            GUILayout.BeginVertical("window");           

            GUILayout.Label(" ", GUI.skin.GetStyle("TemplatesPromo"), GUILayout.Width(586));

            EditorGUIUtility.AddCursorRect(new Rect(0, 0, 600, 320), MouseCursor.Link);
            
            GUILayout.BeginVertical();
            GUILayout.Space(-320);
            GUILayout.BeginHorizontal();
            GUILayout.Space(5);

            if (GUILayout.Button("LOCOMOTION", GUI.skin.GetStyle("CustomButton"), GUILayout.Width(188)))
            {                
                Application.OpenURL(_basicPath);
            }
            if (GUILayout.Button("MELEE COMBAT", GUI.skin.GetStyle("CustomButton"), GUILayout.Width(190)))
            {
                Application.OpenURL(_meleePath);
            }
            if (GUILayout.Button("SHOOTER", GUI.skin.GetStyle("CustomButton"), GUILayout.Width(189)))
            {
                Application.OpenURL(_shooterPath);
            }
            GUILayout.EndHorizontal();
            GUILayout.EndVertical();
            GUILayout.EndVertical();
        }

        public static void AddonsPageContent()
        {
            GUILayout.BeginVertical("window");
            scrollPosition = GUILayout.BeginScrollView(
            scrollPosition, GUILayout.Width(580), GUILayout.Height(316));

            DrawNewAddon(mobileIcon, "Mobile Examples", "Simple mobile example, basic, melee and shooter scenes included", "Purchase Full Version", _basicPath, true);
            DrawNewAddon(topdownIcon, "Topdown Examples", "Topdown controller basic, melee and shooter scenes included", "Purchase Full Version", _basicPath, true);
            DrawNewAddon(pointAndClickIcon, "Point&Click Examples", "Similar to Diablo gameplay, basic and melee scenes included", "Purchase Full Version", _basicPath, true);
            DrawNewAddon(platformIcon, "2.5D Examples", "2.5D with corner transition, basic, melee and shooter scenes included", "Purchase Full Version", _basicPath, true);
            DrawNewAddon(vMansionIcon, "Mansion CameraMode Examples", "Cool example of how to use the CameraMode to create a CCTV or oldschool gameplay style", "Purchase Full Version", _basicPath, false);
            DrawNewAddon(climbAddon, "FreeClimb Add-on", "Climb on any surface such as walls or cliffs. \n\n *Full Locomotion Template Required", "Go to AssetStore", "https://assetstore.unity.com/packages/tools/utilities/third-person-freeclimb-add-on-105187", true);
            DrawNewAddon(swimmingAddon, "Swimming Add-on", "Swim on the surface or dive into the water. \n\n *Full Locomotion Template Required", "Go to AssetStore", "https://assetstore.unity.com/packages/tools/utilities/third-person-swimming-add-on-97418", true);
            DrawNewAddon(ziplineAddon, "Zipline Add-on", "Zipline through pre located ropes. \n\n *Full Locomotion Template Required", "Go to AssetStore", "https://assetstore.unity.com/packages/tools/utilities/third-person-zipline-add-on-97410", true);
            DrawNewAddon(stealthKillAddon, "Stealth Kill Add-on (Free!)", "Example using the GenericAction feature, animations included. \n\n *FSM AI & ThirdPerson Templates Required", "Go to AssetStore", "https://assetstore.unity.com/packages/templates/systems/invector-stealth-kill-add-on-135495", true);
            DrawNewAddon(builderAddon, "Builder Add-on", "Collect Items and Build them anywhere in your scene to create traps or interactables! \n\n *Shooter Template Required", "Go to AssetStore", "https://assetstore.unity.com/packages/tools/utilities/third-person-builder-add-on-152689", true);

            GUILayout.EndScrollView();
            GUILayout.FlexibleSpace();
            GUILayout.EndVertical();
        }

        private static void DrawNewAddon(Texture2D icon, string title, string description, string button, string path, bool useUrl)
        {
            GUILayout.BeginHorizontal("box");

            GUILayout.Label(icon, GUI.skin.GetStyle("Icon"), GUILayout.Height(90), GUILayout.Width(90));

            GUILayout.BeginVertical();
            GUILayout.Label(title, GUI.skin.GetStyle("Title"), GUILayout.Width(300));
            GUILayout.Label(description, GUILayout.Width(300));
            GUILayout.EndVertical();

            if (GUILayout.Button(button))
            {
                if(useUrl)
                    Application.OpenURL(path);
                else
                    AssetDatabase.ImportPackage(path, true);
            }

            GUILayout.EndHorizontal();
        }       

        public static void GettingStartedPageContent()
        {
            GUILayout.BeginVertical("window");            

            GUILayout.BeginHorizontal("box");
            GUILayout.Label("<b>1</b>- Make sure your Character FBX is using the AnimationType: 'Humanoid' in the Rig tab, so you can retarget the default animations from our Animator to your new Character.");
            GUILayout.EndHorizontal();
            GUILayout.Space(6);

            GUILayout.BeginHorizontal("box");
            GUILayout.Label("<b>2</b>- Never modify a default resource file (Animator, Prefabs, etc...) that comes with the template, instead" +
                " create a copy of the original file and place it inside your project folder.");
            GUILayout.EndHorizontal();
            GUILayout.Space(6);

            GUILayout.BeginHorizontal("box");
            GUILayout.Label("<b>3</b>- When modifying the Invector scripts, make sure to comment the original source and create a #region for ex: 'MyCustomModification' " +
                "so it's easier to find and implement again once you update the template to a newer version.");
            GUILayout.EndHorizontal();
            GUILayout.Space(6);

            EditorGUILayout.HelpBox("- ALWAYS BACKUP your project before updating!", MessageType.Warning, true);            
            EditorGUILayout.HelpBox("- To update your template you need to Delete the Invector folder, this way you won't get any conflicts between old files and newer files.", MessageType.Info, true);

            GUILayout.FlexibleSpace();
            GUILayout.EndVertical();
        }

        public static void Forum()
        {
            GUILayout.BeginVertical("window");

            GUILayout.BeginVertical("box");
            EditorGUILayout.HelpBox("The Official Invector Forum is getting bigger every day, join the vCommunity too!\n\n- Get help from users \n- Community Add-ons created by users\n- Get feedback to your Project \n- Showcase your Game \n- Check the latests Integrations", MessageType.Info);
            if (GUILayout.Button("Open Forum"))
            {
                Application.OpenURL("http://invector.proboards.com/");
            }
            GUILayout.EndVertical();
         

            GUILayout.FlexibleSpace();
            GUILayout.EndVertical();
        }

#endregion

    }
}