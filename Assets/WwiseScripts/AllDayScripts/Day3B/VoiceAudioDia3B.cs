using UnityEngine;
using System.Collections;

public class VoiceAudioDia3B : MonoBehaviour {

    public GameObject Charlie;

	// Use this for initialization
	void Start () {
        Invoke("Settop", 1.0f);
	}

	// Update is called once per frame
	void Update () {
        if (Charlie.activeSelf)
        {
            gameObject.GetComponent<VoicesAudio>().StartDialogueAudio = false;
        }
	}

    void Settop()
    {
        gameObject.GetComponent<VoicesAudio>().StartDialogueAudio = true;
    }
}
