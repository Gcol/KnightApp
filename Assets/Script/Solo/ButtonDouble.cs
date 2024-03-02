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
        currentSprite.color = Color.grey;
    }


    public void PushButton()
    {
        if (active)
        {
            curretGO.SetActive(false);
            currentSprite.color = Color.white; 
            active = false;
        }
        else
        {
            curretGO.SetActive(true);
            currentSprite.color = Color.white;
            active = true;
        }
    }

}
