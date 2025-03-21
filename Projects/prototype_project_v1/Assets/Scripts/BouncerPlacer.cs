using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncerPlacer : MonoBehaviour
{
    public Transform Racer;
    public GameObject BouncerToSpawn;
    public KeyCode rotateRightKey, rotateLeftKey;

    private const float distanceFromCamera = 30f;
    private const float rotationAmount = 0.5f;
    private const float minPositionY = 1f;

    private bool mouseCliked = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Turn the mouse position on the screen into a position in the world
        transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, distanceFromCamera));
        // Make sure position doesn't drop too low
        if(transform.position.y < minPositionY) {
            transform.position = new Vector3(transform.position.x, minPositionY, transform.position.z);
        }
        
        // If mouse pressed down, place a bouncer
        if (Input.GetMouseButtonDown(0) && !mouseCliked) {
            Instantiate(BouncerToSpawn, transform.position, transform.rotation);
            mouseCliked = true;
        }
        // Wait until mouse is released before placing another bouncer
        if (Input.GetMouseButtonUp(0)) {
            mouseCliked = false;
        }

        // Rotate bouncer placement
        if(Input.GetKey(rotateLeftKey)) {
            transform.Rotate(0, rotationAmount, 0, Space.Self);
        }
        if (Input.GetKey(rotateRightKey)) {
            transform.Rotate(0, -rotationAmount, 0, Space.Self);
        }

    }
}
