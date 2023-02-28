using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; 

public class UpgradeScreen : MonoBehaviour
{
    public static int zergCoins;
    public TMP_Text coinsText;

    [Header("Buttons")]
    public Button premiumGas;
    // Start is called before the first frame update
    private void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        coinsText.text = "Zerg Coins: " + zergCoins.ToString();
    }

    public void buyPremiumGas()
    {
        premiumGas.interactable = false;  
    }
}
