﻿using System;
using System.Collections.Generic;
using System.IO;
using SameDayDelivery.ScriptableObjects;
using UnityEngine;
using UnityEngine.Events;

namespace SameDayDelivery.Utility
{
    public class SaveSystem : MonoBehaviour
    {
        [Serializable]
        private class SaveData
        {
            public int day;
            public int money;
            public int score;
            public List<int> unlockedUpgrades = new List<int>();
            public List<int> unlockedLevels = new List<int>(); 
        }
        
        [SerializeField]
        private GameData _gameData;

        [SerializeField]
        private string _filename = "ZaveFile";

        [SerializeField]
        private bool _loadSavedDataOnAwake;

        [SerializeField]
        private UnityEvent _onLoad;
        [SerializeField]
        private UnityEvent _onSave;
        [SerializeField]
        private UnityEvent _onDelete;
        [SerializeField]
        private UnityEvent _onLoadFailure;

        private void Awake()
        {
            return;
            if (_loadSavedDataOnAwake)
                LoadFromFile();
        }

        public void SaveToFile()
        {
            string path = GetStandardPath();

            SaveData saveData = new SaveData();
            saveData.day = _gameData.day;
            saveData.money = _gameData.money;
            saveData.score = _gameData.score;
            List<UpgradeItem> upgrades = _gameData.upgradeLookupTable.upgrades;
            List<LevelData> lvls = _gameData.lvlSelectTable.levels;
            for (int i = 0; i < upgrades.Count; i++)
            {
                saveData.unlockedUpgrades.Add(upgrades[i].purchased ? 1 : 0);
            }

            for (int i = 0; i < lvls.Count; i++)
            {
                saveData.unlockedLevels.Add(lvls[i].unlocked ? 1 : 0);
            }
            string jsonData = JsonUtility.ToJson(saveData);
            
            Debug.Log($"{jsonData}");
            
            using StreamWriter writer = new StreamWriter(path);
            writer.Write(jsonData);
            
            _onSave?.Invoke();
        }

        public void LoadFromFile()
        {
            string path = GetStandardPath();

            if (!File.Exists(path)) return;
            using StreamReader reader = new StreamReader(path);
            string jsonData = reader.ReadToEnd();
            
            if (jsonData.Length <= 0)
            {
                _onLoadFailure?.Invoke();
                return;
            }

            SaveData saveData = new SaveData();
            saveData = JsonUtility.FromJson<SaveData>(jsonData);

            _gameData.day = saveData.day;
            _gameData.money = saveData.money;
            _gameData.score = saveData.score;

            List<int> upgrades = saveData.unlockedUpgrades;
            List<int> levels = saveData.unlockedLevels; 

            for (int i = 0; i < upgrades.Count; i++)
            {
                _gameData.upgradeLookupTable.upgrades[i].purchased = upgrades[i] == 1;
            }

            for (int i = 0; i < levels.Count; i++)
            {
                _gameData.lvlSelectTable.levels[i].unlocked = levels[i] == 1;
            }

            _onLoad?.Invoke();
        }

        public void DeleteSavedData()
        {
            string path = GetStandardPath();
            
            _gameData.DeleteTempData();

            if (!File.Exists(path)) return;
            using StreamWriter writer = new StreamWriter(path);
            writer.Write(""); // clear data
            _gameData.ResetData();
            
            _onDelete?.Invoke();
        }

        private string GetStandardPath()
        {
            return $"{Application.persistentDataPath}/{_filename}";
        }
#if UNITY_EDITOR
        private void OnGUI()
        {
            // Debug only, not meant for build
            // if (GUI.Button(new Rect(10, 10, 200, 100), "Save Game Data"))
            // {
            //     SaveToFile();
            // }
            // if (GUI.Button(new Rect(10, 110, 200, 100), "Load Game Data"))
            // {
            //     LoadFromFile();
            // }
        }
#endif
    }
}