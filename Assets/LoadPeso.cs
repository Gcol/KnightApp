using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LoadPeso : MonoBehaviour
{
    public GlobalInfo globalInfo;

    public List<Button> persoSelected;

    // Start is called before the first frame update
    void Start()
    {
        globalInfo = FindObjectOfType<SaveManager>().LoadGlobalInfo();
        Debug.Log(globalInfo.lastChevalier);
        if (globalInfo.lastChevalier != null)
        {
            UpdateButton(true);
            transform.Find("Menu").Find("TitreBienvenue").GetComponent<TextMeshProUGUI>().text = "Bienvenue " + globalInfo.lastChevalier;

        }
        else
            UpdateButton(false);


    }

    void UpdateButton(bool isPersoSelected)
    {
        foreach (Button currentButton in persoSelected)
            currentButton.gameObject.SetActive(isPersoSelected);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
