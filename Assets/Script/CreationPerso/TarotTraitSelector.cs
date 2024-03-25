using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TarotTraitSelector : MonoBehaviour
{
    public void UpdateButton()
    {
        GameObject.Find("TarotValidButton").GetComponent<TextMeshProUGUI>().text  = "Selectionner :" + GetComponent<TextMeshProUGUI>().text.Split(":")[0];
    }
}
