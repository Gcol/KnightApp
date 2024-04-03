using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEditor;

[Serializable]
public struct CaracSave
{
    public string name;
    public int value;
    public int od;

    public CaracSave(string name, int value, int od)
    {
        this.name = name;
        this.value = value;
        this.od = od;
    }
}

[Serializable]
public struct StatSave
{
    public string name;
    public int currentValue;

    public StatSave(string name, int maxValue)
    {
        this.name = name;
        this.currentValue = maxValue;
    }
}

[Serializable]
public class Player
{

    public string name;
    public string alias;

    public int pg;
    public int xp;
    public string hautFait;
    public string archetype;
    public string blason;
    public string armure;
    public string section;

    public List<string> allModule;

    public string[] motiv;

    public List<string> tarot;

    public List<CaracSave> allCarac;

    public List<string> allWeapon;

    public string description;

    public List<StatSave> stat;


    public Player(Chevalier currentChevalier)
    {
        allWeapon = new List<string>();
        allModule = new List<string>();

        stat = new List<StatSave>
        {
            new StatSave("Vie", currentChevalier.PointDeVie()),
            new StatSave("Espoir", currentChevalier.Espoir()),
            new StatSave("Energie", currentChevalier.armure.PointEnergie),
            new StatSave("Armure", currentChevalier.armure.PointArmure),
            new StatSave("ChampDeForce", currentChevalier.armure.ChampDeForce)
        };

        alias = currentChevalier.alias;
        name = currentChevalier.fullname;
        archetype = currentChevalier.archetype.name;
        hautFait = currentChevalier.hautFait.name;
        blason = currentChevalier.blason.name;
        section = currentChevalier.section.name;
        armure = currentChevalier.armure.name;
        allCarac = new List<CaracSave>();
        tarot = currentChevalier.tarots;
        motiv = currentChevalier.motivation;

        foreach (KeyValuePair<caractéristique, CharacValue> keyValuePair in currentChevalier.allStat)
        {
            allCarac.Add(new CaracSave(keyValuePair.Key.ToString(), keyValuePair.Value.value, keyValuePair.Value.overdrive));
        }


        foreach (Arme arme in currentChevalier.allWeapon)
            allWeapon.Add(arme.name);

        foreach (Module module in currentChevalier.armure.modules)
            allModule.Add(module.name);

        pg = 0;
        xp = 0;
    }

    public string fullName()
    {
        string fullname = name.Split(" ")[0] + alias + name.Split(" ")[1];
        return fullname;
    }

}

[Serializable]
public class Stat
{
    public int max;
    public int value;
}
[Serializable]
public class GlobalInfo
{
    public string name;
    public string lastChevalier;
}

public class SaveManager : MonoBehaviour
{
    public string filePathGlobalInfo;
    public string filePathUser;
    public string filePathNote;

    // Method to save monthly data
    public void SaveNote(string currentNote)
    {
        File.WriteAllText(filePathNote, currentNote);
    }
    public void SaveData(GlobalInfo currentUser)
    {
        Debug.Log(currentUser.lastChevalier);
        File.WriteAllText(filePathGlobalInfo, JsonUtility.ToJson(currentUser));
    }

    public void SaveData(Player currentUser)
    {
        filePathUser = Application.persistentDataPath + $"/Caracter/";
        if (!Directory.Exists(filePathUser))
        {
            // Create the folder
            Directory.CreateDirectory(filePathUser);
            Debug.Log("Folder created at: " + filePathUser);
        }

        File.WriteAllText(filePathUser + currentUser.fullName()+".json", JsonUtility.ToJson(currentUser));
    }

    public String LoadNote()
    {
        filePathNote = Application.persistentDataPath + $"/note.txt";
        if (File.Exists(filePathNote))
        {
            return File.ReadAllText(filePathNote);
        }
        return "";
    }


    public Player LoadCaracter(string name)
    {
        filePathUser = Application.persistentDataPath + $"/Caracter/{name}.json";
        string json = File.ReadAllText(filePathUser);
        Debug.Log(json);
        return JsonUtility.FromJson<Player>(json);
    }

    public GlobalInfo LoadGlobalInfo()
    {
        filePathGlobalInfo = Application.persistentDataPath + $"/saveUser.json";
        Debug.Log(filePathGlobalInfo);
        if (File.Exists(filePathGlobalInfo))
        {
            Debug.Log("File exist");
            string json = File.ReadAllText(filePathGlobalInfo);
            Debug.Log(json);
            return JsonUtility.FromJson<GlobalInfo>(json);
        }
        
        return new GlobalInfo();
    }
}
