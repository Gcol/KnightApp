using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AddCaracButton : MonoBehaviour
{
    public CreationPersoManager cMM;
    public caract�ristique caract�ristique;
    public string from;
    public bool selfInit = false;

    public void Start()
    {
        if (selfInit)
            InitCarac(caract�ristique, from);
    }
    public void InitCarac(caract�ristique caract�ristique, string from)
    {
        this.caract�ristique = caract�ristique;
        this.from = from;   
        transform.Find("Text (TMP)").GetComponent< TextMeshProUGUI >().text = caract�ristique.ToString();
    }
    void OnEnable()
    {
        if (cMM.caracPlayer[caract�ristique].value() == cMM.caracPlayer[cMM.caracPlayer[caract�ristique].aspect].value() && caract�ristique != cMM.caracPlayer[caract�ristique].aspect)
            gameObject.GetComponent<Button>().interactable = false;
        else if (gameObject.GetComponent<Button>().interactable == false)
            gameObject.GetComponent<Button>().interactable = true;
        // Add any other actions you want to perform when the GameObject is activated
    }

    public void PushButton()
    {
        cMM.AddCarac(caract�ristique, from);
    }
}
