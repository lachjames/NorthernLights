using UnityEngine;
using System.Collections;
using UnityEditor;
using UnityEditor.AnimatedValues;
using System.Collections.Generic;
using System;
using System.Reflection;
using System.Xml.Linq;
using System.Linq;
using System.IO;

namespace CinemaSuite
{
    public class CinemaSuiteWelcome : EditorWindow
    {
        private const string TITLE = "Cinema Suite";
        private const string MENU_ITEM = "Window/Cinema Suite/About";

        private GUISkin skin = null;
        private bool showOnStartup = true;

		List<string> availableProductNames = new List<string>{
            "CinemaFaceCap",
            "CinemaDirector",
			"CinemaMocap",
			"CinemaProCams",
			"CinemaThemes",
        };

		List<ProductInfo> availableProducts = new List<ProductInfo>();
		List<ProductInfo> installedProducts = new List<ProductInfo>();

        private AnimBool showInstalledProducts;
        private AnimBool showAvailableProducts;
        private AnimBool showCinemaSuiteAbout;

        private Texture2D cinemaSuiteLogo;
        private Texture2D directorKeyImage;
        private Texture2D mocapKeyImage;
        private Texture2D proCamsKeyImage;
        private Texture2D themesKeyImage;

        private Texture2D cmfLogo;

        private Texture2D websiteIcon;
        private Texture2D youtubeIcon;
        private Texture2D twitterIcon;
        private Texture2D facebookIcon;
        private Texture2D forumIcon;


        private Vector2 scrollPosition = new Vector2();



        bool legalStuff = true;
        Vector2 legalScrollPosition = new Vector2();
        private bool ShowAboutFirst = false;

        #region Language
        const string VISIT_WEBSITE = "Visit our website:";
        const string WEBSITE = "www.cinema-suite.com";

        const string SUPPORT = "Support:";
        const string SUPPORT_WEBSITE = "www.cinema-suite.com/forum";

        const string EMAIL_SUPPORT = "Email Support:";
        const string EMAIL = "support@cinema-suite.com";

        const string LIKE_US = "Like us on Facebook:";
        const string CINEMA_SUITE_INC = "/CinemaSuiteInc";

        const string FOLLOW_US = "Follow us on Twitter:";

        const string WATCH_US = "Watch us on YouTube:";

        const string DISCLAIMER1 = "Cinema Suite has been developed by Cinema Suite Inc. Any attempt to decompile and/or reverse engineer Cinema Suite source code is strictly prohibited under copyright laws applicable in the country of use. \n\n";
        const string DISCLAIMER2 = "While Cinema Suite Inc. make every effort to deliver high quality products, we do not guarantee that our products are free from defects. Our software is provided 'as is' and you use the software at your own risk. \n\n";
        const string DISCLAIMER3 = "We make no warranties as to performance, merchantability, fitness for a particular purpose, or any other warranties whether expressed or implied. \n\n";
        const string DISCLAIMER4 = "No oral or written communication from or information provided by Cinema Suite Inc. shall create a warranty. \n\n";
        const string DISCLAIMER5 = "Under no circumstances shall Cinema Suite Inc. be liable for direct, indirect, special, incidental, or consequential damages resulting from the use, misuse, or inability to use this software, even if Cinema Suite Inc. has been advised of the possibility of such damages. \n\n";
        const string DISCLAIMER6 = "Microsoft® and the Microsoft Kinect® are registered trademarks of Microsoft Corporation. Cooke® is a registered trademark of Cooke Optics Limited. Cinema Mo Cap, Cinema Director, and Cinema Suite Copyright© 2013. All rights reserved.";

        const string CMF_THANKS = "Cinema Suite Inc. extends a special thank you to the Canada Media Fund (CMF) for assistance in making Cinema Suite possible.";

        #endregion

        public void Awake()
        {
            base.titleContent = new GUIContent(TITLE);
            
            this.minSize = new Vector2(600, 700);

            if (EditorPrefs.HasKey("CinemaSuite.WelcomeWindow.ShowOnStartup"))
            {
                showOnStartup = EditorPrefs.GetBool("CinemaSuite.WelcomeWindow.ShowOnStartup");
            }
            loadProductInfo();
        }

        public void OnEnable()
        {
            if (EditorGUIUtility.isProSkin)
            {
                skin = Resources.Load("CinemaSuite_WelcomeSkin") as GUISkin;
            }
            else
            {
                skin = Resources.Load("CinemaSuite_WelcomeSkin_Light") as GUISkin;
            }

            showInstalledProducts = new AnimBool(true, Repaint);
            showAvailableProducts = new AnimBool(true, Repaint);
            showCinemaSuiteAbout = new AnimBool(true, Repaint);

            string suffix = EditorGUIUtility.isProSkin ? "_Pro" : "_Personal";
            cinemaSuiteLogo = Resources.Load<Texture2D>("Cinema_Suite_Logo" + suffix);
            cmfLogo = Resources.Load<Texture2D>("CMFLogo");

            websiteIcon = Resources.Load<Texture2D>("Cinema_Suite_Web" + suffix);
            youtubeIcon = Resources.Load<Texture2D>("Cinema_Suite_Youtube" + suffix);
            twitterIcon = Resources.Load<Texture2D>("Cinema_Suite_Twitter" + suffix);
            facebookIcon = Resources.Load<Texture2D>("Cinema_Suite_Facebook" + suffix);
            forumIcon = Resources.Load<Texture2D>("Cinema_Suite_Forums" + suffix);

//            loadProductInfo();
        }

        protected void OnGUI()
        {
            GUI.skin.label.richText = true;
            
#if UNITY_5 || UNITY_2017_1_OR_NEWER
            using (var verticalScope = new EditorGUILayout.VerticalScope())
            {
                using (var scrollView = new EditorGUILayout.ScrollViewScope(scrollPosition, GUILayout.Width(base.position.width), GUILayout.Height(base.position.height - 16)))
                {
                    scrollPosition = scrollView.scrollPosition;
#else
            {
                scrollPosition = EditorGUILayout.BeginScrollView(scrollPosition, false, true);
                {
#endif
                    GUILayout.Space(8f);

                    if (ShowAboutFirst)
                    {
                        this.DrawAboutCinemaSuiteSection();
                    }

                    Rect productsRect = EditorGUILayout.GetControlRect(GUILayout.Width(base.position.width - 22));
                    GUI.Box(new Rect(productsRect.x-4, productsRect.y, productsRect.width+8, productsRect.height), string.Empty, EditorStyles.toolbar);
                    showInstalledProducts.target = EditorGUI.Foldout(productsRect, showInstalledProducts.target, "Installed Products");

                    if (showInstalledProducts.target)
                    {
                        if (installedProducts.Count > 0)
                        {
                            foreach (ProductInfo product in installedProducts)
                            {
                                drawProduct(product);
                            }
                        }

                        
                    }

                    Rect availProductsRect = EditorGUILayout.GetControlRect(GUILayout.Width(base.position.width - 22));
                    GUI.Box(new Rect(availProductsRect.x - 4, availProductsRect.y, availProductsRect.width + 8, availProductsRect.height), string.Empty, EditorStyles.toolbar);
                    showAvailableProducts.target = EditorGUI.Foldout(availProductsRect, showAvailableProducts.target, "Available Products");

                    if (showAvailableProducts.target)
                    {
                        // Draw the available products
                        if (availableProducts.Count > 0)
                        {
                            foreach (ProductInfo product in availableProducts)
                            {
                                drawProduct(product);
                            }

                            GUILayout.Space(4f);
                        }
                    }

                    if (!ShowAboutFirst)
                    {
                        this.DrawAboutCinemaSuiteSection();
                    }
                }
#if !UNITY_5 && !UNITY_2017_1_OR_NEWER
                EditorGUILayout.EndScrollView();
#endif
            }


            EditorGUILayout.BeginHorizontal();
            GUILayout.FlexibleSpace();
            bool tempShowOnStartup = EditorGUILayout.Toggle(new GUIContent("Show on Startup"), showOnStartup);
            if(tempShowOnStartup != showOnStartup)
            {
                showOnStartup = tempShowOnStartup;
                EditorPrefs.SetBool("CinemaSuite.WelcomeWindow.ShowOnStartup", showOnStartup);
            }
            EditorGUILayout.EndHorizontal();
        }

        private void drawProduct(ProductInfo product)
        {
            EditorGUILayout.BeginVertical(skin.FindStyle("Header"));
            Rect foldoutRect = EditorGUILayout.GetControlRect();
            product.ShowProductInfo.target = EditorGUI.Foldout(foldoutRect, product.ShowProductInfo.target, product.name, true);
            EditorGUILayout.EndVertical();

#if UNITY_5 || UNITY_2017_1_OR_NEWER
            using (var productGroup = new EditorGUILayout.FadeGroupScope(product.ShowProductInfo.faded))
            {
                if (productGroup.visible)
                {
#else
            {
                if (product.ShowProductInfo.target)
                {
#endif
            
                    Rect contentRect = EditorGUILayout.BeginVertical(skin.FindStyle("Content"));
                    product.OnGUI(contentRect);
                    EditorGUILayout.EndVertical();
                }
            }
        }

        private void loadProductInfo()
        {
			for (int i = 0; i < availableProductNames.Count; i++)
			{
				string baseFilename = "BaseProductInfo";
				string installedFilename = string.Concat(availableProductNames[i], "InstalledProductInfo");
				string path = IsInstalled(installedFilename);

				if (path != null)
				{
					ProductInfo installedProduct = ParseXml(XDocument.Load(path))[0];
					installedProduct.Initialize(Repaint);
					installedProducts.Add(installedProduct);
				}
				else
				{
					ProductInfo availableProduct = ParseXml(XDocument.Parse(((TextAsset)Resources.Load(baseFilename)).text))[i];
					availableProduct.Initialize(Repaint);
					availableProducts.Add(availableProduct);
				}
			}
        }
        
        private void DrawAboutCinemaSuiteSection()
        {
            // Draw the About Cinema Suite Section
            Rect aboutRect = EditorGUILayout.GetControlRect(GUILayout.Width(base.position.width - 22));
            GUI.Box(new Rect(aboutRect.x - 4, aboutRect.y, aboutRect.width + 8, aboutRect.height), string.Empty, EditorStyles.toolbar);
            showCinemaSuiteAbout.target = EditorGUI.Foldout(aboutRect, showCinemaSuiteAbout.target, "About Cinema Suite");

#if UNITY_5 || UNITY_2017_1_OR_NEWER
            using (var group = new EditorGUILayout.FadeGroupScope(showCinemaSuiteAbout.faded))
            {
                if (group.visible)
                {
#else
            {
                if (showCinemaSuiteAbout.target)
                {
#endif
                    
                    // Header
                    EditorGUILayout.BeginHorizontal();
                    //GUILayout.Label("<b><size=30>Cinema Suite</size></b>");
                    GUILayout.Label(cinemaSuiteLogo);

                    // Web and Social Media Links
                    if (GUILayout.Button(websiteIcon, GUILayout.Height(32), GUILayout.Width(32)))
                    {
                        Application.OpenURL("http://www.cinema-suite.com");
                    }
                    if(GUILayout.Button(forumIcon, GUILayout.Height(32), GUILayout.Width(32)))
                    {
                        Application.OpenURL("http://cinema-suite.com/forum");
                    }
                    if(GUILayout.Button(facebookIcon, GUILayout.Height(32), GUILayout.Width(32)))
                    {
                        Application.OpenURL("https://www.facebook.com/CinemaSuiteInc/");
                    }
                    if(GUILayout.Button(twitterIcon, GUILayout.Height(32), GUILayout.Width(32)))
                    {
                        Application.OpenURL("https://twitter.com/CinemaSuiteInc");
                    }
                    if(GUILayout.Button(youtubeIcon, GUILayout.Height(32), GUILayout.Width(32)))
                    {
                        Application.OpenURL("https://www.youtube.com/cinemasuiteinc");
                    }

                    EditorGUILayout.EndHorizontal();

                    GUILayout.Space(8f);

                    // About us
                    GUILayout.Label("We are a team who are passionate about Video Games and are dedicated to creating useful software extensions for video game developers.");

                    // Special thanks
                    GUILayout.Label("We would like to extend a special thanks to the Canada Media Fund.");
                    GUILayout.Label(cmfLogo);

                    GUILayout.Space(16f);

                    // Legal Stuff
                    legalStuff = EditorGUILayout.Foldout(legalStuff, new GUIContent("Legal Stuff"));
                    if (legalStuff)
                    {
                        legalScrollPosition = GUILayout.BeginScrollView(legalScrollPosition, false, true, GUILayout.Height(200f));
                        GUILayout.TextArea(DISCLAIMER1 + DISCLAIMER2 + DISCLAIMER3 + DISCLAIMER4 + DISCLAIMER5 + DISCLAIMER6);
                
                        GUILayout.EndScrollView();
                    }

                    
                }
            }
        }

        private static Type[] GetAllSubTypes(System.Type ParentType)
        {
            List<System.Type> list = new List<System.Type>();
            foreach (Assembly a in System.AppDomain.CurrentDomain.GetAssemblies())
            {
                foreach (System.Type type in a.GetTypes())
                {
                    if (type.IsSubclassOf(ParentType))
                    {
                        list.Add(type);
                    }
                }
            }
            return list.ToArray();
        }

		public List<ProductInfo> ParseXml(XDocument xml)
		{
			string suffix = EditorGUIUtility.isProSkin ? "_Pro" : "_Personal";

			var productList = (from element in xml.Root.Elements("product")
			                    select new ProductInfo
			                    {
				name = (string)element.Element("name"),
				keyImage = Resources.Load((string)element.Element("keyImage")) as Texture2D,
				headerText = "<size=16>" + (string)element.Element("headerText") + "</size>",
				header2Text = "<size=14>" + (string)element.Element("header2Text") + "</size>",
				bodyText = (string)element.Element("bodyText"),
				resourceImage1 = Resources.Load((string)element.Element("resourceImage1") + suffix) as Texture2D,
				resourceImage2 = Resources.Load((string)element.Element("resourceImage2") + suffix) as Texture2D,
				resourceImage3 = Resources.Load((string)element.Element("resourceImage3") + suffix) as Texture2D,
				resourceImage4 = Resources.Load((string)element.Element("resourceImage4") + suffix) as Texture2D,
				resourceImage1Link = (string)element.Element("resourceImage1Link"),
				resourceImage2Link = (string)element.Element("resourceImage2Link"),
				resourceImage3Link = (string)element.Element("resourceImage3Link"),
				resourceImage4Link = (string)element.Element("resourceImage4Link"),
				resourceImage1Label = (string)element.Element("resourceImage1Label"),
				resourceImage2Label = (string)element.Element("resourceImage2Label"),
				resourceImage3Label = (string)element.Element("resourceImage3Label"),
				resourceImage4Label = (string)element.Element("resourceImage4Label"),
				assetStorePage = (string)element.Element("assetStorePage"),
				installed = Convert.ToBoolean((string)element.Element("installed"))
			}).ToList();

			return productList;
		}
		
		public string IsInstalled(string InstalledProduct)
		{
			var allFiles = Directory.GetFiles("Assets/Cinema Suite/", "*.xml", SearchOption.AllDirectories);
			
			if (allFiles.Length != 0) {
				foreach (var fi in allFiles)
				{
					if (fi.Contains(InstalledProduct))
					{
						return fi;
					}
				}
			}
			return null;
		}

        /// <summary>
        /// Show the Cinema Mocap Window
        /// </summary>
        [MenuItem(MENU_ITEM, false, 100)]
        private static void ShowWindow()
        {
            CinemaSuiteWelcome welcomeWindow = (CinemaSuiteWelcome) EditorWindow.GetWindow(typeof(CinemaSuiteWelcome));
            welcomeWindow.ShowAboutFirst = true;
        }
    }
}