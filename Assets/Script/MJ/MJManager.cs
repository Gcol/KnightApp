using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Newtonsoft.Json.Bson;
using UnityEditor;

public class MJManager : MonoBehaviour
{
    public string currentMission;
    public MissionManager currentMM;
    public TwitchChatClient currentTCC;

    public SaveMjManager currentSMM;
    public MjInfo mjInfo;

    //TODO a ajouter dans une save


    // Start is called before the first frame update
    void Start()
    {

        FindObjectOfType<TwitchChatClient>().Init();
        FindObjectOfType<MjSendInformation>().SetName("MJ");

        currentSMM = FindObjectOfType<SaveMjManager>();
        mjInfo = currentSMM.LoadMjInfo();

        FindObjectOfType<ChoixMissionManager>().Init();
        if (mjInfo.mission != null)
            ChooseAMission(mjInfo.mission, mjInfo.missionIndex);
        else
            FindObjectOfType<ChoixMissionManager>().GenMission();
        // Il faudrait load la scene par ici
    }


    public void ChooseAMission(string newMission, int indexMission = 0)
    {
        currentMission = newMission;
        FindObjectOfType<MjSendInformation>().Init(newMission);
        FindObjectOfType<ChoixMissionManager>().gameObject.SetActive(false);
        currentMM.Init(newMission, indexMission);
        currentTCC.ChangeScene(currentMM.allMissionScene[indexMission]);

    }

    public void SaveAndQuit()
    {
        mjInfo.mission = currentMission;
        mjInfo.missionIndex = currentMM.currentIndexScene;
        currentSMM.SaveMjInfo(mjInfo);
        #if UNITY_EDITOR
                // Quitter l'application lorsque la touche Échap est enfoncée en dehors du mode play dans l'éditeur
                EditorApplication.isPlaying = false;
        #else
                // Quitter l'application lorsque la touche Échap est enfoncée dans un build
                Application.Quit();
        #endif
    }

}
