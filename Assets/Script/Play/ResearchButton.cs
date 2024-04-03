using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class ResearchButton : MonoBehaviour
{
    public TMP_InputField myInputField;
    public TwitchChatClient twitchChatClient;

    private void Start()
    {
                
    }

    public void LaunchMessage()
    {
        string myKey = myInputField.text;
        twitchChatClient.SendMessage(myKey);
    }

}