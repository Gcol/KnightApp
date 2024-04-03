using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonCreaPerso : MonoBehaviour
{
    public CreaPerso entity;
    public MonoBehaviour script;


    // Start is called before the first frame update
    void Start()
    {
        UpdateAff();
    }

    public void Init(CreaPerso newEntity)
    {
        entity = newEntity;

        UpdateAff();
    }

    void UpdateAff()
    {
        gameObject.name = entity.name;
        transform.Find("Text (TMP)").GetComponent<TextMeshProUGUI>().text = entity.name;
        gameObject.GetComponent<Image>().sprite = entity.currentSprite;
    }

    public void PushButton()
    {
        Debug.Log(GetComponent<Button>());
        ((TarotManager)script).PushButton(entity, GetComponent<Button>());
    }
}
