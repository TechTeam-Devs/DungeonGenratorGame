using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EventHandler : MonoBehaviour
{
    
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("Vrikerkrkerkf");
        if (collider.CompareTag("Player"))
            {
               
      Debug.Log("Afslutter");
            ExitGame();
        }
    }

    private void ExitGame()
    {
        SceneManager.LoadScene("Menu");
       // SceneManager.UnloadScene("SampleScene");
    }
}
