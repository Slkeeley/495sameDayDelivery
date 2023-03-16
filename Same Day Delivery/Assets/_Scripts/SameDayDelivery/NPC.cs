using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    private Animator am;
    [SerializeField] private GameObject ragDoll;
    private void Awake()
    {
        ragDoll.SetActive(false);
        am = GetComponent<Animator>(); 
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Van")
        {
            am.enabled = false;
            ragDoll.SetActive(true); 
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag=="Van")
        {
            //reassemble ragdoll 
        }
    }

}
