using System;
using UnityEngine;

namespace SameDayDelivery
{
    public class Package : MonoBehaviour
    {
        public float pickupTime = 1f;
        
        private bool _pickupValid;
        private PackagePickup _packagePickup;

        private float pickupTimer;

        private void Awake()
        {
            pickupTimer = pickupTime;
        }

        private void Update()
        {
            if (pickupTimer > 0)
                pickupTimer -= Time.deltaTime;

            if (_pickupValid) return;
            
            if (Input.GetKey(KeyCode.E))
            {
                if (_packagePickup && pickupTimer <= 0)
                    _packagePickup.Pickup(gameObject);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            _packagePickup = other.GetComponent<PackagePickup>();
            if (!_packagePickup) return;
            _pickupValid = true;
        }

        public void ResetPickupTimer()
        {
            _pickupValid = false;
            pickupTimer = pickupTime;
        }
    }
}
