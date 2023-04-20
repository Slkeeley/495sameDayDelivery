using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events; 

public class StreetLamp : MonoBehaviour
{
    Rigidbody rb;
    Collider cd;
    SameDayDelivery.Controls.GameWatcher gw;
    [SerializeField] private GameObject lamp;
    [SerializeField] private GameObject lense;
    [SerializeField] private Material gray; 
    [SerializeField] private Material lampMat;
    [SerializeField] private Material transparent;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        cd = GetComponent<BoxCollider>();
        gw = GameObject.Find("GameWatcher").GetComponent<SameDayDelivery.Controls.GameWatcher>(); 
        rb.useGravity = false; 
        rb.isKinematic = true; 
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Van")
        {
            rb.useGravity = true; 
            rb.isKinematic = false;
            cd.enabled = false;
            gw.propHit?.Invoke(); 
            StartCoroutine(flicker());

        }
    }

    IEnumerator flicker()//changes the material of the lamp from lit to a basic gray after being hit by the van
    {
        lense.GetComponent<MeshRenderer>().material = transparent;
        lamp.GetComponent<MeshRenderer>().material = gray;  
        yield return new WaitForSeconds(.1f);
        lamp.GetComponent<MeshRenderer>().material = lampMat;
        yield return new WaitForSeconds(.1f);
        lamp.GetComponent<MeshRenderer>().material = gray;
        yield return new WaitForSeconds(.1f);
        lamp.GetComponent<MeshRenderer>().material = lampMat;
        yield return new WaitForSeconds(.1f);
        lamp.GetComponent<MeshRenderer>().material = gray;
        yield return new WaitForSeconds(.1f);
        lamp.GetComponent<MeshRenderer>().material = lampMat;
        yield return new WaitForSeconds(.1f);
        lamp.GetComponent<MeshRenderer>().material = gray;  
        yield return new WaitForSeconds(.1f);
        lamp.GetComponent<MeshRenderer>().material = lampMat;
        yield return new WaitForSeconds(.1f);
        lamp.GetComponent<MeshRenderer>().material = gray;
    }
}
