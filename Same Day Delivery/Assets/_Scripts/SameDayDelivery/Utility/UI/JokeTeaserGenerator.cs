using SameDayDelivery.ScriptableObjects;
using TMPro;
using UnityEngine;

namespace SameDayDelivery.UI
{
    public class JokeTeaserGenerator : MonoBehaviour
    {
        [SerializeField]
        private JokeData _jokeData;
        [SerializeField]
        private TMP_Text _targetText;

        private void OnEnable()
        {
            if (!_targetText)
                _targetText = GetComponent<TMP_Text>();
            
            _targetText.text = _jokeData.GetRandomPauseTeaser();
        }
    }
}