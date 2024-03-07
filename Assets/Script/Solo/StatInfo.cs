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
        transform.Find("PointSanté/GameObject").gameObject.GetComponent<UpdateStat>().InitValue(currentChevalier.currentPv, currentChevalier.pv);
        transform.Find("Point D'espoir/GameObject").gameObject.GetComponent<UpdateStat>().InitValue(currentChevalier.currentPe, currentChevalier.pe);
        transform.Find("Point D'énergie/GameObject").gameObject.GetComponent<UpdateStat>().InitValue(currentChevalier.currentPen, currentChevalier.armure.PointEnergie);
        transform.Find("Points D'armure/GameObject").gameObject.GetComponent<UpdateStat>().InitValue(currentChevalier.currentPa, currentChevalier.armure.PointArmure);
        transform.Find("Champ de Force/GameObject").gameObject.GetComponent<UpdateStat>().InitValue(currentChevalier.currentCDF, currentChevalier.armure.ChampDeForce);

        transform.Find("PointSanté/Text (TMP)").gameObject.GetComponent<TextMeshProUGUI>().text = currentChevalier.currentPv.ToString();
        transform.Find("Point D'espoir/Text (TMP)").gameObject.GetComponent<TextMeshProUGUI>().text = currentChevalier.currentPe.ToString();
        transform.Find("Point D'énergie/Text (TMP)").gameObject.GetComponent<TextMeshProUGUI>().text = currentChevalier.currentPen.ToString();
        transform.Find("Points D'armure/Text (TMP)").gameObject.GetComponent<TextMeshProUGUI>().text = currentChevalier.currentPa.ToString();
        transform.Find("Champ de Force/Text (TMP)").gameObject.GetComponent<TextMeshProUGUI>().text = currentChevalier.currentCDF.ToString();

    }

    public void UpdateChevalierInfo(Chevalier currentChevalier)
    {
        int.TryParse(transform.Find("PointSanté/Text (TMP)").gameObject.GetComponent<TextMeshProUGUI>().text, out currentChevalier.currentPv);
        int.TryParse(transform.Find("Points D'armure/Text (TMP)").gameObject.GetComponent<TextMeshProUGUI>().text, out currentChevalier.currentPa);
        int.TryParse(transform.Find("Point D'espoir/Text (TMP)").gameObject.GetComponent<TextMeshProUGUI>().text, out currentChevalier.currentPe);
        int.TryParse(transform.Find("Point D'énergie/Text (TMP)").gameObject.GetComponent<TextMeshProUGUI>().text, out currentChevalier.currentPen);
        int.TryParse(transform.Find("Champ de Force/Text (TMP)").gameObject.GetComponent<TextMeshProUGUI>().text, out currentChevalier.currentCDF);
    }
}
