using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace SameDayDelivery.VanControls
{
    public class VanController : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private SameDayDelivery.ScriptableObjects.GameData data;
        [SerializeField] private SameDayDelivery.ScriptableObjects.UpgradeItem premiumGas;
        [SerializeField] private SameDayDelivery.ScriptableObjects.UpgradeItem freshTires;
        public GameObject packageChute;
        private Rigidbody rb; 

        [Header("Inputs")] //Axes which the van drives on
        private const string HORIZONTAL = "Horizontal";
        private const string VERTICAL = "Vertical";
        float horizontalInput;
        float verticalInput;

        [Header("Driving Values")]
        public float currMotorForce; //currentSpeed 
        public float maxMotorForce; //maxSpeed
        public float topReverseForce; //the fastest speed that the van can move in Reverse
        public float overDriveSpeed; //how fast can the car move in OverDrive Mode
        public float currSteerAngle; //how fast can the van turn currently
        public float MaxSteerAngle;
        public float brakeForce; //how hard the car brakes
        public float currBrakeForce;
        public float maxXVelocity;
        public float maxZVelocity;
        public float maxVelo; 

        [Header("Acceleration")]
        public float accelerationSpeed; //the speed at which the car accelerates
        public float decelerationSpeed; //the speed at which the car decellerates
        public float decelerationMultiplier; //the speed at which the car's rigidbody decellerates Should be between (0 and 1)
        public bool accelerating; //check if the van's speed is increasing 
        public bool decelerating; //check if the van's speed is decreasing 

        [Header("Booleans")]
        public bool forwards;
        public bool backwards;
        public bool overDrive;
        public bool chuteActive = false;
        public bool crashed;
        public bool isBraking;

        [Header("Audio Events")] //Used to determine what sound should be played
        public UnityEvent motorStart;
        public UnityEvent driving;
        public UnityEvent reverse;
        public UnityEvent stopNoises;
        public UnityEvent crash;

    
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
            rb = GetComponent<Rigidbody>(); 
            accelerating = false;
            chuteActive = false;
            packageChute.SetActive(false);
            upgradeAttachment();
            checkUpgradePurchaseValues();
            overDriveSpeed = maxMotorForce * 2;
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
                // if (forwards) StartCoroutine(Decelerate());
           //        if (backwards) StartCoroutine(DecelerateBackwards());
            }
            else return;

            if (currMotorForce < 0f) currMotorForce = 0f;
        }
        void upgradeAttachment()//find the correct scriptable object for the upgrade references to grab and apply 
        {
            premiumGas = data.upgradeLookupTable.upgrades[9];
            freshTires = data.upgradeLookupTable.upgrades[6];
        }

        void checkUpgradePurchaseValues()//checks if an upgrade is purchased, if so add its value to the default values. 
        {
            if (premiumGas.purchased) maxMotorForce = maxMotorForce + 20;

        }
        #region DRIVING METHODS 
        void GetInput()
        {
            horizontalInput = Input.GetAxis(HORIZONTAL);
            verticalInput = Input.GetAxis(VERTICAL);
         
            if (Input.GetKey(KeyCode.W))//moving forwards 
            {
                Debug.Log("W pressed");
               // if (rb.velocity.magnitude <= 0) rb.velocity = 0.1f; 
                decelerating = false;
                forwards = true;
                backwards = false;
                StopCoroutine(Decelerate());
                driving?.Invoke();
            }
            isBraking = Input.GetKey(KeyCode.Space);

            if (Input.GetKey(KeyCode.S))//moving Backwards
            {
                Debug.Log("S pressed");
                decelerating = false;
                forwards = false;
                backwards = true;
                StopCoroutine(Decelerate());
                driving?.Invoke();
            }


            if (Input.GetKeyUp(KeyCode.W))//(Mathf.Approximately(_movement.y, 0f)) // if the player lets go of W begin decelerating. 
            {
                forwards = false;
                accelerating = false;
                decelerating = true;
            }

            if (Input.GetKeyUp(KeyCode.S))//(_movement.y < 0f) //if the player lets go of S begin decelerating Backwards
            {
                backwards = false; 
                accelerating = false;
                decelerating = true;
            }
            
        }
        
        void HandleMotor()
        {
            if (forwards) //Drive Forwards
            {
           
                if (rb.velocity.magnitude< Mathf.Abs(maxVelo)) accelerating = true;

                if (accelerating)//if the car is still accleration have the wheels motor torque increase until it reaches max
                {
                   frontLeftCollider.motorTorque = verticalInput * currMotorForce;
                    frontRightCollider.motorTorque = verticalInput * currMotorForce;
                    currMotorForce += accelerationSpeed;
                    rb.velocity *= 1.1f;

                    if (currMotorForce >= maxMotorForce)//once the motor torque reaches max level stop accelerating
                    {
                        accelerating = false;
                        currMotorForce = maxMotorForce;
                    }
                }
                else
                {
                    frontLeftCollider.motorTorque = verticalInput * maxMotorForce;
                    frontRightCollider.motorTorque = verticalInput * maxMotorForce;
                }



            }

            if(backwards)//move in reverse
            {
                if (currMotorForce < topReverseForce) accelerating = true;

                if (accelerating)//if the car is still accleration have the wheels motor torque increase until it reaches max
                {
                    frontLeftCollider.motorTorque = verticalInput * currMotorForce;
                    frontRightCollider.motorTorque = verticalInput * currMotorForce;
                    currMotorForce += accelerationSpeed;


                    if (currMotorForce >= topReverseForce)//once the motor torque reaches max level stop accelerating
                    {
                        accelerating = false;
                        currMotorForce = topReverseForce;
                    }
                }
                else
                {
                    frontLeftCollider.motorTorque = verticalInput *topReverseForce;
                    frontRightCollider.motorTorque = verticalInput * topReverseForce;
                }
            }

        }
        

        void ApplyBraking()
        {
            frontLeftCollider.brakeTorque = currBrakeForce;
            frontRightCollider.brakeTorque = currBrakeForce;
            backLeftCollider.brakeTorque = currBrakeForce;
            backRightCollider.brakeTorque = currBrakeForce;
        }

        void HandleSteering()
        {
            currSteerAngle = MaxSteerAngle * horizontalInput;
            frontLeftCollider.steerAngle = currSteerAngle;
            frontRightCollider.steerAngle = currSteerAngle;
        }

        void UpdateWheels()
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
        /*  
            public IEnumerator Decelerate() //for the car to continue to move forward once the player has let go of w
            {
                frontLeftCollider.motorTorque = currMotorForce;
                frontRightCollider.motorTorque = currMotorForce;
                currMotorForce -= decelerationSpeed;
                rb.velocity *= decelerationMultiplier;
                yield return new WaitForEndOfFrame();
                Debug.Log("Attempting to Decellerate");
                if(rb.velocity.x <=0.0f && rb.velocity.z <= 0.0f)
                {
                    stopNoises?.Invoke();
                    currMotorForce = 0f; 
                    decelerating = false;
                }
            }
        */
        public IEnumerator Decelerate() //for the car to continue to move forward once the player has let go of w
        {
            rb.velocity *= decelerationMultiplier;
            yield return new WaitForEndOfFrame();
            Debug.Log("Attempting to Decellerate");
            if (rb.velocity.magnitude <= 0.0f )
            {
                stopNoises?.Invoke();
                rb.velocity = rb.velocity.normalized * 0; 
                decelerating = false;
            }
        }
    }
}
