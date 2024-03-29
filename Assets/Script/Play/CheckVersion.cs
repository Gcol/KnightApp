using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Networking;

public class CheckVersion : MonoBehaviour
{
    public string urlToCheck = "https://teauorent.com/currentversion/";

    public GameObject PannelJeu;
    public GameObject PannelMaj;


    public void Start()
    {
        StartCoroutine(CheckWebContent("1.6"));
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

                // V�rifier le contenu ici
                if (webContent.Contains("Version=" + version))
                {
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
                Debug.LogError("Erreur lors de la requ�te : " + webRequest.error);
            }
        }
    }
}
