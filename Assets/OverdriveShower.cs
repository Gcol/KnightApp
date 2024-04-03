using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OverdriveShower : MonoBehaviour
{
    public Overdrive overdrive;
    public int previousValue;

    // Start is called before the first frame update
    void Start()
    {
        int lvl = 1;
        previousValue = 0;
        foreach (EvolutionModule odLvl in overdrive.description)
        {
            transform.Find("Nv" + lvl).Find("Text (TMP)").GetComponent<TextMeshProUGUI>().text = "Nv " + lvl + ": " + odLvl.description;
            lvl++;
        }
    }

    public void UpdateOdd(int newValue)
    {
        if (newValue !=  previousValue)
        {
            Debug.Log(newValue + " => "  + previousValue);
            for (int i = previousValue; i < newValue; i++)
                transform.Find("Nv" + (i + 1)).Find("Check").Find("Text (TMP)").GetComponent<TextMeshProUGUI>().text = "X";
            for (int i = previousValue; i > newValue; i--)
                transform.Find("Nv" + i).Find("Check").Find("Text (TMP)").GetComponent<TextMeshProUGUI>().text = "";
            previousValue = newValue;
        }
    }
}
