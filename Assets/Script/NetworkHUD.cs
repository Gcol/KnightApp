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
        // Vérifie si le NetworkManager est en cours d'exécution et que l'adresse IP est disponible
        if (NetworkManager.singleton != null && NetworkManager.singleton.networkAddress != null)
        {
            // Obtient l'adresse IP locale de la machine hôte
            string localIPAddress = GetLocalIPAddress();

            // Affiche l'adresse IP sur votre HUD
            ipAddressText.text = "Server IP: " + localIPAddress;
        }
    }

    // Méthode pour obtenir l'adresse IP locale de la machine hôte
    private string GetLocalIPAddress()
    {
        // Obtient toutes les interfaces réseau de la machine hôte
        IPAddress[] localIPs = Dns.GetHostAddresses(Dns.GetHostName());

        // Recherche une adresse IP IPv4 non localhost
        foreach (IPAddress addr in localIPs)
        {
            if (addr.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork && !IPAddress.IsLoopback(addr))
            {
                return addr.ToString();
            }
        }

        // Si aucune adresse IP n'est trouvée, retourne une chaîne vide
        return "";
    }


}
