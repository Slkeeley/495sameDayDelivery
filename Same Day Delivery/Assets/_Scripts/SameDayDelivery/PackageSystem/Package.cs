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
            _rigidbody.isKinematic = true;
            _rigidbody.detectCollisions = false;
            _rigidbody.useGravity = false;
        }

        public void Throw(Vector3 direction, float power = 1f)
        {
            _rigidbody.isKinematic = false;
            _rigidbody.detectCollisions = true;
            _rigidbody.useGravity = true;
            
            _rigidbody.AddForce(direction * power, ForceMode.Impulse);
        }
    }
}
