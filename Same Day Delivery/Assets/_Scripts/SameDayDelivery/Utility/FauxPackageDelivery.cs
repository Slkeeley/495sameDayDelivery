using SameDayDelivery.PackageSystem;
using SameDayDelivery.ScriptableObjects;
using UnityEngine;
using UnityEngine.Events;

namespace SameDayDelivery.Utility
{
    public class FauxPackageDelivery : MonoBehaviour
    {
        public GameData gameData;
        public GameObject deliveredPrefab;
        public Transform spawnLocation;
        public UnityEvent onSpawnEvent;
        public UnityEvent packageRecieved;//Event to call the destinations package received

        private void OnTriggerEnter(Collider other)
        {
            var package = other.GetComponentInChildren<Package>();
            if (!package) return;
            if (gameData.carryingPackage == package) return;
            
            package.gameObject.SetActive(false);

            var fx = Instantiate(deliveredPrefab);
            fx.transform.position = spawnLocation.position;
            onSpawnEvent?.Invoke();
            packageRecieved?.Invoke(); //invoke the destination package received
            gameObject.SetActive(false);
        }
    }
}