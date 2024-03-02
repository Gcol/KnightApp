using Mirror;
using UnityEngine;
using TMPro;

public class MyNetworkBehaviour : NetworkBehaviour
{
    public GameObject UpdateChapter;
    public TextMeshProUGUI myText;
    public GameObject canvasServer;
    // Définir une SyncVar pour la variable que vous souhaitez surveiller
    [SyncVar(hook = nameof(OnMyVariableChanged))]
    public int myVariable;


    void Start()
    {
        if (isServer)
        {
            UpdateChapter.SetActive(true);
            canvasServer = GameObject.Find("ServerCanvas");
            canvasServer.SetActive(false);
            canvasServer.SetActive(true);
        }
    }
    // Méthode appelée chaque fois que la valeur de myVariable change
    private void OnMyVariableChanged(int oldValue, int newValue)
    {
        Debug.Log($"myVariable changed from {oldValue} to {newValue}");
        myText.text = "valeur = " + newValue;
        // Ajoutez ici le code que vous souhaitez exécuter lorsque la variable change
    }

    // Méthode pour modifier la variable et déclencher sa synchronisation
    public void SetMyVariable(int newValue)
    {
        Debug.Log("Change value to " + newValue + " tu es le serveur " + isServer);

        // Modifier la variable uniquement sur le serveur
        if (isServer)
        {
            Debug.Log("Change value to " + newValue);
            myVariable = newValue;
            myText.text = "valeur = " + newValue;
        }
    }
}
