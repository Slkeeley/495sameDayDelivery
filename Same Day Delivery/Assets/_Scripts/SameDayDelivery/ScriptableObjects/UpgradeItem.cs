using System.Web;
using UnityEngine;

namespace SameDayDelivery.ScriptableObjects
{
    [System.Serializable]
    public class UpgradeValue
    {
        public string uName = "";
        public float uValue;
    }
    
    [CreateAssetMenu(fileName = "UpgradeItem", menuName = "Game/UpgradeItem", order = 51)]
    public class UpgradeItem : ScriptableObject
    {
        public string upgradeName = "zUnknown zUpgrade";
        [TextArea]
        public string description = "zotally zawesome zupgrade!";
        public int cost;
        public Sprite icon;
        public bool purchased;
        [Header("Value")]
        public UpgradeValue valueA;
        public UpgradeValue valueB;
    }
}