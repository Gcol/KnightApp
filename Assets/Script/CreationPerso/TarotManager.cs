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


    public GameObject InstructionPannel;
    public Tarot currentObj;

    public void UpdatePerso()
    {
        cMM.UpdatePerso(currentObj);
    }
    // Start is called before the first frame update
    void Start()
    {
        InstructionPannel = transform.Find("Instruction").gameObject;
        cMM = FindObjectOfType<CreationPersoManager>();
        UpdateObjectif();

    }

    void UpdateObjectif()
    {

        if (cMM.taroDeck.avJ == null)
            InstructionPannel.transform.Find("Instruction (AvJ)").GetComponent<TextMeshProUGUI>().text = "2 Avantage Joueur";
        else
            InstructionPannel.transform.Find("Instruction (AvJ)").GetComponent<TextMeshProUGUI>().text = (2 - cMM.taroDeck.avJ.Count) + " Avantage Joueur";

        if (cMM.taroDeck.DavJ == null)
            InstructionPannel.transform.Find("Instruction (DavJ)").GetComponent<TextMeshProUGUI>().text  = "1 Desavantage Joueur";
        else
            InstructionPannel.transform.Find("Instruction (DavJ)").GetComponent<TextMeshProUGUI>().text = "0 Desavantage Joueur";

        if (cMM.taroDeck.avIa == null)
            InstructionPannel.transform.Find("Instruction (AvIA)").GetComponent<TextMeshProUGUI>().text = "1 Avantage IA";
        else
            InstructionPannel.transform.Find("Instruction (AvIA)").GetComponent<TextMeshProUGUI>().text = "0 Avantage IA";

        if (cMM.taroDeck.DavIa == null)
            InstructionPannel.transform.Find("Instruction (DavIA)").GetComponent<TextMeshProUGUI>().text = "1 Desavantage IA";
        else
            InstructionPannel.transform.Find("Instruction (DavIA)").GetComponent<TextMeshProUGUI>().text = "0 Desavantage IA";

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
