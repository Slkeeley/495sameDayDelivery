using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StreetLamp : MonoBehaviour
{
    Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>(); 
        rb.isKinematic = true; 
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Van")
        {
            rb.isKinematic = false; 
        }
    }
}
