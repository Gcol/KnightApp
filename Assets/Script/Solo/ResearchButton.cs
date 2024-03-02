using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class ResearchButton : MonoBehaviour
{
    public TMP_InputField myInputField;
    
    public SpriteDictionnary battleMap;
    public SpriteDictionnary fondGame;
    public AudioDictionnary allAudio;
    public AudioDictionnary allPisteAudio;

    Dictionary<string, Sprite> dictFondGame;
    Dictionary<string, Sprite> dictBattleMap;
    Dictionary<string, AudioClip> dictAllAudio;
    Dictionary<string, AudioClip> dictAllPisteAudio;



    public Image currentBattleMap;
    public Image currentFondGame;
    public AudioSource currentAudio;
    public AudioSource currentPiste;
    // Start is called before the first frame update
    void Start()
    {
        dictBattleMap = battleMap.ToDictionary();
        dictAllAudio = allAudio.ToDictionary();
        dictFondGame = fondGame.ToDictionary();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LaunchResearch()
    {
        string myKey = myInputField.text;
        if (dictBattleMap.ContainsKey(myKey))
            currentBattleMap.sprite = dictBattleMap[myKey];
        if (dictFondGame.ContainsKey(myKey))
            currentFondGame.sprite = dictFondGame[myKey];
        if (dictAllAudio.ContainsKey(myKey))
        {
            currentAudio.clip = dictAllAudio[myKey];
            currentAudio.Play();
        }
    }

}


[Serializable]
public class SpriteDictionnary
{

    [SerializeField]
    public SpriteInfo[] allSpriteInfo;

    public Dictionary<string, Sprite> ToDictionary()
    {
        Dictionary<string, Sprite> newDict = new Dictionary<string, Sprite>();
        foreach (var item in allSpriteInfo)
        {
            newDict.Add(item.name, item.sprite);
        }
        return newDict;
    }
}

[Serializable]
public class AudioDictionnary
{

    [SerializeField]
    public AudioInfo[] allAudioInfo;

    public Dictionary<string, AudioClip> ToDictionary()
    {
        Dictionary<string, AudioClip> newDict = new Dictionary<string, AudioClip>();
        foreach (var item in allAudioInfo)
        {
            newDict.Add(item.name, item.audioInfo);
        }
        return newDict;
    }
}

[Serializable]
public class SpriteInfo
{
    [SerializeField]
    public string name;
    [SerializeField]
    public Sprite sprite;
}

[Serializable]
public class AudioInfo
{
    [SerializeField]
    public string name;
    [SerializeField]
    public AudioClip audioInfo;
}
