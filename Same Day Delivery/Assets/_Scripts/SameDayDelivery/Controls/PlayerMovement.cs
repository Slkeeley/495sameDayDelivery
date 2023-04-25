using System;
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
        public float pushPower = 2.0F;
        [Tooltip("Any rigidbody with mass equal to this number or greater, will not be pushed.")]
        public float pushMassMax = 100f;

        [SerializeField, Header("Camera Settings")]
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
        [SerializeField]
        private Animator _animator;

        private float _horizontalRampTimer;
        private float _verticalRampTimer;

        private PackagePickup _packagePickup;
        private static readonly int SpeedAnim = Animator.StringToHash("Speed");
        private static readonly int SprintingAnim = Animator.StringToHash("Sprinting");
        private float _oldHorizontalInput;
        private float _oldVerticalInput;

        private const float TOLERANCE = 0.01f;

        private void Awake()
        {
            _characterController = GetComponent<CharacterController>();
            _rigidBody = GetComponent<Rigidbody>();
            _playerControlManager = GetComponent<PlayerControlManager>();
            _packagePickup = GetComponent<PackagePickup>();
            _horizontalRampTimer = 0f;
            _verticalRampTimer = 0f;
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
            var transform1 = transform;
            while (true)
            {
                // GroundCharacter();
                var pos = transform1.position;
                pos.y = 0.15f;
                transform1.position = pos;
                yield return new WaitForSeconds(groundCheckInterval);
            }
        }

        private void Update()
        {
            SpeedRamp();
            Movement();
        }

        private void SpeedRamp()
        {
            var horizontalInput = _playerControlManager.move.x;
            var verticalInput = _playerControlManager.move.y;

            if (horizontalInput != 0f)
                _horizontalRampTimer += Time.deltaTime;
            else
                _horizontalRampTimer = 0f;

            if (verticalInput != 0f)
                _verticalRampTimer += Time.deltaTime;
            else
                _verticalRampTimer = 0f;

            _horizontalRampTimer = Mathf.Clamp01(_horizontalRampTimer);
            _verticalRampTimer = Mathf.Clamp01(_verticalRampTimer);
            
            _oldHorizontalInput = horizontalInput;
            _oldVerticalInput = verticalInput;
        }

        private void Movement()
        {
            var horizontalInput = _playerControlManager.move.x;
            var verticalInput = _playerControlManager.move.y;

            var speed = (_playerControlManager.sprinting) ? runSpeed : walkSpeed;

            _animator.SetBool(SprintingAnim, _playerControlManager.sprinting);

            var upgradeSpeedMod = 1f;
            
            if (_upgradeCardio && _upgradeCardio.purchased && !_packagePickup.CarryingPackage()) 
                upgradeSpeedMod = _upgradeCardio.valueA.uValue;

            if (_upgradeWeightlifting && _upgradeWeightlifting.purchased && _packagePickup.CarryingPackage())
                upgradeSpeedMod = _upgradeWeightlifting.valueA.uValue;

            speed *= upgradeSpeedMod;
            
            // Debug.Log($"speed = {speed} speedMod = {upgradeSpeedMod}");

            var transform1 = _cam.transform;
            var forward = transform1.forward;
            var right = transform1.right;

            forward.y = 0f;
            right.y = 0f;

            // ensure we are only talking about direction, and not speed
            forward.Normalize();
            right.Normalize();

            
            // combine the vertical and horizontal vectors, and once again normalize them so we don't move faster diagonally
            var horizontalRampedInput = Mathf.Lerp(0f, horizontalInput, _horizontalRampTimer);
            var verticalRampedInput = Mathf.Lerp(0f, verticalInput, _verticalRampTimer);
            
            var motion = (forward * verticalRampedInput + right * horizontalRampedInput);

            // motion = Vector3.Slerp(Vector3.zero, motion, _speedRampTimer);

            // direction, speed, and time coefficient, and we're done!
            var motionWithSpeed = motion * (speed * Time.deltaTime);

            // motionWithSpeed = Vector3.Slerp(Vector3.zero, motionWithSpeed, _speedRampTimer);
            
            // trigger animation with speed
            if (_animator)
            {
                var horizontalSpeed = motionWithSpeed.magnitude;
                // Debug.Log($"horizontalSpeed = {horizontalSpeed.ToString()}");
                _animator.SetFloat(SpeedAnim, horizontalSpeed);
            }

            _isGrounded = _characterController.isGrounded;
            if (!_isGrounded)
            {
                motionWithSpeed.y = -9.81f;
            }
            
            if (_characterController && motionWithSpeed != Vector3.zero)
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
            _isGrounded = _characterController.isGrounded;
        }

        void OnControllerColliderHit(ControllerColliderHit hit)
        {
            Rigidbody body = hit.collider.attachedRigidbody;
            if (!body) return;
            
            var mass = body.mass;
            if (mass >= pushMassMax) return;

            mass = Mathf.Max(mass, 1f);
            // no rigidbody
            if (body == null || body.isKinematic)
                return;

            // We dont want to push objects below us
            if (hit.moveDirection.y < -0.3f)
                return;

            // Calculate push direction from move direction,
            // we only push objects to the sides never up and down
            Vector3 pushDir = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);

            // If you know how fast your character is trying to move,
            // then you can also multiply the push velocity by that.

            // Apply the push
            
            body.velocity = pushDir * pushPower / mass;
        }
    }
}
