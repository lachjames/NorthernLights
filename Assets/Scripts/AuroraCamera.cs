using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AuroraCamera : MonoBehaviour
{
    public bool isFollowing = false;
    
    public float fWait, maxLength, fLength;
    public Color target_color;

    public Image fade_img;

    bool is_fade_in;

    AuroraInput controls;

    // Start is called before the first frame update
    void Start()
    {
        fade_img.color = new Color(0, 0, 0, 0);

        controls = new AuroraInput();

        controls.Player.Enable();

        controls.Player.Move.performed += ctx => Move(ctx.ReadValue<Vector2>());
        controls.Player.Look.performed += ctx => Rotate(ctx.ReadValue<Vector2>());

        controls.Player.Move.canceled += ctx => Move(new Vector2(0, 0));
        controls.Player.Look.canceled += ctx => Rotate(new Vector2(0, 0));
    }

    // Update is called once per frame
    void Update()
    {
        fWait -= Time.deltaTime;
        if (fWait <= 0)
        {
            // No more waiting, time to fade out
            fLength -= Time.deltaTime;
            Color base_color = new Color(target_color.r, target_color.g, target_color.b, is_fade_in ? 0f : 1f);

            fade_img.color = Color.Lerp(base_color, target_color, fLength / maxLength);
        }

        if (isFollowing)
        {
            // Check for any horizontal movement using inputs
        }
    }

    void Move (Vector2 movement)
    {
        // Check if rotation is non-zero
    }

    void Rotate (Vector2 rot)
    {

    }

    internal void SetGlobalFadeIn(float fWait, float fLength, float fR, float fG, float fB)
    {
        this.fWait = fWait;
        this.maxLength = fLength;
        this.fLength = fLength;

        this.target_color = new Color(
            fR, fG, fB, 0f
        );

        this.is_fade_in = true;
    }

    internal void SetGlobalFadeOut(float fWait, float fLength, float fR, float fG, float fB)
    {
        this.fWait = fWait;
        this.maxLength = fLength;
        this.fLength = fLength;

        this.target_color = new Color(
            fR, fG, fB, 1f
        );

        this.is_fade_in = false;
    }
}
