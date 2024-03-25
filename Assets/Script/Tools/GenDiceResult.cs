using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class GenDiceResult : MonoBehaviour
{
    public GameObject dicePannel;
    public GameObject dicePrefab;


    public TMP_InputField nbDiceField;
    public TMP_InputField nbFaceDiceField;
    public TMP_InputField nbAddToDiceField;

    public TextMeshProUGUI status;
    public TextMeshProUGUI resultat;

    public Button currentButton;

    public int nbDice;
    public int nbDiceFace;
    public int nbOverdrive;

    public bool stop = false;

    public List<GameObject> allPreviousDice;

    // Start is called before the first frame update
    void Start()
    {
        stop = false;
        allPreviousDice = new List<GameObject>();
        CleanOldDice();
    }

    public void UpdateTexteStatus()
    {
        status.text = "Lancer : " + nbDice + "D" + nbDiceFace + " + " + nbOverdrive;
    }

    public void UpdateValueNbFace()
    {
        int.TryParse(nbFaceDiceField.text, out nbDiceFace);
        UpdateTexteStatus();
    }

    public void UpdateNbAdd()
    {
        int.TryParse(nbAddToDiceField.text, out nbOverdrive);
        UpdateTexteStatus();

    }

    public void UpdateValueNbDice()
    {
        int.TryParse(nbDiceField.text, out nbDice);
        UpdateTexteStatus();
    }


    public void CleanOldDice()
    {
        stop = true;
        foreach (GameObject curreGO in allPreviousDice)
        {
            Destroy(curreGO);
        }
        resultat.text = "En attente de Lancement";
        UpdateValueNbFace();
    }

    public void Lance()
    {
        CleanOldDice();
        stop = false;
        StartCoroutine(LanceCoRoutine(nbDice, nbDiceFace,  nbOverdrive));
    }

    IEnumerator LanceCoRoutine(int nbDes, int nbDiceFace,  int overdrive)
    {
        currentButton.interactable = false;
        resultat.text = "Des en cours de lancement";
        int nbReussit = 0;
        for (int i = 0; i < nbDes; i++)
        {
            if (stop)
                break;
            yield return new WaitForSeconds(0.5f);
            GameObject newDice = Instantiate(dicePrefab, dicePannel.transform);
            nbReussit += newDice.GetComponent<Dice>().Lancer(nbDiceFace, false);
            allPreviousDice.Add(newDice);
        }
        if (!stop)
            resultat.text = string.Format("{0} + {1} = {2}", nbReussit, overdrive, nbReussit + overdrive);
        currentButton.interactable = true;
    }


}