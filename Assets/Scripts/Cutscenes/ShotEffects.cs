using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
// using UnityEngine.Networking.NetworkSystem;

public class MoveToLocation : ShotEffect
{
    public string objectName;
    public string waypointName;

    string template = @"
void main () {{
    ActionJumpToLocation(GetObjectByTag({0}), GetLocation(GetWaypointByTag({1})));
}}
    ";

    public override string GenerateScript()
    {
        return String.Format(template, '"' + objectName + '"', '"' + waypointName + '"');
    }

    public override void ShowEditor()
    {
        using (new EditorGUILayout.HorizontalScope())
        {
            GUILayout.Label("Object Name: ", GUILayout.Width(200));
            objectName = GUILayout.TextField(objectName);
        }
        using (new EditorGUILayout.HorizontalScope())
        {
            GUILayout.Label("Waypoint Name: ", GUILayout.Width(200));
            waypointName = GUILayout.TextField(waypointName);
        }
    }
}


public class FollowObject : ShotEffect
{
    public string subjectName;
    public string followObject;
    public float followDistance;

    string template = @"
void main () {{
    AssignCommand(GetObjectByTag({0}), ActionForceFollowObject(GetObjectByTag({1}), {2}));
}}
    ";

    public override string GenerateScript()
    {
        return String.Format(template, '"' + subjectName + '"', '"' + followObject + '"', followDistance);
    }

    public override void ShowEditor()
    {
        using (new EditorGUILayout.HorizontalScope())
        {
            GUILayout.Label("Object Name: ", GUILayout.Width(200));
            subjectName = GUILayout.TextField(subjectName);
        }
        using (new EditorGUILayout.HorizontalScope())
        {
            GUILayout.Label("Waypoint Name: ", GUILayout.Width(200));
            followObject = GUILayout.TextField(followObject);
        }
        using (new EditorGUILayout.HorizontalScope())
        {
            GUILayout.Label("Follow Distance: ", GUILayout.Width(200));
            followDistance = EditorGUILayout.FloatField(followDistance);
        }
    }
}

public class CutsceneAttack : ShotEffect
{
    public string attacker;
    public string target;
    public int animation, result, damage;

    string template = @"
void main () {{
    AssignCommand(GetObjectByTag({0}), CutsceneAttack(GetObjectByTag({1}), {2}, {3}, {4}));
}}
    ";

    public override string GenerateScript()
    {
        return String.Format(template, '"' + attacker + '"', '"' + target+ '"', animation, result, damage);
    }

    public override void ShowEditor()
    {
        using (new EditorGUILayout.HorizontalScope())
        {
            GUILayout.Label("Attacker: ", GUILayout.Width(200));
            attacker = GUILayout.TextField(attacker);
        }
        using (new EditorGUILayout.HorizontalScope())
        {
            GUILayout.Label("Target: ", GUILayout.Width(200));
            target = GUILayout.TextField(target);
        }
        using (new EditorGUILayout.HorizontalScope())
        {
            GUILayout.Label("Animation: ", GUILayout.Width(200));
            animation = EditorGUILayout.IntField(animation);
        }
        using (new EditorGUILayout.HorizontalScope())
        {
            GUILayout.Label("Result: ", GUILayout.Width(200));
            result = EditorGUILayout.IntField(result);
        }
        using (new EditorGUILayout.HorizontalScope())
        {
            GUILayout.Label("Damage: ", GUILayout.Width(200));
            damage = EditorGUILayout.IntField(damage);
        }
    }
}