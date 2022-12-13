using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //Unity library that allows us to manipulate with scenes

public class mainMenuHandler : MonoBehaviour
{
    public void startGameEasy()
    {
        SceneManager.LoadScene("SceneEasy"); //Loads our scene, "SampleScene" when this methods gets called
    }
    public void startGameMedium()
    {
        SceneManager.LoadScene("SceneMedium"); //Loads our scene, "SampleScene" when this methods gets called
    }
    public void startGameNightmare()
    {
        SceneManager.LoadScene("SceneNightmare"); //Loads our scene, "SampleScene" when this methods gets called
    }

    public void exitGame()
    {
        Application.Quit();
        Debug.Log("Game has been exited (doesn't work in Unity editor mode");
    }
}
