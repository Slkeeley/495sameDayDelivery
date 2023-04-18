using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCSpawner : MonoBehaviour
{
    [Header("NPCs")]
    public int maxNPCs; 
    public int npcsOut;
    [SerializeField] private GameObject[] NPCs;
    [Header("Spawning")]
    public float spawnRadius;
    public LayerMask whatIsNavMesh;
    public Vector3 spawnPoint;

    //Private Vars
    private bool isSpawning;
    private bool spawnPointFound;
    private GameObject player;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        isSpawning = true;
        spawnPointFound = false;

    }

    private void Update()
    {
            if (npcsOut < maxNPCs && isSpawning)
            {
            isSpawning = false;    
            StartCoroutine(spawnNPC());
            }
    }

   bool searchSpawnPoint()
    {
        float randomZ = Random.Range(-spawnRadius, spawnRadius);
        float randomX = Random.Range(-spawnRadius, spawnRadius);

        spawnPoint = new Vector3(player.transform.position.x + randomX, player.transform.position.y+.25f, player.transform.position.z + randomZ);
        if (Physics.Raycast(spawnPoint, -transform.up, 15f, whatIsNavMesh))
        {
            return true;
        }
        else return false; 
    }

    void selectNPC()
    {
        int randomNPC = Random.Range(0, NPCs.Length);
        GameObject.Instantiate(NPCs[randomNPC], spawnPoint, Quaternion.identity);
        npcsOut++; 
    }
    

    IEnumerator spawnNPC()
    {
        if (searchSpawnPoint()) selectNPC(); 
        yield return new WaitForSeconds(0.25f);
        isSpawning = true;
        spawnPointFound = false;
    }
  
}
