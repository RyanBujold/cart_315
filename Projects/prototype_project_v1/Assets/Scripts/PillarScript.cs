using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillarScript : MonoBehaviour
{
    public Vector3 Position1;
    public Vector3 Position2;
    public float PillarSpeed;

    private Vector3 chasePosition;
    private bool chasingPos1;
    private float xPos;
    private float yPos;
    private float zPos;

    // Start is called before the first frame update
    void Start() {
        //this.transform.position = new Vector3(Position1.x, Position1.y, Position1.z);
        chasePosition = Position2;
        chasingPos1 = true;
    }

    // Update is called once per frame
    void Update() {
        // When we reach our chase position, change to our other saved position
        float distance = Vector3.Distance(this.transform.position, chasePosition);
        if (distance < 1f) {
            if (chasingPos1) {
                chasePosition = Position2;
                chasingPos1 = false;
            }
            else {
                chasePosition = Position1;
                chasingPos1 = true;
            }
        }

        this.transform.position = Vector3.MoveTowards(this.transform.position, chasePosition, PillarSpeed);

        /*// Moving Down
        if (this.transform.position.y > chasePosition.y) {
            yPos -= PillarSpeed * Time.deltaTime;
        }
        // Moving Up
        if (this.transform.position.y < chasePosition.y) {
            yPos += PillarSpeed * Time.deltaTime;
        }
        // Moving Left
        if (this.transform.position.x > chasePosition.x) {
            xPos -= PillarSpeed * Time.deltaTime;
        }
        // Moving Right
        if (this.transform.position.x < chasePosition.x) {
            xPos += PillarSpeed * Time.deltaTime;
        }
        // Moving In
        if (this.transform.position.z > chasePosition.z) {
            zPos -= PillarSpeed * Time.deltaTime;
        }
        // Moving Out
        if (this.transform.position.z < chasePosition.z) {
            zPos += PillarSpeed * Time.deltaTime;
        }*/

        //transform.localPosition = new Vector3(xPos, yPos, zPos);
    }
}
