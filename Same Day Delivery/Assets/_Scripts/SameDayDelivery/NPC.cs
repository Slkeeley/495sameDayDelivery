using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class NPC : MonoBehaviour
{
    [Header("AI Data")]
    public float moveSpeed; 
    public LayerMask whatIsSidewalk;
    public float walkPointRange;
    public Vector3 walkPoint; 
    private NavMeshAgent agent;
    private GameObject player;
    bool walkPointSet=false;
    float despawnRadius; 
   

    //  private Animator am;
    private SameDayDelivery.Controls.GameWatcher watcher;
    private NPCSpawner spawner; 
    public Rigidbody[] ragdollLimbs;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>(); 
        // ragDoll.SetActive(false);
        ragdollLimbs = GetComponentsInChildren<Rigidbody>();
        foreach (Rigidbody i in ragdollLimbs)//get all of the rigidbodies present within the rig and add them to the array 
        {
            i.collisionDetectionMode = CollisionDetectionMode.ContinuousSpeculative; 
            i.isKinematic = true; 
        }
        // am = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        watcher = GameObject.Find("GameWatcher").GetComponent<SameDayDelivery.Controls.GameWatcher>();
        spawner = GameObject.Find("EnemySpawner").GetComponent<NPCSpawner>();
        despawnRadius = spawner.despawnRadius; 
    }

    private void Update()
    {
        walk();
        checkDistFromPlayer();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Van" || other.tag =="Player")//if the NPC runs into a player or the player's van activate their ragdolls
        {
            int eventChance = Random.Range(0, 5);
            if (eventChance < 1) spawner.vanHit?.Invoke(); 

            foreach (Rigidbody i in ragdollLimbs)
            {
                i.isKinematic = false;

            }
            agent.isStopped = true; 
            //  am.enabled = false;

            if (watcher.evilIntentions.purchased)
            {
                watcher.currentScore = watcher.currentScore + 5; 
            }
            StartCoroutine(despawn()); 
        }

        if (other.tag=="Player")//if the npc is hit by a thrown package damage the package then activate the ragdoll
        {
            foreach (Rigidbody i in ragdollLimbs)
            {
                i.isKinematic = false;
            }
            agent.isStopped = true;
            //  am.enabled = false;
            if (watcher.evilIntentions.purchased)
            {
                watcher.currentScore = watcher.currentScore + 5;
            }
            StartCoroutine(despawn());
        }
    }

    void walk()
    {
        if (!walkPointSet) searchWalkPoint();

        if (walkPointSet)
        {           
            agent.SetDestination(walkPoint); 
        }
        Vector3 distanceToWalkPoint = transform.position - walkPoint; 

        if(distanceToWalkPoint.magnitude < 1f)
        {
            walkPointSet = false; 
        }
    }

    void searchWalkPoint()
    {
        float randomZ = Random.Range(-walkPointRange, walkPointRange); 
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsSidewalk))
        {
            walkPointSet = true; 
        } 
    }


   void checkDistFromPlayer()
    {
        Vector3 distanceFromPlayer = transform.position - player.transform.position;
        
        if(distanceFromPlayer.magnitude >= despawnRadius)
        {
            cullNPC(); 
        }
    }

    private void cullNPC()
    {
        spawner.npcsOut--;
        Destroy(this.gameObject); 
    }
    IEnumerator despawn()
    {
        yield return new WaitForSeconds(5);
        spawner.npcsOut--; 
        Destroy(this.gameObject); 
    }
}
