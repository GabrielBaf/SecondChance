using UnityEngine;
using System.Collections;

public class AndyTalkDia6Good : MonoBehaviour {

    public GameObject OutCam;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
        if (OutCam.activeSelf)
        {
            gameObject.GetComponent<VoicesAudio>().StartDialogueAudio = true;
        }
	}
}
