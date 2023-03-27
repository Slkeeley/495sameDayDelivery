using System.Collections.Generic;
using UnityEngine;

namespace SameDayDelivery.DeliverySystem
{
    public class Neighborhood : MonoBehaviour
    {
        [SerializeField] private GameObject chosenHouse; 
        public List<GameObject> homes; //All the possible delivery destinations within this neighborhood


        public void
            chooseDeliveryDestination() //randomly select one house in this neighborhood to deliver a package to. 
        {
            for (int i = 0; i < homes.Count; i++)
            {
                int houseSelected = Random.Range(0, homes.Count);

                if (homes[houseSelected].GetComponent<Destinations>().packageDelivered == false)
                {
                  //  homes[houseSelected].GetComponent<Destinations>().activeHouse = true;
                    chosenHouse = homes[houseSelected];
                    if (chosenHouse.GetComponent<Destinations>().active == false) 
                    {  
                        chosenHouse.GetComponent<Destinations>().active = true; 
                    }
                  
                    break;
                }
                else
                {
                    i--; //keep iterating if the house was already selected or was too close
                }
            }
        }
    }
}
