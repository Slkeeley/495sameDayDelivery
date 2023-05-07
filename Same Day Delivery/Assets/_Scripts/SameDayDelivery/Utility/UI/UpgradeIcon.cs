using SameDayDelivery.ScriptableObjects;
using UnityEngine;
using UnityEngine.UI;

namespace SameDayDelivery.UI
{
    public class UpgradeIcon : MonoBehaviour
    {
        public Image backgroundImage;
        public Image foregroundImage;
        public Color activateColor = Color.white;
        public Color inactiveColor = new Color(1f, 1f, 1f, 0.25f);
        public UpgradeItem upgradeItem;

        public void UpdateUI()
        {
            var bgColor = backgroundImage.color;
            var fgColor = foregroundImage.color;
            
            // bgColor = upgradeItem.purchased ? activateColor : inactiveColor;
            fgColor = upgradeItem.purchased ? activateColor : inactiveColor;
            
            backgroundImage.color = bgColor;
            foregroundImage.color = fgColor;

            foregroundImage.sprite = upgradeItem.icon;
        }
    }
}