using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoixPersoManager : MonoBehaviour
{
    public GameObject pannelButtonChoice;
    public GameObject prefabButtonChoice;

    // Start is called before the first frame update
    void Start()
    {
        // Path to the folder containing the sprites

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
        }
    }

}
