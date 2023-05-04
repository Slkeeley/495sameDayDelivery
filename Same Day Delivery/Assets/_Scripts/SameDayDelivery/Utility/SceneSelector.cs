using UnityEngine;
using UnityEngine.SceneManagement;

namespace SameDayDelivery.Utility
{
    public class SceneSelector : MonoBehaviour
    {



        public void toUpgradeScreen()//go to the upgrades screen
        {
            Debug.Log("clicked");
            SceneManager.LoadScene("UpgradeScreen");
        }

        public void backToMenu()//return to the main menu
        {
            SceneManager.LoadScene("MainMenu");
        }

        public void loadLevelSelect()//load the level 
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            SceneManager.LoadScene("Stage00");
        }

        public void toFailScreen()//go to the fail screen 
        {
 
            SceneManager.LoadScene("FailScreen");
        }

        public void toPassScreen()//go to the pass screen;
        {
            SceneManager.LoadScene("PassScreen");
        }

        public void toLevelSelect()
        {
            SceneManager.LoadScene("LevelSelect");
        }
        
        public void loadSelectedLevel(int indexNumber)
        {
            SceneManager.LoadScene(indexNumber); //select the level to load in the editor so we only need to use 1 function 
        }

        public void toNewGame()
        {
            SceneManager.LoadScene("NewGameScreen"); 
        }
    }
}
