using Mirror;
using UnityEngine;
using UnityEngine.SceneManagement; // Assurez-vous d'importer le namespace SceneManager


public class Client : MonoBehaviour
{
    public NetworkManager networkManager;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void AutoConnect()
    {
        // Démarre automatiquement en tant que client
        networkManager.StartClient();
        SceneManager.LoadScene("Online");

    }
}
