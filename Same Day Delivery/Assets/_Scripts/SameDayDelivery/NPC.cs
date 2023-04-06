using System.Collections;
using System.Collections.Generic;
using SameDayDelivery.Controls;
using UnityEngine;

public class NPC : MonoBehaviour
{
    private Animator am;
    [SerializeField] private SameDayDelivery.ScriptableObjects.UpgradeItem evilIntentions; 
    [SerializeField] private GameObject ragDoll;
    private SameDayDelivery.Controls.GameWatcher watcher;
    private void Awake()
    {
        ragDoll.SetActive(false);
        am = GetComponent<Animator>();
        watcher = GameObject.Find("GameWatcher").GetComponent<SameDayDelivery.Controls.GameWatcher>(); 
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Van")
        {
            am.enabled = false;
            ragDoll.SetActive(true); 
            if(evilIntentions.purchased)
            {
                GameWatcher.currentScore += 5; 
            }
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
