using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public KeyCode startRaceKey;
    
    public static GameManager S;

    public readonly float GOAL_TIME = 75;

    public float Timer { get; private set; }
    public float CountdownTimer { get; private set; }
    public bool IsRaceActive { get; private set; }
    public bool IsGameStarted { get; private set; }
    public bool IsRaceFinished {  get; private set; }

    private const float STARTING_COUNTDOWN_TIME = 3;

    // Start is called before the first frame update
    void Awake() {
        S = this;
    }

    void Start() {
        Reset();
        CountdownTimer = STARTING_COUNTDOWN_TIME;
    }

    // Update is called once per frame
    void Update() {

        if (IsGameStarted) {
            // Increment the timer while the race is happening
            if (IsRaceActive && !IsRaceFinished) {
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
        // Start the game with this
        else if (Input.GetKeyDown(startRaceKey)) {
            IsGameStarted = true;
        }
        
    }

    public void StartRace() {
        IsRaceActive = true;
    }

    public void EndRace() {
        IsRaceActive = false;
        IsRaceFinished = true;
    }

    public void Reset() {
        Timer = 0;
        IsRaceActive = false;
        IsRaceFinished = false;
    }

}
