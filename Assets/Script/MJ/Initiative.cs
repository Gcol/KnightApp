using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Initiative : MonoBehaviour
{
    public TextMeshProUGUI pvTexte;
    public TextMeshProUGUI modifPvTexte;
    public TextMeshProUGUI nameText;

    public TMP_InputField tMP_InputField;
    public int currentPV;
    public int maxCurrentPV;
    public int tempPv;

    public GameObject currentPannel;



    // Start is called before the first frame update
    public void Init(string name, int pv)
    {
        currentPV = pv;
        maxCurrentPV = pv;
        nameText.text = name;
        pvTexte.text = pv.ToString() + " pv";
        modifPvTexte.text = pv.ToString() + " / " + maxCurrentPV.ToString() + " pv";
    }

    public void UpdatePV()
    {
        int intValue;

        // Use int.Parse() to convert the string to an integer
        if (int.TryParse(tMP_InputField.text, out intValue))
        {
            tempPv = currentPV + intValue < 0 ? 0 : currentPV + intValue > maxCurrentPV ? maxCurrentPV : currentPV + intValue;
            modifPvTexte.text = tempPv.ToString() + " / " + maxCurrentPV.ToString() + " pv";
        }
    }

    public void ValideUpdate()
    {
        currentPV = tempPv;
        pvTexte.text = currentPV.ToString() + " pv";
        if (currentPV <= 0)
            Destroy(gameObject);
        currentPannel.SetActive(false);
    }



}
