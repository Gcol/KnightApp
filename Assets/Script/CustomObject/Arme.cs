using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ArmeType
{
    melee,
    distance
}
public enum PorteArme
{
    Contact_2m,
    Courte_2_15_m,
    Moyenne_15_50m,
    Longue_50_300m,
    Lointaine_300_m,
}


[Serializable]
[CreateAssetMenu(fileName = "Nouvelle Arme", menuName = "Knight / Arme")]
public class Arme : CreaPerso
{
    public ArmeType typeArme;
    public PorteArme porteArme;
    public string Degat1Main;
    public string Degat2Main;
    public string Violence1Main;
    public string Violence2Main;
    public string effet;
    public string portee;
}
