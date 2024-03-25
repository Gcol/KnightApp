using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapacitéManager : MonoBehaviour
{
    public Chevalier currentChevalier;
    public GameObject capacitePrefab;

    public void InitCapacite(Chevalier newChevalier)
    {
        currentChevalier = newChevalier;
        foreach (Capacite currentCapacite in currentChevalier.armure.allCapacite)
        {

            GameObject newCapa = Instantiate(capacitePrefab, transform);
            newCapa.GetComponent<CapaciteShower>().InitCapacite(currentCapacite);
        }

    }


}
