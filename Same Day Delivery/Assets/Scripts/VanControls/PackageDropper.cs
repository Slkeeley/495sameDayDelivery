using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PackageDropper : MonoBehaviour
{
    public Transform packageSpawnPos;
    public GameObject droppedPackage;
    public GameObject reminderText;
    public bool playerInRange; 
    // Update is called once per frame
    void Update()
    {
        if (playerInRange)
        {
            reminderText.SetActive(true);
            if(Input.GetKeyDown(KeyCode.E))
            {
                spawnPackage(); 
            }
        }
        else reminderText.SetActive(false); 
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player") playerInRange = true; 
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player") playerInRange = false; 
    }
    void spawnPackage()
    {
        Instantiate(droppedPackage, packageSpawnPos.position, Quaternion.identity); 
    }
}
