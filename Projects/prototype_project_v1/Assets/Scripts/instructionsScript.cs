using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instructionsScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.S.IsRaceActive) {
            this.gameObject.SetActive(false);
        }
        else {
            this.gameObject.SetActive(true);
        }
    }
}
