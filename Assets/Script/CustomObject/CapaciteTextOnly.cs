using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
[CreateAssetMenu(fileName = "Nouvelle Capacite Text", menuName = "Knight / CapaciteText")]
public class CapaciteTextOnly : Capacite
{
    public string mainName;
    public string mainDesc;
    public List<string> enteteText;
    [Multiline]
    public List<string> allText;
}
