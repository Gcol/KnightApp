using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ArmeType
{
    melee,
    distance
}

[Serializable]
[CreateAssetMenu(fileName = "Nouvelle Arme", menuName = "Knight / Arme")]
public class Arme : ScriptableObject
{
    public ArmeType typeArme;
    public string Degat1Main;
    public string Degat2Main;
    public string Violence1Main;
    public string Violence2Main;
    public string effet;
    public string portee;
}
