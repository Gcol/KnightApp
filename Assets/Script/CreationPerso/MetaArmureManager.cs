using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class MetaArmureManager : MonoBehaviour
{
    public CreationPersoManager cMM;

    public TextMeshProUGUI textMeshProPrefab;

    public GameObject PannelInfoPannel;
    public GameObject PannelMetaArmureAff;
    public TextMeshProUGUI supInfoTitre;
    public Image supInfoImage;

    public GameObject CapacitePrefab;
    public GameObject EvolutionPrefab;


    public TextMeshProUGUI boutonText;

    public List<GameObject> objectToDestroy =  new List<GameObject>();

    public Armure currentArmure;

    public void UpdatePerso()
    {

        cMM.UpdatePerso(currentArmure);
        PannelMetaArmureAff.SetActive(true);    
    }

    public void Clean()
    {
        foreach (GameObject toDestroy in objectToDestroy)
        {
            Destroy(toDestroy);
        }
    }




    public void PushButton(Armure cObjct)
    {
        currentArmure = cObjct;
        PannelInfoPannel.SetActive(true);
        Clean();
        supInfoImage.sprite = cObjct.currentSprite;

        Transform stat = PannelInfoPannel.transform.Find("Stat");
        Transform module = PannelInfoPannel.transform.Find("Module");
        Transform overdrive = PannelInfoPannel.transform.Find("Overdrive").Find("OD");
        Transform capacitePannel = PannelInfoPannel.transform.Find("Capacite");
        Transform evolutionPannel = PannelInfoPannel.transform.Find("Evolution");


        UpdateStat(stat, "PA", cObjct.PointArmure.ToString());
        UpdateStat(stat, "PE", cObjct.PointEnergie.ToString());
        UpdateStat(stat, "CdF", cObjct.ChampDeForce.ToString());
        UpdateStat(stat, "Gen", cObjct.generationMetaArmure.ToString());


        //foreach(moduleSlot currMs in cObjct.slot)
        //{
        //    module.Find(currMs.nameSlot).GetComponent<TextMeshProUGUI>().text  = currMs.number.ToString();  
        //}

        foreach (caractéristique currC in cObjct.overdrive)
        {
            TextMeshProUGUI newCarac = Instantiate(textMeshProPrefab, overdrive);
            newCarac.text = "•" + currC.ToString();
            newCarac.gameObject.SetActive(true);
            objectToDestroy.Add(newCarac.gameObject);
        }

        foreach(Capacite capacite in cObjct.allCapacite)
        {
            GameObject newCapacite = Instantiate(CapacitePrefab, capacitePannel);
            newCapacite.GetComponent<CapaciteShower>().InitCapacite(capacite);
            objectToDestroy.Add(newCapacite);

        }

        foreach (evolutionStr evolution in cObjct.evolution)
        {
            GameObject newEvol = Instantiate(EvolutionPrefab, evolutionPannel);
            newEvol.transform.Find("CoutPg").GetComponent<TextMeshProUGUI>().text = evolution.numberPG.ToString();
            newEvol.transform.Find("Desc").GetComponent<TextMeshProUGUI>().text = evolution.effect;
            objectToDestroy.Add(newEvol);

        }

        supInfoTitre.text = cObjct.name;

        boutonText.text = "Selectionner l'amure : " + cObjct.name;
    }

    public void UpdateStat(Transform stat, string statName, string valueStat)
    {
        stat.Find(statName).Find("Value").Find("Value").GetComponent<TextMeshProUGUI>().text = valueStat;    
    }


}
