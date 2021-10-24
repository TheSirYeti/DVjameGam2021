using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    public float timer;
    public Text timeText;
    
    private void Update()
    {
        ClockTimer();
    }

    public void ClockTimer()
    {
        int minutes = Mathf.FloorToInt(timer / 60F);
        int seconds = Mathf.FloorToInt(timer - minutes * 60);
        timeText.text = string.Format("{0:0}:{1:00}", minutes, seconds);
        timer -= Time.fixedDeltaTime;
    }
}
