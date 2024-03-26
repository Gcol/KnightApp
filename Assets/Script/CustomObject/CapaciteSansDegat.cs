using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
[CreateAssetMenu(fileName = "Nouvelle Capacite Sans Degat", menuName = "Knight / CapaciteSansDegat")]
public class CapaciteSansDegat : Capacite
{
    [TextArea(0, 100)]
    public string energiCout;
    [TextArea(0, 100)]
    public string activation;
    [TextArea(0, 100)]
    public string duree;
    [TextArea(0, 100)]
    public string effet;
}
