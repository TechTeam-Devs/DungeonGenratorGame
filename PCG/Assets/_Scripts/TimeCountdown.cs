using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System; //Bruges til TimeSpan
using UnityEngine.SceneManagement;

public class TimeCountdown : MonoBehaviour
{
    //protected LevelOptions levelParameters;
    public TMP_Text timeLeftTxt;
    float timeLeft;
    float spawnTimer = 0f;
    float repeatTime = 1f;
    bool isActive = true;

    [SerializeField]
    private float totalMinutes;

    
    // Start is called before the first frame update
    void Awake()
    {
        timeLeft = totalMinutes * 60;
    }

    // Update is called once per frame
    void Update()
    {
      
        if (isActive)
        { 

        timeLeft = timeLeft -Time.deltaTime;

        spawnTimer += Time.deltaTime;
        if (spawnTimer >= repeatTime)
        {
            ObjectHandler.SpawnRandomBlocks();
            spawnTimer -= repeatTime;
           
        }

        if (timeLeft <= 0)
            {
                isActive = false;
                SceneManager.LoadScene("Menu");
            }

        TimeSpan timeConvert = TimeSpan.FromSeconds(timeLeft);
        timeLeftTxt.text = timeConvert.Minutes.ToString() + ":" + timeConvert.Seconds.ToString(); //S�rger for at tid bliver vist i min og sec
        }
    }

    public void TimerStart()
    {
        isActive = true;
    }

    public void TimerStop(bool gameWon)
    {
        isActive = false;
        if (gameWon)
        {
            timeLeftTxt.color = Color.green;
        }
        else
        {
            timeLeftTxt.color = Color.red;
        }
        
    }
}
