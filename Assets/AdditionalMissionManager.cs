using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AdditionalMissionManager : MonoBehaviour
{

    public void Init(ChevalierChef chevalierChef, string contenueMission)
    {
        Transform FondNoir = transform.Find("FondBlanc").Find("FondNoir");
        FondNoir.Find("Titre").GetComponent<TextMeshProUGUI>().text = chevalierChef.ToString();
        FondNoir.Find("Desc").GetComponent<TextMeshProUGUI>().text = contenueMission;
    }

}
