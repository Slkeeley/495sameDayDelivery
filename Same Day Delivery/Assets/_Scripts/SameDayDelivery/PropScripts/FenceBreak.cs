using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FenceBreak : MonoBehaviour
{
    public Rigidbody[] rBodies;

    private void Awake()
    {
        rBodies = GetComponentsInChildren<Rigidbody>();
        foreach (Rigidbody i in rBodies)//get all of the rigidbodies present within the rig and add them to the array 
        {
            i.collisionDetectionMode = CollisionDetectionMode.ContinuousSpeculative;
            i.isKinematic = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Van")
        {
           foreach (Rigidbody i in rBodies)
            {
                i.isKinematic = false;

            }
            GetComponent<BoxCollider>().enabled = false; 
        }
    }
}
