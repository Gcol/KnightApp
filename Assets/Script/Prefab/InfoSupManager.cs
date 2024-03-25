using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InfoSupManager : MonoBehaviour
{
    public Image imageFond;
    public TextMeshProUGUI descriptionText;

    public TextMeshProUGUI choicePannelText;
    public GameObject lastPannel;




    public void ActiveOnePannel(GameObject pannel)
    {
        if (pannel != lastPannel)
        {
            pannel.SetActive(true);
            choicePannelText.text = pannel.name;
            if (lastPannel != null)
                lastPannel.SetActive(false);
            lastPannel = pannel;

        }
    }



    public void ChangeInfo(Sprite newImage, string newText)
    {
        imageFond.sprite = newImage;
        descriptionText.text = newText;
    }
}
