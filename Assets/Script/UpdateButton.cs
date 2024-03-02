
using Mirror;
using UnityEngine;

public class UpdateButton : NetworkBehaviour
{
    public int state;
    public NetworkManager currentNM;
    void Start()
    {

    }

    private void RpcUpdateHUD(int newState)
    {
        currentNM.ServerChangeScene("OnlineScene");
    }
}
