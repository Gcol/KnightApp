using UnityEngine;

[CreateAssetMenu(fileName = "NewMission", menuName = "Knight / Mission")]
public class Mission : ScriptableObject
{
    public string name;
    [Multiline]
    public string description;
}