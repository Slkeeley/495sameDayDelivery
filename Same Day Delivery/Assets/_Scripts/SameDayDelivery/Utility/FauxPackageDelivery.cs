using SameDayDelivery.PackageSystem;
using UnityEngine;
using UnityEngine.Events;

namespace SameDayDelivery.Utility
{
    public class FauxPackageDelivery : MonoBehaviour
    {
        public GameObject deliveredPrefab;
        public Transform spawnLocation;
        public UnityEvent onSpawnEvent;
        public UnityEvent packageRecieved;

        private void OnTriggerEnter(Collider other)
        {
            var package = other.GetComponentInChildren<Package>();
            if (!package) return;
            
            package.gameObject.SetActive(false);

            var fx = Instantiate(deliveredPrefab);
            fx.transform.position = spawnLocation.position;
            onSpawnEvent?.Invoke();
            packageRecieved?.Invoke(); 
            gameObject.SetActive(false);
        }
    }
}