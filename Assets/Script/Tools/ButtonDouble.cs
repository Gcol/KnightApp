using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonDouble : MonoBehaviour
{
    public GameObject curretGO;
    public Image currentSprite;

    public bool active = true;

    void Start()
    {
        PushButton();
    }

    public void PushButton()
    {
        curretGO.SetActive(active);
        if (currentSprite != null)
            currentSprite.color = active ? Color.grey : Color.white;
        active = !active;
    }

}
