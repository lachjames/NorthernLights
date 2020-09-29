using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

[SelectionBase]
[ExecuteInEditMode]
public class AuroraLayoutRoom : MonoBehaviour
{
    public AuroraRoom room;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        room.position = new Vector3(
            transform.position.x,
            transform.position.z,
            transform.position.y
        );
    }

    public void Initialize(AuroraRoom room)
    {
        this.room = room;

        gameObject.name = room.model;

        Debug.Log("Loading model " + room.model);

        GameObject model = AuroraEngine.Resources.LoadModel(room.model);
        model.transform.parent = transform;
    }
}


public class AuroraLayout
{
    public List<AuroraRoom> rooms = new List<AuroraRoom>();
    public List<AuroraDoorHook> doorHooks = new List<AuroraDoorHook>();
    public AuroraLayout(string filename)
    {
        string txt = File.ReadAllText(filename);
        string[] lines = txt.Split('\n');

        int row = 0;
        while (!lines[row].Contains("beginlayout"))
        {
            row++;
        }
        row++;

        // Read rooms
        string roomsStart = lines[row];
        string[] roomStartTokens = roomsStart.Trim().Split(' ');

        int numRooms = int.Parse(roomStartTokens[1]);
        Debug.Log("Reading " + numRooms + " rooms");
        row += 1;
        for (int i = 0; i < numRooms; i++)
        {
            Debug.Log("Reading room " + lines[row]);
            rooms.Add(new AuroraRoom(lines[row]));
            row += 1;
        }

        // Read tracks
        string trackStart = lines[row];
        string[] trackStartTokens = trackStart.Trim().Split(' ');

        int numTracks = int.Parse(trackStartTokens[1]);
        Debug.Log("Reading " + numTracks + " tracks");
        row += 1;
        for (int i = 0; i < numTracks; i++)
        {
            Debug.Log("Reading track " + lines[row]);
            row += 1;
        }

        // Read obstacles
        string obstacleStart = lines[row];
        string[] obstacleStartTokens = obstacleStart.Trim().Split(' ');

        int numObstacles = int.Parse(obstacleStartTokens[1]);
        Debug.Log("Reading " + numObstacles + " obstacles");
        row += 1;
        for (int i = 0; i < numObstacles; i++)
        {
            Debug.Log("Reading obstacle " + lines[row]);
            row += 1;
        }

        // Read doors
        string doorStart = lines[row];
        string[] doorStartTokens = doorStart.Trim().Split(' ');
        int numDoors = int.Parse(doorStartTokens[1]);
        Debug.Log("Reading " + numDoors + " doors");
        row += 1;
        for (int i = 0; i < numDoors; i++)
        {
            Debug.Log("Reading door " + lines[row]);
            doorHooks.Add(new AuroraDoorHook(lines[row]));
            row += 1;
        }
    }

    public string GetString ()
    {
        List<string> lines = new List<string>();

        // Header
        lines.Add("#MAXLAYOUT ASCII");
        lines.Add("filedependancy null.max");
        lines.Add("beginlayout");

        // Rooms
        lines.Add("   roomcount " + rooms.Count);
        foreach (AuroraRoom room in rooms)
        {
            lines.Add("      " + room.GetString());
        }

        lines.Add("   trackcount 0");
        lines.Add("   obstaclecount 0");

        // Door hooks
        lines.Add("   doorhookcount " + doorHooks.Count);
        foreach (AuroraDoorHook hook in doorHooks)
        {
            lines.Add("      " + hook.GetString());
        }

        // Footer
        lines.Add("donelayout");

        return string.Join("\n", lines);
    }
}

public class AuroraRoom
{
    public string model;
    public Vector3 position;

    public AuroraRoom(string definition)
    {
        string[] tokens = definition.Trim().Split(' ');
        model = tokens[0];
        position = new Vector3(
            float.Parse(tokens[1]),
            float.Parse(tokens[2]),
            float.Parse(tokens[3])
        );
    }

    public AuroraRoom (string model, Vector3 position)
    {
        this.model = model;
        this.position = position;
    }

    public string GetString ()
    {
        return model + " " +
            string.Format("{0:0.0###########}", position.x) + " " +
            string.Format("{0:0.0###########}", position.y) + " " +
            string.Format("{0:0.0###########}", position.z);
    }
}

public class AuroraDoorHook
{
    public string model, name;
    public int unk;
    public Vector3 position;
    public Quaternion rotation;

    public AuroraDoorHook(string definition)
    {
        string[] tokens = definition.Trim().Split(' ');
        model = tokens[0];
        name = tokens[1];
        unk = int.Parse(tokens[2]);
        position = new Vector3(
            float.Parse(tokens[3]),
            float.Parse(tokens[4]),
            float.Parse(tokens[5])
        );
        rotation = new Quaternion(
            float.Parse(tokens[6]),
            float.Parse(tokens[7]),
            float.Parse(tokens[8]),
            float.Parse(tokens[9])
        );
    }

    public string GetString ()
    {
        return model + " " + name + " " + unk + " " +
            string.Format("{0:0.0###########}", position.x) + " " +
            string.Format("{0:0.0###########}", position.y) + " " +
            string.Format("{0:0.0###########}", position.z) + " " +
            string.Format("{0:0.0###########}", rotation.x) + " " +
            string.Format("{0:0.0###########}", rotation.y) + " " +
            string.Format("{0:0.0###########}", rotation.z) + " " +
            string.Format("{0:0.0###########}", rotation.w);
    }
}
