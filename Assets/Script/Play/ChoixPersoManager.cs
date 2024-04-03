using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class ChoixPersoManager : MonoBehaviour
{
    public GameObject prefabButtonChoice;
    private GridLayoutGroup GridLayoutGroup;

    // Start is called before the first frame update
    void Start()
    {
        GridLayoutGroup = GetComponent<GridLayoutGroup>();
        // Path to the folder containing the sprites

        string folderPath = Application.persistentDataPath + $"/Caracter/";
        string[] saveFiles = Directory.GetFiles(folderPath);
        Debug.Log("Save files in directory:");
        foreach (string saveFile in saveFiles)
        {
            string[] pathParts = saveFile.Split('/');
            string fileName = pathParts[pathParts.Length - 1].Replace(".json","");
            GameObject newPrefabInstance = Instantiate(prefabButtonChoice, transform);
            newPrefabInstance.GetComponent<ChoixPerso>().SetChevalier(fileName);
        }/*
        // Load all assets at the specified path
        Chevalier[] allChevalier = Resources.LoadAll<Chevalier>("Chevalier");

        // Iterate through each asset
        if (allChevalier != null && allChevalier.Length > 0)
        {
            foreach (Chevalier currChevalier in allChevalier)
            {
                GameObject newPrefabInstance = Instantiate(prefabButtonChoice, pannelButtonChoice.transform);
                newPrefabInstance.GetComponent<ChoixPerso>().SetChevalier(currChevalier);
            }
        }
        else
        {
            Debug.LogWarning("No chevalier found in the 'Cheval' folder.");
        }*/
    }

}
