using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarSelectController : MonoBehaviour
{
    //reference to the game manager
    //we need to "fill" this in when the scene starts
    //holds the sprite to be used by the player when in game
    GameManager manager;

	void Start ()
    {
        //find the game object with the tag GameController
        //In order to find this object you must start the game from main menu
        GameObject foundObject = GameObject.FindGameObjectWithTag("GameController");

        //get the GameManager script from the object we just found
        manager = foundObject.GetComponent<GameManager>();
	}

    //will be called by the buttons with car sprites assigned
    //each button holds the sprite the player wants to use as their car
    //when calling this, the button needs to pass itself as a parameter
    public void UpdateSelectedCar(Button selectedButton)
    {
        //get the Image component from the button (holds the sprite we want)
        Image buttonImage = selectedButton.GetComponent<Image>();
        //set the selectedCar variable on the GameManager (this is a sprite variable)
        manager.selectedCar = buttonImage.sprite;
        //load the game
        manager.LoadScene("Game");
    }
}
