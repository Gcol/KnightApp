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

    public int Lancer(int nbFace = 6, bool caracTest = true)
    {
        int randomInt = Random.Range(1, nbFace + 1);

        resultat.text = randomInt.ToString();
        if (caracTest)
        {
            if (randomInt % 2 == 0)
            {
                resultat.color = Color.green;
            }
            else
                resultat.color = Color.red;
            return (randomInt + 1) % 2;
        }
        return (randomInt);
    }
}
