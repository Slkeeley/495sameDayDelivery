using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; 

public class UpgradeScreen : MonoBehaviour
{
    public static int zergCoins;
    public TMP_Text coinsText;
    public TMP_Text descText;

    [Header("Buttons")]
    public Button highlightedButton; 
    public Button selectedButton; 
    public Button[] upgradeButtons;
    public GameObject buyButton;
    private bool upgradeSelected = false; 
    // Start is called before the first frame update
    private void Start()
    {
        buyButton.SetActive(false); 
    }

    // Update is called once per frame
    void Update()
    {
        coinsText.text = "Zerg Coins: " + zergCoins.ToString();

        checkHighlightedButton(); 
      
    }

    void checkHighlightedButton()
    {
        if (!upgradeSelected)
        {
            if (highlightedButton != null)
            {
                descText.text = highlightedButton.GetComponent<upgradeButton>().desc;
            }
            else
            {
                descText.text = "";
            }
        }
    }

    void checkSelectedButton()
    {
        if (selectedButton!= null)
        {
            buyButton.SetActive(true);
            upgradeSelected = true; 
            descText.text = selectedButton.GetComponent<upgradeButton>().desc;
            selectedButton.GetComponent<upgradeButton>().glow.SetActive(true); 

        }
        else
        {
            buyButton.SetActive(false);
            upgradeSelected = false;
            descText.text = ""; 
        }
    }

    public void buyUpgrade()
    {
        Debug.Log("Pretended to Buy Upgrade");
        selectedButton = null;
        selectedButton.GetComponent<upgradeButton>().glow.SetActive(false);
    }

}
