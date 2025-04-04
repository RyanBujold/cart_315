using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundsCheck : MonoBehaviour
{
    private void OnTriggerExit(Collider other) {
        if (other.gameObject.tag == "Racer") {
            Racer temp = (Racer) other.GetComponent(typeof(Racer));
            temp.Lose();
        }
    }
}
