using UnityEngine;
using UnityEditor;

public class PackageTool
{
    [MenuItem("Package/Update Package")]
    static void UpdatePackage()
    {
        AssetDatabase.ExportPackage("Assets/Anime4K", "Anime4K.unitypackage", ExportPackageOptions.Recurse);
    }
}
