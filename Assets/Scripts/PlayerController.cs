using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AuroraEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public AuroraInput controls;

    public StateSystem stateManager;
    GameObject model;

    Animation anim;

    CharacterController controller;
    Camera camera;

    public float moveSpeed = 3;
    public float rotSpeed = 3;

    Vector3 defaultPosition;
    Quaternion defaultOrientation;

    float rotV, rotH;
    float moveV, moveH;

    enum MoveType
    {

    }

    void Awake()
    {
        // Control action map
        controls = new AuroraInput();

        controls.Player.Enable();

        Debug.Log("Controls: " + controls);

        controls.Player.Move.performed += ctx => Move(ctx.ReadValue<Vector2>());
        controls.Player.Look.performed += ctx => Rotate(ctx.ReadValue<Vector2>());

        controls.Player.Move.canceled += ctx => Move(new Vector2(0, 0));
        controls.Player.Look.canceled += ctx => Rotate(new Vector2(0, 0));

        camera = GetComponentInChildren<Camera>();
        defaultPosition = camera.transform.localPosition;
        defaultOrientation = camera.transform.localRotation;
        stateManager = GameObject.Find("State System").GetComponent<StateSystem>();
    }
    // Source: https://forum.unity.com/threads/change-gameobject-layer-at-run-time-wont-apply-to-child.10091/
    void SetLayerRecursively(GameObject obj, int newLayer)
    {
        if (null == obj)
        {
            return;
        }

        obj.layer = newLayer;

        foreach (Transform child in obj.transform)
        {
            if (null == child)
            {
                continue;
            }
            SetLayerRecursively(child.gameObject, newLayer);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // Load the model for the PC
        model = AuroraEngine.Resources.LoadModel("pmbbl");
        AuroraEngine.Resources.LoadModel("n_traskh", null, model);
        model.transform.parent = transform;
        model.transform.localPosition = Vector3.zero;
        model.transform.localRotation = Quaternion.identity;

        SetLayerRecursively(model, LayerMask.NameToLayer("PC"));

        anim = model.GetComponent<Animation>();
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        camera.transform.localPosition = defaultPosition;
        camera.transform.localRotation = defaultOrientation;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //camera.transform.RotateAround(transform.position, transform.up, rotSpeed * Time.deltaTime * rotH);
        // We only rotate around the y-axis
        transform.rotation = Quaternion.Euler(
            0f, //transform.rotation.eulerAngles.x,
            transform.rotation.eulerAngles.y + rotSpeed * Time.deltaTime * moveH,
            0f //transform.rotation.eulerAngles.z
        );
        controller.SimpleMove(
            moveSpeed * moveV * transform.forward
            //moveSpeed * moveH * transform.right            
        );

        anim.wrapMode = WrapMode.Loop;

        if (moveV != 0)
        {
            if (moveV > 0.5f)
            {
                anim.CrossFade("run");
            } else if (moveV < 0)
            {
                //anim.CrossFade("back");
                // Moving backwards
            } else
            {
                anim.CrossFade("walk");
            }
        } else
        {
            anim.CrossFade("neutral");
        }
    }

    void Rotate (Vector2 rotation)
    {
        rotH = rotation.x;
        rotV = rotation.y;
    }

    void Move(Vector2 direction)
    {
        moveV = direction.y;
        moveH = direction.x;
    }
}
