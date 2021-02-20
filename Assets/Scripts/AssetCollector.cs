using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class AssetCollector : EditorWindow
{
    [MenuItem("Window/Asset Collecter")]
    public static void ShowWindow()
    {
        GetWindow(typeof(AssetCollector));
    }

    Vector2 scroll;
    List<string> assetPaths = new List<string>();
    GameObject[] gameObjectsInHeirarchy;
    List<string> guidsOfGameObjects = new List<string>();
    List<long> localIdOfGameObjects = new List<long>();

    private void OnGUI()
    {
        GUILayout.Label("My string", EditorStyles.boldLabel);
        scroll = GUILayout.BeginScrollView(scroll);
        PrintAssets();
        GetAllGameObjects();
        PrintGameObjectsName();

        //foreach (GameObject gameObject in gameObjectsInHeirarchy)
        //{
        //    if (AssetDatabase.TryGetGUIDAndLocalFileIdentifier(gameObject, out string guid, out long localId))
        //    {
        //        Debug.Log(gameObject.name + " " + guid + " " + localId);
        //    }
        //    else
        //    {
        //        Debug.Log("try function not executed");
        //    }
        //}
        GUILayout.EndScrollView();
    }

    private void PrintGameObjectsName()
    {
        foreach(GameObject gameObject in gameObjectsInHeirarchy)
        {
            Debug.Log(gameObject.name + gameObject);
        }
    }

    private void PrintAssets()
    {
        foreach (string s in AssetDatabase.GetAllAssetPaths())
        {
            
            if (s.StartsWith("Assets/") && !(s.Contains("TextMesh Pro")))
            {
                GUILayout.Label(s);
                assetPaths.Add(s);
            }
        }
    }

    private void GetAllGameObjects()
    {
        gameObjectsInHeirarchy = FindObjectsOfType<GameObject>();
    }
}
