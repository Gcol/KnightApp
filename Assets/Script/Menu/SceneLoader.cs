using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // Fonction pour charger une scène par son nom
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    // Fonction pour quitter le jeu
    public void QuitGame()
    {
        Application.Quit();
    }
}
