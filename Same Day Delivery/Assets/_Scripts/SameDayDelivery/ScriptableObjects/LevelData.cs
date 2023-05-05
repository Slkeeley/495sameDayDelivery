using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace SameDayDelivery.ScriptableObjects
{
    [System.Serializable]
    [CreateAssetMenu(fileName = "LevelData", menuName = "Game/LevelData", order = 51)]
    public class LevelData : ScriptableObject
    {
        public string levelName;
        public int levelNumber;
        public Sprite screenshot;
        public bool unlocked; 
    }
}
