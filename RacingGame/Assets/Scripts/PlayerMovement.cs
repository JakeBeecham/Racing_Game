using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed = 400;
    float currentSpeed; //the speed of the car that modifiers will be applied to

    public float rotationSpeed = 2; // speed which the car will turn at
    float h, v;

    Rigidbody2D body;

    float modifierLastsFor = 0;
    bool modifierActive = true;
    float elapsed = 0; // records time passed

    public string horizontalInputName = "Horizontal"; //required for 2 players
    public string verticalInputName = "Vertical"; //required for 2 players

	void Start ()
    {
        body = GetComponent<Rigidbody2D>();
        currentSpeed = movementSpeed;
	}
	
	void Update ()
    {
		//modifiers have a length that they are applied for
        if(modifierActive)
        {
            //when a modifier is active we need to track how much time is passing
            elapsed += Time.deltaTime;

            //if the time passed is greater than the modifiers length
            if(elapsed >= modifierLastsFor)
            {
                modifierActive = false; //turn off the modifier
                currentSpeed = movementSpeed; //reset
                elapsed = 0; //reset
            }
        }

        //get the input from the user
        h = Input.GetAxisRaw(horizontalInputName);
        v = Input.GetAxisRaw(verticalInputName);

        //use the horizontal inout to rotate the player
        //note the negative h value to make rotate in the correct direction
        transform.Rotate(0, 0, -h * rotationSpeed);
	}

    private void FixedUpdate()
    {
        //transform.up is the forward direction of the game object in 2D
        //move the object in the forward direction by the current speed
        body.velocity = transform.up * v * currentSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if we hit an object tagged as modifier
        if(collision.gameObject.CompareTag("Modifier"))
        {
            //get the SpeedModifier component from the object we hit
            SpeedModifier mod = collision.gameObject.GetComponent<SpeedModifier>();

            //set the current speed to be the original speed multipled by the modifier
            currentSpeed = movementSpeed * mod.modifier;

            //copy the data from the modifier into our own local variables
            //these are used in the Update
            modifierLastsFor = mod.lastFor;
            modifierActive = true;
            elapsed = 0;
        }
    }
}
