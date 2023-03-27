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
        
        private void Awake()
        {
            _gameData.ResetData();
        }

        private void Start()
        {
            if (!_playerTransform)
            {
                var playerMovement = FindObjectOfType<PlayerMovement>();
                if (playerMovement)
                    _playerTransform = playerMovement.transform;
                else
                    Debug.LogError("Cannot find object with PlayerMovement on it.");
            }

            _gameData.playerTransform = _playerTransform;
            _gameData.ActivateNextDelivery();
        }
    }
}