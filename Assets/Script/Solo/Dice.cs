using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dice : MonoBehaviour
{
    public TextMeshProUGUI resultat;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int Lancer()
    {
        int randomInt = Random.Range(1,6);

        resultat.text = randomInt.ToString();
        if (randomInt % 2 == 0)
        {
            resultat.color = Color.green;
        }
        else
            resultat.color = Color.red;

        Debug.Log("Je tire " + randomInt + " je renvoie " + (randomInt + 1) % 2);
        return (randomInt + 1) % 2;
    }
}
