using System.Collections;
using SameDayDelivery.Controls;
using UnityEngine;
using UnityEngine.Events; 

namespace SameDayDelivery.VanControls
{
    public class CarControls : MonoBehaviour //THIS SCRIPT IS FOR THE CONTROLS WHILE THE PLAYER IS INSIDE THE VAN
    {
        [Header("References")]
        [SerializeField] private SameDayDelivery.ScriptableObjects.GameData data;
        [SerializeField] private SameDayDelivery.ScriptableObjects.UpgradeItem premiumGas;
        [SerializeField] private SameDayDelivery.ScriptableObjects.UpgradeItem freshTires;
        [Header("Van Speed")]
        public float topSpeed=25f; //the fastest speed that the van can move 
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

        [Header("Collisions")]
        RaycastHit hit;
        [SerializeField] private Transform frontBumper;
        [SerializeField] private Transform backBumper;
        public bool crashed;

        [Header("Events")]
        public UnityEvent motorStart; 
        public UnityEvent driving; 
        public UnityEvent reverse;
        public UnityEvent stopNoises;
        public UnityEvent crash; 


        // private variables
        private float defaultBrakeForce; 
        private bool chuteActive;
        private Vector2 _movement;
        private PlayerControlManager _playerControlManager;
        


        private void Awake()
        {
            _playerControlManager = GetComponent<PlayerControlManager>();
            overDriveSpeed = topSpeed * 2;
            defaultBrakeForce = brakeForce; 
            accelerating = false;
            chuteActive = false;
            packageChute.SetActive(false);
            upgradeAttachment();
            checkUpgradePurchaseValues();
        }

        private void FixedUpdate()//send out raycasts from the front and back of the van, if the van collides with a house then stop the car 
        {
            if (Physics.Raycast(frontBumper.position, transform.forward, out hit, 1f))
            {
                SameDayDelivery.DeliverySystem.Destinations house = hit.transform.GetComponentInParent<SameDayDelivery.DeliverySystem.Destinations>();
                if (house != null)
                {
                    currSpeed = 0;
                    if (!crashed)
                    {
                        crashed = true;
                        crash?.Invoke();
                    }
                }
                else crashed = false;
            }
            else crashed = false; 
           

            if (Physics.Raycast(backBumper.position, -transform.forward, out hit, 1f))
            {
                SameDayDelivery.DeliverySystem.Destinations house = hit.transform.GetComponentInParent<SameDayDelivery.DeliverySystem.Destinations>();
                if (house != null)
                {
                    currSpeed = 0;
                    if (!crashed)
                    {
                        crashed = true;
                        crash?.Invoke();
                    }
                }
                else crashed = false;
            }
            
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

        void upgradeAttachment()
        {
            premiumGas = data.upgradeLookupTable.upgrades[9];
            freshTires= data.upgradeLookupTable.upgrades[6];
        }

        void checkUpgradePurchaseValues()//checks if an upgrade is purchased, if so add its value to the default values. 
        {
            if (premiumGas.purchased) topSpeed = topSpeed+25;

        }

        //CONTROL INPUTS TO CONTROL THE PLAYER'S VEHICLE 
        private void Drive()
        {
            if (!overDrive) 
            {
                if (freshTires.purchased) rotationSpeed = currSpeed * 2;
                else rotationSpeed = currSpeed;
            }

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
            if (freshTires.purchased) rotationSpeed = currSpeed/5;
            else rotationSpeed = currSpeed/10;
            brakeForce = 0; 
        }

        private void decreaseGear() // if the player lets go of shift the top speed, rotation speed, and brake force return to normal 
        {
            overDrive = false;
            topSpeed = overDriveSpeed/2;
            if (freshTires.purchased) rotationSpeed = currSpeed * 2;
            else rotationSpeed = currSpeed;
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

        public IEnumerator Decelerate() //for the car to continue to move forward once the player has let go of w
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