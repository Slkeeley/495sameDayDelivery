using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; 


public class upgradeButton : MonoBehaviour
{
   [Header("Upgrade Name")]
    public string upgradeName;
    public TMP_Text upgradeNameText;
  
    [Header("Price")]
    public int price;
    public TMP_Text priceText;

    public string desc; 
    private Button button;
    private GameObject upgradeScreen; 

    private void Awake()
    {
        upgradeNameText.text = upgradeName;
        priceText.text = price.ToString();
        button = GetComponent<Button>();
        upgradeScreen = GameObject.Find("UpgradeCanvas"); 
    }

    public void clicked()//display if the  button was clicked
    {
        Debug.Log("Clicked");
        button.interactable = false; 
    }

    public void onHighlight()
    {
        upgradeScreen.GetComponent<UpgradeScreen>().highlightedButton = button; 
    }

    public void offHighlight()
    {
        upgradeScreen.GetComponent<UpgradeScreen>().highlightedButton = null; 
    }
}
