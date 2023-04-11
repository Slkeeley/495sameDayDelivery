using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; 


public class upgradeButton : MonoBehaviour
{
    [Header("Upgrade Data")]
    public SameDayDelivery.ScriptableObjects.UpgradeItem upgrade;
    [SerializeField] private string upgradeName;
    [SerializeField] private TMP_Text upgradeNameText;
    [SerializeField] private TMP_Text priceText;
    [SerializeField] private Image image;
    [SerializeField] public string desc;
    public int price;
    
    
    [Header ("References")]
    private Button button;
    private GameObject upgradeScreen;
    public GameObject glow;

    private void Awake()
    {
        //Attach scriptable object values to this upgrade button to reflect what it does
        upgradeName = upgrade.upgradeName;
        image.sprite = upgrade.icon;
        desc = upgrade.description;
        price = upgrade.cost; 
        //Create the UI based off of the values for each upgrade
        upgradeNameText.text = upgradeName;
        priceText.text = price.ToString();
        button = GetComponent<Button>();
        upgradeScreen = GameObject.Find("UpgradeCanvas");
        glow.SetActive(false); 
    }

    public void Update()
    {
        if (upgrade.purchased) button.interactable = false; 
    }

    public void clicked()//if the button was clicked highlight the button; 
    {
        if (upgradeScreen.GetComponent<UpgradeScreen>().selectedButton != null)//if there was already a button selected deselect it and then select this button; 
        {
            upgradeScreen.GetComponent<UpgradeScreen>().deselectButton(); 
            upgradeScreen.GetComponent<UpgradeScreen>().selectedButton = button;
            upgradeScreen.GetComponent<UpgradeScreen>().highlightedButton = button;
        }
        else
        {
            upgradeScreen.GetComponent<UpgradeScreen>().selectedButton = button;
            upgradeScreen.GetComponent<UpgradeScreen>().highlightedButton = button;
        }
    }

    public void onHighlight()//if the button is being hovered over tell the upgrade screen to use this button
    {
        upgradeScreen.GetComponent<UpgradeScreen>().highlightedButton = button; 
    }

    public void offHighlight()//if the cursor is removed, the screen no longer has a highlighted 
    {
        upgradeScreen.GetComponent<UpgradeScreen>().highlightedButton = null; 
    }
}
