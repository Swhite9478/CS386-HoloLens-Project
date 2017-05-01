using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
    public float speed;

    private Rigidbody rb;

    void Start() {
        rb = GetComponent<Rigidbody>();
    }
    /*
    void OnTriggerEnter(Collider other){
        print("Collide...");
        if (other.gameObject.CompareTag("Pickup")) {
            print("Collide!");
            other.gameObject.SetActive(false);
            count++;
            setCountText();
        }
    }
    */

}
