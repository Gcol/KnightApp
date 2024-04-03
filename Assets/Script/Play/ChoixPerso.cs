using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Runtime.CompilerServices;
using Newtonsoft.Json.Linq;


public class ChoixPerso : MonoBehaviour
{
    private GlobalInfo globalInfo;

    public Chevalier currentChevalier;
    public TextMeshProUGUI persoName;

    // Start is called before the first frame update
    void Start()
    {
        globalInfo = FindObjectOfType<SaveManager>().LoadGlobalInfo();
    }

    public void SelectChevalier()
    {
        globalInfo.lastChevalier = persoName.text;
        FindObjectOfType<SaveManager>().SaveData(globalInfo);
        FindAnyObjectByType<SceneLoader>().LoadScene("Menu");
    }

    public void SetChevalier(string newChevalier)
    {
        persoName.text = newChevalier;
    }
    public void SetChevalier(Chevalier newChevalier)
    {
        persoName.text = newChevalier.name;
        currentChevalier = newChevalier;
    }
}
