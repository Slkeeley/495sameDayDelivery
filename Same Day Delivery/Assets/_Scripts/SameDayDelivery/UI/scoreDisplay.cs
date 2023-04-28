using SameDayDelivery.Controls;
using UnityEngine;
using TMPro;

namespace SameDayDelivery.UI
{
    public class scoreDisplay : MonoBehaviour // this is used to display the players score, packages and 
    {
        public TMP_Text mostRecentScore;
        public TMP_Text coinsEarned;
        public static int coinsGained;
        private AudioSource source;

        private void Awake()
        {
            source = GetComponent<AudioSource>(); 
        }
        // Start is called before the first frame update
        void Start()
        {
            source.Play(); 
            mostRecentScore.text = "Your <color=#A2A2A2>Z</color>core: " + GameWatcher.scoreEarned.ToString();
            coinsEarned.text = "Zerg Coin<color=#A2A2A2>z</color> Earned: " + coinsGained.ToString();

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

    }
}
