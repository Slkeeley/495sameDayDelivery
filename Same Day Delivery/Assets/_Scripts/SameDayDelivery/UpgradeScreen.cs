using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; 

public class UpgradeScreen : MonoBehaviour
{
    [SerializeField] private SameDayDelivery.ScriptableObjects.GameData data; 
    [Header("Text")]
    public TMP_Text coinsText;
    public TMP_Text descText;

    [Header("Buttons")]
    public Button highlightedButton; 
    public Button selectedButton; 
    public Button[] upgradeButtons;
    public GameObject buyButton;
    private bool upgradeSelected = false;
    private bool sheldonIsBroke = false;

    //static
    public static int totalZergCoins;
    // Start is called before the first frame update
    private void Start()
    {
        buyButton.SetActive(false);
        totalZergCoins = 100; 
    }

    // Update is called once per frame
    void Update()
    {
        coinsText.text = "Zerg Coins: " + data.money.ToString();
    


        checkHighlightedButton();
        checkSelectedButton();
        if (sheldonIsBroke)//if sheldon does not have the required amount of money then have the text say not enough zerg
        {
            descText.fontSize = 14;
            descText.text = "NOT ENOUGH ZERG!";
            descText.color = new Color(1, 0, 0, 1);
        }
    }

    void checkHighlightedButton()//if there is a highlighted button put its description in the text box 
    {
        if (!upgradeSelected)//first check if a button was clicked prior, a selected button takes priority over the highlighted one
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
        if (selectedButton!= null)//if the selected button is not null, have it glow, show the buy button and fill 
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
        }
    }

    public void deselectButton()
    {
        selectedButton.GetComponent<upgradeButton>().glow.SetActive(false);
        selectedButton = null;
    }

    public void buyUpgrade()
    {
        upgradeButton upgradeButton = selectedButton.GetComponent<upgradeButton>();
        
        if (upgradeButton.price <= data.money)//if the player has enough zerg coins
        {
            upgradeSelected = false;
            upgradeButton.glow.SetActive(false);
            upgradeButton.upgrade.purchased = true; 
            descText.text = "";
            data.money -= upgradeButton.price;
            selectedButton = null;

        }
        else StartCoroutine(cannotAfford());
    }

    IEnumerator cannotAfford()
    {
        sheldonIsBroke = true;
        yield return new WaitForSeconds(2.0f);
        sheldonIsBroke = false;
        descText.text = "";
        descText.color = new Color(0, 0, 0, 1);
        descText.fontSize = 8; 
    }
}
