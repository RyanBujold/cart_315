using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingWall : MonoBehaviour
{
    private float yPos;
    private float xPos;
    private Vector3 chasePosition;
    private bool chaseStart;
    private Vector3 startPosition;
    public Vector3 endPosition;
    public float wallSpeed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = this.transform.position;
        yPos = startPosition.y;
        xPos = startPosition.x;
        chasePosition = endPosition;
        chaseStart = false;
    }

    // Update is called once per frame
    void Update()
    {
        // When we reach our chase position, change to our other saved position
        float distance = Vector3.Distance(this.transform.position, chasePosition);
        if(distance < 0.3f) {
            if(chaseStart) {
                chasePosition = endPosition;
                chaseStart = false;
            }
            else {
                chasePosition = startPosition;
                chaseStart = true;  
            }
        }

        // Moving Down
        if (this.transform.position.y > chasePosition.y) {
            yPos -= wallSpeed * Time.deltaTime;
        }
        // Moving Up
        if (this.transform.position.y < chasePosition.y) {
            yPos += wallSpeed * Time.deltaTime;
        }
        // Moving Left
        if (this.transform.position.x > chasePosition.x) {
            xPos -= wallSpeed * Time.deltaTime;
        }
        // Moving Right
        if (this.transform.position.x < chasePosition.x) {
            xPos += wallSpeed * Time.deltaTime;
        }

        transform.localPosition = new Vector3(xPos, yPos, 0);
    }
}
