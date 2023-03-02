using System.Collections;
using SameDayDelivery.PackageSystem;
using SameDayDelivery.ScriptableObjects;
using UnityEngine;

namespace SameDayDelivery.Controls
{
    public class PlayerMovement : MonoBehaviour
    {
        [Tooltip("Walk speed in meters")]
        public float walkSpeed = 6f;
        [Tooltip("Run speed in meters (when activated by player. Unconfirmed feature)")]
        public float runSpeed = 12f;

        [Header("Technical")]
        [Tooltip("Which layer is considered the 'ground' layer. [Not working]")]
        public LayerMask groundLayer;
        [Tooltip("How long between ground checks in seconds. [Not working]")]
        public float groundCheckInterval = 0.25f;
        public float yOffset = 0.2f;

        [SerializeField]
        private Camera _cam;

        [SerializeField]
        private UpgradeItem _upgradeCardio;
        [SerializeField]
        private UpgradeItem _upgradeWeightlifting;
        
        private CharacterController _characterController;
        private Rigidbody _rigidBody;
        private PlayerControlManager _playerControlManager;
        private Ray _ray;
        private RaycastHit _hit;
        [SerializeField]
        private bool _isGrounded;

        private PackagePickup _packagePickup;

        private void Awake()
        {
            _characterController = GetComponent<CharacterController>();
            _rigidBody = GetComponent<Rigidbody>();
            _playerControlManager = GetComponent<PlayerControlManager>();
            _packagePickup = GetComponent<PackagePickup>();
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        private void OnEnable()
        {
            _playerControlManager.MoveBegin += Movement;
            // StartCoroutine(UpdateVerticalPosition());
        }

        private void OnDisable()
        {
            _playerControlManager.MoveBegin -= Movement;
            // StopCoroutine(UpdateVerticalPosition());
        }

        private IEnumerator UpdateVerticalPosition()
        {
            while (true)
            {
                // GroundCharacter();
                var pos = transform.position;
                pos.y = 0.15f;
                transform.position = pos;
                yield return new WaitForSeconds(groundCheckInterval);
            }
        }

        private void Update()
        {
            Movement();
        }

        private void Movement()
        {
            var horizontalInput = _playerControlManager.move.x;
            var verticalInput = _playerControlManager.move.y;

            var speed = (_playerControlManager.sprinting) ? runSpeed : walkSpeed;

            var upgradeSpeedMod = 1f;
            
            if (_upgradeCardio && _upgradeCardio.purchased && !_packagePickup.CarryingPackage()) 
                upgradeSpeedMod = _upgradeCardio.valueA.uValue;

            if (_upgradeWeightlifting && _upgradeWeightlifting.purchased && _packagePickup.CarryingPackage())
                upgradeSpeedMod = _upgradeWeightlifting.valueA.uValue;

            speed *= upgradeSpeedMod;
            
            Debug.Log($"speed = {speed} speedMod = {upgradeSpeedMod}");

            var transform1 = _cam.transform;
            var forward = transform1.forward;
            var right = transform1.right;

            forward.y = 0f;
            right.y = 0f;

            // ensure we are only talking about direction, and not speed
            forward.Normalize();
            right.Normalize();

            // combine the vertical and horizontal vectors, and once again normalize them so we don't move faster diagonally
            var motion = (forward * verticalInput + right * horizontalInput).normalized;

            // direction, speed, and time coefficient, and we're done!
            var motionWithSpeed = motion * (speed * Time.deltaTime);

            _isGrounded = _characterController.isGrounded;
            if (!_isGrounded)
            {
                motionWithSpeed.y = -9.81f;
            }
            _characterController.Move(motionWithSpeed);

            // "rotates" character to always face in direction of camera. We may want to slerp this in the future.
            transform.forward = forward;
            
            // emergency ground sticking logic (it's terrible replace it with something that actually works)
            var pos = transform.position;
            pos.y = yOffset;
            transform.position = pos;
        }

        private void GroundCharacter()
        {
            var transform1 = transform;
            _ray = new Ray();
            _ray.origin = transform1.position;
            _ray.direction = Vector3.down;

            if (Physics.Raycast(_ray, out _hit, 100f, groundLayer))
            {
                var pos = transform1.position;
                pos.y = _hit.point.y;
                transform.position = pos;
            }
            // var pos = transform.position;
            // pos.y = yOffset;
            // transform.position = pos;
        }
    }
}
