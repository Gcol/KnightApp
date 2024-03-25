using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InitiativeManager : MonoBehaviour
{
    public GameObject PannelInitiative;
    public GameObject PrefabInitatiative;

    public Dictionary<string, GameObject> allPlayer;


    // Start is called before the first frame update
    void Start()
    {
        allPlayer = new Dictionary<string, GameObject>();
        AddPlayer("Test", 12);
    }

    public void StartNewRound()
    {
        foreach(GameObject player in allPlayer.Values)
            Destroy(player);
        allPlayer.Clear();

    }

    public void AddPlayer(string name, int pv)
    {
        GameObject newPrefabInstance = Instantiate(PrefabInitatiative, PannelInitiative.transform);
        allPlayer.Add(name, newPrefabInstance);
        newPrefabInstance.GetComponent<Initiative>().Init(name, pv);
    }

}
