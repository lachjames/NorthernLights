using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AISystem : MonoBehaviour
{
    public LayerMask navMeshMask;
    public NavMeshSurface surface;

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

    public void BakeNavMesh ()
    {
        surface.BuildNavMesh();
    }
}
