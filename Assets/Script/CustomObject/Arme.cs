using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum Rarete
{
    Standart,
    Avancé,
    Rare,
    Espoir
}

public enum TypeAttaque
{
    contact,
    tir,
    GrenadeExplosive,
    GrenadeAnti_Blindage,
    GrenadeIncendiaire,
    UneMain,
    DeuxsMains,
    TirBouclierDeploye,
    Missiles,
    Roquettes,
    GrenadeAdhésive,
    FléchetteANeuroToxine,
    FléchetteChoc,
    FléchetteANaNoMachines,
    TargePliée,
    TargeDéploée,
    _600NE,
    T800,
    CarreayBarbelé,
    CarreauANeuroToxine,
    CarreauChoc,
    CarreauANanoMachines,
    Pavois,
    Charge,
    Aucun

}
public enum PorteArme
{
    Contact_2m,
    Courte_2_15_m,
    Moyenne_15_50m,
    Longue_50_300m,
    Lointaine_300_m,
    Aucun
}


[Serializable]
public class CalculDegat
{
    public int nbDice;
    public int addDegat = 0;
    public List<caractéristique> caractéristique;
}

[Serializable]
[CreateAssetMenu(fileName = "Nouvelle Arme", menuName = "Knight / Arme")]
public class Arme : ShopItem
{
    public string surnom;
    public List<DegatArme> degatArmes;
}


[Serializable]
public class DegatArme
{
    public TypeAttaque typeAttaque;
    public CalculDegat degat;
    public CalculDegat violence;
    public PorteArme portee;
    public List<EffectLvl> effet;
}
