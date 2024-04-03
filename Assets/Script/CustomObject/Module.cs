using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum moduleType
{
    déplacement,
    combat,
    distance,
    visée,
    défense,
    tactiques,
    utilitaires,
    amélioration,
    automatisé
}

[Serializable]
public class EvolutionModule
{
    public Rarete rarete;
    public string duree;
    public int price;
    [TextArea(1,200)]
    public string description;
    public DegatArme degatModule;
}

[Serializable]
public class SlotModuleSize
{
    public SlotModule slotModule;
    public int size=1;

    public SlotModuleSize()
    {
        size = 1;
    }
}

[CreateAssetMenu(fileName = "Nouveau Module", menuName = "Knight / Module")]
public class Module : ShopItem
{
    public moduleType moduleType;
    public PorteArme porte;
    public string activation;
    public string durée;
    public string energie;
    public DegatArme degatModule;
    public List<SlotModuleSize> slot;
    public List<EvolutionModule> evolutionModules;
    private int lvlModule;
}
