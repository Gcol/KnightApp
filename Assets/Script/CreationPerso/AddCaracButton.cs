using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AddCaracButton : MonoBehaviour
{
    public CreationPersoManager cMM;
    public caract�ristique caract�ristique;
    public string from;


    public void InitCarac(caract�ristique caract�ristique, string from)
    {
        this.caract�ristique = caract�ristique;
        this.from = from;   
        transform.Find("Text (TMP)").GetComponent< TextMeshProUGUI >().text = caract�ristique.ToString();
    }

    public void PushButton()
    {
        cMM.AddCarac(caract�ristique, from);
    }
}
