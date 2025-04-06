using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour 
{
public Slider sliderTimer;
public Text timerText;
public float gameTime;
private bool stopTimer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       stopTimer = false; 
       sliderTimer.maxValue = gameTime;
       sliderTimer.value = gameTime;
    }

    // Update is called once per frame
    void Update()
    {
        float time = gameTime - Time.time;
        int minutes = Mathf.FloorToInt(time/60);
        int seconds = Mathf.FloorToInt(time - minutes * 60f);
        string textTime = string.Format("{0:0}:{1:00}", minutes, seconds);

        if(time <= 0){
            stopTimer = true;
        }
        if(stopTimer == false){
            timerText.text  = textTime;
            sliderTimer.value = time;
        }
    }
}
