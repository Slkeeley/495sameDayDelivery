using System.Collections;
using System.Collections.Generic;
using SameDayDelivery.Controls;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem; 

namespace SameDayDelivery.VanControls
{
    public class VanController : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private SameDayDelivery.ScriptableObjects.GameData data;
        [SerializeField] private SameDayDelivery.ScriptableObjects.UpgradeItem premiumGas; //ChANGE THE MAX VELO VALUE
        [SerializeField] private SameDayDelivery.ScriptableObjects.UpgradeItem freshTires;//CHANGE THE MAX STEER ANGLE
        public GameObject packageChute;
        //private VARS 
        public Rigidbody rb;
        private SameDayDelivery.Controls.PlayerControlManager _playerControlManager;
        Vector2 _movement;


        [Header("Driving Values")]
        public float currMotorForce; //currentSpeed of the wheels
        public float maxMotorForce; //maxSpeed of the wheels 
        public float currSteerAngle; //how fast can the van turn currently
        public float MaxSteerAngle;
        public float brakeForce; //how hard the car brakes    
        public float maxVelo; 
        public float maxReverseVelo;

        [Header("Acceleration")]
        public float accelerationSpeed; //the speed at which the car accelerates
        public float decelerationSpeed; //the speed at which the car decellerates
        public float decelerationMultiplier; //the speed at which the car's rigidbody decellerates Should be between (0 and 1)
        public bool accelerating; //check if the van's speed is increasing 
        public bool decelerating; //check if the van's speed is decreasing 


        [Header("Multipliers")]
        //OVERDRIVE VARS
        private float overDriveForce; //maxSpeed of the wheels
        private float overDriveSpeed; //how fast can the car move in OverDrive Mode
        private float defaultBrakeForce; //used to reset brake force after car stops being in over drive
        public float steerAnglePenalty;//how slow does the car turn while holding down shift 
        public float overDriveMultiplier;//how much is the speed of the car changed when holding donw shift
        //UPGRADE MULTIPLIERS;
        public float speedUpgradeMult;
        public float turnUpgradeMult; 

        [Header("Booleans")]
        public bool forwards;
        public bool backwards;
        public bool overDrive;
        public bool chuteActive = false;

        [Header("Audio Events")] //Used to determine what sound should be played
        public UnityEvent motorStart;
        public UnityEvent driving;
        public UnityEvent reverse;
        public UnityEvent stopNoises;
        public UnityEvent crash;
        public UnityEvent sheldonReaction;

    
        [Header("Wheels")]
        //Colliders
        [SerializeField] private WheelCollider frontLeftCollider;
        [SerializeField] private WheelCollider frontRightCollider;
        [SerializeField] private WheelCollider backLeftCollider;
        [SerializeField] private WheelCollider backRightCollider;
        //Transforms 
        [SerializeField] private Transform frontLeftColliderTransform;
        [SerializeField] private Transform frontRightColliderTransform;
        [SerializeField] private Transform backLeftColliderTransform;
        [SerializeField] private Transform backRightColliderTransform;



        private void Awake()
        {
            _playerControlManager = GetComponent<SameDayDelivery.Controls.PlayerControlManager>();
            _movement = _playerControlManager.move; 
            rb = GetComponent<Rigidbody>(); 
            accelerating = false;
            chuteActive = false;
            packageChute.SetActive(false);
            upgradeAttachment();
            checkUpgradePurchaseValues();
            //overDriveValues
            overDriveSpeed = maxVelo *overDriveMultiplier;
            overDriveForce = maxMotorForce * overDriveMultiplier;
            defaultBrakeForce = brakeForce;
            steerAnglePenalty = 3; 
        }



        private void FixedUpdate()//Every Physics update grab the inputs and how fast the car is moving
        {
            GetInput();
            HandleMotor();
            HandleSteering();
            UpdateWheels();
            
            if (decelerating)
            {
                StartCoroutine(Decelerate());
            }
            else return;
        }
        private void LateUpdate()
        {
            if (currMotorForce > maxMotorForce) currMotorForce = maxMotorForce;
            if (currMotorForce < 0) currMotorForce = 0f; 
        }
        #region UPGRADE REFERENCING
        void upgradeAttachment()//find the correct scriptable object for the upgrade references to grab and apply 
        {
            premiumGas = data.upgradeLookupTable.upgrades[9];
            freshTires = data.upgradeLookupTable.upgrades[6];
        }

        void checkUpgradePurchaseValues()//checks if an upgrade is purchased, if so add its value to the default values. 
        {
            if (premiumGas.purchased)//if premium gas is purchased increase both the max speed and acceleration rate of the car
            {
                maxVelo = maxVelo * speedUpgradeMult;
                maxReverseVelo = maxReverseVelo * speedUpgradeMult; 
                accelerationSpeed = accelerationSpeed * speedUpgradeMult; 
            }
            if(freshTires.purchased)//if fresh tires is purchased change the max steering angle of the car
            {
                MaxSteerAngle = MaxSteerAngle * turnUpgradeMult; 
            }

        }
        #endregion

        #region DRIVING METHODS 
        void GetInput()
        {
            if (_movement.y > 0f)//moving forwards 
            {
                decelerating = false;
                forwards = true;
                backwards = false;
                StopCoroutine(Decelerate());           
            }
      
            if (_movement.y < 0f)//moving Backwards
            {
                if(forwards)
                {
                    ApplyBraking();
                    return; 
                }
                decelerating = false;
                forwards = false;
                backwards = true;
                StopCoroutine(Decelerate());
            }

            if (Mathf.Approximately(_movement.y, 0.0f))// if the player lets go of W begin decelerating. 
            {
                forwards = false;
                backwards = false;
                accelerating = false;
                decelerating = true;
            }

        }
        
         void HandleMotor()
        {

            if (forwards) //Drive Forwards
            {
                driving?.Invoke();
                if (rb.velocity.magnitude < maxVelo) accelerating = true;

                if (accelerating)//if the car is still accleration have the wheels motor torque increase until it reaches max
                {
                    frontLeftCollider.motorTorque = _movement.y * currMotorForce;
                    frontRightCollider.motorTorque = _movement.y * currMotorForce;
                    currMotorForce += accelerationSpeed;

                    if (rb.velocity.magnitude >= maxVelo)//once the motor torque reaches max level stop accelerating
                    { 
                        accelerating = false;
                        currMotorForce = maxMotorForce;
                        rb.velocity = rb.velocity.normalized * maxVelo; 
                    }
                }
                else
                {

                    frontLeftCollider.motorTorque = _movement.y * maxMotorForce;
                    frontRightCollider.motorTorque = _movement.y * maxMotorForce;
                    rb.velocity = rb.velocity.normalized * maxVelo;
                }
            }

            if (backwards) //Drive backwards
            {
                reverse?.Invoke(); 
                if (rb.velocity.magnitude < maxReverseVelo) accelerating = true;

                if (accelerating)//if the car is still accleration have the wheels motor torque increase until it reaches max
                {
                    frontLeftCollider.motorTorque = _movement.y * currMotorForce;
                    frontRightCollider.motorTorque = _movement.y * currMotorForce;
                    currMotorForce += accelerationSpeed;

                    if (rb.velocity.magnitude >= maxReverseVelo)//once the motor torque reaches max level stop accelerating
                    {
                        accelerating = false;
                        currMotorForce = maxMotorForce;
                        rb.velocity = rb.velocity.normalized * maxReverseVelo;
                    }
                }
                else
                {
                    frontLeftCollider.motorTorque = _movement.y * maxMotorForce;
                    frontRightCollider.motorTorque = _movement.y * maxMotorForce;
                    rb.velocity = rb.velocity.normalized * maxReverseVelo;
                }
            }

        }
         void ApplyBraking()
        {
            if (Mathf.Approximately(rb.velocity.magnitude, 0.0f))
            {
                forwards = false;
                stopNoises?.Invoke();
                currMotorForce = 1; 
                return;
            }
            frontLeftCollider.brakeTorque = brakeForce;
            frontRightCollider.brakeTorque = brakeForce;
            backLeftCollider.brakeTorque = brakeForce;
            backRightCollider.brakeTorque = brakeForce;
        }

        void HandleSteering()
        {
            if (overDrive)
            {
                currSteerAngle = (MaxSteerAngle / steerAnglePenalty) * _movement.x;
                frontLeftCollider.steerAngle = currSteerAngle;
                frontRightCollider.steerAngle = currSteerAngle;
            }
            else
            {
                currSteerAngle = MaxSteerAngle * _movement.x;
                frontLeftCollider.steerAngle = currSteerAngle;
                frontRightCollider.steerAngle = currSteerAngle;
            }
        }

        void UpdateWheels()//turn and position the wheel colliders based on their transforms
        {
            updateSingleWheel(frontLeftCollider, frontLeftColliderTransform);
            updateSingleWheel(frontRightCollider, frontRightColliderTransform);
            updateSingleWheel(backLeftCollider, backLeftColliderTransform);
            updateSingleWheel(backRightCollider, backRightColliderTransform);
        }

        void updateSingleWheel(WheelCollider collider, Transform transform)
        {
            Vector3 Pos;
            Quaternion Rot;
            collider.GetWorldPose(out Pos, out Rot);
            transform.rotation = Rot;
            transform.position = Pos;
        }

        public IEnumerator Decelerate() //for the car to continue to move forward once the player has let go of w
        {
            rb.velocity *= decelerationMultiplier;
            frontLeftCollider.motorTorque = currMotorForce;
            frontRightCollider.motorTorque = currMotorForce;
            currMotorForce -= decelerationSpeed;
            yield return new WaitForEndOfFrame();
            if (rb.velocity.magnitude < 0.1f)
            {
                stopNoises?.Invoke();
                rb.velocity = Vector3.zero;
                currMotorForce = 0;
                decelerating = false;
            }
            
        }
        #endregion
        public void ChuteActivation() //If the player is within the correct area to drop the packages turn the shoot on if they leave turn int off. 
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

        #region INPUTS
        public void OnMove(InputAction.CallbackContext context)//forwards and reverse movement
        {
            if(context.performed)
            {
                _movement = context.ReadValue<Vector2>(); 
            }

            if(!context.performed)
            {
                _movement = Vector2.zero; 
            }
        }

        public void OnShift(InputAction.CallbackContext context)//pressing shfit for overdrive movement
        {
            if (context.performed)
            {
                _playerControlManager.sprinting = true;
                increaseGear(); 

            }

            if (!context.performed)
            {
                _playerControlManager.sprinting = false;
                decreaseGear(); 
            }
        }
        private void increaseGear() // if the player is holding shift, the van's top speed increases
        {
            overDrive = true;
            maxVelo = overDriveSpeed;
            maxMotorForce = overDriveForce; 
            brakeForce = 0;
        }

        private void decreaseGear() // if the player lets go of shift the top speed, rotation speed, and brake force return to normal 
        {
            overDrive = false;
            maxVelo = overDriveSpeed / 2; 
            maxMotorForce = overDriveForce/1.5f;
            brakeForce = defaultBrakeForce;
        }
        #endregion

        private void OnTriggerEnter(Collider other)
        {
            if(other.tag=="MailBox")
            {
                other.GetComponent<Rigidbody>().useGravity = true; 
                other.GetComponent<BoxCollider>().isTrigger= false; 
            }
        }
        private void OnCollisionEnter(Collision collision)
        {
            if(collision.gameObject.layer == 8)
            {
                sheldonReaction?.Invoke();
                crash?.Invoke();
       
            }
        }
    }

    
}
