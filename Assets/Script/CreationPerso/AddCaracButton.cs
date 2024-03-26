using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AddCaracButton : MonoBehaviour
{
    public CreationPersoManager cMM;
    public caractéristique caractéristique;
    public string from;


    public void InitCarac(caractéristique caractéristique, string from)
    {
        this.caractéristique = caractéristique;
        this.from = from;   
        transform.Find("Text (TMP)").GetComponent< TextMeshProUGUI >().text = caractéristique.ToString();
    }

    public void PushButton()
    {
        cMM.AddCarac(caractéristique, from);
    }
}
