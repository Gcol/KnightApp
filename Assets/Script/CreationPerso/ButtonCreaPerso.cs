using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonCreaPerso : MonoBehaviour
{
    public CreaPerso entity;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.name = entity.name;
        transform.Find("Text (TMP)").GetComponent<TextMeshProUGUI>().text = entity.name;
        gameObject.GetComponent<Image>().sprite = entity.currentSprite;
    }
}
