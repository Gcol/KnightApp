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
        transform.Find("PointSanté/GameObject").gameObject.GetComponent<UpdateStat>().InitValue(currentChevalier.currentVie, currentChevalier.pv);
        transform.Find("Point D'espoir/GameObject").gameObject.GetComponent<UpdateStat>().InitValue(currentChevalier.currentEspoir, currentChevalier.pe);
        transform.Find("Point D'énergie/GameObject").gameObject.GetComponent<UpdateStat>().InitValue(currentChevalier.currentEnergie, currentChevalier.armure.PointEnergie);
        transform.Find("Points D'armure/GameObject").gameObject.GetComponent<UpdateStat>().InitValue(currentChevalier.currentArmor, currentChevalier.armure.PointArmure);
        transform.Find("Champ de Force/GameObject").gameObject.GetComponent<UpdateStat>().InitValue(currentChevalier.armure.ChampDeForce, currentChevalier.armure.ChampDeForce);

        transform.Find("PointSanté/Text (TMP)").gameObject.GetComponent<TextMeshProUGUI>().text = currentChevalier.currentVie.ToString();
        transform.Find("Point D'espoir/Text (TMP)").gameObject.GetComponent<TextMeshProUGUI>().text = currentChevalier.currentEspoir.ToString();
        transform.Find("Point D'énergie/Text (TMP)").gameObject.GetComponent<TextMeshProUGUI>().text = currentChevalier.currentEnergie.ToString();
        transform.Find("Points D'armure/Text (TMP)").gameObject.GetComponent<TextMeshProUGUI>().text = currentChevalier.currentArmor.ToString();
        transform.Find("Champ de Force/Text (TMP)").gameObject.GetComponent<TextMeshProUGUI>().text = currentChevalier.armure.ChampDeForce.ToString();

    }

    public void UpdateChevalierInfo(Chevalier currentChevalier)
    {
        int.TryParse(transform.Find("PointSanté/Text (TMP)").gameObject.GetComponent<TextMeshProUGUI>().text, out currentChevalier.currentVie);
        int.TryParse(transform.Find("Points D'armure/Text (TMP)").gameObject.GetComponent<TextMeshProUGUI>().text, out currentChevalier.currentArmor);
        int.TryParse(transform.Find("Point D'espoir/Text (TMP)").gameObject.GetComponent<TextMeshProUGUI>().text, out currentChevalier.currentEspoir);
        int.TryParse(transform.Find("Point D'énergie/Text (TMP)").gameObject.GetComponent<TextMeshProUGUI>().text, out currentChevalier.currentEnergie);
        int.TryParse(transform.Find("Champ de Force/Text (TMP)").gameObject.GetComponent<TextMeshProUGUI>().text, out currentChevalier.armure.ChampDeForce);
    }
}
