using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; 


public class upgradeButton : MonoBehaviour
{
    public string upgradeName;
    private TMP_Text upgradeNameText;

    private Button button; 

    private void Awake()
    {
        upgradeNameText = GetComponentInChildren<TextMeshProUGUI>();
        upgradeNameText.text = upgradeName;

        button = GetComponent<Button>(); 
    }

    public void clicked()
    {
        Debug.Log("Clicked");
        button.interactable = false; 
    }
}
