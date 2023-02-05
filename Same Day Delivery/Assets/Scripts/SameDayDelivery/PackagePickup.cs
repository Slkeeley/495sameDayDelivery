using System.Collections.Generic;
using UnityEngine;

namespace SameDayDelivery
{
    public class PackagePickup : MonoBehaviour
    {
        [SerializeField] private Transform packageMount;
        [SerializeField] private Transform packagesParent;
        [SerializeField] private Package carryingPackage;
        private readonly List<Package> _availablePackages = new List<Package>();

        private void Update()
        {
            if (!Input.GetKey(KeyCode.E)) return;
            if (carryingPackage)
                DropPackage();
            else
                PickupPackage();
        }

        private void DropPackage()
        {
            carryingPackage.transform.SetParent(packagesParent);
            carryingPackage.transform.position = packageMount.position;
            carryingPackage.Drop();
            carryingPackage = null;
        }

        private void PickupPackage()
        {
            
            if (_availablePackages.Count <= 0) return;

            var targetPackage = _availablePackages[0];
            var finalDistance = Vector3.Distance(transform.position, targetPackage.transform.position);

            foreach (var package in _availablePackages)
            {
                var newDistance = Vector3.Distance(transform.position, package.transform.position);
                if (!(finalDistance < newDistance)) continue;
                finalDistance = newDistance;
                targetPackage = package;
            }

            carryingPackage = targetPackage;
            carryingPackage.Pickup();
            carryingPackage.transform.position = packageMount.position;
            carryingPackage.transform.SetParent(packageMount);
        }

        private void OnTriggerEnter(Collider other)
        {
            var package = other.GetComponent<Package>();
            if (!package) return;
            _availablePackages.Add(package);
        }

        private void OnTriggerExit(Collider other)
        {
            var package = other.GetComponent<Package>();
            if (!package) return;
            if (_availablePackages.Contains(package))
                _availablePackages.Remove(package);
        }
    }
}
