using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakoutPaddleGuy : MonoBehaviour {
    private float     xPos;
    private float     yPos;
    private Rigidbody2D rb;
    public float      paddleSpeed = 10f;
    private float jumpHeight = 5f;
    public float      leftWall, rightWall, bottomWall;

    public KeyCode leftKey, rightKey, jumpUpKey, jumpDownKey;

    // Start is called before the first frame update
    void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKey(leftKey)) {
            if (xPos > leftWall) {
                xPos -= paddleSpeed * Time.deltaTime;
            }
        }

        if (Input.GetKey(rightKey)) {
            if (xPos < rightWall) {
                xPos += paddleSpeed * Time.deltaTime;
            }
        }

        if(Input.GetKeyDown(jumpUpKey)) {
            rb.AddForce(transform.up * jumpHeight);
        }

        if (Input.GetKeyDown(jumpDownKey)) {
            rb.AddForce(-transform.up * jumpHeight);
        }

        transform.localPosition = new Vector3(xPos, transform.position.y, 0);
    }
}

