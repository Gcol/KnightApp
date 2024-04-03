using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class ArmementShower : MonoBehaviour
{

    private GridLayoutGroup itemGrid;
    public  int nbItem;
    public GameObject itemPrefab;
    public Transform itemPannel;
    public Dictionary<String, GameObject> itemButton;

    public Vector2 defaultSize;


    // Start is called before the first frame update
    void Start()
    {
        itemButton = new Dictionary<String, GameObject>();
        itemGrid = GetComponent<GridLayoutGroup>();
        itemPannel = transform;
        if (gameObject.name == "Armement")
        {
            foreach (GameObject gameObject in GameObject.FindGameObjectsWithTag("Weapon"))
            {
                nbItem++;
                string newName = findLastName(gameObject.GetComponent<ButtonCreaPerso>().entity.name, true);
                itemButton[newName] = gameObject;
            }
        }
        UpdateGrid();
        gameObject.SetActive(false);
    }


    public void AddItem(ShopItem weapon)
    {
        nbItem++;
        GameObject newWeapon = Instantiate(itemPrefab, itemPannel);
        newWeapon.SetActive(true);
        newWeapon.GetComponent<ButtonCreaPerso>().Init(weapon);

        itemButton[findLastName(newWeapon.name, true)] = newWeapon;

        UpdateGrid();
    }

    public void RemoveItem(ShopItem weapon)
    {
        string searchName = findLastName(weapon.name, false);
        nbItem--;
        GameObject oldWeapon = itemButton[searchName];
        itemButton.Remove(searchName);
        Destroy(oldWeapon);
        UpdateGrid();
    }

    public string findLastName(string name, bool isNewName)
    {
        string newName = name;
        int index_name = 0;
        while (itemButton.ContainsKey(newName))
        {
            index_name++;
            newName = name + "_" + index_name;
        }
        if (!isNewName && index_name == 1)
            return name;
        if (!isNewName && index_name > 0)
            return name + "_" + (index_name - 1);
        else return newName;
    }

    void UpdateGrid()
    {
        if (nbItem > 0) 
            itemGrid.cellSize = new Vector2( defaultSize.x / (nbItem > 4 ? 4 : nbItem), defaultSize.y / (1 + ((int)nbItem / 4)));
    }

}

