using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class TarotManager : MonoBehaviour
{
    public TextMeshProUGUI objectif;

    public CreationPersoManager cMM;

    public GameObject tarotInfoPannel;
    public TextMeshProUGUI supInfoTitre;
    public Image supInfoImage;
    public TextMeshProUGUI supInfoText;
    public TextMeshProUGUI supInfoPasse;
    public TextMeshProUGUI supInfoBonus;
    public Button supInfoAvJButton;
    public TextMeshProUGUI supInfoAvJ;
    public Button supInfoAvIAButton;
    public TextMeshProUGUI supInfoAvIA;
    public Button supInfoDavJButton;
    public TextMeshProUGUI supInfoDavJ;
    public Button supInfoDavIAButton;
    public TextMeshProUGUI supInfoDavIA;



    public Tarot currentObj;

    public void UpdatePerso()
    {
        cMM.UpdatePerso(currentObj);
    }
    // Start is called before the first frame update
    void Start()
    {
        cMM = FindObjectOfType<CreationPersoManager>();
        UpdateObjectif();

    }

    void UpdateObjectif()
    {
        objectif.text = "Selectionner:\n";
        if (cMM.taroDeck.avJ == null)
            objectif.text += "2 Avantage Joueur\n";
        else if (cMM.taroDeck.avJ.Count < 2)
            objectif.text += (2 - cMM.taroDeck.avJ.Count) + " Avantage Joueur\n";
        if (cMM.taroDeck.DavJ == null)
            objectif.text += "1 Desavantage Joueur\n";
        if (cMM.taroDeck.avIa == null)
            objectif.text += "1 Avantage IA\n";
        if (cMM.taroDeck.DavIa == null)
            objectif.text += "1 Desavantage IA\n";
    }

    public void PushButton(Tarot tarotCard)
    {
        currentObj = tarotCard;
        tarotInfoPannel.SetActive(true);
        supInfoImage.sprite = tarotCard.currentSprite;
        supInfoTitre.text = tarotCard.name;
        supInfoText.text = tarotCard.desc;
        supInfoPasse.text = "Passe : " + tarotCard.passe;
        supInfoBonus.text = "Bonus : " + tarotCard.bonus;
        supInfoAvJ.text = tarotCard.avantagePj;
        supInfoAvIA.text = tarotCard.avantageIA;
        supInfoDavJ.text = tarotCard.desavantagePj;
        supInfoDavIA.text = tarotCard.desavantageIA;
    }

}
