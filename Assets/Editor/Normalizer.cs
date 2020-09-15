using AuroraEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class NormalizerViewer : EditorWindow
{
    string resref;
    Texture2D diffuse;
    Texture2D normal;

    [MenuItem("KotOR/Normalizer")]
    public static void ShowWindow()
    {
        EditorWindow.GetWindow(typeof(NormalizerViewer));
    }

    public void OnGUI()
    {
        using (new EditorGUILayout.VerticalScope())
        {
            resref = EditorGUILayout.TextField("Resref", resref);

            if (GUILayout.Button("Load"))
            {
                LoadTexture();
            }

            if (GUILayout.Button("Convert"))
            {
                ConvertTexture();
            }

            if (diffuse != null)
            {
                ShowTextures();
            }

            if (GUILayout.Button("Reset"))
            {
                diffuse = null;
                normal = null;
            }
        }
    }

    void LoadTexture()
    {
        diffuse = AuroraEngine.Resources.LoadTexture2D(resref);
    }

    void ConvertTexture()
    {
        normal = NormalMapTools.CreateNormalmap(diffuse, 3);
        //normal = ImageFilter.GenerateNormal(diffuse);
        //normal = NormalGeneration.Diff2Normal(diffuse);
        //normal = Normalizer.CreateNormalMap(diffuse);
    }

    void ShowTextures()
    {
        using (new EditorGUILayout.HorizontalScope())
        {
            if (diffuse != null)
            {
                GUILayout.Label(
                    diffuse,
                    GUILayout.Width(position.width / 2f),
                    GUILayout.Height(position.width / 2f)
                );
            }
            if (normal != null)
            {
                GUILayout.Label(
                    normal,
                    GUILayout.Width(position.width / 2f),
                    GUILayout.Height(position.width / 2f)
                );
            }
        }
    }
}

//public static class Normalizer
//{
//    public static Texture2D CreateNormalMap(Texture2D diffuse, int nClusters, int nHeights)
//    {
//        return null;
//        // This algorithm works like follows:
//        //    - We find the edges of the image
//        //    - We segment the image into clusters
//        //    - We assign a height to each cluster
//        //    - We create a normal map from this height map

//        //bool[][] edges = CreateEdgeMap(diffuse);
//        //int[][] clusters = CreateClusterMap(edges, nClusters);
//        //int[][] heights = CreateHeightMap(clusters, nHeights);
//        //Texture2D normalMap = HeightsToNormals(heights);

//        //return normalMap;
//    }

//    public static bool[][] CreateEdgeMap(Texture2D tex)
//    {
//        // We apply the Sobel operator to the image
//        return null;
//    }

//    private static Bitmap ConvolutionFilter(Bitmap sourceImage,
//    double[,] xkernel,
//    double[,] ykernel, double factor = 1, int bias = 0, bool grayscale = false)
//    {

//        //Image dimensions stored in variables for convenience
//        int width = sourceImage.Width;
//        int height = sourceImage.Height;

//        //Lock source image bits into system memory
//        BitmapData srcData = sourceImage.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);

//        //Get the total number of bytes in your image - 32 bytes per pixel x image width x image height -> for 32bpp images
//        int bytes = srcData.Stride * srcData.Height;

//        //Create byte arrays to hold pixel information of your image
//        byte[] pixelBuffer = new byte[bytes];
//        byte[] resultBuffer = new byte[bytes];

//        //Get the address of the first pixel data
//        IntPtr srcScan0 = srcData.Scan0;

//        //Copy image data to one of the byte arrays
//        Marshal.Copy(srcScan0, pixelBuffer, 0, bytes);

//        //Unlock bits from system memory -> we have all our needed info in the array
//        sourceImage.UnlockBits(srcData);
//    }

//    public static int[][] CreateClusterMap(bool[][] edgeMap, int numClusters)
//    {
//        return null;
//    }
//    public static int[][] CreateHeightMap(int[][] edgeMap, int numHeights)
//    {
//        return null;
//    }

//    public static Texture2D HeightsToNormals(int[][] clusters, int numLevels)
//    {
//        return null;
//    }
//}