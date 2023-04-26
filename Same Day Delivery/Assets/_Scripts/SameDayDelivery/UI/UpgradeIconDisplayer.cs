using System;
using System.Collections.Generic;
using SameDayDelivery.ScriptableObjects;
using UnityEngine;

namespace SameDayDelivery.UI
{
    public class UpgradeIconDisplayer : MonoBehaviour
    {
        public UpgradeLookupTable upgradeLookupTable;
        public Transform upgradeIconsParent;
        public GameObject upgradeIconPrefab;
        public Color activateColor = Color.white;
        public Color inactiveColor = new Color(1f, 1f, 1f, 0.25f);

        public void UpdateUpgradeIcons()
        {
            foreach (Transform child in upgradeIconsParent)
            {
                Destroy(child.gameObject);
            }
            
            foreach (UpgradeItem upgradeItem in upgradeLookupTable.upgrades)
            {
                GameObject go = Instantiate(upgradeIconPrefab, upgradeIconsParent);
                UpgradeIcon icon = go.GetComponent<UpgradeIcon>();
                icon.upgradeItem = upgradeItem;
                icon.activateColor = activateColor;
                icon.inactiveColor = inactiveColor;
                icon.UpdateUI();
            }
        }
    }
}