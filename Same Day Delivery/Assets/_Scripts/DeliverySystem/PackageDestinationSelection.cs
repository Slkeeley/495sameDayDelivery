using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PackageDestinationSelection : MonoBehaviour
{

    public List<GameObject> neighborhoods;//List all of the nieghborhoods that the player may deliver a package to
    public int mostRecentNeighborhood;//get the most recent one so the player doesn't go ot the same neighborhood back to back times
    int chosenN; //the integer used to choose a neighborhood for delivery
   // public float timeBetweenSelection;
    //public float activeTime; 
    
    // Start is called before the first frame update
    void Start()
    {
        chooseNeighborhood();    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void chooseNeighborhood()//c
    {
        for (int i = 0; i < neighborhoods.Count; i++)
        {
             chosenN = Random.Range(0, neighborhoods.Count);
            if(chosenN!=mostRecentNeighborhood)
            {
                mostRecentNeighborhood = chosenN;
                break;
            }            
            else
            {
                i--; //keep iterating if the house was already selected or was too close
            }
        }

        neighborhoods[chosenN].GetComponent<Neighborhood>().chooseDeliveryDestination(); 
    }
}
