using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SectionManager : MonoBehaviour
{
    public CreationPersoManager cMM;

    public GameObject PannelInfoPannel;
    public TextMeshProUGUI supInfoTitre;
    public Image supInfoImage;
    public TextMeshProUGUI supInfoDesc;
    public TextMeshProUGUI supInfoBonus;
    public TextMeshProUGUI supInfoAv;
    public TextMeshProUGUI supInfoDaV;


    public TextMeshProUGUI boutonText;

    public SectionKnight currentObj;

    public void UpdatePerso()
    {
        cMM.UpdatePerso(currentObj);
    }

    public void PushButton(SectionKnight cObjct)
    {
        currentObj = cObjct;
        PannelInfoPannel.SetActive(true);
        supInfoImage.sprite = cObjct.grandImage;
        supInfoTitre.text = cObjct.name;
        supInfoDesc.text = cObjct.desc;
        supInfoBonus.text = "Bonus : " + cObjct.Bonus;
        supInfoAv.text = cObjct.Avantage;
        supInfoDaV.text = cObjct.Inconvenient;
        boutonText.text = "Selectionner la section : " + cObjct.name;
    }
}
