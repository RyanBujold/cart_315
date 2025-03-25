using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CountdownScirpt : MonoBehaviour
{
    private TMP_Text countdownText;

    void Awake() {
        countdownText = this.GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update() {

        // Create a string for the time
        string countdownString = string.Format("{0:0}", GameManager.S.CountdownTimer);

        // Change the message when countdown turns 0
        if (GameManager.S.IsRaceActive) {
            countdownString = "GO!";
            countdownText.transform.position = new Vector3(countdownText.transform.position.x, countdownText.transform.position.y + 0.5f, countdownText.transform.position.z);
        }

        // Add the string to our ui text
        countdownText.text = countdownString;
    }
}
