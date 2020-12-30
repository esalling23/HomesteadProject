using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Experimental.Rendering.Universal;

public class GameManager : MonoBehaviour
{
    // Private variables
    // 
    // day-night cycle
    private int dayLength;   //in minutes
    private int dayStart;
    private int nightStart;
    private int currentDay;
    private bool isDay;
    private Light2D sun;
    private Text timeDisplay;
    // Player
    private Component player;

    // Public variables
    //
    // day-night cycle
    public int cycleSpeed;
    public int timeSkip;
    public int currentTime = 720;

    // Start is called before the first frame update
    void Start()
    {
        dayLength = 1440;
        dayStart = 300;
        nightStart = 1200;
        currentDay = 1;
        sun = GameObject.Find("Sun").GetComponent<Light2D>();
        timeDisplay = GameObject.Find("UI/Canvas/TimeDisplay/Text").GetComponent<Text>();
        StartCoroutine(TimeOfDay());
    }


    // Update is called once per frame
    void Update()
    {
        // Day-Night Cycle
        if (currentTime > 0 && currentTime < dayStart) {
            isDay = false;
            sun.intensity = 0;
        } else if (currentTime >= dayStart && currentTime < nightStart) {
            isDay = true;
            sun.intensity = 1;
        } else if (currentTime >= nightStart && currentTime < dayLength) {
            isDay = false;
            sun.intensity = 0;
        } else if (currentTime >= dayLength) {
            currentTime = 0;
        }

    }

    // TimeOfDay taken from this forum:
    // https://answers.unity.com/questions/983470/unity-2d-daynight.html
    IEnumerator TimeOfDay() {
        while (true) {
            currentTime += timeSkip;
            int hours = Mathf.RoundToInt(currentTime / 60);
            int minutes = currentTime % 60;
            Debug.Log(FormatTime(hours, minutes));

            // Display current time
            timeDisplay.text = FormatTime(hours, minutes);

            yield return new WaitForSeconds(1F/cycleSpeed);
        }
    }

    // Accepts int hours & minutes
    // Returns string representation ex: 1:05
    private string FormatTime(int hours, int minutes) 
    {
        string hoursStr = hours.ToString();
        string minutesStr = minutes.ToString();
        string period = "AM";

        // Handles 0 hours being 12 AM
        // Handles 12 hours being 
        if (hours == 0) 
        {
            hoursStr = "12";
        } 
        // Handles prepending 0 before hours 1-9
        else if (hours < 10) 
        {
            hoursStr = "0" + hoursStr;
        } 
        // Handles afternoons when we're after 12 hours
        else if (hours >= 12) 
        {
            period = "PM";
            int realHours = hours == 12 ? hours : hours % 12;
            hoursStr = realHours.ToString();
        } 

        // Handles prepending 0 before minutes 1 - 9
        if (minutes < 10)
        {
            minutesStr = "0" + minutesStr;
        }

        return hoursStr + ":" + minutesStr + " " + period;
    }
}
