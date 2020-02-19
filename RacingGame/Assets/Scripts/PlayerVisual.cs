using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVisual : MonoBehaviour
{
	void Start ()
    {
        //find the GameController game object
        GameObject foundObject = GameObject.FindGameObjectWithTag("GameController");

        //if the GameController has been found
        if(foundObject != null)
        {
            //get the GameManager script
            GameManager manager = foundObject.GetComponent<GameManager>();
            //get the sprite renderer of the player
            SpriteRenderer renderer = GetComponent<SpriteRenderer>();

            //set the sprite of the player to be sprite stored in the game manager
            //remember this is the sprite we picked in the carselect scene
            renderer.sprite = manager.selectedCar;
        }
	}
}
