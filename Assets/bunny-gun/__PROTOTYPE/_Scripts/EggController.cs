using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggController : MonoBehaviour {

    void OnEnable () {

        Destroy (gameObject, 4f);
    }
    
    void OnCollisionEnter2D (Collision2D other) {

        if (other.transform.CompareTag ("Player")) {

            other.transform.GetComponent<PlayerController> ().OnHit ();
        }
        Destroy (gameObject, 0.1f);
    }

}