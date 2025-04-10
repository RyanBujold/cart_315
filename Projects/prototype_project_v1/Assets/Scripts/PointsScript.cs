using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PointsScript : MonoBehaviour
{
    private TMP_Text pointText;

    void Awake() {
        pointText = this.GetComponent<TMP_Text>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        pointText.text = "Points: " + GameManager.S.PointTotal;
    }
}
