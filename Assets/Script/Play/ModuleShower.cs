using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ModuleShower : MonoBehaviour
{
    ModuleBase currentModule;
    public GameObject currentPannel;
    public bool activate;

    public void InitModule(ModuleBase newModule)
    {
        activate = false;
        string pannelName = "";
        currentModule = newModule;
        transform.Find("Name").gameObject.GetComponent<TextMeshProUGUI>().text = currentModule.name;
        if (currentModule.effet != "" && currentModule.portee != "")
        {
            pannelName = "ModuleEffetPorte";
            transform.Find("Panel/" + pannelName + "/Bas/Effet").GetComponent<TextMeshProUGUI>().text = currentModule.effet;
            transform.Find("Panel/" + pannelName + "/Bas/Portée").GetComponent<TextMeshProUGUI>().text = currentModule.portee;

        }
        else if (currentModule.effet != "")
        {
            pannelName = "ModuleEffet";
            transform.Find("Panel/" + pannelName + "/Bas/Effet").GetComponent<TextMeshProUGUI>().text = currentModule.effet;

        }
        else if (currentModule.portee != "")
        {
            if(currentModule.energie != "")
                pannelName = "ModulePorte";
            else
                pannelName = "ModulePorteSansEnergi";
            transform.Find("Panel/" + pannelName + "/Bas/Portée").GetComponent<TextMeshProUGUI>().text = currentModule.portee;

        }
        else
            pannelName = "ModuleBase";

        if (currentModule.energie != "")
            transform.Find("Panel/" + pannelName + "/Bas/Energie").GetComponent<TextMeshProUGUI>().text = currentModule.energie;

        transform.Find("Panel/" + pannelName).gameObject.SetActive(true);
        transform.Find("Panel/" + pannelName + "/Bas/Activation").GetComponent<TextMeshProUGUI>().text = currentModule.activation;
        transform.Find("Panel/" + pannelName + "/Bas/Duree").GetComponent<TextMeshProUGUI>().text = currentModule.duree;
        transform.Find("Panel/Desc/Desc").GetComponent<TextMeshProUGUI>().text = currentModule.description;

    }

    public void PushButton()
    {
        activate = !activate;
        currentPannel.SetActive(activate);
    }
}
