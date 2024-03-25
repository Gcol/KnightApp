using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Nouvelle Effet", menuName = "Knight / Effet")]
public class Effet : ScriptableObject
{
    [TextArea(20, 100)]
    public string description;
}
