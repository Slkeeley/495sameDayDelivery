using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace SameDayDelivery.VanControls
{
    public class PackageDropper : MonoBehaviour
    {
        public Transform packageSpawnPos;
        public GameObject droppedPackage;
        public GameObject reminderText;

        public bool playerInRange;

        private void Awake()
        {
            reminderText.SetActive(false);
        }

        public void CheckSpawnPackage(InputAction.CallbackContext context)
        {
            if (!context.performed) return;
            if (!playerInRange) return;
            
            SpawnPackage();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                playerInRange = true;
                reminderText.SetActive(true);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                playerInRange = false;
                reminderText.SetActive(false);
            }
        }

        void SpawnPackage()
        {
            Instantiate(droppedPackage, packageSpawnPos.position, Quaternion.identity);
        }
    }
}
