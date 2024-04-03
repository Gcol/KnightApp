using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Video;

public class MjSendInformation : MonoBehaviour
{
    public TextMeshProUGUI mjMessage;
    public Image currentFondGame;
    public AudioSource currentAudio;
    public VideoPlayer videoPlayer;
    public AudioSource currentPiste;

    public string userName;

    public GameObject videoScene;

    public AdditionalMissionManager addionalMissionManager;
    public ChevalierChef chevalierChef;

    public Dictionary<string, Mission>  allMS;

    // Start is called before the first frame update
    public void SetName(string name)
    {
        userName = name;
    }
    public void Init(string missionName)
    {
        chevalierChef = FindAnyObjectByType<GameManager>().currentChevalier.section.chefSection;
        allMS = new Dictionary<string, Mission>();
        Mission[] ressourceMS= Resources.LoadAll<Mission>("Mission/" + missionName);
        foreach (Mission ss in ressourceMS)
        {
            allMS.Add(ss.name, ss);
        }
    }


    public void UpdateScene(string sceneName)
    {
        //Debug.Log(sceneName + " " + sceneName.IndexOf("Scene=", 0));
        if (sceneName.IndexOf("Scene=", 0) >=0)
        {
            sceneName = sceneName.Substring(sceneName.IndexOf("Scene=", 1) + 7);
        }
        if (allMS != null)
        {
            if (allMS[sceneName] is AdditionalMission)
                UpdateScene((AdditionalMission)allMS[sceneName]);
            if (allMS[sceneName] is AdditionalMission)
                UpdateScene((MissionScene)allMS[sceneName]);
        }
    }
    public void UpdateScene(AdditionalMission newMissionScene)
    {
        currentFondGame.sprite = newMissionScene.fondSprite;
        if (newMissionScene.musicFond)
        {
            currentAudio.clip = newMissionScene.musicFond;
            currentAudio.Play();
        }
        if (newMissionScene.videoClip)
        {
            videoScene.SetActive(true);
            videoPlayer.clip = newMissionScene.videoClip;
            videoPlayer.Play();
        }
        else
            videoScene.SetActive(false);
        addionalMissionManager.Init(chevalierChef, newMissionScene.mission[chevalierChef]);
        addionalMissionManager.gameObject.SetActive(true);
    }
    public void UpdateScene(MissionScene newMissionScene)
    {
        currentFondGame.sprite = newMissionScene.fondSprite;
        if (newMissionScene.musicFond)
        {
            currentAudio.clip = newMissionScene.musicFond;
            currentAudio.Play();
        }
        if (newMissionScene.videoClip)
        {
            videoScene.SetActive(true);
            videoPlayer.clip = newMissionScene.videoClip;
            videoPlayer.Play();
        }
        else
            videoScene.SetActive(false);

    }

    public void AddPlayer(string message)
    {
        Debug.Log("New Player : " + message);
    }

    public void GetMjMessage(string message)
    {
        mjMessage.text = message;
    }
}
