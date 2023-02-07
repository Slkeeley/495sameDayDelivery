using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarControls : MonoBehaviour //THIS SCRIPT IS FOR THE CONTROLS WHILE THE PLAYER IS INSIDE THE VAN
{
    
    [Header("Van Speed")]
    public float topSpeed;//the fastest speed that the van can move 
    public float topReverseSpeed;//the fastest speed that the van can move 
    public float currSpeed=0;//the current speed the van is moving
    public float rotationSpeed = 100.0f;
    [Header("Acceleration")]
    public float accelerationSpeed; //the speed at which the car accelerates
    public float reverseAccelerationSpeed; //the speed at which the car accelerates
    public float decellerationSpeed; //the speed at which the car decellerates
    public bool accelerating = false; //check if the van's speed is increasing 
    public bool decellerating = false; //check if the van's speed is decreasing 

    [Header("Other Vars")]
    public bool forwards = false;
    public bool backwards = false;
    public float brakeForce;
    public float currentTurnAngle; 
    public float maxTurnAngle;
    Rigidbody rb; 
    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody>(); 
    }
    void Start()
    {
        accelerating = false;
    }

    // Update is called once per frame
    void Update()
    {
        drive();
        if(decellerating)
        {
            if(forwards) StartCoroutine(decellerate());
            if(backwards) StartCoroutine(decellerateBackwards());

        }
    }


    //CONTROL INPUTS TO CONTROL THE PLAYER'S VEHICLE 
         void drive()
      {
            rotationSpeed = currSpeed;

            float rotation = Input.GetAxis("Horizontal") * rotationSpeed;
            rotation *= Time.deltaTime;
            rotation = Mathf.Clamp(rotation, -45, 45);
            transform.Rotate(0, rotation, 0);
          
        //if the player presses W move forward in the direction they face
        if (Input.GetKey(KeyCode.W))
          {
             //Adjust these booleans when the player begins moving forward again
              decellerating = false;
              forwards = true;
              backwards = false; 
              StopCoroutine(decellerate());


              if (currSpeed < topSpeed) accelerating = true; 

              if (accelerating)//if the vans current speed is lower than the top speed have it speed up until it reaches the top speed. 
              { 
                  float translation = Input.GetAxis("Vertical") * currSpeed;
                  currSpeed += accelerationSpeed; 
                  translation *= Time.deltaTime;
                  transform.Translate(0, 0, translation);

                if (currSpeed>=topSpeed)
                  {
                      accelerating = false;
                      currSpeed = topSpeed;
                  }
              }
              else// if the van reaches top speed it is no longer accelerating and have it move at top speed 
              { 
                  float translation = Input.GetAxis("Vertical") * topSpeed;
                  translation *= Time.deltaTime;
                  transform.Translate(0, 0, translation);
              }
          }

          if (Input.GetKeyUp(KeyCode.W))  //if the player lets go of W begin decellerating 
          {
              accelerating = false; 
              decellerating = true;
        }



        //If the player presess S move backward on their relative z axis
        if (Input.GetKey(KeyCode.S))
        {
            //Adjust these booleans when the player begins moving forward again
            if (forwards)
            {
                applyBrakes();
            }
            else
            {
                if (currSpeed < topReverseSpeed) accelerating = true;

                if (accelerating)//if the vans current speed is lower than the top speed have it speed up until it reaches the top speed. 
                {
                    float translation = Input.GetAxis("Vertical") * currSpeed;
                    currSpeed += reverseAccelerationSpeed;
                    translation *= Time.deltaTime;
                    transform.Translate(0, 0, translation);
                    if (currSpeed >= topReverseSpeed)
                    {
                        accelerating = false;
                        currSpeed = topReverseSpeed;
                    }
                }
                else// if the van reaches top speed it is no longer accelerating and have it move at top speed 
                {
                    float translation = Input.GetAxis("Vertical") * topReverseSpeed;
                    translation *= Time.deltaTime;
                    transform.Translate(0, 0, translation);
                }
            }

        }
        if (Input.GetKeyUp(KeyCode.S))  //if the player lets go of S begin decellerating Backwards
        {
            accelerating = false;
            decellerating = true;
        }
    }
  

    /*
    void checkForBrakes()//check if the plaeyr presses spacebar to forcefully slow the car down
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (currSpeed > 0)
            {
                currSpeed = currSpeed - 0.03f;
            }
        }

    }*/
    void applyBrakes()//if the player is moving forward and presses S apply the brakes firs
    {
            if (currSpeed > 0)
            {
                currSpeed -= brakeForce; //speed is reduced by the set brake force
            }
            else
            {
            decellerating = false;
            forwards = false;
            backwards = true;
            StopCoroutine(decellerate());
        }
    }
    public IEnumerator decellerate()//for the car to continue to move forward once the player has let go of w
    {       
        transform.Translate(Vector3.forward *currSpeed*  Time.deltaTime);
        currSpeed -= decellerationSpeed;
        yield return new WaitForEndOfFrame();
        if (currSpeed <= 0) decellerating = false;
    }
  

    public IEnumerator decellerateBackwards()//for the car to continue to move backward once the player has let go of s
    {
        transform.Translate(Vector3.back * currSpeed * Time.deltaTime);
        currSpeed -= (decellerationSpeed*2);
        yield return new WaitForEndOfFrame();
        if (currSpeed <= 0) decellerating = false;
    }
}
