using System.Collections.Generic;
using UnityEngine;

namespace SameDayDelivery.ScriptableObjects
{
    [CreateAssetMenu(fileName = "UpgradeLookupTable", menuName = "Game/UpgradeLookupTable", order = 51)]
    public class UpgradeLookupTable : ScriptableObject
    {
        public List<UpgradeItem> upgrades = new List<UpgradeItem>();
    }
}