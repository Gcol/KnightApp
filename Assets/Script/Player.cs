using Mirror;
using UnityEngine;

public class Player : NetworkBehaviour
{
    [SyncVar]
    private Vector3 playerPosition;

    private void Update()
    {
        // Seul le joueur local peut contrôler son propre personnage
        if (!isLocalPlayer)
            return;

        // Mouvement du joueur local
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        transform.Translate(movement * Time.deltaTime * 5);

        // Envoyer la nouvelle position au serveur
        CmdUpdatePlayerPosition(transform.position);
    }

    [Command]
    private void CmdUpdatePlayerPosition(Vector3 newPosition)
    {
        // Mettre à jour la position du joueur sur le serveur
        playerPosition = newPosition;

        // Diffuser la nouvelle position à tous les clients
        RpcUpdatePlayerPosition(playerPosition);
    }

    [ClientRpc]
    private void RpcUpdatePlayerPosition(Vector3 newPosition)
    {
        // Mettre à jour la position du joueur sur tous les clients
        if (!isLocalPlayer)
        {
            transform.position = newPosition;
        }
    }
}
