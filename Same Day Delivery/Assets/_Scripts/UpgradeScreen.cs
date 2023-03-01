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
    public Button[] upgradeButtons; 
    // Start is called before the first frame update
    private void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        coinsText.text = "Zerg Coins: " + zergCoins.ToString();
        if(highlightedButton!=null)
        {
            descText.text = highlightedButton.GetComponent<upgradeButton>().desc; 
        }
        else
        {
            descText.text = ""; 
        }
    }

    public void buyPremiumGas()
    {
      //  premiumGas.interactable = false;  
    }


}
