using UnityEngine;

namespace SameDayDelivery
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

        private void Awake()
        {
            _characterController = GetComponent<CharacterController>();
            _rigidBody = GetComponent<Rigidbody>();
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        private void Update()
        {
            var horizontalInput = Input.GetAxis("Horizontal");
            var verticalInput = Input.GetAxis("Vertical");

            var speed = (Input.GetKey(KeyCode.LeftShift)) ? runSpeed : walkSpeed;

            var forward = _cam.transform.forward;
            var right = _cam.transform.right;

            forward.y = 0f;
            right.y = 0f;
            
            // ensure we are only talking about direction, and not speed
            forward.Normalize();
            right.Normalize();
            
            // combine the vertical and horizontal vectors, and once again normalize them so we don't move faster diagonally
            var motion = (forward * verticalInput + right * horizontalInput).normalized;
            
            // direction, speed, and time coefficient, and we're done!
            var motionWithSpeed = motion * (speed * Time.deltaTime);
            
            // transform.Translate(motion * (speed * Time.deltaTime));
            _characterController.Move(motionWithSpeed);
            
            // "rotates" character to always face in direction of camera. We may want to slerp this in the future.
            transform.forward = forward;
        }
    }
}
