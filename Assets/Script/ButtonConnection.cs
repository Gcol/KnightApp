using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonConnection : MonoBehaviour
{
    public Client currentC;

    // Start is called before the first frame update
    void Start()
    {
        currentC = FindObjectOfType<Client>();
    }

    public void AutoConnect()
    { currentC.AutoConnect(); }

}
