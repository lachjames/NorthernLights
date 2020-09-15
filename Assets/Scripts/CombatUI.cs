using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatUI : MonoBehaviour
{
    public AuroraEngine.Creature current, party1, party2;

    public float outerRadius = 0.8f, innerRadius = 0.6f;
    public float alpha = 0.2f;

    public Texture2D[] buttonTextures;

    public Texture2D[] lIcons;
    public Texture2D[] rIcons;
    public Texture2D[] lrIcons;
    public int numIcons = 12; // Default to a clock-like structure
    public float iconSize = 0.15f;

    Texture2D overlayTexture;
    UIMode uiMode;
    int selected;

    Dictionary<Button, (UIMode, int)> mappings = new Dictionary<Button, (UIMode, int)>();
    Dictionary<Button, KeyCode> inputs = new Dictionary<Button, KeyCode>()
    {
        { Button.A, KeyCode.JoystickButton0 },
        { Button.B, KeyCode.JoystickButton1 },
        { Button.X, KeyCode.JoystickButton2 },
        { Button.Y, KeyCode.JoystickButton3 },
    };
    public enum Button
    {
        X, Y, A, B, RT, LT
    }
    
    public class Ability
    {
        
    }

    enum UIMode
    {
        NONE, LEFT_OVERLAY, RIGHT_OVERLAY, BOTH_OVERLAY
    }

    // Start is called before the first frame update
    void Start()
    {
        overlayTexture = CreateUI();

        // Upscale the textures
        for (int i = 0; i < numIcons; i++)
        {
            if (lIcons[i] != null)
            {
                lIcons[i] = Scale(lIcons[i], 4);
            }
            if (rIcons[i] != null)
            {
                rIcons[i] = Scale(rIcons[i], 4);
            }
            if (lrIcons[i] != null)
            {
                lrIcons[i] = Scale(lrIcons[i], 4);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Control the three different tabs
        bool lb = false, rb = false;
        // LB
        if (Input.GetKey(KeyCode.Joystick1Button4))
        {
            lb = true;
        }
        // RB
        if (Input.GetKey(KeyCode.Joystick1Button5))
        {
            rb = true;
        }

        if (lb && !rb)
        {
            uiMode = UIMode.LEFT_OVERLAY;
        } else if (!lb && rb) {
            uiMode = UIMode.RIGHT_OVERLAY;
        } else if (lb && rb)
        {
            uiMode = UIMode.BOTH_OVERLAY;
        } else
        {
            uiMode = UIMode.NONE;
        }

        RenderHUD();

        if (uiMode == UIMode.NONE)
        {
            // We're in combat
            StandardCombat();
            return;
        } else
        {
            AbilityWheel();
        }
    }

    void OnGUI()
    {
        switch (uiMode)
        {
            case UIMode.NONE:
                // Render nothing
                break;
            case UIMode.LEFT_OVERLAY:
                RenderWheel(lIcons);
                break;
            case UIMode.RIGHT_OVERLAY:
                RenderWheel(rIcons);
                break;
            case UIMode.BOTH_OVERLAY:
                RenderWheel(lrIcons);
                break;
        }
    }

    void RenderHUD ()
    {
        // Render current player information

        // Render party member information
        // Party member 1

        // Party member 2

    }

    void RenderPartyMember ()
    {
        // Draw the portrait
        // Draw the health bar
        // Draw the force bar (if applicable)
    }

    void StandardCombat ()
    {

    }

    void AbilityWheel ()
    {
        // Read the right analog stick
        float vertical = Input.GetAxisRaw("Vertical");
        float horizontal = -Input.GetAxisRaw("Horizontal");

        float angleDegrees = Mathf.Rad2Deg * Mathf.Atan2(vertical, horizontal) - 90 + (360 / numIcons / 2);
        if (angleDegrees < 0)
        {
            angleDegrees += 360;
        }
        selected = (int)((angleDegrees / 360 * numIcons) % numIcons);

        // Check for mappings
        foreach (Button b in Enum.GetValues(typeof(Button)))
        {
            if (Input.GetKeyDown(inputs[b]))
            {
                mappings[b] = (uiMode, selected);
            }
        }
    }

    Texture2D Scale(Texture2D source, float factor = 4)
    {
        Texture2D uncompressed = new Texture2D(source.width, source.height, TextureFormat.ARGB32, false);

        uncompressed.SetPixels(source.GetPixels());
        uncompressed.Apply();

        TextureScale.Bilinear(
            uncompressed,
            (int)(uncompressed.width * factor),
            (int)(uncompressed.height * factor)
        );

        return uncompressed;
    }

    void RenderWheel (Texture2D[] icons)
    {
        // Draw the overlay texture
        GUI.Label(new Rect(0, 0, Screen.width, Screen.height), overlayTexture);

        // Draw the icons
        float radius = Screen.height / 2 * (outerRadius + innerRadius) / 2;
        float iconRadius = 1.5f * radius * iconSize;
        for (int i = 0; i < numIcons; i++)
        {
            if (!icons[i])
            {
                continue;
            }

            // Find the position of the icon
            float angle = i * (2 * Mathf.PI / numIcons) - (Mathf.PI / 2);
            float wOffset = Mathf.Cos(angle) * radius;
            float hOffset = Mathf.Sin(angle) * radius;

            float factor = selected == i ? 1.25f : 1f;

            GUI.DrawTexture(new Rect(
                Screen.width / 2 + wOffset - iconRadius * factor,
                Screen.height / 2 + hOffset - iconRadius * factor,
                iconRadius * 2 * factor,
                iconRadius * 2 * factor
            ), icons[i], ScaleMode.ScaleToFit);

            // Check if this ability is mapped; if so, draw the ability icon too
            foreach (Button b in mappings.Keys)
            {
                if (!mappings.ContainsKey(b))
                {
                    continue;
                }

                if ((uiMode, i) == mappings[b])
                {
                    // Draw the icon here
                    Texture2D buttonTexture = buttonTextures[(int)b];

                    float buttonRadius = iconRadius / 2;
                    GUI.DrawTexture(new Rect(
                        Screen.width / 2 + wOffset - 2 * iconRadius + buttonRadius * factor,
                        Screen.height / 2 + hOffset + buttonRadius * factor,
                        buttonRadius * 2 * factor,
                        buttonRadius * 2 * factor
                    ), buttonTextures[(int)b], ScaleMode.ScaleToFit);
                }
            }
        }
    }

    Texture2D CreateUI ()
    {
        // Creates the background for the combat UI, for a specific resolution, and puts it into a texture
        Texture2D tex = new Texture2D(Screen.width, Screen.height, TextureFormat.RGBA32, false);

        Vector2 center = new Vector3(Screen.width / 2, Screen.height / 2);

        // Draw a circle onto the texture
        for (int w = 0; w < Screen.width; w++)
        {
            for (int h = 0; h < Screen.height; h++)
            {
                // Determine whether the pixel should be shaded or not:
                // It should be shaded if it meets the following conditions:
                //    - Distance from center 
                Vector2 point = new Vector2(w, h);
                float normDist = Vector2.Distance(point, center) / (Screen.height / 2);
                if (normDist < outerRadius && normDist > innerRadius)
                {
                    // Point should be coloured in
                    tex.SetPixel(w, h, new Color(0, 0, 0, alpha));
                }
                else
                {
                    // Point should be transparent
                    tex.SetPixel(w, h, new Color(0, 0, 0, 0));
                }
            }
        }

        tex.Apply();

        return tex;
    }
}
