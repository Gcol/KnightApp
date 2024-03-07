using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LancerDeDes : MonoBehaviour
{
    public GameObject lancerDeDesPannel;
    public GameObject dicePannel;
    public GameObject dicePrefab;

    public Button currentButton;

    public TextMeshProUGUI resultat;
    public TextMeshProUGUI buttonLancerText;


    public List<string> comboName;
    public int nbDice;
    public int nbOverdrive;

    bool DiceThrow;

    public List<GameObject> allPreviousDice;

    // Start is called before the first frame update
    void Start()
    {
        DiceThrow = false;
        comboName = new List<string>();
        nbDice = 0;
        nbOverdrive = 0;
        UpdateText();
        currentButton.interactable = false;
        allPreviousDice = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Lance()
    {
        if (!DiceThrow )
        {
            lancerDeDesPannel.SetActive(true);
            foreach (GameObject curreGO in allPreviousDice)
            {
                Destroy(curreGO);
            }
            StartCoroutine(LanceCoRoutine(nbDice, nbOverdrive));
        }
    }

    IEnumerator LanceCoRoutine(int nbDes, int overdrive)
    {
        DiceThrow = true;
        resultat.text = "Des en cours de lancement";
        int nbReussit = 0;
        for (int i = 0; i < nbDes; i++)
        {
            yield return new WaitForSeconds(0.5f);
            GameObject newDice = Instantiate(dicePrefab, dicePannel.transform);
            nbReussit += newDice.GetComponent<Dice>().Lancer();
            allPreviousDice.Add(newDice);
        }
        resultat.text = string.Format("{0} + {1} OD = {2} réussite", nbReussit, overdrive, nbReussit + overdrive);
        DiceThrow = false;
    }


    public void AddCombo(string name, int newNbDice, int newNbOverdrive, Image myButton, List<Color> currentColor)
    {
        if (comboName.Contains(name))
        {
            comboName.Remove(name);
            nbDice -= newNbDice;
            nbOverdrive -= newNbOverdrive;
            myButton.color = currentColor[0];
            currentButton.interactable = false;
        }
        else if (comboName.Count < 2)
        {
            comboName.Add(name);
            nbDice += newNbDice;
            nbOverdrive += newNbOverdrive;
            myButton.color = currentColor[1];
            if (comboName.Count == 2)
                currentButton.interactable = true;

        }
        UpdateText();
    }

    public void UpdateText()
    {
        string newText = "";
        if (comboName.Count > 0)
        {
            newText = string.Join(" + ", comboName);
        }
        else
        {
            newText = "Choississez un combo";
        }
        buttonLancerText.text = newText;
    }

}
