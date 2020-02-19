using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //will hold the sprite for the car selected by the player
    public Sprite selectedCar;

	void Start ()
    {
        //makes this object persistent
        //this object will be created once and transferred into every scene
        DontDestroyOnLoad(this);
	}
	
    //will be called by the btnQuit on the main menu
    public void QuitGame()
    {
        Application.Quit();
    }

    //will be called by the btnPlay and btnMulti on the main menu
    public void LoadScene(string sceneName)
    {
        //load the scene with the name passed in (sceneName)
        SceneManager.LoadScene(sceneName);
    }
}
