using System;
using System.Collections;
using SameDayDelivery.Controls;
using SameDayDelivery.ScriptableObjects;
using UnityEngine;

namespace SameDayDelivery.Utility
{
    public class GameDataSetup : MonoBehaviour
    {
        [SerializeField]
        private GameData _gameData;

        [SerializeField]
        private Transform _playerTransform;

        [SerializeField]
        private GameWatcher _gameWatcher;

        [SerializeField]
        private float _delay = 1f;

        private void Awake()
        {
            _gameData.ResetData();
        }

        private void OnEnable()
        {
            _gameData.OnGenericPackageDelivered += _gameWatcher.PackageReceived;
        }

        private void OnDisable()
        {
            _gameData.OnGenericPackageDelivered -= _gameWatcher.PackageReceived;
        }

        private void Start()
        {
            StartCoroutine(ShortDelay());
            
            
        }

        private IEnumerator ShortDelay()
        {
            yield return new WaitForSeconds(_delay);
            
            if (!_playerTransform)
            {
                var playerMovement = FindObjectOfType<PlayerMovement>();
                if (playerMovement)
                    _playerTransform = playerMovement.transform;
                else
                    Debug.LogError("Cannot find object with PlayerMovement on it.");
            }

            _gameData.playerTransform = _playerTransform;
            _gameData.NextDelivery();
        }
    }
}