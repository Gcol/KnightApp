using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum Rarete
{
    Standart,
    Avanc�,
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
    GrenadeAdh�sive,
    Fl�chetteANeuroToxine,
    Fl�chetteChoc,
    Fl�chetteANaNoMachines,
    TargePli�e,
    TargeD�plo�e,
    _600NE,
    T800,
    CarreayBarbel�,
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
    public List<caract�ristique> caract�ristique;
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
