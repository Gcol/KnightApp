using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static Unity.Burst.Intrinsics.X86.Avx;

public class BlasonManager : MonoBehaviour
{

    public CreationPersoManager cMM;

    public GameObject tarotInfoPannel;
    public TextMeshProUGUI supInfoTitre;
    public Image supInfoImage;
    public TextMeshProUGUI supInfoText;
    public TextMeshProUGUI supInfoVoeu;
    public TextMeshProUGUI supInfoButton;

    public Blason currentObj;

    public void UpdatePerso()
    {
        cMM.UpdatePerso(currentObj);
    }
    // Start is called before the first frame update
    void Start()
    {
        cMM = FindObjectOfType<CreationPersoManager>();

    }

    public void PushButton(ButtonCreaPerso script)
    {
        currentObj = (Blason)script.entity;
        tarotInfoPannel.SetActive(true);
        supInfoImage.sprite = currentObj.grandImage;
        supInfoTitre.text = currentObj.name;
        supInfoText.text = currentObj.desc;
        supInfoVoeu.text = currentObj.voeu;
        supInfoButton.text = "Choissir le blason : " + currentObj.name;
    }
}
