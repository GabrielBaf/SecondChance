using UnityEngine;
using System.Collections;

public class IntroKateAudioDay4A_1 : MonoBehaviour {

    public Waypoint_3WPS Kate;
    public GameObject DialoguePanel;

    bool AlreadyPlayed = false;
	// Update is called once per frame
	void Update () {

        if (Kate.left == true && AlreadyPlayed == false)
        {
            AlreadyPlayed = true;

            gameObject.GetComponent<VoicesAudio>().StartDialogueAudio = true;
        }

        if (DialoguePanel.activeSelf == false && AlreadyPlayed)
        {
            gameObject.GetComponent<VoicesAudio>().StartDialogueAudio = false;

            Destroy(this, 0.5f);
        }

	}
}
