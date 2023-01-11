using UnityEngine;
using System.Collections;

public class VoiceControlDia4B_1 : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Invoke("Settop", 1.0f);
    }

	// Update is called once per frame
	void Update () {

	}

    void Settop()
    {
        gameObject.GetComponent<VoicesAudio>().StartDialogueAudio = true;
    }
}
