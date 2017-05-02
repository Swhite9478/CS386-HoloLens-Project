using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour {
    GameObject[] pickups;
    static readonly float radius = (float) 0.15;
	// Use this for initialization
	void Start () {
        print("JAMES THIS IS WHERE IT'S PRINTING TO!");
        pickups = new GameObject[0];
        float delta_ang = Mathf.PI * 2 / pickups.Length;
        
        for (int i = 0; i < pickups.Length; i++) {
            GameObject pickup = GameObject.CreatePrimitive(PrimitiveType.Cube);
            pickups[i] = pickup;

            pickup.AddComponent<Pickup>();
            
            pickup.transform.SetParent(this.transform);

            float angle = delta_ang * i;
            pickup.transform.position= (this.transform.position + new Vector3(Mathf.Sin(angle) * radius, (float) 0.03, Mathf.Cos(angle) * radius));
            
            //pickup.transform.position = this.transform.position + new Vector3(Mathf.Sin(angle) * radius, 1, Mathf.Cos(angle) * radius) ;
            

            // Note to self, this is entertaining!
            // pickup.AddComponent<Rigidbody>();

        }

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
