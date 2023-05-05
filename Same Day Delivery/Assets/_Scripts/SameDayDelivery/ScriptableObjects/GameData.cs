using System.Collections.Generic;
using SameDayDelivery.Controls;
using SameDayDelivery.PackageSystem;
using SameDayDelivery.Utility;
using UnityEngine;
using UnityEngine.Serialization;

// ReSharper disable once CheckNamespace
namespace SameDayDelivery.ScriptableObjects
{
    [CreateAssetMenu(fileName = "GameData", menuName = "Game/GameData", order = 51)]
    public class GameData : ScriptableObject
    {
        /**
         * Scripts can subscribe to these events or invoke them.So long as a script has a reference to the same GameData
         *   object, they will be communicating across the same network of events. 
         */
        #region Game Events
        public delegate void GameEvent();

        public GameEvent OnScore;
        public GameEvent OnMoneyGain;
        public GameEvent OnMoneyLoss;
        public GameEvent OnGenericPackageDelivered;

        public delegate void UpgradeEvent(UpgradeItem upgradeItem);

        public UpgradeEvent OnUpgradePurchase;

        public delegate void PackageEvent(Package package, GameObject affectedObject);

        public PackageEvent OnPackagePickup;
        public PackageEvent OnPackageThrow;
        public PackageEvent OnPackageDelivered;
        public PackageEvent OnPackageCollide;
        public PackageEvent OnPackageTrigger;
        
        #endregion

        [Header("Meta")]
        public ScoreData scoreData;
        public GameWatcher gameWatcher;
        [Header("Resources")]
        [Tooltip("Current score.")]
        public int score;
        [Tooltip("Current amount of money.")]
        public int money;
        [Tooltip("Current day the player is on.")]
        public int day;
        [Header("Packages")]
        [Tooltip("How many packages have been delivered.")]
        public int delivered;
        [Tooltip("How many packages have not been delivered.")]
        public int undelivered;
        [Tooltip("Indicate to other objects which package Sheldon is carrying")]
        public Package carryingPackage;
        
        [Header("Upgrades")]
        public UpgradeLookupTable upgradeLookupTable;

        public Transform playerTransform;

        public void ResetData()
        {
            day = 0;
            score = 0;
            money = 0;

            foreach (UpgradeItem upgradeItem in upgradeLookupTable.upgrades)
            {
                upgradeItem.purchased = false;
            }
        }

        public void TempSaveData()
        {
            PlayerPrefs.SetInt("day", day);
            PlayerPrefs.SetInt("score", score);
            PlayerPrefs.SetInt("money", money);

            for (int i = 0; i < upgradeLookupTable.upgrades.Count; i++)
            {
                UpgradeItem upgradeItem = upgradeLookupTable.upgrades[i];
                PlayerPrefs.SetInt($"upgrade[{i}]", upgradeItem.purchased ? 1 : 0);
            }
            
            PlayerPrefs.Save();
        }

        public void TempLoadData()
        {
            day = PlayerPrefs.GetInt("day");
            score = PlayerPrefs.GetInt("score");
            money = PlayerPrefs.GetInt("money");
            
            if (!upgradeLookupTable) return;
            
            for (int i = 0; i < upgradeLookupTable.upgrades.Count; i++)
            {
                UpgradeItem upgradeItem = upgradeLookupTable.upgrades[i];
                upgradeItem.purchased = PlayerPrefs.GetInt($"upgrade[{i}]") == 1;
            }
        }

        public void DeleteTempData()
        {
            PlayerPrefs.DeleteKey("day");
            PlayerPrefs.DeleteKey("score");
            PlayerPrefs.DeleteKey("money");
            
            if (!upgradeLookupTable) return;

            List<UpgradeItem> upgrades = upgradeLookupTable.upgrades;
            
            for (int i = 0; i < upgrades.Count; i++)
            {
                PlayerPrefs.DeleteKey($"upgrade[{i}]");
            }
        }
    }
}