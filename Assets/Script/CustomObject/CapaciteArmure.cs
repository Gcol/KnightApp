using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
[CreateAssetMenu(fileName = "Nouvelle Capacite", menuName = "Knight / Capacite")]
public class CapaciteArmure : Capacite
{
    public int nbDiceDegat;
    public int nbDiceViolence;
    public int degatBonus;
    public int violenceBonus;
    public string energiCout;
    public string portee;
    public string duree;
    public string activation;
    [Multiline]
    public string effet;
}
