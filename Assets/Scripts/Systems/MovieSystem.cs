using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using AuroraEngine;

public class MovieSystem : MonoBehaviour
{
    public Camera mainCamera, videoCamera;
    public VideoPlayer player;

    StateSystem stateManager;

    bool aNext = true;
    public bool playing = false;
    Queue<string> queue = new Queue<string>();

    bool debug = true;
    bool initialized = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void Initialize()
    {
        initialized = true;

        player.loopPointReached += NextMovie;
        stateManager = GameObject.Find("State System").GetComponent<StateSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!initialized)
        {
            return;
        }
        //if (!playing && queue.Count > 0)
        //{
        //    StartPlaying();
        //}
        stateManager.GetComponent<AudioSource>().enabled = !playing;
    }

    public void AddToQueue(string resref)
    {
        if (!debug)
        {
            queue.Enqueue(resref);
        }
    }

    public void PlayImmediate (string resref)
    {
        queue.Clear();
        AddToQueue(resref);
        StartPlaying();
    }

    public void StartPlaying ()
    {
        mainCamera.enabled = false;
        videoCamera.enabled = true;
        NextMovie(null);
    }

    VideoClip NextClip()
    {
        string resref = queue.Dequeue().ToLower().Replace("\"", "");
        VideoClip clip = AuroraEngine.Resources.LoadMovie(resref);
        if (clip == null)
        {
            throw new System.Exception("Clip was null!");
        }
        Debug.Log("Playing clip " + resref + " (" + clip.ToString() + ")");
        return clip;
    }

    void NextMovie (VideoPlayer vp)
    {
        if (queue.Count == 0)
        {
            playing = false;

            mainCamera.enabled = true;
            videoCamera.enabled = false;
        } else
        {
            if (player.isPlaying)
            {
                player.Stop();
            }

            playing = true;

            player.clip = NextClip();
            player.Play();
        }
    }
}
