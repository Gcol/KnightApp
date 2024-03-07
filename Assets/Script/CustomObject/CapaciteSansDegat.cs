using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
[CreateAssetMenu(fileName = "Nouvelle Capacite Sans Degat", menuName = "Knight / CapaciteSansDegat")]
public class CapaciteSansDegat : Capacite
{
    public string energiCout;
    public string duree;
    public string activation;
    [Multiline]
    public string effet;
}
