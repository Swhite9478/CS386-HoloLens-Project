using UnityEngine;
using UnityEngine.VR.WSA.Input;

public class Tilt_A_Ball_AUDIO : MonoBehaviour
{
    AudioSource audioSource = null;
    AudioClip audioClip = null;

    public static Tilt_A_Ball_AUDIO Instance { get; private set; }

    // Represents the hologram that is currently being gazed at.
    public GameObject FocusedObject { get; private set; }

    GestureRecognizer recognizer;


    bool rolling = false;

    void Start()
    {
        // Add an AudioSource component and set up some defaults
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false;
        audioSource.spatialize = true;
        audioSource.enabled = true;
        audioSource.spatialBlend = 1.0f;
        audioSource.dopplerLevel = 0.0f;
        audioSource.rolloffMode = AudioRolloffMode.Logarithmic;
        audioSource.maxDistance = 20f;

        // Load the Sphere sounds from the Resources folder
        audioClip = Resources.Load<AudioClip>("Tilt-A-Ball");
    }

    void Awake()
    {
        Instance = this;

        // Set up a GestureRecognizer to detect Select gestures.
        recognizer = new GestureRecognizer();
        recognizer.TappedEvent += (source, tapCount, ray) =>
        {
            // Send an OnSelect message to the focused object and its ancestors.
            if (FocusedObject != null)
            {
                if (!audioSource.isPlaying)
                {
                    FocusedObject.SendMessage("playSounds");
                }
                else
                {
                    FocusedObject.SendMessage("stopSounds");
                }
            }
        };
        recognizer.StartCapturingGestures();
    }

    // Update is called once per frame
    void Update()
    {
        // Figure out which hologram is focused this frame.
        GameObject oldFocusObject = FocusedObject;

        // Do a raycast into the world based on the user's
        // head position and orientation.
        var headPosition = Camera.main.transform.position;
        var gazeDirection = Camera.main.transform.forward;

        RaycastHit hitInfo;
        if (Physics.Raycast(headPosition, gazeDirection, out hitInfo))
        {
            // If the raycast hit a hologram, use that as the focused object.
            FocusedObject = hitInfo.collider.gameObject;
        }
        else
        {
            // If the raycast did not hit a hologram, clear the focused object.
            FocusedObject = null;
        }

        // If the focused object changed this frame,
        // start detecting fresh gestures again.
        if (FocusedObject != oldFocusObject)
        {
            recognizer.CancelGestures();
            recognizer.StartCapturingGestures();
        }
    }

    void playSounds()
    {
        audioSource.clip = audioClip;
        audioSource.Play();
    }

    void stopSounds()
    {
        audioSource.enabled = false;
        audioSource.Stop();
    }

}