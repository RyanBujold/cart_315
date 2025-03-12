using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RacerCamera : MonoBehaviour
{
    public Transform Racer;

    private float maxCameraDistance;
    private Vector3 cameraOffset;
    private Transform initialCamera;
    private Rigidbody racerRB;

    // Start is called before the first frame update
    void Start()
    {
        cameraOffset = transform.position - Racer.position;
        maxCameraDistance = Vector3.Distance(transform.position, Racer.transform.position);
        initialCamera = transform;
        racerRB = Racer.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update() { 

        //if (Vector3.Distance(transform.position, Racer.transform.position) >= maxCameraDistance) {

            //Vector3 targetPosition = Racer.position + cameraOffset;

            //transform.position = Vector3.MoveTowards(transform.position, targetPosition, 0.5f);
        //}

        //transform.rotation = Quaternion.LookRotation(racerRB.velocity, Vector3.up);
        //transform.LookAt(new Vector3(Racer.position.x, transform.position.y, Racer.position.z));
        //transform.Rotate(8.45f, 0f, 0f, Space.Self);
        //transform.rotation = Quaternion.Euler(initialCamera.rotation.x, transform.rotation.y, initialCamera.rotation.z);

        //transform.position = new Vector3(transform.position.x,initialCamera.position.y,transform.position.z);

    }

}
