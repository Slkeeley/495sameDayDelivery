using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicNPCSpawn : MonoBehaviour
{
    public GameObject[] spawnLocations;
    public GameObject[] NPCs; 
    public int maxNPCs;
    public int npcsOut;
    bool inCoroutine; 

    private void Update()
    {
        if(npcsOut < maxNPCs)
        {
            if(!inCoroutine)
            {
                StartCoroutine(spawnNPC()); 
            }
        }
    }

    IEnumerator spawnNPC()
    {
        inCoroutine = true;
        yield return new WaitForSeconds(1);
        Debug.Log("Spawning NPC");
        npcsOut++; 
        int spawnPoint = Random.Range(0, spawnLocations.Length);
        int randNPCs = Random.Range(0, NPCs.Length);
        GameObject.Instantiate(NPCs[randNPCs], spawnLocations[spawnPoint].transform.position, Quaternion.identity);
        inCoroutine = false; 

    }
}
