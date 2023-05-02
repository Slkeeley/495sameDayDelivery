using System;
using System.Collections;
using SameDayDelivery.PackageSystem;
using SameDayDelivery.ScriptableObjects;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

namespace SameDayDelivery.Utility
{
    public class FauxPackageDelivery : MonoBehaviour
    {
        public GameData gameData;
        public GameObject deliveredFXPrefab;
        public Transform spawnFXLocation;
        public GameObject deliveryArea;
        public GameObject houseBeam;
        public UnityEvent onSpawnEvent;
        public UnityEvent packageReceived; //Event to call the destinations package received

        private void Start()
        {
            // tells the game database that this Package Delivery location is available.
            DestinationRegistry.Instance.RegisterAvailableDelivery(this);
            Deactivate();
        }

        public void PackageDelivered(Package package)
        {
            DestinationRegistry.Instance.PackageDelivered(this, package);
        }

        public void Activate()
        {
            deliveryArea.SetActive(true);
            houseBeam.SetActive(true);
        }

        private void Deactivate()
        {
            deliveryArea.SetActive(false);
            houseBeam.SetActive(false);
        }

        private void OnTriggerEnter(Collider other)
        {
            Package package = other.GetComponent<Package>();
            if (!package) return;
            if (gameData.carryingPackage == package) return;

            GameObject fx = Instantiate(deliveredFXPrefab);
            fx.transform.position = spawnFXLocation.position;
            onSpawnEvent?.Invoke();
            packageReceived?.Invoke(); //invoke the destination package received
            
            package.gameObject.SetActive(false);
            
            Deactivate();
            gameData.OnGenericPackageDelivered?.Invoke();
            PackageDelivered(package);
        }
    }
}