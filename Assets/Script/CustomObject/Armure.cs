using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Nouvelle Armure", menuName = "Knight / Armure")]
public class Armure : CreaPerso
{
    public Sprite currentSprite;
    public int PointArmure;
    public int PointEnergie;
    public int ChampDeForce;
    public List<Capacite> allCapacite;
    [TextArea(2,100)]
    public string evolution;
}
