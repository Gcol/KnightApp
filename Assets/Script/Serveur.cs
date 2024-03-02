using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class Serveur : NetworkBehaviour
{
    public GameObject prefabToSpawn;
    public GameObject parentClientCanvas;

    public void SpawnObject()
    {
        if (!isServer)
            return;

        // Instantiate the GameObject on the server
        GameObject spawnedObject = Instantiate(prefabToSpawn, transform.position, Quaternion.identity, parentClientCanvas.transform);

        // Spawn the GameObject on all clientss
        NetworkServer.Spawn(spawnedObject);
    }
}
