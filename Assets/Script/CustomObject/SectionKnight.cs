using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
[CreateAssetMenu(fileName = "Nouvelle Section", menuName = "Knight / Section")]
public class SectionKnight : CreaPerso
{
    public Sprite grandImage;
    [SerializeField]
    ChevalierChef chefSection;
    [TextArea(3, 20)]
    public string Bonus;
    [TextArea(3, 20)]
    public string Avantage;
    [TextArea(3, 20)]
    public string Inconvenient;
    public caractéristique caract;
}
