using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[SelectionBase]
[ExecuteInEditMode]
public class AuroraLayoutDoor : MonoBehaviour
{
    public AuroraDoorHook hook;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        hook.position = new Vector3(
            transform.position.x,
            transform.position.z,
            transform.position.y
        );

        hook.rotation = new Quaternion(
            -transform.rotation.x,
            -transform.rotation.z,
            -transform.rotation.y,
            transform.rotation.w
        );
    }
    public void Initialize(AuroraDoorHook hook)
    {
        this.hook = hook;

        gameObject.name = hook.name;
    }
}