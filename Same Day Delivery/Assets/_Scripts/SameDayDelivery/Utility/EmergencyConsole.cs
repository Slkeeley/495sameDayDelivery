﻿using System;
using System.Collections;
using SameDayDelivery.ScriptableObjects;
using TMPro;
using UnityEngine;

namespace SameDayDelivery.Utility
{
    public class EmergencyConsole : MonoBehaviour
    {
        public GameData gameData;
        public TMP_Text consoleText;

        private void Start()
        {
            StartCoroutine(ShortDelay());
        }

        private IEnumerator ShortDelay()
        {
            yield return new WaitForSeconds(5f);

            string msg = "";

            msg += $"gameData:";
            msg += $"activeDelivery = {(gameData.activeDelivery ? gameData.activeDelivery.gameObject.name : "null")}\n";
            msg += $"availableDeliveriesList.Count = {gameData.availableDeliveriesList.Count.ToString()}\n";
            msg += $"deliveredLocationsList.Count = {gameData.deliveredLocationsList.Count.ToString()}\n";
            
            consoleText.text = msg;
        }
    }
}