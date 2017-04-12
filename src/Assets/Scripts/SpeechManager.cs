using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class SpeechManager : MonoBehaviour
{
    KeywordRecognizer keywordRecognizer = null;
    Dictionary<string, System.Action> keywords = new Dictionary<string, System.Action>();
    

    // Use this for initialization
    void Start()
    {
       
        keywords.Add("Cancel", () =>
        {
            this.BroadcastMessage("CancelAudio");
        });

        keywords.Add("random", () =>
        {
            // Call the OnReset method on every descendant object.
            this.BroadcastMessage("Daniel");
        });
        // Intentionally misspelled gravity
        keywords.Add("gravity on", () =>
        {
            // Call the OnReset method on every descendant object.
            this.BroadcastMessage("Jack");
        });

        keywords.Add("Reset", () =>
        {
            // Call the OnReset method on every descendant object.
            this.BroadcastMessage("OnReset");
        });

        keywords.Add("Drop", () =>
        {
            var focusObject = HelperForGrav.Instance.FocusedObject;
            if (focusObject != null)
            {
                // Call the OnDrop method on just the focused object.
                focusObject.SendMessage("OnDrop");
            }
        });

        // Tell the KeywordRecognizer about our keywords.
        keywordRecognizer = new KeywordRecognizer(keywords.Keys.ToArray());

        // Register a callback for the KeywordRecognizer and start recognizing!
        keywordRecognizer.OnPhraseRecognized += KeywordRecognizer_OnPhraseRecognized;
        keywordRecognizer.Start();
    }

    private void KeywordRecognizer_OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
        System.Action keywordAction;
        if (keywords.TryGetValue(args.text, out keywordAction))
        {
            keywordAction.Invoke();
        }
    }
}