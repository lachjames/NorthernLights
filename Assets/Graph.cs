using Microsoft.Msagl.GraphViewerGdi;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class Graph<T>
{
    // Constructs a graph of objects of type T
    List<T> nodes = new List<T>();
    Dictionary<T, List<T>> edges = new Dictionary<T, List<T>>();
    T root;

    public Graph()
    {

    }

    public void SetRoot(T root)
    {
        this.root = root;
    }

    public T GetRoot()
    {
        return root;
    }

    public void AddNode(T value)
    {
        nodes.Add(value);
        edges[value] = new List<T>();
    }

    public void AddEdge(T from, T to)
    {
        edges[from].Add(to);
    }

    public IEnumerable<T> DepthFirstTraversal()
    {
        HashSet<T> pushed = new HashSet<T>();
        Stack<T> stack = new Stack<T>();

        stack.Push(root);

        while (stack.Count > 0)
        {
            T cur = stack.Pop();
            yield return cur;

            // Push any connections if they have not been pushed before
            foreach (T conn in edges[cur])
            {
                if (pushed.Contains(conn))
                {
                    continue;
                }
                pushed.Add(conn);
                stack.Push(conn);
            }
        }
    }

    public IEnumerable<T> ReversePostOrderTraversal()
    {
        yield return default;
    }

    public Texture2D Visualise(int w = 1024, int h = 1024)
    {
        Microsoft.Msagl.Drawing.Graph graph = new Microsoft.Msagl.Drawing.Graph("graph");
        foreach (T node in nodes)
        {
            foreach (T conn in edges[node])
            {
                graph.AddEdge(node.ToString(), conn.ToString());
            }
        }

        GraphRenderer renderer = new GraphRenderer(graph);
        renderer.CalculateLayout();

        // Thanks to https://gamedev.stackexchange.com/questions/133372/system-drawing-dll-not-found
        // for showing how to use System.Drawing in Unity!
        Texture2D tex = new Texture2D(w, h);

        // CRITICAL: Must place System.Drawing.dll back in Assets folder
        //           for this code to work! Currently removed as it causes
        //           Unity to crash (I think during recompilation).

        //Bitmap bitmap = new Bitmap(w, h);
        //renderer.Render(bitmap);

        //// Convert the bitmap to a Unity Texture2D
        //for (int i = 0; i < w; i++)
        //{
        //    for (int j = 0; j < h; j++)
        //    {
        //        System.Drawing.Color col = bitmap.GetPixel(i, j);
        //        tex.SetPixel(i, (h - 1) - j, new UnityEngine.Color(col.R, col.B, col.G, col.A));
        //    }
        //}
        //tex.Apply();
        return tex;
    }
}