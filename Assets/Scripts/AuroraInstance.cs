using AuroraEngine;
using System;
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

    float CalculateBearing (Transform t)
    {
        // This is an angle between 0-360 degrees
        float yRot = t.rotation.eulerAngles.y;

        // Need to map between -180 to 180
        if (yRot > 180)
        {
            yRot -= 360;
        }

        return yRot * Mathf.Deg2Rad * -1;
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
                // This is an "xy vector pointing in the direction of the creature's orientation"
                aCreature.YOrientation = Mathf.Cos(CalculateBearing(transform));
                aCreature.XOrientation = Mathf.Sin(CalculateBearing(transform));
                break;
            case "Placeables":
                // TODO: Calculate bearing
                AuroraGIT.APlaceable aPlaceable = (AuroraGIT.APlaceable)gitData;
                aPlaceable.X = transform.position.x;
                aPlaceable.Y = transform.position.z;
                aPlaceable.Z = transform.position.y;

                // Bearing is in radians, measured counterclockwise from North
                aPlaceable.Bearing = CalculateBearing(transform);
                break;
            case "Doors":
                // TODO: Door orientation and transform information (link, etc.)
                AuroraGIT.ADoor aDoor = (AuroraGIT.ADoor)gitData;
                aDoor.X = transform.position.x;
                aDoor.Y = transform.position.z;
                aDoor.Z = transform.position.y;

                aDoor.Bearing = CalculateBearing(transform);
                break;
            case "Triggers":
                AuroraGIT.ATrigger aTrigger = (AuroraGIT.ATrigger)gitData;

                aTrigger.XPosition = transform.position.x;
                aTrigger.YPosition = transform.position.z;
                aTrigger.ZPosition = transform.position.y;

                // This doesn't matter, and should be zero, according to BioWare documentation
                aTrigger.XOrientation = 0f;
                aTrigger.YOrientation = 0f;
                aTrigger.ZOrientation = 0f;
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
                break;
            case "Stores":
                // TODO: Orientation
                AuroraGIT.AStore aStore = (AuroraGIT.AStore)gitData;
                aStore.XPosition = transform.position.x;
                aStore.YPosition = transform.position.z;
                aStore.ZPosition = transform.position.y;

                // This is an "xy vector pointing in the direction of the creature's orientation"
                aStore.YOrientation = Mathf.Cos(CalculateBearing(transform));
                aStore.XOrientation = Mathf.Sin(CalculateBearing(transform));
                break;
            case "Waypoints":
                AuroraGIT.AWaypoint aWaypoint = (AuroraGIT.AWaypoint)gitData;
                aWaypoint.XPosition = transform.position.x;
                aWaypoint.YPosition = transform.position.z;
                aWaypoint.ZPosition = transform.position.y;

                // This is an "xy vector pointing in the direction of the creature's orientation"
                aWaypoint.YOrientation = Mathf.Cos(CalculateBearing(transform));
                aWaypoint.XOrientation = Mathf.Sin(CalculateBearing(transform));
                break;
            case "Cameras":
                AuroraGIT.ACamera aCamera = (AuroraGIT.ACamera)gitData;
                // Don't ask me why we don't flip y and z here, I don't know :P
                aCamera.Position = new Vector3(
                    transform.position.x,
                    transform.position.y,
                    transform.position.z
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
                AuroraGIT.ACreature creature = (AuroraGIT.ACreature)gitData;
                creature.structid = 4;
                git.CreatureList.Add(creature);
                break;
            case "Placeables":
                AuroraGIT.APlaceable placeable = (AuroraGIT.APlaceable)gitData;
                placeable.structid = 9;
                git.PlaceableList.Add(placeable);
                break;
            case "Doors":
                AuroraGIT.ADoor door = (AuroraGIT.ADoor)gitData;
                door.structid = 8;
                git.DoorList.Add(door);
                break;
            case "Triggers":
                AuroraGIT.ATrigger trigger = (AuroraGIT.ATrigger)gitData;
                trigger.structid = 1;
                git.TriggerList.Add(trigger);
                break;
            case "Encounters":
                AuroraGIT.AEncounter encounter = (AuroraGIT.AEncounter)gitData;
                encounter.structid = 7;
                git.EncounterList.Add(encounter);
                break;
            case "Sounds":
                AuroraGIT.ASound sound = (AuroraGIT.ASound)gitData;
                sound.structid = 6;
                git.SoundList.Add(sound);
                break;
            case "Stores":
                AuroraGIT.AStore store = (AuroraGIT.AStore)gitData;
                store.structid = 11;
                git.StoreList.Add(store);
                break;
            case "Waypoints":
                AuroraGIT.AWaypoint waypoint = (AuroraGIT.AWaypoint)gitData;
                waypoint.structid = 5;
                git.WaypointList.Add(waypoint);
                break;
            case "Cameras":
                AuroraGIT.ACamera cam = (AuroraGIT.ACamera)gitData;
                cam.structid = 14;
                git.CameraList.Add(cam);
                break;
            default:
                throw new System.Exception("Unknown parent " + transform.parent.name + " found.");
        }
    }
}
