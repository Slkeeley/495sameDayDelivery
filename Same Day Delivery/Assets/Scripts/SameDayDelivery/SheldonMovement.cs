using UnityEngine;

public class SheldonMovement : MonoBehaviour
{
    [Tooltip("Walk speed in meters")]
    public float walkSpeed = 6f;
    [Tooltip("Run speed in meters (when activated by player. Unconfirmed feature)")]
    public float runSpeed = 9f;
    private CharacterController _characterController;
    private Rigidbody _rigidBody;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
        _rigidBody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        var horizontalInput = Input.GetAxis("Horizontal");
        var verticalInput = Input.GetAxis("Vertical");

        var speed = (Input.GetKey(KeyCode.LeftShift)) ? runSpeed : walkSpeed;
        
        _characterController.Move(new Vector3(horizontalInput, 0f, verticalInput) * (Time.deltaTime * speed));
    }
}
