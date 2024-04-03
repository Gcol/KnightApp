using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public enum caractéristique
{
    Chair,
    Bête,
    Dame,
    Masque,
    Machine,
    Déplacement,
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
    Discrétion,
    Dextérité,
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
    Tête,
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
    public List<caractéristique> overdrive;

    //[Serializable]
    //public Dictionary<String, int> SizeSlot = new List<int>();

    [Serialize]
    public Dictionary<SlotModule, moduleSlot> slot = new Dictionary<SlotModule, moduleSlot>()
    {
      {SlotModule.BradD, new moduleSlot(SlotModule.BradD, 0)},
      {SlotModule.Tête,new moduleSlot(SlotModule.Tête, 0)},
      {SlotModule.BrasG,new moduleSlot(SlotModule.BrasG, 0)},
      {SlotModule.Torse,new moduleSlot(SlotModule.Torse, 0)},
      {SlotModule.JambeD,new moduleSlot(SlotModule.JambeD, 0)},
      {SlotModule.JambeL,new moduleSlot(SlotModule.JambeL, 0) }
    };

    public List<Module> modules;
    public evolutionStr[] evolution;

}
