using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destinations : MonoBehaviour
{
    public GameObject destinationLight;//used to visually indicate if this house needs a package delivered
    public bool activeHouse;
    public bool packageDelivered;
    public bool customerSatisfied = false;


    void Start()//set the bools and visual feedback to default values before the player begins their day
    {
        destinationLight.SetActive(false);
        activeHouse = false;
        packageDelivered = false; 
    }

    void Update()
    {
        if(activeHouse)//turn on the delivery beacon if this is the house that needs a package
        {
            destinationLight.SetActive(true);
        }
        else
        {
            destinationLight.SetActive(false); 
        }

        if(packageDelivered&&!customerSatisfied)//need two booleans so choosing neighborhood does not get called multiple times
        {
            activeHouse = false;
            customerSatisfied = true; 
            GameObject.FindObjectOfType<PackageDestinationSelection>().chooseNeighborhood(); 
        }
    }
}
