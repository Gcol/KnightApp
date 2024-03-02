using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChoixComboFromCarac : MonoBehaviour
{
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

        currentLDD.AddCombo(gameObject.name, valueCarac, overdriveCarac, currentImage, allColor);
    }

    // Start is called before the first frame update
    void Start()
    {
        currentImage = transform.Find(gameObject.name + "Pannel").gameObject.GetComponent<Image>();
        caracTextValue = transform.Find(gameObject.name).gameObject.transform.Find(gameObject.name + "Stat").gameObject.GetComponent<TextMeshProUGUI>();
        caracTextOverdrive = transform.Find(gameObject.name).gameObject.transform.Find(gameObject.name + "OD").gameObject.GetComponent<TextMeshProUGUI>();
        float blacknessAmount = 0.3f;
        Color modifiedColor =  new Color(currentImage.color.r % blacknessAmount, currentImage.color.g % blacknessAmount, currentImage.color.b % blacknessAmount, 1f);

        allColor.Add(currentImage.color);
        allColor.Add(modifiedColor);
        currentLDD = FindObjectOfType<LancerDeDes>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
