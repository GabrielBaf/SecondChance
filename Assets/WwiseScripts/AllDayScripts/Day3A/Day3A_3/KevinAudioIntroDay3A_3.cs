using UnityEngine;
using System.Collections;

public class KevinAudioIntroDay3A_3 : MonoBehaviour {

    public GameObject VestiarioCam;
    public GameObject DialoguePanel;

    bool AlreadyPlayed = false;

	// Update is called once per frame
	void Update () {

        if (VestiarioCam.activeSelf && AlreadyPlayed == false)
        {
            gameObject.GetComponent<VoicesAudio>().StartDialogueAudio = true;

            if (DialoguePanel.activeSelf)
            {
                AlreadyPlayed = true;
            }
        }

        if (DialoguePanel.activeSelf == false && AlreadyPlayed)
        {
            gameObject.GetComponent<VoicesAudio>().StartDialogueAudio = false;

            Destroy(this, 0.5f);
        }
	}
}
