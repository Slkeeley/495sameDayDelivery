using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

namespace SameDayDelivery.VanControls
{
    public class EmergencyBreaks : MonoBehaviour
    {
        [SerializeField]
        private float _updateInterval = 0.005f;
        [SerializeField]
        private float _decelerationModifier = 0.9f;
        
        private Rigidbody _rb;
        private bool _movementInput;
        private VanController _vanController;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody>();
            _vanController = GetComponent<VanController>();
        }

        private void Start()
        {
            StartCoroutine(CheckMovementUpdate());
        }

        private IEnumerator CheckMovementUpdate()
        {
            while (true)
            {
                var mag = _rb.velocity.magnitude;
                
                if (!_vanController.enabled && mag > 0.01f)
                {
                    _rb.velocity *= _decelerationModifier;
                    mag = _rb.velocity.magnitude;
                    if (mag < 2f)
                        _rb.velocity = Vector3.zero;
                }
                yield return new WaitForSeconds(_updateInterval);
            }
        }
    }
}