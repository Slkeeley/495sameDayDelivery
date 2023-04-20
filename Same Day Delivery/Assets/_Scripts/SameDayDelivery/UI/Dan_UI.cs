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

    public void workFaster()//dan yells at player after making a slow delivery
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

    public void oneMinute()//dan yells at player when there is less than a minute left. 
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

    public void pedestrianHit()//dan yells at the player every time they hit a pedestrian 
    {
        StartCoroutine(pedestrianHitCR());
    }

    IEnumerator pedestrianHitCR()
    {
        danAudioSource.clip = danVoiceLines[3];
        danAudioSource.PlayOneShot(danAudioSource.clip, 1.0f);
        face.SetActive(true);
        messageText.text = "SHEEELLDON!";
        yield return new WaitForSeconds(danDelay);
        face.SetActive(false);
        messageText.text = "";
        messageText.fontSize = 36;
    }

    public void propHit()
    {
        StartCoroutine(propHitCR());
    }

    IEnumerator propHitCR()
    {
        danAudioSource.clip = danVoiceLines[4];
        danAudioSource.PlayOneShot(danAudioSource.clip, 1.0f);
        face.SetActive(true);
        messageText.fontSize = 24;
        messageText.text = "Hey! That's coming out of your paycheck!";
        yield return new WaitForSeconds(danDelay);
        face.SetActive(false);
        messageText.text = "";
        messageText.fontSize = 36;
    }
}
