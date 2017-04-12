using UnityEngine;

public class addGrav : MonoBehaviour
{
    Vector3 originalPosition;
    public Quaternion originalRotationValue; // declare this as a Quaternion
    float rotationResetSpeed = 1.0f;
    AudioSource audioSource = null;
    AudioClip audioClip = null;

    // Use this for initialization
    void Start()
    {
        // Grab the original local position of the sphere when the app starts.
        originalPosition = this.transform.localPosition;
        originalRotationValue = transform.rotation; // save the initial rotation
    }

    // Called by GazeGestureManager when the user performs a Select gesture
    void OnSelect()
    {
        // If the sphere has no Rigidbody component, add one to enable physics.
        if (!this.GetComponent<Rigidbody>())
        {
            var rigidbody = this.gameObject.AddComponent<Rigidbody>();
            rigidbody.collisionDetectionMode = CollisionDetectionMode.Continuous;
        }
    }

    // Called by SpeechManager when the user says the "Reset" command
    void OnReset()
    {
        // If the sphere has a Rigidbody component, remove it to disable physics.
        var rigidbody = this.GetComponent<Rigidbody>();
        if (rigidbody != null)
        {
            DestroyImmediate(rigidbody);
        }

        // Put the sphere back into its original local position.
        this.transform.localPosition = originalPosition;
        transform.rotation = Quaternion.Slerp(transform.rotation, originalRotationValue, Time.time * rotationResetSpeed);
        Physics.gravity = new Vector3(0, -9.8F, 0);
    }

    void Jack()
    {
        // If the sphere has no Rigidbody component, add one to enable physics.
        if (!this.GetComponent<Rigidbody>())
        {
            var rigidbody = this.gameObject.AddComponent<Rigidbody>();
            rigidbody.collisionDetectionMode = CollisionDetectionMode.Continuous;

            // Add an AudioSource component and set up some defaults
            audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.playOnAwake = false;
            audioSource.spatialize = true;
            audioSource.enabled = true;
            audioSource.spatialBlend = 1.0f;
            audioSource.dopplerLevel = 0.0f;
            audioSource.rolloffMode = AudioRolloffMode.Logarithmic;
            audioSource.maxDistance = 20f;
            audioClip = Resources.Load<AudioClip>("Voice_Recognition");
            audioSource.clip = audioClip;
            audioSource.Play();
        }

    }

    void CancelAudio()
    {   if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }
        else return;
    }

    void Daniel()
    {
        Physics.gravity = new Vector3(Random.Range(-10.0f, 10.0f), Random.Range(-10.0f, 10.0f), Random.Range(-10.0f, 10.0f));
        // If the sphere has no Rigidbody component, add one to enable physics.
        if (!this.GetComponent<Rigidbody>())
        {
            var rigidbody = this.gameObject.AddComponent<Rigidbody>();
            rigidbody.collisionDetectionMode = CollisionDetectionMode.Continuous;
            /*
            audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.playOnAwake = false;
            audioSource.spatialize = true;
            audioSource.enabled = true;
            audioSource.spatialBlend = 1.0f;
            audioSource.dopplerLevel = 0.0f;
            audioSource.rolloffMode = AudioRolloffMode.Logarithmic;
            audioSource.maxDistance = 20f;
            audioClip = Resources.Load<AudioClip>("Tilt-A-Ball");
            audioSource.clip = audioClip;
            audioSource.Play();*/
        }    

    }

    // Called by SpeechManager when the user says the "Drop sphere" command
    void OnDrop()
    {
        // Just do the same logic as a Select gesture.
        OnSelect();
    }
}