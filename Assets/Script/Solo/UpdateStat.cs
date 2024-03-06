using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class UpdateStat : MonoBehaviour
{
    public GameObject currentGO;
    public TextMeshProUGUI caracTextValue;
    public TextMeshProUGUI affTextValue;
    public int maxValue;
    public int currentValue;
    public TMP_InputField currentInputField;

    // Start is called before the first frame update
    void Start()
    {
        currentInputField = transform.Find("Panel/Text (TMP) (1)/InputField (TMP)").gameObject.GetComponent<TMP_InputField>();
        affTextValue = transform.Find("Panel/Text (TMP) (1)").gameObject.GetComponent<TextMeshProUGUI>();
        affTextValue =transform.Find("Panel/Text (TMP) (1)").gameObject.GetComponent<TextMeshProUGUI>();
        affTextValue = transform.parent.Find("Text (TMP)").gameObject.GetComponent<TextMeshProUGUI>();
        currentGO = transform.Find("Panel").gameObject;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void InitValue(int newMaxValue, int newCurrentValue)
    {
        maxValue = newMaxValue;
        currentValue = newCurrentValue;
        
        TextUpdate(currentValue);
    }

    public void UpdateText()
    {
        int intValue;

        // Use int.Parse() to convert the string to an integer
        if (int.TryParse(currentInputField.text, out intValue))
            TextUpdate(maxValue > currentValue + intValue ? currentValue + intValue > 0 ? currentValue + intValue : 0 : maxValue);;
    }

    void TextUpdate(int value)
    {
        caracTextValue.text = string.Format("{0} / {1}", value, maxValue);
    }

    public void  UpdateValue()
    {
        int intValue;
        // Use int.Parse() to convert the string to an integer
        if (int.TryParse(currentInputField.text, out intValue))
        {
            currentValue = maxValue > currentValue + intValue ? currentValue + intValue > 0 ? currentValue + intValue : 0 : maxValue;
            affTextValue.text = currentValue.ToString();
            currentInputField.text = "";
        }
        currentGO.SetActive(false);
    }

}
