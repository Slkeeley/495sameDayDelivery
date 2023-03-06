using SameDayDelivery.Controls;
using UnityEngine;


namespace SameDayDelivery.DeliverySystem
{
    public class Destinations : MonoBehaviour
    {
        public GameObject destinationLight; //used to visually indicate if this house needs a package delivered
        public bool activeHouse;
        public bool packageDelivered;



        void Start() //set the bools and visual feedback to default values before the player begins their day
        {
            destinationLight.SetActive(false);
            activeHouse = false;
            packageDelivered = false;
        }

        void Update()
        {
            if (activeHouse) //turn on the delivery beacon if this is the house that needs a package
            {
                destinationLight.SetActive(true);
            }
            else
            {
                destinationLight.SetActive(false);
            }

        }


        public void packageReceived()
        {
            activeHouse = false;
            packageDelivered = true; 
            FindObjectOfType<PackageDestinationSelection>().chooseNeighborhood();
            FindObjectOfType<GameWatcher>().PackageReceived();
        }
    }
}