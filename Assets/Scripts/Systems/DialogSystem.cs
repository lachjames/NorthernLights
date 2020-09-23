using AuroraEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class DialogSystem : MonoBehaviour
{
    public enum DialogMode
    {
        NPC, PC, START, FINISHED
    }

    public Dictionary<int, string> tokens = new Dictionary<int, string>();

    public bool debug = false;
    bool paused = false;

    public AuroraDLG dialogue;
    public AuroraDLG.AEntry curEntry;
    public AuroraDLG.AReply curReply;

    public AudioSource audioSource;

    public float fontFactor = 1f;
    public float topHeight = 0.15f;
    public float bottomHeight = 0.3f;
    
    public string resref = "end_trask01";

    public List<AuroraDLG.AEntry.AReplies> replies = new List<AuroraDLG.AEntry.AReplies>();
    public string lastLine;

    public DialogMode curMode;

    public float timer = 0;

    StateSystem stateManager;

    AuroraObject owner;

    GameObject cameraModel;

    Vector3 priorCamPos;
    Quaternion priorCamRot;

    bool initialized = false;

    private void Awake()
    {
    }

    // Start is called before the first frame update
    void Start()
    {
    }


    public void Initialize()
    {
        initialized = true;

        stateManager = GameObject.Find("State System").GetComponent<StateSystem>();
        curMode = DialogMode.FINISHED;

        priorCamPos = Camera.main.transform.localPosition;
        priorCamRot = Camera.main.transform.localRotation;
    }

    private void OnGUI()
    {
        if (!initialized)
        {
            return;
        }
        if (paused)
        {
            return;
        }

        if (curMode == DialogMode.FINISHED)
        {
            return;
        }
        // Set the KotOR-like GUI style
        GUI.skin.button.fontSize = (int)(fontFactor * (Screen.height / 128));
        GUI.skin.button.normal.textColor = new Color32(0x00, 0xA4, 0xF4, 0xFF);
        GUI.skin.button.hover.textColor = new Color32(0xF4, 0xF9, 0x00, 0xFF);
        GUI.skin.button.wordWrap = true;

        GUI.skin.label.fontSize = (int)(fontFactor * (Screen.height / 128));
        GUI.skin.label.normal.textColor = new Color32(0x00, 0xA4, 0xF4, 0xFF);
        GUI.skin.label.hover.textColor = new Color32(0xF4, 0xF9, 0x00, 0xFF);
        GUI.skin.label.wordWrap = true;

        GUI.skin.label.alignment = TextAnchor.MiddleCenter;
        //GUI.skin.box.padding = new RectOffset(0, 0, 0, 0);

        using (new GUILayout.VerticalScope("", GUILayout.Height(Screen.height), GUILayout.Width(Screen.width)))
        {
            // Top bar
            using (new GUILayout.VerticalScope("box", GUILayout.Height(Screen.height * topHeight), GUILayout.Width(Screen.width)))
            {
                if (curMode == DialogMode.NPC)
                {
                    GUI.skin.button.alignment = TextAnchor.MiddleCenter;

                    GUILayout.Label("");
                } else
                {
                    GUI.skin.button.alignment = TextAnchor.MiddleLeft;

                    GUILayout.Label(lastLine, GUILayout.Width(Screen.width));
                }
            }

            // Space
            GUILayout.Space(Screen.height * (1 - topHeight - bottomHeight));

            // Bottom bar
            using (new GUILayout.VerticalScope("box", GUILayout.Height(Screen.height * bottomHeight), GUILayout.Width(Screen.width)))
            {
                if (curMode == DialogMode.NPC)
                {
                    int strref = -1;
                    // This should show the current NPC line
                    string txt = AuroraEngine.Resources.GetString(curEntry.Text);
                    lastLine = txt;
                    if (GUILayout.Button(txt, GUILayout.Width(Screen.width)))
                    {
                        MoveFromEntry();
                    }
                } else
                {
                    int i = 0;
                    foreach (AuroraDLG.AEntry.AReplies rply in replies)
                    {
                        string txt = AuroraEngine.Resources.GetString(dialogue.ReplyList[(int)rply.Index].Text);
                        if (GUILayout.Button(txt, GUILayout.Width(Screen.width)))
                        {
                            MoveFromReply(i);
                        }
                        i++;
                    }
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!initialized)
        {
            return;
        }
        PointCamera();

        if (curMode == DialogMode.FINISHED)
        {
            return;
        }

        timer -= Time.deltaTime;
        if (timer <= 0 && curMode == DialogMode.NPC)
        {
            timer = 0;
            // Play the next line automatically
            if (!debug)
            {
                MoveFromEntry();
            }
        }
    }

    void PointCamera ()
    {
        if (curMode == DialogMode.PC)
        {
            // Make the camera point at the PC
            // Focus on the speaker
            GameObject pc = stateManager.PC.gameObject;

            // Calculate a camera position in front of the speaker, facing them
            Camera.main.transform.position = pc.transform.position + pc.transform.forward * 0.5f + pc.transform.up * 1.6f;
            Camera.main.transform.rotation = Quaternion.LookRotation(
                pc.transform.forward * -0.5f,
                pc.transform.up
            );
        }
        else if (curMode == DialogMode.NPC)
        {
            // Play the current camera animation, if there is one
            // Use the default camera pointing via camera angle
            GameObject speaker, listener;
            Vector3 cameraPosition = Camera.main.transform.position;
            Quaternion cameraRotation = Camera.main.transform.rotation;

            if (curEntry.Speaker == "")
            {
                // Speaker is the current owner
                speaker = owner.gameObject;
            }
            else
            {
                speaker = stateManager.GetObjectByTag(curEntry.Speaker).gameObject;
            }

            // TODO: Support other listeners, will be important in K2?
            listener = stateManager.PC.gameObject;
            

            switch (curEntry.CameraAngle)
            {
                case 0:
                case 1:
                    // Focus on the speaker
                    // Calculate a camera position in front of the speaker, facing them
                    cameraPosition = speaker.transform.position + 
                        speaker.transform.forward * 0.5f + 
                        speaker.transform.up * 1.5f;
                    cameraRotation = Quaternion.LookRotation(speaker.transform.forward * -0.5f, speaker.transform.up);
                    break;
                case 2:
                    Vector3 delta = listener.transform.position - speaker.transform.position;
                    // Behind the listener, facing the speaker
                    cameraPosition = listener.transform.position +
                        listener.transform.forward * -1f +
                        speaker.transform.up * 1.5f;
                    cameraRotation = Quaternion.LookRotation(delta, speaker.transform.up);
                    break;
                case 3:
                case 5:
                case 6:
                    cameraPosition = speaker.transform.position +
                        speaker.transform.forward * 2.5f +
                        speaker.transform.up * 1.5f;
                    cameraRotation = Quaternion.LookRotation(speaker.transform.forward * -2.5f, speaker.transform.up);
                    break;
                case 4:
                    // Animated camera
                    AnimationState selectedClip = GetAnimationState();

                    Animation animator = cameraModel.GetComponent<Animation>();
                    if (selectedClip != null)
                    {
                        // Play the selected clip
                        animator.Play(selectedClip.name);
                    }

                    // Bind the camera transform to the camera model transform
                    Transform cameraPos = null;
                    foreach (Transform t in cameraModel.transform)
                    {
                        if (t.name == "camerahook")
                        {
                            cameraPos = t;
                            break;
                        }
                    }

                    Camera.main.transform.localPosition = priorCamPos;
                    Camera.main.transform.localRotation = priorCamRot;

                    if (cameraPos != null)
                    {
                        cameraPosition = cameraPos.transform.position;
                        cameraRotation = Quaternion.Euler(
                            cameraPos.transform.rotation.eulerAngles +
                            new Vector3(90, 0, 0)
                        );
                    }
                    break;
                //case 5:
                //    // Focus on listener (is broken in original game)
                //    break;
                //case 6:
                //    // Module-specific static camera
                //    break;
                default:
                    // In this case, "break" is used literally
                    break;
            }


            Camera.main.transform.position = cameraPosition;
            Camera.main.transform.rotation = cameraRotation;

            // Play animations for the current entry
            foreach (AuroraDLG.AEntry.AAnim anim in curEntry.AnimList)
            {
                string participant = anim.Participant;

                Debug.Log("Triggering dialog animation for " + participant);

                int animID = (int)anim.Animation;

                AuroraObject target = null;
                if (participant == "PLAYER")
                {
                    target = stateManager.PC;
                }
                else if (participant == null)
                {
                    // Not sure what to do here?
                }
                else
                {
                    target = stateManager.GetObjectByTag(participant);
                }

                if (target != null)
                {
                    target.PlayAnimation(animID);
                }
                else
                {
                    Debug.Log("Could not find target " + participant);
                }
            }
        }
    }

    public void ForceCut (GameObject camera)
    {
        cameraModel = camera;
    }

    AnimationState GetAnimationState ()
    {
        Animation animator = cameraModel.GetComponent<Animation>();

        int animation = curEntry.CameraAnimation - 1200;
        int i = 0;
        AnimationState selectedClip = null;
        foreach (AnimationState clip in animator)
        {
            if (i == animation)
            {
                selectedClip = clip;
                break;
            }
            i++;
        }
        return selectedClip;
    }

    public void StartDialog(string resref, AuroraObject owner)
    {
        AuroraDLG dlg = AuroraEngine.Resources.LoadDialogue(resref);
        Debug.Log(dlg);

        // Create the camera model if one exists for this dialog
        if (dlg.CameraModel != null && dlg.CameraModel != "")
        {
            if (cameraModel != null)
            {
                GameObject.Destroy(cameraModel);
            }
            cameraModel = AuroraEngine.Resources.LoadModel(dlg.CameraModel);
        }

        StartDialog(dlg, owner);
    }

    void StartDialog(AuroraDLG dlg, AuroraObject owner)
    {
        // TODO: Find the appropriate starting point by running
        // the relevant NCS scripts
        dialogue = dlg;

        if (owner.GetType() == typeof(Creature))
        {
            ((Creature)owner).OnDialogue();
        }

        // AuroraDLG.AStarting starter = dlg.StartingList[0];

        AuroraDLG.AStarting starter = null;
        foreach (AuroraDLG.AStarting option in dlg.StartingList)
        {
            string scriptName = option.Active;
            if (scriptName == "")
            {
                starter = option;
                break;
            }
            if (stateManager.RunConditionalScript(scriptName, owner) > 0)
            {
                starter = option;
                break;
            }
        }

        if (starter == null)
        {
            // Could not find a starter
            throw new System.Exception("Failed to find a successful starting option for dialog");
        }

        AuroraDLG.AEntry startEntry = dlg.EntryList[(int)starter.Index];

        Debug.Log("Start entry: " + startEntry);

        curEntry = startEntry;

        if (curEntry.Script != "")
        {
            stateManager.RunScript(curEntry.Script, owner);
        }

        curMode = DialogMode.NPC;

        this.owner = owner;
    }

    public void EndDialog ()
    {
        if (curMode == DialogMode.FINISHED)
        {
            return;
        }

        curMode = DialogMode.FINISHED;

        // Call any scripts that should run when the dialog finishes
        Debug.Log(stateManager);
        Debug.Log(dialogue.EndConversation);
        stateManager.RunScript(dialogue.EndConversation, owner);
        if (owner.GetType() == typeof(Creature))
        {
            ((Creature)owner).OnEndDialogue();
        }
    }

    public void PauseDialog ()
    {
        paused = true;
    }

    public void ResumeDialog ()
    {
        paused = false;
    }

    public void AbortDialog ()
    {
        if (curMode == DialogMode.FINISHED)
        {
            return;
        }

        // Not sure if this is ever used, but will implement it anyway
        curMode = DialogMode.FINISHED;

        stateManager.RunScript(dialogue.EndConverAbort, owner);
        if (owner.GetType() == typeof(Creature))
        {
            ((Creature)owner).OnEndDialogue();
        }
    }

    void MoveFromEntry ()
    {
        // TODO: Not convinced by this...
        if (curEntry == null)
        {
            EndDialog();
            return;
        }

        if (curEntry.RepliesList.Count == 0)
        {
            // Dialog is finished
            EndDialog();
            return;
        }

        curMode = DialogMode.PC;
            
        // Get the options for the PC to choose
        replies.Clear();

        foreach (AuroraDLG.AEntry.AReplies rply in curEntry.RepliesList)
        {
            if (rply.Active == "")
            {
                replies.Add(rply);
                continue;
            }

            NCSScript rplyScript = AuroraEngine.Resources.LoadScript(rply.Active);
            if (rplyScript.RunConditional(new NCSContext()) > 0)
            {
                replies.Add(rply);
            }
        }

        if (replies.Count != 1)
        {
            return;
        }
        string txt = AuroraEngine.Resources.GetString(dialogue.ReplyList[(int)replies[0].Index].Text);
        if (txt != "")
        {
            return;
        }
        MoveFromReply(0);
    }

    void MoveFromReply(int idx) 
    {
        curReply = dialogue.ReplyList[(int)replies[idx].Index];
        Debug.Log((int)replies[idx].Index);
        //Debug.Log(curReply.id);

        if (curReply.Script != null && curReply.Script != "")
        {
            stateManager.RunScript(curReply.Script, stateManager.PC);
        }

        if (curReply.EntriesList.Count == 0)
        {
            // Dialog is finished
            EndDialog();
            return;
        }

        curMode = DialogMode.NPC;

        // Get the next line of NPC dialog
        // TODO: Use conditional logic here by calling NCS scripts
        foreach (AuroraDLG.AReply.AEntries rply in curReply.EntriesList)
        {
            if (rply.Active == "")
            {
                curEntry = dialogue.EntryList[(int)rply.Index];
                break;
            }

            NCSScript script = AuroraEngine.Resources.LoadScript(rply.Active);
            int value = script.RunConditional(new NCSContext());

            if (value > 0)
            {
                curEntry = dialogue.EntryList[(int)rply.Index];
                break;
            }
            else {
                Debug.Log("Conditional " + curEntry.Script + " failed");
            }
        }

        // Load the audio
        AudioClip audio = GetAudioClip();
        //LIP lipsync = AuroraEngine.Resources.LoadLipSync(curEntry.VO_ResRef);
        //if (lipsync != null)
        //{
        //    Debug.Log("Lip sync has length " + lipsync.length + " and " + lipsync.frames.Length + " frames");
        //}

        if (audio != null)
        {
            Debug.Log("Found audio");
            audioSource.clip = audio;
            audioSource.Play();

            timer = audio.length;
        } else
        {
            Debug.Log("Did not find audio");
            timer = 0;
        }

        if (timer == 0 && curEntry.CameraAnimation > 0)
        {
            timer = GetAnimationState().length;
        }

        if (curEntry.Delay > 0 && curEntry.Delay < 100000)
        {
            timer = curEntry.Delay;
        }

        // Run the on-play script for the current line being played
        if (curEntry.Script != "")
        {
            // TODO: Check who is the owner of the script when it's run through RuNScript
            stateManager.RunScript(curEntry.Script, stateManager.PC);
        }
    }

    AudioClip GetAudioClip ()
    {
        // If curEntry.Sound exists, we always return that
        AudioClip sound = AuroraEngine.Resources.LoadVO(curEntry.Sound, (int)curEntry.Text.stringref);

        if (sound != null)
        {
            return sound;
        }

        // If curEntry.Sound doesn't exist, we need to load the VO 

        return null;
    }

    public void SetCustomToken(int nCustomTokenNumber, string sTokenValue)
    {
        tokens[nCustomTokenNumber] = sTokenValue;
    }
}
