using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalConfig
{

    public static string GetFilePath(string fileName)
    {
        string filePath = "";

#if UNITY_STANDALONE_WIN
        //Debug.Log("UNITY_STANDALONE_WIN");
        filePath = Application.persistentDataPath + "/" + fileName + ".json";
#endif
#if UNITY_ANDROID
        filePath = Application.persistentDataPath + "/" + fileName + ".json";
#endif
#if UNITY_EDITOR
       // Debug.Log("UNITY_EDITOR");
        filePath = "Assets/Resources/" + fileName + ".json";
#endif

        return filePath;
    }
}

