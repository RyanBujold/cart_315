using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    public Racer racer;

    public TMP_Text speedometer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Update Speedometer
        speedometer.text = Mathf.Round(racer.GetCurrentVelocity()) + " KMPH";
    }
}
