using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

// Borrowed code for ui here https://connect-prd-cdn.unity.com/20190702/c49e63c9-6611-4342-8ed3-11dd7ad2e014_Lesson_Plan_5.2___Keeping_Score.pdf

public class GameManager : MonoBehaviour {
    public int points;
    private int numBricksToHit = 0;
    private int numBricksHit = 0;
    private float timePassed;
    private bool didWin = false;
    public float goalTime = 100f;
    public bool gameStarted = false;

    public Image heartImage;
    public TextMeshProUGUI textMesh;

    public static GameManager S;
    
    // Start is called before the first frame update
    void Awake() {
        S = this;
    }

    void Start() {
        timePassed = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(!gameStarted) {
            if(Input.GetKeyDown(KeyCode.Space)) {
                gameStarted = true;
            }
        }
        
        if (numBricksToHit == numBricksHit && !didWin) {
            didWin = true;
            if (timePassed < goalTime) {
                textMesh.text = "Victory! Here is your final time: " + (Mathf.Round(timePassed * 100.0f) * 0.01f) + "s";
            }
            else {
                textMesh.text = "Better Luck Next Time! Here is your final time: " + (Mathf.Round(timePassed * 100.0f) * 0.01f) + "s";
            }
        }

        if (!didWin && gameStarted) {
            timePassed += Time.deltaTime;
            textMesh.text = "Goal Time: " + goalTime + "s | Time: " + (Mathf.Round(timePassed * 100.0f) * 0.01f) + "s";
        }
        
    }
    
    public void AddPoint(int numPoints) {
        points += numPoints;
    }

    public void AddBrickToHit() {
        numBricksToHit ++;
    }

    public void AddBricksHit() {
        numBricksHit ++;
        Debug.Log(numBricksHit + "/" + numBricksToHit);
    }
}
