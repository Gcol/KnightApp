using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Networking;

public class CheckVersion : MonoBehaviour
{
    public string urlToCheck = "https://teauorent.com/currentversion/";

    public GameObject PannelJeu;
    public GameObject PannelMaj;

    void Start()
    {
    }


    public void SearchVersion(string version)
    {

        StartCoroutine(CheckWebContent(version));
    }

    IEnumerator CheckWebContent(string version)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(urlToCheck))
        {
            yield return webRequest.SendWebRequest();

            if (webRequest.result == UnityWebRequest.Result.Success)
            {
                // Contenu de la page
                string webContent = webRequest.downloadHandler.text;

                // Vérifier le contenu ici
                if (webContent.Contains("Version=" + version))
                {
                    Debug.Log("Bonne VersionTrouvé");
                    PannelJeu.SetActive(true);
                    PannelMaj.SetActive(false);
                }
                else
                {
                    PannelMaj.SetActive(true);
                    PannelJeu.SetActive(false);
                }
            }
            else
            {
                Debug.LogError("Erreur lors de la requête : " + webRequest.error);
            }
        }
    }
}
