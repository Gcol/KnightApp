using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ArchetypeManager : MonoBehaviour
{
    public CreationPersoManager cMM;

    public GameObject PannelInfoPannel;
    public TextMeshProUGUI supInfoTitre;
    public Image supInfoImage;
    public TextMeshProUGUI supInfoText;
    public TextMeshProUGUI supInfoBonus;

    public TextMeshProUGUI boutonText;


    public Archetype currentObj;

    public void UpdatePerso()
    {
        cMM.UpdatePerso(currentObj);
    }


    public void PushButton(Archetype cObjct)
    {
        currentObj = cObjct;
        PannelInfoPannel.SetActive(true);
        supInfoImage.sprite = cObjct.grandImage;
        supInfoTitre.text = cObjct.name;
        supInfoText.text = cObjct.desc;
        supInfoBonus.text = "Bonus : " + cObjct.bonus;
        boutonText.text = "Selectionner l'archetype : " + cObjct.name;
    }
}
