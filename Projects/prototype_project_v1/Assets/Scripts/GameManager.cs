using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager S;

    // Start is called before the first frame update
    void Awake() {
        S = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RaceWon() {
        Debug.Log("FINISH!!!");
    }

    public void TestLogs() {
        Debug.Log("Testing the debug logs");
    }

}
