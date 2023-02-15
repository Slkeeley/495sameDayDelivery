using System;
using UnityEngine;

namespace SameDayDelivery.PackageSystem
{
    public class Package : MonoBehaviour
    {
        private Rigidbody _rigidbody;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        public void Pickup()
        {
            Debug.Log($"Picked up {gameObject.name}");
            _rigidbody.isKinematic = true;
            _rigidbody.detectCollisions = false;
            _rigidbody.useGravity = false;
        }

        public void Drop(Vector3 direction, float power = 1f)
        {
            Debug.Log($"Dropped up {gameObject.name}");
            _rigidbody.isKinematic = false;
            _rigidbody.detectCollisions = true;
            _rigidbody.useGravity = true;
            
            _rigidbody.AddForce(direction * power, ForceMode.Impulse);
        }
    }
}
