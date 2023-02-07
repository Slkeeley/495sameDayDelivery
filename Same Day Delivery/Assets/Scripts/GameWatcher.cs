using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameWatcher : MonoBehaviour
{
    public float TimeLeft;
    public bool TimerOn = false;//bool to make sure timer does not go below 0

    [Header("UI Elements")]
    public TMP_Text timerText; //how the timer is displayed
    public GameObject failNotif;//appears when the player failes
    bool levelFailed; //used to tell if player failed a level 

    // Start is called before the first frame update
    void Start()
    {
        TimerOn = true;
        failNotif.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(TimeLeft>0)//if the player still has time decrease the remaining time then update the UI 
        {
            TimerOn = true; 
            TimeLeft -= Time.deltaTime;
            updaterTimer(TimeLeft);
        }
        else
        {
            TimeLeft = 0;
            TimerOn = false;
            levelFailed = true;
            failNotif.SetActive(true);
            StartCoroutine(ggGoNext());
        }
    }

    void updaterTimer(float currentTime)//used to update the timer text on screen to accurately reflect how much time is left 
    {
        currentTime += 1;
        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);

        timerText.text = string.Format("{0:00} : {1:00}", minutes, seconds);
    }

    IEnumerator ggGoNext()//Coroutine to delay loading the next so that the player can process that they failed/
    {
        yield return new WaitForSeconds(2.0f);
        StopAllCoroutines(); //stop coroutines so that the faile screen isnt loaded multiple times. 
        SceneManager.LoadScene("TestFailScreen");
    }
}
