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
    bool walkPointSet=false; 

    //  private Animator am;
    private SameDayDelivery.Controls.GameWatcher watcher;
    private BasicNPCSpawn spawner; 
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
        watcher = GameObject.Find("GameWatcher").GetComponent<SameDayDelivery.Controls.GameWatcher>();
        spawner = GameObject.Find("EnemySpawner").GetComponent<BasicNPCSpawn>(); 
    }

    private void Update()
    {
        walk(); 
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Van" || other.tag =="Player")//if the NPC runs into a player or the player's van activate their ragdolls
        {
            Debug.Log("Collided"); 
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

        if (other.GetComponent<SameDayDelivery.PackageSystem.Package>())//if the npc is hit by a thrown package damage the package then activate the ragdoll
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
        Debug.Log("walking"); 
        if (!walkPointSet) searchWalkPoint();

        if (walkPointSet)
        {
            //     var step = moveSpeed * Time.deltaTime; // calculate distance to move
            //   transform.position = Vector3.MoveTowards(transform.position, walkPoint, step);
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
        Debug.Log("Searching for walk Point"); 
        float randomZ = Random.Range(-walkPointRange, walkPointRange); 
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsSidewalk))
        {
            walkPointSet = true; 
        } 
    }

    IEnumerator despawn()
    {
        yield return new WaitForSeconds(5);
        spawner.npcsOut--; 
        Destroy(this.gameObject); 
    }
}
