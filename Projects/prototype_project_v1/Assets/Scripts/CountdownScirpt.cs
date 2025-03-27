using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CountdownScirpt : MonoBehaviour
{
    private TMP_Text countdownText;
    private float fullFontSize;

    void Awake() {
        countdownText = this.GetComponent<TMP_Text>();
        fullFontSize = countdownText.fontSize;
    }

    // Update is called once per frame
    void Update() {

        // Create a string for the time
        string countdownString = string.Format("{0:0}", GameManager.S.CountdownTimer);
        countdownText.fontSize = fullFontSize;

        if (!GameManager.S.IsGameStarted) {
            countdownString = "*press space to start*";
            countdownText.fontSize = 50;
        }
        // Change the message when countdown turns 0
        else if (GameManager.S.IsRaceActive) {
            countdownString = "GO!";
            countdownText.transform.position = new Vector3(countdownText.transform.position.x, countdownText.transform.position.y + 0.5f, countdownText.transform.position.z);
        }

        // Add the string to our ui text
        countdownText.text = countdownString;
    }
}
