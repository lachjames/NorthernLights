using UnityEngine;
using System.Collections;
using System;

public class NormalMapMakerRuntimeDemo : MonoBehaviour 
{

	// example texture to load
	public string url = "http://upload.wikimedia.org/wikipedia/commons/4/49/Olivine_basalt2.jpg";

	// Sample texture: "Olivine basalt2". Licensed under Creative Commons Attribution-Share Alike 3.0 via Wikimedia Commons
	// http://commons.wikimedia.org/wiki/File:Olivine_basalt2.jpg#mediaviewer/File:Olivine_basalt2.jpg


	void Start () 
	{
		// call our image loader & converter sample
		StartCoroutine("LoadImageFromWebAndConvertToNormalMap");
	}
	

	// example: Loads texture using WWW, then filters it, converts to normalmap, creates specular map and assigns them to material
	IEnumerator LoadImageFromWebAndConvertToNormalMap()
	{

		Debug.Log ("Loading texture:" + url);
		WWW www = new WWW(url);
		yield return www;

		Debug.Log ("Finished loading");
		if (!String.IsNullOrEmpty(www.error))	Debug.Log("Texture loading error:" + www.error);


		// assign as maintexture
		GetComponent<Renderer>().material.mainTexture = www.texture;

		// OPTIONAL: filter the texture first before creating normal map
		Debug.Log ("Filtering texture..");
		Texture2D filteredTex = NormalMapTools.FilterMedian(www.texture,5);

		// create normal map
		Debug.Log ("Creating normal map");
		Texture2D normalTex = NormalMapTools.CreateNormalmap(filteredTex,6);
		//Texture2D normalTex = NormalMapTools.CreateNormalmap(www.texture,5); // if want to use original texture, instead of filtered
		GetComponent<Renderer>().material.SetTexture("_BumpMap",normalTex);
		// NOTE: Normal map shader needs to be modified, UnpackNormal() is not needed, it breaks the runtime normalmap..
		// http://forum.unity3d.com/threads/creating-runtime-normal-maps-using-rendertotexture.135841/#post-924587


		// create specular map
//		Texture2D specularTex = NormalMapTools.CreateSpecular(www.texture,1.2f,0.35f); // using original texture
		Debug.Log ("Creating specular map");
		Texture2D specularTex = NormalMapTools.CreateSpecular(filteredTex,1.2f,0.5f); // using filtered texture
		GetComponent<Renderer>().material.SetTexture("_SpecMap",specularTex);


		// EXTRA TOOLS: combine rgb texture + specular texture (if you want to use unity default specular shader which takes main texture as RGB + A = gloss)
		//Debug.Log ("Combining RGB + Specular");
		//Texture2D RGBSpecTex = NormalMapTools.CombineRGBAndSpecular(www.texture,specularTex);
		//renderer.material.mainTexture = RGBSpecTex;


	}
}
