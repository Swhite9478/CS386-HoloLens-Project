using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testingScript : MonoBehaviour {
    private MeshRenderer meshRenderer;

    // Use this for initialization
    void Start()
    {
        // Grab the mesh renderer that's on the same object as this script.
        meshRenderer = this.gameObject.GetComponentInChildren<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // Do a raycast into the world based on the user's
        // head position and orientation.
        var headPosition = Camera.main.transform.position;
        var gazeDirection = Camera.main.transform.forward;

        RaycastHit hitInfo;

        if (Physics.Raycast(headPosition, gazeDirection, out hitInfo))
        {
            // If the raycast hit a hologram...
            // Display the cursor mesh.
            meshRenderer.enabled = false;


        }
        else
        {
            // Move the cursor to the point where the raycast hit.
            this.transform.position = Camera.main.transform.position + Camera.main.transform.forward*2;

            // Rotate the cursor to hug the surface of the hologram.
       //     this.transform.rotation = Quaternion.FromToRotation(Vector3.up, hitInfo.normal);

            
            meshRenderer.enabled = true;
        }
    }
}
