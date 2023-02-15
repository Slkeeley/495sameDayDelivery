using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace SameDayDelivery.PackageSystem
{
    public class PackagePickup : MonoBehaviour
    {
        [Tooltip("Time in seconds until throw charge is at maximum force.")]
        public float maxChargeTime = 1f;
        [Tooltip("Maximum throw force after 'Max Charge Time' seconds.")]
        public float maxThrowForce = 10f;

        [SerializeField] private Transform packageMount;
        [SerializeField] private Transform packagesParent;
        [SerializeField] private Package carryingPackage;
        [SerializeField] private Camera _camera;
        private readonly List<Package> _availablePackages = new List<Package>();
        private PlayerControlManager _playerControls;
        [SerializeField]
        private bool _buttonDown;
        [SerializeField]
        private float _throwCharge;
        private Rigidbody _packageRigidBody;
        private bool _justPickedUp;

        private void Awake()
        {
            _playerControls = GetComponent<PlayerControlManager>();
        }

        private void OnEnable()
        {
            // _playerControls.InteractBegin += PackageInteraction;
            _playerControls.InteractBegin += ButtonDown;
            _playerControls.InteractEnd += ButtonUp;
        }

        private void OnDisable()
        {
            _playerControls.InteractBegin -= ButtonDown;
            _playerControls.InteractEnd -= ButtonUp;
        }

        private void ButtonUp()
        {
            Debug.Log($"Button up!");
            _buttonDown = false;
            if (!carryingPackage) return;
            if (_justPickedUp) return;
            
            ThrowPackage();
        }

        private void ButtonDown()
        {
            Debug.Log($"Button down!");
            if (carryingPackage)
            {
                _buttonDown = true;
                _throwCharge = 0f;
            }
            else
            {
                PickupPackage();
            }
        }

        private void Update()
        {
            if (!carryingPackage) return; 
            if (!_buttonDown) return;
            
            _throwCharge += Time.deltaTime;
            _throwCharge = Mathf.Clamp(_throwCharge, 0f, maxChargeTime);
        }

        private void ThrowPackage()
        {
            Debug.Log($"Throwing package!");
            Transform localTransform;
            (localTransform = carryingPackage.transform).SetParent(packagesParent);
            localTransform.position = packageMount.position;

            var forward = _camera.transform.forward;

            // gets ratio of chargeTime to maxChargeTime
            var chargeTimeRatio = Mathf.InverseLerp(0f, maxChargeTime, _throwCharge);
            // Interpolated value from 0 to maxThrowForce based on ratio of chargeTime to maxChargeTime
            var power = Mathf.Lerp(0f, maxThrowForce, chargeTimeRatio);
            
            // drops the package with a force based on the camera's forward vector and the power based on the time
            // holding down the drop button.
            carryingPackage.Drop(forward, power);
            
            
            carryingPackage = null;
            _justPickedUp = false;
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
            _justPickedUp = true;
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
