using UnityEngine;
using System.Collections;

public class ClassDialogueAudioDia1B : MonoBehaviour {

    public GameObject ClassCam;
    public GameObject Charlie;

    bool AlreadyPlay01 = false;
    bool AlreadyPlay02 = false;

	// Update is called once per frame
	void Update () {

        if (ClassCam.activeSelf && AlreadyPlay01 == false)
        {
            AlreadyPlay01 = true;

            gameObject.GetComponent<VoicesAudio>().StartDialogueAudio = true;
        }

        if (ClassCam.activeSelf == false && AlreadyPlay01)
        {
            AlreadyPlay02 = true;

            gameObject.GetComponent<VoicesAudio>().StartDialogueAudio = false;
        }

        if (ClassCam.activeSelf && AlreadyPlay02)
        {
            AlreadyPlay01 = true;

            gameObject.GetComponent<VoicesAudio>().StartDialogueAudio = true;
        }

        if (ClassCam.activeSelf == false && Charlie.activeSelf)
        {
            gameObject.GetComponent<VoicesAudio>().StartDialogueAudio = false;
        }
    }
}
