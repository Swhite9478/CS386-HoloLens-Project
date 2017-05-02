using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    public float scale;
    public Vector3 cameraOffset;
    private GameObject plane;
    public GesterManager gManager;

    // Use this for initialization
    void Start ()
    {
        gManager = new GesterManager();
        plane = GameObject.Find("Floor");
    }

    // Update is called once per frame
    void FixedUpdate() {

    }

    void adjustPosition(){
    }
}
