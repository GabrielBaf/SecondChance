using UnityEngine;
using System.Collections;

public class VoiceControlDia5A_3 : MonoBehaviour {

    public GameObject Player;
    public GameObject RoomCam;
    public GameObject OutCam;

    bool SetActiveNow = false;
    bool SwitchMethod = false;

	// Update is called once per frame
	void Update () {

        if (OutCam.activeSelf != true && SetActiveNow == false)
        {
            SetActiveNow = true;

            gameObject.GetComponent<VoicesAudio>().StartDialogueAudio = true;
        }

        if (RoomCam.activeSelf && Player.activeSelf == false)
        {
            SwitchMethod = true;
            gameObject.GetComponent<VoicesAudio>().StartDialogueAudio = false;
        }

        if (OutCam.activeSelf == false && Player.activeSelf && SwitchMethod)
        {
            gameObject.GetComponent<VoicesAudio>().StartDialogueAudio = true;
        }

	}
}
