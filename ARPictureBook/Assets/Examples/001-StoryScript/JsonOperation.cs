using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UnityEngine;

public class JsonOperation
{

    public static void FirstLoad(string fileName)
    {

        TextAsset t = (TextAsset)Resources.Load(fileName);
        string json = t.text.ToString().Trim();
        FileStream fs = new FileStream(GlobalConfig.GetFilePath(fileName), FileMode.Create);
        byte[] bytes = new UTF8Encoding().GetBytes(json.ToString());
        fs.Write(bytes, 0, bytes.Length);
        fs.Close();
    }

    public static T ReadFile<T>(string fileName)
    {

        FileInfo t = new FileInfo(fileName);
        if (!t.Exists)
        {
            Debug.Log("can not find file");
        }
        StreamReader sr = null;

        sr = File.OpenText(GlobalConfig.GetFilePath(fileName));

        string json = sr.ReadToEnd();

        T GameDataByJson = JsonUtility.FromJson<T>(json);
        sr.Close();
        sr.Dispose();

        Debug.Log("读取完成");

        return GameDataByJson;

    }

    public static void WriteFile<T>(string fileName, T GameDataToJson)
    {
        string str = JsonUtility.ToJson(GameDataToJson);

        FileStream fs = new FileStream(GlobalConfig.GetFilePath(fileName), FileMode.Create);
        byte[] bytes = new UTF8Encoding().GetBytes(str.ToString());
        fs.Write(bytes, 0, bytes.Length);
        fs.Close();
        Debug.Log("写入完成");
    }


}
