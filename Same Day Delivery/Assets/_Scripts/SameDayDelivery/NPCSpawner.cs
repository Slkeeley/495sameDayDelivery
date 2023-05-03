using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events; 

public class NPCSpawner : MonoBehaviour
{
    [Header("NPCs")]
    public int maxNPCs; 
    public int npcsOut;
    [SerializeField] private GameObject[] NPCs;
    public UnityEvent vanHit; 
    public UnityEvent sheldonNoise; 

    [Header("Spawning")]
    public float spawnRadius;
    public float despawnRadius;
    public LayerMask whatIsNavMesh;
    public Vector3 spawnPoint;

    //Private Vars
    private bool isSpawning;
    private bool spawnPointFound;
    private GameObject van;

    private void Awake()
    {
        van = GameObject.FindGameObjectWithTag("Van");
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

        spawnPoint = new Vector3(van.transform.position.x + randomX, van.transform.position.y+.25f, van.transform.position.z + randomZ);
        if (Physics.Raycast(spawnPoint, -transform.up, 15f, whatIsNavMesh))
        {
            return true;
        }
        else return false; 
    }

    void selectNPC()
    {
        Debug.Log("trying to spawn an NPC"); 
        int randomNPC = Random.Range(0, NPCs.Length);
        GameObject.Instantiate(NPCs[randomNPC], spawnPoint, Quaternion.identity);
        npcsOut++; 
    }
    

    IEnumerator spawnNPC()
    {
        if (searchSpawnPoint()) selectNPC(); 
        yield return new WaitForSeconds(0.1f);
        isSpawning = true;
        spawnPointFound = false;
    }

}