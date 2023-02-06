using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelControls : MonoBehaviour
{
    Rigidbody rb; 
    
    [SerializeField] WheelCollider frontRight;
    [SerializeField] WheelCollider frontLeft;
    [SerializeField] WheelCollider backRight;
    [SerializeField] WheelCollider backLeft;

    public float acceleration;
    public float brakeForce;
    public float currentAcceleration;
    public float currentBrakeForce;
    public float maxTurnAngle = 15; 
    public float currentTurnAngle;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>(); 
    }
    private void FixedUpdate()
    {
        forwardReverse(); 
        checkForBraking();
        
        frontRight.motorTorque = currentAcceleration*2;
        frontLeft.motorTorque = currentAcceleration*2;

        frontRight.brakeTorque = currentBrakeForce;
        frontLeft.brakeTorque = currentBrakeForce;
        backRight.brakeTorque = currentBrakeForce;
        backLeft.brakeTorque = currentBrakeForce;

        currentTurnAngle = maxTurnAngle * Input.GetAxis("Horizontal");
        frontLeft.steerAngle = currentTurnAngle; 
        frontRight.steerAngle = currentTurnAngle; 
    }

    void checkForBraking()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            currentBrakeForce = brakeForce;
        }
        else
        {
            currentBrakeForce = 0;
        }

    }

    void forwardReverse()
    {
        currentAcceleration = acceleration * Input.GetAxis("Vertical");
  
    }
}
