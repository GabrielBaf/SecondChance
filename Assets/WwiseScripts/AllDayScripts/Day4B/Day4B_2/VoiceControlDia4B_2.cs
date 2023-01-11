using UnityEngine;
using System.Collections;

public class VoiceControlDia4B_2 : MonoBehaviour {

    public GameObject SalaCam;

    // Use this for initialization
    void Start()
    {
        Invoke("Settop", 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (SalaCam.activeSelf)
        {
            gameObject.GetComponent<VoicesAudio>().StartDialogueAudio = false;
        }
    }

    void Settop()
    {
        gameObject.GetComponent<VoicesAudio>().StartDialogueAudio = true;
    }
}
