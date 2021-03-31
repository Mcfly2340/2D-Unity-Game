using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    float timer;
    float milliseconds;
    float millisecondsTimer;
    float seconds;
    float minutes;

    [SerializeField] Text stopWatchText;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        millisecondsTimer = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       
        if (milliseconds > 97.999f)
        {
            millisecondsTimer = 0;
            millisecondsTimer += Time.deltaTime;
            Debug.Log("1 second up!");
        }
        if (seconds == 60)
        {
            minutes += 1;
            millisecondsTimer += Time.deltaTime;
        }
        
        timer += Time.deltaTime;
        millisecondsTimer += Time.deltaTime;
        milliseconds = (millisecondsTimer * 100);
        seconds = (int)(timer % 60);
        minutes = (int)((timer / 60) % 60);

        stopWatchText.text = "Timer: " + minutes.ToString("00") + ":" + seconds.ToString("00") + ":" + milliseconds.ToString("00");
    }
}
