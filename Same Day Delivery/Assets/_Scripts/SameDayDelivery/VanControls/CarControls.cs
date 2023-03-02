using System.Collections;
using SameDayDelivery.Controls;
using UnityEngine;
using UnityEngine.Events; 

namespace SameDayDelivery.VanControls
{
    public class CarControls : MonoBehaviour //THIS SCRIPT IS FOR THE CONTROLS WHILE THE PLAYER IS INSIDE THE VAN
    {
        [Header("Van Speed")]
        public static float topSpeed=25f; //the fastest speed that the van can move 
        public float topReverseSpeed; //the fastest speed that the van can move 
        public float overDriveSpeed;
        public float currSpeed; //the current speed the van is moving
        public float rotationSpeed = 100.0f;

        [Header("Acceleration")]
        public float accelerationSpeed; //the speed at which the car accelerates
        public float reverseAccelerationSpeed; //the speed at which the car accelerates
        public float decelerationSpeed; //the speed at which the car decellerates
        public bool accelerating; //check if the van's speed is increasing 
        public bool decelerating; //check if the van's speed is decreasing 

        [Header("Other Vars")]
        public bool forwards;
        public bool backwards;
        public bool overDrive;
        public float brakeForce;
        public GameObject packageChute;

        [Header("Events")]
        public UnityEvent motorStart; 
        public UnityEvent driving; 
        public UnityEvent reverse;
        public UnityEvent stopNoises;

        // private variables
        private float defaultBrakeForce; 
        private bool chuteActive;
        private Vector2 _movement;
        private PlayerControlManager _playerControlManager;

        /*
        #region Input Events and Button State Control

        private ButtonState _interactButton;
        private bool _interactHeld;
        private ButtonState _sprintButton;
        private bool _sprintHeld;

        // This may not be necessary, but if you need fine control over when the interact and sprinting buttons are pressed
        // you can use these variables and functions.

        private void OnEnable()
        {
            _playerControlManager.InteractBegin += InteractBegin;
            _playerControlManager.InteractEnd += InteractEnd;
            _playerControlManager.SprintBegin += SprintBegin;
            _playerControlManager.SprintEnd += SprintEnd;
        }

        private void OnDisable()
        {
            _playerControlManager.InteractBegin -= InteractBegin;
            _playerControlManager.InteractEnd -= InteractEnd;
            _playerControlManager.SprintBegin -= SprintBegin;
            _playerControlManager.SprintEnd -= SprintEnd;
        }

        private void InteractBegin()
        {
            _interactButton = ButtonState.Down;
            _interactHeld = true;
        }

        private void InteractEnd()
        {
            _interactButton = ButtonState.Up;
            _interactHeld = false;
        }

        private void SprintBegin()
        {
            _sprintButton = ButtonState.Down;
            _sprintHeld = true;
        }

        private void SprintEnd()
        {
            _sprintButton = ButtonState.Up;
            _sprintHeld = false;
        }

        #endregion
        */
        private void Awake()
        {
            _playerControlManager = GetComponent<PlayerControlManager>();
            overDriveSpeed = topSpeed * 2;
            defaultBrakeForce = brakeForce; 
            accelerating = false;
            chuteActive = false;
            packageChute.SetActive(false);
            Debug.Log("The Van's Top Speed is: " + topSpeed);
        }

        // Update is called once per frame
        private void Update()
        {
            _movement = _playerControlManager.move;

            Drive();
            if (decelerating)
            {
                if (forwards) StartCoroutine(Decelerate());
                if (backwards) StartCoroutine(DecelerateBackwards());
            }
            else return;

        }


        //CONTROL INPUTS TO CONTROL THE PLAYER'S VEHICLE 
        private void Drive()
        {
            rotationSpeed = currSpeed*2;
            var rotation = _movement.x * rotationSpeed;
            rotation *= Time.deltaTime;
            rotation = Mathf.Clamp(rotation, -45, 45);
            transform.Rotate(0, rotation, 0);

            //if the player presses W move forward in the direction they face
            if (_movement.y > 0f)
            {
                //Adjust these booleans when the player begins moving forward again
                decelerating = false;
                forwards = true;
                backwards = false;
                StopCoroutine(Decelerate());
                driving?.Invoke(); 

                if (currSpeed < topSpeed) accelerating = true;

                // if the vans current speed is lower than the top speed have it speed up until it reaches the top speed. 
                if (accelerating)
                {
                    var translation = _movement.y * currSpeed;
                    currSpeed += accelerationSpeed;
                    translation *= Time.deltaTime;
                    transform.Translate(0, 0, translation);

                    if (currSpeed >= topSpeed)
                    {
                        accelerating = false;
                        currSpeed = topSpeed;
                    }
                }
                else
                {
                    // if the van reaches top speed it is no longer accelerating and have it move at top speed.
                    var translation = _movement.y * topSpeed;
                    translation *= Time.deltaTime;
                    transform.Translate(0, 0, translation);
                }

                if (currSpeed > topSpeed) currSpeed -= decelerationSpeed;
            }

            if (Input.GetKeyUp(KeyCode.W))//(Mathf.Approximately(_movement.y, 0f)) // if the player lets go of W begin decelerating. 
            {
                accelerating = false;
                decelerating = true;
            }

            // If the player presses S move backward on their relative z axis
            if (_movement.y < 0f)//REVERSE
            {
                StopCoroutine(Decelerate());
                //Adjust these booleans when the player begins moving forward again
                if (forwards)
                {
                    ApplyBrakes();
                }
                else
                {
                    backwards = true;
                    reverse?.Invoke(); 
                    if (currSpeed < topReverseSpeed) accelerating = true;

                    if (accelerating) //if the vans current speed is lower than the top speed have it speed up until it reaches the top speed. 
                    {
                        var translation = _movement.y * currSpeed;
                        currSpeed += reverseAccelerationSpeed;
                        translation *= Time.deltaTime;
                        transform.Translate(0, 0, translation);
                        if (currSpeed >= topReverseSpeed)
                        {
                            accelerating = false;
                            currSpeed = topReverseSpeed;
                        }
                    }
                    else // if the van reaches top speed it is no longer accelerating and have it move at top speed 
                    {
                        var translation = _movement.y * topReverseSpeed;
                        translation *= Time.deltaTime;
                        transform.Translate(0, 0, translation);
                    }
                }
            }
            
            if (Input.GetKeyUp(KeyCode.S))//(_movement.y < 0f) //if the player lets go of S begin decelerating Backwards
            {
                accelerating = false;
                decelerating = true;
            }

            if (_playerControlManager.sprinting) increaseGear();

            if (Input.GetKeyUp(KeyCode.LeftShift)) decreaseGear(); 
        }

        private void ApplyBrakes() //if the player is moving forward and presses S apply the brakes firs
        {
            if (currSpeed > 0)
            {
                currSpeed -= brakeForce; //speed is reduced by the set brake force
            }
            else
            {
                decelerating = false;
                forwards = false;
                backwards = true;
                StopCoroutine(Decelerate());
            }
        }

        private void increaseGear() // if the player is holding shift, the van's top speed increases
        {
            overDrive = true;
            topSpeed = overDriveSpeed;
            rotationSpeed = currSpeed / 8;
            brakeForce = 0; 
        }

        private void decreaseGear() // if the player lets go of shift the top speed, rotation speed, and brake force return to normal 
        {
            overDrive = false;
            topSpeed = overDriveSpeed/2;
            rotationSpeed = currSpeed*2;
            brakeForce = defaultBrakeForce; 
        }


        public void
            ChuteActivation() //If the player is within the correct area to drop the packages turn the shoot on if they leave turn int off. 
        {
            if (!chuteActive)
            {
                chuteActive = true;
                packageChute.SetActive(true);
            }
            else
            {
                chuteActive = false;
                packageChute.SetActive(false);
            }
        }

        private IEnumerator Decelerate() //for the car to continue to move forward once the player has let go of w
        {
            transform.Translate(Vector3.forward * (currSpeed * Time.deltaTime));
            currSpeed -= decelerationSpeed;
            yield return new WaitForEndOfFrame();
            if (currSpeed <= 0)
            {
                stopNoises?.Invoke(); 
                decelerating = false;
            }
            
        }


        private IEnumerator
            DecelerateBackwards() //for the car to continue to move backward once the player has let go of s
        {
            transform.Translate(Vector3.back * (currSpeed * Time.deltaTime));
            currSpeed -= decelerationSpeed * 2;
            yield return new WaitForEndOfFrame();
            if (currSpeed <= 0)
            {
                stopNoises?.Invoke();
                decelerating = false;
            }


        }
    }
}