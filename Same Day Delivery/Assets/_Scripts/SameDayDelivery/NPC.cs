using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    //  private Animator am;
    [SerializeField] private SameDayDelivery.ScriptableObjects.UpgradeItem evilIntentions;
    [SerializeField] private GameObject ragDoll;
    private SameDayDelivery.Controls.GameWatcher watcher;
    private void Awake()
    {
        ragDoll.SetActive(false);
        // am = GetComponent<Animator>();
        watcher = GameObject.Find("GameWatcher").GetComponent<SameDayDelivery.Controls.GameWatcher>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Van" || other.tag =="Player")
        {
          //  am.enabled = false;
            ragDoll.SetActive(true); 
            if(evilIntentions.purchased)
            {
                watcher.currentScore = watcher.currentScore + 5; 
            }
        }

        if (other.GetComponent<SameDayDelivery.PackageSystem.Package>())
        {
            //  am.enabled = false;
            ragDoll.SetActive(true);
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
