using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

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
