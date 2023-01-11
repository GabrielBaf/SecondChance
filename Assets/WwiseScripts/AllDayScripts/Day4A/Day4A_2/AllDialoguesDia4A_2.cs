using UnityEngine;
using System.Collections;

public class AllDialoguesDia4A_2 : MonoBehaviour {

    void Start()
    {
        Invoke("AllDialogues", 0.5f);
    }

	// Update is called once per frame
	void Update () {


	}

    void AllDialogues()
    {
        gameObject.GetComponent<VoicesAudio>().StartDialogueAudio = true;
    }
}
