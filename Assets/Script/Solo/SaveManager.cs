using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

[Serializable]
public class User
{
    public string name;
    public int currentPv;
    public int currentPa;
    public int currentPe;
    public int currentPen;
    public int currentCDF;

    public User(Chevalier newChevalier)
    {
        currentCDF = newChevalier.armure.ChampDeForce;
        currentPen = newChevalier.armure.PointEnergie;
        currentPa  = newChevalier.armure.PointArmure;
        currentPv = newChevalier.pv;
        currentPe = newChevalier.pe;
        name = newChevalier.name;
    }

    public void UpdateUser(Chevalier newChevalier)
    {
        currentCDF = newChevalier.currentCDF;
        currentPen = newChevalier.currentPen;
        currentPa = newChevalier.currentPa;
        currentPv = newChevalier.currentPv;
        currentPe = newChevalier.currentPe;
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
