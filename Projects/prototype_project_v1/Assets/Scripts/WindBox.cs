using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindBox : MonoBehaviour
{
    public Vector3 WindDirection;

    private void OnTriggerStay(Collider other) {
        if (other.gameObject.tag == "Racer") {
            Racer racer = other.gameObject.GetComponent<Racer>();
            racer.AddVelocity(WindDirection);
        }
    }
}
