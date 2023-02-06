using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PackageDestinationSelection : MonoBehaviour
{

    public List<GameObject> neighborhoods;
    public int mostRecentNeighborhood;
    int chosenN; 
    public float timeBetweenSelection; 
    public float activeTime; 
    
    // Start is called before the first frame update
    void Start()
    {
        chooseNeighborhood();    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void chooseNeighborhood()
    {
        Debug.Log("choosing neighborhood");
        for (int i = 0; i < neighborhoods.Count; i++)
        {
             chosenN = Random.Range(0, neighborhoods.Count);
            if(chosenN!=mostRecentNeighborhood)
            {
                Debug.Log("chosen neighborhood is " + chosenN);
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
