using UnityEngine;

namespace SameDayDelivery.Controls
{
    public class PlayerMovement : MonoBehaviour
    {
        [Tooltip("Walk speed in meters")]
        public float walkSpeed = 6f;
        [Tooltip("Run speed in meters (when activated by player. Unconfirmed feature)")]
        public float runSpeed = 12f;

        [SerializeField]
        private Camera _cam;
        
        private CharacterController _characterController;
        private Rigidbody _rigidBody;
        private PlayerControlManager _playerControlManager;
        private Ray _ray;
        private RaycastHit _hit;
        [SerializeField]
        private bool _isGrounded;

        private void Awake()
        {
            _characterController = GetComponent<CharacterController>();
            _rigidBody = GetComponent<Rigidbody>();
            _playerControlManager = GetComponent<PlayerControlManager>();
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

        private void Update()
        {
            Movement();
        }

        private void Movement()
        {
            var horizontalInput = _playerControlManager.move.x;
            var verticalInput = _playerControlManager.move.y;

            var speed = (_playerControlManager.sprinting) ? runSpeed : walkSpeed;

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
            // var pos = transform.position;
            // pos.y = yOffset;
            // transform.position = pos;
        }
    }
}
