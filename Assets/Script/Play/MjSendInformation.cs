using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class MjSendInformation : MonoBehaviour
{
    public Image currentFondGame;
    public AudioSource currentAudio;
    public VideoPlayer videoPlayer;
    public AudioSource currentPiste;

    public string userName;

    public GameObject videoScene;

    public Dictionary<string, MissionScene>  allMS;

    // Start is called before the first frame update
    public void SetName(string name)
    {
        userName = name;
    }
    public void Init(string missionName)
    {
        allMS = new Dictionary<string, MissionScene>();
        MissionScene[] ressourceMS= Resources.LoadAll<MissionScene>("Mission/" + missionName);
        foreach (MissionScene ss in ressourceMS)
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
            UpdateScene(allMS[sceneName]);
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
}
