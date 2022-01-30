// using System.Collections;
// using System.Collections.Generic;
// using System.Diagnostics;
// using UnityEngine;

// public class NCSBenchmark : MonoBehaviour
// {
//     public int LIMIT = 10000;
//     public float fps = 60f;

//     int ipf = 0;

//     float smoothed = 0;
//     float factor = 0.1f;

//     string benchmark = @"
// _start:
//   JSR main
//   RETN

// main: ; void main()
//   RSADDI
//   CONSTI 0
//   CPDOWNSP -8 4
//   MOVSP -4
// loc_0000002B:
//   CONSTI 1
//   JZ loc_00000051
//   CPTOPSP -4 4
//   INCSPI -8
//   MOVSP -4
//   JMP loc_0000002B

// loc_00000051:
//   MOVSP -4
//   RETN";
//     // Start is called before the first frame update
//     void Start()
//     {
        
//     }

//     // Update is called once per frame
//     void Update()
//     {
//         Stopwatch watch = new Stopwatch();

//         ipf = 0;
//         watch.Start();
//         while (true)
//         {
//             if (watch.ElapsedMilliseconds > (1 / fps) * 1000)
//             {
//                 break;
//             }
//             NCSScript script = new NCSScript(benchmark, "benchmark");
//             //script.Step(ctx);
//             ipf++;
//         }
//     }

//     void OnGUI ()
//     {
//         GUIStyle style = new GUIStyle();
//         style.fontSize = 32;
//         style.normal.textColor = Color.black;

//         GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 20, 200, 40), "Instructions per second: " + Smooth(ipf * fps).ToString(), style);        
//     }

//     float Smooth (float f)
//     {
//         smoothed = (1 - factor) * smoothed + factor * f;
//         return smoothed;
//     }
// }
