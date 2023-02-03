using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarControls : MonoBehaviour //THIS SCRIPT IS FOR THE CONTROLS WHILE THE PLAYER IS INSIDE THE VAN
{
    public float topSpeed;//the fastest speed that the van can move 
    public float currSpeed=0;//the current speed the van is moving
    public float rotationSpeed = 100.0f;
    public bool accelerating = false; //check if the van's speed is increasing 
    public bool decellerating = false; //check if the van's speed is decreasing 
    public float accelerationSpeed; //the speed at which the car accelerates
    public float decellerationSpeed; //the speed at which the car decellerates

    // Start is called before the first frame update
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
            StartCoroutine(decellerate());
        }
    }

    void drive()
    {
        /*  if (!accelerating)
          {

              float translation = Input.GetAxis("Vertical") * topSpeed;
              float rotation = Input.GetAxis("Horizontal") * rotationSpeed;

              translation *= Time.deltaTime;
              rotation *= Time.deltaTime;

              transform.Translate(0, 0, translation);

              transform.Rotate(0, rotation, 0);
          }*/
        //if the player presses W move forward in the direction they face
        if (Input.GetKey(KeyCode.W))
        {
            decellerating = false;
            StopCoroutine(decellerate());
            if (currSpeed < topSpeed) accelerating = true; 

            if (accelerating)//if the vans current speed is lower than the top speed have it speed up until it reaches the top speed. 
            { 
                float translation = Input.GetAxis("Vertical") * currSpeed;
                currSpeed += accelerationSpeed; 
                translation *= Time.deltaTime;
                transform.Translate(0, 0, translation);
                if(currSpeed>=topSpeed)
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
        //if the player lets go of W begin decellerating 

        if (Input.GetKeyUp(KeyCode.W))
        {
            accelerating = false; 
            decellerating = true;
        }
    }

    public IEnumerator decellerate()
    {

        transform.position += Vector3.forward * currSpeed* Time.deltaTime;
        currSpeed -= decellerationSpeed;
        yield return new WaitForEndOfFrame();
        if (currSpeed <= 0) decellerating = false;
    }
}
