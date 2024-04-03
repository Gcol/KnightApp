using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public Chevalier currentChevalier;
    public GameObject currentPrefab;


    public void currentInit(Chevalier newChevalier)
    {
        currentChevalier = newChevalier;

        foreach (Arme currentWeapon in newChevalier.allWeapon)
        {
            GameObject newModule = Instantiate(currentPrefab, transform);
            //newModule.GetComponent<Arme>().Init(currentWeapon);
        }
    }
}
