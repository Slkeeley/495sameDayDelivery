using UnityEngine;
using UnityEngine.SceneManagement;

namespace SameDayDelivery.Utility
{
    public class SceneSelector : MonoBehaviour
    {



        public void toUpgradeScreen()
        {
            Debug.Log("clicked");
            SceneManager.LoadScene("UpgradeScreen");
        }

        public void backToMenu()
        {
            SceneManager.LoadScene("MainMenu");
        }

        public void loadCity()
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            SceneManager.LoadScene("TestCity");
        }
    }
}
