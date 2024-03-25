using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Nouveau Archetype", menuName = "Personnage / Archetype")]
public class Archetype : CreaPerso
{
    public Sprite grandImage;
    [TextArea(2, 20)]
    public string bonus;
}
