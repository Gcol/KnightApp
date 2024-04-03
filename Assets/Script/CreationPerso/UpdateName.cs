using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UpdateName : MonoBehaviour
{
    public TMP_InputField persoName;
    public TMP_InputField alias;
    public TMP_InputField surname;
    public CreationPersoManager persoManager;

    public TextMeshProUGUI fullName;

    // Start is called before the first frame update
    void Start()
    {
        persoManager = FindAnyObjectByType<CreationPersoManager>();
        fullName.text = "";
    }

    public void nameUpdate()
    {
        fullName.text = persoName.text + " ";
        if (alias.text != "")
            fullName.text += "\"" + alias.text + "\" ";
        fullName.text += surname.text;

        persoManager.newChevalier.fullname = persoName.text + " " + surname.text;
        persoManager.newChevalier.alias = alias.text;
    }
}
