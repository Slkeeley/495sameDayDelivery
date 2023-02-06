using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destinations : MonoBehaviour
{
    public GameObject destinationLight;
    public bool activeHouse;
    public bool packageDelivered;
    public bool customerSatisfied = false;

    public int Neighborhood; 
    // Start is called before the first frame update
    void Start()
    {
        destinationLight.SetActive(false);
        activeHouse = false;
        packageDelivered = false; 

    }

    // Update is called once per frame
    void Update()
    {
        if(activeHouse)
        {
            destinationLight.SetActive(true);
        }
        else
        {
            destinationLight.SetActive(false); 
        }

        if(packageDelivered&&!customerSatisfied)
        {
            activeHouse = false;
            customerSatisfied = true; 
            GameObject.FindObjectOfType<PackageDestinationSelection>().chooseNeighborhood(); 
        }
    }
}
