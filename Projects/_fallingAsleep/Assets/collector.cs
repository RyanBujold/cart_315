using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collector : MonoBehaviour
{

    public float XLoc = 0;
    public float YLoc = 0;
    public float Speed = 0.05f;

    // Start is called before the first frame update
    void Start()
    {
        XLoc = 0;
        YLoc = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Z)){
            Debug.Log("Left");
            XLoc -= Speed;
        }
        if(Input.GetKey(KeyCode.X)){
            Debug.Log("Right");
            XLoc += Speed;
        }

        this.transform.position = new Vector3(XLoc, YLoc, 0);
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Circle"){
            Destroy(other.gameObject);
        }
    }
}
