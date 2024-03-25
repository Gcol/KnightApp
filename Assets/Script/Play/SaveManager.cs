using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


[Serializable]
public class Player
{

    public string name;
    public string alias;

    public string hautFait;
    public string archetype;
    public string blason;
    public string armure;
    public string section;

    public List<string> allModule;

    [HideInInspector]
    public List<string> motiv;

    [HideInInspector]
    public List<string> arcanes;

    public Dictionary<string, CharacValue> allStat = new Dictionary<string, CharacValue>() {
        {"Chair", new CharacValue(0,0)},
        {"Déplacement", new CharacValue(0,0)},
        {"Force", new CharacValue(0,0)},
        {"Endurance", new CharacValue(0,0)},
        {"Bête", new CharacValue(0,0)},
        {"Hargne", new CharacValue(0,0)},
        {"Combat", new CharacValue(0,0)},
        {"Instinct", new CharacValue(0,0)},
        {"Machine", new CharacValue(0,0)},
        {"Tir", new CharacValue(0,0)},
        {"Savoir", new CharacValue(0,0)},
        {"Technique", new CharacValue(0,0)},
        {"Dame", new CharacValue(0,0)},
        {"Aura", new CharacValue(0,0)},
        {"Parole", new CharacValue(0,0)},
        {"Sang-Froid", new CharacValue(0,0)},
        {"Masque", new CharacValue(0,0)},
        {"Discrétion", new CharacValue(0,0)},
        {"Dextérité", new CharacValue(0,0)},
        {"Perception", new CharacValue(0,0)}
    };

    public List<string> allWeapon;

    public string description;

    public Dictionary<string, Stat> stat = new Dictionary<string, Stat>(){
        { "Vie" , new Stat() },
        { "Espoir" , new Stat() },
        { "Energie" , new Stat() },
        { "Armure" , new Stat() },
        { "Champ De Force" , new Stat() }
    };

    public Player(Chevalier currentChevalier)
    {
        name = currentChevalier.fullname;
        alias = currentChevalier.alias;
        hautFait = currentChevalier.hautFait.name;
        blason = currentChevalier.blason.name;
        section = currentChevalier.section.name;
        armure = currentChevalier.armure.name;
    }

}

[Serializable]
public class Stat
{
    public int max;
    public int value;
}

[Serializable]
public class User
{
    public string name;
    public Player chevalier;

    public User(Chevalier newChevalier)
    {
        name = newChevalier.name;
        chevalier = new Player(newChevalier);
    }

    public void UpdateUser(Chevalier newChevalier)
    {
        name = newChevalier.name;
    }
}

public class SaveManager : MonoBehaviour
{
    public string filePathUser;
    public string filePathNote;

    // Method to save monthly data
    public void SaveNote(string currentNote)
    {
        File.WriteAllText(filePathNote, currentNote);
    }

    public void SaveData(User currentUser)
    {
        File.WriteAllText(filePathUser, JsonUtility.ToJson(currentUser));
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


    public User LoadUser()
    {
        filePathUser = Application.persistentDataPath + $"/saveUser.json";
        if (File.Exists(filePathUser))
        {
            string json = File.ReadAllText(filePathUser);
            return JsonUtility.FromJson<User>(json);
        }
        
        return null;
    }
}
