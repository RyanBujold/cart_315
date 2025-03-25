using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public static GameManager S;

    public readonly float GOAL_TIME = 75;

    public float Timer { get; private set; }
    public float CountdownTimer { get; private set; }
    public bool IsRaceActive { get; private set; }

    private const float STARTING_COUNTDOWN_TIME = 3;

    // Start is called before the first frame update
    void Awake() {
        S = this;
    }

    void Start() {
        Timer = 0;
        CountdownTimer = STARTING_COUNTDOWN_TIME;
        IsRaceActive = false;
    }

    // Update is called once per frame
    void Update() {
        // Increment the timer while the race is happening
        if (IsRaceActive) { 
            Timer += Time.deltaTime;
        }
        // Start countdown timer to start race
        else {
            CountdownTimer -= Time.deltaTime;
            if (CountdownTimer <= 0) {
                IsRaceActive = true;
            }
        }
    }

    public void TestLogs() {
        Debug.Log("Testing the debug logs");
    }

    public void StartRace() {
        IsRaceActive = true;
    }

    public void EndRace() {
        IsRaceActive = false;
    }

}
