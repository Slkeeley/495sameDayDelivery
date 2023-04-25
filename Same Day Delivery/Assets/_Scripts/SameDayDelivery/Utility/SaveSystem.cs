using System.IO;
using SameDayDelivery.ScriptableObjects;
using UnityEngine;

namespace SameDayDelivery.Utility
{
    public class SaveSystem : MonoBehaviour
    {
        [SerializeField]
        private GameData _gameData;

        [SerializeField]
        private string _filename = "DontReadThisSaveFile";
        
        public void SaveToFile()
        {
            string path = Application.persistentDataPath + "/" + _filename;
            string jsonData = JsonUtility.ToJson(_gameData);

            using StreamWriter writer = new StreamWriter(path);
            writer.Write(jsonData);
        }

        public void LoadFromFile()
        {
            string path = Application.persistentDataPath + "/" + _filename;

            if (!File.Exists(path)) return;
            using StreamReader reader = new StreamReader(path);
            string jsonData = reader.ReadToEnd();
            _gameData = JsonUtility.FromJson<GameData>(jsonData);
        }
    }
}