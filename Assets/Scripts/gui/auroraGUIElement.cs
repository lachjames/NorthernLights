//using Aurora.Types;
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;
//using TMPro;

//[ExecuteInEditMode]
//public class auroraGUIElement : MonoBehaviour
//{
//    internal RectTransform rt, parentRect;

//    [SerializeField]
//    Vector4 pos;

//    [SerializeField]
//    Control control;

//    [SerializeField]
//    Gui gui_definition;

//    // Start is called before the first frame update
//    void Start()
//    {
//        rt = GetComponent<RectTransform>();
//        parentRect = transform.parent.GetComponent<RectTransform>();

//        SetStyle();
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        SetSize();
//    }

//    internal Vector4 MapToRect()
//    {
//        pos = new Vector4(
//            int.Parse(control.Extent.Left),
//            int.Parse(control.Extent.Top),
//            int.Parse(control.Extent.Width),
//            int.Parse(control.Extent.Height)
//        );

//        float baseWidth = int.Parse(gui_definition.Extent.Width);
//        float baseHeight = int.Parse(gui_definition.Extent.Height);

//        int newWidth = (int)(pos.z / baseWidth * parentRect.rect.width);
//        int newHeight = (int)(pos.w / baseHeight * parentRect.rect.height);

//        float adjustedLeft = pos.x + (newWidth - pos.z) / 2;
//        float adjustedTop = baseHeight - (pos.y + (newHeight - pos.w) / 2);

//        float newLeft = (float)(adjustedLeft / baseWidth * parentRect.rect.width);
//        float newTop = (float)(adjustedTop / baseHeight * parentRect.rect.height - parentRect.rect.height);


//        float x_offset = (float)(int.Parse(gui_definition.Extent.Left) / baseWidth * parentRect.rect.width);
//        float y_offset = (float)(int.Parse(gui_definition.Extent.Top) / baseHeight * parentRect.rect.height);

//        Vector4 result = new Vector4(newLeft + x_offset, newTop - y_offset, pos.z, pos.w);
//        //Debug.Log(result);

//        return result;
//    }

//    void SetSize ()
//    {
//        Vector4 curSizing = MapToRect();
//        rt.sizeDelta = new Vector2(curSizing.z, curSizing.w);
//        rt.anchoredPosition = new Vector2(curSizing.x, curSizing.y);
//    }

//    void SetStyle ()
//    {
//        Image imgComponent = GetComponent<Image>();
//        if (control.Border.Fill != "")
//        {
//            Debug.Log("guiTextures/" + control.Border.Fill);
//            Sprite img = (Sprite)Resources.Load("guiTextures/" + control.Border.Fill, typeof(Sprite));
//            Debug.Log(img);
//            imgComponent.enabled = true;
//            imgComponent.overrideSprite = img;
//        } if (control.Border.Color != null) {
//            float r = float.Parse(control.Border.Color[0]);
//            float g = float.Parse(control.Border.Color[1]);
//            float b = float.Parse(control.Border.Color[2]);

//            imgComponent.color = new Color(r, g, b);
//        }
//    }

//    void SetText ()
//    {
//        TMP_Text tmp = GetComponentInChildren<TMP_Text>();
//        if (control.Text.Strref != "" && control.Text.Strref != "4294967295")
//        {
//            AuroraData data = GameObject.Find("Runtime").GetComponent<AuroraData>();
//            Debug.Log(control.Text.Strref);
//            Debug.Log(data.textDict[control.Text.Strref]);
//            tmp.text = data.textDict[control.Text.Strref];
//        } else
//        {
//            tmp.text = "";
//        }

//        if (control.Text.Color != null)
//        {
//            float r = float.Parse(control.Text.Color[0]);
//            float g = float.Parse(control.Text.Color[1]);
//            float b = float.Parse(control.Text.Color[2]);

//            Color col = new Color(r, g, b);
//            tmp.color = col;
//        }
//    }

//    public void Instantiate(Control control, Gui gui_definition)
//    {
//        this.control = control;
//        this.gui_definition = gui_definition;

//        parentRect = transform.parent.GetComponent<RectTransform>();
//        rt = GetComponent<RectTransform>();

//        SetSize();
//        SetStyle();
//        SetText();
//    }
//}
