using UnityEngine;
using System.Threading;
using System.Collections.Generic;

public static class ImageFilter
{
    static Material _material;

    public static Texture2D Upscale(Texture2D source, float factor = 1, bool esrgan = false)
    {
        if (esrgan)
        {
            return AssetUpscaler.UpscaleTexture(source);
        }
        // Convert to ARGB32
        Texture2D uncompressed = new Texture2D(source.width, source.height, TextureFormat.ARGB32, false);

        uncompressed.SetPixels(source.GetPixels());
        uncompressed.Apply();

        TextureScale.Bilinear(
            uncompressed,
            (int)(uncompressed.width * factor),
            (int)(uncompressed.height * factor)
        );

        //return uncompressed;

        // Use AI Upscaling with Anime4k
        RenderTexture rt = RenderTexture.GetTemporary(uncompressed.width, uncompressed.height, 32, RenderTextureFormat.ARGB32);

        ApplyShader(
            uncompressed,
            rt,
            "Hidden/Anime4K", 
            new Dictionary<string, float>()
            {
                { "_Strength", 1f }
            },
            4
        );

        Texture2D result = Convert(source, uncompressed, rt);
        RenderTexture.ReleaseTemporary(rt);

        //Texture2D withAlpha = new Texture2D(uncompressed.width, uncompressed.height, TextureFormat.ARGB32, false);

        //// Apply the original alpha values
        //for (int w = 0; w < uncompressed.width; w++)
        //{
        //    for (int h = 0; h < uncompressed.height; h++)
        //    {
        //        Color c = result.GetPixel(w, h);
        //        Color original = uncompressed.GetPixel(w, h);
        //        withAlpha.SetPixel(w, h, new Color(
        //            c.r,
        //            c.g,
        //            c.b,
        //            original.a
        //        ));
        //    }
        //}
        //withAlpha.Apply();

        return result;
    }

    public static Texture2D ApplyShader (Texture2D source, string shader, Dictionary<string, float> parameters, int passes)
    {
        // Convert to ARGB32
        Texture2D uncompressed = new Texture2D(source.width, source.height, TextureFormat.ARGB32, false);

        uncompressed.SetPixels(source.GetPixels());
        uncompressed.Apply();

        // Use AI Upscaling with Anime4k
        RenderTexture rt = RenderTexture.GetTemporary(uncompressed.width, uncompressed.height, 32, RenderTextureFormat.ARGB32);

        ApplyShader(uncompressed, rt, shader, parameters, passes);
        Texture2D result = Convert(source, uncompressed, rt);

        RenderTexture.ReleaseTemporary(rt);

        return result;
    }

    public static Texture2D GenerateNormal(Texture2D source)
    {
        return ApplyShader(source, "Mattatz/SobelFilter", new Dictionary<string, float>(), 1);
    }

    public static void ApplyShader (Texture2D source, RenderTexture destination, string shader, Dictionary<string, float> parameters, int passes)
    {
        if (_material == null)
            _material = new Material(Shader.Find(shader));

        foreach (string key in parameters.Keys)
        {
            _material.SetFloat(key, parameters[key]);
        }

        RenderTexture tempRT1 = RenderTexture.GetTemporary(destination.width, destination.height);
        RenderTexture tempRT2 = RenderTexture.GetTemporary(destination.width, destination.height);

        Graphics.CopyTexture(source, tempRT1);
        for (int p = 0; p < passes; p++)
        {
            Graphics.Blit(tempRT1, tempRT2, _material, p);
            Graphics.CopyTexture(tempRT2, tempRT1);
        }
        Graphics.CopyTexture(tempRT1, destination);

        RenderTexture.ReleaseTemporary(tempRT1);
        RenderTexture.ReleaseTemporary(tempRT2);
    }

    static Texture2D Convert(Texture2D original, Texture2D source, RenderTexture rt)
    {
        Texture2D tex = new Texture2D(source.width, source.height, source.format, false);

        Graphics.CopyTexture(rt, tex);

        return tex;
    }
}

// Only works on ARGB32, RGB24 and Alpha8 textures that are marked readable
// Source: http://wiki.unity3d.com/index.php/TextureScale
public class TextureScale
{
    public class ThreadData
    {
        public int start;
        public int end;
        public ThreadData(int s, int e)
        {
            start = s;
            end = e;
        }
    }

    private static Color[] texColors;
    private static Color[] newColors;
    private static int w;
    private static float ratioX;
    private static float ratioY;
    private static int w2;
    private static int finishCount;
    private static Mutex mutex;

    public static void Point(Texture2D tex, int newWidth, int newHeight)
    {
        ThreadedScale(tex, newWidth, newHeight, false);
    }

    public static void Bilinear(Texture2D tex, int newWidth, int newHeight)
    {
        ThreadedScale(tex, newWidth, newHeight, true);
    }

    private static void ThreadedScale(Texture2D tex, int newWidth, int newHeight, bool useBilinear)
    {
        texColors = tex.GetPixels();
        newColors = new Color[newWidth * newHeight];
        if (useBilinear)
        {
            ratioX = 1.0f / ((float)newWidth / (tex.width - 1));
            ratioY = 1.0f / ((float)newHeight / (tex.height - 1));
        }
        else
        {
            ratioX = ((float)tex.width) / newWidth;
            ratioY = ((float)tex.height) / newHeight;
        }
        w = tex.width;
        w2 = newWidth;
        var cores = Mathf.Min(SystemInfo.processorCount, newHeight);
        var slice = newHeight / cores;

        finishCount = 0;
        if (mutex == null)
        {
            mutex = new Mutex(false);
        }
        if (cores > 1)
        {
            int i = 0;
            ThreadData threadData;
            for (i = 0; i < cores - 1; i++)
            {
                threadData = new ThreadData(slice * i, slice * (i + 1));
                ParameterizedThreadStart ts = useBilinear ? new ParameterizedThreadStart(BilinearScale) : new ParameterizedThreadStart(PointScale);
                Thread thread = new Thread(ts);
                thread.Start(threadData);
            }
            threadData = new ThreadData(slice * i, newHeight);
            if (useBilinear)
            {
                BilinearScale(threadData);
            }
            else
            {
                PointScale(threadData);
            }
            while (finishCount < cores)
            {
                Thread.Sleep(1);
            }
        }
        else
        {
            ThreadData threadData = new ThreadData(0, newHeight);
            if (useBilinear)
            {
                BilinearScale(threadData);
            }
            else
            {
                PointScale(threadData);
            }
        }

        tex.Resize(newWidth, newHeight);
        tex.SetPixels(newColors);
        tex.Apply();

        texColors = null;
        newColors = null;
    }

    public static void BilinearScale(System.Object obj)
    {
        ThreadData threadData = (ThreadData)obj;
        for (var y = threadData.start; y < threadData.end; y++)
        {
            int yFloor = (int)Mathf.Floor(y * ratioY);
            var y1 = yFloor * w;
            var y2 = (yFloor + 1) * w;
            var yw = y * w2;

            for (var x = 0; x < w2; x++)
            {
                int xFloor = (int)Mathf.Floor(x * ratioX);
                var xLerp = x * ratioX - xFloor;
                newColors[yw + x] = ColorLerpUnclamped(ColorLerpUnclamped(texColors[y1 + xFloor], texColors[y1 + xFloor + 1], xLerp),
                                                        ColorLerpUnclamped(texColors[y2 + xFloor], texColors[y2 + xFloor + 1], xLerp),
                                                        y * ratioY - yFloor);
            }
        }

        mutex.WaitOne();
        finishCount++;
        mutex.ReleaseMutex();
    }

    public static void PointScale(System.Object obj)
    {
        ThreadData threadData = (ThreadData)obj;
        for (var y = threadData.start; y < threadData.end; y++)
        {
            var thisY = (int)(ratioY * y) * w;
            var yw = y * w2;
            for (var x = 0; x < w2; x++)
            {
                newColors[yw + x] = texColors[(int)(thisY + ratioX * x)];
            }
        }

        mutex.WaitOne();
        finishCount++;
        mutex.ReleaseMutex();
    }

    private static Color ColorLerpUnclamped(Color c1, Color c2, float value)
    {
        return new Color(c1.r + (c2.r - c1.r) * value,
                            c1.g + (c2.g - c1.g) * value,
                            c1.b + (c2.b - c1.b) * value,
                            c1.a + (c2.a - c1.a) * value);
    }
}
