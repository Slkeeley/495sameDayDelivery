using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheldonSounds : MonoBehaviour
{

    public AudioClip[] clips;
    private AudioSource source;
    // Update is called once per frame
    private void Awake()
    {
        source = GetComponent<AudioSource>(); 
    }

   public void pickupSound()
    {
        source.PlayOneShot(clips[0]); 
    }
}
