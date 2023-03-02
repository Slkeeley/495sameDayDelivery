﻿using SameDayDelivery.PackageSystem;
using UnityEngine;

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

        public delegate void UpgradeEvent(UpgradeItem upgradeItem);

        public UpgradeEvent OnUpgradePurchase;

        public delegate void PackageEvent(Package package, GameObject affectedObject);

        public PackageEvent OnPackagePickup;
        public PackageEvent OnPackageThrow;
        public PackageEvent OnPackageDelivered;
        public PackageEvent OnPackageCollide;
        public PackageEvent OnPackageTrigger;
        
        #endregion
        
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
        
        [Header("Upgrades")]
        public UpgradeLookupTable upgradeLookupTable;

        public void ResetData()
        {
            score = 0;
            money = 0;

            foreach (var upgradeItem in upgradeLookupTable.upgrades)
            {
                upgradeItem.purchased = false;
            }
        }
    }
}