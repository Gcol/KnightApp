using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Nouveau Tarot", menuName = "Knight / Tarot")]
public class Tarot : CreaPerso
{

    public caractéristique caract;
    [TextArea(1, 100)]
    public string passe;
    [TextArea(3, 100)]
    public string bonus;
    [TextArea(3, 100)]
    public string avantagePj;
    [TextArea(3, 100)]
    public string desavantagePj;
    [TextArea(3, 100)]
    public string avantageIA;
    [TextArea(3, 100)]
    public string desavantageIA;
}
