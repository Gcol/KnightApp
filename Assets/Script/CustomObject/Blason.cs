using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Personnage / Blason")]
public class Blason : CreaPerso
{
    public Sprite grandImage;
    [TextArea(2, 100)]
    public string voeu;
}
