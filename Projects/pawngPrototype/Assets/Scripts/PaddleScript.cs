using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleScript : MonoBehaviour {
    private float     yPos;
    public float      paddleSpeed = .05f;
    public float      topWall, bottomWall;

    public KeyCode upKey, downKey;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKey(downKey) && yPos > bottomWall) {
            if (yPos > bottomWall) {
                yPos -= paddleSpeed * Time.deltaTime;
            }
        }

        if (Input.GetKey(upKey) && yPos < topWall) {
            if (yPos < topWall) {
                yPos += paddleSpeed * Time.deltaTime;
            }
        }

        transform.localPosition = new Vector3(transform.position.x, yPos, 0);
    }
}

