using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NoteManager : MonoBehaviour
{
    public TMP_InputField myInputField;
    public float lastSavetime;
    public GameManager currentGM;


    // Start is called before the first frame update
    void Start()
    {
        lastSavetime = 0f;
        currentGM = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - lastSavetime > 10f) 
        {
            lastSavetime = Time.time;
            currentGM.SaveNote(myInputField.text);
        }
    }

    public string GetText()
    { return myInputField.text; }   


    public void LoadNote(string newNote)
    {
        myInputField.text = newNote;
        gameObject.SetActive(false);
    }


}
