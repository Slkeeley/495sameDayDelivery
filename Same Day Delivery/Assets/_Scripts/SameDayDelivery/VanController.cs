using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VanController : MonoBehaviour
{
    private const string HORIZONTAL = "Horizontal";
    private const string VERTICAL = "Vertical";
    
    float horizontalInput; 
    float verticalInput;

    public float motorForce;
    public float currSteerAngle; 
    public float MaxSteerAngle; 


    public float brakeForce; 
    public float currBrakeForce; 
    public bool isBraking; 
    [SerializeField] private WheelCollider frontLeftCollider;
    [SerializeField] private WheelCollider frontRightCollider;
    [SerializeField] private WheelCollider backLeftCollider;
    [SerializeField] private WheelCollider backRightCollider;

    [SerializeField] private Transform frontLeftColliderTransform;
    [SerializeField] private Transform frontRightColliderTransform;
    [SerializeField] private Transform backLeftColliderTransform;
    [SerializeField] private Transform backRightColliderTransform;

    public GameObject packageChute;
    bool chuteActive = false; 

    private void FixedUpdate()
    {
        GetInput();
        HandleMotor();
        HandleSteering();
        UpdateWheels();
    }

    void GetInput()
    {
        horizontalInput = Input.GetAxis(HORIZONTAL); 
        verticalInput = Input.GetAxis(VERTICAL);
        isBraking = Input.GetKey(KeyCode.Space);
    }

    void HandleMotor()
    {
        frontLeftCollider.motorTorque = verticalInput * motorForce; 
        frontRightCollider.motorTorque = verticalInput * motorForce;
        currBrakeForce = isBraking ? brakeForce : 0f; 
        if(isBraking)
        {
            ApplyBraking();
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

    public void  ChuteActivation() //If the player is within the correct area to drop the packages turn the shoot on if they leave turn int off. 
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
}
