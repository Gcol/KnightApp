using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChoixCaracCombo : MonoBehaviour
{
    public string name;
    public Image currentImage;
    public List<Color> allColor;
    public TextMeshProUGUI caracTextValue;
    public TextMeshProUGUI caracTextOverdrive;

    private int valueCarac;
    private int overdriveCarac;

    public LancerDeDes currentLDD;


    public void AddCaracToCombo()
    {
        //TODO faire mieux (pourquoi le load a chaque fois (serais ce possible de le gérer au chargement du perso?)
        int.TryParse(caracTextValue.text, out int valueCarac);
        if (!int.TryParse(caracTextOverdrive.text, out int overdriveCarac))
            overdriveCarac = 0;

        currentLDD.AddCombo(name, valueCarac, overdriveCarac, currentImage, allColor);
    }

    // Start is called before the first frame update
    void Start()
    {
        currentLDD = FindObjectOfType<LancerDeDes>();
        currentImage.color = allColor[0];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
