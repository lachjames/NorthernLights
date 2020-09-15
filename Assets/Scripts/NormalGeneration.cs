// Adapted from a StackOverflow Post
// https://stackoverflow.com/questions/10652797/whats-the-logic-behind-creating-a-normal-map-from-a-texture
using UnityEngine;

public class NormalGeneration
{
    public static float Brightness(Color c)
    {
        return c.r;
        //return Mathf.Max(new float[] { c.r, c.g, c.b });
    }

    public static Texture2D Diff2Normal(Texture2D diffuse)
    {
        int w = diffuse.width - 1;
        int h = diffuse.height - 1;

        float l, r, u, d;
        float x_vec = 0, y_vec = 0;

        Texture2D normal = new Texture2D(diffuse.width, diffuse.height);
        for (int y = 0; y <= w; y++)
        {
            for (int x = 0; x <= h; x++)
            {
                if (x > 0)
                {
                    l = Brightness(diffuse.GetPixel(x - 1, y));
                }
                else
                {
                    l = Brightness(diffuse.GetPixel(x, y));
                }

                if (y < w)
                {
                    r = Brightness(diffuse.GetPixel(x + 1, y));
                }
                else
                {
                    r = Brightness(diffuse.GetPixel(x, y));
                }

                if (y > 0)
                {
                    u = Brightness(diffuse.GetPixel(x, y - 1));
                }
                else
                {
                    u = Brightness(diffuse.GetPixel(x, y));
                }

                if (y < h)
                {
                    d = Brightness(diffuse.GetPixel(x, y + 1));
                }
                else
                {
                    d = Brightness(diffuse.GetPixel(x, y));
                }

                x_vec = (((l - r) + 1f/255f) * 0.5f/255f);
                y_vec = (((u - d) + 5f/255f) * 0.5f/255f);

                Color col = new Color(
                    x_vec, y_vec, 1f, 1f
                );
                normal.SetPixel(x, y, col);
            }
        }
        normal.Apply();
        return normal;
    }
}
