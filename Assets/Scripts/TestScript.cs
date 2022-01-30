using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AuroraEngine;

public class TestScript : MonoBehaviour
{
    public int Speed = 10;
    public string ScriptName = "a_move_pl";

    Vector2 stackScroll, instScroll;
    bool running;

    NCSScript script;
    NCSContext context;
    // Start is called before the first frame update
    void Start()
    {
        script = AuroraEngine.Resources.LoadScript(ScriptName);
        context = new NCSContext(script, script.file);
    }

    private void OnGUI()
    {
        using (new GUILayout.VerticalScope("box"))
        {
            using (new GUILayout.HorizontalScope("box"))
            {
                // Stack visualization
                using (var stackScope = new GUILayout.ScrollViewScope(stackScroll, "box", GUILayout.Width(Screen.width / 3), GUILayout.Height(2 * Screen.height / 3)))
                {
                    stackScroll = stackScope.scrollPosition;
                    for (int i = 0; i < context.stack.Count; i++)
                    {
                        if (context.stack[i] == null)
                        {
                            GUILayout.Label("NULL");
                        } else
                        {
                            GUILayout.Label(context.stack[i].ToString());
                        }
                    }
                }

                // Instruction visualization
                using (var instScope = new GUILayout.ScrollViewScope(instScroll, "box", GUILayout.Width(Screen.width / 3), GUILayout.Height(2 * Screen.height / 3)))
                {
                    instScroll = instScope.scrollPosition;
                    for (int i = 0; i < script.instructions.Count; i++)
                    {
                        GUILayout.Label(i + ": " + script.instructions[i].ToString());
                    }
                }
            }

            using (new GUILayout.HorizontalScope("box"))
            {
                if (GUILayout.Button(">", GUILayout.Width(50), GUILayout.Height(50)))
                    script.Step(context);

                if (GUILayout.Button(">>", GUILayout.Width(50), GUILayout.Height(50)))
                    running = !running;

                if (GUILayout.Button("<<", GUILayout.Width(50), GUILayout.Height(50)))
                {
                    context = new NCSContext(script, script.file);
                    script.lastInstruction = null;
                }
                if (script.lastInstruction != null)
                    GUILayout.Label("Last instruction (" + context.programCounter + "): " + script.lastInstruction.ToString());
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < Speed; i++)
        {
            if (running && !context.Finished())
            {
                Debug.Log(context.programCounter + ": " + script.instructions[context.programCounter]);
                try
                {
                    script.Step(context);
                } catch
                {
                    running = false;
                    break;
                }
            }
            else
            {
                running = false;
                break;
            }
        }
    }
}
