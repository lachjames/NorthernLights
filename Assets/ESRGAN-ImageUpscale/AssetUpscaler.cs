using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using Barracuda;
using UnityEditor;
using UnityEngine;
using UnityEngine.Networking;

public class AssetUpscaler
{
    internal class TextureUpcalingContext
    {  
        public Model model;
        public IWorker worker;
        public Tensor input;
        public Texture2D destinationTexture;
        public IEnumerator executor;
        public float startTime;
        public Material combineMaterial;
        public Material extractAlpha;
        public Texture2D inputTexture;
        public NNModel srcModel;     

        public bool IsJPG()
        {
            return false;
            //var normalizedExt = Path.GetExtension(destinationAssetPath).ToLower();
            //return normalizedExt == "jpg" || normalizedExt == "jpeg";
        }

        public bool IsPNG()
        {
            return false;
            //return Path.GetExtension(destinationAssetPath).ToLower() == "png";
        }
        
        public bool IsTGA()
        {
            // All our textures are TGA
            return true;
            //return Path.GetExtension(destinationAssetPath).ToLower() == "tga";
        }
        
        public void Cleanup()
        {
            input.Dispose(); 
            worker.Dispose();

            worker = null;
            model = null;
            input = null;
            destinationTexture = null;
            executor = null;
            inputTexture = null;
        }
    }
    
    public static Texture2D UpscaleTexture (Texture2D tex)
    {
        sContext.inputTexture = tex;

        // Budget needed for upscaling in MB
        long budget = 9600L * sContext.inputTexture.width * sContext.inputTexture.height *
                      (sContext.inputTexture.alphaIsTransparency ? 2 : 1) / 1024 / 1024;

        // Check if model will fit into video memory
        if (budget > SystemInfo.graphicsMemorySize)
        {
            if (!EditorUtility.DisplayDialog("Upscaling large image!",
                $"Upscaling process will use more video memory than your GPU has ({budget}MB > {SystemInfo.graphicsMemorySize}MB)." +
                "\nDo you want to continue?\nNote: transparent images take 2x of memory!",
                "Continue", "Cancel"))
                return null;
        }

        sContext.model = ModelLoader.Load(LocateModel(), false);
        sContext.worker = BarracudaWorkerFactory.CreateWorker(BarracudaWorkerFactory.Type.ComputePrecompiled, sContext.model, false);

        if (sContext.inputTexture.alphaIsTransparency)
            sContext.input = new Tensor(new Texture[] { sContext.inputTexture, ExtractAlpha(sContext.inputTexture) });
        else
            sContext.input = new Tensor(new Texture[] { sContext.inputTexture });

        Texture2D target = new Texture2D(tex.width, tex.height);

        sContext.startTime = Time.realtimeSinceStartup;
        sContext.destinationTexture = target;
        sContext.executor = sContext.worker.ExecuteAsync(sContext.input);

        return target;
    }

    private static TextureUpcalingContext sContext = new TextureUpcalingContext();

    static void FinishUpscale()
    {
        var output = sContext.worker.Peek();

        var outputCol = BarracudaTextureUtils.TensorToRenderTexture(output, 0);

        if (output.batch > 1)
        {
            var outputAlpha = BarracudaTextureUtils.TensorToRenderTexture(output, 1);
            var tempTexture = CombineTextures(outputCol, outputAlpha);
            outputCol = tempTexture; 
        }

        RenderTexture.active = outputCol;
        sContext.destinationTexture.ReadPixels(new Rect(0, 0, outputCol.width, outputCol.height), 0, 0);
        sContext.destinationTexture.Apply();

        var ts = Time.realtimeSinceStartup - sContext.startTime;
        Debug.Log($"Upscaling took: {ts}s");
        Debug.Log($"Memory usage summary: {sContext.worker.Summary()}");

        sContext.Cleanup(); 
    }

    static NNModel LocateModel()
    {
        if (sContext.srcModel == null)
        {
            string[] allCandidates = AssetDatabase.FindAssets("ESRGAN");
            foreach (var guid in allCandidates)
            {
                var path = AssetDatabase.GUIDToAssetPath(guid);
                if (path.ToLower().EndsWith(".nn"))
                {
                    sContext.srcModel = (NNModel)AssetDatabase.LoadAssetAtPath(path, typeof(NNModel));
                    break;
                }
            }
        }

        return sContext.srcModel;
    }
    
    static RenderTexture CombineTextures(Texture col, Texture alpha)
    {
        var tempTexture = RenderTexture.GetTemporary(col.width, col.height, 0, RenderTextureFormat.ARGB32);

        if (sContext.combineMaterial == null)
        {
            string[] allMaterials = AssetDatabase.FindAssets("t:Material");
            foreach (var matit in allMaterials)
            {
                var mat = AssetDatabase.GUIDToAssetPath(matit);
                if (mat.ToLower().EndsWith("combinetextures.mat"))
                {
                    sContext.combineMaterial = (Material)AssetDatabase.LoadAssetAtPath(mat, typeof(Material));
                }
            }
        }
        
        sContext.combineMaterial.SetTexture("_MainTex", col);
        sContext.combineMaterial.SetTexture("_AlphaTex", alpha);
        
        Graphics.Blit(col, tempTexture, sContext.combineMaterial);

        return tempTexture;
    }
    
    static RenderTexture ExtractAlpha(Texture tex)
    {
        var tempTexture = RenderTexture.GetTemporary(tex.width, tex.height, 0, RenderTextureFormat.ARGB32);

        if (sContext.extractAlpha == null)
        {
            string[] allMaterials = AssetDatabase.FindAssets("t:Material");
            foreach (var matit in allMaterials)
            {
                var mat = AssetDatabase.GUIDToAssetPath(matit);
                if (mat.ToLower().EndsWith("extractalpha.mat"))
                {
                    sContext.extractAlpha = (Material)AssetDatabase.LoadAssetAtPath(mat, typeof(Material));
                }
            }
        }
        
        Graphics.Blit(tex, tempTexture, sContext.extractAlpha);

        return tempTexture;
    }
}
