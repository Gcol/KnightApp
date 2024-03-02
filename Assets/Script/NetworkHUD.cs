using Mirror;
using TMPro;
using UnityEngine;
using System.Net;

public class NetworkHUD : NetworkBehaviour
{
    public TextMeshProUGUI ipAddressText;
    public TextMeshProUGUI nbPlayer;

    private void Update()
    {
        if (NetworkServer.connections != null)
        {
            nbPlayer.text = "Nb player : " + NetworkServer.connections.Count;
        
        }
        // V�rifie si le NetworkManager est en cours d'ex�cution et que l'adresse IP est disponible
        if (NetworkManager.singleton != null && NetworkManager.singleton.networkAddress != null)
        {
            // Obtient l'adresse IP locale de la machine h�te
            string localIPAddress = GetLocalIPAddress();

            // Affiche l'adresse IP sur votre HUD
            ipAddressText.text = "Server IP: " + localIPAddress;
        }
    }

    // M�thode pour obtenir l'adresse IP locale de la machine h�te
    private string GetLocalIPAddress()
    {
        // Obtient toutes les interfaces r�seau de la machine h�te
        IPAddress[] localIPs = Dns.GetHostAddresses(Dns.GetHostName());

        // Recherche une adresse IP IPv4 non localhost
        foreach (IPAddress addr in localIPs)
        {
            if (addr.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork && !IPAddress.IsLoopback(addr))
            {
                return addr.ToString();
            }
        }

        // Si aucune adresse IP n'est trouv�e, retourne une cha�ne vide
        return "";
    }


}
