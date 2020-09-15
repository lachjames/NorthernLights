using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicSystem : MonoBehaviour
{
    // Start is called before the first frame update
    bool initialized = false;

    // Start is called before the first frame update
    public void Initialize()
    {
        initialized = true;
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!initialized)
        {
            return;
        }
    }

    public void StopBackgroundMusic ()
    {

    }

    public void StartBackgroundMusic (string resref)
    {

    }
}
