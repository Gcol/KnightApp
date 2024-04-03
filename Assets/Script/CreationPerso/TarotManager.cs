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
    public Button supInfoAvIAButton;
    public Button supInfoDavJButton;
    public Button supInfoDavIAButton;

    public TextMeshProUGUI supInfoAvJ;
    public TextMeshProUGUI supInfoAvIA;
    public TextMeshProUGUI supInfoDavJ;
    public TextMeshProUGUI supInfoDavIA;


    public GameObject InstructionPannel;
    public Tarot currentObj;
    public string emplacement;
    public Button currentButton;

    public void UpdatePerso()
    {
        cMM.UpdatePerso(currentObj, emplacement);
    }
    // Start is called before the first frame update
    void Start()
    {
        InstructionPannel = transform.Find("Instruction").gameObject;
        cMM = FindObjectOfType<CreationPersoManager>();
    }

    public void UpdateEmplacement(string emplacement)
    {
        this.emplacement =  emplacement;
    }

    public void UpdateObjectif(string emplacement)
    {
        Debug.Log(emplacement);
        if (emplacement != "Avantage Joueur")
        {
            emplacement = emplacement.Replace(" 2", "");
            InstructionPannel.transform.Find($"Instruction {emplacement}").GetComponent<TextMeshProUGUI>().text = $"<s>0 {emplacement}</s>";
            InstructionPannel.transform.Find($"Instruction {emplacement}").GetComponent<TextMeshProUGUI>().color = Color.grey;
            switch (emplacement)
            {
                case "Avantage Joueur":
                    supInfoAvJButton.interactable = false;
                    break;
                case "Avantage IA":
                    supInfoAvIAButton.interactable = false;
                    break;
                case "Desavantage Joueur":
                    supInfoDavJButton.interactable = false;
                    break;
                case "Desavantage IA":
                    supInfoDavIAButton.interactable = false;
                    break;
            }

        }
        else
            InstructionPannel.transform.Find($"Instruction {emplacement}").GetComponent<TextMeshProUGUI>().text = $"1 {emplacement}";

    }
    
    public void DeactiveButton()
    {
        currentButton.interactable = false;
    }

    public void PushButton(CreaPerso tarotCard, Button currentButton)
    {
        this.currentButton = currentButton;
        currentObj = (Tarot)tarotCard;
        tarotInfoPannel.SetActive(true);
        supInfoImage.sprite = tarotCard.currentSprite;
        supInfoTitre.text = tarotCard.name;
        supInfoText.text = tarotCard.desc;
        supInfoPasse.text = "Passe : " + currentObj.passe;
        supInfoBonus.text = "Bonus : " + currentObj.bonus;
        supInfoAvJ.text = currentObj.avantagePj;
        supInfoAvIA.text = currentObj.avantageIA;
        supInfoDavJ.text = currentObj.desavantagePj;
        supInfoDavIA.text = currentObj.desavantageIA;
    }

}
