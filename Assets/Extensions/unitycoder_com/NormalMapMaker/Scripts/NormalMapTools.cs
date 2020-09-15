// Runtime tools for texture manipulation (unitycoder.com)

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class NormalMapTools 
{

	/// <summary>
	/// Creates the specular map
	/// </summary>
	/// <returns>specular map texture</returns>
	/// <param name="t">source texture</param>
	/// <param name="specularContrast">Specular contrast float (example: 0-2)</param>
	/// <param name="specularCutOff">Specular cut off float (example: 0-1)</param>
	public static Texture2D CreateSpecular(Texture2D t, float specularContrast, float specularCutOff)
	{

		Color[] pixels = t.GetPixels();
		Texture2D texSpecular = new Texture2D(t.width, t.height, TextureFormat.RGB24, false, false);

		for (int y=0;y<t.height;y++)
		{
			for (int x=0;x<t.width;x++)
			{
//				float bw = t.GetPixel(x,y).grayscale;
				float bw = pixels[x+y*t.width].grayscale;
				// adjust contrast
				bw *= bw * specularContrast;
				bw = bw<(specularContrast*specularCutOff)?-1:bw;
				bw = Mathf.Clamp(bw,-1,1);
				bw *= 0.5f;
				bw += 0.5f;
				Color c = new Color(bw,bw,bw,1);
				pixels[x+y*t.width] = c;
			}
		}

		texSpecular.SetPixels(pixels);
		texSpecular.Apply();
		return texSpecular;
	}


	/// <summary>
	/// Create the normalmap
	/// </summary>
	/// <returns>normal map color array</returns>
	/// <param name="t">source texture</param>
	/// <param name="normalStrength">normal map strength float (example: 1-20)</param>
	public static Texture2D CreateNormalmap(Texture2D t, float normalStrength)
	{
		Color[] pixels = new Color[t.width*t.height];
		Texture2D texNormal = new Texture2D(t.width, t.height, TextureFormat.RGB24, false, false);			
		Vector3 vScale = new Vector3(0.3333f,0.3333f,0.3333f);

		// TODO: would be faster using pixel array, instead of getpixel
		for (int y=0;y<t.height;y++)
		{
			for (int x=0;x<t.width;x++)
			{
				Color tc = t.GetPixel(x-1, y-1);
				Vector3 cSampleNegXNegY = new Vector3(tc.r,tc.g,tc.g);
				tc = t.GetPixel(x, y-1);
				Vector3 cSampleZerXNegY = new Vector3(tc.r,tc.g,tc.g);
				tc = t.GetPixel(x+1, y-1);
				Vector3 cSamplePosXNegY = new Vector3(tc.r,tc.g,tc.g);
				tc = t.GetPixel(x-1, y);
				Vector3 cSampleNegXZerY = new Vector3(tc.r,tc.g,tc.g);
				tc = t.GetPixel(x+1,y);
				Vector3 cSamplePosXZerY = new Vector3(tc.r,tc.g,tc.g);
				tc = t.GetPixel(x-1,y+1);
				Vector3 cSampleNegXPosY = new Vector3(tc.r,tc.g,tc.g);
				tc = t.GetPixel(x,y+1);
				Vector3 cSampleZerXPosY = new Vector3(tc.r,tc.g,tc.g);
				tc = t.GetPixel(x+1,y+1);
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


				pixels[x+y*t.width] = c;
			} // for x
		} // for y

		texNormal.SetPixels(pixels);
		texNormal.Apply();

		return texNormal;
	} // CreateNormalmap




	/// <summary>
	/// Median filter
	/// </summary>
	/// <returns>filtered color array</returns>
	/// <param name="t">t = source texture</param>
	/// <param name="filterSize">fSize = filter size</param>
	public static Texture2D FilterMedian(Texture2D t, int filterSize)
	{
		Color[] pixels = new Color[t.width*t.height];
		Texture2D texFiltered = new Texture2D(t.width, t.height, TextureFormat.RGB24, false, false);	
		int tIndex = 0;
		int medianMin = -(filterSize/2);
		int medianMax = (filterSize/2);
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
					if (tx >= 0 && tx < t.width) // TODO: should wrap around? use modulus..
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
				pixels[x+y*t.width]=new Color(r[r.Count/2],g[g.Count/2], b[b.Count/2]);
				tIndex++;
			}
		}
		texFiltered.SetPixels(pixels);
		texFiltered.Apply();
		return texFiltered;
	} // filtersMedian()



	/// <summary>
	/// Combines the RGB and specular into one texture
	/// </summary>
	/// <returns>ARGB32 texture with RGB + Alpha as specular(gloss)</returns>
	/// <param name="t">source RGB texture (rgb)</param>
	/// <param name="s">source Specular texture (rgb)</param>
	public static Texture2D CombineRGBAndSpecular(Texture2D t, Texture2D s)
	{
		Color[] pixels = t.GetPixels();
		Color[] pixelsSpec = s.GetPixels();
		Texture2D texCombined = new Texture2D(t.width, t.height, TextureFormat.ARGB32, false, false);

		for (int y=0;y<t.height;y++)
		{
			for (int x=0;x<t.width;x++)
			{
				pixels[x+y*t.width].a = pixelsSpec[x+y*t.width].grayscale; // take grayscale value from specular texture
			}
		}

		texCombined.SetPixels(pixels);
		texCombined.Apply();
		return texCombined;

	}


}
