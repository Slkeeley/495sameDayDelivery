using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Dan_UI : MonoBehaviour
{
    public GameObject face;
    public TMP_Text messageText;
    public float danDelay;//how long until dan dissappears into the void again?
    [SerializeField] private AudioSource danAudioSource;
    [SerializeField] private AudioClip[] danVoiceLines; 

    private void Awake()
    {
        face.SetActive(false);
        messageText.text = "";
        danAudioSource = GetComponent<AudioSource>(); 
    }

    public void onStart()//dan yells at player on Start
    {
        StartCoroutine(onStartCR()); 
    }
    IEnumerator onStartCR()
    {
        danAudioSource.clip = danVoiceLines[0];
        danAudioSource.PlayOneShot(danAudioSource.clip, 1.0f); 
        face.SetActive(true); 
        messageText.text = "Get To Work!";
        yield return new WaitForSeconds(danDelay);
        face.SetActive(false);
        messageText.text = "";
    }

    public void workFaster()
    {
        StartCoroutine(workFasterCR()); 
    }

    IEnumerator workFasterCR()
    {

        danAudioSource.clip = danVoiceLines[1];
        danAudioSource.PlayOneShot(danAudioSource.clip, 1.0f);
        face.SetActive(true);
        messageText.text = "Work Faster!";
        yield return new WaitForSeconds(danDelay);
        face.SetActive(false);
        messageText.text = ""; 
    }

    public void oneMinute()
    {
        StartCoroutine(oneMinuteCR()); 
    }

    IEnumerator oneMinuteCR()
    {
        danAudioSource.clip = danVoiceLines[2];
        danAudioSource.PlayOneShot(danAudioSource.clip, 1.0f);
        face.SetActive(true);
        messageText.fontSize = 24; 
        messageText.text = "Hurry up! You're running out of time!";
        yield return new WaitForSeconds(danDelay);
        face.SetActive(false);
        messageText.text = "";
        messageText.fontSize = 36;
    }
}
