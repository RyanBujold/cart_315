using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakoutPaddleGuy : MonoBehaviour {
    private float     xPos;
    private float     yPos;
    private float zRot;
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    public float      paddleSpeed = 10f;
    private float jumpHeight = 3f;
    public float      leftWall, rightWall, bottomWall;
    private const float JUMP_COOLDOWN_TIME = 1f;
    private float jumpCooldownCounter = 0f;
    private bool isJumpOnCooldown = false;
    public float rotationSpeed = 1f;

    public KeyCode leftKey, rightKey, jumpUpKey, jumpDownKey, rotateRightKey, rotateLeftKey;

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

        zRot = 0f;
        if (Input.GetKey(rotateRightKey)) {
            zRot -= rotationSpeed;
        }

        if(Input.GetKey(rotateLeftKey)) {
            zRot += rotationSpeed;
        }


        if (Input.GetKeyDown(jumpUpKey) && !isJumpOnCooldown && GameManager.S.gameStarted) {
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

        transform.localPosition = new Vector3(xPos, transform.position.y, 0);
        transform.Rotate(transform.rotation.x, transform.rotation.y, zRot);
    }
}

