using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VanSounds : MonoBehaviour
{
    public AudioClip[] clips;
    private AudioSource source; 
    // Start is called before the first frame update
    void Awake()
    {
        source = GetComponent<AudioSource>();    
    }

      public void startMotor()// on entry play the car engine starting noise; 
    {
        source.PlayOneShot(clips[0]); 
    }

    public void drive()// on entry play the car engine starting noise; 
    {
        source.clip = clips[1];
        if (!source.isPlaying) source.Play(); 
    }

    public void reverse()//if the player is backing up play the reverse horn
    {
        //reverse nboise here
    }
}
