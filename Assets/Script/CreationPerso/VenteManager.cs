using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class VenteManager : MonoBehaviour
{
    public ShopItem currentObj;
    public ArmurerieManager armurerieManager;
    public CreationPersoManager CreationPerso;

    public GameObject armureriInfoPannel;
    public TextMeshProUGUI supInfoTitre;
    public Image supInfoImage;
    public TextMeshProUGUI supInfoDesc;
    public TextMeshProUGUI supInfoEffet;
    public TextMeshProUGUI supInfoButton;



    public void PushButton(ButtonCreaPerso script)
    {
        currentObj = (ShopItem)script.entity;
        armureriInfoPannel.SetActive(true);
        supInfoButton.text = "Vendre " + currentObj.name + " pour " + currentObj.price + " pg";
        supInfoImage.sprite = currentObj.currentSprite;
        supInfoTitre.text = currentObj.name;
        supInfoDesc.text = currentObj.desc;
        supInfoEffet.text = "A definir";
    }

    public void ApplyVente()
    {
        armurerieManager.UpdatePG(currentObj.price);
        if (currentObj is Arme)
            CreationPerso.Sell((Arme)currentObj);
        if (currentObj is Module)
            CreationPerso.Sell((Module)currentObj);

    }

}
