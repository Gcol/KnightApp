using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Nouveau module", menuName = "Knight / Module")]
public class ModuleArmure : ScriptableObject
{
    public string activation;
    public string description;
    public string durée;
    public int energie;
}
