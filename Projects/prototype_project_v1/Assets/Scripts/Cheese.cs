using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cheese : MonoBehaviour
{

    private readonly float rotationSpeed = 100f;
    private int pointValue = 100;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() {
        this.transform.Rotate(0f, (rotationSpeed * Time.deltaTime), 0f, Space.Self);
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Racer") {
            GameManager.S.AddPoints(pointValue);
            this.gameObject.SetActive(false);
        }
    }
}
