using SameDayDelivery.Controls;
using UnityEngine;
using TMPro;

namespace SameDayDelivery.UI
{
    public class scoreDisplay : MonoBehaviour // this is used to display the players score, packages and 
    {
        public TMP_Text mostRecentScore;

        public TMP_Text packagesDelivered;
        public TMP_Text coinsEarned;

        // Start is called before the first frame update
        void Start()
        {
            mostRecentScore.text = "Your Score: " + GameWatcher.scoreEarned.ToString();
            packagesDelivered.text = "Packages Delivered: " + GameWatcher.successFullDeliveries.ToString();

            
           
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
