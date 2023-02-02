using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarControls : MonoBehaviour //THIS SCRIPT IS FOR THE CONTROLS WHILE THE PLAYER IS INSIDE THE VAN
{
    public float topSpeed;//the fastest speed that the van can move 
    public float currSpeed=1;//the current speed the van is moving
    public float rotationSpeed = 100.0f;
    public bool accelerating = false; //check if the van's speed is increating 
    

    // Start is called before the first frame update
    void Start()
    {
        accelerating = false;
    }

    // Update is called once per frame
    void Update()
    {
        drive(); 
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
        if(Input.GetKey(KeyCode.W))//if the player presses W move forward in the direction they face
        {
            if (currSpeed < topSpeed) accelerating = true; 

            if (accelerating)//if the vans current speed is lower than the top speed have it speed up until it reaches the top speed. 
            { 
                float translation = Input.GetAxis("Vertical") * currSpeed;
                Debug.Log("trying to accelerate");
                currSpeed += 0.05f; 
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
    }
}
