using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Racer : MonoBehaviour
{
    public KeyCode driveKey, restartKey;
    public float driveSpeed = 0;

    private Rigidbody rb;
    private Vector3 startingPosition;
    private Quaternion startingRotation;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        startingPosition = transform.position;
        startingRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.S.IsRaceActive) {
            // When drive key pressed, move the racer forward
            if (Input.GetKey(driveKey)) {
                rb.velocity += ((transform.forward * driveSpeed) * Time.deltaTime);
            }
            // When restart key pressed, restart game
            if (Input.GetKey(restartKey)) {
                Lose();
            }
        }

        // Always make the ball face the direction of its velocity
        Vector3 velocityToLookAt = transform.position + new Vector3(rb.velocity.x, 0, rb.velocity.z);
        transform.LookAt(velocityToLookAt);

        // Make sure we never have too much y velocity upwards
        if(rb.velocity.y > 5) {
            rb.velocity = new Vector3(rb.velocity.x, 5, rb.velocity.z);
        }

        // If we finish the race, stop the racer
        if (GameManager.S.IsRaceFinished) {
            rb.velocity = new Vector3(0, 0, 0);
        }

    }

    public float GetCurrentVelocity(){
        return rb.velocity.magnitude;
    }

    public void AddVelocity(Vector3 vector) {
        rb.velocity += vector;
    }

    private void OnCollisionEnter(Collision other) {
        // did we hit an obstacle
        if (other.gameObject.tag == "Obstacle") {
            Lose();
        }
    }

    private void Reset() {
        transform.position = startingPosition;
        transform.rotation = startingRotation;
        rb.velocity = new Vector3(0f, 0f, 0f);
        rb.angularVelocity = new Vector3(0f, 0f, 0f);
    }

    private void Lose() {
        Reset();
        GameManager.S.Reset();
    }

}
