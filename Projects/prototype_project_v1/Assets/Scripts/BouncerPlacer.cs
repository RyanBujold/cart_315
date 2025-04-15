using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncerPlacer : MonoBehaviour
{
    // Borrowed destroying objects code
    // https://discussions.unity.com/t/how-to-delete-all-game-objects-that-have-clone-in-the-name/877313

    public Transform Racer;
    public GameObject BouncerToSpawn;
    public KeyCode rotateRightKey, rotateLeftKey, resetKey;

    private const float distanceFromCamera = 30f;
    private const float rotationAmount = 200f;
    private float minPositionY = 0f;
    private List<GameObject> bouncers;

    private bool mouseCliked = false;

    // Start is called before the first frame update
    void Start()
    {
        bouncers = new List<GameObject> ();
    }

    // Update is called once per frame
    void Update()
    {
        // Turn the mouse position on the screen into a position in the world
        transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, distanceFromCamera));
        // Make sure position doesn't drop too low
        minPositionY = Racer.transform.position.y;
        if(transform.position.y < minPositionY) {
            transform.position = new Vector3(transform.position.x, minPositionY, transform.position.z);
        }
        
        // If mouse pressed down, place a bouncer
        if (Input.GetMouseButtonDown(0) && !mouseCliked) {
            CreateNewBouncer();
            mouseCliked = true;
        }
        // Wait until mouse is released before placing another bouncer
        if (Input.GetMouseButtonUp(0)) {
            mouseCliked = false;
        }
        // If reset key pressed remove all the bouncers
        if (Input.GetKeyDown(resetKey)) {
            DestroyAllBouncers();
        }

        // Rotate with keys
        if(Input.GetKey(rotateLeftKey)) {
            transform.Rotate(0, rotationAmount * Time.deltaTime, 0, Space.Self);
        }
        if (Input.GetKey(rotateRightKey)) {
            transform.Rotate(0, -rotationAmount * Time.deltaTime, 0, Space.Self);
        }
        // Rotate with scroll wheel
        if (Input.GetAxis("Mouse ScrollWheel") > 0f) {
            transform.Rotate(0, rotationAmount * Time.deltaTime * 10, 0, Space.Self);
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0f) {
            transform.Rotate(0, -rotationAmount * Time.deltaTime * 10, 0, Space.Self);
        }

    }

    private void CreateNewBouncer() {
        GameObject instance = Instantiate(BouncerToSpawn, transform.position, transform.rotation);
        bouncers.Add(instance);
    }

    private void DestroyAllBouncers() {
        foreach (GameObject bouncer in bouncers) {
            Destroy(bouncer);
        }
        bouncers.Clear();
    }
}
