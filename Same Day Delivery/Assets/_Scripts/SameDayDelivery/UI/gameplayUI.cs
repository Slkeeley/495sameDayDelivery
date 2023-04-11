using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace SameDayDelivery.UI
{
    public class gameplayUI : MonoBehaviour
    {
        public TMP_Text timerText; //how the timer is displayed
        public TMP_Text scoreText; //how the score is displayed
        public TMP_Text levelText; //how the current day is displayed
        public TMP_Text zergCoinsText; //how the current day is displayed
        public TMP_Text deliveryText;
        public TMP_Text packagesText; //display how many packages the player still needs to deliver
        private Color dtColor;
        public GameObject failNotification; //appears when the player fails
        public GameObject successNotification; //appears when the player passes
                                               // Start is called before the first frame update
        void Start()
        {
            uiSetup();
        }

        void uiSetup()
        {
            failNotification.SetActive(false); //make sure that the player cannot see the pass or fail notifications 
            successNotification.SetActive(false);
            dtColor = new Color(1f, 1f, 1f, 1f);
        }

        public void deliveryMessage(int deliveryType)//if a package was delivered this is called to show the delivery message 
        {
            switch (deliveryType)
            {
                case 1: //speedy delivery 
                    dtColor = new Color(0.04669785f, 1f, 1f, 1f);
                    deliveryText.color = dtColor;
                    deliveryText.text = "Speedy Delivery! +150";
                    StartCoroutine(displayDeliveryMessage());
                    break;
                case 2://slow delivery
                    dtColor = new Color(1f, 0f, 0.1349077f, 1f);
                    deliveryText.color = dtColor;
                    deliveryText.text = "Slow Delivery +75";
                    StartCoroutine(displayDeliveryMessage());
                    break;
                case 3://standard delivery
                    dtColor = new Color(0.6f, 0.6f, 0.6f, 1f);
                    deliveryText.color = dtColor;
                    deliveryText.text = "Standard Delivery! +100";
                    StartCoroutine(displayDeliveryMessage());
                    break;
            }
        }

        IEnumerator displayDeliveryMessage()
        {
            yield return new WaitForSeconds(2.0f);
            deliveryText.text = "";
        }
    }
}
