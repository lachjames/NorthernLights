using AuroraEngine;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using UnityEditor;
using UnityEngine;

public class ModelExplorer : EditorWindow
{
    string mdlLocation, mdxLocation;
    
    public MDL mdlObj;
    Vector2 scroll;

    Stopwatch loadTimer, instantiateTimer;

    [MenuItem("Window/Aurora/Model Explorer")]
    public static void ShowWindow ()
    {
        EditorWindow.GetWindow(typeof(ModelExplorer));
    }

    public void OnGUI()
    {
        using (new EditorGUILayout.VerticalScope())
        {
            mdlLocation = EditorGUILayout.TextField("MDL Location", mdlLocation);
            mdxLocation = EditorGUILayout.TextField("MDX Location", mdxLocation);
            if (GUILayout.Button("Load"))
            {
                using (Stream mdlStream = File.OpenRead(mdlLocation))
                using (Stream mdxStream = File.OpenRead(mdxLocation))
                {
                    AuroraModel auroraModel = new AuroraModel(mdlStream, mdxStream, Game.KotOR);
                    mdlObj = auroraModel.mdlObject;
                }
            }
            if (GUILayout.Button("Instantiate"))
            {
                using (Stream mdlStream = File.OpenRead(mdlLocation))
                using (Stream mdxStream = File.OpenRead(mdxLocation))
                {
                    // Create an instance
                    GameObject model = AuroraEngine.Resources.LoadModel(mdlStream, mdxStream, new Dictionary<string, GameObject>(), Vector3.zero, null, null, null);
                }
            }

            if (GUILayout.Button("Benchmark Load"))
            {
                BenchmarkLoad();
            }

            if (GUILayout.Button("Benchmark Instantiate"))
            {
                BenchmarkInstantiate();
            }

            if (loadTimer != null)
                GUILayout.Label("Loading: " + loadTimer.Elapsed.ToString());
    
            if (instantiateTimer != null)
                GUILayout.Label("Instantiation: " + instantiateTimer.Elapsed.ToString());

            if (loadTimer != null && instantiateTimer != null)
            {
                GUILayout.Label("Loading takes " + loadTimer.Elapsed.TotalSeconds / instantiateTimer.Elapsed.TotalSeconds);
            }

            //using (var scope = new EditorGUILayout.ScrollViewScope(scroll, "box"))
            //{
            //    scroll = scope.scrollPosition;

            //    if (mdlObj != null)
            //    {
            //        // Show the MDL object's information
            //        ShowMDL();
            //    }
            //}
        }
    }

    void BenchmarkLoad()
    {
        loadTimer = new Stopwatch();
        loadTimer.Start();

        using (Stream mdlStream = File.OpenRead(mdlLocation))
        using (Stream mdxStream = File.OpenRead(mdxLocation))
        {
            AuroraModel auroraModel = new AuroraModel(mdlStream, mdxStream, Game.KotOR);
            mdlObj = auroraModel.mdlObject;
        }

        loadTimer.Stop();
    }
    void BenchmarkInstantiate()
    {
        instantiateTimer = new Stopwatch();
        instantiateTimer.Start();

        using (Stream mdlStream = File.OpenRead(mdlLocation))
        using (Stream mdxStream = File.OpenRead(mdxLocation))
        {
            // Create an instance
            GameObject model = AuroraEngine.Resources.LoadModel(mdlStream, mdxStream, new Dictionary<string, GameObject>(), Vector3.zero, null, null, null);
        }

        instantiateTimer.Stop();
    }

    void ShowMDL ()
    {
        // Show general information
        using (new EditorGUILayout.VerticalScope("box"))
        {
            GUILayout.Label("General information");
            List<MDLNode> nodes = GetNodes(mdlObj.rootNode);
            if (mdlObj.rootNode != null)
            {
                GUILayout.Label("Nodes: " + nodes.Count);
            }

            GUILayout.Label("Animation data");

            DrawAnimations();

            GUILayout.Label(mdlObj.animations.Length.ToString());

            DrawNode(mdlObj.rootNode);
        }
    }

    void DrawAnimations ()
    {
        using (new EditorGUILayout.VerticalScope("box"))
        {
            if (mdlObj.animations == null)
            {
                return;
            }
            foreach (AnimationNode anim in mdlObj.animations)
            {
                GUILayout.Label(
                    anim.animationHeader.animationLength +
                    "s + (" + anim.animationHeader.events.Length + ") events; " +
                    anim.rootNode.nodeHeader.controllers.Length + " controllers;" +
                    GetNodes(anim.rootNode).Count + " nodes"
                );
            }
        }
    }

    void DrawNode (MDLNode node)
    {
        using (new EditorGUILayout.VerticalScope("box"))
        {
            int node_idx = node.nodeHeader.nodeNumber;
            string node_name = mdlObj.nameHeader.names[node_idx].name;
            GUILayout.Label("Node " + node_name);
            if (node.vertices != null)
            {
                GUILayout.Label("  - Vertices: " + node.vertices.Length);
                GUILayout.Label("  - TVertices: " + node.tVertices.Length);
                //GUILayout.Label("  - Faces: " + node.trimeshHeader.faces.Length);
            }
            foreach (MDLNode child in node.childNodes)
            {
                DrawNode(child);
            }
        }
    }

    List<MDLNode> GetNodes (MDLNode obj) {
        if (obj == null)
        {
            return new List<MDLNode>();
        }

        List<MDLNode> nodes = new List<MDLNode>();

        // Add the current node
        nodes.Add(obj);

        // Add all child nodes
        foreach (MDLNode n in obj.childNodes)
        {
            nodes.AddRange(GetNodes(n));
        }

        return nodes;
    }

    public void LoadGFF (string loc)
    {
        
    }
}
