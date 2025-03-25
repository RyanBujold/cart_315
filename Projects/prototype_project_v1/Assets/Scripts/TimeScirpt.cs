using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimeScirpt : MonoBehaviour
{
    // Used for help with timer formatting
    // https://discussions.unity.com/t/making-a-timer-00-00-minutes-and-seconds/14318

    private TMP_Text timerText;

    void Awake() {
        timerText = this.GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update() {

        // Convert the times into a minute, second format
        int goalMin = Mathf.FloorToInt(GameManager.S.GOAL_TIME / 60F);
        int goalSec = Mathf.FloorToInt(GameManager.S.GOAL_TIME - goalMin * 60);

        int timerMin = Mathf.FloorToInt(GameManager.S.Timer / 60F);
        int timerSec = Mathf.FloorToInt(GameManager.S.Timer - timerMin * 60);

        // Create a string for the time
        string timerString = string.Format("Goal:[{0:00}\"{1:00}]\nTime: [{2:00}\"{3:00}]", goalMin, goalSec, timerMin, timerSec);

        // Add the string to our ui text
        timerText.text = timerString;
    }
}
