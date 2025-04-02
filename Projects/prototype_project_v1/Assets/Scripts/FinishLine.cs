using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    public AudioSource winSound;

    void Start() {
        winSound.volume = 10f;
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Racer") {
            winSound.Play();
            GameManager.S.EndRace();
        }
    }
}
