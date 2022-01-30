﻿using System;
using System.Reflection;


public class PrefabSavingUtil {

    public static void SavePrefab(UnityEditor.SceneManagement.PrefabStage prefabStage)
    {
        if (prefabStage == null)
            throw new ArgumentNullException();

        var savePrefabMethod = prefabStage.GetType().GetMethod("SavePrefab", BindingFlags.NonPublic | BindingFlags.Instance);
        if (savePrefabMethod == null)
            throw new InvalidOperationException();

        savePrefabMethod.Invoke(prefabStage, null);
    }
}
