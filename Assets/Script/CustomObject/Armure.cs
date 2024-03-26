using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum caract�ristique
{
    Chair,
    B�te,
    Dame,
    Masque,
    Machine,
    D�placement,
    Force,
    Endurance,
    Hargne,
    Combat, 
    Instinct,
    Tir, 
    Savoir,
    Technique,
    Aura,
    Parole,
    Sang_Froid,
    Discr�tion,
    Dext�rit�,
    Perception
}
[Serializable]
public struct moduleSlot
{
    public string nameSlot;
    public int number;

    public moduleSlot(string nameSlot, int number)
    {
        this.number = number;
        this.nameSlot = nameSlot;
    }

}
public enum generationMetaArmure
{
    Premiere_Generation,
    Deuxieme_Generation,
    Troisieme_Generation
}
[Serializable]
public struct evolutionStr
{
    public int numberPG;
    [TextArea(0, 100)]
    public string effect;
    public bool buyable;
}

[CreateAssetMenu(fileName = "Nouvelle Armure", menuName = "Knight / Armure")]
public class Armure : CreaPerso
{
    [TextArea(0,100)]
    public string historique;
    public int PointArmure;
    public int PointEnergie;
    public int ChampDeForce;
    public generationMetaArmure generationMetaArmure;
    public List<Capacite> allCapacite;
    public List<caract�ristique> overdrive;
    
    
    public moduleSlot[] slot = new moduleSlot[]
    {
      new moduleSlot("BrasD", 0),
      new moduleSlot("T�te", 0),
      new moduleSlot("BrasG", 0),
      new moduleSlot("Torse", 0),
      new moduleSlot("JambeD", 0),
      new moduleSlot("JambeL", 0)
    };
    public evolutionStr[] evolution;
}
