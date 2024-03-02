using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class ChoixPerso : MonoBehaviour
{

    public Chevalier currentChevalier;
    public GameManager currentGM;
    public TextMeshProUGUI persoName;

    // Start is called before the first frame update
    void Start()
    {
        currentGM = FindObjectOfType<GameManager>();
    }

    public void SelectChevalier()
    {

        Debug.Log("J'ai choisi " + currentChevalier.name);
        currentGM.ChooseAChevalier(currentChevalier);
    }

    public void SetChevalier(Chevalier newChevalier)
    {
        persoName.text = newChevalier.name;
        currentChevalier = newChevalier;
    }
}
