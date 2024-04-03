using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AddCaracButton : MonoBehaviour
{
    public CreationPersoManager cMM;
    public caractéristique caractéristique;
    public string from;
    public bool selfInit = false;

    public void Start()
    {
        if (selfInit)
            InitCarac(caractéristique, from);
    }
    public void InitCarac(caractéristique caractéristique, string from)
    {
        this.caractéristique = caractéristique;
        this.from = from;   
        transform.Find("Text (TMP)").GetComponent< TextMeshProUGUI >().text = caractéristique.ToString();
    }
    void OnEnable()
    {
        if (cMM.caracPlayer[caractéristique].value() == cMM.caracPlayer[cMM.caracPlayer[caractéristique].aspect].value() && caractéristique != cMM.caracPlayer[caractéristique].aspect)
            gameObject.GetComponent<Button>().interactable = false;
        else if (gameObject.GetComponent<Button>().interactable == false)
            gameObject.GetComponent<Button>().interactable = true;
        // Add any other actions you want to perform when the GameObject is activated
    }

    public void PushButton()
    {
        cMM.AddCarac(caractéristique, from);
    }
}
