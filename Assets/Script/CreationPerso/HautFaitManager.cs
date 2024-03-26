using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HautFaitManager : MonoBehaviour
{
    public CreationPersoManager cMM;

    public GameObject PannelInfoPannel;
    public TextMeshProUGUI supInfoTitre;
    public Image supInfoImage;
    public TextMeshProUGUI supInfoText;
    public TextMeshProUGUI supInfoBonus;
    public TextMeshProUGUI supInfoCondition;
    public TextMeshProUGUI supInfoSurnom;

    public TextMeshProUGUI boutonText;


    public HautFait currentObj;

    public void UpdatePerso()
    {
        cMM.UpdatePerso(currentObj);
    }
    public void PushButton(HautFait cObjct)
    {
        currentObj = cObjct;
        PannelInfoPannel.SetActive(true);
        supInfoImage.sprite = cObjct.grandImage;
        supInfoTitre.text = cObjct.name;
        supInfoText.text = cObjct.desc;
        supInfoCondition.text = cObjct.Condition;
        supInfoSurnom.text = "Surnom : " + cObjct.Surnoms;
        supInfoBonus.text = "Bonus : " + cObjct.Bonus;
        boutonText.text = "Selectionner le haut fait : " + cObjct.name;
    }
}
