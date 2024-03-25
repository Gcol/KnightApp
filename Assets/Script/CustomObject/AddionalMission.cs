using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


[SerializeField]
public enum ChevalierChef
{
    Lancelot,
    Lamorak,
    Kay,
    Bohort,
    Gauvain,
    Palomydès,
    Dagonnet,
    Sagramor,
    Bédivère
}

[CreateAssetMenu(fileName = "0 - MissionBonus", menuName = "Knight / AdditionalMission")]
public class AdditionalMission : ScriptableObject
{
    [SerializeField]
    public Dictionary<ChevalierChef, string> mission  = new Dictionary<ChevalierChef, string>()
    {
        {ChevalierChef.Lancelot, ""},
        {ChevalierChef.Lamorak, ""},
        {ChevalierChef.Kay, ""},
        {ChevalierChef.Bohort, ""},
        {ChevalierChef.Gauvain, ""},
        {ChevalierChef.Palomydès, ""},
        {ChevalierChef.Dagonnet, ""},
        {ChevalierChef.Sagramor, ""},
        {ChevalierChef.Bédivère, ""},
    };
}
