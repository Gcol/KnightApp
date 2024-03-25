using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class ChoixMissionManager : MonoBehaviour
{
    public GameObject pannelButtonChoice;
    public GameObject prefabButtonChoice;

    public List<string> allMission =new List<string>();
    public string path = "Mission";

    // Start is called before the first frame update
    public void Init()
    {
        string folderPath = "Assets/Resources/Mission";

        string[] subDirectories = Directory.GetDirectories(folderPath);
        foreach (string subDir in subDirectories)
        {
            string[] pathParts = subDir.Split('\\');
            string folderName = pathParts[pathParts.Length - 1]; // Get the last part of the path as the folder name
            allMission.Add(folderName);
        }
        
    }

    public void GenMission()
    {
        if (allMission != null && allMission.Count > 0)
        {
            foreach (string currMission in allMission)
            {
                GameObject newPrefabInstance = Instantiate(prefabButtonChoice, pannelButtonChoice.transform);
                newPrefabInstance.GetComponent<ChoixMission>().SetMission(currMission);
            }
        }
        else
        {
            Debug.LogWarning("No mission found in the '" + path + "' folder.");
        }
    }

}