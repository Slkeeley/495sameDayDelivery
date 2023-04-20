using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class barricade : MonoBehaviour
{
    [SerializeField] private GameObject unbroken; 
    [SerializeField] private GameObject Broken;
    SameDayDelivery.Controls.GameWatcher gw;

    private void Awake()
    {
        gw = GameObject.Find("GameWatcher").GetComponent<SameDayDelivery.Controls.GameWatcher>();
        unbroken.SetActive(true);
        Broken.SetActive(false); 
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Van")
        {
            switchStates();
            gw.propHit?.Invoke(); 
            GetComponent<BoxCollider>().enabled = false;
        }
    }

    void switchStates()
    {
        unbroken.SetActive(false);
        Broken.SetActive(true);
    }
}
