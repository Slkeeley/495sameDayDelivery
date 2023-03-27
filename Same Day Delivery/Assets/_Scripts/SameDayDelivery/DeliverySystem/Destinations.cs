using SameDayDelivery.Controls;
using System.Collections;
using System.Globalization;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events; 

namespace SameDayDelivery.DeliverySystem
{
    public class Destinations : MonoBehaviour
    {
        public GameObject destinationLight; //used to visually indicate if this house needs a package delivered
        public bool active=false; 
        public bool packageDelivered;


        void Start() //set the bools and visual feedback to default values before the player begins their day
        {
            packageDelivered = false;
        }
        void FixedUpdate()
        {
            if (active)
            {
                Debug.Log("should be active"); 
                destinationLight.SetActive(true);
            }
            else destinationLight.SetActive(false);

        }
  
        public void packageReceived()//to be called in the event that a package was received

        {
             active= false;
            packageDelivered = true;
            FindObjectOfType<PackageDestinationSelection>().chooseNeighborhood();
            FindObjectOfType<GameWatcher>().PackageReceived();
        }
    }
}