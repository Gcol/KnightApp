using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

[Serializable]
public class creatureRencontre
{
    public Creature creature;
    public int nombreCreature;
}

[CreateAssetMenu(fileName = "Nouvelle Scene", menuName = "Knight / Mission")]
public class MissionScene : Mission
{
    [SerializeField]
    public creatureRencontre[] creatures;
    [TextArea(10, 100)]
    public string SceneDescription;
}
