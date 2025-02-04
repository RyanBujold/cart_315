using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPaddleScript : MonoBehaviour {
    private float yPos;
    public float paddleSpeed = .05f;
    public float topWall, bottomWall;

    public GameObject Ball;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        // Moving Down
        if (this.transform.position.y > Ball.transform.position.y && yPos > bottomWall) {
            yPos -= paddleSpeed * Time.deltaTime;
        }
        // Moving Up
        if (this.transform.position.y < Ball.transform.position.y && yPos < topWall) {
            yPos += paddleSpeed * Time.deltaTime;
        }

        transform.localPosition = new Vector3(transform.position.x, yPos, 0);
    }
}
