using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakoutPaddleGuy : MonoBehaviour {
    private float     xPos;
    private float     yPos;
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    public float      paddleSpeed = 10f;
    private float jumpHeight = 3f;
    public float      leftWall, rightWall, bottomWall;
    private const float JUMP_COOLDOWN_TIME = 1f;
    private float jumpCooldownCounter = 0f;
    private bool isJumpOnCooldown = false;

    public KeyCode leftKey, rightKey, jumpUpKey, jumpDownKey;

    // Start is called before the first frame update
    void Start() {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
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

        if(Input.GetKeyDown(jumpUpKey) && !isJumpOnCooldown) {
            rb.AddForce(transform.up * jumpHeight);
            isJumpOnCooldown = true;
        }

        if (isJumpOnCooldown) {
            jumpCooldownCounter += Time.deltaTime;
            if (jumpCooldownCounter > JUMP_COOLDOWN_TIME) {
                isJumpOnCooldown = false;
                jumpCooldownCounter = 0f;
            }
            sr.color = Color.gray;
        }
        else {
            sr.color = Color.white;
        }


        /*if (Input.GetKeyDown(jumpDownKey)) {
            rb.AddForce(-transform.up * jumpHeight);
        }*/

        transform.localPosition = new Vector3(xPos, transform.position.y, 0);
    }
}

