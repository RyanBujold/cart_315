using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    public int points;
    private int numBricksToHit = 0;
    private int numBricksHit = 0;
    private float timePassed;
    private bool didWin = false;

    public Image heartImage;

    public static GameManager S;
    
    // Start is called before the first frame update
    void Awake() {
        S = this;
    }

    void Start() {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(numBricksToHit == numBricksHit && !didWin) {
            didWin = true;
            Debug.Log("VICTORY");
            Debug.Log("TOTAL TIME: " + timePassed +"s");
        }

        if (!didWin) {
            timePassed += Time.deltaTime;
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
