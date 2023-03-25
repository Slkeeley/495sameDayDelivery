using System.Collections.Generic;
using UnityEngine;

namespace SameDayDelivery.ScriptableObjects
{
    [CreateAssetMenu(fileName = "JokeData", menuName = "Game/JokeData", order = 51)]
    public class JokeData : ScriptableObject
    {
        public List<string> pauseMenuTeasers = new List<string>();

        public string GetRandomPauseTeaser() => pauseMenuTeasers.Count <= 0 ? 
            "" : pauseMenuTeasers[Random.Range(0, pauseMenuTeasers.Count)];
    }
}