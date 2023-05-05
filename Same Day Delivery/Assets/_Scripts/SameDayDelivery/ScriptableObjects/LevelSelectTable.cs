using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SameDayDelivery.ScriptableObjects
{
    [CreateAssetMenu(fileName = "LevelSelectTable", menuName = "Game/LevelSelectTable", order = 51)]
    public class LevelSelectTable : ScriptableObject
    {
        public List<LevelData> levels = new List<LevelData>();
    }
}
