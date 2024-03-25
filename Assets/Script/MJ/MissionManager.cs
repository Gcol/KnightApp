using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class MissionManager : MonoBehaviour
{
    public List<MissionScene> allMissionScene;
    public int currentIndexScene;

    public GameObject nextButtonScene;
    public TextMeshProUGUI nextSceneButtonText;

    public GameObject previousButtonScene;
    public TextMeshProUGUI previousSceneButtonText;

    public TwitchChatClient currentTCC;
    public TMP_InputField infoMission;
    public TextMeshProUGUI nameScene;
    public string missionName;

    // Start is called before the first frame update

    public void Init(string newMissionName, int newIndex)
    {
        missionName = newMissionName;
        allMissionScene = new List<MissionScene>();
        currentTCC = FindObjectOfType<TwitchChatClient>();

        FindObjectOfType<MjSendInformation>().Init(newMissionName);

        foreach (MissionScene currMS in FindObjectOfType<MjSendInformation>().allMS.Values)
        {
            allMissionScene.Add(currMS);
        }
        currentIndexScene = newIndex;
        ChangeScene();
    }

    public void ChangeScene()
    {
        if (currentIndexScene < allMissionScene.Count)
        {
            ChangeScene(allMissionScene[currentIndexScene]);
            if (currentIndexScene + 1 < allMissionScene.Count)
            {
                nextSceneButtonText.text = allMissionScene[currentIndexScene + 1].name;
                nextButtonScene.SetActive(true);
            }
            else
                nextButtonScene.SetActive(false);
            if (currentIndexScene - 1 >= 0)
            {
                previousSceneButtonText.text = allMissionScene[currentIndexScene - 1].name;
                previousButtonScene.SetActive(true);
            }
            else
                previousButtonScene.SetActive(false);

        }
        else
        {
            Debug.LogError("Tu charge un index de scene qui n'existe pas " + currentIndexScene + " / " + allMissionScene.Count);
        }
    }

    public void RefreshScene()
    {
        currentTCC.reloadAll(missionName, allMissionScene[currentIndexScene]);
    }

    public void ChangeScene(MissionScene newScene)
    {
        nameScene.text = newScene.name;
        infoMission.text = newScene.SceneDescription;
        currentTCC.ChangeScene(newScene);
    }

    public void NextScene()
    {
        currentIndexScene++;
        ChangeScene();
    }

    public void PrevScene()
    {
        currentIndexScene--;
        ChangeScene();
    }
}
