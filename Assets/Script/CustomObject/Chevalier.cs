using UnityEngine;
using System.Collections.Generic;
using System.Collections;

using System;


[Serializable]
[CreateAssetMenu(fileName = "Nouveau Chevalier", menuName = "Knight / Chevalier")]
public class Chevalier : ScriptableObject
{
    public string name;
    public string alias;
    public Armure armure;
    public int pv;
    public int pe;

    public int currentPv;
    public int currentPe;
    public int currentPen;
    public int currentPa;
    public int currentCDF;

    public List<Weapon> allWeapon;

    [Multiline]
    public string description;

    public Dictionary<string, CharacValue> objectNames;

    [SerializeField]
    public AllStat newStat;
    public void Start()
    {
        objectNames = newStat.ToDictionary();
    }
}

[Serializable]
public class AllStat
{

    [SerializeField]
    public Stat[] allStat;
    
    public Dictionary<string, CharacValue> ToDictionary()
    {
        Dictionary<string, CharacValue> newDict = new Dictionary<string, CharacValue> ();
        foreach (var item in allStat)
        {
            newDict.Add(item.name, item.statValue);
        }
        return newDict;
    }
}

[Serializable]
public class Stat
{
    [SerializeField]
    public string name;
    [SerializeField]
    public CharacValue statValue;

}


[Serializable]
public class CharacValue
{
    [SerializeField]
    public int value;
    public int overdrive;
}
