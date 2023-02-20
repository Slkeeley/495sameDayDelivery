using SameDayDelivery.Controls;
using UnityEngine;
using TMPro;

namespace SameDayDelivery.UI
{
    public class scoreDisplay : MonoBehaviour // this is used to display the players score, packages and 
    {
        public TMP_Text mostRecentScore;

        public TMP_Text packagesDelivered;

        // Start is called before the first frame update
        void Start()
        {
            mostRecentScore.text = "Your Score: " + GameWatcher.currentScore.ToString();
            packagesDelivered.text = "Packages Delivered: " + GameWatcher.packagesDelivered.ToString();
            //put zBucks here
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
