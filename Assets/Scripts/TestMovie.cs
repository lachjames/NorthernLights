using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AuroraEngine;
using UnityEngine.Video;

public class TestMovie : MonoBehaviour
{
    public string MovieName = "01a";
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("Movie System").GetComponent<MovieSystem>().AddToQueue("07_1");
        GameObject.Find("Movie System").GetComponent<MovieSystem>().AddToQueue("07_4");
        GameObject.Find("Movie System").GetComponent<MovieSystem>().AddToQueue("07_2");

        GameObject.Find("Movie System").GetComponent<MovieSystem>().StartPlaying();
    }
}
