using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class barricade : MonoBehaviour
{
    [SerializeField] private GameObject unbroken; 
    [SerializeField] private GameObject Broken;

    private void Awake()
    {
        unbroken.SetActive(true);
        Broken.SetActive(false); 
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Van")
        {
            switchStates();
            GetComponent<BoxCollider>().enabled = false;
        }
    }

    void switchStates()
    {
        unbroken.SetActive(false);
        Broken.SetActive(true);
    }
}
