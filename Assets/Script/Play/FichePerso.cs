using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;


public class FichePerso : MonoBehaviour
{

    public GameManager currentGM;
    public TextMeshProUGUI persoName;
    public Image currentSprite;

    Dictionary<string, CharacteOverdrive> charactValueText;

    [SerializeField]
    AllCharacText newText;
    // Start is called before the first frame update
    void Start()
    {
    }

    void Init()
    {
        currentGM = FindObjectOfType<GameManager>();
        charactValueText = newText.ToDictionary();

    }

    public void InsertNewPerso(Chevalier currentChevalier)
    {
        Init();
        //currentSprite.sprite = currentChevalier.armure.currentSprite;
        //persoName.text = currentChevalier.name.Split(" ")[0] + " \"" + currentChevalier.alias+  "\" " + currentChevalier.name.Split(" ")[1];
        
        foreach (var kvp in currentChevalier.allStat)
        {
            charactValueText[kvp.Key.ToString()].valueText.text = kvp.Value.value.ToString();
            if (kvp.Value.overdrive != 0)
                charactValueText[kvp.Key.ToString()].overdriveText.text = kvp.Value.ToString();
            else if (charactValueText[kvp.Key.ToString()].overdriveText != null)
                charactValueText[kvp.Key.ToString()].overdriveText.text = "";
        }
    }

}


[Serializable]
public class AllCharacText
{

    [SerializeField]
    CharacText[] currentCharacText;

    public Dictionary<string, CharacteOverdrive> ToDictionary()
    {
        Dictionary<string, CharacteOverdrive> newDict = new Dictionary<string, CharacteOverdrive>();
        foreach (var item in currentCharacText)
        {
            newDict.Add(item.name, item.varText);
        }
        return newDict;
    }
}


[Serializable]
public class CharacText
{
    [SerializeField]
    public string name;
    [SerializeField]
    public CharacteOverdrive varText;

}

[Serializable]
public class CharacteOverdrive
{
    [SerializeField]
    public TextMeshProUGUI valueText;
    [SerializeField]
    public TextMeshProUGUI overdriveText;

}
