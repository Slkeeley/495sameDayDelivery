using System;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{

    //  private float fixedDeltaTime;
    public GameObject pauseMenu;

    private const float Tolerance = 0.01f;

    // Start is called before the first frame update
    void Start()
    {
        // fixedDeltaTime = Time.fixedDeltaTime;
        pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Math.Abs(Time.timeScale - 1.0f) < Tolerance)
            {
                PauseGame(); 
            }
            else
            {
                ResumeGame();  
            }
        }
    }

    public void PauseGame()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true; 
        pauseMenu.SetActive(true);
        Time.timeScale = 0.0f; 
    }

   public void ResumeGame()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false; 
        pauseMenu.SetActive(false);
        Time.timeScale = 1.0f; 
    }
}
