using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Nouvelle Armure", menuName = "Knight / Armure")]
public class Armure : ScriptableObject
{
    public Sprite currentSprite;
    public int PointArmure;
    public int PointEnergie;
    public int ChampDeForce;
    public List<Capacite> allCapacite;
    public List<Arme> allArme;
    public List<ModuleBase> allModule;
}
