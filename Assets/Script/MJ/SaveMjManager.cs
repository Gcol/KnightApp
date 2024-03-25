using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

[Serializable]
public class MjInfo
{
    public string mission;
    public int missionIndex;

}
public class SaveMjManager : MonoBehaviour
{

    public string filePathMj ;


    public MjInfo LoadMjInfo()
    {
        filePathMj = Application.persistentDataPath + $"/Mj.json";
        if (File.Exists(filePathMj))
        {
            string json = File.ReadAllText(filePathMj);
            return JsonUtility.FromJson<MjInfo>(json);
        }
        return new MjInfo();
    }
    public void SaveMjInfo(MjInfo mjInfo)
    {
        File.WriteAllText(filePathMj, JsonUtility.ToJson(mjInfo));
    }

}
