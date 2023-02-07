using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameWatcher : MonoBehaviour
{
    public float TimeLeft;
    public bool TimerOn = false;
    public TMP_Text timerText; 
    public GameObject failNotif;
    public bool levelFailed; 
    // Start is called before the first frame update
    void Start()
    {
        TimerOn = true;
        failNotif.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(TimeLeft>0)
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

    void updaterTimer(float currentTime)
    {
        currentTime += 1;
        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);

        timerText.text = string.Format("{0:00} : {1:00}", minutes, seconds);
    }

    IEnumerator ggGoNext()
    {
        yield return new WaitForSeconds(2.0f);
        StopAllCoroutines(); 
        SceneManager.LoadScene("TestFailScreen");
    }
}
