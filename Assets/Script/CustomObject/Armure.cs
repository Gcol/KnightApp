using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
    Perception,
    Rien
}
[Serializable]
public struct moduleSlot
{
    public SlotModule nameSlot;
    public int number;
    public List<Module> modules;

    public moduleSlot(SlotModule nameSlot, int number)
    {
        this.number = number;
        this.nameSlot = nameSlot;
        this.modules = new List<Module>();
    }

}

public enum SlotModule
{
    BradD,
    T�te,
    BrasG,
    Torse,
    JambeD,
    JambeL,
    BrasChoice,
    JambeChoice,
    TeteTorseChoice,
    TeteBrasChoice
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

    //[Serializable]
    //public Dictionary<String, int> SizeSlot = new List<int>();

    [Serialize]
    public Dictionary<SlotModule, moduleSlot> slot = new Dictionary<SlotModule, moduleSlot>()
    {
      {SlotModule.BradD, new moduleSlot(SlotModule.BradD, 0)},
      {SlotModule.T�te,new moduleSlot(SlotModule.T�te, 0)},
      {SlotModule.BrasG,new moduleSlot(SlotModule.BrasG, 0)},
      {SlotModule.Torse,new moduleSlot(SlotModule.Torse, 0)},
      {SlotModule.JambeD,new moduleSlot(SlotModule.JambeD, 0)},
      {SlotModule.JambeL,new moduleSlot(SlotModule.JambeL, 0) }
    };

    public List<Module> modules;
    public evolutionStr[] evolution;

}
