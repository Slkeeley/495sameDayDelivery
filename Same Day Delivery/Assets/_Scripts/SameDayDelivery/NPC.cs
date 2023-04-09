using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    //  private Animator am;
    [SerializeField] private SameDayDelivery.ScriptableObjects.UpgradeItem evilIntentions;
    //[SerializeField] private GameObject ragDoll;
    private SameDayDelivery.Controls.GameWatcher watcher;
    public Rigidbody[] ragdollLimbs; 
    private void Awake()
    {
        // ragDoll.SetActive(false);
        ragdollLimbs = GetComponentsInChildren<Rigidbody>();
        foreach (Rigidbody i in ragdollLimbs)
        {
            i.isKinematic = true; 
        }
        // am = GetComponent<Animator>();
        watcher = GameObject.Find("GameWatcher").GetComponent<SameDayDelivery.Controls.GameWatcher>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Van" || other.tag =="Player")
        {
            foreach (Rigidbody i in ragdollLimbs)
            {
                i.isKinematic = false;
            }
            //  am.enabled = false;
            // ragDoll.SetActive(true); 
            if (evilIntentions.purchased)
            {
                watcher.currentScore = watcher.currentScore + 5; 
            }
        }

        if (other.GetComponent<SameDayDelivery.PackageSystem.Package>())
        {
            foreach (Rigidbody i in ragdollLimbs)
            {
                i.isKinematic = false;
            }
            //  am.enabled = false;
            //    ragDoll.SetActive(true);
            if (evilIntentions.purchased)
            {
                watcher.currentScore = watcher.currentScore + 5;
            }
        }
    }
/*
    private void OnTriggerExit(Collider other)
    {
        if(other.tag=="Van")
        {
            //reassemble ragdoll 
        }
    }
*/
}
