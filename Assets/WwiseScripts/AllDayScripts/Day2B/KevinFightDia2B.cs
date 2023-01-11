using UnityEngine;
using System.Collections;
using PixelCrushers.DialogueSystem;

public class KevinFightDia2B : MonoBehaviour {


    public ConversationTrigger KevinFight;

    public GameObject Class_Cam;

    bool Alreadyplay = false;

	// Update is called once per frame
	void Update () {

        if (KevinFight == null)
        {
            gameObject.GetComponent<VoicesAudio>().StartDialogueAudio = true;
        }

        if (Class_Cam.activeSelf && Alreadyplay == false)
        {
            Alreadyplay = true;

            gameObject.GetComponent<VoicesAudio>().StartDialogueAudio = false;

            Destroy(this);
        }


	}
}
