using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public enum Cycle
{
    Day,
    Night
}
public enum Passage 
{
    AM,
    PM
}

public class TimeManager : MonoBehaviour
{
    public TextMeshProUGUI AmPmSpot;

    int days;
    public TextMeshProUGUI daySpot;

    [Range(0, 10)]
    int minutes;
    public TextMeshProUGUI minuteSpot;

    [Range(0,60)]
    int seconds;
    public TextMeshProUGUI secondsSpot;

    public float timer;

    [Range(1, 100)]
    public int timeRate = 2;

    public Cycle timeCycle = Cycle.Day;
    public Passage timePassage = Passage.AM; 

    void Update()
    {
        Time.timeScale = timeRate;
        timer += Time.deltaTime;

        minutes = Mathf.RoundToInt(timer) / 60;
        seconds = Mathf.RoundToInt(timer) - (minutes * 60);
        if (minutes >= 10)
        {
            days += 1;
            timer -= 600;
        }

        updateDisplay();
        UpdateIndicators();
    }

    void updateDisplay() 
    {
        secondsSpot.text = seconds.ToString();
        minuteSpot.text = minutes.ToString();
        daySpot.text = "Day: " + days.ToString();
        if (timePassage == Passage.AM)
        {
            AmPmSpot.text = "AM";
        }
        else if (timePassage == Passage.PM)
        {
            AmPmSpot.text = "PM";
        }
    }

    void UpdateIndicators() 
    {
        if (minutes <= 7)
        {
            timeCycle = Cycle.Day;
        }
        else
        {
            timeCycle = Cycle.Night;
        }

        if (minutes == 0)
        {
            timePassage = Passage.AM;
        }
        if (minutes == 1)
        {
            timePassage = Passage.AM;
        }
        if (minutes == 2)
        {
            timePassage = Passage.AM;
        }
        if (minutes == 3)
        {
            timePassage = Passage.AM;
        }
        if (minutes == 4)
        {
            timePassage = Passage.AM;
        }
        if (minutes == 5)
        {
            timePassage = Passage.AM;
        }
        if (minutes == 6)
        {
            timePassage = Passage.PM;
        }
        if (minutes == 7)
        {
            timePassage = Passage.PM;
        }
        if (minutes == 8)
        {
            timePassage = Passage.PM;
        }
        if (minutes == 9) 
        {
            timePassage = Passage.PM;
        }
    }
}
