using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Racer : MonoBehaviour
{
    public KeyCode driveKey;
    public float driveSpeed = 0;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // When drive key pressed, move the racer forward
        if(Input.GetKeyDown(driveKey)){
            rb.velocity += transform.forward * driveSpeed;
        }

        //var targetRotation = Quaternion.LookRotation(transform.position + rb.velocity.normalized);
        //transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 50f * Time.deltaTime);
        transform.LookAt(transform.position + rb.velocity);

    }

}
