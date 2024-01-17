using UnityEngine;
using UnityEngine.UI;

public class TIMECONT : MonoBehaviour
{

    public Text timerText; 

   
    private float timer;
    private bool isTimerRunning;

    private void Start()
    {


        timer = 0f;
        isTimerRunning = true;

        if (timerText == null)
        {
            Debug.LogError("TimerText is not assigned! Assign a Text component in the Unity Editor.");
        }
        else
        {
            timerText.text = "Time: " + FormatTime(timer);
        }
    }

    private void Update()
    {
        if (isTimerRunning)
        {
            timer += Time.deltaTime;
            UpdateTimerText();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
    
        isTimerRunning = false;
    }

    private void UpdateTimerText()
    {
        timerText.text = "Time: " + FormatTime(timer);
    }

    private string FormatTime(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60F);
        int seconds = Mathf.FloorToInt(time % 60);
        return string.Format("{0:0}:{1:00}", minutes, seconds);
    }
}