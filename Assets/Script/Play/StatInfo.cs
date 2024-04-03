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
        transform.Find("PointSanté/GameObject").gameObject.GetComponent<UpdateStat>().InitValue(currentChevalier.currentStat["Vie"], currentChevalier.PointDeVie());
        transform.Find("Point D'espoir/GameObject").gameObject.GetComponent<UpdateStat>().InitValue(currentChevalier.currentStat["Espoir"], currentChevalier.Espoir());
        transform.Find("Point D'énergie/GameObject").gameObject.GetComponent<UpdateStat>().InitValue(currentChevalier.currentStat["Energie"], currentChevalier.armure.PointEnergie);
        transform.Find("Points D'armure/GameObject").gameObject.GetComponent<UpdateStat>().InitValue(currentChevalier.currentStat["Armure"], currentChevalier.armure.PointArmure);
        transform.Find("Champ de Force/GameObject").gameObject.GetComponent<UpdateStat>().InitValue(currentChevalier.armure.ChampDeForce, currentChevalier.armure.ChampDeForce);


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
