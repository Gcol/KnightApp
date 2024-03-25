using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class ResearchButton : MonoBehaviour
{
    public TMP_InputField myInputField;

    Dictionary<string, Sprite> dictBattleMap;

    public Image currentBattleMap;

    // Start is called before the first frame update
    void Start()
    {
        dictBattleMap = new Dictionary<string, Sprite>();
        Sprite[] ressourceSprite = Resources.LoadAll<Sprite>("Bdd");
        foreach (Sprite sprite in ressourceSprite)
        {
            dictBattleMap.Add(sprite.name, sprite);
        }
    }

    public void LaunchResearch()
    {
        string myKey = myInputField.text;
        if (dictBattleMap.ContainsKey(myKey))
            currentBattleMap.sprite = dictBattleMap[myKey];
    }

}