using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    private void OnTriggerStay(Collider other) {
        if (other.gameObject.tag == "Racer") {
            GameManager.S.RaceWon();
        }
    }
}
