using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TartoCard : MonoBehaviour
{
    public CreaPerso entity;
    public TextMeshProUGUI cardText;
    public Image cardImage;

    // Start is called before the first frame update
    void Start()
    {
        cardText.text = entity.name;
        cardImage.sprite = entity.currentSprite;
    }

}
