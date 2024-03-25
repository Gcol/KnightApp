using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Nouveau Hf", menuName = "Personnage / HautFait")]
public class HautFait : CreaPerso
{
    public Sprite grandImage;
    [TextArea(2, 40)]
    public string Condition;
    [TextArea(2, 40)]
    public string Bonus;
    [TextArea(2, 40)]
    public string Surnoms;

}
