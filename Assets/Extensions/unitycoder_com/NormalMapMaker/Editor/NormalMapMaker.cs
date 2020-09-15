//
// NormalMapMaker by mgear / UnityCoder.com
// url: http://unitycoder.com
// 

using UnityEditor;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace unitycodercom_mapmaker
{
		
	public class NormalMapMaker : EditorWindow
	{
		public static Texture2D sourceImage;
		private static int normalStrength = 5; // default 5
		private static int medianFilterStrength = 3; //  default 3
		private static bool normalGroupEnabled = true;
		private static bool specularGroupEnabled = true;
		private static float specularCutOff = 0.40f; // default 0.4
		private static float specularContrast = 1.5f; // default 1.5
		private static string appName = "NormalMapMaker";
		public static string normalSuffix = "_normal.png";
		public static string specularSuffix = "_specular.png";
		public static bool running = false;

		// create menu item and window
	    [MenuItem ("Window/Normal Map Maker")]
	    static void Init () 
		{
	    NormalMapMaker window = (NormalMapMaker)EditorWindow.GetWindow (typeof (NormalMapMaker));
			window.title = appName;
			window.minSize = new Vector2(300,348);
			window.maxSize = new Vector2(300,350);
			running = true;
	    }
		
		// window closed
		void OnDestroy()
		{
			running = false;
		}
		
		// main loop/gui
		void OnGUI () 
		{
			GUILayout.Label ("Source Texture", EditorStyles.boldLabel);
			EditorGUILayout.BeginHorizontal();
	            sourceImage = EditorGUILayout.ObjectField(sourceImage, typeof(Texture2D),false, GUILayout.Height(100)) as Texture2D;
	        EditorGUILayout.EndHorizontal();
			if (sourceImage!=null)
			{
				GUILayout.Label (sourceImage.name+ "  ("+sourceImage.width+"x"+sourceImage.height+")", EditorStyles.miniLabel);
			}else{
				GUILayout.Label ("", EditorStyles.miniLabel);
			}
	        EditorGUILayout.Space();
			normalGroupEnabled = EditorGUILayout.BeginToggleGroup("Create Normal Map", normalGroupEnabled);
				normalStrength = EditorGUILayout.IntSlider("Bumpiness Strength",normalStrength,1, 20);
				medianFilterStrength = EditorGUILayout.IntSlider("Median Filter Strength",medianFilterStrength,0, 10); 
			EditorGUILayout.EndToggleGroup();
	        EditorGUILayout.Space();
			specularGroupEnabled = EditorGUILayout.BeginToggleGroup("Create Specular Map", specularGroupEnabled);
				specularCutOff = EditorGUILayout.Slider("Brightness Cutoff",specularCutOff,0, 1);
				specularContrast = EditorGUILayout.Slider("Specular Contrast",specularContrast,0, 2);
			EditorGUILayout.EndToggleGroup();

			//  ** Create button GUI **
			EditorGUILayout.Space();
			GUI.enabled = sourceImage&&(normalGroupEnabled||specularGroupEnabled)?true:false; // disabled if no sourceImage selected
			if(GUILayout.Button (new GUIContent ("Create Map"+(normalGroupEnabled&&specularGroupEnabled?"s":""), "Create Map"+(normalGroupEnabled&&specularGroupEnabled?"s":"")), GUILayout.Height(40))) 
			{
				buildMaps(sourceImage.width,sourceImage.height,sourceImage.name);
			}
			GUI.enabled = true;
		}
		

		// ** building maps **
		void buildMaps(int textureWidth, int textureHeight, string baseFile)
		{
			float progress = 0.0f;
			float progressStep = 1.0f/textureHeight;
			bool setReadable = false;

			// check if its readable, if not set it temporarily readable
			string path = AssetDatabase.GetAssetPath(sourceImage);
			TextureImporter textureImporter = AssetImporter.GetAtPath(path) as TextureImporter;
			if (textureImporter.isReadable == false)
			{
				textureImporter.isReadable = true;
				AssetDatabase.ImportAsset(path, ImportAssetOptions.ForceUpdate);
				setReadable = true;
			}

			Texture2D texSource = new Texture2D(textureWidth, textureHeight, TextureFormat.RGB24, false, false);
			// clone original texture
			Color[] temp = sourceImage.GetPixels();
			texSource.SetPixels(temp);
			if (specularGroupEnabled)
			{
				Texture2D texSpecular = new Texture2D(textureWidth, textureHeight, TextureFormat.RGB24, false, false);
				Color[] pixels = new Color[textureWidth*textureHeight];
				for (int y=0;y<textureHeight;y++)
				{
					for (int x=0;x<textureWidth;x++)
					{
						float bw = sourceImage.GetPixel(x,y).grayscale;
						// adjust contrast
						bw *= bw * specularContrast;
						bw = bw<(specularContrast*specularCutOff)?-1:bw;
						bw = Mathf.Clamp(bw,-1,1);
						bw *= 0.5f;
						bw += 0.5f;
						Color c = new Color(bw,bw,bw,1);
						pixels[x+y*textureWidth] = c;
					}
					
					// progress bar
					progress+=progressStep;
					if(EditorUtility.DisplayCancelableProgressBar(appName,"Creating specular map..",progress)) 
					{
						Debug.Log(appName+": Specular map creation cancelled by user (strange texture results will occur)");
						EditorUtility.ClearProgressBar();
						break;
					}		
				}
				EditorUtility.ClearProgressBar();
				
				// apply texture
				texSpecular.SetPixels(pixels);
				
				// save texture as png
				byte[] bytes3  = texSpecular.EncodeToPNG();
				File.WriteAllBytes(Path.GetDirectoryName(path) + "/" + baseFile+specularSuffix, bytes3);
				// cleanup texture
				UnityEngine.Object.DestroyImmediate(texSpecular);
			}
			
			if (normalGroupEnabled)
			{
				progress = 0;
				if (medianFilterStrength>=2) // must be atleast 2 for median filter
				{
					texSource.SetPixels(filtersMedian(sourceImage,medianFilterStrength));
				}

				Color[] pixels = new Color[textureWidth*textureHeight];
				// sobel filter
				Texture2D texNormal = new Texture2D(textureWidth, textureHeight, TextureFormat.RGB24, false, false);			
				Vector3 vScale = new Vector3(0.3333f,0.3333f,0.3333f);
				for (int y=0;y<textureHeight;y++)
				{
					for (int x=0;x<textureWidth;x++)
					{
						Color tc = texSource.GetPixel(x-1, y-1);
						Vector3 cSampleNegXNegY = new Vector3(tc.r,tc.g,tc.g);
						tc = texSource.GetPixel(x, y-1);
						Vector3 cSampleZerXNegY = new Vector3(tc.r,tc.g,tc.g);
						tc = texSource.GetPixel(x+1, y-1);
						Vector3 cSamplePosXNegY = new Vector3(tc.r,tc.g,tc.g);
						tc = texSource.GetPixel(x-1, y);
						Vector3 cSampleNegXZerY = new Vector3(tc.r,tc.g,tc.g);
						tc = texSource.GetPixel(x+1,y);
						Vector3 cSamplePosXZerY = new Vector3(tc.r,tc.g,tc.g);
						tc = texSource.GetPixel(x-1,y+1);
						Vector3 cSampleNegXPosY = new Vector3(tc.r,tc.g,tc.g);
						tc = texSource.GetPixel(x,y+1);
						Vector3 cSampleZerXPosY = new Vector3(tc.r,tc.g,tc.g);
						tc = texSource.GetPixel(x+1,y+1);
						Vector3 cSamplePosXPosY = new Vector3(tc.r,tc.g,tc.g);
						float fSampleNegXNegY = Vector3.Dot(cSampleNegXNegY, vScale);
						float fSampleZerXNegY = Vector3.Dot(cSampleZerXNegY, vScale);
						float fSamplePosXNegY = Vector3.Dot(cSamplePosXNegY, vScale);
						float fSampleNegXZerY = Vector3.Dot(cSampleNegXZerY, vScale);
						float fSamplePosXZerY = Vector3.Dot(cSamplePosXZerY, vScale);
						float fSampleNegXPosY = Vector3.Dot(cSampleNegXPosY, vScale);
						float fSampleZerXPosY = Vector3.Dot(cSampleZerXPosY, vScale);
						float fSamplePosXPosY = Vector3.Dot(cSamplePosXPosY, vScale);							
						float edgeX = (fSampleNegXNegY - fSamplePosXNegY) * 0.25f+(fSampleNegXZerY - fSamplePosXZerY) * 0.5f+ (fSampleNegXPosY - fSamplePosXPosY) * 0.25f;
						float edgeY = (fSampleNegXNegY - fSampleNegXPosY) * 0.25f+(fSampleZerXNegY - fSampleZerXPosY)*0.5f+(fSamplePosXNegY - fSamplePosXPosY)*0.25f;
						Vector2 vEdge = new Vector2(edgeX,edgeY)*normalStrength;
						Vector3 norm = new Vector3(vEdge.x,vEdge.y, 1.0f).normalized;
						Color c = new Color(norm.x*0.5f+0.5f,norm.y*0.5f+0.5f,norm.z*0.5f+0.5f,1);
						pixels[x+y*textureWidth] = c;
					}
					// progress bar
					progress+=progressStep;
					if(EditorUtility.DisplayCancelableProgressBar(appName,"Creating normal map..",progress)) 
					{
						Debug.Log(appName+": Normal map creation cancelled by user (strange texture results will occur)");
						EditorUtility.ClearProgressBar();
						break;
					}		
				}
				
				// apply texture
				texNormal.SetPixels(pixels);
				
				// save texture as png
				byte[] bytes2  = texNormal.EncodeToPNG();
				File.WriteAllBytes(Path.GetDirectoryName(path) + "/"+baseFile+normalSuffix, bytes2);
				
				// remove progressbar
				EditorUtility.ClearProgressBar();
				
				// cleanup texture
				UnityEngine.Object.DestroyImmediate(texNormal);
			}
			
			// cleanup texture
			UnityEngine.Object.DestroyImmediate(texSource);
			
			// restore isReadable setting, if we had changed it
			if (setReadable)
			{
				textureImporter.isReadable = false;
				AssetDatabase.ImportAsset(path, ImportAssetOptions.ForceUpdate);
				setReadable = false;
			}
			AssetDatabase.Refresh();
		} // buildMaps()


		// ** helper functions **
		Color[] filtersMedian(Texture2D t, int fSize)
		{
			float progress = 0.0f;
			float progressStep = 1.0f/t.height;
			Color[] normalTemp = new Color[t.width*t.height];
			int tIndex = 0;
			int medianMin = -(fSize/2);
			int medianMax = (fSize/2);
			List<float> r = new List<float>();
			List<float> g = new List<float>();
			List<float> b = new List<float>();
			for (int x = 0; x < t.width; ++x)
			{
				for (int y = 0; y < t.height; ++y)
				{
					r.Clear();
					g.Clear();
					b.Clear();
					for (int x2 = medianMin; x2 < medianMax; ++x2)
					{
						int tx = x + x2;
						if (tx >= 0 && tx < t.width)
						{
							for (int y2 = medianMin; y2 < medianMax; ++y2)
							{
								int ty = y + y2;
								if (ty >= 0 && ty < t.height)
								{
									Color c = t.GetPixel(tx, ty);
									r.Add(c.r);
									g.Add(c.g);
									b.Add(c.b);
								}
							}
						}
					}
					r.Sort();
					g.Sort();
					b.Sort();
					normalTemp[x+y*t.width]=new Color(r[r.Count/2],g[g.Count/2], b[b.Count/2]);
					tIndex++;
				}
				
				// progress bar
				progress+=progressStep;
				if(EditorUtility.DisplayCancelableProgressBar(appName,"Median filtering..",progress)) 
				{
					Debug.Log(appName+": Filtering cancelled by user (strange texture results will occur)");
					EditorUtility.ClearProgressBar();
					break;
				}
			}
			EditorUtility.ClearProgressBar();
			return normalTemp;
		} // filtersMedian()

	} // class : normalmapmaker

	// helper class for setting texture type to NormalMap
	class fixNormalMaps : AssetPostprocessor 
	{
		void OnPostprocessTexture (Texture2D texture)
		{
			// early exists if window not open or no source image selected
			if (!NormalMapMaker.running) return;
			if (NormalMapMaker.sourceImage.name==null) return;
			
			if (assetPath.Contains(NormalMapMaker.sourceImage.name+NormalMapMaker.normalSuffix))
			{
				// mark it as normal map texture type
				TextureImporter normalTextureImporter = assetImporter as TextureImporter;
				if (normalTextureImporter.textureType!=TextureImporterType.NormalMap)
				{
					normalTextureImporter.textureType = TextureImporterType.NormalMap;
					AssetDatabase.Refresh();
				}
				// ping the created file
	//			EditorGUIUtility.PingObject(AssetDatabase.LoadMainAssetAtPath(assetPath)); // only works on 2nd time..but then asset already exists and we dont want to always ping there..
			}
	    }
	} // class : fixnormalmaps

} // namespace
