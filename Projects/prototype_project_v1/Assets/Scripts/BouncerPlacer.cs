using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncerPlacer : MonoBehaviour
{
    public Transform Racer;
    public GameObject BouncerToSpawn;
    public KeyCode rotateRightKey, rotateLeftKey;

    private const float distanceFromCamera = 30f;

    private bool mouseCliked = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, distanceFromCamera));

        if (Input.GetMouseButtonDown(0) && !mouseCliked) {
            Instantiate(BouncerToSpawn, transform.position, transform.rotation);
            mouseCliked = true;
        }
        if (Input.GetMouseButtonUp(0)) {
            mouseCliked = false;
        }

        if(Input.GetKeyDown(rotateLeftKey)) {
            transform.Rotate(0, 45, 0, Space.Self);
        }

        if (Input.GetKeyDown(rotateRightKey)) {
            transform.Rotate(0, -45, 0, Space.Self);
        }

    }
}
