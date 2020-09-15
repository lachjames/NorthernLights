using AuroraEngine;
using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Reflection.Emit;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

public class GUISystem : MonoBehaviour
{
    public GUIStyle guiStyle;
    public static GUIStyle style;

    public LayerMask hookMask;
    public float interactionRange = 3f;

    AuroraInput controls;

    public AuroraGUI gui;
    public string guiName = "mainmenu16x12";

    Dictionary<string, Texture> textures;
    GameObject selectedHook = null;

    bool selected = false;
    bool pressedLastFrame = false;
    bool initialized = false;
    // Start is called before the first frame update

    AuroraObject pc;

    //AuroraWindow currentWindow = null;
    ModalWindow modalWindow = null;

    public StateSystem stateSystem;

    void Awake()
    {
        controls = new AuroraInput();

        controls.Player.Enable();

        controls.Player.Select.performed += _ => SelectedOption();
    }

    void SelectedOption ()
    {
        UnityEngine.Debug.Log("Selected");
        selected = true;
    }

    void Start()
    {
        // Get the default GUI template
        //LoadGUI(guiName);
    }
    public void Initialize()
    {
        stateSystem = GameObject.Find("State System").GetComponent<StateSystem>();
        style = guiStyle;
        initialized = true;

        // TODO: Make this not require the State System to be initialized first? Or is this fine, idk...
        pc = stateSystem.PC;
    }

    void Update()
    {
        if (!initialized)
        {
            return;
        }
        if (selected && !pressedLastFrame)
        {
            if (Vector3.Distance(pc.transform.position, selectedHook.transform.position) < interactionRange)
            {
                selectedHook.transform.parent.GetComponent<AuroraObject>().Selected();
            }
        }

        pressedLastFrame = selected;
        selected = false;
    }

    void LoadGUI (string name)
    {
        gui = AuroraEngine.Resources.LoadGUI(name);

        // Load textures
        textures = new Dictionary<string, Texture>();
        foreach (AuroraGUI.ACONTROLS control in gui.CONTROLS)
        {
            string texname = control.BORDER.FILL;
            Texture texture = AuroraEngine.Resources.LoadTexture2D(texname);
            textures[texname] = texture;
        }
    }

    //Rect Position(Rect pos)
    //{
    //    // Moves the UI into the middle of the screen, by offsetting along the x and y axes
    //}

    void OnGUI()
    {
        if (!initialized)
        {
            UnityEngine.Debug.Log("Not drawing GUI as not initialized");
            return;
        }
        //DrawGUI();
        DrawHooks();

        if (modalWindow != null)
        {
            modalWindow.Draw();
        }
    }

    public void ShowModalWindow (ModalWindow window)
    {
        modalWindow = window;
    }

    public void CloseModalWindow ()
    {
        modalWindow = null;
    }

    void DrawGUI ()
    {
        // Draw the GUI
        foreach (AuroraGUI.ACONTROLS control in gui.CONTROLS)
        {
            // Create a label
            Rect pos = new Rect(
                control.EXTENT.LEFT,
                control.EXTENT.TOP,
                control.EXTENT.WIDTH,
                control.EXTENT.HEIGHT
            );

            //pos = Position(pos);

            // Find text for the label
            string text = "";
            if (control.TEXT != null)
            {
                if (control.TEXT.TEXT != "")
                {
                    text = control.TEXT.TEXT;
                }
                else
                {
                    text = AuroraEngine.Resources.GetString((int)control.TEXT.STRREF);
                }
            }

            // Find image for the label
            string texName = control.BORDER.FILL;
            Texture tex = textures[texName];

            GUI.Label(pos, tex);
        }
    }

    void DrawHooks ()
    {
        selectedHook = null;

        GUIStyle style = new GUIStyle();
        style.fontSize = 16;
        style.normal.textColor = Color.red;
        style.alignment = TextAnchor.MiddleCenter;

        List<GameObject> allHooks = new List<GameObject>();
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("LookAtHook"))
        {
            //Debug.Log("Considering object " + obj.name);
            AuroraObject auroraObject = obj.GetComponent<LookAtHook>().obj;

            if (auroraObject == null)
            {
                continue;
            }

            if (auroraObject.GetType() == typeof(Door))
            {
                Door door = (Door)auroraObject;
                AuroraUTD utd = (AuroraUTD)door.template;
                // TODO: Support closing doors? Don't think this is a thing in KotOR/TSL
                if (door.open)
                {
                    //Debug.Log("Door is open, so not drawing hook");
                    continue;
                }
                //Debug.Log("Drawing hook for door");
                allHooks.Add(obj);
            }
            else if (auroraObject.GetType() == typeof(Creature))
            {
                // Check if the creature has a default conversation
                Creature creature = (Creature)auroraObject;
                AuroraUTC utc = (AuroraUTC)creature.template;

                bool selectable = false;

                if (utc.Conversation == null || utc.Conversation == "")
                {
                    //Debug.Log("Creature has no conversation, so not drawing hook");
                    selectable = true;
                }
                else if (NWScript.GetIsEnemy(creature, stateSystem.PC) > 0)
                {
                    selectable = true;
                }

                if (selectable)
                    allHooks.Add(obj);
            }
            else if (auroraObject.GetType() == typeof(Placeable))
            {
                // Check if the placeable can be interacted with
                Placeable placeable = (Placeable)auroraObject;
                AuroraUTP utp = (AuroraUTP)placeable.template;

                if (utp.Useable == 0)
                {
                    //Debug.Log("Placeable is not useable, so not drawing hook");
                    continue;
                }
                //Debug.Log("Drawing hook for placeable");
                allHooks.Add(obj);
            }
        }

        //Debug.Log("Considering " + allHooks.Count + " hooks");

        List<GameObject> hooks = new List<GameObject>();
        foreach (GameObject g in allHooks)
        {
            //Debug.Log("Checking if hook " + g.name + " is visible");
            // Determine whether the object is blocked by another collider
            Vector2 point = Camera.main.WorldToScreenPoint(g.transform.position);
            Ray r = Camera.main.ScreenPointToRay(point);
            RaycastHit hit;

            if (Physics.Raycast(r, out hit, float.MaxValue, hookMask))
            {
                // We might hit the boundary of the object represented by the hook?
                if (hit.transform.gameObject == g || Vector3.Distance(hit.point, g.transform.position) < 1f)
                {
                    hooks.Add(g);
                }
            }
        }

        //Debug.Log("Showing " + hooks.Count + " hooks");

        float dist = float.PositiveInfinity;
        selectedHook = null;
        foreach (GameObject h in hooks)
        {
            Vector2 hPos = Camera.main.WorldToScreenPoint(h.transform.position);
            float d = Vector2.Distance(
                new Vector2(hPos.x, Screen.height - hPos.y),
                new Vector2(
                    Screen.width / 2,
                    Screen.height / 2
                )
            );

            if (d < dist)
            {
                dist = d;
                selectedHook = h;
            }
        }

        foreach (GameObject g in hooks)
        {
            Vector2 point = Camera.main.WorldToScreenPoint(g.transform.position);
            if (g == selectedHook)
            {
                if (Vector3.Distance(pc.transform.position, selectedHook.transform.position) < interactionRange)
                {
                    style.normal.textColor = Color.green;
                    style.fontSize = 28;
                }
                else
                {
                    style.normal.textColor = Color.blue;
                    style.fontSize = 28;
                }
            } else
            {
                style.normal.textColor = Color.red;
                style.fontSize = 16;
            }

            Rect labelRect = new Rect(point.x - 90, Screen.height - point.y - 240, 180, 240);

            AuroraObject obj = g.GetComponent<LookAtHook>().obj;
            if (obj.GetType() == typeof(Door))
            {
                TooltipWindow doorTooltip = ((Door)obj).GetTooltip();
                using (new GUILayout.AreaScope(labelRect))
                {
                    doorTooltip.Draw();
                }
            }
            GUI.Label(
                new Rect(point.x - 25, Screen.height - point.y - 25, 50, 50),
                "O",
                style
            );;
        }
    }
}

public abstract class AuroraUI
{
    // This is the base class that allows GUI windows to be easily rendered
    // with a common structure

    public AuroraUI()
    {

    }

    public virtual void Update ()
    {

    }

    public abstract void Draw();

    public abstract class AuroraUIElement
    {
        public float width, height;
        public AuroraUIElement(float w, float h)
        {
            width = w;
            height = h;
        }

        public abstract void Draw();
    }

    public class Item : AuroraUIElement
    {
        AuroraEngine.Item item;
        AuroraUTI template;
        Texture2D tex;
        string name;

        public Button button;

        // An item has a thumbnail and a clickable button next to it
        public Item(float w, float h, AuroraEngine.Item item) : base(w, h)
        {
            this.item = item;
            template = (AuroraUTI)item.template;
            tex = AuroraEngine.Resources.LoadTexture2D(
                AuroraEngine.Resources.From2DA("baseitems", template.BaseItem, "defaulticon")
            );

            if (tex == null)
            {
                tex = Texture2D.blackTexture;
            }

            name = AuroraEngine.Resources.GetString((int)template.LocalizedName.stringref);

            button = new Button(w, h, name);
        }

        public override void Draw()
        {
            using (new GUILayout.HorizontalScope())
            {
                // Draw the thumbnail
                GUILayout.Label(
                    tex, GUISystem.style, GUILayout.Width(this.height), GUILayout.Height(this.height)
                );

                button.Draw();
            }
        }
    }

    public class SelectorList : AuroraUIElement
    {
        Button upButton;
        Button downButton;

        List<AuroraUIElement> items;

        int curIdx = 0;
        public SelectorList (float w, float h, List<AuroraUIElement> items) : base (w, h)
        {
            this.items = items;
            Update();
        }

        public void Update ()
        {
            upButton = new Button(this.width, this.height, "▲");
            upButton.Clicked += CycleUp;

            downButton = new Button(this.width, this.height, "▼");
            downButton.Clicked += CycleDown;
        }

        public void CycleUp (object obj, EventArgs ev)
        {
            curIdx += 1;

            while (curIdx >= items.Count)
            {
                curIdx -= items.Count;
            }
            while (curIdx < 0)
            {
                curIdx += items.Count;
            }

            UnityEngine.Debug.Log(curIdx);
        }

        public void CycleDown (object obj, EventArgs ev)
        {
            curIdx -= 1;

            while (curIdx >= items.Count)
            {
                curIdx -= items.Count;
            }
            while (curIdx < 0)
            {
                curIdx += items.Count;
            }
            
            UnityEngine.Debug.Log(curIdx);
        }

        public override void Draw()
        {
            using (new GUILayout.VerticalScope())
            {
                // Item arrow
                if (items.Count == 0)
                {
                    //GUILayout.Label("Blank");
                    return;
                }
                upButton.Draw();
                items[curIdx].Draw();
                downButton.Draw();
            }
        }
    }

    public class ScrollableList : AuroraUIElement
    {
        // A scrollable list contains a set of AuroraUIElements
        public Vector2 scroll;
        public List<AuroraUIElement> elements;
        public ScrollableList(float w, float h, List<AuroraUIElement> items) : base(w, h)
        {
            elements = items;
            scroll = Vector2.zero;
        }

        public override void Draw()
        {
            using (var scrollScope = new GUILayout.ScrollViewScope(scroll))
            {
                scroll = scrollScope.scrollPosition;

                foreach (AuroraUIElement elem in elements)
                {
                    elem.Draw();
                }
            }
        }
    }

    public class Grid : AuroraUIElement
    {
        int vert, hor;
        AuroraUIElement[,] items; // Indexed by items[v, h]
        public Grid(float w, float h, int vert, int hor, AuroraUIElement[,] items) : base(w, h)
        {
            this.vert = vert;
            this.hor = hor;
            this.items = items;
        }

        public override void Draw()
        {
            // Wrap the whole thing in a vertical scope
            using (new GUILayout.VerticalScope())
            {
                // Wrap each line in a horizontal scope
                for (int v = 0; v < vert; v++)
                {
                    using (new GUILayout.HorizontalScope())
                    {
                        for (int h = 0; h < hor; h++)
                        {
                            items[v, h].Draw();
                        }
                    }
                }
            }
        }
    }

    public class Button : AuroraUIElement
    {
        public event EventHandler Clicked;

        Texture2D tex;
        string str;

        public Button(float w, float h, Texture2D tex) : base(w, h)
        {
            this.tex = tex;
            this.str = null;
        }

        public Button(float w, float h, string str) : base(w, h)
        {
            this.str = str;
            this.tex = null;
        }

        public override void Draw()
        {
            if (this.str != null)
            {
                if (GUILayout.Button(str, GUISystem.style))
                {
                    Clicked.Invoke(null, null);
                }
            }
            else if (this.tex != null)
            {
                if (GUILayout.Button(tex, GUISystem.style))
                {
                    Clicked.Invoke(null, null);
                }
            }
            else
            {
                // Draw empty button
                GUILayout.Button("BUTTON", GUISystem.style);
            }
        }
    }
}

public abstract class ModalWindow : AuroraUI
{
    public GUISystem gui;
    public float width, height;

    public Rect windowRect;
    // A window which is an overlay over the game
    public ModalWindow(GUISystem gui, float width, float height)
    {
        this.gui = gui;

        this.width = Screen.width * width;
        this.height = Screen.height * height;

        float centerW = Screen.width / 2;
        float centerH = Screen.height / 2;

        windowRect = new Rect(
            centerW - (this.width / 2),
            centerH - (this.height / 2),
            this.width,
            this.height
        );
    }
}

public class TooltipWindow : AuroraUI
{
    float width, height;
    AuroraObject obj;

    string objName;

    //HealthBar healthBar;

    List<AuroraUIElement> options1, options2, options3;
    SelectorList left, middle, right;

    public TooltipWindow (float w, float h, AuroraObject o, List<AuroraUIElement> o1, List<AuroraUIElement> o2, List<AuroraUIElement> o3)
    {
        width = w;
        height = h;

        obj = o;

        options1 = o1;
        options2 = o2;
        options3 = o3;

        Update();
    }

    public override void Update ()
    {
        objName = "Object";
        if (obj.GetType() == typeof(Creature))
        {
            string firstName = AuroraEngine.Resources.GetString((int)((AuroraUTC)obj.template).FirstName.stringref);
            string lastName = AuroraEngine.Resources.GetString((int)((AuroraUTC)obj.template).LastName.stringref);
            objName = firstName + (lastName != "" ? (" " + lastName) : "");
        }
        else if (obj.GetType() == typeof(Door))
        {
            objName = AuroraEngine.Resources.GetString((int)((AuroraUTD)obj.template).LocName.stringref);
        }
        else if (obj.GetType() == typeof(Placeable))
        {
            objName = AuroraEngine.Resources.GetString((int)((AuroraUTP)obj.template).LocName.stringref);

            // Check if the placeable is empty; if so, append " (Empty)" to the name
            if (((AuroraUTP)obj.template).ItemList.Count == 0)
            {
                objName += " (Empty)";
            }
        }

        left = new SelectorList(this.width / 3, this.height * 2 / 3, options1);
        middle = new SelectorList(this.width / 3, this.height * 2 / 3, options2);
        right = new SelectorList(this.width / 3, this.height * 2 / 3, options3);
    }

    public override void Draw()
    {
        using (new GUILayout.VerticalScope())
        {
            // Title
            GUILayout.Label(objName);

            // Health bar (TODO)

            // Three options
            using (new GUILayout.HorizontalScope())
            {
                left.Draw();
                middle.Draw();
                right.Draw();
            }
        }
    }
}

public class PlaceableWindow : ModalWindow
{
    Placeable placeable;
    ScrollableList scroll;

    Button getItems, switchToGiveItems, close;
    public PlaceableWindow(GUISystem gui, float width, float height, Placeable placeable) : base(gui, width, height)
    {
        this.placeable = placeable;

        Update();
    }

    public override void Update ()
    {
        AuroraUTP template = (AuroraUTP)placeable.template;

        // Load the items
        List<AuroraUIElement> items = new List<AuroraUIElement>();
        foreach (AuroraUTP.AItem item in template.ItemList)
        {
            // Create an item instance for each item in the inventory
            // (this will be transferred into the player's inventory when they pick the item up)
            UnityEngine.Debug.Log("Loading item " + item.InventoryRes);
            Item uiItem = new Item(this.width, this.height * 2 / 9, AuroraEngine.Resources.LoadItem(item.InventoryRes));
            uiItem.button.Clicked += (_, __) => PlayerTakeItem(item);
            uiItem.button.Clicked += (_, __) => placeable.OnInvDisturbed();

            items.Add(uiItem);
        }

        // Create the scrollable list
        scroll = new ScrollableList(width, height * 2 / 3, items);

        // Create the buttons
        getItems = new Button(width, height / 12, "Get Items");
        getItems.Clicked += GetAllItems;
        
        switchToGiveItems = new Button(width, height / 12, "Switch to Give Items");
        switchToGiveItems.Clicked += SwitchToGiveItems;

        close = new Button(width, height / 12, "Close");
        close.Clicked += Close;
    }

    void PlayerTakeItem (AuroraUTP.AItem item)
    {
        // Give a copy of the item to the player
        ((AuroraUTC)gui.stateSystem.PC.template).ItemList.Add(new AuroraUTC.AItem()
        {
            InventoryRes = item.InventoryRes
        });

        // Remove the item from the placeable
        AuroraUTP utp = (AuroraUTP)placeable.template;
        utp.ItemList.Remove(item);

        // Update
        Update();
    }

    void GetAllItems (object caller, EventArgs handler)
    {
        // Give all items to the player
        //Close(null, null);
    }

    void SwitchToGiveItems (object caller, EventArgs handler)
    {
        // TODO: Implement giving items to a placeable
        //Close(null, null);
    }

    void Close (object caller, EventArgs handler)
    {
        gui.CloseModalWindow();
        placeable.ClosePlc();
    }

    public override void Draw()
    {

        using (new GUILayout.AreaScope(windowRect))
        {
            using (new GUILayout.VerticalScope())
            {
                // Draw the scrollable item picker
                scroll.Draw();

                getItems.Draw();
                switchToGiveItems.Draw();
                close.Draw();
            }
        }
    }
}

public abstract class MenuWindow : AuroraUI
{
    string label;
    Grid grid;
    Button closeButton;
    // A menu that fills up the whole screen
    public MenuWindow(string label)
    {
        this.label = label;

        grid = new Grid(Screen.width / 2, Screen.height - 200, 1, 8, new AuroraUIElement[,] {
            { new Button(Screen.width / 2 - 30, 50, "LOAD GAME") },
            { new Button(Screen.width / 2 - 30, 50, "SAVE GAME") },
            { new Button(Screen.width / 2 - 30, 50, "GAMEPLAY") },
            { new Button(Screen.width / 2 - 30, 50, "FEEDBACK") },
            { new Button(Screen.width / 2 - 30, 50, "AUTO-PAUSE") },
            { new Button(Screen.width / 2 - 30, 50, "GRAPHICS") },
            { new Button(Screen.width / 2 - 30, 50, "SOUND") },
            { new Button(Screen.width / 2 - 30, 50, "EXIT GAME") },
        });

        closeButton = new Button(Screen.width, 100, "CLOSE");
    }

    public override void Draw()
    {
        using (new GUILayout.VerticalScope())
        {
            // Draw the heading
            GUILayout.Label(this.label, GUILayout.Width(Screen.width), GUILayout.Height(100));

            using (new GUILayout.HorizontalScope())
            {
                // Draw the left set of buttons (as a grid)
                grid.Draw();

                // Draw the window on the right
            }
            closeButton.Draw();
        }
    }
}

//public class OptionsMenu : MenuWindow
//{

//}