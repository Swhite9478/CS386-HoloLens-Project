using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour {
    GameObject go;
  
    public void SetPos(Vector3 pos) {
        go.transform.position = pos;
    }

    void Start() {
        Particle:
        go = gameObject;
        transform.rotation = new Quaternion(45, 45, 45, 45);
        transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        tag = "Pickup";
        
        /*
        go.AddComponent<BoxCollider>();
        go.GetComponent<BoxCollider>().isTrigger = true;
        */
        //GetComponent<Collider>().enabled = false;
        GetComponent<Collider>().isTrigger = true;

    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Player")) {
            print("Collide!");
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update () {
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
    }
}
