using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class ChoixMission : MonoBehaviour
{
    public MJManager currentGM;
    public TextMeshProUGUI missionName;

    // Start is called before the first frame update
    void Start()
    {
        currentGM = FindObjectOfType<MJManager>();
    }

    public void ChooseAMission()
    {
        currentGM.ChooseAMission(missionName.text);
    }

    public void SetMission(string name)
    {
        missionName.text = name;
    }
}
