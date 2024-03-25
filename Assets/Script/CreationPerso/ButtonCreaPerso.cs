using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonCreaPerso : MonoBehaviour
{
    public CreaPerso entity;
    public TextMeshProUGUI cText;
    public Image cImage;

    // Start is called before the first frame update
    void Start()
    {
        cText.text = entity.name;
        cImage.sprite = entity.currentSprite;
    }
}
