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
    public string effet;
    public string portee;
}
