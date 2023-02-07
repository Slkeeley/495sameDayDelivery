using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Neighborhood : MonoBehaviour
{
    public List<GameObject> homes;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void chooseDeliveryDestination()
    {
        for (int i = 0; i < homes.Count; i++)
        {
            int houseSelected = Random.Range(0, homes.Count);

            if (homes[houseSelected].GetComponent<Destinations>().packageDelivered == false)
            {
                homes[houseSelected].GetComponent<Destinations>().activeHouse = true;
                break;
            }
            else
            {
                i--; //keep iterating if the house was already selected or was too close
            }
        }
    }
}
