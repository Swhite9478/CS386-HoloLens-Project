using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VR.WSA.Input;

public class GesterManager : MonoBehaviour {

    GestureRecognizer ManipulateRec;
    Floor floor;
    Vector3 start;
	// Use this for initialization
	void Start () {
        ManipulateRec.SetRecognizableGestures(GestureSettings.ManipulationTranslate);

        ManipulateRec.ManipulationStartedEvent += ManipStart;
        ManipulateRec.ManipulationUpdatedEvent += ManipUpdate;
        ManipulateRec.ManipulationCompletedEvent += ManipComplete;

        ManipulateRec.StartCapturingGestures();

    }

    public void ManipStart(InteractionSourceKind source, Vector3 pos, Ray ray) {
        print("Starting manipulation");
        start = pos;
    }

    public void ManipUpdate(InteractionSourceKind source, Vector3 pos, Ray ray) {
        print("continuing manipulation");
        floor.gameObject.transform.Rotate(pos - start);
        start = pos;
    }

    public void ManipComplete(InteractionSourceKind source, Vector3 pos, Ray ray) {
        print("Manipulation complete");     
    }

    // Update is called once per frame
    void Update () {
		
	}
}
