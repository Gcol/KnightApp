using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[Serializable]
public class EffectLvl
{
    [SerializeField]
    Effet effet;
    [SerializeField]
    int level;
}

[CreateAssetMenu(fileName = "Nouvelle Effet", menuName = "Knight / Effet")]
public class Effet : ScriptableObject
{
    [TextArea(1, 100)]
    public string description;
}
