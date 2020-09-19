using AuroraEngine;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

[ExecuteInEditMode]
public class AuroraInstance : MonoBehaviour
{
    public AuroraStruct gitData;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gitData == null)
        {
            return;
        }
        // Update the GIT with information on this 
        switch (transform.parent.name)
        {
            case "Creatures":
                AuroraGIT.ACreature aCreature = (AuroraGIT.ACreature)gitData;
                aCreature.XPosition = transform.position.x;
                aCreature.YPosition = transform.position.z;
                aCreature.ZPosition = transform.position.y;

                // Calculate orientation from bearing
                float yRot = transform.rotation.eulerAngles.y;
                float bearing = yRot * Mathf.Deg2Rad * -1;
                Debug.Log(bearing);
                aCreature.YOrientation = Mathf.Sin(bearing);
                aCreature.XOrientation = Mathf.Cos(bearing);
                break;
            case "Placeables":
                // TODO: Calculate bearing
                AuroraGIT.APlaceable aPlaceable = (AuroraGIT.APlaceable)gitData;
                aPlaceable.X = transform.position.x;
                aPlaceable.Y = transform.position.z;
                aPlaceable.Z = transform.position.y;

                aPlaceable.Bearing = transform.rotation.y * Mathf.Deg2Rad * -1;
                break;
            case "Doors":
                // TODO: Door orientation and transform information (link, etc.)
                AuroraGIT.ADoor aDoor = (AuroraGIT.ADoor)gitData;
                aDoor.X = transform.position.x;
                aDoor.Y = transform.position.z;
                aDoor.Z = transform.position.y;

                aDoor.Bearing = transform.rotation.y * Mathf.Deg2Rad * -1;
                break;
            case "Triggers":
                AuroraGIT.ATrigger aTrigger = (AuroraGIT.ATrigger)gitData;

                aTrigger.XPosition = transform.position.x;
                aTrigger.YPosition = transform.position.z;
                aTrigger.ZPosition = transform.position.y;

                // Not convinced by this...
                aTrigger.XOrientation = transform.rotation.eulerAngles.x;
                aTrigger.YOrientation = transform.rotation.eulerAngles.y;
                aTrigger.ZOrientation = transform.rotation.eulerAngles.z;
                break;
            case "Encounters":
                // TODO: Encounter geometry and spawn points
                AuroraGIT.AEncounter aEncounter = (AuroraGIT.AEncounter)gitData;
                aEncounter.XPosition = transform.position.x;
                aEncounter.YPosition = transform.position.z;
                aEncounter.ZPosition = transform.position.y;
                break;
            case "Sounds":
                // TODO: Sound orientation and data
                AuroraGIT.ASound aSound = (AuroraGIT.ASound)gitData;
                aSound.XPosition = transform.position.x;
                aSound.YPosition = transform.position.z;
                aSound.ZPosition = transform.position.y;

                // Calculate orientation from bearing
                float ySoundRot = transform.rotation.eulerAngles.y;
                float soundBearing = ySoundRot * Mathf.Deg2Rad * -1;
                aSound.YOrientation = Mathf.Sin(soundBearing);
                aSound.XOrientation = Mathf.Cos(soundBearing);
                break;
            case "Stores":
                // TODO: Orientation
                AuroraGIT.AStore aStore = (AuroraGIT.AStore)gitData;
                aStore.XPosition = transform.position.x;
                aStore.YPosition = transform.position.z;
                aStore.ZPosition = transform.position.y;

                // Calculate orientation from bearing
                float yStoreRot = transform.rotation.eulerAngles.y;
                float storeBearing = yStoreRot * Mathf.Deg2Rad * -1;
                aStore.YOrientation = Mathf.Sin(storeBearing);
                aStore.XOrientation = Mathf.Cos(storeBearing);
                break;
            case "Waypoints":
                AuroraGIT.AWaypoint aWaypoint = (AuroraGIT.AWaypoint)gitData;
                aWaypoint.XPosition = transform.position.x;
                aWaypoint.YPosition = transform.position.z;
                aWaypoint.ZPosition = transform.position.y;

                // Calculate orientation from bearing
                float yWaypointRot = transform.rotation.eulerAngles.y;
                float waypointBearing = yWaypointRot * Mathf.Deg2Rad * -1;
                aWaypoint.YOrientation = Mathf.Sin(waypointBearing);
                aWaypoint.XOrientation = Mathf.Cos(waypointBearing);
                break;
            case "Cameras":
                // TODO: Orientation (have to map the Quaternions I think)
                AuroraGIT.ACamera aCamera = (AuroraGIT.ACamera)gitData;
                aCamera.Position = new Vector3(
                    transform.position.x,
                    transform.position.z,
                    transform.position.y
                );

                // To reverse the quaternion map, we do the
                // exact same transformation as the original map!
                aCamera.Orientation = new Quaternion(
                    -transform.rotation.x,
                    -transform.rotation.z,
                    -transform.rotation.y,
                    transform.rotation.w
                );
                break;
            default:
                break;
        }
    }
    public void Initialize(AuroraStruct gitData)
    {
        this.gitData = gitData;
    }

    public void BuildGIT (AuroraGIT git)
    {
        // Update the GIT with information on this 
        switch (transform.parent.name)
        {
            case "Creatures":
                git.CreatureList.Add((AuroraGIT.ACreature)gitData);
                break;
            case "Placeables":
                git.PlaceableList.Add((AuroraGIT.APlaceable)gitData);
                break;
            case "Doors":
                git.DoorList.Add((AuroraGIT.ADoor)gitData);
                break;
            case "Triggers":
                git.TriggerList.Add((AuroraGIT.ATrigger)gitData);
                break;
            case "Encounters":
                git.EncounterList.Add((AuroraGIT.AEncounter)gitData);
                break;
            case "Sounds":
                git.SoundList.Add((AuroraGIT.ASound)gitData);
                break;
            case "Stores":
                git.StoreList.Add((AuroraGIT.AStore)gitData);
                break;
            case "Waypoints":
                git.WaypointList.Add((AuroraGIT.AWaypoint)gitData);
                break;
            case "Cameras":
                git.CameraList.Add((AuroraGIT.ACamera)gitData);
                break;
            default:
                break;
        }
    }
}
