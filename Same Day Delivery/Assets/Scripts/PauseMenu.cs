using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{

    //  private float fixedDeltaTime;
    public GameObject pauseMenu;
    // Start is called before the first frame update
    void Start()
    {
        //       fixedDeltaTime = Time.fixedDeltaTime;
        pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Time scale is :" + Time.timeScale);
     if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale == 1.0f)
            {
                pauseGame(); 
            }
            else
            {
                resumeGame();  
            }
        }
    }

    void pauseGame()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true; 
        pauseMenu.SetActive(true);
        Time.timeScale = 0.0f; 
    }

   public void resumeGame()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false; 
        pauseMenu.SetActive(false);
        Time.timeScale = 1.0f; 
    }


}
