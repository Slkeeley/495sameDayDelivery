using System;
using System.Collections;
using SameDayDelivery.Controls;
using SameDayDelivery.ScriptableObjects;
using UnityEngine;

namespace SameDayDelivery.Utility
{
    public class GameDataSetup : MonoBehaviour
    {
        public enum LevelType
        {
            Level,
            MainMenu
        }
        
        [SerializeField]
        private GameData _gameData;

        [SerializeField]
        private LevelType _levelType = LevelType.Level;

        private void OnEnable()
        {
            switch (_levelType)
            {
                case LevelType.Level:
                    _gameData.TempLoadData();
                    break;
                case LevelType.MainMenu:
                    _gameData.ResetData();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void OnDisable()
        {
            switch (_levelType)
            {
                case LevelType.Level:
                    _gameData.TempSaveData();
                    break;
                case LevelType.MainMenu:
                    _gameData.ResetData();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}