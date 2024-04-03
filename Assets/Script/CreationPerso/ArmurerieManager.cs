using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Unity.Burst.Intrinsics.X86.Avx;
using TMPro;


public class ArmurerieManager : MonoBehaviour
{
    public CreationPersoManager cMM;

    public CreaPerso currentObj;//Todo voir pour les modules
    public int pg;
    public TextMeshProUGUI textPg;

    public Dictionary<int, List<Button>> buyByPrice;
    public GameObject pannelArme;
    public GameObject pannelModule;


    public GameObject armureriInfoPannel;
    public TextMeshProUGUI supInfoTitre;
    public Image supInfoImage;
    public TextMeshProUGUI supInfoDesc;
    public TextMeshProUGUI supInfoEffet;
    public TextMeshProUGUI supInfoButton;




    public void UpdatePerso()
    {
        pg -= ((ShopItem)currentObj).price;
        if (currentObj is Arme)
            cMM.UpdatePerso((Arme)currentObj);
        if (currentObj is Module)
            cMM.UpdatePerso((Module)currentObj);
        UpdateTextPg();
    }

    public void UpdatePG(int addedValue)
    {
        pg += addedValue;
        if (gameObject.activeSelf)
            UpdateTextPg();
    }
    // Start is called before the first frame update
    void Start()
    {
        pannelArme.SetActive(true);
        pannelModule.SetActive(true);
        buyByPrice = new Dictionary<int, List<Button>>();
        foreach(GameObject button in GameObject.FindGameObjectsWithTag("Shop"))
        {
            int price = ((ShopItem)button.GetComponent<ButtonCreaPerso>().entity).price;
            if (!buyByPrice.ContainsKey(price))
                buyByPrice[price] = new List<Button>();
            buyByPrice[price].Add(button.GetComponent<Button>());
        }
        UpdateTextPg();
        pannelArme.SetActive(false);
        pannelModule.SetActive(false);

    }


    void UpdateTextPg()
    {
        textPg.text = "Vous avez encore :" + pg + " pg";
        foreach(int price in buyByPrice.Keys)
        {
            if (pg < price)
            {
                foreach(Button button in buyByPrice[price])
                    button.interactable = false;
            }
            else
            {
                //TODO optimiser ca ?
                foreach (Button button in buyByPrice[price])
                    button.interactable = true;
            }
        }
    }



    public void PushButton(ButtonCreaPerso script)
    {
        currentObj = script.entity;
        armureriInfoPannel.SetActive(true);
        supInfoButton.text = "Acheter " + currentObj.name + " pour " + ((ShopItem)currentObj).price + " pg";
        supInfoImage.sprite = currentObj.currentSprite;
        supInfoTitre.text = currentObj.name;
        supInfoDesc.text = currentObj.desc;
        supInfoEffet.text = "A definir";
    }

    
}
