using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StatInfo : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void InsertNewPerso(Chevalier currentChevalier)
    {
        transform.Find("PointSanté/Text (TMP)").gameObject.GetComponent<TextMeshProUGUI>().text = currentChevalier.pv.ToString();
        transform.Find("Point D'espoir/Text (TMP)").gameObject.GetComponent<TextMeshProUGUI>().text = currentChevalier.pe.ToString();
        transform.Find("Point D'énergie/Text (TMP)").gameObject.GetComponent<TextMeshProUGUI>().text = currentChevalier.armure.PointArmure.ToString();
        transform.Find("Points D'armure/Text (TMP)").gameObject.GetComponent<TextMeshProUGUI>().text = currentChevalier.armure.PointEnergie.ToString();
        transform.Find("Champ de Force/Text (TMP)").gameObject.GetComponent<TextMeshProUGUI>().text = currentChevalier.armure.ChampDeForce.ToString();
    }
}
