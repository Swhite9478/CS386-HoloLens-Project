using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    public float scale;
    public Vector3 cameraOffset;
    private GameObject plane;

	// Use this for initialization
	void Start () {
        plane = GameObject.Find("Floor");
    }

    // Update is called once per frame
    void FixedUpdate() {

    }

    void adjustPosition(){
    }
}
