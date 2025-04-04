using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Racer : MonoBehaviour
{
    public KeyCode driveKey, brakeKey,restartKey;
    public AudioSource au;
    public AudioSource engine;
    public AudioClip crashSound;
    public AudioClip bounceSound;
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
                AddVelocity((transform.forward * driveSpeed) * Time.deltaTime);
            }
            // When brake key pressed, slow down the racer
            if(Input.GetKey(brakeKey)) {
                Brake();
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

        // Match engine pitch to speed
        //200x -3y = 0
        engine.pitch = (3 * GetCurrentVelocity())/200;

    }

    public float GetCurrentVelocity(){
        return rb.velocity.magnitude;
    }

    public void AddVelocity(Vector3 vector) {
        rb.velocity += vector;
    }

    private void Brake() {
        rb.velocity /= (1.005f);
    }

    private void OnCollisionEnter(Collision other) {
        // did we hit an obstacle
        if (other.gameObject.tag == "Obstacle") {
            au.PlayOneShot(crashSound,8f);
            Lose();
        }
        if(other.gameObject.tag == "Bouncer") {
            au.PlayOneShot(bounceSound, 10f);
        }
    }

    private void Reset() {
        transform.position = startingPosition;
        transform.rotation = startingRotation;
        rb.velocity = new Vector3(0f, 0f, 0f);
        rb.angularVelocity = new Vector3(0f, 0f, 0f);
    }

    public void Lose() {
        Reset();
        GameManager.S.Reset();
    }

}
