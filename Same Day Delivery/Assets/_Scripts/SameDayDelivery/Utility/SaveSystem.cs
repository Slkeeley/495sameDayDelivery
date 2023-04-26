using System;
using System.Collections.Generic;
using System.IO;
using SameDayDelivery.ScriptableObjects;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

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
            public UpgradeLookupTable upgradeLookupTable;
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

        private void Awake()
        {
            // return;
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
            saveData.upgradeLookupTable = _gameData.upgradeLookupTable;
            
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
            
            if (jsonData.Length <= 0) return;

            SaveData saveData = new SaveData();
            saveData = JsonUtility.FromJson<SaveData>(jsonData);

            _gameData.day = saveData.day;
            _gameData.money = saveData.money;
            _gameData.score = saveData.score;
            _gameData.upgradeLookupTable = saveData.upgradeLookupTable;
            
            _onLoad?.Invoke();
        }

        public void DeleteSavedData()
        {
            string path = GetStandardPath();

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

        private void OnGUI()
        {
            if (GUI.Button(new Rect(10, 10, 200, 100), "Save Game Data"))
            {
                SaveToFile();
            }
            if (GUI.Button(new Rect(10, 110, 200, 100), "Load Game Data"))
            {
                LoadFromFile();
            }
        }
    }
}