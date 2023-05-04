using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class VanSounds : MonoBehaviour
{
    public AudioClip[] vanClips;
    public AudioClip[] sheldonClips;
    private AudioSource source;
    // Start is called before the first frame update
    void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    public void startMotor()// on entry play the car engine starting noise; 
    {
        source.PlayOneShot(vanClips[0]);
    }

    public void drive()// on entry play the car engine starting noise; 
    {
        source.clip = vanClips[1];
        if (!source.isPlaying) source.Play();
    }

    public void reverse()//if the player is backing up play the reverse horn
    {
        source.clip = vanClips[2];
        if (!source.isPlaying) source.Play();
    }

    public void sheldonNoise()
    {
        int chosenVoiceLine = Random.Range(0, sheldonClips.Length);

        source.clip = sheldonClips[chosenVoiceLine];
        if (!source.isPlaying) source.Play();
    }
}
