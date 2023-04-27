using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

namespace SameDayDelivery.Controls
{
    public class SimpleVehicle : MonoBehaviour
    {
        [SerializeField] private float moveSpeed = 10f;
        [SerializeField] private float turnSpeed = 100f;
        [SerializeField] private float _drag = 0.98f;
        [SerializeField] private float _updateInterval = 0.1f;
        [SerializeField] private Transform groundCheckRef;
        [SerializeField] private float groundDistance = 0.4f;
        [SerializeField] private LayerMask groundMask;

        private Rigidbody rb;
        private bool isGrounded = true;
        private Vector2 movementInput = new Vector2();

        private void Start()
        {
            rb = GetComponent<Rigidbody>();
            StartCoroutine(CheckGrounded());
        }

        public void OnMove(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                movementInput = context.ReadValue<Vector2>();
            }

            if (context.canceled)
            {
                movementInput = Vector2.zero;
            }
        }

        private void FixedUpdate()
        {
            Drive();
        }

        private void Drive()
        {
            float h = movementInput.x;
            float v = movementInput.y;

            if (v > 0f)
            {
                transform.Rotate(0f, h * turnSpeed * Time.deltaTime, 0f);
                rb.AddForce(transform.position + transform.forward * (v * moveSpeed * Time.deltaTime), ForceMode.Acceleration);
            }

            rb.velocity *= _drag;
        }

        private IEnumerator CheckGrounded()
        {
            while (true)
            {
                isGrounded = Physics.CheckSphere(groundCheckRef.position, groundDistance, groundMask);
                yield return new WaitForSeconds(_updateInterval);
            }
        }
    }
}