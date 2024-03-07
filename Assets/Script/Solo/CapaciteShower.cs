using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CapaciteShower : MonoBehaviour
{
    public GameObject currentPannel;
    public GameObject subEffectPrefab;
    public object currentCapacite;
    public bool pannelShow;

    public void InitCapacite(Object newCapacite)
    {
        pannelShow = false;
        currentCapacite = newCapacite;

        transform.Find("Haut/Text (TMP)").gameObject.GetComponent<TextMeshProUGUI>().text = newCapacite.name;
        if (newCapacite is CapaciteArmure)
            InitText((CapaciteArmure)newCapacite);

        if (newCapacite is CapaciteTextOnly)
            InitText((CapaciteTextOnly)newCapacite);

        if (newCapacite is CapaciteSansDegat)
            InitText((CapaciteSansDegat)newCapacite);
        currentPannel.SetActive(false);
    }

    public void InitText(CapaciteTextOnly newCapacite)
    {
        string currentPannel = "TextCapacite";
        Transform effectPannel = transform.Find("Panel/" + currentPannel + "/EffectPannel");
        transform.Find("Panel/" + currentPannel + "/Name/name").gameObject.GetComponent<TextMeshProUGUI>().text = newCapacite.mainName;
        transform.Find("Panel/" + currentPannel + "/Name/Desc").gameObject.GetComponent<TextMeshProUGUI>().text = newCapacite.mainDesc;
        transform.Find("Panel/" + currentPannel).gameObject.SetActive(true);

        for (int i = 0; i < newCapacite.enteteText.Count; i++)
        {
            Transform newSubPannel = Instantiate(subEffectPrefab, effectPannel).transform;
            newSubPannel.Find("Name/Name").gameObject.GetComponent<TextMeshProUGUI>().text = newCapacite.enteteText[i];
            newSubPannel.Find("Desc").gameObject.GetComponent<TextMeshProUGUI>().text = newCapacite.allText[i];
        }        
    }

    public void InitText(CapaciteSansDegat newCapacite)
    {
        string currentPannel = "SansDegatCapacite";
        transform.Find("Panel/" + currentPannel).gameObject.SetActive(true);
        transform.Find("Panel/" + currentPannel + "/Effet").gameObject.GetComponent<TextMeshProUGUI>().text = newCapacite.effet;
        transform.Find("Panel/" + currentPannel + "/Value/Energie").gameObject.GetComponent<TextMeshProUGUI>().text = newCapacite.energiCout;
        transform.Find("Panel/" + currentPannel + "/Value/Durée").gameObject.GetComponent<TextMeshProUGUI>().text = newCapacite.duree;
        transform.Find("Panel/" + currentPannel + "/Value/Activation").gameObject.GetComponent<TextMeshProUGUI>().text = newCapacite.activation;

    }

    public void InitText(CapaciteArmure newCapacite)
    {
        string currentPannel = "DegatCapacite";
        transform.Find("Panel/" + currentPannel).gameObject.SetActive(true);
        transform.Find("Panel/" + currentPannel + "/Effet").gameObject.GetComponent<TextMeshProUGUI>().text = newCapacite.effet;

        string textDegat = newCapacite.nbDiceDegat + "D";
        if (newCapacite.degatBonus != 0)
            textDegat += " + " + newCapacite.degatBonus;

        string textViolence = newCapacite.nbDiceViolence + "D";
        if (newCapacite.violenceBonus != 0)
            textViolence += " + " + newCapacite.violenceBonus;

        transform.Find("Panel/" + currentPannel + "/Value/Degat").gameObject.GetComponent<TextMeshProUGUI>().text = textDegat;
        transform.Find("Panel/" + currentPannel + "/Value/Violence").gameObject.GetComponent<TextMeshProUGUI>().text = textViolence;
        transform.Find("Panel/" + currentPannel + "/Value/Energie").gameObject.GetComponent<TextMeshProUGUI>().text = newCapacite.energiCout;
        transform.Find("Panel/" + currentPannel + "/Value/Porté").gameObject.GetComponent<TextMeshProUGUI>().text = newCapacite.portee;
        transform.Find("Panel/" + currentPannel + "/Value/Durée").gameObject.GetComponent<TextMeshProUGUI>().text = newCapacite.duree;
        transform.Find("Panel/" + currentPannel + "/Value/Activation").gameObject.GetComponent<TextMeshProUGUI>().text = newCapacite.activation;
    }



    public void ShowPannel()
    {
        pannelShow = !pannelShow;
        currentPannel.SetActive(pannelShow);
    }
}
