using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System; //Bruges til TimeSpan
using UnityEngine.SceneManagement;

public class TimeCountdown : MonoBehaviour
{
    protected LevelOptions levelParameters;
    public TMP_Text timeLeftTxt;
    float timeLeft;
    bool isActive = true;

    
    // Start is called before the first frame update
    void Awake()
    {/*
        GameObject timer = GameObject.Find("GameGenerator");
        LevelOptions leveloptions = timer.GetComponent<LevelOptions> ();
        */

        timeLeft = levelParameters.totalMinutes*60;
        //timeLeft = levelParameters.totalMinutes * 60;
    }

    // Update is called once per frame
    void Update()
    {
        if (isActive)
        {
            timeLeft = timeLeft -Time.deltaTime;
            if (timeLeft <= 0)
            {
                isActive = false;
                SceneManager.LoadScene("Menu");
            }
        }

        TimeSpan timeConvert = TimeSpan.FromSeconds(timeLeft);
        timeLeftTxt.text = timeConvert.Minutes.ToString() + ":" + timeConvert.Seconds.ToString(); //Sørger for at tid bliver vist i min og sec
    }

    public void TimerStart()
    {
        isActive = true;
    }

    public void TimerStop()
    {
        isActive = false;
    }
}
