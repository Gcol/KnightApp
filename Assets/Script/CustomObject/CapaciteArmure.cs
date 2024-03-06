using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
[CreateAssetMenu(fileName = "Nouvelle Capacite", menuName = "Knight / Capacite")]
public class CapaciteArmure : ScriptableObject
{
    public int degatBonus;
    public int nbDiceDegat;
    public int nbDiceViolence;
    public int violenceBonus;
    public int energiCout;
    public string portee;
    public string duree;
    public string activation;
    public string effet;
}
