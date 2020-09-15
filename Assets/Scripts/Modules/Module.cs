using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

namespace AuroraEngine
{
    public class Module
    {
        public string moduleName;
        public AuroraData data;

        public AuroraIFO ifo;
        public AuroraARE are;
        public AuroraGIT git;

        public Area area;

        List<CameraPoint> cameraPoints = new List<CameraPoint>();
        public Vector3 entryPosition { get; private set; }
        public Quaternion entryRotation { get; private set; }
        public AudioClip ambientMusic { get; private set; }
        public AudioClip ambientSound { get; private set; }

        static StateSystem stateManager;
        static AISystem aiManager;
        static LoadingSystem loader;

        List<ReflectionProbe> realtimeProbes = new List<ReflectionProbe>();

        void SetLayerRecursive (GameObject obj, int layer)
        {
            obj.layer = layer;
            foreach (Transform t in obj.transform)
            {
                SetLayerRecursive(t.gameObject, layer);
            }
        }

        // Source: https://forum.unity.com/threads/getting-the-bounds-of-the-group-of-objects.70979/
        Bounds getBounds(GameObject objeto)
        {
            Bounds bounds;
            Renderer childRender;
            bounds = getRenderBounds(objeto);
            if (bounds.extents.x == 0)
            {
                bounds = new Bounds(objeto.transform.position, Vector3.zero);
                foreach (Transform child in objeto.transform)
                {
                    childRender = child.GetComponent<Renderer>();
                    if (childRender)
                    {
                        bounds.Encapsulate(childRender.bounds);
                    }
                    else
                    {
                        bounds.Encapsulate(getBounds(child.gameObject));
                    }
                }
            }
            return bounds;
        }

        Bounds getRenderBounds(GameObject objeto)
        {
            Bounds bounds = new Bounds(Vector3.zero, Vector3.zero);
            Renderer render = objeto.GetComponent<Renderer>();
            if (render != null)
            {
                return render.bounds;
            }
            return bounds;
        }

        public Module(string name, AuroraData data)
        {
            this.moduleName = name;
            this.data = data;
            if (stateManager == null)
            {
                stateManager = GameObject.Find("State System").GetComponent<StateSystem>();
            }
            if (loader == null)
            {
                loader = GameObject.Find("Loading System").GetComponent<LoadingSystem>();
            }

            ifo = data.Get<AuroraIFO>("module", ResourceType.IFO);
            string areaName = ifo.Mod_Entry_Area;

            are = data.Get<AuroraARE>(areaName, ResourceType.ARE);
            git = data.Get<AuroraGIT>(areaName, ResourceType.GIT);

            entryPosition = new Vector3(ifo.Mod_Entry_X, ifo.Mod_Entry_Z, ifo.Mod_Entry_Y);

            Dictionary<string, Vector3> layout = Resources.LoadLayout(areaName, data);

            area = Area.Create(are);

            GameObject parent = new GameObject("Models");
            parent.transform.SetParent(area.transform);

            foreach (var value in layout)
            {
                loader.AddAction(() =>
                {
                    string resref = value.Key.ToLower();

                    GameObject room = Resources.LoadModel(resref);

                    if (SetupSkybox(room)) {
                        return;
                    }

                    // Set up the Navmesh
                    SetLayerRecursive(room, LayerMask.NameToLayer("NavMeshStatic"));

                    // Set the room's position and parent
                    room.transform.position = value.Value;
                    room.transform.SetParent(parent.transform);
                });
            }

            LoadCreatures();
            LoadPlaceables();

            loader.AddAction(() => data.aiManager.BakeNavMesh());

            LoadDoors();
            LoadTriggers();
            LoadEncounters();
            LoadSounds();
            LoadStores();
            LoadWaypoints();
            LoadCameras();

            loader.AddAction(() =>
            {
                // Load the music
                //int musicId = git.AreaProperties.MusicDay;
                //string musicResource = Resources.Load2DA("ambientmusic")[musicId, "resource"];

                //ambientMusic = Resources.LoadAudio(musicResource);
            });
        }

        public bool SetupSkybox (GameObject room)
        {
            return SkymapTaris(room) || SkymapTattoine(room);
        }

        bool SkymapTaris (GameObject skymapObj)
        {
            Transform up = skymapObj.transform.Find("sky01");
            Transform front = skymapObj.transform.Find("sky015");
            Transform back = skymapObj.transform.Find("sky011");
            Transform left = skymapObj.transform.Find("sky014");
            Transform right = skymapObj.transform.Find("sky012");

            return MakeSkymap(up, front, back, left, right);
        }

        bool MakeSkymap (Transform up, Transform front, Transform back, Transform left, Transform right)
        {
            if (!up || !front || !back || !left || !right)
            {
                return false;
            }

            if (!up || !front || !back || !left || !right)
            {
                return false;
            }

            Material m = new Material(Shader.Find("Skybox/6 Sided"));
            m.SetTexture("_FrontTex", front.GetComponent<Renderer>().material.mainTexture);
            m.SetTexture("_UpTex", up.GetComponent<Renderer>().material.mainTexture);
            m.SetTexture("_BackTex", back.GetComponent<Renderer>().material.mainTexture);
            m.SetTexture("_LeftTex", left.GetComponent<Renderer>().material.mainTexture);
            m.SetTexture("_RightTex", right.GetComponent<Renderer>().material.mainTexture);

            RenderSettings.skybox = m;

            GameObject.Destroy(up.gameObject);
            GameObject.Destroy(front.gameObject);
            GameObject.Destroy(back.gameObject);
            GameObject.Destroy(left.gameObject);
            GameObject.Destroy(right.gameObject);

            return true;
        }

        bool SkymapTattoine (GameObject skymapObj)
        {
            return Tatt1(skymapObj) || Tatt2(skymapObj);
        }

        bool Tatt1(GameObject skymapObj)
        {
            Transform up = skymapObj.transform.Find("sky05");
            Transform front = skymapObj.transform.Find("sky01");
            Transform back = skymapObj.transform.Find("sky03");
            Transform left = skymapObj.transform.Find("sky04");
            Transform right = skymapObj.transform.Find("sky02");

            return MakeSkymap(up, front, back, left, right);
        }
        bool Tatt2(GameObject skymapObj)
        {
            Transform up = skymapObj.transform.Find("mesh05");
            Transform front = skymapObj.transform.Find("mesh01");
            Transform back = skymapObj.transform.Find("mesh03");
            Transform left = skymapObj.transform.Find("mesh04");
            Transform right = skymapObj.transform.Find("mesh02");

            // Check that the up transform is very far away
            if (!up || up.position.magnitude < 1000f)
            {
                return false;
            }

            return MakeSkymap(up, front, back, left, right);
        }

        public void UpdateProbes ()
        {
            foreach (ReflectionProbe probe in realtimeProbes)
            {
                probe.RenderProbe();
            }
        }

        private void LoadCreatures()
        {
            List<AuroraGIT.ACreature> creatures = git.CreatureList;

            GameObject parent = new GameObject("Creatures");
            parent.transform.SetParent(area.transform);

            foreach (AuroraGIT.ACreature c in creatures)
            {
                loader.AddAction(() =>
                {
                    Vector3 position = new Vector3(c.XPosition, c.ZPosition, c.YPosition);

                    //character orientation is stored as a vector2 which describes an angle to rotate around
                    float x = c.XOrientation, y = c.YOrientation;
                    float bearing = Mathf.Tan(x / y);
                    Quaternion rotation = Quaternion.Euler(0, bearing * Mathf.Rad2Deg * -1, 0);

                    Creature creature = Resources.LoadCreature(c.TemplateResRef);
                    creature.gameObject.transform.position = position;
                    creature.gameObject.transform.rotation = rotation;
                    creature.gameObject.tag = "Creature";

                    creature.transform.SetParent(parent.transform);

                    SetLayerRecursive(creature.gameObject, LayerMask.NameToLayer("Creature"));

                    //Debug.Log(character.template);
                    stateManager.AddObject(((AuroraUTC)creature.template).Tag, creature);
                });
            }
        }

        private void LoadDoors()
        {
            List<AuroraGIT.ADoor> doors = git.DoorList;

            GameObject parent = new GameObject("Doors");
            parent.transform.SetParent(area.transform);

            foreach (AuroraGIT.ADoor d in doors)
            {
                loader.AddAction(() =>
                {

                    Vector3 position = new Vector3(d.X, d.Z, d.Y);

                    float bearing = d.Bearing;
                    Quaternion rotation = Quaternion.Euler(0, bearing * Mathf.Rad2Deg * -1, 0);

                    Door door = Resources.LoadDoor(d.TemplateResRef);
                    door.gameObject.transform.position = position;
                    door.gameObject.transform.rotation = rotation;
                    door.gameObject.tag = "Door";

                    SetLayerRecursive(door.gameObject, LayerMask.NameToLayer("NavMeshDynamic"));

                    // Save the rotation and reset it, so the NavMeshObstacle will
                    // rotate correctly with the door
                    Quaternion rot = door.transform.rotation;
                    door.transform.rotation = Quaternion.identity;

                    NavMeshObstacle obstacle = door.gameObject.AddComponent<NavMeshObstacle>();
                    Bounds b = getBounds(door.gameObject);

                    // All doors are the same height in KOTOR, fortunately
                    obstacle.center = new Vector3(0, 1.5f, 0);
                    obstacle.size = new Vector3(
                        b.size.x,
                        b.size.y,
                        b.size.z
                    );

                    obstacle.carving = true;

                    // Put back the original rotation, to rotate the obstacle correctly
                    door.transform.rotation = rot;

                    door.transform.SetParent(parent.transform);

                    string tag = ((AuroraUTD)door.template).Tag;
                    //if (d.Tag != null)
                    //{
                    //    tag = d.Tag;
                    //}

                    stateManager.AddObject(tag, door);
                });
            }
        }

        private void LoadPlaceables()
        {
            List<AuroraGIT.APlaceable> placeables = git.PlaceableList;
            Placeable placeable;

            GameObject parent = new GameObject("Placeables");
            parent.transform.SetParent(area.transform);

            foreach (var p in placeables)
            {
                loader.AddAction(() =>
                {
                    Vector3 position = new Vector3(p.X, p.Z, p.Y);

                    float bearing = p.Bearing;
                    Quaternion rotation = Quaternion.Euler(0, bearing * Mathf.Rad2Deg * -1, 0);

                    placeable = Resources.LoadPlaceable(p.TemplateResRef);
                    placeable.gameObject.transform.position = position;
                    placeable.gameObject.transform.rotation = rotation;
                    placeable.gameObject.tag = "Placeable";

                    SetLayerRecursive(placeable.gameObject, LayerMask.NameToLayer("NavMeshStatic"));

                    placeable.transform.SetParent(parent.transform);

                    stateManager.AddObject(((AuroraUTP)placeable.template).Tag, placeable);
                });
            }
        }

        private void LoadSounds()
        {
            List<AuroraGIT.ASound> sounds = git.SoundList;
            SoundPoint sound;

            GameObject parent = new GameObject("Sounds");
            parent.transform.SetParent(area.transform);

            foreach (var p in sounds)
            {
                loader.AddAction(() =>
                {
                    Vector3 position = new Vector3(p.XPosition, p.ZPosition, p.YPosition);

                    sound = Resources.LoadSound(p.TemplateResRef);
                    sound.gameObject.transform.position = position;

                    sound.transform.SetParent(parent.transform);

                    stateManager.AddObject(((AuroraUTS)sound.template).Tag, sound);
                });
            }
        }

        private void LoadStores()
        {
            List<AuroraGIT.AStore> stores = git.StoreList;
            Store store;

            GameObject parent = new GameObject("Stores");
            parent.transform.SetParent(area.transform);

            foreach (var p in stores)
            {
                loader.AddAction(() =>
                {
                    Vector3 position = new Vector3(p.XPosition, p.ZPosition, p.YPosition);

                    float x = p.XOrientation, y = p.YOrientation;
                    float bearing = Mathf.Tan(x / y);
                    Quaternion rotation = Quaternion.Euler(0, bearing * Mathf.Rad2Deg * -1, 0);

                    store = Resources.LoadStore(p.ResRef);
                    store.gameObject.transform.position = position;
                    store.gameObject.transform.rotation = rotation;

                    store.transform.SetParent(parent.transform);

                    stateManager.AddObject(((AuroraUTM)store.template).Tag, store);
                });
            }
        }
        private void LoadWaypoints()
        {
            List<AuroraGIT.AWaypoint> waypoints = git.WaypointList;
            Waypoint waypoint;

            GameObject parent = new GameObject("Waypoints");
            parent.transform.SetParent(area.transform);

            foreach (var p in waypoints)
            {
                loader.AddAction(() =>
                {
                    Vector3 position = new Vector3(p.XPosition, p.ZPosition, p.YPosition);

                    float x = p.XOrientation, y = p.YOrientation;
                    float bearing = Mathf.Tan(x / y);
                    Quaternion rotation = Quaternion.Euler(0, bearing * Mathf.Rad2Deg * -1, 0);

                    waypoint = Resources.LoadWaypoint(p.TemplateResRef);
                    waypoint.gameObject.transform.position = position;

                    waypoint.transform.SetParent(parent.transform);

                    string tag = ((AuroraUTW)waypoint.template).Tag;
                    //if (p.Tag != null)
                    //{
                    //    tag = p.Tag;
                    //}

                    stateManager.AddObject(tag, waypoint);
                });
            }
        }
        private void LoadCameras()
        {
            List<AuroraGIT.ACamera> cameras = git.CameraList;
            CameraPoint cam;

            GameObject parent = new GameObject("Cameras");
            parent.transform.SetParent(area.transform);

            foreach (var p in cameras)
            {
                loader.AddAction(() =>
                {
                    Vector3 position = p.Position;
                    Quaternion rotation = p.Orientation;

                    cam = CameraPoint.Create(p);
                    cam.gameObject.transform.position = position;

                    cam.transform.SetParent(parent.transform);
                    cameraPoints.Add(cam);
                });
            }
        }

        private void LoadTriggers()
        {
            List<AuroraGIT.ATrigger> triggers = git.TriggerList;
            Trigger trigger;

            GameObject parent = new GameObject("Triggers");
            parent.transform.SetParent(area.transform);

            foreach (var t in triggers)
            {
                loader.AddAction(() =>
                {
                    Vector3 position = new Vector3(t.XPosition, t.ZPosition, t.YPosition);
                    //Vector3 rotation = new Vector3(t.XOrientation, t.YOrientation, t.ZOrientation);

                    trigger = Resources.LoadTrigger(t.TemplateResRef);
                    trigger.gameObject.transform.position = position;
                    //trigger.gameObject.transform.rotation = Quaternion.Euler(rotation);

                    Mesh mesh = CreateMesh(t.Geometry);

                    trigger.gameObject.AddComponent<MeshRenderer>().enabled = false;
                    trigger.gameObject.AddComponent<MeshFilter>().mesh = mesh;

                    try
                    {
                        MeshCollider collider = trigger.gameObject.AddComponent<MeshCollider>();
                        collider.sharedMesh = mesh;
                        collider.convex = true;
                        collider.isTrigger = true;
                    }
                    catch
                    {

                    }


                    trigger.transform.SetParent(parent.transform);

                    string tag = ((AuroraUTT)trigger.template).Tag;
                    //if (t.Tag != null)
                    //{
                    //    tag = t.Tag;
                    //}

                    SetLayerRecursive(trigger.gameObject, LayerMask.NameToLayer("Trigger"));

                    stateManager.AddObject(tag, trigger);
                });
            }
        }

        private void LoadEncounters()
        {
            List<AuroraGIT.AEncounter> encounters = git.EncounterList;
            Encounter encounter;

            GameObject parent = new GameObject("Encounters");
            parent.transform.SetParent(area.transform);

            foreach (AuroraGIT.AEncounter e in encounters)
            {
                loader.AddAction(() =>
                {
                    Vector3 position = new Vector3(e.XPosition, e.ZPosition, e.YPosition);

                    encounter = Resources.LoadEncounter(e.TemplateResRef);
                    encounter.gameObject.transform.position = position;
                    //trigger.gameObject.transform.rotation = Quaternion.Euler(rotation);

                    Mesh mesh = CreateMesh(e.Geometry);

                    encounter.gameObject.AddComponent<MeshRenderer>().enabled = false;
                    encounter.gameObject.AddComponent<MeshFilter>().mesh = mesh;

                    MeshCollider collider = encounter.gameObject.AddComponent<MeshCollider>();
                    collider.sharedMesh = mesh;
                    collider.convex = true;
                    collider.isTrigger = true;

                    encounter.transform.SetParent(parent.transform);

                    stateManager.AddObject(((AuroraUTE)encounter.template).Tag, encounter);
                });
            }
        }

        Mesh CreateMesh(List<AuroraGIT.ATrigger.AGeometry> geometry)
        {
            // Construct a set of vertices above and below the trigger vertices
            Vector3[] allVertices = new Vector3[2 * geometry.Count];
            for (int i = 0; i < geometry.Count; i++)
            {
                Vector3 vertex = new Vector3(geometry[i].PointX, geometry[i].PointZ, geometry[i].PointY);

                allVertices[2 * i] = vertex + new Vector3(0, 5, 0);
                allVertices[2 * i + 1] = vertex - new Vector3(0, 5, 0);
            }

            return CreateFromVertices(allVertices, geometry.Count);
        }

        Mesh CreateMesh(List<AuroraGIT.AEncounter.AGeometry> geometry)
        {
            // Construct a set of vertices above and below the trigger vertices
            Vector3[] allVertices = new Vector3[2 * geometry.Count];
            for (int i = 0; i < geometry.Count; i++)
            {
                Vector3 vertex = new Vector3(geometry[i].X, geometry[i].Z, geometry[i].Y);

                allVertices[2 * i] = vertex + new Vector3(0, 5, 0);
                allVertices[2 * i + 1] = vertex - new Vector3(0, 5, 0);
            }

            return CreateFromVertices(allVertices, geometry.Count);
        }

        Mesh CreateFromVertices(Vector3[] allVertices, int geomCount)
        {
            // Construct a mesh: for 4 points:
            /*
             * A     C
             * 
             * 
             * B     D
             */

            // We create a triangle ACD/ADC and a triangle ABD/ADB
            // We therefore create four triangles for every vertex,
            int[] idx = new int[geomCount * 12];
            for (int i = 0; i < allVertices.Length; i += 2)
            {
                CreateTriangles(idx, i, allVertices);
            }

            // We are constructing the mesh 
            Mesh mesh = new Mesh();
            mesh.vertices = allVertices;
            mesh.triangles = idx;
            mesh.RecalculateNormals();
            mesh.RecalculateBounds();

            return mesh;

        }

        void CreateTriangles(int[] idx, int i, Vector3[] allVertices)
        {
            int A = i;
            int B = i + 1;
            int C = i + 2;
            int D = i + 3;

            // Check if this is wrapping around to the start vertex
            if (C >= allVertices.Count())
            {
                C = 0;
                D = 1;
            }

            // ACD
            idx[6 * i] = A;
            idx[6 * i + 1] = C;
            idx[6 * i + 2] = D;

            // ADC
            //idx[12 * i + 3] = A;
            //idx[12 * i + 4] = D;
            //idx[12 * i + 5] = C;

            // ABD
            idx[6 * i + 3] = A;
            idx[6 * i + 4] = B;
            idx[6 * i + 5] = D;

            // ADB
            //idx[12 * i + 9] = A;
            //idx[12 * i + 10] = D;
            //idx[12 * i + 11] = B;
        }

        public void OnEnter ()
        {
            stateManager.RunScript(are.OnEnter, area);
        }

        public void OnExit ()
        {
            stateManager.RunScript(are.OnExit, area);
        }

        public void OnHeartbeat ()
        {
            stateManager.RunScript(are.OnHeartbeat, area);
        }

        public void OnUserDefined ()
        {
            stateManager.RunScript(are.OnUserDefined, area);
        }
    }
}