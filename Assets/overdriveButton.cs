using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class overdriveButton : MonoBehaviour
{
    public OverdriveShower shower;
    public Overdrive ovedrive;
   
    public void PushButton()
    {
        int value;
        int.TryParse(transform.Find("Value").GetComponent<TextMeshProUGUI>().text, out value);


        shower.gameObject.SetActive(true);
    }
}
