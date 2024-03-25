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
    // Start is called before the first frame update
    void Start()
    {
        cMM = FindObjectOfType<CreationPersoManager>();

    }

    public void PushButton(Blason blason)
    {
        tarotInfoPannel.SetActive(true);
        supInfoImage.sprite = blason.grandImage;
        supInfoTitre.text = blason.name;
        supInfoText.text = blason.desc;
        supInfoVoeu.text = blason.voeu;
        supInfoButton.text = "Choissir le blason : " + blason.name;
    }
}
