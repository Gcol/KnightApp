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

    public User(Chevalier currentChevalier)
    {
        currentCDF = currentChevalier.currentCDF;
        currentPen = currentChevalier.currentPen;
        currentPa  = currentChevalier.currentPa;
        currentPv = currentChevalier.currentPv;
        currentPe = currentChevalier.currentPe;
        name = currentChevalier.name;
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
