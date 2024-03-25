using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WeaponShower : MonoBehaviour
{
    Weapon currentWeapon;
    public GameObject currentPannel;
    public bool activate;

    public void Init(Weapon newWeapon)
    {
        activate = false;
        currentWeapon = newWeapon;
        transform.Find("Name").GetComponent<TextMeshProUGUI>().text = currentWeapon.name;
        transform.Find("Panel/Effet").GetComponent<TextMeshProUGUI>().text = currentWeapon.effet;

        if (currentWeapon is WeaponContact)
            Init((WeaponContact)currentWeapon);

        if (currentWeapon is WeaponDistance)
            Init((WeaponDistance)currentWeapon);

    }

    public void Init(WeaponContact currentWeapon)
    {
        string pannelName = "WeaponContact";
        transform.Find("Panel/" + pannelName).gameObject.SetActive(true);
        transform.Find("Panel/" + pannelName + "/Value/Degat1Main").GetComponent<TextMeshProUGUI>().text = currentWeapon.Degat1Main;
        transform.Find("Panel/" + pannelName + "/Value/Degat2Main").GetComponent<TextMeshProUGUI>().text = currentWeapon.Degat2Main;
        transform.Find("Panel/" + pannelName + "/Value/Violence1Main").GetComponent<TextMeshProUGUI>().text = currentWeapon.Violence1Main;
        transform.Find("Panel/" + pannelName + "/Value/Violence2Main").GetComponent<TextMeshProUGUI>().text = currentWeapon.Violence2Main;
        transform.Find("Panel/" + pannelName + "/Value/Portee").GetComponent<TextMeshProUGUI>().text = currentWeapon.portee;

    }

    public void Init(WeaponDistance currentWeapon)
    {
        string pannelName = "WeaponDistance";
        transform.Find("Panel/" + pannelName).gameObject.SetActive(true);
        transform.Find("Panel/" + pannelName + "/Value/Degat").GetComponent<TextMeshProUGUI>().text = currentWeapon.Degat;
        transform.Find("Panel/" + pannelName + "/Value/Violence").GetComponent<TextMeshProUGUI>().text = currentWeapon.Violence;
        transform.Find("Panel/" + pannelName + "/Value/Portee").GetComponent<TextMeshProUGUI>().text = currentWeapon.portee;

    }

    public void PushButton()
    {
        activate = !activate;
        currentPannel.SetActive(activate);
    }
}
