using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Nouveau module", menuName = "Knight / Module")]
public class ModuleBase : ScriptableObject
{
    public string activation;
    [Multiline]
    public string description;
    public string duree;
    public string portee;
    public string energie;
    public string effet;
}
