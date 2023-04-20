using System;
using System.Linq;
using SameDayDelivery.ScriptableObjects;
using TMPro;
using UnityEngine;

namespace SameDayDelivery.UI
{
    public class SaveUIManager : MonoBehaviour
    {
        public GameData gameData;
        [Header("TextMeshPro Objects")]
        public TMP_Text daysText;
        public TMP_Text coinsText;
        public TMP_Text scoreText;
        public TMP_Text upgradesText;

        private void Start()
        {
            UpdateUI();
        }

        public void UpdateUI()
        {
            daysText.text = $"{gameData.day}";
            coinsText.text = $"{gameData.money}";
            scoreText.text = $"{gameData.score}";
            int numOfUpgrades = gameData.upgradeLookupTable.upgrades.Count(upgradeItem => upgradeItem.purchased);
            upgradesText.text = $"{numOfUpgrades}";
        }
    }
}