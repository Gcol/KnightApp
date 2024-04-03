using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModuleManager : MonoBehaviour
{
    public Chevalier currentChevalier;
    public GameObject currentPrefab;


    public void currentInit(Chevalier newChevalier)
    {
        currentChevalier = newChevalier;
        /*
        foreach (ModuleBase currentModule in newChevalier.allModule)
        {
            GameObject newModule = Instantiate(currentPrefab, transform);
            newModule.GetComponent<ModuleShower>().InitModule(currentModule);
        }*/
    }
       

}
